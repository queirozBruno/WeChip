using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo.Tabelas;
using Persistencia.DAL;

namespace Servico.Tabelas
{
    public class ClienteServico
    {
        private ClienteDAO clienteDAO = new ClienteDAO();
        private StatusDAO statusDAO = new StatusDAO();

        public void GravarCliente(Cliente cliente)
        {
            if (cliente.ClienteId == null) // Se estiver CRIANDO um cliente, adiciona o objeto status que contém a descrição "Nome Livre". Se estiver ALTERANDO só chama o método GravarCliente()
            {
                cliente.StatusId = statusDAO.ObterIdStatusPorDescricao("Nome Livre");
            }

            clienteDAO.GravarCliente(cliente);
        }

        public Cliente ObterClientePorId(long? id) => clienteDAO.ObterClientePorId(id);

        public IQueryable ObterTodosClientes() => clienteDAO.ObterTodosClientes();

        public IQueryable ObterObterTodosClientesNaoFinalizados() => clienteDAO.ObterTodosClientesNaoFinalizados();
    }
}
