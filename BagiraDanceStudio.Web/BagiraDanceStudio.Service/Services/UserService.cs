using BagiraDanceStudio.Db.Models;
using BagiraDanceStudio.Service.Interfaces;
using BagiraDanceStudio.Service.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using BagiraDanceStudio.Service.Tools;
using BagiraDanceStudio.Db.Interfaces;
using BagiraDanceStudio.Db.Repository;
using AutoMapper;

namespace BagiraDanceStudio.Service.Services
{
    public class UserService : BaseService, IRepositoryService<UserViewModel>
    {
        private AbstractRepository abstractRepository;
        public UserService(DataBaseContext db) : base()
        {
            abstractRepository = new AbstractRepository(db);
        }
        public StatusManager Create(UserViewModel obj)
        {
            return Execute(() =>
            {
                abstractRepository
               .UsersRepository
               .IncludeEntity<PersonData>()
               .Add(Mapper.Map<UserViewModel, User>(obj));
            });
        }

        public StatusManager Delete(UserViewModel obj)
        {
            return Execute(() =>
            {
                abstractRepository
                .UsersRepository
                .Remove(Mapper.Map<UserViewModel, User>(obj));
            });
        }

        public StatusManager Update(UserViewModel obj)
        {
            return Execute(() =>
            {
                return abstractRepository
                      .UsersRepository
                      .Update(Mapper.Map<UserViewModel, User>(obj));
            });
        }
        public StatusManager Get(Guid? id)
        {
            if (id.HasValue)
            {
                return Execute(() =>
                {
                    return Mapper.Map<User,UserViewModel>(abstractRepository
                          .UsersRepository
                          .FindById(id.Value));
                });
            }
            else
            {
                return Execute(() =>
                {
                    return Mapper.Map<IList<User>, List<UserViewModel>>(abstractRepository
                          .UsersRepository
                          .FindAll());
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
    }
}
