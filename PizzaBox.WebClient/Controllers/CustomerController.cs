using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PizzaBox.WebClient.Models;
using PizzaWorld.Domain.Models;
using PizzaWorld.Storage;

namespace PizzaBox.WebClient.Controllers
{
  public class CustomerController : Controller
  {
    private readonly PizzaBoxRepository _ctx;
    public CustomerController(PizzaBoxRepository context)
    {
      _ctx = context;
    }

    [HttpGet]
    public IActionResult Home()
    {
      User user = _ctx.ReadOneUser("first");
      user = _ctx.UserOrderHistory(user);

      var customer = new CustomerViewModel();
      customer.Order = new OrderViewModel()
      {
        Stores = _ctx.GetStores()
      };
      customer.OrderHistory = user.Orders;
      
      return View("home", customer);
    }
   
    [HttpGet]
    public IActionResult RedirectHome()
    {
      User user = _ctx.ReadOneUser("first");
      user = _ctx.UserOrderHistory(user);

      var customer = new CustomerViewModel();
      customer.Order = new OrderViewModel()
      {
        Stores = _ctx.GetStores()
      };
      customer.OrderHistory = user.Orders;
      customer.ErrorMessage = "Orders can not occur more than once every two hours!";
      return View("home", customer);
    }



    [HttpGet]
    public IActionResult RedirectHomeStoreSelection()
    {
      User user = _ctx.ReadOneUser("first");
      user = _ctx.UserOrderHistory(user);

      var customer = new CustomerViewModel();
      customer.Order = new OrderViewModel()
      {
        Stores = _ctx.GetStores()
      };
      customer.OrderHistory = user.Orders;
      customer.ErrorMessage = "You can't order from that store more than once in a 24 hour period!";
      return View("home", customer);
    }
  }
}
