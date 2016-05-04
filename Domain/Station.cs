using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Station
    {
        public int StationId { get; set; }

        [MaxLength(16)]
        public string StationName { get; set; }

        public float StatLon { get; set; }

        public float StatLat { get; set; }

        public virtual List<Cruise> Cruises { get; set; } = new List<Cruise>();

    }
}
