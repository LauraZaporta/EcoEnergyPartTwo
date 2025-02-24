namespace EcoEnergyPartTwo.Models
{
    public abstract class SistemaEnergia
    {
        public DateTime SimulationDate { get; set; }
        public string SimulationType { get; set; }
        public double SimulationGeneratedEnergy { get; set; }

        public static double DefaultSimulationGeneratedEnergy = 0;

        public SistemaEnergia(string simulationType, DateTime simulationDate)
        {
            SimulationDate = simulationDate;
            SimulationType = simulationType;
            SimulationGeneratedEnergy = DefaultSimulationGeneratedEnergy;
        }

        public abstract double CalcularEnergia();
    }
}
