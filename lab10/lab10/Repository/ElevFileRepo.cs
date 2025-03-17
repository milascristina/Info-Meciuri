using lab10.Domain;
using lab10.Enum;
using System;
using System.Collections.Generic;
namespace lab10.Repository;

public class ElevFileRepository : AbstractFileRepository<long, Elev>
{
    public ElevFileRepository(string fileName) : base(fileName) { }
    
    public static bool TryParseScoala(string value, out Scoli scoala)
    {
        // Manually map string values to enum members
        switch (value.ToLower())
        {
            case "scoalagimnazialahorea":
                scoala = Scoli.ScoalaGimnazialaHorea;
                return true;
            case "scoalagimnazialaoctaviangoga":
                scoala = Scoli.ScoalaGimnazialaOctavianGoga;
                return true;
            // Add all your cases here...
            default:
                scoala = default;
                return false;
        }
    }


    public override Elev ExtractEntity(List<string> data)
    {
        if (TryParseScoala(data[2], out var scoala))
        {
            var elev = new Elev(data[1], scoala)
            {
                Id = long.Parse(data[0])
            };
            return elev;
        }
        else
        {
            throw new ArgumentException($"Invalid Scoala value: {data[2]}");
        }
    }


    protected override string CreateEntityAsString(Elev elev)
    {
        return $"{elev.Id};{elev.Name};{elev.Scoala}";
    }
}