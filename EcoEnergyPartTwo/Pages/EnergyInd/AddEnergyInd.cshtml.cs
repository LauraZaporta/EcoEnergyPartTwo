using System.Text.Json;
using EcoEnergyPartTwo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EcoEnergyPartTwo.Pages.WaterCon
{
    public class AddEnergyIndModel : PageModel
    {
        [BindProperty]
        public EnergyIndRecord EI { get; set; }

        public IActionResult OnPost()
        {
            const string Path = "../EcoEnergyPartTwo/wwwroot/Resources/Files/indicadors_energetics_cat.json";

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var existingData = new List<EnergyIndRecord>();
            var headers = new List<EnergyIndRecordHeader>();

            if (System.IO.File.Exists(Path) && new FileInfo(Path).Length > 0)
            {
                var json = System.IO.File.ReadAllText(Path);
                try
                {
                    existingData = JsonSerializer.Deserialize<List<EnergyIndRecord>>(json) ?? new List<EnergyIndRecord>();
                    headers = JsonSerializer.Deserialize<List<EnergyIndRecordHeader>>(json) ?? new List<EnergyIndRecordHeader>();
                }
                catch (JsonException)
                {
                    existingData = new List<EnergyIndRecord>();
                    headers = new List<EnergyIndRecordHeader>();
                }
            }
            else //Si el fitxer no existeix o està buit es crea el header
            {
                var header = new EnergyIndRecordHeader
                {
                    Data = "Data",
                    PBEEHidroelectr = "PBEEHidroelectr",
                    PBEECarbo = "PBEECarbo",
                    PBEEGasNat = "PBEEGasNat",
                    PBEEFuelOil = "PBEEFuelOil",
                    PBEECiclComb = "PBEECiclComb",
                    PBEENuclear = "PBEENuclear",
                    CDEEBCProdBruta = "CDEEBCProdBruta",
                    CDEEBCConsumAux = "CDEEBCConsumAux",
                    CDEEBCProdNeta = "CDEEBCProdNeta",
                    CDEEBCConsumBomb = "CDEEBCConsumBomb",
                    CDEEBCProdDisp = "CDEEBCProdDisp",
                    CDEEBCTotVendesXarxaCentral = "CDEEBCTotVendesXarxaCentral",
                    CDEEBCSaldoIntercanviElectr = "CDEEBCSaldoIntercanviElectr",
                    CDEEBCDemandaElectr = "CDEEBCDemandaElectr",
                    CDEEBCPercentMercatRegulat = "CDEEBCPercentMercatRegulat",
                    CDEEBCPercentMercatLliure = "CDEEBCPercentMercatLliure",
                    FEEIndustria = "FEEIndustria",
                    FEETerciari = "FEETerciari",
                    FEEDomestic = "FEEDomestic",
                    FEEPrimari = "FEEPrimari",
                    FEEEnergetic = "FEEEnergetic",
                    FEEIConsObrPub = "FEEIConsObrPub",
                    FEEISiderFoneria = "FEEISiderFoneria",
                    FEEIMetalurgia = "FEEIMetalurgia",
                    FEEIIndusVidre = "FEEIIndusVidre",
                    FEEICimentsCalGuix = "FEEICimentsCalGuix",
                    FEEIAltresMatConstr = "FEEIAltresMatConstr",
                    FEEIQuimPetroquim = "FEEIQuimPetroquim",
                    FEEIConstrMedTrans = "FEEIConstrMedTrans",
                    FEEIRestaTransforMetal = "FEEIRestaTransforMetal",
                    FEEIAlimBegudaTabac = "FEEIAlimBegudaTabac",
                    FEEITextilConfecCuirCalcat = "FEEITextilConfecCuirCalcat",
                    FEEIPastaPaperCartro = "FEEIPastaPaperCartro",
                    FEEIAltresIndus = "FEEIAltresIndus",
                    DGGNPuntFrontEnagas = "DGGNPuntFrontEnagas",
                    DGGNDistrAlimGNL = "DGGNDistrAlimGNL",
                    DGGNConsumGNCentrTerm = "DGGNConsumGNCentrTerm",
                    CCACGasolinaAuto = "CCACGasolinaAuto",
                    CCACGasoilA = "CCACGasoilA"
                };
                headers.Add(header);
            }

            existingData.Add(EI);
            var jsonString = JsonSerializer.Serialize(new { Header = headers, Data = existingData }, new JsonSerializerOptions { WriteIndented = true });
            System.IO.File.WriteAllText(Path, jsonString);

            return RedirectToPage("/EnergyInd/EnergyInd");
        }
    }
}