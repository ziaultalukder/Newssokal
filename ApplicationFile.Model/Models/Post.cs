using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoinikSokal.Model.Contracts;

namespace ApplicationFile.Model.Models
{
    public class Post:IModel,IDeletable
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public string Tags { get; set; }
        public int CatagoryId { get; set; }
        public Catagory Catagory { get; set; }
        public bool IsDeleted { get; set; }
        public bool Delete()
        {
            return IsDeleted;
        }
    }
}
