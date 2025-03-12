using CsvHelper.Configuration.Attributes;

namespace EcoEnergyPartTwo.Models
{
    public class SistemaEolic : SistemaEnergia, ICalculEnergia //Eòlic
    {
        private double _windSpeed;

        [Name("Hores de sol disponibles / Velocitat del vent / Cabal de l’aigua")]
        public double WindSpeed {
            get { return _windSpeed; }
            set { if (value >= 5) { _windSpeed = value; }
                else { throw new ArgumentException("Invalid value"); }
            } 
        }

        /// <summary>
        /// Calcula l'energia generada per un SistemaEolic.
        /// </summary>
        /// <param>Sense paràmetres.</param>
        /// <returns>Retorna un double amb la quantitat d'energia generada.</returns>
        public override double CalcularEnergia()
        {
            return Math.Round(Math.Pow(WindSpeed, 3) * Rati, 2);
        }
    }
}
