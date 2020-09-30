using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ArticoliWebService.Models
{
    public class Articoli
    {
        [Key]
        [MinLength(5, ErrorMessage = "Il numero minimo di caratteri è 5")]
        [MaxLength(30, ErrorMessage = "Il numero massimo di caratteri è 30")]
        public string CodArt { get; set; }

        [MinLength(5, ErrorMessage = "La descrizione deve avere minimo caratteri è 5")]
        [MaxLength(80, ErrorMessage = "La descrizione deve avere massimo caratteri è 80")]
        public string Descrizione { get; set; }
        public string Um { get; set; }
        public string CodStat { get; set; }
        [Range(0, 100, ErrorMessage = "I pezzi per cartone devono essere compresi fra 0 e 100")]
        public Int16 PzCart { get; set; }
        [Range(0.01, 100, ErrorMessage = "Il peso deve essere compreso fra 0.01 e 100")]
        public double? PesoNetto { get; set; }
        public int? IdIva { get; set; }
        public int? IdFamAss { get; set; }
        public string IdStatoArt { get; set; }
        public DateTime? DataCreazione { get; set; }

        //proprietà di collegamento classi (relazione tra tabelle)
        public virtual ICollection<Ean> barcode { get; set; } //relazione 1 a molti , 1 articolo -> molti barcode
        public virtual Ingredienti ingredienti { get; set; } //realzione 1 a 1 con la tab ingredienti 

        public virtual Iva iva { get; set; } //relazione molti a uno con la tabella IVA

        public virtual FamAssort famAssort { get; set; }

    }
}