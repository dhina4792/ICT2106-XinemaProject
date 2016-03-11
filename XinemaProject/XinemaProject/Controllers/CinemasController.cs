using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Infrastructure.Scrapper;
using XinemaProject.ViewModels;
using System.Data.Entity;
using XinemaProject.DAL;
using XinemaProject.Models;

namespace XinemaProject.Controllers
{
    public class CinemasController : Controller
    {
        private CinemaGateway cinemaGateway;
        // Scrapper scrapper = new Scrapper();
        // GET: Cinemas

        public CinemasController()
        {
            cinemaGateway = new CinemaGateway();
            ViewBag.CinemaOrderByDropDownListItems = cinemaGateway.GetCinemaOrderByNames();
        }
        public ActionResult Index(int? id)
        {
            //scrapper.scrapCinemaName("https://www.google.com/movies?near=singapore&rl=1&stok=ABAPP2tdNR_5cLRa-6emW2UtecEL44SX2A%3A1456036737594");
            //CinemasVM vm = new CinemasVM();
            //vm.cinemasName = scrapper.getCinemaNames();
            //return View(vm);
            if (id != null)
            {
                foreach (var item in ViewBag.CinemaOrderByDropDownListItems)
                {
                    if (item.Value == id.ToString())
                    {
                        item.Selected = true;


                    }
                }
                return View(cinemaGateway.SortBy((int)id));
            }
            else
            {
                foreach (var item in ViewBag.CinemaOrderByDropDownListItems)
                {
                    if (item.Text == "All")
                    {
                        item.Selected = true;


                    }
                }

            }
            return View(cinemaGateway.SelectAll());
        }


    }
}