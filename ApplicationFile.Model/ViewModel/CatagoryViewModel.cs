using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoinikSokal.Model.Contracts;

namespace ApplicationFile.Model.Models
{
    public class CatagoryViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public bool IsDeleted { get; set; }

        [Display(Name = "Root Catagory")]
        public int CatagoryId { get; set; }

        [Display(Name = "Root Catagory")]
        public Catagory Catagory { get; set; }

        [Display(Name = "Root Catagory")]
        public IEnumerable<Catagory> Catagories { get; set; } 
    }
}
