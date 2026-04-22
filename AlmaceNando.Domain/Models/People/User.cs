using AlmaceNando.Domain.Models.Base;
using AlmaceNando.Domain.Models.Inventory;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlmaceNando.Domain.Models.People
{
    public class User:BaseEntity
    {

        // Uno es para identificarlo 
        public string? Name { get; set; }
        // este es para ponerle nombre o numero segun lo que ya este identificado
        public string? UserName { get; set; }

        public string?  Identification { get; set; }
        public string? Password { get; set; }
        //Rol
        public string? Rol {  get; set; }
        public virtual ICollection<Sale> Sales { get; set; }

    }
}
