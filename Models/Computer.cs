using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace JGR_WGU_Capstone.Models
{
    public class Computer
    {
        public Computer(){}

        public Computer(string sn, string man, string mod, DateTime purDate) 
        {
            SerialNumber = sn;
            Manufacturer = man;
            Model = mod;
            PurchaseDate = purDate;
        }

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
