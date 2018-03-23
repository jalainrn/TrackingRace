using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrackingRace.ViewModels
{
    public class StateViewModel
    {

        public int? Id { get; set; }

        [DisplayName("Name:")]
        [StringLength(50)]
        [Required(ErrorMessage = "The Name field is required")]
        public string Name { get; set; }

        [DisplayName("Acronym:")]
        [StringLength(2)]
        [Required(ErrorMessage = "The Acronym field is required")]
        public string Acronym { get; set; }
    }
}