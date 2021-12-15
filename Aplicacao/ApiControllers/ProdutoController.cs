using Modelo.Tabelas;
using Servico;
using Servico.Tabelas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace Aplicacao.ApiControllers
{
    public class ProdutoController : ApiController
    {
        private ProdutoServico produtoServico = new ProdutoServico();
       
        // POST: api/Produto
        [ResponseType(typeof(Produto))]
        public IHttpActionResult Post(Produto produto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (produtoServico.VerificaSeJaExisteCodigoProduto(produto.ProdutoCodigo))
                {
                    return BadRequest("Produto já existe");
                }

                produtoServico.GravarProduto(produto);
                return StatusCode(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }       
    }
}
