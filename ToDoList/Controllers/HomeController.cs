using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using System.Collections.Generic;
using System.Linq;

namespace ToDoList.Controllers
{
  public class HomeController : Controller
  {
    private readonly ToDoListContext _db;

    public HomeController(ToDoListContext db) // ToDoListContext is just a connection to our db
    {
      _db = db;
    }
    [HttpGet("/")]
    public ActionResult Index()
    {
      Category[] cats = _db.Categories.ToArray();
      Item[] items = _db.Items.ToArray();
      Dictionary<string, object[]> model = new Dictionary<string, object[]>();
      model.Add("categories", cats);
      model.Add("items", items);
      return View(model);

      // This is another option we can do.
      // List<Category> cats = _db.Categories.ToList();
      // List<Item> items = _db.Items.ToList();
      // ViewBag.categories = cats;
      // ViewBag.items = items;
      // return View();
    }
    [HttpGet("/favorite_photos")]
    public ActionResult FavoritePhotos()
    {
      return View();
    }
  }
}