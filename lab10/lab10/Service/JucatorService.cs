using System;
using System.Collections.Generic;
using System.Linq;
using lab10.Domain;
using lab10.Repository;
using lab10.Enum;

public class JucatorService
{
    private readonly JucatorFileRepository _jucatorRepository;
    private readonly JucatorActivFileRepository _jucatorActivRepository;

    public JucatorService(JucatorFileRepository jucatorRepository, JucatorActivFileRepository jucatorActivRepository)
    {
        _jucatorRepository = jucatorRepository;
        _jucatorActivRepository = jucatorActivRepository;
    }

    // Method to get all players from a given team
    public List<Jucator> GetJucatoriByEchipa(Echipe echipa)
    {
        return _jucatorRepository.FindAll().Where(j => j.Echipa == echipa.ToString()).ToList();
    }

    // Method to display all players of a given team
    public void AfiseazaJucatoriEchipa(Echipe echipa)
    {
        var jucatori = GetJucatoriByEchipa(echipa);
        if (jucatori.Count == 0)
        {
            Console.WriteLine($"Nu există jucători în echipa {echipa}.");
        }
        else
        {
            Console.WriteLine($"Jucătorii echipei {echipa}:");
            foreach (var jucator in jucatori)
            {
                Console.WriteLine($"ID: {jucator.Id}, Nume: {jucator.Name}, Școala: {jucator.Scoala}");
            }
        }
    }

    // Method to display active players in a given match for a specific team
    public void AfiseazaJucatoriActivInMeci(Echipe echipa, int idMeci)
    {
        // Obținem toți jucătorii ai echipei specificate
        var jucatoriEchipa = _jucatorRepository.FindAll()
            .Where(j => j.Echipa == echipa.ToString())
            .ToList();

        // Filtrăm jucătorii activi din meciul dat, care aparțin echipei specificate
        var jucatoriActiv = _jucatorActivRepository.FindAll()
            .Where(j => j.IdMeci == idMeci && jucatoriEchipa.Any(jucator => jucator.Id == j.IdJucator))
            .ToList();
        if (jucatoriActiv.Count == 0)
        {
            Console.WriteLine($"Nu există jucători activi pentru echipa {echipa} în meciul cu ID-ul {idMeci}.");
        }
        else
        {
            Console.WriteLine($"Jucătorii activi ai echipei {echipa} în meciul cu ID-ul {idMeci}:");
            foreach (var jucatorActiv in jucatoriActiv)
            {
                var jucator = _jucatorRepository.FindAll().FirstOrDefault(j => j.Id == jucatorActiv.IdJucator);
                if (jucator != null)
                {
                    Console.WriteLine($"ID: {jucator.Id}, Nume: {jucator.Name}, Puncte înscrise: {jucatorActiv.NrPuncteInscrise}");
                }
            }
        }
    }


}
