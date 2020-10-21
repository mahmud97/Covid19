using Covid19Web.Solution.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Covid19Web.Solution.Controllers
{
    public class Covid19Controller : Controller
    {
        public ActionResult Covid19Update()
        {
            
            var ob = GetCovid19Data();
            return View(ob);
        }

        public ActionResult CountryDetails(string uniqueIdentifier)
        {
            if (string.IsNullOrEmpty(uniqueIdentifier))
                return HttpNotFound();
            
            var ob = GetCovid19Data();
            var result = ob.Countries.SingleOrDefault(c=>c.Country.Equals(uniqueIdentifier));

            //foreach(var item in ob.Countries)
            //{
            //    if (item.Country.Equals(uniqueIdentifier))
            //    {
            //        result = item;
            //    }
            //}
            return View("Details",result);

        }
        public static Result GetCovid19Data()
        {
            var ob = new Result();
            try
            {

                var url = string.Format("https://api.covid19api.com/summary");
                var req = (HttpWebRequest)WebRequest.Create(url);
                var res = (HttpWebResponse)req.GetResponse();
                using (var streamreader = new StreamReader(res.GetResponseStream()))
                {
                    var result = streamreader.ReadToEnd();

                    if (!string.IsNullOrWhiteSpace(result))
                    {
                        ob = JsonConvert.DeserializeObject<Result>(result);

                    }
                }

            }
            catch (Exception exception)
            {

                throw exception;

            }
            return ob;
        }

    }
}