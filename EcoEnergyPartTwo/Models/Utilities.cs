using System.Drawing;

namespace EcoEnergyPartTwo.Models.Utilities
{
    public class Utilities
    {
        public static bool CheckNotInRange(double num, double min)
        {
            return num < min;
        }
        public static bool IsAllUpper(string word)
        {
            for (int i = 0; i < word.Length; i++)
            {
                if (!Char.IsUpper(word[i]) && word[i] != ' ')
                    return false;
            }
            return true;
        }
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
    }
}