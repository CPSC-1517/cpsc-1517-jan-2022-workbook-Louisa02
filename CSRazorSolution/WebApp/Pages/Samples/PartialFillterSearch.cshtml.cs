#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

#region Additional Namespaces
using WestWindSystem.BLL;
using WestWindSystem.Entities;
#endregion

namespace WebApp.Pages.Samples
{
    public class PartialFillterSearchModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;
        private readonly TerritoryServices _territoryServices;

        public PartialFillterSearchModel(ILogger<PrivacyModel> logger, TerritoryServices territoryServices)
        {
            _logger = logger;
            _territoryServices = territoryServices;
        }

        [TempData]
        public string FeedBack { get; set; }

        [BindProperty(SupportsGet = true)]
        public string searcharg { get; set; }

        public List<Territories> TerritoryInfo { get; set; } = new();

        public void OnGet()
        {
            if (!string.IsNullOrWhiteSpace(searcharg))
            {
                TerritoryInfo = _territoryServices.GetByPartialDescription(searcharg);
            }
        }

        public IActionResult OnPostFetch()
        {
            if (string.IsNullOrWhiteSpace(searcharg))
            {
                FeedBack = "Required: Search Argument is empty.";
            }
            return RedirectToPage(new { searcharg = searcharg });
        }

        public IActionResult OnPostClear()
        {
            FeedBack = "";
            //searcharg = null;
            ModelState.Clear();
            return RedirectToPage(new { searcharg = (string?)null });
        }
    }
}
