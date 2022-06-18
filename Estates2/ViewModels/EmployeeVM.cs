using Estates2.Models.DbModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Estates2.ViewModels
{
    public class EmployeeVM
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        [DisplayName("Phone number")]
        [RegularExpression(@"^\d{9}|^\d{3}-\d{3}-\d{3}|^\d{3} \d{3} \d{3}",
            ErrorMessage = "Please enter a valid phone number")]
        public string PhoneNumber { get; set; }
        [Required]
        [Range(0, Int64.MaxValue, ErrorMessage = "This value must be minimum 0.")]
        public decimal Salary { get; set; }
        public List<MeetingVM> MeetingsVM { get; set; } = new List<MeetingVM>();
        public string FullName => Name + " " + Surname;

        internal static Employee ToDbModel(EmployeeVM vm)
        {
            return new Employee
            {
                Id = vm.Id,
                Name = vm.Name,
                Surname = vm.Surname,
                PhoneNumber = vm.PhoneNumber,
                Salary = vm.Salary,
                Meetings = vm.MeetingsVM.Select(e => MeetingVM.ToDbModel(e)).ToList()
            };
        }

        internal static EmployeeVM FromDbModel(Employee m)
        {
            return new EmployeeVM
            {
                Id = m.Id,
                Name = m.Name,
                Surname = m.Surname,
                PhoneNumber = m.PhoneNumber,
                Salary = m.Salary,
                MeetingsVM = m.Meetings.Select(e => MeetingVM.FromDbModel(e)).ToList()
            };
        }
    }
}