using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrackingRace.ViewModels
{
    public class SizeListViewModel
    {
        public List<SizeViewModel> Sizes { get; set; }
        public int TotalSizes { get; set; }
    }
}