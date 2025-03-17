namespace lab10.Repository
{
    using lab10.Domain;
    using lab10.Enum;
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class MeciFileRepository : AbstractFileRepository<int, Meci>
    {
        public MeciFileRepository(string fileName) : base(fileName)
        {
        }

        public override Meci ExtractEntity(List<string> data)
        {
            if (data.Count < 6)
            {
                throw new ArgumentException("Linia din fișier nu are suficiente date.");
            }

            int id = int.Parse(data[0]);

            // Convertim string-urile în enum Echipe
            Echipe echipa1Enum = (Echipe)Enum.Parse(typeof(Echipe), data[1], true);
            Echipe echipa2Enum = (Echipe)Enum.Parse(typeof(Echipe), data[2], true);

            // Creăm obiectele Echipa folosind ID-urile din fișier
            Echipa echipa1 = new Echipa(int.Parse(data[4]), echipa1Enum);
            Echipa echipa2 = new Echipa(int.Parse(data[5]), echipa2Enum);

            DateTime date = DateTime.Parse(data[3]);

            return new Meci(echipa1, echipa2, date) { Id = id };
        }



        // Metoda de parsing a echipei, care returnează o valoare din enum Echipe
        private static bool TryParseEchipa(string value, out Echipe echipa)
        {
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
                case "chicagobulls":
                    echipa = Echipe.ChicagoBulls;
                    return true;
                case "clevelandcavaliers":
                    echipa = Echipe.ClevelandCavaliers;
                    return true;
                case "utahjazz":
                    echipa = Echipe.UtahJazz;
                    return true;
                case "brooklynnets":
                    echipa = Echipe.BrooklynNets;
                    return true;
                case "neworleanspelicans":
                    echipa = Echipe.NewOrleansPelicans;
                    return true;
                case "indianapacers":
                    echipa = Echipe.IndianaPacers;
                    return true;
                case "torontoraptors":
                    echipa = Echipe.TorontoRaptors;
                    return true;
                case "charlottehornets":
                    echipa = Echipe.CharlotteHornets;
                    return true;
                case "phoenixsuns":
                    echipa = Echipe.PhoenixSuns;
                    return true;
                case "portlandtrailblazers":
                    echipa = Echipe.PortlandTrailBlazers;
                    return true;
                case "goldenstatewarriors":
                    echipa = Echipe.GoldenStateWarriors;
                    return true;
                case "washingtonwizards":
                    echipa = Echipe.WashingtonWizards;
                    return true;
                case "sanantoniospurs":
                    echipa = Echipe.SanAntonioSpurs;
                    return true;
                case "orlandomagic":
                    echipa = Echipe.OrlandoMagic;
                    return true;
                case "denvernuggets":
                    echipa = Echipe.DenverNuggets;
                    return true;
                case "detroitpistons":
                    echipa = Echipe.DetroitPistons;
                    return true;
                case "atlantahawks":
                    echipa = Echipe.AtlantaHawks;
                    return true;
                case "dallasmavericks":
                    echipa = Echipe.DallasMavericks;
                    return true;
                case "sacramentokings":
                    echipa = Echipe.SacramentoKings;
                    return true;
                case "oklahomacitythunder":
                    echipa = Echipe.OklahomaCityThunder;
                    return true;
                case "bostonceltics":
                    echipa = Echipe.BostonCeltics;
                    return true;
                case "newyorkknicks":
                    echipa = Echipe.NewYorkKnicks;
                    return true;
                case "minnesotatimberwolves":
                    echipa = Echipe.MinnesotaTimberwolves;
                    return true;
                case "miamiheat":
                    echipa = Echipe.MiamiHeat;
                    return true;
                case "milwaukeebucks":
                    echipa = Echipe.MilwaukeeBucks;
                    return true;
                default:
                    echipa = default;
                    return false;
            }
        }

        protected override string CreateEntityAsString(Meci meci)
        {
            return
                $"{meci.Id};{meci.Echipa1.Name};{meci.Echipa2.Name};{meci.Date:yyyy-MM-dd};{meci.Echipa1.Id};{meci.Echipa2.Id}";
        }

    }
}
