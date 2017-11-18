using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagiraDanceStudio.Db.Interfaces
{
    public interface IDatabaseRepository<TEntity> where TEntity : class
    {
        void Add(TEntity obj);
        void Remove(TEntity obj);
        bool RemoveById(Guid id);
        bool Update(TEntity obj);
        IEnumerable<TEntity> FindBy(Predicate<TEntity> predicate);
        TEntity FindById(Guid id);
        IList<TEntity> FindAll();
    }
}
