using Church.Client.CustomAttributes;
using Church.DataLayer.Db.Entity;
using Church.DataLayer.Repositories;
using Church.DataLayer.Service;
using StructureMap;
using System.Web.Mvc;

namespace Church.Client.Controllers
{
    [CustomAuthentication]
    public class PastorController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(ObjectFactory.GetInstance<IPastorRepository>().GetPastorsList());
        }

        public ActionResult Create()
        {
            return View(new Pastor());
        }

        [HttpPost]
        [ActionName("Create")]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePost()
        {
            var pastor = new Pastor();
            UpdateModel(pastor);
            if (ModelState.IsValid)
            {
                ObjectFactory.GetInstance<IPastorService>().Upsert(pastor);
                return RedirectToAction("Index");
            }

            return View("Create", pastor);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var pastor = ObjectFactory.GetInstance<IPastorRepository>().GetPastor(id);
            
            return View(pastor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit()
        {
            var pastor = new Pastor();
            UpdateModel(pastor);
            if (ModelState.IsValid)
            {
                ObjectFactory.GetInstance<IPastorService>().Upsert(pastor);
                return RedirectToAction("Index");
            }

            return View("Edit", pastor);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var pastor = ObjectFactory.GetInstance<IPastorRepository>().GetPastor(id);

            return View(pastor);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var pastor = ObjectFactory.GetInstance<IPastorRepository>().GetPastor(id);

            return View(pastor);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            ObjectFactory.GetInstance<IPastorRepository>().Delete(id);

            return RedirectToAction("Index");
        }
    }
}