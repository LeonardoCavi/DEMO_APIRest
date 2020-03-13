using Demo_WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Demo_WebAPI.Controllers
{
    public class ClientController : ApiController
    {

        //public ClientController()
        //{

        //}

        private static List<Client> Clients = new List<Client>();

        [HttpGet]
        public List<Client> Get()
        {
            return Clients;
        }

        [HttpPost]
        public IHttpActionResult Post(Client client)
        {
            if (string.IsNullOrEmpty(client.Name)) { return BadRequest("Not a valid client name!"); }
            else if (client.Age < 0 && client.Age > 120) { return BadRequest("Not a valid age name!"); }
            else if (string.IsNullOrEmpty(client.Profession)) { return BadRequest("Not a valid client profession!"); }
            else
            {
                int? Id = Clients.Count > 0 ? Convert.ToInt32(Clients[Clients.Count - 1].Id): 0;

                if(Id == 0 || Id == null)
                {
                    Id = 1;
                }
                else
                {
                    Id++;
                }

                Clients.Add(new Client(Id, client.Name, client.Age, client.Profession));
                return Ok();
            }           
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var itemToRemove = Clients.SingleOrDefault(r => r.Id == id);

            if(itemToRemove != null)
            {
                Clients.Remove(itemToRemove);
                return Ok();
            }
            else
            {
                return BadRequest("Not a valid client ID!");
            }
        }
    }
}
