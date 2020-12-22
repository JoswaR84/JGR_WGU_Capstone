using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace JGR_WGU_Capstone.Models
{
    public class Computer
    {
        public int ComputerID { get; set; }
        [Required]
        [Display(Name = "Serial Number")]
        public string SerialNumber { get; set; }
        [Required]
        public string Manufacturer { get; set; }
        [Required]
        public string Model { get; set; }
        [DataType(DataType.Date)]
        [Required]
        [Display(Name = "Purchase Date")]
        public DateTime PurchaseDate { get; set; }
        public ICollection<Maintenance> Maintenances { get; set; }
    }
}
