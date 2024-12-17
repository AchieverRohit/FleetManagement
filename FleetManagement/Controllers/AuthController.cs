using FleetManagement.Data;
using FleetManagement.Dtos.Auth;
using FleetManagement.Models;
using FleetManagement.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace FleetManagement.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ITokenService _tokenService;
        private readonly SignInManager<ApplicationUser> _signinManager;
        private readonly FleetDbContext _context;
        private readonly IConfiguration _config;



        public AuthController(
            UserManager<ApplicationUser> userManager,
            ITokenService tokenService,
            SignInManager<ApplicationUser> signInManager,
            FleetDbContext context,
            IConfiguration config)
        {
            _context = context;
            _userManager = userManager;
            _tokenService = tokenService;
            _signinManager = signInManager;
            _config = config;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterDto registerDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var applicationUser = new ApplicationUser
                {
                    FirstName = registerDto.Firstname,
                    LastName = registerDto.Lastname,
                    PhoneNumber = registerDto.MobileNo,
                    UserName = registerDto.Email,
                    Email = registerDto.Email,
                    FleetAccountId=registerDto.FleetAccountId
                };

                // Create user
                var createdUser = await _userManager.CreateAsync(applicationUser, registerDto.Password);

                if (createdUser.Succeeded)
                {
                    // Assign a role to the user (if roles are part of the system)
                    if (!string.IsNullOrEmpty(registerDto.Role))
                    {
                        //var roleExists = await _roleManager.RoleExistsAsync(registerDto.Role);
                        //if (!roleExists)
                        //{
                        //    var roleResult = await _roleManager.CreateAsync(new IdentityRole(registerDto.Role));
                        //    if (!roleResult.Succeeded)
                        //        return StatusCode(500, roleResult.Errors);
                        //}

                        var roleAssignmentResult = await _userManager.AddToRoleAsync(applicationUser, registerDto.Role);
                        if (!roleAssignmentResult.Succeeded)
                            return StatusCode(500, roleAssignmentResult.Errors);
                    }

                    // Save user in the database (if additional custom data needs saving)
                    await _context.SaveChangesAsync();

                    // Prepare response
                    var newUserDto = new NewUserDto
                    {
                        UserId = applicationUser.Id,
                        FirstName = applicationUser.FirstName,
                        LastName = applicationUser.LastName,
                        Email = applicationUser.Email,
                        MobileNo = applicationUser.PhoneNumber
                    };
                    if (applicationUser.FleetAccountId!=null)
                    {
                        newUserDto.FleetAccountId=applicationUser.FleetAccountId;
                    }
                    return Ok(newUserDto);
                }
                else
                {
                    return BadRequest(createdUser.Errors);
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Find user by email
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Email.ToLower() == loginDto.Email.ToLower());

            if (user == null)
                return Unauthorized("Invalid Email!");

            // Validate the password
            var result = await _signinManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (!result.Succeeded)
            {
                return Unauthorized("Invalid Email or Password!");
            }

            // Fetch additional user details from the database
            var loggedUser = await _context.Users.FirstOrDefaultAsync(s => s.Id == user.Id);

            if (loggedUser == null)
            {
                return NotFound("User details not found!");
            }

            var jwtToken = await _tokenService.CreateToken(user);
            if (jwtToken == null) return NotFound("Error while creating Token");
            // Create a response with user details and token
            var loggedInUser = new LoggedInUser
            {
                UserId = loggedUser.Id,
                FirstName = loggedUser.FirstName,
                LastName = loggedUser.LastName,
                Email = loggedUser.Email,
                MobileNo = loggedUser.PhoneNumber,
                Role = (await _userManager.GetRolesAsync(user)).FirstOrDefault(),
                Token = jwtToken,
                Expiration = _config["JWT:Expiration"]
            };

            return Ok(loggedInUser);
        }


        [HttpGet("check-email")]
        public async Task<IActionResult> CheckEmailExists(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return Ok(false); // Email does not exist
            }
            return Ok(true); // Email exists
        }
    }
}
