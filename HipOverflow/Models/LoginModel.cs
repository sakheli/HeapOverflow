using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace HipOverflow.Models
{
    public class LoginModel
    {
        [DataMember]
        [Required(ErrorMessage = "აუცილებლად მიუთითეთ თქვენი იმეილი")]
        [Display(Name = "თქვენი იმეილი")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataMember]
        [Required(ErrorMessage = "აუცილებლად მიუთითეთ პაროლი")]
        [MinLength(2, ErrorMessage = "როლი არ უნდა იყოს 2 ასოზე ნაკლები")]
        [MaxLength(30, ErrorMessage = "როლი არ უნდა იყოს 100 ასოზე მეტი")]
        [Display(Name = "თქვენი პაროლი")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}