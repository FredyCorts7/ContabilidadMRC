using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContabilidadMRC.Models
{
    public class DetailBill
    {
        //Properties Definition
        [Key]
        public int DetailBillID { get; set; }

        public int BillID { get; set; }

        public int ProductID { get; set; }

        [Display(Name = "Cantidad")]
        [Required]
        public int Quantity { get; set; }

        //Navigation Properties Definition

        public Bill Bill { get; set; }

        public Product Product { get; set; }

    }
}
