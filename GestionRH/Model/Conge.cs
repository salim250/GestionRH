using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace GestionRH.Model
{
    public class Conge
    {
        
        public int Id { get; set; }
        public DateTime Date_Debut { get; set; }
        public DateTime Date_Fin { get; set; }
        public string TypeConge { get; set; }
        public int Telephone { get; set; }
        public string Adresse { get; set; }
        public string Login { get; set; }
    }


    

}
