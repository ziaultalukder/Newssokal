using ApplicationFile.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DoinikSokal.Model.Contracts;
using DoinikSokal.Repository.Contracts;
using DoinikSokal.BLL.Contracts;

namespace ApplicationFile.BLL.Base
{
    public abstract class Manager<T>: IManager<T> where T:class, IDeletable, IModel
    {
        protected IRepository<T> _Repository;

        public Manager(IRepository<T> repository)
        {
            _Repository = repository;
        } 
        public virtual bool Add(T entity)
        {
            return _Repository.Add(entity);
        }

        public virtual bool Update(T entity)
        {
            return _Repository.Update(entity);
        }

        public virtual bool Remove(IDeletable entity)
        {
            bool IsDeletable = entity is IDeletable;
            if (!IsDeletable)
            {
                throw new Exception("This Item Is Not Deleteable");
            }
            return _Repository.Remove((IDeletable)entity);
        }

        public virtual bool Remove(ICollection<IDeletable> entites)
        {
            return _Repository.Remove(entites);
        }

        public virtual ICollection<T> GetAll(bool withDeleted = false)
        {
            return _Repository.GetAll(withDeleted);
        }

        public virtual ICollection<T> Get(Expression<Func<T, bool>> query)
        {
            return _Repository.Get(query);
        }
        public virtual T GetById(int id)
        {
            return _Repository.GetById(id);
        }

        public virtual void Dispose()
        {
            _Repository.Dispose();
        }
    }
}
