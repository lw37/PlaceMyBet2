using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PlaceMyBet.Models;

namespace PlaceMyBet.Controllers
{
    public class EventosController : ApiController
    {
        // GET: api/Eventos
        public IEnumerable<EventoDTO> Get()
        {
            var repo = new EventosRepository();
            List<EventoDTO> eventos = repo.RetrieveDTO();
            return eventos;
        }


        // GET: api/Eventos/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Eventos
        public void Post([FromBody]Evento evento)
        {

                var repo = new EventosRepository();
                repo.save(evento);
            
        }

        // PUT: api/Eventos/5
        public void Put(int id, [FromBody]Evento evento)
        {
            var repo = new EventosRepository();

           
        }

        // DELETE: api/Eventos/5
        public void Delete(int id)
        {
        }
    }
}
