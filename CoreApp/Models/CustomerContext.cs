using System.Collections.Generic;

namespace CoreApp.Models
{
    public class CustomerContext
    {
        public static List<Customer> Customers = new List<Customer>()
        {
            new Customer{Adi="nedim",Soyadi="akbaş",TelefonNo="531"},
            new Customer{Adi="kaan",Soyadi="akbaş",TelefonNo="532"},
            new Customer{Adi="uğur",Soyadi="özcan",TelefonNo="533"},
            new Customer{Adi="yağız",Soyadi="akbaş",TelefonNo="534"}
        };
    }
}
