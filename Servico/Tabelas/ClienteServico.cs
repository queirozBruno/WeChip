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
                Status status = statusDAO.RecuperarStatusPorDescricao("Nome Livre");
                cliente.Status = status;
            }

            clienteDAO.GravarCliente(cliente);
        }

        public IQueryable ObterTodosClientes() => clienteDAO.ObterTodosClientes();
    }
}
