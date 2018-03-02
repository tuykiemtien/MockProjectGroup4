using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using DTO;
using GUI.Models;

namespace GUI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index() 
        {
            return View();
        } 
        [System.Web.Mvc.HttpPost]
        public JsonResult Index(AccountDTO account)
        {
            try
            {
                AccountDTO accountLogin = DataAccess.Instance.Login(account.Username, account.Password);
                if(accountLogin != null)
                {
                    Session["username"] = accountLogin.Username;
                    return Json(new { Ok = true });
                }
                else
                {
                    return Json(new { Ok = false });
                }
            }
            catch
            {
                return Json(new { Ok = false });
            }
        }
    }
}