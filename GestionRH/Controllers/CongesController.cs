using GestionRH.Context;
using GestionRH.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;

namespace GestionRH.Controllers
{
  //[EnableCors("MyPolicy")]
  [Route("api/[controller]")]
  [ApiController]
  //[Authorize]
  public class CongesController : Controller
    {
        private readonly DataContext _context;
    
    public CongesController(DataContext context)
        {
            _context = context;
        }

        //public class Autorisation
        //{
        //    public string Date { get; set; }
        //    public string HeureSortie { get; set; }
        //    public string HeureRetour { get; set; }
        //    public string Statut { get; set; } = "Non Validé";

        //}

        //[Route("api/GetListAutorisationByLogin/{login}"),HttpGet]
        //public List<Autorisation> GetListAutorisationByLogin(string login)
        //{

        //    String constr = @"Server =.\SQLEXPRESS02; Database =GestionDemandes; Trusted_Connection = True;TrustServerCertificate=True";


        //    Autorisation aut = new Autorisation();
        //    List<Autorisation> listaut = new List<Autorisation>();

        //    using (SqlConnection connection = new SqlConnection(constr))
        //    {


        //        var sql = @"select * from autorisation where login='"+login+"' order by date desc";


        //        SqlCommand command = new SqlCommand(sql, connection);
        //        connection.Open();

        //        SqlDataReader reader = command.ExecuteReader();


        //        while (reader.Read())
        //        {
        //            aut = new Autorisation();
        //            aut.Date = reader["date"].ToString();
        //            aut.HeureSortie = reader["heureSortie"].ToString();
        //            aut.HeureRetour = reader["heureRetour"].ToString();
        //            listaut.Add(aut);

        //        }



        //        connection.Close();
        //        return listaut;


        //    }
        //}
        [AllowAnonymous]
        [Route("api/Postconge")]
        [HttpPost]
        public async Task<Conge> PostConge([FromBody]Conge conge)
        {

            _context.Conge.Add(conge);
            await _context.SaveChangesAsync();

            return conge;
        }

        
        [HttpGet]
        [Route("api/Getconge/{Id}")]
        public async Task<Conge> GetConge(int Id)
        {
            var conges = await _context.Conge.FindAsync(Id);

            return conges;
        }

    }
}
