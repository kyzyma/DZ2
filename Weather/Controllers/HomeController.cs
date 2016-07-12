using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Weather.Models;
using Weather.Services;

namespace Weather.Controllers
{
    public class HomeController : Controller
    {
        //GetJasonData jsData;
        IGetJasonData _jsData;

        /* public HomeController()
             {
                 jsData = new GetJasonData();
             }
        */
        public HomeController(IGetJasonData jsData)
        {
            _jsData = jsData;
        }
        // GET: /Home/

        public ActionResult Index()
            {
                var ob = _jsData.OutData("london",3);
                return View(ob);
            }

            [HttpPost]
            public ActionResult Index(BaseObject City)
            {
                if (City.ChooseCityInput == null || City.ChooseCityInput.Length ==0)
                {
                    var ob = _jsData.OutData(City.ChooseCityList, City.CountDays);
                    
                    return View(ob);
                }
                else
                {
                    var ob = _jsData.OutData(City.ChooseCityInput, City.CountDays);
                    ob.CountDays = City.CountDays;
                    return View(ob);
                }
            }

            

            
        
    }
}
