using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EcoEnergyPartTwo.Pages.WaterCon
{
    public class WaterModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public WaterModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}
