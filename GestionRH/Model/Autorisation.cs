namespace GestionRH.Model
{
    public class Autorisation
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string HeureSortie { get; set; }
        public string HeureRetour { get; set; }
        public Status Status { get; set; }
        public Employe Employe { get; set; }
    }
}
