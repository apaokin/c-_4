using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        ProcContext db;
        public HomeController(ProcContext context)
        {

            db = context;
        }
        public JsonResult Index(int page = 0)
        {
            
            var query2 = db.ImageMs.Include("Smiles").Include("Bodies").OrderBy(c => c.Id).Skip(page).Take(1).First();
            return Json(query2);
        }
        public JsonResult ForType(int page = 0)
        {
            var query =(from i in db.ImageMs
             join s in db.Smiles on i.Id equals s.ImageMId
             join b in db.Bodies on i.Id equals b.ImageMId
             group new {i,s,b} by new {i.Path} into res             

             select new
             {
                 path = res.Key.Path,
                 smiles_count = res.Select(x => x.s.Id).Distinct().Count(),
                 bodies_count= res.Select(x => x.b.Id).Distinct().Count()
             }).Skip(page).Take(1);
            var image = query.First();
            int pos = image.path.LastIndexOf("\\") + 1;
            string Path = "http://localhost:3035/images/" + image.path.Substring(pos);
            //var query2 = db.ImageMs.Include("Smiles").Include("Bodies").OrderBy(c => c.Id).Skip(page).Take(1).First();
            Request.HttpContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            return Json(new { path = Path,smiles_count = image.smiles_count, bodies_count = image.bodies_count});
        }
        public JsonResult Count()
        {
            var query2 = db.ImageMs.Count();
            Request.HttpContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            return Json(new { count = query2 });
        }
    }
}
