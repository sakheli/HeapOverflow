using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HeapOverflow.Models
{
    public class CategoryModel
    {
        public int id { get; set; }


        [Required(ErrorMessage = "კატეგორიის სახელი აუცილებელია")]
        [MinLength(2, ErrorMessage = "კატეგორიის სახელი არ უნდა იყოს 2 სიმბოლოზე ნაკლები")]
        [MaxLength(50, ErrorMessage = "კატეგორიის სახელი არ უნდა იყოს 50 სიმბოლოზე მეტი")]
        [Display(Name = "კატეგორიის სახელი")]
        public string categoryName { get; set; }
    }
}