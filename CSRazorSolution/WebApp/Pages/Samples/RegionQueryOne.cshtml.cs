using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


#region Additional Namespaces
using WestWindSystem.BLL;
using WestWindSystem.Entities;
#endregion

namespace WebApp.Pages.Samples
{
    public class RegionQueryOneModel : PageModel
    {

        private readonly ILogger<PrivacyModel> _logger;
        private readonly RegionServices _regionServices;

        public RegionQueryOneModel(ILogger<PrivacyModel> logger, RegionServices regionServices)
        {
            _logger = logger;
            _regionServices = regionServices;
        }

        [TempData]
        public string FeedbackMessage { get; set; }

        //SupportGet = true will allowa this property to be matched 
        //   to a routing parameter of the same name.
        [BindProperty(SupportsGet = true)]

        //this is bond to the input control via asp-for
        //this is a two way binding out and in
        //data is move out and in FOR YOU AUTOMATICALLY
        public int regionid { get; set; } 
        public Region regionInfo { get; set; }

        //the List<T> has a null value as the page is created
        //you can initialize the property to an instance as the page 
        //    is being created by adding =new() to your declaration
        //if you do, you will have an empty instance of List<T>
        [BindProperty]
        public List<Region> regionsList { get; set; } = new();

        [BindProperty]
        public int selectRegion { get; set; }

        public void OnGet()
        {
            //since the internet is a stateless environment, you need to 
            //  obtain any list data that is required by your controls or local
            //  logic on EVERY instance of the page being processed
            PopulateLists();

            if (regionid > 0)
            {
                regionInfo = _regionServices.Region_GetById(regionid);
                if (regionInfo == null)
                {
                    FeedbackMessage = "Region id is not valid. No such region on file.";
                }
                else
                {
                    FeedbackMessage = $"ID: {regionInfo.RegionId} Description {regionInfo.RegionDescription}";
                }
            }
        }

        private void PopulateLists()
        {
            //this method will obtain the data for any require list to be used
            //   in populating controls or for local logic
            regionsList = _regionServices.Region_List();
        }

        //generic falling post handler
        public void OnPost()
        {
            FeedbackMessage = " WARNING!!! No OnPost page handler found. Execution default to the coded OnPost().";
        }

        //specific post method to use in conjunction with asp-page-handler="xxx"
        public IActionResult OnPostFetch()
        {
            if (regionid < 1)
            {
                FeedbackMessage = "Required: Region ID is a non-zero positive whole number";
            }
            //the recieving "regionid" is the routing parameter
            //the sending "regionid" is a BindProperty field
            return RedirectToPage(new {regionid = regionid});
        }

        public IActionResult OnPostSelect()
        {
            if (regionid < 1)
            {
                FeedbackMessage = "Required: Select a Region to view.";
            }
            //the recieving "regionid" is the routing parameter
            //the sending "regionid" is a BindProperty field
            return RedirectToPage(new { regionid = selectRegion });
        }

        //specific post method to use in conjunction with asp-page-handler="xxx"
        public IActionResult OnPostClear()
        {
            FeedbackMessage = "";
            //regionid = 0;
            ModelState.Clear();
            return RedirectToPage(new {regionid = (int?)null});
        }
    }
}
