using Lanchonete.Models;

namespace Lanchonete.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
    }
}
