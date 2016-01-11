using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Threading.Tasks;
using WebApp_OpenIDConnect_DotNet_B2C.Models;

namespace WebApp_OpenIDConnect_DotNet_B2C.Controllers
{
    public class UsersController : Controller
    {
        public ActionResult Index()
        {
            var users = DocumentDBRepository<Users>.GetUsers(d => !d.Disabled);
            return View(users);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
       // [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,IdentityProvider,DisplayName,GivenName,Surname,City,Country,Email,LastLogin")] Users user)
        {
           // if (ModelState.IsValid)
           // {
                await DocumentDBRepository<Users>.CreateItemAsync(user);
                return RedirectToAction("Index");
          //  }
           // return View(user);
        }


        public ActionResult Edit()
        {
            return View();
        }
    }
}