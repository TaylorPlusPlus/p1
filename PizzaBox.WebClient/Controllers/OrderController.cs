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
    GenericPizzaFactory factory = new GenericPizzaFactory();
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

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult AddingToOrderPut(OrderViewModel model)
    {
      

        return View("SuccessfulOrder", model);
      
    }
    [HttpGet]
    public IActionResult AddingToOrderGet(OrderViewModel model)
    {

      return View("",model);
    }

    [HttpGet]
    public IActionResult SelectAStore()
    {
      OrderViewModel model = new OrderViewModel();
      model.Stores = _ctx.GetStores();
      return View("SelectAStore", model);
    }

    [HttpPost]
    public IActionResult ModifyOrder(OrderViewModel model)
    {
     
     Order currentOrder = new Order();

     for(int i = 0; i < model.SelectedPizzas.Count(); i ++)
     {
       string pizza = model.SelectedPizzas.ElementAt(i);
       string size = model.SelectedSizes.ElementAt(i);
        
        
          if(pizza.Equals("Hawaiian"))
          {
            currentOrder.Pizzas.Add(factory.Make<HawaiianPizza>());
          }
          if(pizza.Equals("Meat"))
          {
            currentOrder.Pizzas.Add(factory.Make<MeatPizza>());
          }
          if(pizza.Equals("Greek"))
          {
            currentOrder.Pizzas.Add(factory.Make<GreekPizza>());
          }
          if(size == "Large")
        {
          currentOrder.Pizzas.Last().MakeLarge();
        }
     }
     model.ViewOfOrder = currentOrder;

      return View("ModifyOrder", model);
    }

    [HttpPost]
    public IActionResult AddPizza(OrderViewModel model)
    {
      
      return View("AddPizza", model);
    }

    [HttpPost]
    public IActionResult RemovePizza(OrderViewModel model)
    {
      Console.WriteLine(model.RemoveIndex);
      model.SelectedPizzas.RemoveAt(model.RemoveIndex);
      model.SelectedSizes.RemoveAt(model.RemoveIndex);

      Order currentOrder = new Order();

      for(int i = 0; i < model.SelectedPizzas.Count(); i ++)
     {
       string pizza = model.SelectedPizzas.ElementAt(i);
       string size = model.SelectedSizes.ElementAt(i);
        
        
          if(pizza.Equals("Hawaiian"))
          {
            currentOrder.Pizzas.Add(factory.Make<HawaiianPizza>());
          }
          if(pizza.Equals("Meat"))
          {
            currentOrder.Pizzas.Add(factory.Make<MeatPizza>());
          }
          if(pizza.Equals("Greek"))
          {
            currentOrder.Pizzas.Add(factory.Make<GreekPizza>());
          }
          if(size == "Large")
        {
          currentOrder.Pizzas.Last().MakeLarge();
        }
     }
     model.ViewOfOrder = currentOrder;

      return View("ModifyOrder", model);
    }



    [HttpPost]
    public IActionResult CompleteOrder(OrderViewModel model)
    {

      Order currentOrder = new Order();
      
     for(int i = 0; i < model.SelectedPizzas.Count(); i ++)
     {
       string pizza = model.SelectedPizzas.ElementAt(i);
       string size = model.SelectedSizes.ElementAt(i);
        
        
          if(pizza.Equals("Hawaiian"))
          {
            currentOrder.Pizzas.Add(factory.Make<HawaiianPizza>());
          }
          if(pizza.Equals("Meat"))
          {
            currentOrder.Pizzas.Add(factory.Make<MeatPizza>());
          }
          if(pizza.Equals("Greek"))
          {
            currentOrder.Pizzas.Add(factory.Make<GreekPizza>());
          }
          if(size == "Large")
        {
          currentOrder.Pizzas.Last().MakeLarge();
        }
     }



      Console.WriteLine(currentOrder.ToString());
      if(currentOrder.Pizzas.Count() > 1)
      {
      _ctx.SaveOrder(_ctx.ReadOneStore(model.Store),_ctx.ReadOneUser("first"), currentOrder);
      }
      return View("SuccessfulOrder");
    }
  }
}