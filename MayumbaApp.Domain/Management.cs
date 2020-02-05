using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EstatesAppDomain
{
   public class Management
    {
        public string PropertyId { get; set; }
        
        public string Manager_NIN { get; set; }
        public Manager Manager { get; set; }
        public Property Property { get; set; }
    }
}
