using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebMvc.ViewModels;

namespace WebMvc.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        public async Task<IActionResult> SignIn(string returnUrl)
        {
            var user = User as ClaimsPrincipal;

            var token = await HttpContext.GetTokenAsync("access_token");
            var idToken = await HttpContext.GetTokenAsync("id_token");
            foreach (var claim in user.Claims)
            {
                Debug.WriteLine($"Claim Type: {claim.Type} - Claim Value : {claim.Value}");
            }

            if (token != null)
            {
                ViewData["access_token"] = token;
            }

            if (idToken != null)
            {
                ViewData["id_token"] = idToken;
            }
            if (TempData.ContainsKey("TicketPageParameters"))
            {
                var myArray = TempData.Get<string[,]>("TicketPageParameters");

                var dateSelected = Convert.ToDateTime(myArray[0, 1]).ToString("MM-dd-yyyy");
                return RedirectToAction("Index", "Ticket", new { eventId = Convert.ToInt32(myArray[0, 0]), dateselected = dateSelected });
            }


            return RedirectToAction(nameof(EventController.Index), "Event");

        }

        public async Task<IActionResult> Signout()
        {
            await HttpContext.SignOutAsync("Cookies");
            await HttpContext.SignOutAsync("oidc");
            var homeUrl = Url.Action(nameof(EventController.Index), "Event");
            return new SignOutResult("oidc",
                new AuthenticationProperties { RedirectUri = homeUrl });
       }
    }
}
