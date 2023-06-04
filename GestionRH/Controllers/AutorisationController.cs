using GestionRH.Context;
using GestionRH.Model;
using Microsoft.AspNetCore.Mvc;

namespace GestionRH.Controllers
{
  public class AutorisationController
  {
    private readonly DataContext _context;
    public AutorisationController(DataContext context)
    {
      _context = context;
    }

    [HttpPost]
    [Route("api/PostAutorisation")]
    public async Task<Autorisation> PostAutorisation(Autorisation Autorisation)
    {

      _context.Autorisation.Add(Autorisation);
      await _context.SaveChangesAsync();

      return Autorisation;
    }
  }
}
