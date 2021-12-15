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
    public class OfertaDAO
    {
        private EFContext context = new EFContext();

        public void GravarOferta(Oferta oferta)
        {
            if (oferta.OfertaId == null) //Se OfertaId for nulo, então está criando uma nova oferta, senão está alterando
            {
                context.Ofertas.Add(oferta);
            }
            else
            {
                context.Entry(oferta).State = EntityState.Modified;
            }
            context.SaveChanges();
        }
    }
}
