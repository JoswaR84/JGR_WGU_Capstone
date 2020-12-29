using JGR_WGU_Capstone.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace JGR_WGU_Capstone.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ApplicationDbContext>>()))
            {
                // Look for any movies.
                if (context.Computer.Any())
                {
                    return;   // DB has been seeded
                }

                context.Computer.AddRange(
                    new Computer
                    {
                        SerialNumber = "123",
                        Manufacturer = "Dell",
                        Model = "Latitude",
                        PurchaseDate = DateTime.Parse("01/27/2018")

                    },
                    new Computer
                    {
                        SerialNumber = "987",
                        Manufacturer = "Dell",
                        Model = "Latitude",
                        PurchaseDate = DateTime.Parse("03/04/2019")

                    },
                    new Computer
                    {
                        SerialNumber = "654",
                        Manufacturer = "Dell",
                        Model = "Optiplex",
                        PurchaseDate = DateTime.Parse("01/05/2020")

                    },
                    new Computer
                    {
                        SerialNumber = "852",
                        Manufacturer = "HP",
                        Model = "Spectre",
                        PurchaseDate = DateTime.Parse("04/20/2019")
                    },
                    new Computer
                    {
                        SerialNumber = "147",
                        Manufacturer = "HP",
                        Model = "Omen",
                        PurchaseDate = DateTime.Parse("05/30/2018")

                    },
                    new Computer
                    {
                        SerialNumber = "963",
                        Manufacturer = "HP",
                        Model = "Omen",
                        PurchaseDate = DateTime.Parse("07/07/2017")

                    }
                );
                context.SaveChanges();
                context.Maintenance.AddRange(
                    new Maintenance {
                        Notes = "Fixed the computer",
                        MaintenanceDate = DateTime.Parse("07/07/2019"),
                        ComputerID = 1
                    },
                    new Maintenance
                    {
                        Notes = "Fixed outlook",
                        MaintenanceDate = DateTime.Parse("09/25/2019"),
                        ComputerID = 1
                    },
                    new Maintenance
                    {
                        Notes = "Ran checkdisk",
                        MaintenanceDate = DateTime.Parse("12/07/2019"),
                        ComputerID = 2
                    }, 
                    new Maintenance
                    {
                        Notes = "Defragged HDD",
                        MaintenanceDate = DateTime.Parse("11/11/2020"),
                        ComputerID = 3
                    },
                    new Maintenance
                    {
                        Notes = "Scanned for viruses",
                        MaintenanceDate = DateTime.Parse("12/9/2019"),
                        ComputerID = 3
                    },
                    new Maintenance
                    {
                        Notes = "Installed MS Office 2016",
                        MaintenanceDate = DateTime.Parse("01/15/2020"),
                        ComputerID = 3
                    },
                    new Maintenance
                    {
                        Notes = "Replaced keyboard",
                        MaintenanceDate = DateTime.Parse("08/08/2019"),
                        ComputerID = 4
                    },
                    new Maintenance
                    {
                        Notes = "Installed new GPU",
                        MaintenanceDate = DateTime.Parse("11/28/2020"),
                        ComputerID = 4
                    },
                    new Maintenance
                    {
                        Notes = "Cleaned junk files",
                        MaintenanceDate = DateTime.Parse("09/24/2019"),
                        ComputerID = 5
                    },
                    new Maintenance
                    {
                        Notes = "Upgraded to Windows 10 Pro",
                        MaintenanceDate = DateTime.Parse("11/10/2019"),
                        ComputerID = 5
                    },
                    new Maintenance
                    {
                        Notes = "Removed viruses",
                        MaintenanceDate = DateTime.Parse("11/19/2019"),
                        ComputerID = 6
                    }
                );
                context.SaveChanges();
            }
        }
    }
}