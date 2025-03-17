namespace lab10.Repository;
using lab10.Domain;
using lab10.Repository;
using System;
using System.Collections.Generic;

public class JucatorActivFileRepository : AbstractFileRepository<int, JucatorActiv>
{
    public JucatorActivFileRepository(string fileName) : base(fileName) { }

    public override JucatorActiv ExtractEntity(List<string> data)
    {
        // Extragem datele pentru JucatorActiv din linia de text
        try
        {
            int id = int.Parse(data[0]);
            int idJucator = int.Parse(data[1]);
            int idMeci = int.Parse(data[2]);
            int nrPuncteInscrise = int.Parse(data[3]);
            string tip = data[4];

            return new JucatorActiv(id, idJucator, idMeci, nrPuncteInscrise, tip);
        }
        catch (Exception ex)
        {
            throw new ArgumentException("Invalid data format for JucatorActiv", ex);
        }
    }

    protected override string CreateEntityAsString(JucatorActiv jucatorActiv)
    {
        // Creăm linia de text pentru fișier
        return $"{jucatorActiv.Id};{jucatorActiv.IdJucator};{jucatorActiv.IdMeci};{jucatorActiv.NrPuncteInscrise};{jucatorActiv.Tip}";
    }
}