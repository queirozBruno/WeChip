using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Modelo.Tabelas;
using Modelo.ViewModels;
using Servico.Tabelas;
using Modelo.ApiModels;

namespace Aplicacao.ApiControllers
{
    public class VendasController : ApiController
    {
        private OfertaServico ofertaServico = new OfertaServico();
        private OfertaProdutoServico ofertaProdutoServico = new OfertaProdutoServico();

        // GET: api/Vendas
        public List<Vendas> Get()
        {
            Oferta oferta = null;
            List<Vendas> listVendas = new List<Vendas>();
            IQueryable<Produto> listProdutos = null;
            Vendas vendas = null;
            List<Oferta> ofertas = ofertaServico.ObterTodasOfertas();
            double somaProdutos = 0;

            foreach (var item in ofertas)
            {
                item.Cliente.Ofertas = null;
                oferta = new Oferta
                {
                    OfertaId = item.OfertaId,
                    OfertaBairro = item.OfertaBairro,
                    ClienteId = item.ClienteId,
                    OfertaCep = item.OfertaCep,
                    OfertaCidade = item.OfertaCidade,
                    OfertaComplemento = item.OfertaComplemento,
                    OfertaEstado = item.OfertaEstado,
                    OfertaNumero = item.OfertaNumero,
                    OfertaRua = item.OfertaRua
                };

                listProdutos = ofertaProdutoServico.ObterOfertaProdutoPorOfertaId((long)oferta.OfertaId);
                foreach (var itemProdutos in listProdutos)
                {
                    somaProdutos += itemProdutos.ProdutoPreco;
                }
                vendas = new Vendas { Cliente = item.Cliente, Oferta = oferta, Produtos = listProdutos, Total = somaProdutos };
                listVendas.Add(vendas);
            }

            return listVendas;
        }
    }
}
