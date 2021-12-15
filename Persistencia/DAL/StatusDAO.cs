using Modelo.Tabelas;
using Persistencia.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.DAL
{
    public class StatusDAO
    {
        private EFContext context = new EFContext();

        // Consultas utilizando LINQ e Expressões LAMBDA
        public long ObterIdStatusPorDescricao(string descricao) => context.Status.Where(s => s.StatusDescricao == descricao).Select(s => (long)s.StatusId).FirstOrDefault();

        public IQueryable<Status> ObterTodosStatus() => context.Status;
    }
}
