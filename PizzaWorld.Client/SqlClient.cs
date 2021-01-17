using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PizzaWorld.Domain.Abstracts;
using PizzaWorld.Domain.Models;
using PizzaWorld.Storage;

namespace PizzaWorld.Client
{
    public class SqlClient
    {
        private readonly PizzaWorldContext _db = new PizzaWorldContext();
 
        public SqlClient()
        {
           
        }
        
        public IEnumerable<Store> ReadStores()
        {
            return _db.Store;
        }

        // call this in user experience to set user
        public User ReadOneUser(string name)
        {
            return _db.Users.FirstOrDefault(s => s.Username == name);
        }        

         public User ReadOneStore(string name)
        {
            return _db.Store.FirstOrDefault(s => s.Username == name);
        } 
        public void SaveOrder(Store store, User user, Order order)
        {
            //NEED TO MAKE SURE THIS ONLY UPDATES IF IT IS ALREADY IN THE DATABASE!!!!
            _db.Store.FirstOrDefault(s => s.Name == store.Name).Orders.Add(order);
            _db.Users.FirstOrDefault(s => s.Username == user.Username).Orders.Add(order);

            _db.SaveChanges();
        }

        

        public User UserOrderHistory(User user)
        {
            var u = _db.Users
                        .Include(u => u.Orders)
                        .ThenInclude(o => o.Pizzas)
                        .ThenInclude(p => p.Toppings)
                        .Include(u => u.Orders)
                        .ThenInclude(o => o.Pizzas)
                        .ThenInclude(p => p.Crust)
                        .Include(u => u.Orders)
                        .ThenInclude(u => u.Store)
                        .FirstOrDefault( u => u.EntityId == user.EntityId);
            return u; 
        }
         public Store StoreOrderHistory(Store store)
        {
            var u = _db.Store
                        .Include(u => u.Orders)
                        .ThenInclude(o => o.Pizzas)
                        .ThenInclude(p => p.Toppings)
                        .Include(u => u.Orders)
                        .ThenInclude(o => o.Pizzas)
                        .ThenInclude(p => p.Crust)
                        .Include(u => u.Orders)
                        .ThenInclude(u => u.User)
                        .FirstOrDefault( u => u.EntityId == store.EntityId);
            return u; 
        }
    }
}
