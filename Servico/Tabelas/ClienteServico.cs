using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia.DAL;

namespace Servico.Tabelas
{
    public class ClienteServico
    {
        private ClienteDAO clienteDAO = new ClienteDAO();

        public IQueryable ObterTodosClientes() => clienteDAO.ObterTodosClientes();
    }
}
