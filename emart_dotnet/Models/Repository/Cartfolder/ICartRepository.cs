using Emart_final.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Emart_final.Models.Repository.Cartfolder
{
    public interface ICartRepository
    {
        Task<Cart> SaveCart(Cart obj);
        Task<IEnumerable<Cart>> GetAllCart();
        Task<Cart> GetCartById(int id);
        Task DeleteCart(int id);
        Task<Cart> UpdateCart(Cart c, int id);
        Task<IEnumerable<Cart>> FindProdByCustID(int cid);
        Task<int> UpdateQty(int QT, int cid);
        Task DeleteCartByCustomerId(int customerId);
    }
}
