using Estates2.Models;
using Estates2.Models.DbModels;
using Estates2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Estates2.Controllers
{
    public class EstateController : Controller
    {
        // GET: Estate
        public ActionResult Index()
        {
            return View();
        }
        //create
        [HttpGet]
        public ActionResult Create()
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                return View(new EstateVM
                {
                    AllOwners = db.Owners.ToList().Select(o => OwnerVM.FromDbModel(o)).ToList()
                });
            }
        }

        [HttpPost]
        public ActionResult Create(EstateVM vm)
        {
            if (ModelState.IsValid)
            {
                using (DatabaseContext db = new DatabaseContext())
                {
                    var estate = EstateVM.ToDbModel(vm);
                    db.Estates.Add(estate);
                    db.SaveChanges();
                }
                return RedirectToAction("ViewAll");
            }
            using (DatabaseContext db = new DatabaseContext())
            {
                vm.AllOwners = db.Owners.ToList().Select(o => OwnerVM.FromDbModel(o)).ToList();
            }
            return View(vm);
        }

        //read
        [HttpGet]
        public ActionResult ViewAll()
        {
            List<EstateVM> estates;
            using (DatabaseContext db = new DatabaseContext())
                estates = db.Estates.ToList().Select(x => EstateVM.FromDbModel(x)).ToList();
            return View(estates);
        }
        //details
        public ActionResult View(int id)
        {
            Estate estate;
            using (DatabaseContext db = new DatabaseContext())
            {
                estate = db.Estates.FirstOrDefault(x => x.Id == id);

                if (estate == null)
                {
                    return HttpNotFound();
                }
                return View(EstateVM.FromDbModel(estate));
            }
        }
        //update
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Estate estate;
            using (DatabaseContext db = new DatabaseContext())
            {
                estate = db.Estates.FirstOrDefault(x => x.Id == id);
                var AllOwners = db.Owners.ToList().Select(o => OwnerVM.FromDbModel(o)).ToList();
                if (estate == null)
                {
                    return HttpNotFound();
                }
                return View(EstateVM.FromDbModel(estate, AllOwners));
            }
        }

        [HttpPost]
        public ActionResult Edit(EstateVM vm)
        {
            if (ModelState.IsValid)
            {
                using (DatabaseContext db = new DatabaseContext())
                {
                    var estate = db.Estates.FirstOrDefault(x => x.Id == vm.Id);
                    estate.Adress = vm.Adress;
                    estate.ZipCode = vm.ZipCode;
                    estate.City = vm.City;
                    estate.Price = vm.Price;
                    estate.Area = vm.Area;
                    estate.Furniture = vm.Furniture;
                    estate.Balcony = vm.Balcony;
                    estate.RoomsNumber = vm.RoomsNumber;
                    estate.Description = vm.Description;
                    estate.Bedrooms = vm.Bedrooms;
                    estate.OwnerId = vm.SelectedOwnerId;
                    db.SaveChanges();
                }
                return RedirectToAction("ViewAll");
            }
            using (DatabaseContext db = new DatabaseContext())
            {
                vm.AllOwners = db.Owners.ToList().Select(o => OwnerVM.FromDbModel(o)).ToList();
            }
            return View(vm);
        }
        //delete
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            Estate estate;
            using (DatabaseContext db = new DatabaseContext())
            {
                estate = db.Estates.FirstOrDefault(x => x.Id == id);
                if (estate == null)
                {
                    return HttpNotFound();
                }
                return View(EstateVM.FromDbModel(estate));
            }
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int? id)
        {
            Estate estate;
            using (DatabaseContext db = new DatabaseContext())
            {
                estate = db.Estates.FirstOrDefault(x => x.Id == id);
                db.Estates.Remove(estate);
                db.SaveChanges();
                if (estate == null)
                {
                    return HttpNotFound();
                }
            }
            return RedirectToAction("ViewAll");
        }
    }
}