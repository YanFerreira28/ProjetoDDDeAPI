using SISControler.Domain.Contracts.Services;
using SISControler.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace SISControler.Application.Controllers
{
    [RoutePrefix("api/cliente")]
    public class ClienteController : ApiController
    {
        public readonly IServiceCliente _serviceCliente;

        public ClienteController(IServiceCliente serviceCliente)
        {
            _serviceCliente = serviceCliente;
        }

        // GET: api/Cliente
        [Route()]
        [HttpGet]
        [ResponseType(typeof(IEnumerable<Cliente>))]
        public IHttpActionResult GetAll()
        {
            var client = _serviceCliente.GetAll();
            return Ok(client);
        }

        // GET: api/Cliente/5
        [Route()]
        [ResponseType(typeof(Cliente))]
        public IHttpActionResult GetById(int id)
        {
            var client =  _serviceCliente.GetById(id);

            if (client == null)
                BadRequest();

            return Ok(client);
        }

        // POST: api/Cliente
        [HttpPost]
        [Route()]
        [ResponseType(typeof(void))]
        public IHttpActionResult Include(Cliente obj)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _serviceCliente.Insert(obj);
            _serviceCliente.Commit();

            return Created(new Uri(Request.RequestUri.AbsoluteUri), obj);
        }

        // PUT: api/Cliente/5
        [Route()]
        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult Update(Cliente obj)
        {

            if (!ModelState.IsValid)
                return BadRequest();

            _serviceCliente.Update(obj);
            _serviceCliente.Commit();

            return Ok(obj);
            
        }

        // DELETE: api/Cliente/5
        [Route()]
        [HttpDelete]
        [ResponseType(typeof(void))]
        public IHttpActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _serviceCliente.Delete(id);
            _serviceCliente.Commit();
            return Ok();
        }
    }
}
