using Persistencia.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.DAL
{
    public class ClienteDAO
    {
        private EFContext context = new EFContext();
        public IQueryable ObterTodosClientes() => context.Clientes;
    }
}
