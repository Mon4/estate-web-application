using Estates2.Models.DbModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Estates2.ViewModels
{
    public class ClientVM
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
        [DisplayName("Date of birth")]
        [DataType(DataType.Date)]
        [ValidateDate]
        public DateTime DateOfBirth { get; set; }
        public List<MeetingVM> MeetingsVM { get; set; } = new List<MeetingVM>();
        public string FullName => Name + " " +Surname;
        public static Client ToDbModel(ClientVM vm)
        {
            return new Client
            {
                Id = vm.Id,
                Name = vm.Name,
                Surname = vm.Surname,
                PhoneNumber = vm.PhoneNumber,
                DateOfBirth = vm.DateOfBirth,
                Meetings = vm.MeetingsVM.Select(e => MeetingVM.ToDbModel(e)).ToList()
            };

        }
        public static ClientVM FromDbModel(Client m)
        {
            return new ClientVM
            {
                Id = m.Id,
                Name = m.Name,
                Surname = m.Surname,
                PhoneNumber = m.PhoneNumber,
                DateOfBirth = m.DateOfBirth,
                MeetingsVM = m.Meetings.Select(e => MeetingVM.FromDbModel(e)).ToList()
            };
        }
    }
}