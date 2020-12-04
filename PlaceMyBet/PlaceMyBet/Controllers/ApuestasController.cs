using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PlaceMyBet.Models;

namespace PlaceMyBet.Controllers
{
    public class ApuestasController : ApiController
    {
      // GET:api/Apuestas
        //[Authorize(Roles ="Admin")]
        public IEnumerable<ApuestaDTO> Get()
        {
            var repo = new ApuestasRepository();
            List<ApuestaDTO> apuestas = repo.RetrieveDTO();
            return apuestas;
        }
        // GET: api/Apuestas?email=vl1&tipoMercado=vl2
    /*    public IEnumerable<ApuestaDTO> GetEmail(string email,double tipoMercado)
        {
            var repo = new ApuestasRepository();
            List<ApuestaDTO> apuestas = repo.RetrieveDTObyEmail(email,tipoMercado);
            return apuestas;
        }
        // GET: api/Apuestas?idmercado=1&email=luo.luo.ll14@gmail.com
      /*  public IEnumerable<ApuestaDTOmer> GetMercado(int idMercado, string email)
        {
            var repo = new ApuestasRepository();
            List<ApuestaDTOmer> apuestas = repo.RetrieveDTObyMercado(idMercado,email);
            return apuestas;
        }*/
        // GET: api/Apuestas/5
        public Apuesta Get(int id)
        {
            var repo = new ApuestasRepository();
            Apuesta apuesta = repo.Retrieve(id);
            return apuesta;
        }

        // POST: api/Apuestas
        //[Authorize]
        public void Post([FromBody]Apuesta apuesta)
        {
            var repo = new ApuestasRepository();
            repo.Save(apuesta);
        }

        // PUT: api/Apuestas/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Apuestas/5
        public void Delete(int id)
        {
          
            
        }
    }
}
