using lab10.Enum;
using lab10.Repository;

namespace lab10.Domain;

public class Echipa : IEntity<int>  
{
    private int id;
    private Echipe name;

    public Echipa(int id, Echipe name)
    {
        this.id = id;
        this.name = name;
    }

    public int Id { get => id; set => id = value; }
    public Echipe Name { get => name; set => name = value; }

    // Suprascrierea operatorului ==
    public static bool operator ==(Echipa left, Echipa right)
    {
        // Verificăm dacă ambele obiecte sunt aceleași referințe
        if (ReferenceEquals(left, right))
        {
            return true;
        }

        // Verificăm dacă unul dintre obiecte este null
        if (ReferenceEquals(left, null) || ReferenceEquals(right, null))
        {
            return false;
        }

        // Compara Id și Name
        return left.Id == right.Id && left.Name == right.Name;
    }

    // Suprascrierea operatorului !=
    public static bool operator !=(Echipa left, Echipa right)
    {
        return !(left == right); // Utilizăm operatorul == pentru a defini !=
    }

    // Suprascrierea metodei Equals (pentru comparare obiecte)
    public override bool Equals(object obj)
    {
        if (obj is Echipa other)
        {
            return this == other; // Folosim operatorul == definit anterior
        }
        return false;
    }

    // Suprascrierea metodei GetHashCode
    public override int GetHashCode()
    {
        return Id.GetHashCode() ^ Name.GetHashCode();
    }
    public override string ToString()
    {
        return Name.ToString(); // Convertim enum-ul Echipe în string
    }

}
