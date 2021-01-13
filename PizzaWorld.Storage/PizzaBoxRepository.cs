using System.Collections.Generic;
using System.Linq;
using PizzaWorld.Domain.Abstracts;
using PizzaWorld.Storage;


namespace PizzaWorld.Storage
{  public class PizzaBoxRepository
  {
    private PizzaWorldContext _ctx;

    public PizzaBoxRepository(PizzaWorldContext context)
    {
      _ctx = context;
    }

    public List<string> GetStores()
    {
      return _ctx.Store.Select(s => s.Name).ToList();
    }

    // public IEnumerable<T> Get<T>() where T : AModel
    // {
    //   return _ctx.Set<T>().Select(t => t.GetType().GetProperty()).ToList();
    // }
  }
}
