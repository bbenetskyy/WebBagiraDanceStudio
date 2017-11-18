using System;
using System.Collections.Generic;
using System.Text;

namespace BagiraDanceStudio.Service.Interfaces
{
    interface IAbstractRepositoryService<TEntity> where TEntity : class
    {
        bool Create(TEntity obj);
        bool Update(TEntity obj);
        bool Delete(TEntity obj);
        dynamic Get(Guid? id);
    }
}
