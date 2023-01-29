using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace E_CommerceWebSite.Models
{
    public partial class TbCategory
    {
        public TbCategory()
        {
            TbProducts = new HashSet<TbProduct>();
        }
        [Key]
        public int CategoryId { get; set; }
        [Required(ErrorMessage ="Category name is required..!")]
        public string CategoryName { get; set; }

        public virtual ICollection<TbProduct> TbProducts { get; set; }
    }
}
