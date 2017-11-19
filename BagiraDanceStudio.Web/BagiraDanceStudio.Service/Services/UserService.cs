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
    public class UserService : IRepositoryService<UserViewModel>
    {
        private IManagerExceptions managerExceptions;
        private IAbstractRepository abstractRepository;
        public UserService(DataBaseContext db)
        {
            abstractRepository = new AbstractRepository(db);
        }
        public StatusManager Create(UserViewModel obj)
        {
            return Execute(() => { abstractRepository
                                  .UsersRepository
                                  .IncludeEntity<PersonData>()
                                  .Add(BuildUser(obj));
            });
        }

        public StatusManager Delete(UserViewModel obj)
        {
            return Execute(() => { abstractRepository
                                   .UsersRepository
                                   .Remove(BuildUser(obj));
            });
        }

        public StatusManager Update(UserViewModel obj)
        {
            return Execute(() => { return abstractRepository
                                         .UsersRepository
                                         .Update(BuildUser(obj));
            });
        }
        public StatusManager Get(Guid? id)
        {
            if (id.HasValue)
            {
                return Execute(() => { return abstractRepository
                                             .UsersRepository
                                             .FindById(id.Value);
                });
            }
            else
            {
                return Execute(() => { return abstractRepository
                                             .UsersRepository
                                             .FindAll();
                });
            }
        }

        #region [Execute]
        public StatusManager Execute(Action method)
        {
            StatusManager statusManager = new StatusManager();
            try
            {
                method();
            }
            catch (Exception ex)
            {
                statusManager.ErrorMessage = ex;
                statusManager.Log();
            }
            return statusManager;
        }
        public StatusManager Execute(Func<dynamic> method)
        {
            StatusManager statusManager = new StatusManager();
            try
            {
                statusManager.ReturnValue = method();
            }
            catch (Exception ex)
            {
                statusManager.ErrorMessage = ex;
                statusManager.Log();
            }
            return statusManager;
        }
        #endregion

        public User BuildUser(UserViewModel obj)
        {
            User user = new User();
            user.Balance = obj.Balance;
            user.TrainingPoints = obj.TrainingPoints;
            user.PersonData = obj.GetPersonData();
            //user.Manager = abstractRepository.PersonDataRepository.FindById(obj.IdManager);
            //user.Level = abstractRepository.Find(obj.LevelName);
            //user.BillingHistory = abstractRepository.PersonDataRepository.Find(obj.IdBillingHistory);
            return user;
        }
    }
}
