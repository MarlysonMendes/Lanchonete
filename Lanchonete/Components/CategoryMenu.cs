using Lanchonete.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Lanchonete.Components
{
    public class CategoryMenu : ViewComponent
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryMenu(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public IViewComponentResult Invoke()
        {
            var categoryes = _categoryRepository.Categories.OrderBy(c => c.CategoryName);
            return View(categoryes);
        }
    }
}
