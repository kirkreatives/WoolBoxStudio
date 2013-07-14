using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WoolBoxStudio.Models
{
    public class HomeCarousel
    {
        public virtual int HomeCarouselID { get; set; }

        [Required(ErrorMessage = "A description is required")]
        public virtual string Description { get; set; }

        [Display(Name = "Image")]
        public virtual string ImageLink { get; set; }
    }
}