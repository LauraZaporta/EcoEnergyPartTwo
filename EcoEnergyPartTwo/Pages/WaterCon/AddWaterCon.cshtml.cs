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

            // Comprovem si el formulari és vàlid
            if (!ModelState.IsValid)
            {
                return Page();
            }

            XElement rootElement = XElement.Load(Path);

            if (!rootElement.Elements("consum").Any()) //Si no hi ha cap element "consum" afegeix la "capçalera"
            {
                XElement header = new XElement("consum",
                    new XElement("year", "Any"),
                    new XElement("codeComarca", "Codi comarca"),
                    new XElement("comarca", "Comarca"),
                    new XElement("pobl", "Població"),
                    new XElement("domXarxa", "Domèstic xarxa"),
                    new XElement("altresActivitats", "Activitats econòmiques i fonts pròpies"),
                    new XElement("total", "Total"),
                    new XElement("consumDom", "Consum domèstic per càpita")
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