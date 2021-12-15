using Modelo.Tabelas;
using Persistencia.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.DAL
{
    public class ProdutoDAO
    {
        private EFContext context = new EFContext();

        public void GravarProduto(Produto produto)
        {
            if (produto.ProdutoId == null) //Se ClienteId for nulo, então está criando um novo cliente, senão está alterando
            {
                context.Produtos.Add(produto);
            }
            else
            {
                context.Entry(produto).State = EntityState.Modified;
            }
            context.SaveChanges();
        }

        public IQueryable<Produto> ObterTodosProdutos() => context.Produtos;

        public bool VerificaSeJaExisteCodigoProduto(string codigo) => context.Produtos.Where(p => p.ProdutoCodigo.Contains(codigo)).Any();

        public double ValorProdutoPorId(double id) => context.Produtos.Where(p => p.ProdutoId == id).Select(p => p.ProdutoPreco).FirstOrDefault();
    }
}
