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
      User user = _ctx.ReadOneUser("First");
      user = _ctx.UserOrderHistory(user);
      /*
      if(user.HoursSinceLastOrder() < 2)
      {
        
        return RedirectToAction("RedirectHome", "Customer");
       
      }
      */
     
      OrderViewModel model = new OrderViewModel();
      model.Stores = _ctx.GetStores();
      return View("SelectAStore", model);
    }
  
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult ModifyOrder(OrderViewModel model)
    {
     User user = _ctx.ReadOneUser("First");

      user = _ctx.UserOrderHistory(user);
      user.SelectedStore = _ctx.ReadOneStore(model.Store);
      Order currentOrder = new Order();
    
      if(user.OrderedFromThisStoreWithin24hr())
      {
        
        return RedirectToAction("RedirectHomeStoreSelection", "Customer");
       
      }
      
     

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
     model.OrderPrice = currentOrder.CalculatePrice();
     if(model.OrderPrice > 250m){
       model.ErrorMessage = "Pizza Removed from order. Order can not be valued over $250.00";
        currentOrder.Pizzas.RemoveAt(0);
       model.SelectedPizzas.RemoveAt(0);
     }
     if(model.Pizzas.Count > 50){
       model.ErrorMessage = "Pizza Removed from order. Each order is limited to 50 pizzas";
       model.SelectedPizzas.RemoveAt(0);
        currentOrder.Pizzas.RemoveAt(0);
     }
     model.ViewOfOrder = currentOrder;
     model.OrderPrice = currentOrder.CalculatePrice();

      return View("ModifyOrder", model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult AddPizza(OrderViewModel model)
    {
      
      return View("AddPizza", model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
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

        model.OrderPrice = currentOrder.CalculatePrice();
     if(model.OrderPrice > 250m){
       model.ErrorMessage = "Pizza Removed from order. Order can not be valued over $250.00";
        currentOrder.Pizzas.RemoveAt(0);
       model.SelectedPizzas.RemoveAt(0);
     }
     if(model.Pizzas.Count > 50){
       model.ErrorMessage = "Pizza Removed from order. Each order is limited to 50 pizzas";
       model.SelectedPizzas.RemoveAt(0);
        currentOrder.Pizzas.RemoveAt(0);
     }
     model.ViewOfOrder = currentOrder;
     model.OrderPrice = currentOrder.CalculatePrice();

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

      currentOrder.PurchaseDate = DateTime.Now;
      
      _ctx.SaveOrder(_ctx.ReadOneStore(model.Store),_ctx.ReadOneUser("First"), currentOrder);
      
      return View("SuccessfulOrder");
  }
}
}