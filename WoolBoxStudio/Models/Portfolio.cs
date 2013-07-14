using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WoolBoxStudio.Models
{
    public class Portfolio
    {
        public virtual int PortfolioID { get; set; }
        public virtual int CategoryID { get; set; }

        [Required(ErrorMessage = "A title is required")]
        public virtual string Title { get; set; }

        [Required(ErrorMessage = "A description is required")]
        [DataType(DataType.MultilineText)]
        public virtual string Description { get; set; }

        [Display(Name = "Image")]
        public virtual string ImageLink { get; set; }

        public virtual Category Category { get; set; }
    }
}