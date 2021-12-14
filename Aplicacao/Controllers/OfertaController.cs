using Servico.Tabelas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aplicacao.Controllers
{
    public class OfertaController : Controller
    {
        private ClienteServico clienteServico = new ClienteServico();

        // GET: Oferta
        public ActionResult Index()
        {
            return View(clienteServico.ObterObterTodosClientesNaoFinalizados());
        }

        public ActionResult Oferta(long? id)
        {
            return View(clienteServico.ObterClientePorId(id));
        }
    }
}