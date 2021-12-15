using Modelo.Tabelas;
using Persistencia.DAL;
using System.Collections.Generic;
using System.Linq;

namespace Servico.Tabelas
{
    public class OfertaProdutoServico
    {
        private OfertaProdutoDAO ofertaProdutoDAO = new OfertaProdutoDAO();

        public void GravarOfertaProduto(OfertaProduto ofertaProduto) => ofertaProdutoDAO.GravarOfertaProduto(ofertaProduto);

        public IQueryable<Produto> ObterOfertaProdutoPorOfertaId(long id) => ofertaProdutoDAO.ObterOfertaProdutoPorOfertaId(id);
    }
}
