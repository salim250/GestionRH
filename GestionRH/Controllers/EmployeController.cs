using GestionRH.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using GestionRH.Context;
using Microsoft.EntityFrameworkCore;

namespace GestionRH.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeController : ControllerBase
    {
        private readonly DataContext _context;
        public EmployeController(DataContext context)
        {
            _context = context;
        }
        [HttpPost]
        [Route("AskForVacation")]
        [Authorize(Roles = "Employee")]
        public async Task<IActionResult> AskForVacation([FromBody] Conge vacationRequest)
        {
            var employeeId = GetLoggedInUserId(); // Retrieve the ID of the logged-in employee

            var employee = _context.Employees.FirstOrDefault(e => e.Id == employeeId);

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

            var employee = _context.Employees.FirstOrDefault(e => e.Id == employeeId);

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

            var employee = _context.Employees.FirstOrDefault(e => e.Id == employeeId);

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
        public async Task<IActionResult> CreditHistories()
        {
            var employeeId = GetLoggedInUserId(); // Retrieve the ID of the logged-in employee

            var employee = _context.Employees.FirstOrDefault(e => e.Id == employeeId);

            if (employee == null)
            {
                return NotFound(); // Employee not found
            }
            var credits = employee.Credits;
            return Ok(credits); // Vacation request submitted successfully
        }
        
        [HttpGet]
        [Route("ExitPermitHistories")]
        [Authorize(Roles = "Employee")]
        public async Task<IActionResult> ExitPermitHistories()
        {
            var employeeId = GetLoggedInUserId(); // Retrieve the ID of the logged-in employee

            var employee = _context.Employees.FirstOrDefault(e => e.Id == employeeId);

            if (employee == null)
            {
                return NotFound(); // Employee not found
            }
            var exitPermit = employee.Conges;
            return Ok(exitPermit); // Vacation request submitted successfully
        }
        
        [HttpGet]
        [Route("VacationHistories")]
        [Authorize(Roles = "Employee")]
        public async Task<IActionResult> VacationHistories()
        {
            var employeeId = GetLoggedInUserId(); // Retrieve the ID of the logged-in employee

            var employee = _context.Employees.FirstOrDefault(e => e.Id == employeeId);

            if (employee == null)
            {
                return NotFound(); // Employee not found
            }
            var conges = employee.Conges;
            return Ok(conges); // Vacation request submitted successfully
        }

        private int GetLoggedInUserId()
        {
            // Retrieve the current user's claims
            var claimsIdentity = HttpContext.User.Identity as ClaimsIdentity;

            // Find the claim that holds the user ID
            var userIdClaim = claimsIdentity?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);

            if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out int userId))
            {
                throw new ApplicationException("Unable to retrieve user ID.");
            }

            return userId;
        }






    }
}
