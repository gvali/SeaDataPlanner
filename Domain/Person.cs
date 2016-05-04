using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Person
    {
        public int PersonId { get; set; }
        [MaxLength(128)]
        public string FirstName { get; set; }
        [MaxLength(128)]
        public string LastName { get; set; }


        public virtual List<Project> Projects { get; set; } = new List<Project>();

        public virtual List<Cruise> Cruises { get; set; } = new List<Cruise>();

        #region NotMapped
        public string FirstLastName => FirstName + " " + LastName;
        public string LastFirstName => LastName + " " + FirstName;
        #endregion
    }
}
