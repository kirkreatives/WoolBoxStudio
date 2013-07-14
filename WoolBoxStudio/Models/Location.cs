using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WoolBoxStudio.Models
{
    public class Location
    {
        public virtual int LocationID { get; set; }

        [Required(ErrorMessage="A business is required")]
        public virtual string Business { get; set; }

        [Required(ErrorMessage="A city is required")]
        public virtual string City { get; set; }

        [Required(ErrorMessage = "A address is required")]
        public virtual string Address { get; set; }

        [Display(Name = "Image")]
        public virtual string ImageLink { get; set; }
    }
}