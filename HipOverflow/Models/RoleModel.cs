using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using WCF.DataContract;

namespace HipOverflow.Models
{
    public class RoleModel
    {
        public int id { get; set; }

        [DataMember]
        [Required(ErrorMessage = "მიუთითეთ თქვენი როლი")]
        [MinLength(2, ErrorMessage = "როლი არ უნდა იყოს 2 ასოზე ნაკლები")]
        [MaxLength(100, ErrorMessage = "როლი არ უნდა იყოს 100 ასოზე მეტი")]
        [Display(Name = "თქვენი როლი")]
        public string roleName { get; set; }

        public virtual ICollection<UserContract> Users { get; set; }
    }
}