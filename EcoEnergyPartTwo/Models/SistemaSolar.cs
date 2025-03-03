namespace EcoEnergyPartTwo.Models
{
    public class SistemaSolar : SistemaEnergia, ICalculEnergia
    {
        public double HoursOfSun { get; set; }
        public override double CalcularEnergia()
        {
            return Math.Round(HoursOfSun * 1.5, 2);
        }
    }
}
