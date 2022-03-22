#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

#region Additional Namespaces
using WestWindSystem.BLL;
using WestWindSystem.Entities;
using WebApp.Helpers;
#endregion

namespace WebApp.Pages.Samples
{
    public class PartialFilterSearchModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;
        private readonly TerritoryServices _territoryServices;
        private readonly RegionServices _regionServices;

        public PartialFilterSearchModel(ILogger<PrivacyModel> logger, TerritoryServices territoryServices, RegionServices regionServices)
        {
            _logger = logger;
            _territoryServices = territoryServices;
            _regionServices = regionServices;
        }

        [TempData]
        public string FeedBack { get; set; }

        [BindProperty(SupportsGet = true)]
        public string searcharg { get; set; }

        public List<Territories> TerritoryInfo { get; set; }

        [BindProperty]
        public List<Region> RegionsList { get; set; } = new();


        #region Paginator
        //my desired page size
        private const int PAGE_SIZE = 5;
        //be able to hold an instance of the Paginator
        public Paginator Pager { get; set; }
        #endregion
        public void OnGet(int? currentPage)
        {
            //using the Paginator with your query

            //OnGet will have a parameter (Request query string) that recieves the 
            // current page number. On the initial load of page, this value will be null
            
            //obtain the data list for the Region dropdown list (select tag)
            RegionsList = _regionServices.Region_List();
            if (!string.IsNullOrWhiteSpace(searcharg))
            {
                //setting up for using the paginator only needs to be done if
                //   a query is executing


                //determine the current page number
                int pagenumber = currentPage.HasValue ? currentPage.Value : 1;
                //set up the current state of the paginotor (string)
                PageState current = new(pagenumber, PAGE_SIZE);
                //temporary local integer to hold the results of the query's total collection size
                //  this will be needed by the Paginator during the paginator's execution
                int totalcount;

                //we need to pass paging data into our query so that efficiencies in the 
                // system will ONLY return the amount of records to actually be display
                //  on the browser page.

                TerritoryInfo = _territoryServices.GetByPartialDescription(searcharg,
                                  pagenumber, PAGE_SIZE, out totalcount);

                //create the needed paginator instance
                Pager = new(totalcount, current);
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
