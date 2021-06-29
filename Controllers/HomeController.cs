using System;
using System.Net;
using System.Web.Mvc;
using MekaShron.Models;
using Newtonsoft.Json;

namespace MekaShron.Controllers
{
    public class HomeController : Controller
    {       
        public ActionResult Index()
        {
            var loginModel = new Login();

            return View(loginModel);
        }

        [HttpPost]
        public ActionResult Login(Login loginModel)
        {
            MekaShronService.IICUTechservice mekaShronServiceClient = new MekaShronService.IICUTechservice();            
            try
            {
                // Call login service 
                var response = JsonConvert.DeserializeObject<Response>(mekaShronServiceClient.Login(loginModel.UserName, loginModel.Password, "bhavi"));

                if (response.ResultCode.Equals("-1"))
                {
                    // Stay in the same page if there are any errors
                    return Json(new { result = "-1", url = Url.Action("Login", "Home") });
                }
                else
                {
                    // Redirect to user details page
                    TempData["UserDetails"] = response;
                    return Json(new { result = "1", url = Url.Action("UserDetails", "Home") });
                }
            }
            catch 
            {
                // Log the exception
                return View("Error");
            }
        }

        public ActionResult UserDetails()
        {
            return View();
        }

        public ActionResult Error()
        {
            return View();
        }


    }
}