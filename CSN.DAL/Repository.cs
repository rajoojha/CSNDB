using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Data;
namespace CSN.DAL
{
    public class Repository<TEntity> where TEntity : class
    {
        internal CSNDBEntities  context;
        internal DbSet<TEntity> dbSet;

        public Repository(CSNDBEntities context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
            this.dbSet.AsNoTracking();

        }

        public virtual IQueryable<TEntity> Get()
        {
            IQueryable<TEntity> query = dbSet.AsNoTracking<TEntity>();

            return query;
        }

        public virtual TEntity GetByID(object id)
        {
            return dbSet.Find(id);
        }

        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

        public virtual void Update(TEntity entityToUpdate)
        {

            if (context.Entry(entityToUpdate).State == EntityState.Detached)
            {
                dbSet.Attach(entityToUpdate);
            }
            context.Entry(entityToUpdate).State = EntityState.Modified;

        }


    }
}
