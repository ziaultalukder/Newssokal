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
    public class PostManager:Manager<Post>,IPostManager
    {
        private IPostRepository _postRepository;
        public PostManager(IPostRepository repository) : base(repository)
        {
            this._postRepository = repository;
        }
    }
}
