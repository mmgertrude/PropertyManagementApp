using System;

namespace EstatesAppDomain
{
    public class Payment
    {
        //for navigation (compulsary)

        public string Bill_Id { get; set; }
        public string Occupant_NIN { get; set; }
        //optional
        public Bill Bill { get; set; }
        public Occupant Occupant { get; set; }

    }
}
