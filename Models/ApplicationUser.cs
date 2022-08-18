using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using System;

namespace Blog_Sitesi.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public DateTime? DogumTarihi { get; set; }
        [NotMapped]
        public string FullName
        {
            get
            {
                return Ad + " " + Soyad;
            }
        }
        public string Phone { get; set; }

        public Gender Gender { get; set; }
    }
}
