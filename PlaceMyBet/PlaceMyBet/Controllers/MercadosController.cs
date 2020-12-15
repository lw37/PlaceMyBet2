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
       /* public IEnumerable<MercadoDTO> Get()
        {
            var repo = new MercadosRepository();
            List<MercadoDTO> mercados = repo.RetrieveDTO();
            return mercados;
        }


        */
        // GET: api/Mercados?evento=val1&mercado=val2
       /*  public IEnumerable<Mercado> GetMercado(int evento,double mercado)
        {
           var repo = new MercadosRepository();
            List<Mercado> mercados = repo.RetrieveByMercadoEvento(evento,mercado);
            return mercados;
        }*/
        // GET: api/Mercados/5
        public IEnumerable<ApuestaDTO> Get(int id)
        {
            var repo = new MercadosRepository();
            List<ApuestaDTO> apuestas = repo.RetrieveDTO(id);
            return apuestas;
        }

        // POST: api/Mercados
        public void Post([FromBody]Mercado mercado)
        {
            var repo = new MercadosRepository();
            repo.Save(mercado);
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
