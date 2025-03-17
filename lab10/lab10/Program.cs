using System;
using System.Collections.Generic;
using lab10.Domain;
using lab10.Enum;

using System;
using lab10.Domain;
using lab10.Repository;
using lab10.Enum;

class Program
{
    static void Main(string[] args)
    {
        var meciRepository = new MeciFileRepository("C:\\Users\\Cristina\\RiderProjects\\lab10\\lab10\\meci.txt");
        var jucatorActivRepository = new JucatorActivFileRepository("C:\\Users\\Cristina\\RiderProjects\\lab10\\lab10\\jucatoriactivi.txt");
        var jucatorRepository = new JucatorFileRepository("C:\\Users\\Cristina\\RiderProjects\\lab10\\lab10\\jucatori.txt");
        
        var meciService = new MeciService(meciRepository, jucatorActivRepository, jucatorRepository);
        var jucatorService = new JucatorService(jucatorRepository, jucatorActivRepository);

        
        DateTime startDate = new DateTime(2025, 01, 01);  
        DateTime endDate = new DateTime(2025, 01, 07);   
        Console.WriteLine("-Testare AfiseazaMeciuriDinPerioada:");
        meciService.AfiseazaMeciuriDinPerioada(startDate, endDate);
        Console.WriteLine(); 

        
        int idMeci = 1; 
        Console.WriteLine("-TestareAfiseazaScor Meci:");
        meciService.AfiseazaScorMeci(idMeci);
        Console.WriteLine();
        
        Console.WriteLine("-Testare AfiseazaJucatoriEchipa pentru echipa 'HoustonRockets':");
        jucatorService.AfiseazaJucatoriEchipa(Echipe.HoustonRockets);

        Console.WriteLine();

       
        int idMeciActiv = 1; 
        Console.WriteLine("-Testare AfiseazaJucatoriActivInMeci pentru echipa 'HoustonRockets' si Meciul cu ID-ul 1:");
        jucatorService.AfiseazaJucatoriEchipa(Echipe.HoustonRockets);
        Console.WriteLine();
    }
}
