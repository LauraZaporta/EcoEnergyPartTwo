using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EcoEnergyPartTwo.Pages.Simulations
{
    public class SimulationsModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public SimulationsModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}
