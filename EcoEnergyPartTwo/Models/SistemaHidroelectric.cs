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

        /// <summary>
        /// Calcula l'energia generada per un SistemaHidroelectric.
        /// </summary>
        /// <param>Sense paràmetres.</param>
        /// <returns>Retorna un double amb la quantitat d'energia generada.</returns>
        public override double CalcularEnergia()
        {
            return Math.Round(WaterFlow * 9.8 * Rati, 2);
        }
    }
}
