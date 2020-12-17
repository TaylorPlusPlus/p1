using System.Collections.Generic;

namespace PizzaWorld.Domain.Models
{
    public class Store
    {
        public List<Order> Orders {get; set;}
        
        void CreateOrder()
        {
            Orders.Add(new Order());
        }
        bool DeleteOrder(Order Order)
        {
            try
            {
                Orders.Remove(Order);
                return true;
            }catch{
                return false;
            }
        }
    }
}