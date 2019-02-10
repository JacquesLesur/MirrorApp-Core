using System;
using System.Net.Http;
using System.Web.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MirrorApp.Controllers
{
    [Route("api/[controller]")]
    public class AlexaController : Controller
    {
        [Route("")]
        [HttpGet]
        [HttpHead]
        public IHttpActionResult root()
        {
            return this.Ok("Im Alive");
        }
        [Route("api/alexaSample")]
        [HttpPost]
        public HttpResponseMessage AlexaSampleRequest()
        {
            var speechlet = new AlexaResponse();
            return speechlet.GetResponse(Request);
        }
        [Route("")]
        [HttpPost]
        public HttpResponseMessage Post()

        {
            return new AlexaResponse().g(Request);

        }
    }
}
