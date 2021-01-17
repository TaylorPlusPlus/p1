using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PizzaBox.WebClient.Models;
using PizzaWorld.Domain.Models;
using PizzaWorld.Storage;

namespace PizzaBox.WebClient.Controllers
{
  public class HomeController : Controller
  {
    private readonly PizzaBoxRepository _ctx;

    public HomeController(PizzaBoxRepository context)
    {
      _ctx = context;
    }

    [HttpGet]
    public IActionResult Selection()
    {
     return View("RoleSelection");
    }
 
  }
}
