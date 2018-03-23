using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrackingRace.ViewModels
{
    public class RaceListViewModel
    {
        public List<RaceViewModel> Races { get; set; }
        public int TotalRaces { get; set; }
    }
}