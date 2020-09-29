using System.ComponentModel.DataAnnotations;

namespace ArticoliWebService.Models
{
    public class Ean
    {
        public string CodArt { get; set; }

        [Key]
        [StringLength(13, MinimumLength = 8, ErrorMessage = "Il Barcode deve avere da 8 a 13 cifre")]
        public string BarCode { get; set; }

        [Required]
        public string IdTipoArt { get; set; }

        //proprietà collegamento classi (relazioni tabelle)
        public virtual Articoli articolo { get; set; } //realzione molti a uno , a tanti Barcode corrisponde un solo articolo 
    }
}