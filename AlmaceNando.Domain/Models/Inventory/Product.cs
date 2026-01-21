using AlmaceNando.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlmaceNando.Domain.Models.Inventory
{
    internal class Product:BaseEntity
    {

        public string Name { get; set; }
        //Fecha de ultima actualizacion de datos
        public DateTime UpdateAt { get; set; } = DateTime.Now;

        public int Stock { get; set; }
        // El precio actualizado del producto al cual se deberia vender
        public decimal CurrentPrice { get; set; }
        //La marca del producto para poderlo usr en el buscador
        public string Brand { get; set; }

        // codigo interno que puede ayudar a buscar         
        public string ProductCode { get; set; }
        //conjunto de palabras que podrian definir el producto
        //entre mas palabras hayan mas facil se supone que debe ser para 
        //encontrar el producto

        public string keyword { get; set; }

        //Columna derivada, para buscar objetos
        //REACONDIONAR CUANDO SEPAS, USAR LINQ
             //--->FALTA UNA COLUMNA<---//
             //SEARCHKEYWORD
        



    }
}
