using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Estates2.Models.DbModels
{
    public class Meeting
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public virtual Client Client { get; set; }
        public int EmployeeId {get; set; }
        public virtual Employee Employee { get; set; }
        public int EstateId { get; set; }
        public virtual Estate Estate { get; set; }
        public DateTime Date { get; set; }
        public Meeting()
        {
        }
    }
}