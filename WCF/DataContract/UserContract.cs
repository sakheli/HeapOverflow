using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WCF.DataContract
{
    public class UserContract
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UserContract()
        {
            Posts = new HashSet<PostContract>();
            Replies = new HashSet<ReplyContract>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string username { get; set; }

        [Required]
        [StringLength(50)]
        public string password { get; set; }

        [Required]
        [StringLength(50)]
        public string email { get; set; }

        public int roleId { get; set; }

        public int? assignedCategory { get; set; }

        public virtual CategoryContract Category { get; set; }

        public virtual ICollection<PostContract> Posts { get; set; }

        public virtual ICollection<ReplyContract> Replies { get; set; }

        public virtual RoleContract Roles { get; set; }
    }
}