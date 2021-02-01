using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WCF.DataContract
{
    public class PostContract
    {
        public PostContract()
        {
            Replies = new HashSet<ReplyContract>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(150)]
        public string title { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string body { get; set; }

        public int userId { get; set; }

        public int categoryId { get; set; }

        public virtual CategoryContract Category { get; set; }

        public virtual UserContract Users { get; set; }

        public virtual ICollection<ReplyContract> Replies { get; set; }
    }
}