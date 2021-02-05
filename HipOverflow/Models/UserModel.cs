using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using WCF.DataContract;

namespace HipOverflow.Models
{
    public class UserModel
    {
        public int id { get; set; }

        [DataMember]
        [Required(ErrorMessage = "აუცილებელია სახელი")]
        [MinLength(2, ErrorMessage = "სახელი არ უნდა იყოს 2 ასოზე ნაკლები")]
        [MaxLength(20, ErrorMessage = "სახელი არ უნდა იყოს 20 ასოზე მეტი")]
        [Display(Name = "სახელი")]
        public string username { get; set; }

        [DataMember]
        [Required(ErrorMessage = "მიუთითეთ თქვენი პაროლი")]
        [Display(Name = "თქვენი პაროლი")]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [DataMember]
        [Required(ErrorMessage = "ელექტრონული ფოსტის მითითება აუცილებელია")]
        [Display(Name = "ელექტრონული ფოსტა")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }


        public int roleId { get; set; }

        public int? assignedCategory { get; set; }

        public virtual CategoryContract Category { get; set; }

        public virtual ICollection<PostContract> Posts { get; set; }

        public virtual ICollection<ReplyContract> Replies { get; set; }

        public virtual RoleContract Roles { get; set; }
    }
}