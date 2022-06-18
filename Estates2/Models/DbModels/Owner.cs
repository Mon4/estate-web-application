using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Estates2.Models.DbModels
{
    public class Owner
    {
        public int Id { get; set; }
        public string Adress { get; set; } //street and home number
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
        public List<Estate> Estates { get; set; } = new List<Estate>();
        public string Name { get; set; }

        public Owner()
        {
        }
    }
}