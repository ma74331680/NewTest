using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VtuberWebsite.Controllers
{
    public class productcontroller
    {
        public ActionResult productshowing()
        {
            return Veiw();
        }

        public ActionResult producttable()
        {

            return View();
        }

        public ActionResult myfavorite()
        {

            return View();
        }


    }
}