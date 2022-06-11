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

        public IActionResult List()
        {
            //var lunches = _lunchRepository.Lunches;
            // return View(lunches);
            var lunchViewModel = new LunchListViewModel();
            lunchViewModel.Lunches = _lunchRepository.Lunches;
            lunchViewModel.currentCatgory = "Categoria Atual";
            return View(lunchViewModel);
        }
    }
}
