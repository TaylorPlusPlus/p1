using System.Collections.Generic;

namespace PizzaBox.WebClient.Models
{
    public class StoreViewModel 
    {
        public string Name {get;set;}
        public List<string> Stores{get;set;}

        public string Username {get;set;}

        public string OrderHistory{get;set;}

        public string MonthSales{get;set;}
    }
}