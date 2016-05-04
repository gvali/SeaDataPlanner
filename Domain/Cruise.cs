using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Cruise
    {
        public int CruiseId { get; set; }

        [MaxLength(64)]
        public string CruiseName { get; set; }

        [Required]
        public int PersonId { get; set; }
        public virtual Person Person { get; set; }

        public virtual List<Person> Persons { get; set; } = new List<Person>();

        public virtual List<Station> Stations { get; set; } = new List<Station>();

    }
}
