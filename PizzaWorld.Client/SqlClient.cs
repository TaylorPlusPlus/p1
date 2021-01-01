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

        public IEnumerable<Order> ReadOrders(Store store)
        {
           // var s = ReadOneStore(store.Name);
            //return s.Orders;
            return  _db.Store
                .Where(u => u.Name == store.Name)
                .SelectMany(u => u.Orders);
        }

        //Test this
        public IEnumerable<Order> ReadOrders(User user)
        {    
            _db.SaveChanges();
        
              return  _db.Users
                .Where(u => u.Username == user.Username)
                .SelectMany(u => u.Orders);
        }
        public IEnumerable<APizzaModel> ReadPizzas(Order order)
        {
            return _db.Order
                .Where(u => u.EntityId == order.EntityId)
                .SelectMany(u => u.Pizzas);
        }
        public IEnumerable<AToppingModel> ReadToppings(APizzaModel pizza)
        {
            return _db.Pizzas
                .Where(u => u.EntityId == pizza.EntityId)
                .SelectMany(u => u.Toppings);
                
        }
        public IEnumerable<ACrustModel> ReadCrust(APizzaModel pizza)
        {
            return _db.Pizzas
                .Where(u => u.EntityId == pizza.EntityId).Select(u => u.Crust);
        }

        public Store ReadOneStore(string name)
        {
            return _db.Store.FirstOrDefault(s => s.Name == name);
        }


        // call this in user experience to set user
        public User ReadOneUser(string name)
        {
            return _db.Users.FirstOrDefault(s => s.Username == name);
        }        
        public void SaveStore(Store store)
        {
            _db.Add(store); // git add
            _db.SaveChanges(); // git commit
        }

        public void SaveOrder(Store store, User user, Order order)
        {
                //NEED TO MAKE SURE THIS ONLY UPDATES IF IT IS ALREADY IN THE DATABASE!!!!
                _db.Store.FirstOrDefault(s => s.Name == store.Name).Orders.Add(order);
                _db.Users.FirstOrDefault(s => s.Username == user.Username).Orders.Add(order);

              _db.SaveChanges();
        }

        public void Update()
        {
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
                        .FirstOrDefault( u => u.EntityId == user.EntityId);
            var o = u.Orders.LastOrDefault();
    
            return u; 
        }

    }
}