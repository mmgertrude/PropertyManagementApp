using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EstatesAppDomain
{
    public class Manager
    {
        [Key]
        public string Manager_NIN { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Manager_FName { get; set; }
        public string Manager_LNane { get; set; }
        public string Address { get; set; }
        public int Salary { get; set; }
        public string MaritualStatus { get; set; }
        public DateTime DateHired { get; set; }
        public DateTime DateRetired { get; set; }
       // public byte Picture { get; set; }
        public List<Management> Managements { get; set; }


    }
}
