using GestionRH.Context;
using GestionRH.DTOs;
using GestionRH.Model;
using JwtAuthDemo.Infrastructure;
using JwtAuthDemo.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GestionRH.Controllers
{
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IUserService _userService;
        private readonly IJwtAuthManager _jwtAuthManager;
        private readonly DataContext _context;
        public UsersController(DataContext dataContext, ILogger<UsersController> logger, IUserService userService, IJwtAuthManager jwtAuthManager)
        {
            _logger = logger;
            _userService = userService;
            _jwtAuthManager = jwtAuthManager;
            _context = dataContext;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public ActionResult Login([FromBody] LoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (!_userService.IsValidUserCredentials(request.UserName, request.Password))
            {
                return Unauthorized();
            }
            List<User> Users = _context.Users.ToList();
            var p = Users.Where(c => c.Email == request.UserName).ToList();
            var role = _userService.GetUserRole(request.UserName);
            var claims = new[]
            {
                new Claim("username",request.UserName),
                new Claim("role", role)
            };

            var jwtResult = _jwtAuthManager.GenerateTokens(request.UserName, claims, DateTime.Now);
            _logger.LogInformation($"User [{request.UserName}] logged in the system.");
            return Ok(new LoginResult
            {
                id = p[0].Id,
                UserName = request.UserName,
                Role = role,
                AccessToken = jwtResult.AccessToken,
                RefreshToken = jwtResult.RefreshToken.TokenString
            });
        }
        [HttpPost("logout")]
        [Authorize]
        public ActionResult Logout()
        {
            // optionally "revoke" JWT token on the server side --> add the current token to a block-list
            // https://github.com/auth0/node-jsonwebtoken/issues/375

            var userName = User.Identity?.Name;
            _jwtAuthManager.RemoveRefreshTokenByUserName(userName);
            _logger.LogInformation($"User [{userName}] logged out the system.");
            return Ok();
        }

        [HttpPost]
        [Route("addUser")]
        [AllowAnonymous]
        public async Task<IActionResult> addUser([FromBody] User user)
        {
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.PasswordHash);
            _context.Users.Add(user);
            _context.SaveChanges();
            return Ok(user);
        }
        
        [HttpPost]
        [Route("addEmploye")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> addEmploye([FromBody] User user)
        {
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.PasswordHash);
            user.role = Role.Employe;
            _context.Users.Add(user);
            _context.SaveChanges();
            return Ok(user);
        }


    }
}
