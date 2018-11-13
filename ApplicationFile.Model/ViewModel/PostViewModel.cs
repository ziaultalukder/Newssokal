using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationFile.Model.Models
{
    public class PostViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Details { get; set; }

        [Required]
        public string Tags { get; set; }

        [Display(Name = "Category")]
        public int CatagoryId { get; set; }
        public Catagory Catagory { get; set; }
        public IEnumerable<Catagory> Catagories { get; set; }
    }
}
