using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using BitlyTest.Infrastructure;
using BitlyTest.Repo;

namespace BitlyTest.Controllers
{
    public class HomeController : Controller
    {
        RecordsRepo repo;

        public HomeController(RecordsRepo _repo)
        {
            repo = _repo;
        }

        [HttpGet]
        public IActionResult Index()
        {
          return View();
        }

        [HttpGet]
        public string Get(string fullRecord)
        {
            //string s = HttpContext.Request.QueryString.ToString().Remove(0, 12);
           
             
            return repo.GetShortRecord(fullRecord); ;
        }
        
        [HttpGet]
        public ActionResult Route(string shortRecord)
        {
            try
            {
                return Redirect(repo.Route(shortRecord));
            }
            catch
            {
                return RedirectToAction("index");
            }
            
        }
    }
}
