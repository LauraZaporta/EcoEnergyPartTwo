using System.ComponentModel.DataAnnotations;
using EcoEnergyPartTwo.Models.Utilities;

namespace EcoEnergyPartTwo.Models
{
    public class SimulationForm : IValidatableObject
    {
        const string MandatoryField = "Aquest camp és obligatori";
        const string RatiRange = "El rati ha d'estar per sobre de 0 i per sota de 3.";
        const string CostRange = "El cost ha de ser un valor positiu.";
        const string PriceRange = "El preu ha de ser un valor positiu.";
        const string SpecificFieldRange = "El valor de {0} ha d'estar per sobre de {1}.";
        const double MinSunHours = 1;
        const double MinWaterFlow = 20;
        const double MinWindSpeed = 5;

        [Required(ErrorMessage = MandatoryField)]
        public string? SimulationType { get; set; }

        [Required(ErrorMessage = MandatoryField)]
        public double SpecificField { get; set; }

        [Required(ErrorMessage = MandatoryField)]
        [Range(0.01, 3, ErrorMessage = RatiRange)]
        public double Rati { get; set; }

        [Required(ErrorMessage = MandatoryField)]
        [Range(0.01, double.MaxValue, ErrorMessage = CostRange)]
        public double CostkWh { get; set; }

        [Required(ErrorMessage = MandatoryField)]
        [Range(0.01, double.MaxValue, ErrorMessage = PriceRange)]
        public double PricekWh { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            switch (SimulationType)
            {
                case "Solar":
                    if (Utilities.Utilities.CheckNotInRange(SpecificField, MinSunHours))
                        yield return new ValidationResult(string.Format(SpecificFieldRange, "hores de sol", MinSunHours), new[] { nameof(SpecificField) });
                    break;

                case "Hidroelèctrica":
                    if (Utilities.Utilities.CheckNotInRange(SpecificField, MinWaterFlow))
                        yield return new ValidationResult(string.Format(SpecificFieldRange, "cabal d'aigua", MinWaterFlow), new[] { nameof(SpecificField) });
                    break;

                case "Eòlica":
                    if (Utilities.Utilities.CheckNotInRange(SpecificField, MinWindSpeed))
                        yield return new ValidationResult(string.Format(SpecificFieldRange, "velocitat del vent", MinWindSpeed), new[] { nameof(SpecificField) });
                    break;
            }
        }
    }
}
