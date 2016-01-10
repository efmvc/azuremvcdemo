using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using WebApp_OpenIDConnect_DotNet_B2C.Policies;

namespace WebApp_OpenIDConnect_DotNet_B2C.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Request.IsAuthenticated)
            {

               return Redirect("Home/Member");
            }
            else
            {
                return View();
            }
        }

        // You can use the PolicyAuthorize decorator to execute a certain policy if the user is not already signed into the app.
        [PolicyAuthorize(Policy = "B2C_1_EFSignInPolicy")]
        public ActionResult Claims()
        {
            Claim displayName = ClaimsPrincipal.Current.FindFirst(ClaimsPrincipal.Current.Identities.First().NameClaimType);
            ViewBag.DisplayName = displayName != null ? displayName.Value : string.Empty;
            return View();
        }

        public ActionResult Error(string message)
        {
            ViewBag.Message = message;

            return View("Error");
        }
        public ActionResult Member()
        {

            foreach (Claim claim in ClaimsPrincipal.Current.Claims)
            {
                if (@claim.Type.Equals("name"))
                {
                    ViewBag.claimName = claim.Value;
                }
            }
            return View();
        }
                
    }
}