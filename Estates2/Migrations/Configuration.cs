namespace Estates2.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Estates2.Models.DatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true; // umozliwia automatyczne migracje 
            AutomaticMigrationDataLossAllowed = true; //umozliwia utrate danych, jesli taka wystapi - niewywolujac wyjatku
        }

        protected override void Seed(Estates2.Models.DatabaseContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            context.Owners.AddOrUpdate(x => x.Id,
                new Models.DbModels.Owner() { Id = 1, Adress = "Królewska 5", Name = "Monika", ZipCode = "30-303", City = "Kraków", PhoneNumber = "508509510" },
                new Models.DbModels.Owner() { Id = 2, Adress = "Michałowska 5", Name = "Ania", ZipCode = "31-303", City = "Kraków", PhoneNumber = "507509510" },
                new Models.DbModels.Owner() { Id = 3, Adress = "Beatowa 5", Name = "Marcin", ZipCode = "32-303", City = "Kraków", PhoneNumber = "509509510" }
                );

            context.Estates.AddOrUpdate(x => x.Id,
                new Models.DbModels.Estate() { Id = 1, Adress = "Cicha 1", ZipCode = "32-309", City = "Kraków", Price = 750000, Area = 50.5m, Furniture = true, Balcony = true, RoomsNumber = 3, Description = "z widokiem na Teatr Słowackiego i planty Krakowskie", Bedrooms = 2, OwnerId = 1 },
                new Models.DbModels.Estate() { Id = 2, Adress = "Głośna 1", ZipCode = "39-670", City = "Kraków", Price = 500000, Area = 43.5m, Furniture = false, Balcony = true, RoomsNumber = 2, Description = "z widokiem na Skałki Twardowskiego", Bedrooms = 1, OwnerId = 2 },
                new Models.DbModels.Estate() { Id = 3, Adress = "Kapuściana 1", ZipCode = "35-467", City = "Kraków", Price = 1500000, Area = 90.5m, Furniture = true, Balcony = false, RoomsNumber = 4, Description = "okno na wschód i zachód słońca", Bedrooms = 2, OwnerId = 3 }
                );


            context.Employees.AddOrUpdate(x => x.Id,
                new Models.DbModels.Employee() { Id = 007, Name = "Beata", Surname = "Mumin", PhoneNumber = "588509510", Salary = 2000 },
                new Models.DbModels.Employee() { Id = 009, Name = "Bartek", Surname = "Teletubiś", PhoneNumber = "586669519", Salary = 2500 },
                new Models.DbModels.Employee() { Id = 010, Name = "Paulina", Surname = "Atomówka", PhoneNumber = "588599510", Salary = 2200 }
                );

            context.Clients.AddOrUpdate(x => x.Id,
               new Models.DbModels.Client() { Id = 35, Name = "Ola", Surname = "Pieprz", PhoneNumber = "900509510", DateOfBirth = new DateTime(2000, 1, 20) },
               new Models.DbModels.Client() { Id = 40, Name = "Olek", Surname = "Sól", PhoneNumber = "900600510", DateOfBirth = new DateTime(1978, 1, 20) },
               new Models.DbModels.Client() { Id = 46, Name = "Oskar", Surname = "Czarnuszka", PhoneNumber = "980050010", DateOfBirth = new DateTime(1990, 1, 20) }
               );

            context.Meetings.AddOrUpdate(x => x.Id,
               new Models.DbModels.Meeting() { Id = 0, ClientId = 35, EmployeeId = 007, EstateId = 1, Date = new DateTime(2022, 6, 30, 8, 30, 0) },
               new Models.DbModels.Meeting() { Id = 1, ClientId = 40, EmployeeId = 007, EstateId = 1, Date = new DateTime(2022, 6, 29, 10, 30, 0) },
               new Models.DbModels.Meeting() { Id = 2, ClientId = 35, EmployeeId = 009, EstateId = 1, Date = new DateTime(2022, 6, 28, 8, 0, 0) }
               );
        }


    }
}







//namespace Estates2.Migrations
//{
//    using System;
//    using System.Data.Entity;
//    using System.Data.Entity.Migrations;
//    using System.Linq;

//    internal sealed class Configuration : DbMigrationsConfiguration<Estates2.Models.DatabaseContext>
//    {
//        public Configuration()
//        {
//            AutomaticMigrationsEnabled = false;
//        }

//        protected override void Seed(Estates2.Models.DatabaseContext context)
//        {
//            //  This method will be called after migrating to the latest version.

//            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
//            //  to avoid creating duplicate seed data.
//        }
//    }
//}