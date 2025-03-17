namespace lab10.Repository;
using lab10.Domain;
using lab10.Enum;
using System;
using System.Collections.Generic;

public class JucatorFileRepository : AbstractFileRepository<int, Jucator>
{
    public JucatorFileRepository(string fileName) : base(fileName) { }

    // Override ExtractEntity to convert file data into a Jucator object
    public override Jucator ExtractEntity(List<string> data)
    {
        // Parse the Scoala enum from the string data
        if (Enum.TryParse(data[2], out Scoli scoala))
        {
            var jucator = new Jucator(int.Parse(data[0]), data[1], scoala, data[3]); // ID, name, scoala, echipa
            return jucator;
        }
        else
        {
            throw new ArgumentException($"Invalid Scoala value: {data[2]}");
        }
    }

    // Override CreateEntityAsString to convert Jucator object into a string
    protected override string CreateEntityAsString(Jucator jucator)
    {
        return $"{jucator.Id};{jucator.Name};{jucator.Scoala};{jucator.Echipa}";
    }
}