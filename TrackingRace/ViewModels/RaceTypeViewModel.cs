using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrackingRace.ViewModels
{
    public class RaceTypeViewModel
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "Type name is required")]
        [Display(Name = "Name:")]
        [StringLength(20)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Distance is required. It must be specified in kilometers")]
        [Display(Name = "Distance (Km):")]
        [Range(1, 42, ErrorMessage = "Please enter a valid number between 1 and 42")]
        public int DistanceKm { get; set; }
    }
}