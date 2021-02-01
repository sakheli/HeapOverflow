using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WCF.DataContract
{
    public class RoleContract
    {
        public RoleContract()
        {
            Users = new HashSet<UserContract>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string roleName { get; set; }

        public virtual ICollection<UserContract> Users { get; set; }
    }
}