using lab10.Repository;

namespace lab10.Domain;

public class JucatorActiv : IEntity<int>
{
    public int Id { get; set; }  // Acesta va fi identificatorul entității
    public int IdJucator { get; set; }
    public int IdMeci { get; set; }
    public int NrPuncteInscrise { get; set; }
    public string Tip { get; set; }

    public JucatorActiv(int id, int idJucator, int idMeci, int nrPuncteInscrise, string tip)
    {
        this.Id = id;  // Setăm ID-ul entității
        this.IdJucator = idJucator;
        this.IdMeci = idMeci;
        this.NrPuncteInscrise = nrPuncteInscrise;
        this.Tip = tip;
    }
}