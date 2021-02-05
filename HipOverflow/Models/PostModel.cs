using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using WCF.DataContract;

namespace HipOverflow.Models
{
    public class PostModel
    {
        public int id { get; set; }

        [DataMember]
        [Required(ErrorMessage = "აუცილებელია სათაური")]
        [MinLength(2, ErrorMessage = "სათაური არ უნდა იყოს 2 ასოზე ნაკლები")]
        [MaxLength(200, ErrorMessage = "სათაური არ უნდა იყოს 20 ასოზე მეტი")]
        [Display(Name = "სათაური")]
        public string title { get; set; }

        [Column(TypeName = "text")]
        [DataMember]
        [Required(ErrorMessage = "აუცილებელია კომენტარი")]
        [MinLength(5, ErrorMessage = "კომენტარი არ უნდა იყოს 5 ასოზე ნაკლები")]
        [MaxLength(200, ErrorMessage = "კომენტარი არ უნდა იყოს 200 ასოზე მეტი")]
        [Display(Name = "კომენტარი")]
        public string body { get; set; }

        public int userId { get; set; }

        public int categoryId { get; set; }

        public virtual CategoryContract Category { get; set; }

        public virtual UserContract Users { get; set; }

        public virtual ICollection<ReplyContract> Replies { get; set; }
    }
}