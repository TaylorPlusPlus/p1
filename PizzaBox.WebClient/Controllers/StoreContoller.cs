using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PizzaBox.WebClient.Models;
using PizzaWorld.Domain.Models;
using PizzaWorld.Storage;

namespace PizzaBox.WebClient.Controllers
{
  public class StoreController : Controller
  {
    private readonly PizzaBoxRepository _ctx;
    public StoreController(PizzaBoxRepository context)
    {
      _ctx = context;
    }

    [HttpGet]
    public IActionResult StoreHome(StoreViewModel model)
    {
      return View("StoreHome", model);
    }
    
     [HttpPost]
    public IActionResult StoreSelection(StoreViewModel model)
    {
      return View("StoreHome", model);
    }

    [HttpGet]
    public IActionResult ToStoreSelection(StoreViewModel model)
    {
        model.Stores = _ctx.GetStores();
        return View("StoreSelection", model);
    }

    [HttpGet]
    public IActionResult HistorySelection(StoreViewModel model)
    {
      return View("HistorySelection", model);
    }
    [HttpPost]
    public IActionResult HistoryByUsername(StoreViewModel model)
    {
      Store store = _ctx.ReadOneStore(model.Name);
      store = _ctx.StoreOrderHistory(store);
    //  model.OrderHistory = store.ListOrderHistoryByUsername(model.Username);
      model.ListofOrders = store.ListofOrdersByUsername(model.Username);

      return View("HistoryByUsername", model);
    }
    [HttpGet]
    public IActionResult HistoryByAll(StoreViewModel model)
    {
      Store store = _ctx.ReadOneStore(model.Name);
      store = _ctx.StoreOrderHistory(store);
      model.OrderHistory = store.ListOrderHistory();
      model.ListofOrders = store.Orders;

      return View("HistoryByAll", model);
    }

    [HttpGet]
    public IActionResult SalesSelection(StoreViewModel model)
    {
      Store store = _ctx.ReadOneStore(model.Name);
      store = _ctx.StoreOrderHistory(store);
      model.OrderHistory = store.SalesLoop();
      model.MonthSales = store.SalesLoopMonth();
      
      return View("SalesSelection", model);
    }


  }
}
