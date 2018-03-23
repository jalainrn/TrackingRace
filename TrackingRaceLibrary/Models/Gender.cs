using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackingRaceLibrary.Models
{
    public class Gender
    {
        [StringLength(1)]
        public string Id { get; set; }

        [StringLength(8)]
        public string Name { get; set; }
    }
}
