using Modelo.Tabelas;
using Persistencia.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servico.Tabelas
{
    public class StatusServico
    {
        private StatusDAO statusDAO = new StatusDAO();

        public IQueryable<Status> ObterTodosStatus() => statusDAO.ObterTodosStatus();
    }
}
