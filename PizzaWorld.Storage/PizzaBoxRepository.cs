using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PizzaWorld.Domain.Abstracts;
using PizzaWorld.Domain.Models;
using PizzaWorld.Storage;


namespace PizzaWorld.Storage
{  public class PizzaBoxRepository
  {
    private PizzaWorldContext _db;

    public PizzaBoxRepository(PizzaWorldContext context)
    {
      _db = context;
    }

    public List<string> GetStores()
    {
      return _db.Store.Select(s => s.Name).ToList();
    }

    // public IEnumerable<T> Get<T>() where T : AModel
    // {
    //   return _ctx.Set<T>().Select(t => t.GetType().GetProperty()).ToList();
    // }

        public IEnumerable<Store> ReadStores()
        {
            return _db.Store;
        }

        // call this in user experience to set user
        public User ReadOneUser(string name)
        {
            return _db.Users.FirstOrDefault(s => s.Username == name);
        }        

      public Store ReadOneStore(string name)
        {
            return _db.Store.FirstOrDefault(s => s.Name == name);
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
