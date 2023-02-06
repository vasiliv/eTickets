using eTickets.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace eTickets.Data.Cart
{
    //add or remove items to shopping cart
    public class ShoppingCart
    {
        private readonly AppDbContext _context;
        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }
        public ShoppingCart(AppDbContext context)
        {
            _context= context;
        }
        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            // ?? - if ShoppingCartItems == null
            return ShoppingCartItems ?? (ShoppingCartItems = _context.ShoppingCartItems
                                        .Where(n => n.ShoppingCartId == ShoppingCartId)
                                        .Include(n => n.Movie).ToList());
        }
        public double GetShoppingCartTotal() => _context.ShoppingCartItems
                                                .Where(n => n.ShoppingCartId == ShoppingCartId)
                                                .Select(n => n.Movie.Price * n.Amount).Sum();        
    }
}
