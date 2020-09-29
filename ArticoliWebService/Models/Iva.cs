using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ArticoliWebService.Models
{
    public class Iva
    {
        [Key]
        public int IdIva { get; set; }
        public string Descrizione { get; set; }

        [Required]
        public Int16 Aliquota { get; set; }

        //proprietà relative al collegamento tra classi (relazioni tabelle)
        public virtual ICollection<Articoli> articoli { get; set; } //relazione uno a molti con articoli. ad un iva corrisponono molti articoli
    }
}