using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrackingRace.ViewModels
{
    public class RunnerListViewModel
    {
        public List<RunnerViewModel> Runners { get; set; }
        public int TotalRuners { get; set; }
    }
}