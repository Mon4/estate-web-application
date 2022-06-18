using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Estates2.Models.DbModels
{
    public class Estate
    {
        public int Id { get; set; }
        public string Adress { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public decimal Price { get; set; }
        public decimal Area { get; set; } //pol. powierzchnia
        public bool Furniture { get; set; }
        public bool Balcony { get; set; }
        public int RoomsNumber { get; set; }
        public string Description { get; set; }
        public int Bedrooms { get; set; }
        public int OwnerId { get; set; }
        public virtual Owner Owner { get; set; }

        public Estate()
        {
        }

    }
}