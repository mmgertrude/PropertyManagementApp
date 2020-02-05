using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EstatesAppDomain
{
   public class Property
    {
        [Key]
        public string Property_Id { get; set; }
        public PropertyType propertyType { get; set; }
        public string Property_Address { get; set; }
        public int No_Of_bedrooms { get; set; }
        public int No_Of_bathrooms { get; set; }
        public int inside_area_size { get; set; }
        public  int No_Of_small_car_parking_area { get; set; }
        public bool Availability_Status { get; set; }
       // public byte Picture { get; set; }
        public List<Ownership> Ownerships { get; set; }
        public List<Management> Managements { get; set; }
        public List<RentAgreement> RentAgreements { get; set; }


    }
}
