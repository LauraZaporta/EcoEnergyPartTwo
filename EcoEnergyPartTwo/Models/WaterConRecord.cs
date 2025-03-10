using System.ComponentModel.DataAnnotations;
using CsvHelper.Configuration.Attributes;

namespace EcoEnergyPartTwo.Models
{
    public class WaterConRecord : IValidatableObject
    {
        const string MandatoryField = "Aquest camp és obligatori";
        const string RangeYear = "El camp any no pot superar l'any actual i no pot haver sigut abans del 1900";
        const string RangeCodeComarca = "El codi de comarca ha d'estar entre 0 i 41";
        const string ComarcaUpperError = "La comarca ha d'estar en majúscules i no pot contenir números";
        const string PositiveRequired = "El valor ha de ser positiu";
        const string PositiveRequiredInt = "El valor ha de ser positiu, sense decimals";

        [Name("Any")]
        [Required(ErrorMessage = MandatoryField)]
        public int Year { get; set; }

        [Name("Codi comarca")]
        [Required(ErrorMessage = MandatoryField)]
        [Range(0, 41, ErrorMessage = RangeCodeComarca)]
        public int CodeComarca { get; set; }

        [Name("Comarca")]
        [Required(ErrorMessage = MandatoryField)]
        public string? Comarca { get; set; }

        [Name("Població")]
        [Required(ErrorMessage = MandatoryField)]
        [Range(0, int.MaxValue, ErrorMessage = PositiveRequiredInt)]
        public int Pobl { get; set; }

        [Name("Domèstic xarxa")]
        [Required(ErrorMessage = MandatoryField)]
        [Range(0, int.MaxValue, ErrorMessage = PositiveRequiredInt)]
        public int DomXarxa { get; set; }

        [Name("Activitats econòmiques i fonts pròpies")]
        [Required(ErrorMessage = MandatoryField)]
        [Range(0, int.MaxValue, ErrorMessage = PositiveRequiredInt)]
        public int AltresActivitats { get; set; }

        [Name("Total")]
        [Required(ErrorMessage = MandatoryField)]
        [Range(0, int.MaxValue, ErrorMessage = PositiveRequiredInt)]
        public int Total { get; set; }

        [Name("Consum domèstic per càpita")]
        [Required(ErrorMessage = MandatoryField)]
        [Range(0, double.MaxValue, ErrorMessage = PositiveRequired)]
        public double ConsumDom { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Year < 1900 || Year > DateTime.Now.Year)
            {
                yield return new ValidationResult(RangeYear, new[] { nameof(Year) });
            }
            if (!Utilities.Utilities.IsAllUpper(Comarca))
            {
                yield return new ValidationResult(ComarcaUpperError, new[] { nameof(Comarca) });
            }
        }
    }
}