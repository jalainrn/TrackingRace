using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackingRaceLibrary.Models
{
    public class Size
    {
        public int Id { get; set; }

        [StringLength(2)]
        public string Acronym { get; set; }

        [StringLength(10)]
        public string Name { get; set; }

        //[Required(ErrorMessage = "Gender is required")]
        //[Display(Name = "Gender:")]
        //public string Gender { get; set; }
    }
}
