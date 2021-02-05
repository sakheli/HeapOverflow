using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using WCF.DataContract;

namespace HipOverflow.Models
{
    public class ReplyModel
    {

        public int id { get; set; }

        public int userId { get; set; }

        [Column(TypeName = "text")]
        [Required]
        [MinLength(5, ErrorMessage = "კომენტარი არ უნდა იყოს 20 ასოზე ნაკლები")]
        [MaxLength(300, ErrorMessage = "კომენტარი არ უნდა იყოს 100 ასოზე მეტი")]
        public string body { get; set; }

        public virtual UserContract Users { get; set; }

        public virtual ICollection<PostContract> Posts { get; set; }
    }
}