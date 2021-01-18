using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using PizzaWorld.Domain.Models;

namespace PizzaBox.WebClient.Models
{
  public class CustomerViewModel
  {
    public string Name { get; set; }
    public OrderViewModel Order { get; set; }
    public List<Order> OrderHistory {get; set;}
    public string ErrorMessage {get;set;}

    public CustomerViewModel()
    {
      Name = "fred";
      Order = new OrderViewModel();
      OrderHistory = new List<Order>();
    }
  }
}
