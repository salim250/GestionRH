using Newtonsoft.Json;

namespace GestionRH.Model
{
    public class Employe : User
    {
        public string? Poste { get; set; }
        public int Telephone { get; set; }
        public string? Adresse { get; set; }
        public int? Cin { get; set; }
        public DateTime? DateNaissance { get; set; }
        public ICollection<Credit> Credits { get; set; }
        public ICollection<Conge> Conges { get; set; }
        public ICollection<Autorisation> Autorisations { get; set; }
    }
}
