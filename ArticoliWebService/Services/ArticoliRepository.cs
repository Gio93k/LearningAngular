using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArticoliWebService.Models;
using Microsoft.EntityFrameworkCore;

namespace ArticoliWebService.Services
{
    public class ArticoliRepository : IArticoliRepository
    {
        AlphaShopDbContext _alphaShopDbContext;
        public ArticoliRepository(AlphaShopDbContext alphaShopDbContext)
        {
            this._alphaShopDbContext = alphaShopDbContext;
        }
        public async Task<ICollection<Articoli>> SelArticoliByDescrizione(string Descrizione)
        {
            return await this._alphaShopDbContext.Articoli
            .Where(a => a.Descrizione.Contains(Descrizione))
            .OrderBy(a => a.Descrizione)
            .ToListAsync();
        }
        public async Task<Articoli> SelArticoloByCodice(string Code)
        {
            return await this._alphaShopDbContext.Articoli
            .Where(c => c.CodArt.Equals(Code))
            .FirstOrDefaultAsync();
        }
        public async Task<Articoli> SelArticoloByEan(string Ean)
        {
            return await this._alphaShopDbContext.Barcode
            .Where(c => c.BarCode.Equals(Ean))
            .Select(a => a.articolo)
            .FirstOrDefaultAsync();
        }
        public async Task<bool> ArticoloExists(string code)
        {
            return await Task.FromResult<bool>(this._alphaShopDbContext.Articoli.Any(c => c.CodArt == code));
            /*
            La mia
            if (this._alphaShopDbContext.Articoli
            .Where(c => c.CodArt.Equals(code)).FirstOrDefault() != null) return true;
            else return  false;*/
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