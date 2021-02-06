using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using WCF.DataContract;

namespace HeapOverflow.Models
{
    public class ReplyModel
    {
        public int id { get; set; }

        public int userId { get; set; }

        [Column(TypeName = "text")]
        [Required(ErrorMessage = "აუცილებელია კონტენტი")]
        [Display(Name = "კონტენტი")]
        public string body { get; set; }

        public virtual UserContract Users { get; set; }

        public virtual ICollection<PostContract> Posts { get; set; }
    }
}