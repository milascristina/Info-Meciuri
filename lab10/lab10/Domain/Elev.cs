using lab10.Enum;
using lab10.Repository;

namespace lab10.Domain;

public class Elev : IEntity<long>
{
    public long Id { get; set; }
    public string Name { get; set; }
    public Scoli Scoala { get; set; }

    public Elev(string name, Scoli scoala)
    {
        Name = name;
        Scoala = scoala;
    }
}