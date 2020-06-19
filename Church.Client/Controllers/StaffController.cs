using Church.Client.CustomAttributes;
using Church.DataLayer.Db.Entity;
using Church.DataLayer.Repositories;
using Church.DataLayer.Service;
using StructureMap;
using System.Linq;
using System.Web.Mvc;
using System.Web.SessionState;

namespace Church.Client.Controllers
{
    [CustomAuthentication]
    [SessionState(SessionStateBehavior.Required)]
    public class StaffController : Controller
    {
        [HttpGet]
        public ActionResult Staff()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        [ActionName("Staff")]
        [HandleError]
        
        public ActionResult StaffPost()
        {
            var staff = new Staff();
            UpdateModel(staff);
            if (ModelState.IsValid)
            {
                ObjectFactory.GetInstance<IStaffService>().Upsert(staff);

                return RedirectToAction("Index", "Home");
            }
            return View("Staff", staff);
        }

        [HttpGet]
        [ActionName("StaffList")]
        public ActionResult List()
        {
            var staffList = ObjectFactory.GetInstance<IStaffRepository>().GetStaffLists();
            ViewBag.StaffList = staffList;
            return View("List", staffList.FirstOrDefault());
        }

        [HttpGet]
        
        public ActionResult EditStaff(int id)
        {
            var staff = ObjectFactory.GetInstance<IStaffRepository>().GetStaff(id);

            return View(staff);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult EditStaff()
        {
            var staff = new Staff();
            UpdateModel(staff);
            if (ModelState.IsValid)
            {
                ObjectFactory.GetInstance<IStaffService>().Upsert(staff);

                return RedirectToAction("StaffList");
            }
            
            return View("Staff", staff);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var data = ObjectFactory.GetInstance<IStaffRepository>().GetStaff(id);

            return View(data);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var data = ObjectFactory.GetInstance<IStaffRepository>().GetStaff(id);
            return View(data);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeletePost(int id)
        {
            ObjectFactory.GetInstance<IStaffRepository>().Delete(id);
            
            return RedirectToAction("StaffList");
        }
    }
}