using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ToDoList.Controllers
{
  public class CategoriesController : Controller
  {
    private readonly ToDoListContext _db;

    public CategoriesController(ToDoListContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Category> model = _db.Categories.ToList();
      return View(model);
    }
    public ActionResult Create()
    {
      return View();
    }
    [HttpPost]
    public ActionResult Create(Category category)
    {
      _db.Categories.Add(category);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Category thisCategory = _db.Categories
                                .Include(cat => cat.Items)
                                .ThenInclude(item => item.JoinEntities)
                                .ThenInclude(join => join.Tag)
                                .FirstOrDefault(category => category.CategoryId == id);
      return View(thisCategory);
    }

    public ActionResult Edit(int id)
    {
      Category foundCategory = _db.Categories.FirstOrDefault(category => category.CategoryId == id);
      return View(foundCategory);
    }
    [HttpPost]
    public ActionResult Edit(Category category)
    {
      _db.Categories.Update(category);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Delete(int id)
    {
      Category foundCategory = _db.Categories.FirstOrDefault(category => category.CategoryId == id);
      return View(foundCategory);
    }
    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirm(int id)
    {
      Category foundCategory = _db.Categories.FirstOrDefault(category => category.CategoryId == id);
      _db.Categories.Remove(foundCategory);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}