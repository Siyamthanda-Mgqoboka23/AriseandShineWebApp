using AriseandShineWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace AriseandShineWebApp.Controllers
{
    public class ContactController : Controller
    {
        [HttpGet]
        public IActionResult ContactUs()
        {
            return View(new ContactUsViewModel());
        }

        [HttpPost]
        public IActionResult SendPrayerRequest(ContactUsViewModel model)
        {
            if (ModelState.IsValid)
            {
                // TODO: save/send prayer request
                TempData["Message"] = "Prayer request sent successfully!";
                return RedirectToAction("ContactUs");
            }

            return View("ContactUs", model);
        }

        [HttpPost]
        public IActionResult SubmitContactForm(ContactUsViewModel model)
        {
            if (ModelState.IsValid)
            {
                // TODO: handle general contact form
                TempData["Message"] = "Your message was sent successfully!";
                return RedirectToAction("ContactUs");
            }

            return View("ContactUs", model);
        }
    }
}
