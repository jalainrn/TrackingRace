using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackingRaceLibrary.Models
{
    public class RaceRunner
    {
        public int Id { get; set; }
        public int RaceId { get; set; }
        public int RunnerId { get; set; }
        public virtual Race Race { get; set; }
        public virtual Runner Runner { get; set; }
    }
}
