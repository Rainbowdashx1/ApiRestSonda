using ApiRestSonda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using static ApiRestSonda.Models.Entities;

namespace ApiRestSonda.Controllers
{
    public class DemosondaController : ApiController
    {
        [HttpPost]
        [Route("api/RequestLogin")]
        public JsonResponse Post(RequestLogin RL)
        {
            MethodBD Mbd = new MethodBD(RL);
            return Mbd.ValidateLogin();
        }
        [HttpPost]
        [Route("api/RequestCreateUser")]
        public JsonResponse Post(RequestCreateUser RCU)
        {
            MethodBD Mbd = new MethodBD(RCU);
            return Mbd.CreateUser();
        }
    }
}
