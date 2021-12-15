using Modelo.Tabelas;
using Persistencia.DAL;
using System.Collections.Generic;

namespace Servico.Tabelas
{
    public class OfertaServico
    {
        private OfertaDAO ofertaDAO = new OfertaDAO();

        public void GravarOferta(Oferta oferta) => ofertaDAO.GravarOferta(oferta);

        public List<Oferta> ObterTodasOfertas() => ofertaDAO.ObterTodasOfertas();
    }
}
