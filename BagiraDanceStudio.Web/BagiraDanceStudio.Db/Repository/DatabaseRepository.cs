using BagiraDanceStudio.Db.Interfaces;
using BagiraDanceStudio.Db.Models;
using BagiraDanceStudio.Db.Tools;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagiraDanceStudio.Db.Repository
{
    public class DatabaseRepository<TEntity> : IDatabaseRepository<TEntity>, IDisposable where TEntity : TableAbstract
    {
        private DataBaseContext _dbContext;
        private List<string> _includeEntity;
        public DatabaseRepository(DataBaseContext dbContext)
        {
            _dbContext = dbContext;
            _includeEntity = new List<string>();
        }
        public DatabaseRepository()
        {
            _dbContext = new DataBaseContext();
            _includeEntity = new List<string>();
        }
        public void Add(TEntity obj)
        {
            _dbContext.Set<TEntity>().Add(obj);
            _dbContext.SaveChanges();
        }
        public void Remove(TEntity obj)
        {
            _dbContext.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            _dbContext.Set<TEntity>().Remove(obj);
            _dbContext.SaveChanges();
        }
        public bool RemoveById(Guid id)
        {
            TEntity obj = FindById(id);
            if (obj != null)
            {
                _dbContext.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                _dbContext.Set<TEntity>().Remove(obj);
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }
        public bool Update(TEntity obj)
        {
            if (obj != null)
            {
                _dbContext.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _dbContext.Update<TEntity>(obj);
                _dbContext.SaveChanges();
            }
            return false;
        }
        public IEnumerable<TEntity> FindBy(Predicate<TEntity> predicate)
        {
            return _dbContext
                .Set<TEntity>()
                .IncludeEntity(_includeEntity)
                .ToList<TEntity>()
                .FindAll(predicate)
                .ToList<TEntity>();
        }
        public TEntity FindById(Guid id)
        {
            return _dbContext
                .Set<TEntity>()
                .Where(x => x.GetId() == id)
                .IncludeEntity(_includeEntity)
                .SingleOrDefault();
        }
        public IList<TEntity> FindAll()
        {
            return _dbContext
                .Set<TEntity>()
                .IncludeEntity(_includeEntity)
                .ToList<TEntity>();
        }
        public DatabaseRepository<TEntity> IncludeEntity<Q>() where Q : class
        {
            if (!_includeEntity.Any(x => x.Equals(typeof(Q).Name)))
                _includeEntity.Add(typeof(Q).Name);
            return this;
        }
        public DatabaseRepository<TEntity> ExcludeEntity<Q>() where Q : class
        {
            string nameEntity = typeof(Q).Name;
            if (_includeEntity.Any(x => x.Equals(nameEntity)))
                _includeEntity.Remove(nameEntity);
            return this;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);

        }
        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_dbContext != null)
                {
                    _dbContext.Dispose();
                    _dbContext = null;
                }
            }
        }
    }
}
