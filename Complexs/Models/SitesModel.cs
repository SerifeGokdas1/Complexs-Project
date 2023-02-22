using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Complexs.Models
{
    public class SitesModel
    {
        public int SiteId { get; set; }
        [Required(ErrorMessage = "It is mandatory to fill in the site name section.")]
        public string SiteName { get; set; }
        public string SiteLocation { get; set; }
        public string SiteManager { get; set; }
    }
}