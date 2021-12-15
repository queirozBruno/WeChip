using Modelo.Tabelas;
using Persistencia.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.DAL
{
    public class ProdutoDAO
    {
        private EFContext context = new EFContext();

        public IQueryable<Produto> ObterTodosProdutos() => context.Produtos;

        public double ValorProdutoPorId(double id) => context.Produtos.Where(p => p.ProdutoId == id).Select(p => p.ProdutoPreco).FirstOrDefault();
    }
}
