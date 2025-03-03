namespace EcoEnergyPartTwo.Models
{
    public class SistemaEolic : SistemaEnergia, ICalculEnergia //Eòlic
    {
        public double WindSpeed { get; set; }
        public override double CalcularEnergia()
        {
            return Math.Round(Math.Pow(WindSpeed, 3) * 0.2, 2);
        }
    }
}
