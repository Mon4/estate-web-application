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
    public class MeetingController : Controller
    {
        // GET: Meeting
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
                return View(new MeetingVM
                {
                    AllEmployees = db.Employees.ToList().Select(o => EmployeeVM.FromDbModel(o)).ToList(),
                    AllEstates = db.Estates.ToList().Select(o => EstateVM.FromDbModel(o)).ToList(),
                    AllClients = db.Clients.ToList().Select(o => ClientVM.FromDbModel(o)).ToList()
                });
            }
        }

        [HttpPost]
        public ActionResult Create(MeetingVM meetingVM)
        {
            if (ModelState.IsValid)
            {
                using (DatabaseContext db = new DatabaseContext())
                {
                    var meeting = MeetingVM.ToDbModel(meetingVM);
                    db.Meetings.Add(meeting);
                    db.SaveChanges();
                }
                return RedirectToAction("ViewAll");
            }
            using (DatabaseContext db = new DatabaseContext())
            {
                meetingVM.AllEmployees = db.Employees.ToList().Select(o => EmployeeVM.FromDbModel(o)).ToList();
                meetingVM.AllEstates = db.Estates.ToList().Select(o => EstateVM.FromDbModel(o)).ToList();
                meetingVM.AllClients = db.Clients.ToList().Select(o => ClientVM.FromDbModel(o)).ToList();
            }
            return View(meetingVM);
        }

        //read
        [HttpGet]
        public ActionResult ViewAll()
        {
            List<MeetingVM> meetings;
            using (DatabaseContext db = new DatabaseContext())
                meetings = db.Meetings.ToList().Select(x=>MeetingVM.FromDbModel(x)).ToList();
            return View(meetings);

        }
        //details
        public ActionResult View(int id)
        {
            Meeting meeting;
            using (DatabaseContext db = new DatabaseContext())
            {
                meeting = db.Meetings.FirstOrDefault(x => x.Id == id);
                if (meeting == null)
                {
                    return HttpNotFound();
                }
                return View(MeetingVM.FromDbModel(meeting));
            }
        }
        //update
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Meeting meeting;
            using (DatabaseContext db = new DatabaseContext())
            {
                var AllEmployees = db.Employees.ToList().Select(o => EmployeeVM.FromDbModel(o)).ToList();
                var AllEstates = db.Estates.ToList().Select(o => EstateVM.FromDbModel(o)).ToList();
                var AllClients = db.Clients.ToList().Select(o => ClientVM.FromDbModel(o)).ToList();
                meeting = db.Meetings.FirstOrDefault(x => x.Id == id);
                if (meeting == null)
                {
                    return HttpNotFound();
                }
                return View(MeetingVM.FromDbModel(meeting, AllEmployees, AllEstates, AllClients));
            }
        }

        [HttpPost]
        public ActionResult Edit(MeetingVM vm)
        {
            if (ModelState.IsValid)
            {
                using (DatabaseContext db = new DatabaseContext())
                {
                    var meeting = db.Meetings.FirstOrDefault(x => x.Id == vm.Id);
                    meeting.Date = vm.MeetingDate;
                    db.SaveChanges();
                }
                return RedirectToAction("ViewAll");
            }
            using (DatabaseContext db = new DatabaseContext())
            {
                vm.AllEmployees = db.Employees.ToList().Select(o => EmployeeVM.FromDbModel(o)).ToList();
                vm.AllEstates = db.Estates.ToList().Select(o => EstateVM.FromDbModel(o)).ToList();
                vm.AllClients = db.Clients.ToList().Select(o => ClientVM.FromDbModel(o)).ToList();
            }
            return View(vm);
        }
        //delete
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            Meeting meeting;
            using (DatabaseContext db = new DatabaseContext())
            {
                meeting = db.Meetings.FirstOrDefault(x => x.Id == id);
                if (meeting == null)
                {
                    return HttpNotFound();
                }
                return View(MeetingVM.FromDbModel(meeting));
            }
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int? id)
        {
            Meeting meeting;
            using (DatabaseContext db = new DatabaseContext())
            {
                meeting = db.Meetings.FirstOrDefault(x => x.Id == id);
                db.Meetings.Remove(meeting);
                db.SaveChanges();
            }
            if (meeting == null)
            {
                return HttpNotFound();
            }
            return RedirectToAction("ViewAll");
        }
    }
}