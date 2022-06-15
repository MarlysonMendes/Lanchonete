using Lanchonete.Models;
using Lanchonete.Repositories.Interfaces;
using Lanchonete.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Lanchonete.Controllers
{
    public class LunchesController : Controller
    {
        private readonly ILunchRepository _lunchRepository;

        public LunchesController(ILunchRepository lunchRepository)
        {
            _lunchRepository = lunchRepository;
        }

        public IActionResult List(string category)
        {
            IEnumerable<Lunch> lanches;
            string currentCategory = string.Empty;

            if (string.IsNullOrEmpty(category))
            {
                lanches = _lunchRepository.Lunches.OrderBy(l => l.LuchId);
                currentCategory = "Todos os lanches";
            }
            else
            {

                lanches = _lunchRepository.Lunches
                          .Where(l => l.Category.CategoryName.Equals(category))
                          .OrderBy(c => c.LuchName);

                currentCategory = category;
            }

            var lunchesListViewModel = new LunchListViewModel
            {
                Lunches = lanches,
                CurrentCategory = currentCategory
            };

            return View(lunchesListViewModel);
        }
    }
}
