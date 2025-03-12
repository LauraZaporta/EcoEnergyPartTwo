using System.ComponentModel.DataAnnotations;
using EcoEnergyPartTwo.Models.Utilities;
using System.Data;
using System.Text.RegularExpressions;
using CsvHelper.Configuration.Attributes;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EcoEnergyPartTwo.Models
{
    public class EnergyIndRecord : IValidatableObject
    {
        const string MandatoryField = "Aquest camp és obligatori";
        const string PositiveRequired = "El valor ha de ser positiu";
        const string RangeData = "La data ha d'estar entre 1900 i l'any actual";
        const string DateFormatError = "El format ha de ser mm/yyyy";

        [Required(ErrorMessage = MandatoryField)]
        [RegularExpression(@"^(0[1-9]|1[0-2])\/\d{4}$", ErrorMessage = DateFormatError)]
        public string? Data { get; set; }

        [Name("PBEE_Hidroelectr")]
        public double PBEEHidroelectr { get; set; }

        [Name("PBEE_Carbo")]
        public double PBEECarbo { get; set; }

        [Name("PBEE_GasNat")]
        public double PBEEGasNat { get; set; }

        [Name("PBEE_Fuel-Oil")]
        public double PBEEFuelOil { get; set; }

        [Name("PBEE_CiclComb")]
        public double PBEECiclComb { get; set; }

        [Name("PBEE_Nuclear")]
        public double PBEENuclear { get; set; }

        [Name("CDEEBC_ProdBruta")]
        public double CDEEBCProdBruta { get; set; }

        [Name("CDEEBC_ConsumAux")]
        public double CDEEBCConsumAux { get; set; }

        [Required(ErrorMessage = MandatoryField)]
        [Range(0, double.MaxValue, ErrorMessage = PositiveRequired)]
        [Name("CDEEBC_ProdNeta")]
        public double CDEEBCProdNeta { get; set; }

        [Name("CDEEBC_ConsumBomb")]
        public double CDEEBCConsumBomb { get; set; }

        [Required(ErrorMessage = MandatoryField)]
        [Range(0, double.MaxValue, ErrorMessage = PositiveRequired)]
        [Name("CDEEBC_ProdDisp")]
        public double CDEEBCProdDisp { get; set; }

        [Name("CDEEBC_TotVendesXarxaCentral")]
        public double CDEEBCTotVendesXarxaCentral { get; set; }

        [Name("CDEEBC_SaldoIntercanviElectr")]
        public double CDEEBCSaldoIntercanviElectr { get; set; }

        [Required(ErrorMessage = MandatoryField)]
        [Range(0, double.MaxValue, ErrorMessage = PositiveRequired)]
        [Name("CDEEBC_DemandaElectr")]
        public double CDEEBCDemandaElectr { get; set; }

        [Name("CDEEBC_TotalEBCMercatRegulat")]
        public string? CDEEBCPercentMercatRegulat { get; set; } = "50.0%";

        [Name("CDEEBC_TotalEBCMercatLliure")]
        public string? CDEEBCPercentMercatLliure { get; set; } = "50.0%";

        [Name("FEE_Industria")]
        public double? FEEIndustria { get; set; }

        [Name("FEE_Terciari")]
        public double? FEETerciari { get; set; }

        [Name("FEE_Domestic")]
        public double? FEEDomestic { get; set; }

        [Name("FEE_Primari")]
        public double? FEEPrimari { get; set; }

        [Name("FEE_Energetic")]
        public double? FEEEnergetic { get; set; }

        [Name("FEEI_ConsObrPub")]
        public double? FEEIConsObrPub { get; set; }

        [Name("FEEI_SiderFoneria")]
        public double? FEEISiderFoneria { get; set; }

        [Name("FEEI_Metalurgia")]
        public double? FEEIMetalurgia { get; set; }

        [Name("FEEI_IndusVidre")]
        public double? FEEIIndusVidre { get; set; }

        [Name("FEEI_CimentsCalGuix")]
        public double? FEEICimentsCalGuix { get; set; }

        [Name("FEEI_AltresMatConstr")]
        public double? FEEIAltresMatConstr { get; set; }

        [Name("FEEI_QuimPetroquim")]
        public double? FEEIQuimPetroquim { get; set; }

        [Name("FEEI_ConstrMedTrans")]
        public double? FEEIConstrMedTrans { get; set; }

        [Name("FEEI_RestaTransforMetal")]
        public double? FEEIRestaTransforMetal { get; set; }

        [Name("FEEI_AlimBegudaTabac")]
        public double? FEEIAlimBegudaTabac { get; set; }

        [Name("FEEI_TextilConfecCuirCalçat")]
        public double? FEEITextilConfecCuirCalcat { get; set; }

        [Name("FEEI_PastaPaperCartro")]
        public double? FEEIPastaPaperCartro { get; set; }

        [Name("FEEI_AltresIndus")]
        public double? FEEIAltresIndus { get; set; }

        [Name("DGGN_PuntFrontEnagas")]
        public double DGGNPuntFrontEnagas { get; set; }

        [Name("DGGN_DistrAlimGNL")]
        public double DGGNDistrAlimGNL { get; set; }

        [Name("DGGN_ConsumGNCentrTerm")]
        public double DGGNConsumGNCentrTerm { get; set; }

        [Required(ErrorMessage = MandatoryField)]
        [Range(0, double.MaxValue, ErrorMessage = PositiveRequired)]
        [Name("CCAC_GasolinaAuto")]
        public double CCACGasolinaAuto { get; set; }

        [Name("CCAC_GasoilA")]
        public double CCACGasoilA { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!Utilities.Utilities.IsValidDate(Data))
            {
                yield return new ValidationResult(RangeData, new[] { nameof(Data) });
            }
        }
    }
}