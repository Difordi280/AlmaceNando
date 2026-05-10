using System;
using System.Collections.Generic;
using System.Text;

namespace AlmaceNando.Domain.Models.Base
{
    public abstract class BaseEntity
    {
        //Direccion Id  natural para cualquier tabla 
        public Guid Id { get; set; } = Guid.NewGuid();



        //Fecha  de creacion del dato 
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        

        //Para informar a la base de datos central de que el archivo se dio la orden de eliminarlo o no 
        public bool IsDeleted { get; set; }
        //Para informar al servidor central si el datos esta sincronizado o no 
        
       public bool SyncStatus { get; set; }


    }
}
