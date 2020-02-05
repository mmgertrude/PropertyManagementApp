using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EstatesAppDomain
{
   public class Occupant
    {
        [Key]
        public string Occupant_NIN { get; set; }
       // public int Agreement_Id { get; set; }

        public string Occupant_FName { get; set; }
        public string Occupant_LName { get; set; }
        public string OccupantType { get; set; }
        public string PhoneNumber1 { get; set; }
        public string PhoneNumber2 { get; set; }
        public string Email { get; set; }
        public string Notes { get; set; }
        public List<RentAgreement> RentAgreements { get; set; }
        public List<Payment> Payments  { get; set; }




    }
}
