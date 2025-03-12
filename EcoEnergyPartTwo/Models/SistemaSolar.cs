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

        /// <summary>
        /// Calcula l'energia generada per un SistemaSolar.
        /// </summary>
        /// <param>Sense paràmetres.</param>
        /// <returns>Retorna un double amb la quantitat d'energia generada.</returns>
        public override double CalcularEnergia()
        {
            return Math.Round(HoursOfSun * Rati, 2);
        }
    }
}