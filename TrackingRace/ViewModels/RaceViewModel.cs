﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using TrackingRaceLibrary.Models;

namespace TrackingRace.ViewModels
{
    public class RaceViewModel
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "The Name field is required")]
        [Display(Name = "Name:")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Date field is required")]
        [Display(Name = "Date:")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "The Race Type is required")]
        [Display(Name = "Race type:")]
        public int RaceTypeId { get; set; }

        [Display(Name = "Profit")]
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

        //[Required(ErrorMessage = "The State field is required")]
        //public StateViewModel State { get; set; }

        //[Required(ErrorMessage = "The Race Type field is required")]
        //public RaceTypeViewModel RaceType { get; set; }

        [Display(Name = "State:")]
        public string StateName { get; set; }

        [Display(Name = "Race Type:")]
        public string RaceTypeName { get; set; }
    }
}