using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WCF.DataContract
{
    public class ReplyContract
    {
        public ReplyContract()
        {
            Posts = new HashSet<PostContract>();
        }

        public int id { get; set; }

        public int userId { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string body { get; set; }

        public virtual UserContract Users { get; set; }

        public virtual ICollection<PostContract> Posts { get; set; }
    }
}