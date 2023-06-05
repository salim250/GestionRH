namespace GestionRH.Model
{
    public class Credit
    {
        public int Id { get; set; }
        public Employe Employe { get; set; }
        public string ReferenceCredit { get; set; }
        public float MontantCredit { get; set; }
        public DateTime Duree { get; set; }
        public string Echeance { get; set; }
        public Status Status { get; set; }
    }
}
