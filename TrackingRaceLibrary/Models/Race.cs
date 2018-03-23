using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackingRaceLibrary.Models
{
    public class Race
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The Name field is required")]
        [Display(Name = "Name:")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Date field is required")]
        [Display(Name = "Date:")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "The Race Type is required")]
        [Display(Name = "Race type:")]
        public int RaceTypeId { get; set; }

        [Display(Name = "Profit:")]
        public bool Profit { get; set; }

        [Required(ErrorMessage = "The Address field is required")]
        [Display(Name = "Address:")]
        [StringLength(100)]
        public string Address { get; set; }

        [Required(ErrorMessage = "The City field is required")]
        [Display(Name = "City:")]
        [StringLength(20)]
        public string City { get; set; }

        [Required(ErrorMessage = "The State field is required")]
        [Display(Name = "State:")]
        public int StateId { get; set; }

        [Required(ErrorMessage = "The Zip Code field is required")]
        [Display(Name = "Zip Code:")]
        public int ZipCode { get; set; }


        public State State { get; set; }
        public RaceType RaceType { get; set; }
    }
}
