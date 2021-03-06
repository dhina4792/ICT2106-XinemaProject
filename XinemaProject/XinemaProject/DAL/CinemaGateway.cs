﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XinemaProject.Models;

namespace XinemaProject.DAL
{
    public class CinemaGateway:DataGateway<Cinema>
    {
        private List<SelectListItem> CinemaOrderByDropDownItems;

        public CinemaGateway()
        {

            CinemaOrderByDropDownItems = new List<SelectListItem>();
            var firstItem = new SelectListItem { Text = "All", Value = "0"};
            var secondItem = new SelectListItem { Text = "Shaw", Value = "1" };
            var thirdItem = new SelectListItem { Text = "Golden Village", Value = "2" };
            var fourthItem = new SelectListItem { Text = "Cathay", Value = "3" };
            CinemaOrderByDropDownItems.Add(firstItem);
            CinemaOrderByDropDownItems.Add(secondItem);
            CinemaOrderByDropDownItems.Add(thirdItem);
            CinemaOrderByDropDownItems.Add(fourthItem);


        }

        public List<SelectListItem> GetCinemaOrderByNames()
        {
            return CinemaOrderByDropDownItems;
        }
        public IEnumerable<Cinema> SortBy(int id)
        {
            var cinemas = from t in SelectAll()
                        select t;
            switch (id)
            {

                case 1:

                    cinemas = from t in SelectAll()
                              where t.CinemaName.Contains("Shaw") || t.CinemaAddress.Contains("Shaw")
                              select t;
                    return cinemas;
                case 2:
                    cinemas = from t in SelectAll()
                              where t.CinemaName.Contains("Golden Village") || t.CinemaAddress.Contains("Golden Village")
                              select t;
                    return cinemas;

                case 3:
                    cinemas = from t in SelectAll()
                              where t.CinemaName.Contains("Cathay") || t.CinemaAddress.Contains("Cathay")
                              select t;
                    return cinemas;



            }


            return cinemas;
        }
    }
}