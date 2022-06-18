using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Estates2.Models.DbModels
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public List<Meeting> Meetings { get; set; } = new List<Meeting>();

        public Client() { }

    }
}