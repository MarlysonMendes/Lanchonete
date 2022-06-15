using Lanchonete.Models;

namespace Lanchonete.ViewModels
{
    public class LunchListViewModel
    {
        public IEnumerable<Lunch> Lunches { get; set; }
        public string CurrentCategory { get; set; }
    }
}
