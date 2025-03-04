using CsvHelper.Configuration.Attributes;

namespace EcoEnergyPartTwo.Models
{
    public class SistemaHidroelectric : SistemaEnergia, ICalculEnergia //Hidroelèctric
    {
        private double _waterFlow;

        [Name("Hores de sol disponibles / Velocitat del vent / Cabal de l’aigua")]
        public double WaterFlow
        {
            get { return _waterFlow; }
            set { if (value >= 20) { _waterFlow = value; }
                else { throw new ArgumentException("Invalid value"); }
            }
        }
        public override double CalcularEnergia()
        {
            return Math.Round(WaterFlow * 9.8 * 0.8, 2);
        }
    }
}
