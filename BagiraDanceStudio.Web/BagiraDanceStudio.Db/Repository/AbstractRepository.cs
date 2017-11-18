using BagiraDanceStudio.Db.Interfaces;
using BagiraDanceStudio.Db.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BagiraDanceStudio.Db.Repository
{
    public class AbstractRepository: IAbstractRepository
    {
        public DatabaseRepository<User> UsersRepository { get; set; }
        public DatabaseRepository<PersonData> PersonDataRepository { get; set; }
        public AbstractRepository(DataBaseContext dataBaseContext)
        {
            UsersRepository = new DatabaseRepository<User>(dataBaseContext);
            PersonDataRepository = new DatabaseRepository<PersonData>(dataBaseContext);
        }
    }
}
