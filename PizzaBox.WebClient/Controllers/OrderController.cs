using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PizzaWorld.Storage;
using PizzaBox.WebClient.Models;
using PizzaWorld.Domain.Models;

namespace PizzaBox.WebClient.Controllers
{
  public class OrderController : Controller
  {
    private readonly PizzaWorldContext _ctx;
    public OrderController(PizzaWorldContext context)
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
        order.PurchaseDate = DateTime.Now;
        order.Store = _ctx.Store.FirstOrDefault(s => s.Name == model.Store);
        

        _ctx.Order.Add(order);
        _ctx.SaveChanges();

        return View("SuccessfulOrder", model);
      }

      return View("home", model);
    }
  }
}
