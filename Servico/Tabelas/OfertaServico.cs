using Modelo.Tabelas;
using Persistencia.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servico.Tabelas
{
    public class OfertaServico
    {
        private OfertaDAO ofertaDAO = new OfertaDAO();

        public void GravarOferta(Oferta oferta) => ofertaDAO.GravarOferta(oferta);
    }
}
