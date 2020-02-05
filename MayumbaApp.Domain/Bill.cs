using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EstatesAppDomain
{
    public class Bill
    {
        [Key]
        public string Bill_Id { get; set; }
        public int FullAmountToPay { get; set; }
        public DateTime DueDate { get; set; }
        public string Payment_Method { get; set; }
        public List<Payment> Payments { get; set; }



    }

}
