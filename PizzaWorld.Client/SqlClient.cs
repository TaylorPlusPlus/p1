using System.Collections.Generic;
using System.Linq;
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
            var s = ReadOneStore(store.Name);
            return s.Orders;
        }

        public Store ReadOneStore(string name)
        {
            return _db.Store.FirstOrDefault(s => s.Name == name);
        }        
        public void SaveStore(Store store)
        {
            _db.Add(store); // git add
            _db.SaveChanges(); // git commit
        }

        public void SaveOrder(Store store, User user, Order order)
        {
                //NEED TO MAKE SURE THIS ONLY UPDATES IF IT IS ALREADY IN THE DATABASE!!!!
                _db.Store.FirstOrDefault(s => s == store).Orders.Add(order);
                _db.Users.FirstOrDefault(s => s.Username == user.Username).Orders.Add(order);
                //_db.Store.Find(store).Orders.Add(order);
               // _db.Users.Find(user).Orders.Add(order);
       //     _db.Add(user);
      //      _db.Add(store);
              _db.SaveChanges();
        }

        public void Update(Store store)
        {
            _db.SaveChanges();
        }

    }
}