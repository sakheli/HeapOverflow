﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HeapOverflow.Models
{
    public class LoginModel
    {
        //[Display(Name = "Id")]
        //public int Id { get; set; }

        [Required(ErrorMessage = "მომხმარებლის იმეილი აუცილებელია")]
        [Display(Name = "მომხმარებლის იმეილი")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [Required(ErrorMessage = "პაროლი აუცილებელია")]
        [MinLength(2, ErrorMessage = "სახელი არ უნდა იყოს 2 სიმბოლოზე ნაკლები")]
        [MaxLength(30, ErrorMessage = "სახელი არ უნდა იყოს 30 სიმბოლოზე მეტი")]
        [Display(Name = "პაროლი")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}