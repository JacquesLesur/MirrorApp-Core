using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using AlexaSkillsKit;
using Microsoft.AspNetCore.Http;
using System.Net.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MirrorApp.Controllers
{
    [Route("api/[controller]")]
    public class SkillAPIController : Controller
    {

        [Route("")]
        [HttpGet]
        [HttpHead]
        public IHttpActionResult root()
        {
            return this.Ok("Im Alive");
        }

        [Route("")]
        [HttpPost]
        public HttpResponseMessage Post()

        {
            return new AlexaResponse().GetResponse(this.Request);

        }
        // GET: api/<controller>
        //[HttpPost]
        //public  async Task<IActionResult> Post(LaunchRequest input)
        //{

        //    var json =  HttpContext.Request;
        //    var test =  json.ToString();
        //    //var skillRequest = JsonConvert.DeserializeObject<SkillRequest>(json.ReadFormAsync());

        //    //var requestType = skillRequest.GetRequestType();
        //    SkillResponse response = null;
        //    //if (requestType == typeof(LaunchRequest))
        //    //{
        //    //    response = ResponseBuilder.Tell("Welcome to AppConsult!");
        //    //    response.Response.ShouldEndSession = false;
        //    //}
        //    response = ResponseBuilder.Tell("Ca me soul je me casse");
        //    response.Response.ShouldEndSession = true;




        //    return new OkObjectResult(response);
        //}




        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        //// POST api/<controller>
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
