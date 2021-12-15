using Modelo.Tabelas;
using Persistencia.Context;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Persistencia.DAL
{
    public class OfertaProdutoDAO
    {
        private EFContext context = new EFContext();

        public void GravarOfertaProduto(OfertaProduto ofertaProduto)
        {
            if (ofertaProduto.OfertaProdutoId == null) //Se OfertaProdutoId for nulo, então está criando um novo registro, senão está alterando
            {
                context.OfertaProdutos.Add(ofertaProduto);
            }
            else
            {
                context.Entry(ofertaProduto).State = EntityState.Modified;
            }
            context.SaveChanges();
        }
    }
}
