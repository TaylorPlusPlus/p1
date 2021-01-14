using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PizzaWorld.Storage;
using PizzaBox.WebClient.Models;
using PizzaWorld.Domain.Models;
using PizzaWorld.Domain.Factories;

namespace PizzaBox.WebClient.Controllers
{
  public class OrderController : Controller
  {
    private readonly PizzaBoxRepository _ctx;
    public OrderController(PizzaBoxRepository context)
    {
      _ctx = context;
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Post(OrderViewModel model)
    {
      if (ModelState.IsValid)
      {
        GenericPizzaFactory factory = new GenericPizzaFactory();

        var order = new Order();
        User user = new User();
        order.Store = _ctx.ReadOneStore(model.Store);
        user = _ctx.ReadOneUser("first");
        user.SelectedStore = order.Store;
        order.User = user;
        
        order.PurchaseDate = DateTime.Now;
        order.Store = _ctx.ReadOneStore(model.Store);
        Console.WriteLine(model.Store + ": Model + Selected Pizzas = " + model.SelectedPizzas.Last());

        foreach(string pizza in model.SelectedPizzas)
        {
          if(pizza.Equals("Hawaiian"))
          {
            order.Pizzas.Add(factory.Make<HawaiianPizza>());
          }
          if(pizza.Equals("Meat"))
          {
            order.Pizzas.Add(factory.Make<MeatPizza>());
          }
          if(pizza.Equals("Greek"))
          {
            order.Pizzas.Add(factory.Make<GreekPizza>());
          }
        
        }

        _ctx.SaveOrder(order.Store, order.User, order);
        _ctx.Update();

        return View("SuccessfulOrder", model);
      }

      return View("home", model);
    }
  }
}
