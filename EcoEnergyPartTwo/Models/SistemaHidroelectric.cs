namespace EcoEnergyPartTwo.Models
{
    public class SistemaHidroelectric : SistemaEnergia, ICalculEnergia //Hidroelèctric
    {
        const int NumDecimals = 2;
        const int MinFlow = 20;

        private double _cabalAigua;
        public double CabalAigua
        {
            get { return _cabalAigua; }
            set
            {
                if (value < MinFlow) { throw new ArgumentOutOfRangeException($"The minimum flow is {MinFlow}"); }
                else { _cabalAigua = value; }
            }
        }
        public SistemaHidroelectric(double cabalAigua, string simulationType, DateTime simulationDate) : base(simulationType, simulationDate)
        {
            CabalAigua = cabalAigua;
        }
        public override double CalcularEnergia()
        {
            return Math.Round(CabalAigua * 9.8 * 0.8, NumDecimals);
        }
    }
}
