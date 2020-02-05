using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EstatesAppDomain
{
    public class Ownership
    {
        public string Property_Id { get; set; }
        public string Owner_NIN { get; set; }

        public int Percent_Owned { get; set; }
        public Owner Owner  { get; set; }
        public Property Property { get; set; }

    }
}
