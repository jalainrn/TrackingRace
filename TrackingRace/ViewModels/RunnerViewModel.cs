﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TrackingRaceLibrary.Models;

namespace TrackingRace.ViewModels
{
    public class RunnerViewModel
    {
        public int? Id { get; set; }

        [DisplayName("First Name:")]
        [Required(ErrorMessage = "The First Name field is required")]
        [StringLength(20)]
        public string FName { get; set; }

        [DisplayName("Last Name:")]
        [Required(ErrorMessage = "The Last Name field is required")]
        [StringLength(20)]
        public string LName { get; set; }
        //public string Address { get; set; }
        //public string City { get; set; }
        //public string StateId { get; set; }
        //public int ZipCode { get; set; }

        [DisplayName("Size:")]
        [Required(ErrorMessage = "The Size field is required")]
        public int SizeId { get; set; }

        [DisplayName("Gender:")]
        [Required(ErrorMessage = "The Gender field is required")]
        public string GenderId { get; set; }

        [DisplayName("Date of Birthday:")]
        [Required(ErrorMessage = "The Date of Birthday field is required")]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }

        [DisplayName("Email:")]
        [Required(ErrorMessage = "The Email field is required")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        [DisplayName("Phone:")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid Phone number")]
        public string Phone { get; set; }


        public bool IsTrue => true;

        [Required]
        [DisplayName("I agree to the TrackingRace Agreement and Waiver")]
        [Compare(nameof(IsTrue), ErrorMessage = "I agree to the TrackingRace Agreement and Waiver")]
        public bool WaiverAgreement { get; set; }

        public virtual List<RaceViewModel> Races { get; set; }

        //Support Properties 
        [Required(ErrorMessage = "Please select a Race")]
        public int RaceId { get; set; }
        public string RaceName { get; set; }

        [DisplayName("Size:")]
        public string SizeName { get; set; }
        public Size Size { get; set; }


        [DisplayName("Gender:")]
        public string GenderName { get; set; }
        public Gender Gender { get; set; }


    }
}