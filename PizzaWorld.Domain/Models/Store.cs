using System.Collections.Generic;
using System;
using PizzaWorld.Domain.Abstracts;

namespace PizzaWorld.Domain.Models
{
    public class Store : AEntity
    {
        public List<Order> Orders {get; set;}
        public string Name {get; set;}

     //   public int StoreId{get; set;}
        
        public Store()
        {
            Orders = new List<Order>();
        }
        public void CreateOrder()
        {
        //    Orders.Add(new Order());
            
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

        public override string ToString()
        {
            return $"{Name}";
        }
        //Calculate Revenue

    }
}