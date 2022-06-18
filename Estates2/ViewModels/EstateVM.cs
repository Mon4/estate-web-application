using Estates2.Models.DbModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Estates2.ViewModels
{
    public class EstateVM
    {
        public int Id { get; set; }
        [DisplayName("Estate adress")]
        [Required]
        public string Adress { get; set; }
        [DisplayName("ZIP Code")]
        [Required]
        [RegularExpression(@"^\d{2}-\d{3}")]
        public string ZipCode { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        [Range(0, Int64.MaxValue, ErrorMessage = "This value must be minimum 0.")]
        public decimal Price { get; set; }
        [Range(0, Int64.MaxValue, ErrorMessage = "This value must be higher than 0.")]
        public decimal Area { get; set; } //pol. powierzchnia
        public bool Furniture { get; set; }
        public bool Balcony { get; set; }
        [Required]
        [DisplayName("Number of rooms")]
        [Range(1, Int64.MaxValue, ErrorMessage = "This value must be higher than 0.")]
        public int RoomsNumber { get; set; }
        public string Description { get; set; }
        [Range(1, Int64.MaxValue, ErrorMessage = "This value must be higher than 0.")]
        public int Bedrooms { get; set; }
        public OwnerVM OwnerVM { get; set; }
        public MeetingVM MeetingVM { get; set; }
        public int SelectedOwnerId { get; set; }
        public List<OwnerVM> AllOwners { get; set; }


        public static Estate ToDbModel(EstateVM vm)
        {
            return new Estate
            {
                Id = vm.Id,
                Adress = vm.Adress,
                ZipCode = vm.ZipCode,
                City = vm.City,
                Price = vm.Price,
                Area = vm.Area,
                Furniture = vm.Furniture,
                Balcony = vm.Balcony,
                RoomsNumber = vm.RoomsNumber,
                Description = vm.Description,
                Bedrooms = vm.Bedrooms,
                OwnerId = vm.SelectedOwnerId
            };

        }
        public static EstateVM FromDbModel(Estate m, List<OwnerVM> owners = null)
        {
            return new EstateVM
            {
                Id = m.Id,
                Adress = m.Adress,
                ZipCode = m.ZipCode,
                City = m.City,
                Price = m.Price,
                Area = m.Area,
                Furniture = m.Furniture,
                Balcony = m.Balcony,
                RoomsNumber = m.RoomsNumber,
                Description = m.Description,
                Bedrooms = m.Bedrooms,

                OwnerVM = new OwnerVM
                {
                    Id = m.Owner.Id,
                    Name = m.Owner.Name,
                    Adress = m.Owner.Adress,
                    ZipCode = m.Owner.ZipCode,
                    City = m.Owner.City,
                    PhoneNumber = m.Owner.PhoneNumber,
                },
                AllOwners = owners
            };
        }


    }
}