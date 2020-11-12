using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PlaceMyBet.Models;

namespace PlaceMyBet.Controllers
{
    public class MercadosController : ApiController
    {
        // GET: api/Mercados
        public IEnumerable<Mercado> Get()
        {
            var repo = new MercadosRepository();
            List<Mercado> mercados = repo.Retrieve();
            return mercados;
        }
        // GET: api/Mercados?evento=val1&mercado=val2
        public IEnumerable<Mercado> GetMercado(int evento,double mercado)
        {
            var repo = new MercadosRepository();
            List<Mercado> mercados = repo.RetrieveByMercadoEvento(evento,mercado);
            return mercados;
        }


        // GET: api/Mercados/5
        public Mercado Get(int id)
        {
            var repo = new MercadosRepository();
            Mercado mercado = repo.Retrieve(id);
            return mercado;
        }

        // POST: api/Mercados
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Mercados/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Mercados/5
        public void Delete(int id)
        {
        }
    }
}
