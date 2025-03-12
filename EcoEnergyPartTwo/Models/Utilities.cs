using System.Drawing;
using System.Text.RegularExpressions;

namespace EcoEnergyPartTwo.Models.Utilities
{
    public class Utilities
    {
        /// <summary>
        /// Comprova si un número no està dins d'un rang mínim.
        /// </summary>
        /// <param name="num">El número que es vol comprovar.</param>
        /// <param name="min">El valor mínim del rang.</param>
        /// <returns>Retorna true si el número és menor que el valor mínim; sinó, retorna false.</returns>
        public static bool CheckNotInRange(double num, double min)
        {
            return num < min;
        }

        /// <summary>
        /// Comprova si una string està tota en majúscules.
        /// </summary>
        /// <param name="word">La paraula que es vol analitzar.</param>
        /// <returns>Retorna true si la string està tota en majúscules; sinó, retorna false.</returns>
        public static bool IsAllUpper(string word)
        {
            for (int i = 0; i < word.Length; i++)
            {
                if (!Char.IsUpper(word[i]) && word[i] != ' ')
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Passa els valors d'un formulari a un objecte SistemaSolar i el retorna.
        /// </summary>
        /// <param name="form">El formulari del qual es volen prendre els paràmetres.</param>
        /// <returns>Retorna un objecte SistemaSolar amb els valors del formulari.</returns>
        public static SistemaSolar AssignSimulationToSolar(SimulationForm form)
        {
            SistemaSolar solar = new SistemaSolar
            {
                SimulationType = form.SimulationType,
                SimulationDate = DateTime.Now,
                Rati = form.Rati,
                HoursOfSun = form.SpecificField,
                CostkWh = form.CostkWh,
                PricekWh = form.PricekWh
            };
            solar.GeneratedEnergy = solar.CalcularEnergia();
            solar.AssignTotalCost();
            solar.AssignTotalPrice();
            return solar;
        }

        /// <summary>
        /// Passa els valors d'un formulari a un objecte SistemaHidroelectric i el retorna.
        /// </summary>
        /// <param name="form">El formulari del qual es volen prendre els paràmetres.</param>
        /// <returns>Retorna un objecte SistemaHidroelectric amb els valors del formulari.</returns>
        public static SistemaHidroelectric AssignSimulationToHidro(SimulationForm form)
        {
            SistemaHidroelectric hidro = new SistemaHidroelectric
            {
                SimulationType = form.SimulationType,
                SimulationDate = DateTime.Now,
                Rati = form.Rati,
                WaterFlow = form.SpecificField,
                CostkWh = form.CostkWh,
                PricekWh = form.PricekWh
            };
            hidro.GeneratedEnergy = hidro.CalcularEnergia();
            hidro.AssignTotalCost();
            hidro.AssignTotalPrice();
            return hidro;
        }

        /// <summary>
        /// Passa els valors d'un formulari a un objecte SistemaEolic i el retorna.
        /// </summary>
        /// <param name="form">El formulari del qual es volen prendre els paràmetres.</param>
        /// <returns>Retorna un objecte SistemaEolic amb els valors del formulari.</returns>
        public static SistemaEolic AssignSimulationToEolic(SimulationForm form)
        {
            SistemaEolic eolic = new SistemaEolic
            {
                SimulationType = form.SimulationType,
                SimulationDate = DateTime.Now,
                Rati = form.Rati,
                WindSpeed = form.SpecificField,
                CostkWh = form.CostkWh,
                PricekWh = form.PricekWh
            };
            eolic.GeneratedEnergy = eolic.CalcularEnergia();
            eolic.AssignTotalCost();
            eolic.AssignTotalPrice();
            return eolic;
        }

        /// <summary>
        /// Detecta els objectes d'una llista WaterConRecord que tenen tendència creixent en consum d'aigua,
        /// emmagatzema els noms de les seves respectives comarques en una llista d'strings i la retorna.
        /// </summary>
        /// <param name="waterConsumptions">Llista de la que es volen extreure les "comarques creixents".</param>
        /// <returns>Retorna una llista amb els noms de les comarques creixents.</returns>
        public static List<string?> DetectGrowingConsums(List<WaterConRecord> waterConsumptions)
        {
            List<string?> growingMunicipalities = new();

            //Agrupem per comarca
            var groupedByComarca = waterConsumptions
            .GroupBy(w => w.Comarca);

            foreach (var comarcaGroup in groupedByComarca)
            {
                //Agrupem per any i fem la mitjana del consum
                var yearlyAverage = comarcaGroup
                    .GroupBy(w => w.Year)
                    .Select(g => new
                    {
                        Year = g.Key,
                        AverageConsum = g.Average(x => x.Total)
                    })
                    .OrderBy(x => x.Year)
                    .ToList();
                var lastYears = yearlyAverage
                .OrderByDescending(x => x.Year)
                .Take(5)
                .OrderBy(x => x.Year)
                .ToList();
                bool isGrowing = true;
                for (int i = 0; i < lastYears.Count - 1; i++)
                {
                    if (lastYears[i + 1].AverageConsum <= lastYears[i].AverageConsum)
                    {
                        isGrowing = false;
                        i = lastYears.Count;
                    }
                }
                if (isGrowing)
                {
                    growingMunicipalities.Add(comarcaGroup.Key);
                }
            }
            return growingMunicipalities;
        }

        /// <summary>
        /// Comprova si una string compleix un format de data concret (mm/yyyy) i no supera l'any actual
        /// </summary>
        /// <param name="data">String que representa una data en formaat mes/any.</param>
        /// <returns>Retorna true si la data concorda amb el format i no supera l'any actual; sinó, retorna false.</returns>
        public static bool IsValidDate(string data)
        {
            int anyActual = DateTime.Now.Year;

            if (Regex.IsMatch(data, @"^(0[1-9]|1[0-2])\/\d{4}$"))
            {
                int any = int.Parse(data.Substring(3, 4));
                return any <= anyActual;
            }
            return false;
        }
    }
}