using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XinemaProject.Models;

namespace XinemaProject.DAL
{
    public class MovieGateway : DataGateway<Movies>
    {
        private List<SelectListItem> MovieOrderByDropDownItems;

        public MovieGateway()
        {

            MovieOrderByDropDownItems = new List<SelectListItem>();
            var firstItem = new SelectListItem { Text = "A-Z", Value = "0" };
            var secondItem = new SelectListItem { Text = "Z-A", Value = "1" };


            MovieOrderByDropDownItems.Add(firstItem);
            MovieOrderByDropDownItems.Add(secondItem);


        }

        public List<SelectListItem> GetMovieOrderByNames()
        {
            return MovieOrderByDropDownItems;
        }
        public IEnumerable<Movies> SortBy(int id)
        {
            switch (id)
            {

                case 1:

                    return data.OrderByDescending(t => t.moviesName);



            }
            return data.OrderBy(t => t.moviesName);
        }
    }
}