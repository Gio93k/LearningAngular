using System.Collections.Generic;
using System.Threading.Tasks;
using ArticoliWebService.Dto;
using ArticoliWebService.Models;
using ArticoliWebService.Services;
using Microsoft.AspNetCore.Mvc;

namespace ArticoliWebService.Controllers
{
    [ApiController]
    [Produces("application/json")] //il formato di cosa produce
    [Route("api/articoli")]
    public class ArticoliController : Controller
    {
        //eseguo il code injection di articoli repository , uso l'interfaccia
        private IArticoliRepository _articoliRepository;

        public ArticoliController(IArticoliRepository articoliRepository)
        {
            this._articoliRepository = articoliRepository;
        }

        [HttpGet("cerca/descrizione/{filter}")]
        [ProducesResponseType(400)] //restituisce una badrequest di tipo 400
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ArticoliDto>))]
        /* restituisce ok se tutto è andato bene e restituirà una collezione di articoliDto 
         in formato json, è una classe stampo per le informazioni che vengono richieste*/

        public async Task<IActionResult> GetArticoliByDesc(string filter)
        {
            var articoliDtio = new List<ArticoliDto>();
            var articoli = await this._articoliRepository.SelArticoliByDescrizione(filter);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (articoli.Count == 0)
            {
                return NotFound(string.Format("Non è stato trovato alcun articolo con il filtro '{0}", filter));
            }

            //inseriamo in articoliDto , gli articoli veri venuti fuori con la query
            foreach (var articolo in articoli)
            {
                articoliDtio.Add(new ArticoliDto
                {
                    CodArt = articolo.CodArt,
                    Descrizione = articolo.Descrizione,
                    Um = articolo.Um,
                    CodStat = articolo.CodStat,
                    PzCart = articolo.PzCart,
                    PesoNetto = articolo.PesoNetto,
                    DataCreazione = articolo.DataCreazione
                });
            }
            return Ok(articoliDtio);
        }


        [HttpGet("cerca/codice/{CodArt}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(ArticoliDto))]
        public async Task<IActionResult> GetArtcoloByCode(string CodArt)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!(await this._articoliRepository.ArticoloExists(CodArt)))
            {
                return NotFound(string.Format("Non è stato trovato alcun articolo con il codice '{0}", CodArt));
            }
            var articoli = await this._articoliRepository.SelArticoloByCodice(CodArt);

            var articoliDto = new ArticoliDto
            {
                CodArt = articoli.CodArt,
                Descrizione = articoli.Descrizione,
                Um = articoli.Um,
                CodStat = articoli.CodStat,
                PesoNetto = articoli.PesoNetto,
                DataCreazione = articoli.DataCreazione
            };
            return Ok(articoliDto);
        }

        [HttpGet("cerca/barcode/{barcode}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(ArticoliDto))]
        public async Task<IActionResult> GetArtcoloByEan(string barcode)
        {
            var articoli = await this._articoliRepository.SelArticoloByEan(barcode);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (articoli == null)
            {
                return NotFound(string.Format("Non è stato trovato alcun articolo con il barcode '{0}", barcode));
            }
            var articoliDto = new ArticoliDto
            {
                CodArt = articoli.CodArt,
                Descrizione = articoli.Descrizione,
                Um = articoli.Um,
                CodStat = articoli.CodStat,
                PesoNetto = articoli.PesoNetto,
                DataCreazione = articoli.DataCreazione
            };
            return Ok(articoliDto);

        }





    }
}