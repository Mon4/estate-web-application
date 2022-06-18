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
    public class OwnerController : Controller
    {
        // GET: Owner
        public ActionResult Index()
        {
            return View();
        }

        //create
        [HttpGet]
        public ActionResult Create()
        {
            return View(new OwnerVM());
        }

        [HttpPost]
        public ActionResult Create(OwnerVM ownerVM)
        {
            if (ModelState.IsValid)
            {
                using (DatabaseContext db = new DatabaseContext())
                {
                    var owner = OwnerVM.ToDbModel(ownerVM);
                    db.Owners.Add(owner);
                    db.SaveChanges();
                }
                return RedirectToAction("ViewAll");
            }
            return View(new OwnerVM());
        }

        //read
        [HttpGet]
        public ActionResult ViewAll()
        {
            List<OwnerVM> owners;
            using (DatabaseContext db = new DatabaseContext())
                owners = db.Owners.ToList().Select(x => OwnerVM.FromDbModel(x)).ToList();
            return View(owners);

        }
        //details
        public ActionResult View(int id)
        {
            Owner owner;
            using (DatabaseContext db = new DatabaseContext())
                owner = db.Owners.FirstOrDefault(x => x.Id == id);
            if (owner == null)
            {
                return HttpNotFound();
            }
            return View(OwnerVM.FromDbModel(owner));
        }
        //update
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Owner owner;
            using (DatabaseContext db = new DatabaseContext())
                owner = db.Owners.FirstOrDefault(x => x.Id == id);
            if (owner == null)
            {
                return HttpNotFound();
            }
            return View(OwnerVM.FromDbModel(owner));
        }

        [HttpPost]
        public ActionResult Edit(OwnerVM vm)
        {
            if (!ModelState.IsValid)
                return View(vm);
            using (DatabaseContext db = new DatabaseContext())
            {

                var owner = db.Owners.FirstOrDefault(x => x.Id == vm.Id);
                owner.Name = vm.Name;
                owner.Adress = vm.Adress;
                owner.PhoneNumber = vm.PhoneNumber;
                owner.ZipCode = vm.ZipCode;
                owner.City = vm.City;
                db.SaveChanges();
            }
            return RedirectToAction("ViewAll");
        }
        //delete
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            Owner owner;
            using (DatabaseContext db = new DatabaseContext())
            {
                owner = db.Owners.FirstOrDefault(x => x.Id == id);
            }
            if (owner == null)
            {
                return HttpNotFound();
            }
            return View(OwnerVM.FromDbModel(owner));
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int? id)
        {
            Owner owner;
            using (DatabaseContext db = new DatabaseContext())
            {
                owner = db.Owners.FirstOrDefault(x => x.Id == id);
                db.Owners.Remove(owner);
                db.SaveChanges();
            }
            if (owner == null)
            {
                return HttpNotFound();
            }
            return RedirectToAction("ViewAll");
        }

    }
}
