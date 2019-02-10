using Alexa.NET.Request;
using Alexa.NET.Response;
using Microsoft.AspNetCore.Mvc;
using MirrorApp.Worker;
using System.Net.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MirrorApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlexaController : ControllerBase
    {
        [HttpPost]
        [Route("")]
        public SkillResponse post(SkillRequest input)

        {
            AlexaResponse alexaResponse = new AlexaResponse(input);

            return alexaResponse.response;
        }
    }
}
