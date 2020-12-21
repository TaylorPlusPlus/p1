using System.Collections.Generic;
using System;

namespace PizzaWorld.Domain.Models
{
    public class Store
    {
        public List<Order> Orders {get; set;}
        
        public void CreateOrder()
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

        public void PrintAllOrders()
        {
            foreach(Order order in Orders)
            {
                Console.WriteLine(order);

            }
        }

        //Calculate Revenue

    }
}