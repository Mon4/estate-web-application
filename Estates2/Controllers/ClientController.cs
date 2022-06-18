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
    public class ClientController : Controller
    {
        public ActionResult Error()
        {
            throw new NotImplementedException();
        }

        // GET: Client
        public ActionResult Index()
        {
            return View();
        }
        //create
        [HttpGet]
        public ActionResult Create()
        {
            return View(new ClientVM());
        }

        [HttpPost]
        public ActionResult Create(ClientVM vm)
        {
            if (ModelState.IsValid)
            {
                using (DatabaseContext db = new DatabaseContext())
                {
                    var client = ClientVM.ToDbModel(vm);
                    db.Clients.Add(client);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            return View(new ClientVM());
        }

        //read
        [HttpGet]
        public ActionResult ViewAll()
        {
            List<ClientVM> clients;
            using (DatabaseContext db = new DatabaseContext())
                clients = db.Clients.ToList().Select(x => ClientVM.FromDbModel(x)).ToList();
            return View(clients);

        }
        //details
        public ActionResult View(int id)
        {
            Client client;
            using (DatabaseContext db = new DatabaseContext())
                client = db.Clients.FirstOrDefault(x => x.Id == id);

            if (client == null)
            {
                return HttpNotFound();
            }
            return View(ClientVM.FromDbModel(client));
        }
        //update
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Client client;
            using (DatabaseContext db = new DatabaseContext())
                client = db.Clients.FirstOrDefault(x => x.Id == id);

            if (client == null)
            {
                return HttpNotFound();
            }
            return View(ClientVM.FromDbModel(client));
        }

        [HttpPost]
        public ActionResult Edit(ClientVM vm)
        {
            if (!ModelState.IsValid)
                return View(vm);
            using (DatabaseContext db = new DatabaseContext())
            {
                var client = db.Clients.FirstOrDefault(x => x.Id == vm.Id);
                client.Name = vm.Name;
                client.Surname = vm.Surname;
                client.PhoneNumber = vm.PhoneNumber;
                client.DateOfBirth = vm.DateOfBirth;
                db.SaveChanges();
            }
            return RedirectToAction("ViewAll");
        }
        //delete
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            Client client;
            using (DatabaseContext db = new DatabaseContext())
            {
                client = db.Clients.FirstOrDefault(x => x.Id == id);
            }

            if (client == null)
            {
                return HttpNotFound();
            }
            return View(ClientVM.FromDbModel(client));
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int? id)
        {
            Client client;
            using (DatabaseContext db = new DatabaseContext())
            {
                client = db.Clients.FirstOrDefault(x => x.Id == id);
                db.Clients.Remove(client);
                db.SaveChanges();
            }
            if (client == null)
            {
                return HttpNotFound();
            }
            return RedirectToAction("ViewAll");
        }
    }
}