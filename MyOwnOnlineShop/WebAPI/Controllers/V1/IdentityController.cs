using Application.Interfaces;
using Domain.Enums;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebAPI.Models;
using WebAPI.SwaggerExamples.Responses.IdentityResponses;
using WebAPI.Wrappers;

namespace WebAPI.Controllers.V1;

[Route("api/[controller]")]
[ApiController]
public class IdentityController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IConfiguration _configuration;
    private readonly IEmailSenderService _emailSenderService;

    public IdentityController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration,
        IEmailSenderService emailSenderService)
    {
        _roleManager = roleManager;
        _userManager = userManager;
        _configuration = configuration;
        _emailSenderService = emailSenderService;
    }

    /// <summary>
    /// Registers the user in the system
    /// </summary>
    /// <response code="200">User created successfully!</response>
    /// <response code="500">User already exists!</response>
    [ProducesResponseType(typeof(RegisterResponseStatus200), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(RegisterResponseStatus500), StatusCodes.Status500InternalServerError)]
    [HttpPost]
    [Route("Register User")]
    public async Task<IActionResult> RegisterUser(RegisterModel register)
    {
        var userExists = await _userManager.FindByNameAsync(register.UserNick);
        if (userExists != null)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new Response
            {
                Succeeded = false,
                Message = "User already exists!"
            });
        }

        ApplicationUser user = new ApplicationUser()
        {
            Email = register.Email,
            SecurityStamp = Guid.NewGuid().ToString(),
            NameUser = register.NameUser,
            UserName = register.UserNick,
            UserSurname = register.UserSurname,
            PhoneNumber = register.PhoneNumber,
            Street = register.Street,
            HouseNumber = register.HouseNumber,
            FlatNumber = register.FlatNumber,
            City = register.City,
            PostalCode = register.PostalCode,
            Country = register.Country,
        };

        var result = await _userManager.CreateAsync(user, register.Password);
        if (!result.Succeeded)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new Response<bool>
            {
                Succeeded = false,
                Message = "User creation failed! Please check user details and try again",
                Errors = result.Errors.Select(x => x.Description)
            });
        }

        if (!await _roleManager.RoleExistsAsync(UserRoles.User))
            await _roleManager.CreateAsync(new IdentityRole(UserRoles.User));

        await _userManager.AddToRoleAsync(user, UserRoles.User);

        await _emailSenderService.Send(user.Email, "Registration confirmation", EmailTemplate.WelcomeMessage, user);

        return Ok(new Response { Succeeded = true, Message = "User created successfully!" });
    }

    /// <summary>
    /// Registers the Admin in the system
    /// </summary>
    /// <response code="200">Registers created successfully!</response>
    /// <response code="500">Registers already exists!</response>
    [ProducesResponseType(typeof(AdminRegisterResponseStatus200), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(AdminRegisterResponseStatus500), StatusCodes.Status500InternalServerError)]
    [HttpPost]
    [Route("RegisterAdmin")]
    public async Task<IActionResult> RegisterAdmin(RegisterModel register)
    {
        var userExists = await _userManager.FindByNameAsync(register.UserNick);
        if (userExists != null)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new Response
            {
                Succeeded = false,
                Message = "Admin already exists!"
            });
        }

        ApplicationUser user = new ApplicationUser()
        {
            Email = register.Email,
            SecurityStamp = Guid.NewGuid().ToString(),
            NameUser = register.NameUser,
            UserName = register.UserNick,
            UserSurname = register.UserSurname,
            PhoneNumber = register.PhoneNumber,
            Street = register.Street,
            HouseNumber = register.HouseNumber,
            FlatNumber = register.FlatNumber,
            City = register.City,
            PostalCode = register.PostalCode,
            Country = register.Country,
        };

        var result = await _userManager.CreateAsync(user, register.Password);
        if (!result.Succeeded)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new Response<bool>
            {
                Succeeded = false,
                Message = "Admin creation failed! Please check user details and try again",
                Errors = result.Errors.Select(x => x.Description)
            });
        }

        if (!await _roleManager.RoleExistsAsync(UserRoles.Admin))
            await _roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));

        await _userManager.AddToRoleAsync(user, UserRoles.Admin);
        await _emailSenderService.Send(user.Email, "Registration confirmation", EmailTemplate.WelcomeMessage, user);

        return Ok(new Response { Succeeded = true, Message = "User created successfully!" });
    }

    /// <summary>
    /// Logs the user into system
    /// </summary>
    /// <response code="200">Logs successfully!</response>
    /// <response code="500">Something wrong!</response>
    [HttpPost]
    [Route("Login")]
    public async Task<IActionResult> Login(LoginModel login)
    {
        var user = await _userManager.FindByNameAsync(login.UserNick);
        if (user != null && await _userManager.CheckPasswordAsync(user, login.Password))
        {
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var userRoles = await _userManager.GetRolesAsync(user);
            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                expires: DateTime.Now.AddHours(2),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return Ok(new AuthSuccessResponse()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = token.ValidTo
            });
        }
        return Unauthorized();
    }
}