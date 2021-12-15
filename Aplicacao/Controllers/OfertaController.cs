using Modelo.ViewModels;
using Servico.Tabelas;
using Modelo.Tabelas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;

namespace Aplicacao.Controllers
{
    public class OfertaController : Controller
    {
        private ClienteServico clienteServico = new ClienteServico();
        private ProdutoServico produtoServico = new ProdutoServico();
        private StatusServico statusServico = new StatusServico();
        private OfertaServico ofertaServico = new OfertaServico();
        private OfertaProdutoServico ofertaProdutoServico = new OfertaProdutoServico();

        // GET: Oferta
        public ActionResult Index()
        {
            return View(clienteServico.ObterObterTodosClientesNaoFinalizados());
        }

        // GET: Oferta/Oferta
        public ActionResult Oferta(long? id)
        {            
            try
            {
                var cliente = clienteServico.ObterClientePorId(id);
                var produtos = produtoServico.ObterTodosProdutos();
                var status = statusServico.ObterTodosStatus();
                OfertaViewModel ofertaViewModel = new OfertaViewModel { Cliente = cliente, Produtos = produtos, Statuses = status };
                return View(ofertaViewModel);
            }
            catch (Exception)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }            
        }

        // POST: Oferta/Oferta
        [HttpPost]
        public ActionResult Oferta(OfertaViewModel ofertaViewModel, FormCollection formCollection)
        {
            ViewBag.Erro = "";
            try
            {           
                // Para descobrir os produtos selecionados com checkbox, vindo da View, é percorrido o formCollection e, se tiver algum item que contenha o valor "Produto" e esse item contenha 
                // a chave "true,false", ou seja, teve o checkbox marcado, então removemos a string produto, para restar somente o id do produto no valor do item, e adicionamos o id na lista.
                List<long> listProduto = new List<long>();
                foreach (var item in formCollection)
                {
                    if (item.ToString().Contains("Produto"))
                    {
                        if (formCollection[item.ToString()].ToString() == "true,false")
                        {
                            listProduto.Add(long.Parse(item.ToString().Replace("Produto", "")));
                        }
                    }
                }

                // Recupera o id do status marcado com radio button na View
                long status = long.Parse(formCollection["item.StatusId"].ToString());

                // Instancia e passa os valores da view, para o objeto oferta, para gravar no BD
                Oferta oferta = new Oferta();
                oferta.ClienteId = (long)ofertaViewModel.Cliente.ClienteId;
                oferta.OfertaBairro = ofertaViewModel.Oferta.OfertaBairro;
                oferta.OfertaCep = ofertaViewModel.Oferta.OfertaCep;
                oferta.OfertaCidade = ofertaViewModel.Oferta.OfertaCidade;
                oferta.OfertaComplemento = ofertaViewModel.Oferta.OfertaComplemento;
                oferta.OfertaEstado = ofertaViewModel.Oferta.OfertaEstado;
                oferta.OfertaNumero = ofertaViewModel.Oferta.OfertaNumero;
                oferta.OfertaRua = ofertaViewModel.Oferta.OfertaRua;
                ofertaServico.GravarOferta(oferta);

                // Para cada produto ofertado será gravado na tabela OfertaProduto e será subtraído o valor do crédito do cliente pelo valor do produto
                double creditoCliente = ofertaViewModel.Cliente.ClienteCredito;
                if (listProduto.Count > 0)
                {
                    OfertaProduto ofertaProduto = null;
                    foreach (var item in listProduto)
                    {
                        ofertaProduto = new OfertaProduto { OfertaId = (long)oferta.OfertaId, ProdutoId = item};
                        ofertaProdutoServico.GravarOfertaProduto(ofertaProduto);
                        creditoCliente -= produtoServico.ValorProdutoPorId(item);
                    }
                }            

                // Instancia e passa os valores da view, para o objeto cliente, para fazer as alterações na tabela
                Cliente cliente = new Cliente();
                cliente.ClienteId = ofertaViewModel.Cliente.ClienteId;
                cliente.ClienteCpf = ofertaViewModel.Cliente.ClienteCpf;
                cliente.ClienteCredito = creditoCliente;
                cliente.ClienteNome = ofertaViewModel.Cliente.ClienteNome;
                cliente.ClienteTelefone = ofertaViewModel.Cliente.ClienteTelefone;
                cliente.StatusId = status;
                clienteServico.GravarCliente(cliente); //Grava as alterações na tabela Cliente                
            }
            catch (Exception e)
            {
                ViewBag.Erro = e.Message;
            }
            return RedirectToAction("Index");
        }
    }
}