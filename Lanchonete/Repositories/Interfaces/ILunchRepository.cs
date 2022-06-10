using Lanchonete.Models;

namespace Lanchonete.Repositories.Interfaces
{
    public interface ILunchRepository
    {
        IEnumerable<Lunch> Lunches { get; }
        IEnumerable<Lunch> FavoritesLunches { get; }
        Lunch GetLunchById(int lancheId);

    }
}
