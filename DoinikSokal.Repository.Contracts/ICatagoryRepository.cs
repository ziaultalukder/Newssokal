using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationFile.Model.Models;

namespace DoinikSokal.Repository.Contracts
{
    public interface ICatagoryRepository:IRepository<Catagory>
    {
        ICollection<Catagory> GetByName(string name);
    }
}
