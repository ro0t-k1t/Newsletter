using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using static Newsletter.Models.Enums;

namespace Newsletter.Models
{
    public class Subscription
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string EmailAddress { get; set; }

        [Display(Name = "Where did you hear about us?")]
        [Required(ErrorMessage = "Please select one")]
        public Origin Origin { get; set; }

        [Display(Name = "Please specify other (optional)")]
        public string OriginOther { get; set; }

        [Display(Name = "Reason for signing up (optional)")]
        public string Reason { get; set; }

        [Display(Name = "Signed up at")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime DateTime { get; set; }
    }
}