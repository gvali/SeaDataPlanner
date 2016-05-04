using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Project
    {
        public int ProjectId { get; set; }
        [MaxLength(64)]
        public string ProjectName { get; set; }

        public int PersonId { get; set; }

        [Required]
        public virtual Person Person { get; set; }

        public virtual List<Person> Persons { get; set; } = new List<Person>(); 

    }
}
