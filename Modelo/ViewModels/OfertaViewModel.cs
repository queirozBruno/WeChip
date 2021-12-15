using Modelo.Tabelas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.ViewModels
{
    /// <summary>
    ///  Classe usada na View do cadastro de oferta. Responsável por agrupar todos os objetos necessários na View.
    /// </summary>
    public class OfertaViewModel
    {
        public Cliente Cliente { get; set; }
        public Oferta Oferta { get; set; }
        public IQueryable<Produto> Produtos { get; set; }
        public IQueryable<Status> Statuses { get; set; }
    }
}
