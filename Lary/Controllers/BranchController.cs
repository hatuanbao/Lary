using Lary.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lary.ViewModel.Branch;

namespace Lary.Controllers
{
    public class BranchController : Controller
    {
        LaryDbContext _db = new LaryDbContext();

        public ActionResult Index(int? page = 1)
        {
            var model = _db.Branch.Where(p => p.IsDelete != true).ToList();
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
        public ActionResult Create(CreateBranchViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Error", "Error! Please try again!");
                return View(model);
            }

            Branch branch = new Branch()
            {
                Name = model.BranchName
            };

            _db.Branch.Add(branch);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Detail(long? id)
        {
            var branch = _db.Branch.FirstOrDefault(p => p.Id == id);
            if (branch == null)
                return Redirect("Index");

            CreateBranchViewModel model = new CreateBranchViewModel()
            {
                BranchName = branch.Name
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Detail(long? id, CreateBranchViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Error", "Error! Please try again!");
                return View(model);
            }

            var branch = _db.Branch.FirstOrDefault(p => p.Id == id);
            if (branch == null)
                return Redirect("Index");

            branch.Name = model.BranchName;

            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(long? id)
        {
            var branch = _db.Branch.Where(p => p.IsDelete != true).FirstOrDefault(p => p.Id == id);
            if (branch == null)
            {
                return RedirectToAction("Index");
            }

            branch.IsDelete = true;
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