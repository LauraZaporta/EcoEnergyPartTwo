using System.Drawing;

namespace EcoEnergyPartTwo.Models.Utilities
{
    public class Utilities
    {
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
    }
}