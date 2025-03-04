using EcoEnergyPartTwo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EcoEnergyPartTwo.Models.Utilities;
using CsvHelper;
using System.Formats.Asn1;
using System.Globalization;
using System.IO;

namespace EcoEnergyPartTwo.Pages.Simulations
{
    public class AddSimulationModel : PageModel
    {
        [BindProperty]
		public SimulationForm Sim { get; set; }

        public IActionResult OnPost()
        {
            const string Path = "../EcoEnergyPartTwo/wwwroot/Resources/Files/simulacions_energia.csv";
            bool isFileEmpty = true;
            List<object> writeObjects = new List<object>();  // Canvia a la classe base

            if (!ModelState.IsValid)
            {
                return Page();
            }
            else
            {
                switch (Sim.SimulationType)
                {
                    case "Solar":
                        SistemaSolar solar = Utilities.AssignSimulationToSolar(Sim);
                        writeObjects.Add(solar);
                        break;
                    case "Hidroelèctrica":
                        SistemaHidroelectric hidro = Utilities.AssignSimulationToHidro(Sim);
                        writeObjects.Add(hidro);
                        break;
                    default:
                        SistemaEolic eolic = Utilities.AssignSimulationToEolic(Sim);
                        writeObjects.Add(eolic);
                        break;
                }

                using (var reader = new StreamReader(Path))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    isFileEmpty = csv.Read();
                }

                using (var writer = new StreamWriter(Path, append: true))
                using (var csvWriter = new CsvWriter(writer, new CsvHelper.Configuration.CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    HasHeaderRecord = !isFileEmpty
                }))
                {
                    csvWriter.WriteRecords(writeObjects); // Escriu les dades
                }
            }

            return RedirectToPage("/Simulations/Simulations");
        }
    }
}