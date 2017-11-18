using BagiraDanceStudio.Db.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BagiraDanceStudio.Db.Tools
{
    public static class DatabaseRepositoryExtension
    {
        public static IQueryable<TEntity> IncludeEntity<TEntity>(this IQueryable<TEntity> dbSetEntity, List<string> includedEntity) where TEntity : class
        {
            foreach(string entity in includedEntity)
            {
                dbSetEntity = dbSetEntity.Include(entity);
            }
            return dbSetEntity;
        }
    }
}
