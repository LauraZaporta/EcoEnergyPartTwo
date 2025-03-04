using CsvHelper;
using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EcoEnergyPartTwo.Pages.Simulations
{
	public class SimulationModel : PageModel
	{
        public List<dynamic> Simulations { get; set; } = new();
        public void OnGet()
        {
            string path = "../EcoEnergyPartTwo/wwwroot/Resources/Files/simulacions_energia.csv";

            if (System.IO.File.Exists(path))
            {
                using (var reader = new StreamReader(path))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    Simulations = csv.GetRecords<dynamic>().ToList();
                }
            }
        }
    }
}
