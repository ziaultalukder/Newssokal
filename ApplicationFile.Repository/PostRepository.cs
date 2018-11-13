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
    public class PostRepository:DeletableRepository<Post>, IPostRepository
    {
        public PostRepository(DbContext db) : base(db)
        {
        }
    }
}
