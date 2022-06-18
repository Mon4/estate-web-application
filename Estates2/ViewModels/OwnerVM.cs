using Estates2.Models.DbModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Estates2.ViewModels
{
    public class OwnerVM
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Adress { get; set; } //street and home number
        [Required]
        [DisplayName("ZIP Code")]
        public string ZipCode { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        [RegularExpression(@"^\d{9}|^\d{3}-\d{3}-\d{3}|^\d{3} \d{3} \d{3}",
            ErrorMessage = "Please enter a valid phone number")]
        [DisplayName("Phone number")]
        public string PhoneNumber { get; set; }
        public List<EstateVM> EstatesVM { get; set; } = new List<EstateVM>();
        

        public OwnerVM(string adress, string zipCode, string city, string phoneNumber, int estatesNumber)
        {
            Adress = adress;
            ZipCode = zipCode;
            City = city;
            PhoneNumber = phoneNumber;
        }

        public OwnerVM()
        {
        }

        internal static Owner ToDbModel(OwnerVM vm)
        {
            return new Owner
            {
                Id = vm.Id,
                Name = vm.Name,
                Adress = vm.Adress,
                ZipCode = vm.ZipCode,
                City = vm.City,
                PhoneNumber = vm.PhoneNumber,
                Estates = vm.EstatesVM.Select(e => EstateVM.ToDbModel(e)).ToList()
            };
        }

        internal static OwnerVM FromDbModel(Models.DbModels.Owner m)
        {
            return new OwnerVM
            {
                Id = m.Id,
                Name = m.Name,
                Adress = m.Adress,
                ZipCode = m.ZipCode,
                City = m.City,
                PhoneNumber = m.PhoneNumber,
                EstatesVM = m.Estates.Select(e => EstateVM.FromDbModel(e)).ToList()
            };
        }
    }
}