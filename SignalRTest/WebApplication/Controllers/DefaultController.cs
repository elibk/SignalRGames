using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    public class DefaultController : Controller
    {
        //
        // GET: /Default/
        public ActionResult Index()
        {
            //char[] field = new char[] 
            //{
            //    '~', '@', '', '', '', '', '', '', '', '$', '', '',
            //    '', '', '', '', '', '', '^', '', '', '', '', '',
            //    '', '', '', '', '', '', '', '', '', '', '', '',
            //    '', '', '', '', '~', '', '', '', '', '', '', '',
            //    '', '', '', '', '', '', '#', '', '', '', '', '',
            //    '', '', '', '', '', '', '', '', '', '#', '', '',
            //    '', '@', '', '', '', '', '', '', '', '', '', '',
            //    '', '', '', '', '', '', '', '%', '', '', '', '',
            //    '', '', '$', '', '', '', '', '', '', '', '^', '',
            //    '', '', '', '', '', '', '', '', '', '', '', '',
            //    '', '', '', '', '', '%', '', '', '', '', '', '',

            //};

            char[] field = new char[] 
            {
                '~', '@', '#',
                '$', '#', ' ',
                '~', '$', '@'
             

            };

            ViewBag.Rows = 5;
            ViewBag.Cols = 5;
            return View();
        }
	}
}