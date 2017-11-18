using BagiraDanceStudio.Db.Models;
using BagiraDanceStudio.Service.Interfaces;
using BagiraDanceStudio.Service.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using BagiraDanceStudio.Service.Tools;
using BagiraDanceStudio.Db.Interfaces;
using BagiraDanceStudio.Db.Repository;

namespace BagiraDanceStudio.Service.Services
{
    public class UserService : IAbstractRepositoryService<UserViewModel>
    {
        private IManagerExceptions managerExceptions;
        private IAbstractRepository abstractRepository;
        public UserService(DataBaseContext db)
        {
            abstractRepository = new AbstractRepository(db);
        }
        public bool Create(UserViewModel obj)
        {
            return Execute(() => { abstractRepository.UsersRepository.Add(BuildUser(obj)); });
        }

        public bool Delete(UserViewModel obj)
        {
            return Execute(() => { abstractRepository.UsersRepository.Remove(BuildUser(obj)); });
        }

        public bool Update(UserViewModel obj)
        {
            return Execute(() => { return abstractRepository.UsersRepository.Update(BuildUser(obj)); });
        }
        public dynamic Get(Guid? id)
        {
            if (id is Guid ID)
            {
                return Execute(() => { return abstractRepository.UsersRepository.FindById(ID); });
            }
            else
            {
                return Execute(() => { return abstractRepository.UsersRepository.FindAll(); });
            }
        }

        #region [Execute]
        public bool Execute(Action method)
        {
            try
            {
                method();
                return true;
            }
            catch (Exception ex)
            {
                managerExceptions.Print(ex.Message);
                return false;
            }
        }
        public dynamic Execute(Func<dynamic> method)
        {
            try
            {
                return method();
            }
            catch (Exception ex)
            {
                managerExceptions.Print(ex.Message);
                return null;
            }
        }
        #endregion

        public User BuildUser(UserViewModel obj)
        {
            User user = new User();
            user.Balance = obj.Balance;
            user.TrainingPoints = obj.TrainingPoints;
            user.PersonData = obj.GetPersonData();
            user.Manager = abstractRepository.PersonDataRepository.FindById(obj.IdManager);
            //user.Level = abstractRepository.Find(obj.LevelName);
            //user.BillingHistory = abstractRepository.PersonDataRepository.Find(obj.IdBillingHistory);
            return user;
        }
    }
}
