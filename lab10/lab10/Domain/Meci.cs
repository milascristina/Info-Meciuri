using lab10.Repository;

namespace lab10.Domain;

public class Meci : IEntity<int>
{
    // Implement IEntity<int>
    public int Id { get; set; }
    public Echipa Echipa1 { get; set; }
    public Echipa Echipa2 { get; set; }
    public DateTime Date { get; set; }

    public Meci(Echipa echipa1, Echipa echipa2, DateTime date)
    {
        Echipa1 = echipa1;
        Echipa2 = echipa2;
        Date = date;
    }
}