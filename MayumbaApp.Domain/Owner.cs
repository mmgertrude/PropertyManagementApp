using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EstatesAppDomain
{
    public class Owner
    {
        [Key]
        public string Owner_NIN { get; set; }
        public string Owner_FName { get; set; }
        public string Owner_LName { get; set; }
        public string Address { get; set; }
        public List<Ownership> Ownerships { get; set; }

    }
}
