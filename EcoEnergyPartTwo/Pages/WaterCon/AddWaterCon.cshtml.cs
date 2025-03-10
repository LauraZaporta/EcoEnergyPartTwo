using EcoEnergyPartTwo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Xml.Linq; 
using System.IO; 

namespace EcoEnergyPartTwo.Pages.WaterCon
{
    public class AddWaterConModel : PageModel
    {
        [BindProperty]
        public WaterConRecord WC { get; set; }

        public IActionResult OnPost()
        {
            const string Path = "../EcoEnergyPartTwo/wwwroot/Resources/Files/consum_aigua_cat_per_comarques.xml";

            // Comprovem si el formulari �s v�lid
            if (!ModelState.IsValid)
            {
                return Page();
            }

            XElement rootElement = XElement.Load(Path);

            if (!rootElement.Elements("consum").Any()) //Si no hi ha cap element "consum" afegeix la "cap�alera"
            {
                XElement header = new XElement("consum",
                    new XElement("year", "Any"),
                    new XElement("codeComarca", "Codi comarca"),
                    new XElement("comarca", "Comarca"),
                    new XElement("pobl", "Poblaci�"),
                    new XElement("domXarxa", "Dom�stic xarxa"),
                    new XElement("altresActivitats", "Activitats econ�miques i fonts pr�pies"),
                    new XElement("total", "Total"),
                    new XElement("consumDom", "Consum dom�stic per c�pita")
                );
                rootElement.Add(header);
            }

            XElement newEntry = new XElement("consum",
                new XElement("year", WC.Year),
                new XElement("codeComarca", WC.CodeComarca),
                new XElement("comarca", WC.Comarca),
                new XElement("pobl", WC.Pobl),
                new XElement("domXarxa", WC.DomXarxa),
                new XElement("altresActivitats", WC.AltresActivitats),
                new XElement("total", WC.Total),
                new XElement("consumDom", WC.ConsumDom)
            );

            rootElement.Add(newEntry);
            rootElement.Save(Path);

            return RedirectToPage("/WaterCon/WaterCon");
        }
    }
}