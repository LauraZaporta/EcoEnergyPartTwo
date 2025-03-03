using EcoEnergyPartTwo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EcoEnergyPartTwo.Models.Utilities;
using System.Formats.Asn1;
using System.Globalization;

namespace EcoEnergyPartTwo.Pages.Simulations
{
    public class AddSimulationModel : PageModel
	{
		[BindProperty]
		public SimulationForm Sim { get; set; }

        public IActionResult OnPost()
        {
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
                        break;
                    case "Hidroelèctric":
                        SistemaHidroelectric hidro = Utilities.AssignSimulationToHidro(Sim);
                        break;
                    default:
                        SistemaEolic eolic = Utilities.AssignSimulationToEolic(Sim);
                        break;
                }
                using (var writer = new StreamWriter(@"C:\ruta\fitxer.csv"))
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csv.WriteRecords(persones);
                }
                Console.WriteLine("Fitxer CSV escrit correctament.");

            }

            //Fotre l'error a l'escriure el form

            return RedirectToPage("Index");
        }
    }
}
