using System;
using System.Collections.Generic;

#nullable disable

namespace E_CommerceWebSite.Models
{
    public partial class TbImage
    {
        public int ImageId { get; set; }
        public string ImageName { get; set; }
        public int ProductId { get; set; }

        public virtual TbProduct Product { get; set; }
    }
}
