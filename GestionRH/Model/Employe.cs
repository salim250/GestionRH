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

        [JsonIgnore]
        public ICollection<Credit> Credits { get; set; }
        [JsonIgnore]
        public ICollection<Conge> Conges { get; set; }
        [JsonIgnore]
        public ICollection<Autorisation> Autorisations { get; set; }
    }
}
