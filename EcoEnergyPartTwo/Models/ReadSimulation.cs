namespace EcoEnergyPartTwo.Models
{
    public class ReadSimulation
    {
        public double SpecificField { get; set; }
        public string? SimulationType { get; set; }
        public DateTime SimulationDate { get; set; }
        public double Rati { get; set; }
        public double GeneratedEnergy { get; set; }
        public double CostkWh { get; set; }
        public double PricekWh { get; set; }
        public double TotalCostkWh { get; set; }
        public double TotalPricekWh { get; set; }
    }
}