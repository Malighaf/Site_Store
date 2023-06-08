using Site_Store.Application.Services.Common.Queries.GetCategory;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint.Site.Areas.Admin.Views.ViewComponents
{
    [Area("Admin")]
    public class Notif : ViewComponent
    {
        private readonly IGetCategoryService _getCategoryService;
        public Notif(IGetCategoryService getCategoryService)
        {
            _getCategoryService = getCategoryService;
        }


        public IViewComponentResult Invoke()
        {
            return View(viewName: "Notif", _getCategoryService.Execute().Data);
        }
    }
}
