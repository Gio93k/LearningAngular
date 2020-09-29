using System.Collections.Generic;
using System.Linq;
using ArticoliWebService.Models;

namespace ArticoliWebService.Services
{
    public class ArticoliRepository : IArticoliRepository
    {
        AlphaShopDbContext _alphaShopDbContext;
        public ArticoliRepository(AlphaShopDbContext alphaShopDbContext)
        {
            this._alphaShopDbContext = alphaShopDbContext;
        }
        public ICollection<Articoli> SelArticoliByDescrizione(string Descrizione)
        {
            return this._alphaShopDbContext.Articoli
            .Where(a => a.Descrizione.Contains(Descrizione))
            .OrderBy(a => a.Descrizione)
            .ToList();
        }
        public Articoli SelArticoloByCodice(string Code)
        {
            return this._alphaShopDbContext.Articoli
            .Where(c => c.CodArt.Equals(Code))
            .FirstOrDefault();
        }
        public Articoli SelArticoloByEan(string Ean)
        {
            return this._alphaShopDbContext.Barcode
            .Where(c => c.BarCode.Equals(Ean))
            .Select(a => a.articolo)
            .FirstOrDefault();
        }
        public bool ArticoloExists(string code)
        {
            throw new System.NotImplementedException();
        }

        public bool DelArticoli(Articoli articolo)
        {
            throw new System.NotImplementedException();
        }

        public bool InsArticoli(Articoli articolo)
        {
            throw new System.NotImplementedException();
        }

        public bool Salva()
        {
            throw new System.NotImplementedException();
        }



        public bool UpdArticoli(Articoli articolo)
        {
            throw new System.NotImplementedException();
        }
    }
}