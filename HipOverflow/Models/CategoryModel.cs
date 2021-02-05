using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using WCF.DataContract;

namespace HipOverflow.Models
{
    public class CategoryModel
    {
        public int id { get; set; }

        [DataMember]
        [Required(ErrorMessage = "აუცილებელია კატეგორიის სახელი")]
        [MinLength(2, ErrorMessage = "კატეგორია არ უნდა იყოს 2 ასოზე ნაკლები")]
        [MaxLength(30, ErrorMessage = "კატეგორია არ უნდა იყოს 30 ასოზე მეტი")]
        [Display(Name = "კატეგორია")]
        public string categoryName { get; set; }

        public virtual ICollection<PostContract> Posts { get; set; }

        public virtual ICollection<UserContract> Users { get; set; }
    }
}