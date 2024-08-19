using Microsoft.AspNetCore.Mvc;

namespace CCRS.WebApp.MVC.Extensions
{
    public class SummaryViewComponent : ViewComponent 
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult(View()); 
        }
    }
}
