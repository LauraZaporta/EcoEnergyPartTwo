namespace EcoEnergyPartTwo.Models
{
    public class SistemaEolic : SistemaEnergia, ICalculEnergia //Eòlic
    {
        const int MinSpeed = 5;
        const int NumDecimals = 2;

        private double _velocitatVent;
        public double VelocitatVent
        {
            get { return _velocitatVent;}
            set { if (value < MinSpeed) { throw new ArgumentOutOfRangeException($"The minimum speed is {MinSpeed}"); }
                else { _velocitatVent = value; }
            }
        }
        public SistemaEolic(double velocitatVent, string simulationType, DateTime simulationDate) : base(simulationType, simulationDate)
        {
            VelocitatVent = velocitatVent;
        }
        public override double CalcularEnergia()
        {
            return Math.Round(Math.Pow(VelocitatVent, 3) * 0.2, NumDecimals);
        }
    }
}
