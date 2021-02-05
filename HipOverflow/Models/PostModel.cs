using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using WCF.DataContract;

namespace HeapOverflow.Models
{
    public class PostModel
    {
        public int id { get; set; }

        [Required(ErrorMessage = "სათაური აუცილებელია")]
        [MinLength(2, ErrorMessage = "სათაური არ უნდა იყოს 2 სიმბოლოზე ნაკლები")]
        [MaxLength(50, ErrorMessage = "სათაური არ უნდა იყოს 50 სიმბოლოზე მეტი")]
        [Display(Name = "სათაური")]
        public string title { get; set; }

        [Column(TypeName = "text")]
        [Required(ErrorMessage = "აუცილებელია კონტენტი")]
        [Display(Name = "კონტენტი")]
        public string body { get; set; }


        [Required(ErrorMessage = "კატეგორია არ არსებობს")]
        [Display(Name = "კატეგორია")]
        public string  Category { get; set; }

        [Required(ErrorMessage = "მომხმარებელი არ არსებობს")]
        [Display(Name = "მომხმარებელი")]
        public string  Users { get; set; }

        //[Required(ErrorMessage = "პასუხი არ არსებობს")]
        //[Display(Name = "პასუხი")]
        //public virtual ICollection<ReplyContract> Replies { get; set; }

        //[Required(ErrorMessage = "კატეგორია არ არსებობს")]
        //[Display(Name = "კატეგორია")]
        //public virtual CategoryContract Category { get; set; }

        //[Required(ErrorMessage = "მომხმარებელი არ არსებობს")]
        //[Display(Name = "მომხმარებელი")]
        //public virtual UserContract Users { get; set; }

        //[Required(ErrorMessage = "პასუხი არ არსებობს")]
        //[Display(Name = "პასუხი")]
        //public virtual ICollection<ReplyContract> Replies { get; set; }
    }
}