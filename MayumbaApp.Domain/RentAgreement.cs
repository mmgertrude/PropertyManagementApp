using System;
using System.Collections.Generic;
using System.Text;

namespace EstatesAppDomain
{
   public class RentAgreement
    {
        public string Agreement_Id { get; set; }
        public string Occupant_NIN { get; set; }
        public string Property_Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        public int  Amount_Of_Initial_Deposite { get; set; }
        public string Per_Period_Charged { get; set; }
        public int Cost_Per_Period { get; set; }
        public Property Property { get; set; }
        public Occupant Occupant { get; set; }
    }
}
