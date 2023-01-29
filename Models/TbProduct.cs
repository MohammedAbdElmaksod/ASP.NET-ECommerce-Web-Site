using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace E_CommerceWebSite.Models
{
    public partial class TbProduct
    {
        public TbProduct()
        {
            TbImages = new HashSet<TbImage>();
        }
        [Key]
        public int ProductId { get; set; }
        [Required(ErrorMessage ="name is requird..!")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "sale price is requird..!")]
        public decimal ProductSalePrice { get; set; }
        [Required(ErrorMessage = "buy price is requird..!")]
        public decimal ProductBuyPrice { get; set; }
        public string ImageName { get; set; }
        [Required(ErrorMessage = "Choose category or product default category will be سجاد...!")]
        public int? CategoryId { get; set; }

        public virtual TbCategory Category { get; set; }
        public virtual ICollection<TbImage> TbImages { get; set; }
    }
}
