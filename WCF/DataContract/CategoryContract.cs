using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WCF.DataContract
{
    public class CategoryContract
    {
        public CategoryContract()
        {
            Posts = new HashSet<PostContract>();
            Users = new HashSet<UserContract>();
        }

        public int id { get; set; }

        [Required]
        [MaxLength(50)]
        public byte[] categoryName { get; set; }

        public virtual ICollection<PostContract> Posts { get; set; }

        public virtual ICollection<UserContract> Users { get; set; }   
    }
}