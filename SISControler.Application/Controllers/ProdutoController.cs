using SISControler.Domain.Contracts.Services;
using SISControler.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace SISControler.Application.Controllers
{
    [RoutePrefix("api/produto")]
    public class ProdutoController : ApiController
    {
        private readonly IServiceProduto _serviceProduto;

        public ProdutoController(IServiceProduto service)
        {
            _serviceProduto = service;
        }

        [Route()]
        [HttpGet]
        [ResponseType(typeof(IEnumerable<Produto>))]
        // GET: api/Produto
        public IHttpActionResult Get()
        {
            var x = _serviceProduto.GetAll();

            if (!ModelState.IsValid)
                return BadRequest();

            if (x == null)
                return BadRequest();

            return Ok(x);
        }

        [Route()]
        [HttpGet]
        [ResponseType(typeof(Produto))]
        // GET: api/Produto/5
        public IHttpActionResult Get(int id)
        {
            var x = _serviceProduto.GetById(id);

            if (!ModelState.IsValid)
                return BadRequest();

            if (x == null)
                return BadRequest();

            return Ok(x);
        }

        // POST: api/Produto
        [Route()]
        [HttpGet]
        [ResponseType(typeof(void))]
        public IHttpActionResult Post(Produto obj)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _serviceProduto.Insert(obj);
            _serviceProduto.Commit();

            return Created(new Uri(Request.RequestUri.AbsoluteUri), obj);
        }

        // PUT: api/Produto/5
        [Route()]
        [HttpGet]
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(Produto obj)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _serviceProduto.Update(obj);
            _serviceProduto.Commit();

            return Ok(obj);
        }

        // DELETE: api/Produto/5
        [Route()]
        [HttpGet]
        [ResponseType(typeof(void))]
        public IHttpActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _serviceProduto.Delete(id);
            _serviceProduto.Commit();

            return Ok();
        }
    }
}
