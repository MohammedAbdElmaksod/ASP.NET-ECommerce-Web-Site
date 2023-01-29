using Microsoft.AspNetCore.Identity;
using System.Collections;
using System.Collections.Generic;

namespace E_CommerceWebSite.Models
{
    public class ExtendIdentity:IdentityUser
    {
        public virtual ICollection<TbOrderInvoice> OrderInvoice { get; set; }
    }
}
