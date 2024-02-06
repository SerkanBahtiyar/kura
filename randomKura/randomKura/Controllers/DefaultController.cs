using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using randomKura.Models.Entity;
namespace randomKura.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
      guncelKuraEntities1 sb=new guncelKuraEntities1();
        public ActionResult Index()
        {
           
            var random = new Random();
            var degerler = sb.tablo.ToList();
            var randomIndex = random.Next(0, degerler.Count);
            var rastgeleDeger = degerler[randomIndex];
            return View(new List<tablo> { rastgeleDeger });
        }

        public PartialViewResult hepsiniListele()
        {
            var degerler = sb.tablo.ToList();
            
            return PartialView(degerler);
        }
        public ActionResult KategoriSil(int id)
        {
            var kt = sb.tablo.Find(id);
            sb.tablo.Remove(kt);
            sb.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public PartialViewResult ilet()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult ilet(tablo t)
        {
            sb.tablo.Add(t);
            sb.SaveChanges();
            return PartialView();
        }
    }
}