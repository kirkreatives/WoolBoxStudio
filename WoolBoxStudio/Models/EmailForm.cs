using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace WoolBoxStudio.Models
{
    public class EmailForm
    {
        [Required(ErrorMessage="A name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage="A valid email is required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage="A subject is required")]
        public string Subject { get; set; }

        [Required(ErrorMessage="A message is required")]
        [DataType(DataType.MultilineText)]
        public string Message { get; set; }
    }
}