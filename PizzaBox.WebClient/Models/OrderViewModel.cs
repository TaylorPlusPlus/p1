using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.Extensions.Configuration;
using PizzaWorld.Domain.Models;
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

    public List<string> SelectedSizes {get;set;}

    public List<string> Sizes {get;set;}

    public List<PizzaViewModel> TempPizzas{get;set;}

    public Order ViewOfOrder {get; set;}

    public int RemoveIndex {get;set;}

    public decimal OrderPrice {get; set;}

    public string ErrorMessage {get;set;}

    public OrderViewModel()
    {
      Pizzas = new List<string>();
      Pizzas.Add("Hawaiian");
      Pizzas.Add("Greek");
      Pizzas.Add("Meat");
      SelectedPizzas = new List<string>();
      SelectedSizes = new List<string>();
      Sizes = new List<string>();
      Sizes.Add("Large");
      Sizes.Add("Small");

    }
    
  }
}
