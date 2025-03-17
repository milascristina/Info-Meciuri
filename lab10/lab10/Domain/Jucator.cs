using lab10.Enum;
using lab10.Repository;

namespace lab10.Domain;


public class Jucator : Elev, IEntity<int>
{
    private string echipa;

    public Jucator(int id, string name, Scoli scoala, string echipa) : base(name, scoala)
    {
        this.echipa = echipa;
        this.Id = id;  // Ensure the Id is set (from IEntity<int>)
    }

    // Implement IEntity<int>
    public int Id { get; set; }

    // Public property for Echipa
    public string Echipa 
    { 
        get => echipa; 
        set => echipa = value; 
    }
}