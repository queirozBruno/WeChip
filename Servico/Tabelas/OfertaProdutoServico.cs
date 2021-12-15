using Modelo.Tabelas;
using Persistencia.DAL;

namespace Servico.Tabelas
{
    public class OfertaProdutoServico
    {
        private OfertaProdutoDAO ofertaProdutoDAO = new OfertaProdutoDAO();

        public void GravarOfertaProduto(OfertaProduto ofertaProduto) => ofertaProdutoDAO.GravarOfertaProduto(ofertaProduto);
    }
}
