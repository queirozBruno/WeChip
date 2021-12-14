using Modelo.Tabelas;
using Persistencia.Context;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Persistencia.DAL
{
    public class ClienteDAO
    {
        private EFContext context = new EFContext();

        public void GravarCliente(Cliente cliente)
        {
            if (cliente.ClienteId == null) //Se ClienteId for nulo, então está criando um novo cliente, senão está alterando
            {
                context.Clientes.Add(cliente);
            }
            else
            {
                context.Entry(cliente).State = EntityState.Modified;
            }
            context.SaveChanges();
        }

        public IQueryable ObterTodosClientes() => context.Clientes;
    }
}
