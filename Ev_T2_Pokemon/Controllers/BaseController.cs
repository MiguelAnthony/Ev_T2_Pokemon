using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ev_T2_Pokemon.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ev_T2_Pokemon.Controllers
{
    public class BaseController : Controller
    {
        private readonly Ev_T2_Pokemon_Context context;
        public BaseController(Ev_T2_Pokemon_Context context)
        {
            this.context = context;
        }

        protected Reg_Usuario LoggedUser()
        {
            var claim = HttpContext.User.Claims.FirstOrDefault();
            var user = context.Reg_Usuario.Where(o => o.Usuario == claim.Value).FirstOrDefault();
            return user;
        }
    }
}
