using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.Extensions.Configuration;
using PizzaWorld.Storage;

namespace PizzaBox.WebClient.Models
{
  public class OrderViewModel
  {
    public List<string> Stores { get; set; }

    [Required]
    public string Store { get; set; }

    public List<string> Pizzas {get; set;}

    public List<string> SelectedPizzas {get; set;}

    public OrderViewModel()
    {
      Pizzas = new List<string>();
      Pizzas.Add("Hawaiian");
      Pizzas.Add("Greek");
      Pizzas.Add("Meat");
      SelectedPizzas = new List<string>();
    }
    
  }
}
