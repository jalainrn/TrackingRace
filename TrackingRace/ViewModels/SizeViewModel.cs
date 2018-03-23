using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrackingRace.ViewModels
{
    public class SizeViewModel
    {
        public int? Id { get; set; }

        [StringLength(2)]
        [DisplayName("Acronym:")]
        [Required(ErrorMessage = "The Acronym field is required")]
        public string Acronym { get; set; }

        [StringLength(10)]
        [DisplayName("Name:")]
        [Required(ErrorMessage = "The Name field is required")]
        public string Name { get; set; }
    }
}