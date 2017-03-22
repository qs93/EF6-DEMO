using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Demo.IBLL;
using Demo.BLLContainer;

namespace Demo.Web
{
    public class BaseController : Controller
    {
        protected IMemberService memberService
        {
            get
            {
                return Container.Resolve<IMemberService>();
            }
        }
    }
}