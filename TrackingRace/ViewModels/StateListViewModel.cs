using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrackingRace.ViewModels
{
    public class StateListViewModel
    {
        public List<StateViewModel> States { get; set; }
        public int TotalStates { get; set; }
    }
}