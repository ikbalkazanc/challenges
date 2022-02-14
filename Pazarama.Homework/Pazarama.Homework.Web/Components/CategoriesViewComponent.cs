using Microsoft.AspNetCore.Mvc;
using Pazarama.Homework.Data;

namespace Pazarama.Homework.Web.Components
{
    public class CategoriesViewComponent : ViewComponent
    {

        private readonly DatabaseContext _context;
        public CategoriesViewComponent(DatabaseContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedGenre = RouteData.Values["id"];
            return View(_context.Categories.ToList());
        }
    }
}
