using BagiraDanceStudio.Db.Models;
using BagiraDanceStudio.Db.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BagiraDanceStudio.Db.Interfaces
{
    public interface IAbstractRepository
    {
        DatabaseRepository<User> UsersRepository { get; set; }
        DatabaseRepository<PersonData> PersonDataRepository { get; set; }
    }
}
