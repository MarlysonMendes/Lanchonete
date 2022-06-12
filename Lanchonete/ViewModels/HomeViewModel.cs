using Lanchonete.Models;

namespace Lanchonete.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Lunch> FavoriteLunches { get; set; }
    }
}
