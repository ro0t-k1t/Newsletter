using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Newsletter.Models
{
    public class Enums
    {
        public enum Origin
        {
            Advert = 0,
            [Display(Name = "Word of Mouth")]
            WordOfMouth = 1,
            Other = 2
        }
    }
}