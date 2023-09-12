using Emart_final.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emart_final.Models.Repository.Cartfolder
{
    public class CartRepository : ICartRepository
    {
        private readonly AppDbContext context;

        public CartRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<Cart> SaveCart(Cart cart)
        {
            context.Cart.Add(cart);
            await context.SaveChangesAsync();
            return cart;
        }

        public async Task<IEnumerable<Cart>> GetAllCart()
        {
            var Cart = await context.Cart.ToListAsync();
            return Cart;
        }

        public async Task<Cart> GetCartById(int id)
        {
            var cart = await context.Cart.FindAsync(id);
            return cart;
        }

        public async Task DeleteCart(int id)
        {
            var cartToDelete = await context.Cart.FindAsync(id);
            if (cartToDelete != null)
            {
                context.Cart.Remove(cartToDelete);
                await context.SaveChangesAsync();
            }
        }

        public async Task<Cart> UpdateCart(Cart cart, int id)
        {
            if (id != cart.CartID)
            {
                return null;
            }

            context.Entry(cart).State = EntityState.Modified;
            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return cart;
        }

        private bool CartExists(int id)
        {
            return context.Cart.Any(e => e.CartID == id);
        }

        public async Task<IEnumerable<Cart>> FindProdByCustID(int custID)
        {
            var carts = await context.Cart
                .Where(c => c.CustID == custID)
                .ToListAsync();

            return carts;
        }

        public async Task<int> UpdateQty(int newQty, int cartId)
        {
            var cart = await context.Cart.FindAsync(cartId);
            if (cart != null)
            {
                cart.Qty = newQty;
                await context.SaveChangesAsync();
                return 1; // Update successful
            }
            return 0; // Cart not found
        }
        public async Task DeleteCartByCustomerId(int customerId)
        {
            var cartItemsToDelete = await context.Cart
                .Where(c => c.CustID == customerId)
                .ToListAsync();

            if (cartItemsToDelete != null && cartItemsToDelete.Any())
            {
                context.Cart.RemoveRange(cartItemsToDelete);
                await context.SaveChangesAsync();
            }
        }
    }
}
