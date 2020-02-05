using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EstatesAppDomain
{
   public class PropertyType
    {
        [Key]
        public string PropertyType_Id { get; set; }
        public string PropertyType_Name { get; set; }
        public string PropertyType_Description { get; set; }
    }
}
