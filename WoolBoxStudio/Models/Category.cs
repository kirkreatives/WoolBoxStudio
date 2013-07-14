using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WoolBoxStudio.Models
{
    public class Category
    {
        public virtual int CategoryID { get; set; }

        [Required(ErrorMessage = "A category name is required")]
        [Display(Name="Category Name")]
        public virtual string Name { get; set; }
    }
}