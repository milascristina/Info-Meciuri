namespace lab10.Repository;
using lab10.Domain;
using lab10.Enum;
using System;
using System.Collections.Generic;

public class EchipaFileRepository : AbstractFileRepository<int, Echipa>
{
    public EchipaFileRepository(string fileName) : base(fileName) { }

    // Method to parse the 'Echipe' enum from a string value
    public static bool TryParseEchipa(string value, out Echipe echipa)
    {
        // Manually map string values to enum members (match string with Enum)
        switch (value.ToLower())
        {
            case "houstonrockets":
                echipa = Echipe.HoustonRockets;
                return true;
            case "losangeleslakers":
                echipa = Echipe.LosAngelesLakers;
                return true;
            case "laclipppers":
                echipa = Echipe.LAClippers;
                return true;
            // Add cases for all the enum values...
            default:
                echipa = default;
                return false;
        }
    }

    // Override method to extract the entity (Echipa) from the data list
    public override Echipa ExtractEntity(List<string> data)
    {
        // Parse the 'Echipe' enum from the string value
        if (TryParseEchipa(data[0], out var echipa)) // We only need the name here (first value in the data list)
        {
            var echipaEntity = new Echipa(int.Parse(data[1]), echipa); // id is parsed from second value
            return echipaEntity;
        }
        else
        {
            throw new ArgumentException($"Invalid Echipa value: {data[0]}");
        }
    }

    // Override method to create a string representation of the 'Echipa' entity
    protected override string CreateEntityAsString(Echipa echipa)
    {
        return $"{echipa.Name};{echipa.Id}";
    }
}