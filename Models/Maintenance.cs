using System;
using System.ComponentModel.DataAnnotations;

namespace JGR_WGU_Capstone.Models
{
    public class Maintenance
    {
        [Required]
        public int MaintenanceID { get; set; }
        [Required]
        public string Notes { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Maintenance Date")]
        public DateTime MaintenanceDate { get; set; }
        [Required]
        public int ComputerID { get; set; }
        public Computer Computer { get; set; }
    }
}
