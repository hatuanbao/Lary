using Lary.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lary.ViewModel.Staff;

namespace Lary.Controllers
{
    public class StaffController : Controller
    {
        LaryDbContext _db = new LaryDbContext();
        
        public ActionResult Index(int? page = 1)
        {
            var model = _db.Staff.Where(p => p.IsDelete != true).ToList();
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
        public ActionResult Create(CreateStaffViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Error", "Error! Please try again!");
                return View(model);
            }

            Staff staff = new Staff()
            {
                StaffName = model.StaffName
            };

            _db.Staff.Add(staff);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Detail(long? id)
        {
            var staff = _db.Staff.FirstOrDefault(p => p.Id == id);
            if (staff == null)
                return Redirect("Index");

            CreateStaffViewModel model = new CreateStaffViewModel()
            {
                StaffName = staff.StaffName
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Detail(long? id, CreateStaffViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Error", "Error! Please try again!");
                return View(model);
            }

            var staff = _db.Staff.FirstOrDefault(p => p.Id == id);
            if (staff == null)
                return Redirect("Index");

            staff.StaffName = model.StaffName;
           
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(long? id)
        {
            var staff = _db.Staff.Where(p => p.IsDelete != true).FirstOrDefault(p => p.Id == id);
            if (staff == null)
            {
                return RedirectToAction("Index");
            }

            staff.IsDelete = true;
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