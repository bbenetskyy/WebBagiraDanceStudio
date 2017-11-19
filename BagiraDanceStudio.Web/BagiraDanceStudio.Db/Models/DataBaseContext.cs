using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BagiraDanceStudio.Db.Models
{
    public class DataBaseContext : DbContext
    {
        public DbSet<BillingHistory> BillingHistories { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventToImage> EventToImages { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<PersonData> PersonsData { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<ScheduleAssigned> SchedulesAssigned { get; set; }
        public DbSet<ScheduleAvailable> SchedulesAvailable { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Manager> Managers { get; set; }

        //public DataBaseContext(DbContextOptions<DataBaseContext> options)
        //    : base(options)
        //{
        //}
        public DataBaseContext() : base((new DbContextOptionsBuilder<DataBaseContext>()
            .UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;" +
                          "Initial Catalog=BagiraDanceStudioDatabase;" +
                          "Integrated Security=True;" +
                          "Connect Timeout=30;" +
                          "Encrypt=False;" +
                          "TrustServerCertificate=True;" +
                          "ApplicationIntent=ReadWrite;" +
                          "MultiSubnetFailover=False"
                         )).Options)
        {
        }
    }
}
