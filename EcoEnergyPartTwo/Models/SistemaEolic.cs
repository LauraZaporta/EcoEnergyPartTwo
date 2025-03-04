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
        public override double CalcularEnergia()
        {
            return Math.Round(Math.Pow(WindSpeed, 3) * 0.2, 2);
        }
    }
}
