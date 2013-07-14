using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WoolBoxStudio.Models
{
    public class CraftShow
    {
        public virtual int CraftShowID { get; set; }

        [Required(ErrorMessage = "A city is required")]
        public virtual string City { get; set; }

        [Required(ErrorMessage = "A address is required")]
        public virtual string Address { get; set; }

        [Required(ErrorMessage = "Products are required")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Products Available")]
        public virtual string ProductsAvailable { get; set; }

        [Required(ErrorMessage = "A start date is required")]
        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        public virtual DateTime StartDate { get; set; }

        [Required(ErrorMessage = "A end date is required")]
        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        public virtual DateTime EndDate { get; set; }

        [Required(ErrorMessage = "A start time is required")]
        [DataType(DataType.Time)]
        [Display(Name = "Start Time")]
        public virtual DateTime StartTime { get; set; }

        [Required(ErrorMessage = "A end time is required")]
        [DataType(DataType.Time)]
        [Display(Name = "End Time")]
        public virtual DateTime EndTime { get; set; }
    }
}