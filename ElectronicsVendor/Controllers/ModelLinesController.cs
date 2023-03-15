
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
  }
}