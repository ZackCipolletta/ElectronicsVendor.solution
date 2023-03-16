
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using ElectronicsVendor.Models;
using System.Collections.Generic;
using System.Linq;

namespace ElectronicsVendor.Controllers
{
  public class ModelLinesController : Controller
  {
    private readonly ElectronicsVendorContext _db;
      public ModelLinesController(ElectronicsVendorContext db)
    {
      _db = db;
    }

    public ActionResult Create(int id)
    {
      ViewBag.Component = _db.Components
                          .FirstOrDefault(component => component.ComponentId == id);
      return View();
    }

    [HttpPost]
    public ActionResult Create(ModelLine modelLine, int id)
    {
      if (id == 0)
      {
        return RedirectToAction("Create");
      }
      modelLine.ComponentId = id;
      _db.ModelLines.Add(modelLine);
      _db.SaveChanges();
      return RedirectToAction("Details", "Components", new { id = id });
    }

        public ActionResult Details(int id)
    {
      ModelLine thisModelLine = _db.ModelLines
            .Include(modelLine => modelLine.Component)
            .ThenInclude(component => component.JoinEntities)
            .ThenInclude(join => join.Vendor)
            .FirstOrDefault(modelLine => modelLine.ModelLineId == id);
      return View(thisModelLine);
    }

        public ActionResult Edit(int id)
    {
      ModelLine thisModelLine = _db.ModelLines
            .Include(modelLine => modelLine.Component)
            .FirstOrDefault(modelLine => modelLine.ModelLineId == id);
      return View(thisModelLine);
    }

    [HttpPost]
    public ActionResult Edit(ModelLine modelLine, int id)
    {
      _db.ModelLines.Update(modelLine);
      _db.SaveChanges();
      return RedirectToAction("Details", new {id = id});
    }
  }
}