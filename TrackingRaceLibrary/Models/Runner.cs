using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackingRaceLibrary.Models
{
    public class Runner
    {
        public int Id { get; set; }

        [StringLength(20)]
        public string FName { get; set; }

        [StringLength(20)]
        public string LName { get; set; }
        //public string Address { get; set; }
        //public string City { get; set; }
        //public string StateId { get; set; }
        //public int ZipCode { get; set; }
        public int SizeId { get; set; }
        public Size Size { get; set; }

        public string GenderId { get; set; }
        public Gender Gender { get; set; }

        public DateTime DOB { get; set; }

        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        public bool WaiverAgreement { get; set; }

        public virtual List<Race> Races { get; set; }

    }
}
