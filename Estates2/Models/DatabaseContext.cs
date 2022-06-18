using Estates2.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Estates2.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("Estates2ConnectionString") 
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
        }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Employee> Employees {get; set; }
        public DbSet<Estate> Estates { get; set; }
        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<Owner> Owners { get; set; }

    }
}