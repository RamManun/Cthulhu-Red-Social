using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialNetwork1._1.Models
{
    public class SearchModel
    {
        public String UserName { get; set; }
        public String SurName { get; set; }
        public int? AgeMin { get; set; }
        public int? AgeMax { get; set; }
        public string Gender { get; set; }
    }
}