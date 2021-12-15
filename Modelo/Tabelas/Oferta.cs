using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modelo.Tabelas
{
    public class Oferta
    {
        public long? OfertaId { get; set; }
        public long ClienteId { get; set; }

        [Display(Name = "Cep")]
        public string OfertaCep { get; set; }

        [Display(Name = "Rua")]
        public string OfertaRua { get; set; }

        [Display(Name = "Numero")]
        public string OfertaNumero { get; set; }

        [Display(Name = "Complemento")]
        public string OfertaComplemento { get; set; }

        [Display(Name = "Bairro")]
        public string OfertaBairro { get; set; }

        [Display(Name = "Cidade")]
        public string OfertaCidade { get; set; }

        [Display(Name = "Estado")]
        public string OfertaEstado { get; set; }

        public Cliente Cliente { get; set; }
    }
}
