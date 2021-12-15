using Modelo.Tabelas;
using Persistencia.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servico.Tabelas
{
    public class ProdutoServico
    {
        private ProdutoDAO produtoDAO = new ProdutoDAO();

        public IQueryable<Produto> ObterTodosProdutos() => produtoDAO.ObterTodosProdutos();

        public double ValorProdutoPorId(double id) => produtoDAO.ValorProdutoPorId(id);

        public bool VerificaSeJaExisteCodigoProduto(string codigo) => produtoDAO.VerificaSeJaExisteCodigoProduto(codigo);

        public void GravarProduto(Produto produto) => produtoDAO.GravarProduto(produto);
    }
}
