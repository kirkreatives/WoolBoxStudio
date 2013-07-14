using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WoolBoxStudio.Models
{
    public class About
    {
        public virtual int AboutID { get; set; }

        [Required(ErrorMessage="About me is required")]
        [DataType(DataType.MultilineText)]
        [Display(Name="About Me")]
        public virtual string AboutMe { get; set; }

        [Display(Name = "Image")]
        public virtual string ImageLink { get; set; }
    }
}