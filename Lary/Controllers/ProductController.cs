using Lary.Models;
using Lary.ViewModel.Product;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lary.Controllers
{
    public class ProductController : BaseController 
    {
        LaryDbContext _db = new LaryDbContext();
        // GET: Product
        public ActionResult Index(int? page = 1)
        {
            var model = _db.Item.Where(p => p.IsDelete != true).ToList();
            int pageSize = 50;
            int pageNumber = (page ?? 1);
            return View(model.ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CreateItemViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Error","Error! Please try again!");
                return View(model);
            }

            Item item = new Item()
            {
                Name = model.Name,
                Input = model.Input,
                Output = model.Output,
                CalculationUnit = model.CalculationUnit,
                Price = model.Price
            };

            _db.Item.Add(item);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Detail(long? id)
        {
            var item = _db.Item.FirstOrDefault(p => p.Id == id);
            if (item == null)
                return Redirect("Index");

            CreateItemViewModel model = new CreateItemViewModel()
            {
                Name = item.Name,
                Input = item.Input,
                Output = item.Output,
                CalculationUnit = item.CalculationUnit,
                Price = item.Price
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Detail(long? id, CreateItemViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Error", "Error! Please try again!");
                return View(model);
            }

            var item = _db.Item.FirstOrDefault(p => p.Id == id);
            if(item == null)
                return Redirect("Index");

            item.Name = model.Name;
            item.Input = model.Input;
            item.Output = model.Output;
            item.CalculationUnit = model.CalculationUnit;
            item.Price = model.Price;
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(long? id)
        {
            var item = _db.Item.Where(p => p.IsDelete != true).FirstOrDefault(p => p.Id == id);
            if (item == null)
            {
                return RedirectToAction("Index");
            }

            item.IsDelete = true;
            try
            {
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }
    }
}