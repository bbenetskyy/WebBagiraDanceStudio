using BagiraDanceStudio.Service.Tools;
using System;
using System.Collections.Generic;
using System.Text;

namespace BagiraDanceStudio.Service.Interfaces
{
    interface IRepositoryService<TEntity> where TEntity : class
    {
        StatusManager Create(TEntity obj);
        StatusManager Update(TEntity obj);
        StatusManager Delete(TEntity obj);
        StatusManager Get(Guid? id);
    }
}
