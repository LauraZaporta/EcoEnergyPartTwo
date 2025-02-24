namespace EcoEnergyPartTwo.Models
{
    public class SistemaSolar : SistemaEnergia, ICalculEnergia
    {
        const int NumDecimals = 2;
        const int MinHours = 1;

        private double _horesDeSol;
        public double HoresDeSol
        {
            get { return _horesDeSol; }
            set
            {
                if (value < MinHours) { throw new ArgumentOutOfRangeException($"The minimum speed is {MinHours}"); }
                else { _horesDeSol = value; }
            }
        }
        public SistemaSolar(double horesDeSol, string simulationType, DateTime simulationDate) : base(simulationType, simulationDate)
        {
            HoresDeSol = horesDeSol;
        }
        public override double CalcularEnergia()
        {
            return Math.Round(HoresDeSol * 1.5, NumDecimals);
        }
    }
}
