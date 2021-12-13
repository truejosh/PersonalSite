using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PersonalSiteMVC.UI.Models
{
    public class ContactViewModel
    {

        [Required(ErrorMessage = "**A Name is Required**")]
        public string Name { get; set; }

        [Required(ErrorMessage = "**An Email is Required**")]
        public string Email { get; set; }

        public string Subject { get; set; }

        [Required(ErrorMessage = "**Please Provide a Message**")]
        [UIHint("MultilineText")]
        public string Message { get; set; }

    }
}