using Estates2.Models.DbModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Estates2.ViewModels
{
    public class MeetingVM
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public ClientVM ClientVM { get; set; } = new ClientVM();
        public int EmployeeId {get; set; }
        public EmployeeVM EmployeeVM { get; set; } = new EmployeeVM();
        public int EstateId { get; set; }
        public EstateVM EstateVM { get; set; } = new EstateVM();
        [DisplayName("Meeting date")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime MeetingDate { get; set; } = DateTime.Now;
        public int SelectedEmployeeId { get; set; }
        public List<EmployeeVM> AllEmployees { get; set; }
        public int SelectedEstateId { get; set; }
        public List<EstateVM> AllEstates { get; set; }
        public int SelectedClientId { get; set; }
        public List<ClientVM> AllClients { get; set; }


        public static Meeting ToDbModel(MeetingVM vm)
        {
            return new Meeting
            {
                Id = vm.Id,
                Date = vm.MeetingDate,
                ClientId = vm.SelectedClientId,
                EmployeeId = vm.SelectedEmployeeId,
                EstateId = vm.SelectedEstateId
            };
            
        }
        public static MeetingVM FromDbModel(Meeting m, List<EmployeeVM> employees = null, List<EstateVM> estates=null, 
            List<ClientVM> clients = null)
        {
            return new MeetingVM
            {
                Id = m.Id,
                MeetingDate = m.Date,
                AllEmployees = employees,
                AllEstates = estates,
                AllClients = clients,
                EmployeeVM = new EmployeeVM
                {
                    Id = m.Employee.Id,
                    Name = m.Employee.Name,
                    Surname = m.Employee.Surname,
                    PhoneNumber = m.Employee.PhoneNumber,
                    Salary = m.Employee.Salary,
                },
                EstateVM = new EstateVM
                {
                    Id = m.Id,
                    Adress = m.Estate.Adress,
                    ZipCode = m.Estate.ZipCode,
                    City = m.Estate.City,
                    Price = m.Estate.Price,
                    Area = m.Estate.Area,
                    Furniture = m.Estate.Furniture,
                    Balcony = m.Estate.Balcony,
                    RoomsNumber = m.Estate.RoomsNumber,
                    Description = m.Estate.Description,
                    Bedrooms = m.Estate.Bedrooms,
                },
                ClientVM = new ClientVM
                {
                    Id = m.Id,
                    Name = m.Client.Name,
                    Surname = m.Client.Surname,
                    PhoneNumber = m.Client.PhoneNumber,
                    DateOfBirth = m.Client.DateOfBirth,
                },
            };
        }
    }
}