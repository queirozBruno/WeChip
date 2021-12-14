using Modelo.Tabelas;
using Servico.Tabelas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aplicacao.Controllers
{
    public class ClienteController : Controller
    {
        private ClienteServico clienteServico = new ClienteServico();

        //GET
        public ActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        public ActionResult Create(Cliente cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    clienteServico.GravarCliente(cliente);
                    return RedirectToAction("Create");
                }
                return View(cliente);
            }
            catch
            {
                return View(cliente);
            }
        }

    }
}