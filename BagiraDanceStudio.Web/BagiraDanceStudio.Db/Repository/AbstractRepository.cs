using BagiraDanceStudio.Db.Interfaces;
using BagiraDanceStudio.Db.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BagiraDanceStudio.Db.Repository
{
    public class AbstractRepository
    {
        public DatabaseRepository<User> UsersRepository { get; set; }
        public DatabaseRepository<PersonData> PersonDataRepository { get; set; }
        public DatabaseRepository<Manager> ManagerRepository { get; set; }
        public DatabaseRepository<BillingHistory> BillingHistoryRepository { get; set; }
        public DatabaseRepository<Event> EventRepository { get; set; }
        public DatabaseRepository<EventToImage> EventToImageRepository { get; set; }
        public DatabaseRepository<Image> ImageRepository { get; set; }
        public DatabaseRepository<Level> LevelRepository { get; set; }
        public DatabaseRepository<Role> RoleRepository { get; set; }
        public DatabaseRepository<ScheduleAssigned> ScheduleAssignedRepository { get; set; }
        public DatabaseRepository<ScheduleAvailable> ScheduleAvailableRepository { get; set; }
        public DatabaseRepository<Tag> TagRepository { get; set; }
        public AbstractRepository(DataBaseContext dataBaseContext)
        {
            UsersRepository = new DatabaseRepository<User>(dataBaseContext);
            PersonDataRepository = new DatabaseRepository<PersonData>(dataBaseContext);
            ManagerRepository = new DatabaseRepository<Manager>(dataBaseContext);
            BillingHistoryRepository = new DatabaseRepository<BillingHistory>(dataBaseContext);
            EventRepository = new DatabaseRepository<Event>(dataBaseContext);
            EventToImageRepository = new DatabaseRepository<EventToImage>(dataBaseContext);
            ImageRepository = new DatabaseRepository<Image>(dataBaseContext);
            LevelRepository = new DatabaseRepository<Level>(dataBaseContext);
            RoleRepository = new DatabaseRepository<Role>(dataBaseContext);
            ScheduleAssignedRepository = new DatabaseRepository<ScheduleAssigned>(dataBaseContext);
            ScheduleAvailableRepository = new DatabaseRepository<ScheduleAvailable>(dataBaseContext);
            TagRepository = new DatabaseRepository<Tag>(dataBaseContext);
        }
    }
}
