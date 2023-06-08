using GestionRH.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using GestionRH.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using JwtAuthDemo.Infrastructure;

namespace GestionRH.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IJwtAuthManager _jwtAuthManager;
        public EmployeController(DataContext context, IJwtAuthManager jwtAuthManager)
        {
            _context = context;
            _jwtAuthManager = jwtAuthManager;
        }
        [HttpPost]
        [Route("AskForVacation")]
        [Authorize(Roles = "Employee")]
        public async Task<IActionResult> AskForVacation([FromBody] Conge vacationRequest)
        {

            var employeeId = GetLoggedInUserId();
            var employee = _context.Employees.FirstOrDefault(e => e.Email == employeeId);
            if (employee == null)
            {
                return NotFound(); // Employee not found
            }

            vacationRequest.Employe = employee;
            vacationRequest.Status = Status.Encours;

            _context.Conge.Add(vacationRequest);
            await _context.SaveChangesAsync();
            return Ok(); // Vacation request submitted successfully
        }
        
        [HttpPost]
        [Route("AskForExitPermit")]
        [Authorize(Roles = "Employee")]
        public async Task<IActionResult> AskForExitPermit([FromBody] Autorisation exitPermitRequest)
        {
            var employeeId = GetLoggedInUserId(); // Retrieve the ID of the logged-in employee

            var employee = _context.Employees.FirstOrDefault(e => e.Email == employeeId);

            if (employee == null)
            {
                return NotFound(); // Employee not found
            }

            exitPermitRequest.Employe = employee;
            exitPermitRequest.Status = Status.Encours;

            _context.Autorisation.Add(exitPermitRequest);
            await _context.SaveChangesAsync();
            return Ok(); // Vacation request submitted successfully
        }
        
        [HttpPost]
        [Route("AskForCredit")]
        [Authorize(Roles = "Employee")]
        public async Task<IActionResult> AskForCredit([FromBody] Credit creditRequest)
        {
            var employeeId = GetLoggedInUserId(); // Retrieve the ID of the logged-in employee

            var employee = _context.Employees.FirstOrDefault(e => e.Email == employeeId);

            if (employee == null)
            {
                return NotFound(); // Employee not found
            }

            creditRequest.Employe = employee;
            creditRequest.Status = Status.Encours;

            _context.Credit.Add(creditRequest);
            await _context.SaveChangesAsync();
            return Ok(); // Vacation request submitted successfully
        }

        [HttpGet]
        [Route("CreditHistories")]
        [Authorize(Roles = "Employee")]
        public IActionResult CreditHistories()
        {
            var employeeId = GetLoggedInUserId(); // Retrieve the ID of the logged-in employee

            var employee = _context.Employees.FirstOrDefault(e => e.Email == employeeId);

            if (employee == null)
            {
                return NotFound(); // Employee not found
            }
            var credits = _context.Credit.Where(c => c.Employe == employee).Where(x => x.Status == Status.Encours).ToList();
            return Ok(credits); // Vacation request submitted successfully
        }
        
        [HttpGet]
        [Route("ExitPermitHistories")]
        [Authorize(Roles = "Employee")]
        public IActionResult ExitPermitHistories()
        {
            var employeeId = GetLoggedInUserId(); // Retrieve the ID of the logged-in employee

            var employee = _context.Employees.FirstOrDefault(e => e.Email == employeeId);

            if (employee == null)
            {
                return NotFound(); // Employee not found
            }
            var exitPermit = _context.Autorisation.Where(c => c.Employe == employee).ToList();
            return Ok(exitPermit); // Vacation request submitted successfully
        }
        
        [HttpGet]
        [Route("VacationHistories")]
        [Authorize(Roles = "Employee")]
        public IActionResult VacationHistories()
        {
            var employeeId = GetLoggedInUserId(); // Retrieve the ID of the logged-in employee

            var employee = _context.Employees.FirstOrDefault(e => e.Email == employeeId);

            if (employee == null)
            {
                return NotFound(); // Employee not found
            }
            var conges = _context.Conge.Where(c => c.Employe == employee).Where(x => x.Status == Status.Encours).ToList();
            return Ok(conges); // Vacation request submitted successfully
        }

        private string? GetLoggedInUserId()
        {
            // Retrieve the current user's claims
            var claimsIdentity = HttpContext.User.Identity as ClaimsIdentity;

            // Find the claim that holds the user ID
            var userIdClaim = claimsIdentity?.Claims.FirstOrDefault(c => c.Type == "username");

            return userIdClaim.Value;
        }






    }
}
