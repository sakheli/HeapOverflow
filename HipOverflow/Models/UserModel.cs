using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WCF.DataContract;

namespace HeapOverflow.Models
{
    public class UserModel
    {
        public int id { get; set; }

        [Required(ErrorMessage = "სახელი აუცილებელია")]
        [MinLength(2, ErrorMessage = "სახელი არ უნდა იყოს 2 სიმბოლოზე ნაკლები")]
        [MaxLength(50, ErrorMessage = "სახელი არ უნდა იყოს 20 სიმბოლოზე მეტი")]
        [Display(Name = "სახელი")]
        public string username { get; set; }

        [Required(ErrorMessage = "პაროლი აუცილებელია")]
        [MinLength(2, ErrorMessage = "პაროლი არ უნდა იყოს 2 სიმბოლოზე ნაკლები")]
        [MaxLength(50, ErrorMessage = "პაროლი არ უნდა იყოს 50 სიმბოლოზე მეტი")]
        [Display(Name = "პაროლი")]
        public string password { get; set; }

        [Required(ErrorMessage = "მომხმარებლის იმეილი აუცილებელია")]
        [Display(Name = "მომხმარებლის იმეილი")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }

        [Required(ErrorMessage = "როლი აუცილებელია")]
        [Display(Name = "მომხმარებლის როლი")]
        public RoleModel role { get; set; } 


        public int roleId { get; set; }

        public virtual CategoryContract Category { get; set; }

        public virtual ICollection<PostContract> Posts { get; set; }

        public virtual ICollection<ReplyContract> Replies { get; set; }

        public virtual RoleContract Roles { get; set; }
    }
}