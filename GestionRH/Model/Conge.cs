using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace GestionRH.Model
{
    public class Conge
    {
        
        public int Id { get; set; }
        public DateTime Date_Debut { get; set; }
        public DateTime Date_Fin { get; set; }
        public string? TypeConge { get; set; }
        public Status Status { get; set; }
        public Employe? Employe { get; set; }
    }


    

}
