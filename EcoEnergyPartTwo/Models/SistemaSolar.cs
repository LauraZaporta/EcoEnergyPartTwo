using CsvHelper.Configuration.Attributes;

namespace EcoEnergyPartTwo.Models
{
    public class SistemaSolar : SistemaEnergia, ICalculEnergia
    {
        private double _hoursOfSun;

        [Name("Hores de sol disponibles / Velocitat del vent / Cabal de l’aigua")]
        public double HoursOfSun
        {
            get { return _hoursOfSun; }
            set { if (value >= 1) { _hoursOfSun = value; }
                else { throw new ArgumentException("Invalid value"); }
            }
        }
        public override double CalcularEnergia()
        {
            return Math.Round(HoursOfSun * 1.5, 2);
        }
    }
}