using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationFile.Model.Models;
using ApplicationFile.Repository.Base;
using DoinikSokal.Repository.Contracts;

namespace ApplicationFile.Repository
{
    public class CatagoryRepository:DeletableRepository<Catagory>,ICatagoryRepository
    {
        public ICollection<Catagory> GetByName(string name)
        {
            return Get(c => c.Name.Contains(name));
        }

        public CatagoryRepository(DbContext db) : base(db)
        {
        }
    }
}
