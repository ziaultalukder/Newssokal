using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DoinikSokal.Model.Contracts;

namespace DoinikSokal.Repository.Contracts
{
    public interface IRepository<T> where T : class
    {
        bool Add(T entity);
        bool Update(T entity);
        bool Remove(IDeletable entity);
        bool Remove(ICollection<IDeletable> entities);
        ICollection<T> GetAll(bool withDelete = false);
        ICollection<T> Get(Expression<Func<T, bool>> query);
        T GetById(int id);
        void Dispose();
    }
}
