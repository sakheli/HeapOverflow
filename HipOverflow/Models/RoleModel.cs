using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WCF.DataContract;

namespace HeapOverflow.Models
{
    public class RoleModel
    {
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string roleName { get; set; }

        public virtual ICollection<UserContract> Users { get; set; }
    }
}