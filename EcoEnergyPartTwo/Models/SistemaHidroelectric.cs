namespace EcoEnergyPartTwo.Models
{
    public class SistemaHidroelectric : SistemaEnergia, ICalculEnergia //Hidroelèctric
    {
        public double WaterFlow { get; set; }
        public override double CalcularEnergia()
        {
            return Math.Round(WaterFlow * 9.8 * 0.8, 2);
        }
    }
}
