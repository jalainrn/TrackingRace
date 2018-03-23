using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrackingRace.ViewModels
{
    public class RaceTypeListViewModel
    {
        public List<RaceTypeViewModel> RaceTypes { get; set; }
        public int TotalRaceTypes { get; set; }
    }
}