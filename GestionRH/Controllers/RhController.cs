using Azure.Core;
using GestionRH.Context;
using GestionRH.Model;
using GestionRH.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Claims;

namespace GestionRH.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RhController : ControllerBase
    {
        private readonly IExitPermitService _exitPermitService;
        private readonly IVacationService _vacationService;
        private readonly ICreditService _creditService;
        private readonly DataContext _context;
        public RhController(DataContext context,IExitPermitService exitPermitService, IVacationService vacationService, ICreditService creditService)
        {
            _exitPermitService = exitPermitService;
            _vacationService = vacationService;
            _context = context;
            _creditService = creditService;
        }

        [HttpPut("exit-permit/{id}")]
        [Authorize(Roles = "ResponsableRH")]
        public IActionResult AcceptRefuseExitPermitRequest(int id, [FromBody] bool accept)
        {

            // Retrieve the exit permit request by ID from the database
            var exitPermitRequest = _exitPermitService.GetExitPermitRequestById(id);

            // Check if the exit permit request exists
            if (exitPermitRequest == null)
            {
                return NotFound();
            }

            // Update the status of the exit permit request
            if (accept)
            {
                exitPermitRequest.Status = Status.Valider;
            }
            else
            {
                exitPermitRequest.Status = Status.Annuler;
            }

            // Save the changes to the database
            _exitPermitService.UpdateExitPermitRequest(exitPermitRequest);

            // Return the updated exit permit request
            return Ok(exitPermitRequest);
        }
        
        [HttpPut("Vacation/{id}")]
        [Authorize(Roles = "ResponsableRH")]
        public IActionResult AcceptRefuseVacationRequest(int id, [FromBody] bool accept)
        {

            // Retrieve the exit permit request by ID from the database
            var vacationRequest = _vacationService.GetVacationRequestById(id);

            // Check if the exit permit request exists
            if (vacationRequest == null)
            {
                return NotFound();
            }

            // Update the status of the exit permit request
            if (accept)
            {
                vacationRequest.Status = Status.Valider;
            }
            else
            {
                vacationRequest.Status = Status.Annuler;
            }

            // Save the changes to the database
            _vacationService.UpdateVacationRequest(vacationRequest);

            // Return the updated exit permit request
            return Ok(vacationRequest);
        }
        
        [HttpPut("Credit/{id}")]
        [Authorize(Roles = "ResponsableRH")]
        public IActionResult AcceptRefuseCreditRequest(int id, [FromBody] bool accept)
        {

            // Retrieve the exit permit request by ID from the database
            var creditRequest = _creditService.GetCreditRequestById(id);

            // Check if the exit permit request exists
            if (creditRequest == null)
            {
                return NotFound();
            }

            // Update the status of the exit permit request
            if (accept)
            {
                creditRequest.Status = Status.Valider;
            }
            else
            {
                creditRequest.Status = Status.Annuler;
            }

            // Save the changes to the database
            _creditService.UpdateCreditRequest(creditRequest);

            // Return the updated exit permit request
            return Ok(creditRequest);
        }

        [HttpGet]
        [Route("CreditHistories")]
        [Authorize(Roles = "ResponsableRH")]
        public async Task<IActionResult> CreditHistories()
        {
            var credits = _context.Credit.Include(x => x.Employe).ToList();
            return Ok(credits); // Vacation request submitted successfully
        }

        [HttpGet]
        [Route("ExitPermitHistories")]
        [Authorize(Roles = "ResponsableRH")]
        public IActionResult ExitPermitHistories()
        {
            var exitPermit = _context.Autorisation.Include(x => x.Employe).ToList();
            return Ok(exitPermit); // Vacation request submitted successfully
        }

        [HttpGet]
        [Route("VacationHistories")]
        [Authorize(Roles = "ResponsableRH")]
        public async Task<IActionResult> VacationHistories()
        {
            var conges = _context.Conge.Include(x => x.Employe).ToList();
            return Ok(conges); // Vacation request submitted successfully
        }
    }
}
