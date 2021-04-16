using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sigortam.BLL.Abstract;
using Sigortam.Core.Model;
using Sigortam.Entities.Model;
using Sigortam.UI.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Sigortam.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserManager _userManager;
        public HomeController(ILogger<HomeController> logger, IUserManager userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetOffer(User requestModel)
        {
            try
            {
                CResult<User> result = new CResult<User>();
                if (ModelState.IsValid)
                {
                    result = _userManager.Add(requestModel);
                    return Json((object)new
                    {
                        data = 0,
                        message = result.Desc,
                        success = result.Succeeded,
                        redirectUrl = "",
                    });
                }
                return Json((object)new
                {
                    data = 0,
                    message = string.Join(";<br/> ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage)),
                    success = false,
                    redirectUrl = "",
                });
            }
            catch (Exception ex)
            {
                return Json((object)new
                {
                    data = 0,
                    message = "Hata oluştu :" + ex.Message.ToString(),
                    success = false,
                });
            }
        }
    }
}
