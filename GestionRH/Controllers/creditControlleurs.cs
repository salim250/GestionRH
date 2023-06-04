using GestionRH.Context;
using GestionRH.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;

namespace GestionRH.Controllers
{
    public class creditControlleurs : Controller
    {
        
        private readonly DataContext _context;
        public creditControlleurs(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("api/Postcredit")]
        public async Task<Credit> PostCreditAccount(Credit credit)
        {
          
            _context.Credit.Add(credit);
            await _context.SaveChangesAsync();

            return credit;
        }

        // GET: api/Credit/5
        [HttpGet]
        [Route("api/Getcredit/{Id}")]
        public async Task<Credit> GetCredit(int Id)
        {
            var credits = await _context.Credit.FindAsync(Id);

            return credits;
        }
    }
}
