using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EcoEnergyPartTwo.Pages.EnergyInd
{
    public class EnergyModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public EnergyModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}
