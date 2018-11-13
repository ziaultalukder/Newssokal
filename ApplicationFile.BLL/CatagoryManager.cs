using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationFile.BLL.Base;
using ApplicationFile.Model.Models;
using ApplicationFile.Repository;
using ApplicationFile.Repository.Base;
using DoinikSokal.BLL.Contracts;
using DoinikSokal.Repository.Contracts;

namespace ApplicationFile.BLL
{
    public class CatagoryManager:Manager<Catagory>,ICatagoryManager
    {
        private ICatagoryRepository __catagoryRepository;
        public CatagoryManager(ICatagoryRepository catagoryRepository) : base(catagoryRepository)
        {
            this.__catagoryRepository = catagoryRepository;
        }

        public override bool Add(Catagory entity)
        {
            if (string.IsNullOrEmpty(entity.Name))
            {
                throw new Exception("Please Provie a valid name");
            }
            return __catagoryRepository.Add(entity);
        }

        public ICollection<Catagory> GetByName(string name)
        {
            return __catagoryRepository.GetByName(name);
        }
    }
}
