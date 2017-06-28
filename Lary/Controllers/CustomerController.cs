using Lary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Lary.ViewModel.Customer;

namespace Lary.Controllers
{
    public class CustomerController : Controller
    {
        LaryDbContext _db = new LaryDbContext();
        public ActionResult Index(int? page = 1)
        {
            var model = _db.Customer.Where(p => p.IsDelete != true).ToList();
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
        public ActionResult Create(CreateCustomerViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Error", "Error! Please try again!");
                return View(model);
            }

            Customer customer = new Customer() {
                CustomerCode = model.CustomerCode,
                CustomerName = model.CustomerName,
                Phone = model.Phone,
                Address = model.Address,
                DateOfBirth = model.DateOfBirth,
                Referral = model.Referral,
                CustomerTypeId = model.CustomerTypeId,
                DistrictId = model.DistrictId
            };

            try
            {

                _db.Customer.Add(customer);
                _db.SaveChanges();
            }
            catch
            {
                ModelState.AddModelError("Error", "Error! Please try again!");
                return View(model);
            }
            return RedirectToAction("Index");
        }

    }
}