using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoinikSokal.Model.Contracts;

namespace ApplicationFile.Model.Models
{
    public class Catagory:IModel,IDeletable
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        [Display(Name = "Category")]
        public string Name { get; set; }

        public int? CategoryId { get; set; }
        public Catagory Category { get; set; }


        public bool IsDeleted { get; set; }
        public bool Delete()
        {
            return IsDeleted;
        }
    }
}
