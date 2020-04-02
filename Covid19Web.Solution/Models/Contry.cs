using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Covid19Web.Solution.Models
{
    public class Contry
    {

        public string Country { get; set; }

        public string Slug { get; set; }

        public int NewConfirmed { get; set; }
        public int TotalConfirmed { get; set; }
        public int NewDeaths { get; set; }

        public int TotalDeaths { get; set; }
        public int NewRecovered { get; set; }
        public int TotalRecovered { get; set; }



    }
    public class Result
    {

        public List<Contry> Countries { get; set; }


    }

}