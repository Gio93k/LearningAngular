using System;

namespace ArticoliWebService.Dto
{
    public class ArticoliDto
    {


        public string CodArt { get; set; }
        public string Descrizione { get; set; }
        public string Um { get; set; }
        public string CodStat { get; set; }
        public Int16 PzCart { get; set; }
        public double? PesoNetto { get; set; }
        public DateTime? DataCreazione { get; set; }
    }
}