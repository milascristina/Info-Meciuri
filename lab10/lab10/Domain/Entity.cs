namespace lab10.Domain;

using System;
using System.Collections.Generic;

[Serializable]
public class Entity<ID>
{
    protected ID id;

    public ID Id
    {
        get { return id; }
        set { id = value; }
    }

    public override bool Equals(object obj)
    {
        if (this == obj) return true;
        if (obj is not Entity<ID> entity) return false;
        return EqualityComparer<ID>.Default.Equals(Id, entity.Id);
    }

    public override int GetHashCode()
    {
        return EqualityComparer<ID>.Default.GetHashCode(Id);
    }

    public override string ToString()
    {
        return $"Entity{{ id={id} }}";
    }
}