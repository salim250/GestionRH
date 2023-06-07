using GestionRH.Context;
using GestionRH.DTOs;
using GestionRH.Model;
using JwtAuthDemo.Infrastructure;
using JwtAuthDemo.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Security.Policy;

namespace GestionRH.Controllers
{
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IUserService _userService;
        private readonly IJwtAuthManager _jwtAuthManager;
        private readonly DataContext _context;
        public AccountController(DataContext dataContext, ILogger<AccountController> logger, IUserService userService, IJwtAuthManager jwtAuthManager)
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
        public async Task<IActionResult> AddUser([FromBody] User user)
        {
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.PasswordHash);
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return Ok(user);
        }
        [HttpGet]
        [Route("getEmploye")]
        [Authorize(Roles = "Admin")]
        public IActionResult getEmploye()
        {
            var employees = _context.Employees.ToList();
            return Ok(employees);
        }
        
        [HttpGet]
        [Route("getEmploye/{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult getEmployeById(int id)
        {
            var employees = _context.Employees.Find(id);
            return Ok(employees);
        }
        [HttpPost]
        [Route("addEmploye")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddEmploye([FromBody] Employe user)
        {
            if (_userService.IsAnExistingUser(user.Email))
            {
                return BadRequest("User already exists");
            }
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.PasswordHash);
            user.role = Role.Employee;
            _context.Employees.Add(user);
            await _context.SaveChangesAsync();
            return Ok(user);
        }

        [HttpPut]
        [Route("updateUser/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] Employe user)
        {
            var existingUser = await _context.Employees.FindAsync(id);

            if (existingUser == null)
            {
                return NotFound();
            }

            existingUser.prenom = user.prenom;
            existingUser.Email = user.Email;
            existingUser.nom = user.nom;
            existingUser.Poste = user.Poste;
            existingUser.Cin = user.Cin;
            existingUser.Adresse = user.Adresse;
            existingUser.Telephone = user.Telephone;
            existingUser.DateNaissance = user.DateNaissance;
            // Update other properties as needed

            _context.Employees.Update(existingUser);
            await _context.SaveChangesAsync();

            return Ok(existingUser);
        }

        [HttpDelete]
        [Route("deleteUser/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var existingUser = await _context.Employees.FindAsync(id);

            if (existingUser == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(existingUser);
            await _context.SaveChangesAsync();

            return Ok();
        }


    }
}
