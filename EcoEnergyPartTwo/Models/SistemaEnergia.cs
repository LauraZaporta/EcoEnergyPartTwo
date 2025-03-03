namespace EcoEnergyPartTwo.Models
{
    public abstract class SistemaEnergia
    {
		public string? SimulationType { get; set; }
		public DateTime SimulationDate { get; set; }
        public double Rati { get; set; }
		public double GeneratedEnergy { get; set; }
        public double CostkWh { get; set; }
		public double PricekWh { get; set; }
        public double CostTotal { get; set; }
        public double PriceTotal { get; set; }
		public abstract double CalcularEnergia();
        public void AssignTotalCost(){ CostTotal = GeneratedEnergy * CostkWh; }
        public void AssignTotalPrice() { PriceTotal = GeneratedEnergy * PricekWh; }
    }
}
