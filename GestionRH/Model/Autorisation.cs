namespace GestionRH.Model
{
  public class Autorisation
  {
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public string HeureSortie { get; set; }
    public string HeureRetour { get; set; }
    public string Statut { get; set; } = "Non Validé";
  }
}