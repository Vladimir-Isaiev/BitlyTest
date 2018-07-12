using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BitlyTest.Infrastructure;
using BitlyTest.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BitlyTest.Controllers
{
    [Produces("application/json")]
    [Route("api/Records")]
    public class RecordsController : Controller
    {
        RecordsRepo repo;


        public RecordsController(RecordsRepo _repo)
        {
            repo = _repo;
        }      
      

        // GET api/values/5
        [HttpGet]
        public string Get(string fullRecord)
        {
            //string s = HttpContext.Request.QueryString.ToString().Remove(0, 12);
            return repo.GetShortRecord(fullRecord);
        }


        [HttpPost]
        public string Post([FromBody] string fullRecord)
        {
            string s = HttpContext.Request.QueryString.ToString();
            return fullRecord;
        }       
    }
}
