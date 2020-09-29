using System.ComponentModel.DataAnnotations;

namespace ArticoliWebService.Models
{
    public class Ingredienti
    {
        [Key]
        public string CodArt { get; set; }
        public string Info { get; set; }

        //proprietà collegamento tra classi (relazioni tabelle)
        public virtual Articoli articolo { get; set; } //relazione 1 a 1 con la tabella Articoli

    }
}