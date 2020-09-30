using System.Collections.Generic;
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

        public IActionResult GetArticoliByDesc(string filter)
        {
            var articoliDtio = new List<ArticoliDto>();
            var articoli = this._articoliRepository.SelArticoliByDescrizione(filter);
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


    }
}