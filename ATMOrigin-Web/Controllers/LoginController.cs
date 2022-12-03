using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc.Rendering;
using ATMOrigin_Web.ViewModels;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using System.IO;

namespace ATMOrigin_Web.Controllers
{
    public class LoginController : Controller
    {
        private ICompositeViewEngine _viewEngine;

        public LoginController(ICompositeViewEngine compositeView) 
        {
            _viewEngine = compositeView;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ValidateCard(string numberCard)
        {
            numberCard = numberCard == null ? "" : numberCard.Trim();
            DataCardVM dataCard = new DataCardVM();
            dataCard.NumberCard = numberCard;
            //tarjeta valida
            if (true)
            {
                return PartialView("./Views/Login/_LoginPin.cshtml", dataCard);
            }
            else 
            {
                ErrorMsgVM error = new ErrorMsgVM();
                error.Title = "Tarjeta invalida";
                error.Message = "No se encontrado ninguna tarjeta con el numero ingresado";
                error.UrlBack = "Login";
             
                return PartialView("_ErrorView", error);
            }

            
        }

        public IActionResult Login(DataCardVM data)
        {
            data.NumberCard = data.NumberCard == null ? "" : data.NumberCard.Trim();
            data.PIN = data.PIN == null ? "" : data.PIN.Trim();
            ErrorMsgVM error = null;

            //datos validos
            if (true)
            {
                return RedirectToAction("Index","Home");
            }
            else
            {
                error = new ErrorMsgVM();
                error.Title = "Tarjeta invalida";
                error.Message = "No se encontrado ninguna tarjeta con el numero ingresado";
                error.UrlBack = "/Login/index";
                return PartialView("_ErrorView", error);
            }
        }

    }
}
