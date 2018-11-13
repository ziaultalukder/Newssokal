using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ApplicationFile.Repository.DatabaseContext;
using DoinikSokal.Model.Contracts;
using DoinikSokal.Repository.Contracts;

namespace ApplicationFile.Repository.Base
{
    public abstract class Repository<T>:IRepository<T> where T : class
    {
        DbContext db;

        public Repository(DbContext db)
        {
            this.db = db;
        }
        public virtual bool Add(T entity)
        {
            db.Set<T>().Add(entity);
            return db.SaveChanges() > 0;
        }

        public virtual bool Update(T entity)
        {
            db.Set<T>().Attach(entity);
            db.Entry(entity).State = EntityState.Modified;
            return db.SaveChanges() > 0;
        }

        public virtual bool Remove(IDeletable entity)
        {
            entity.IsDeleted = true;
            return Update((T)entity);
        }

        public bool Remove(ICollection<IDeletable> entities)
        {
            int removeCount = 0;
            foreach (var entity in entities)
            {
                var isRemove = Remove(entity);
                if (isRemove)
                {
                    removeCount++;
                }
            }
            return entities.Count == removeCount;
        }

        public virtual ICollection<T> GetAll(bool withDeleted = false)
        {
            return db.Set<T>().ToList();
        }

        public virtual T GetById(int id)
        {
            return db.Set<T>().Find(id);
        }

        public virtual ICollection<T> Get(Expression<Func<T, bool>> query)
        {
            return db.Set<T>().Where(query).ToList();
        } 

        public virtual void Dispose()
        {
            db?.Dispose();
        }
    }

    public abstract class DeletableRepository<T>:Repository<T> where T:class,IDeletable
    {
        DoinikSokalDatabaseContext db = new DoinikSokalDatabaseContext();
        public override ICollection<T> GetAll(bool withDeleted = false)
        {
            return db.Set<T>().Where(c => c.IsDeleted == false || c.IsDeleted == withDeleted).ToList();
        }

        public DeletableRepository(DbContext db) : base(db)
        {
        }
    }
}
