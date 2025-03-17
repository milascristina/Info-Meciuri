using System;
using System.Collections.Generic;
using System.Linq;
using lab10.Domain;
using lab10.Enum;
using lab10.Repository;

public class MeciService
{
    private readonly MeciFileRepository _meciRepository;
    private readonly JucatorActivFileRepository _jucatorActivRepository;
    private readonly JucatorFileRepository _jucatorRepository;

    public MeciService(MeciFileRepository meciRepository, JucatorActivFileRepository jucatorActivRepository, JucatorFileRepository jucatorRepository)
    {
        _meciRepository = meciRepository;
        _jucatorActivRepository = jucatorActivRepository;
        _jucatorRepository = jucatorRepository;
    }
    public void AfiseazaMeciuriDinPerioada(DateTime startDate, DateTime endDate)
    {
        var meciuri = _meciRepository.FindAll()
            .Where(m => m.Date >= startDate && m.Date <= endDate)
            .ToList();

        if (meciuri.Count == 0)
        {
            Console.WriteLine($"Nu există meciuri în perioada {startDate.ToShortDateString()} - {endDate.ToShortDateString()}.");
        }
        else
        {
            Console.WriteLine($"Meciuri din perioada {startDate.ToShortDateString()} - {endDate.ToShortDateString()}:");
            foreach (var meci in meciuri)
            {
                Console.WriteLine($"ID: {meci.Id}, Echipe: {meci.Echipa1.Name} vs {meci.Echipa2.Name}, Data: {meci.Date:yyyy-MM-dd}");
            }
        }
    }
    public void AfiseazaScorMeci(int idMeci)
    {
        var meci = _meciRepository.FindAll().FirstOrDefault(m => m.Id == idMeci);
    
        if (meci == null)
        {
            Console.WriteLine($"Meciul cu ID-ul {idMeci} nu a fost găsit.");
            return;
        }

        var jucatoriActiv = _jucatorActivRepository.FindAll()
            .Where(j => j.IdMeci == idMeci)
            .ToList();
        
        var jucatori = _jucatorRepository.FindAll().ToList();

        var jucatoriActivEchipa1 = jucatoriActiv
            .Where(j => jucatori.FirstOrDefault(jucator => jucator.Id == j.IdJucator)?.Echipa.ToString() == Enum.GetName(typeof(Echipe), meci.Echipa1.Name))
            .ToList();

        var jucatoriActivEchipa2 = jucatoriActiv
            .Where(j => jucatori.FirstOrDefault(jucator => jucator.Id == j.IdJucator)?.Echipa.ToString() == Enum.GetName(typeof(Echipe), meci.Echipa2.Name))
            .ToList();

        int scorEchipa1 = jucatoriActivEchipa1.Sum(j => j.NrPuncteInscrise);

        int scorEchipa2 = jucatoriActivEchipa2.Sum(j => j.NrPuncteInscrise);
        
        Console.WriteLine($"Scorul meciului {meci.Echipa1.Name} vs {meci.Echipa2.Name}:");
        Console.WriteLine($"{meci.Echipa1.Name} - {scorEchipa1} | {meci.Echipa2.Name} - {scorEchipa2}");
    }



}