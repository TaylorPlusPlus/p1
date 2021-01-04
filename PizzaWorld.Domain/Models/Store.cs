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

        public bool CheckIfOrderPlacedWithinWeek(Order order)
        {
          if((DateTime.Now - order.PurchaseDate).TotalDays < 7)
          {
            return true;
          }
          return false;
        }
    }
}