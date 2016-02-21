using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Infrastructure.Scrapper;
using XinemaProject.Models;
using XinemaProject.DAL;
using System.Data.Entity;

namespace XinemaProject.Controllers
{
    public class DataScrapperJob: IJob
    {
        private CinemaGateway cinemaGateway = new CinemaGateway();
        public void Execute(IJobExecutionContext context)
        {
            //Data crawling codes here
            System.Diagnostics.Debug.WriteLine("Executing job...");
            Scrapper scrapper = new Scrapper();
            scrapper.scrapCinemaName("https://www.google.com/movies?near=singapore&rl=1&stok=ABAPP2tdNR_5cLRa-6emW2UtecEL44SX2A%3A1456036737594");
            List<Cinema> cinemaList = scrapper.getCinemaNames();
            int size = cinemaList.Count() - 1;
            //int size = 10;
            Cinema cinema = new Cinema();
           
            while (size >= 0) {
                System.Diagnostics.Debug.WriteLine("size: " + size);
                //cinema.CinemaName = "name";
                //cinema.CinemaAddress = "addr";
                //cinemaGateway.Insert(cinema);
                cinema.CinemaName = cinemaList[size].CinemaName;
                System.Diagnostics.Debug.WriteLine("Cinena Name: " + cinema.CinemaName);
                cinema.CinemaAddress = cinemaList[size].CinemaAddress;
                System.Diagnostics.Debug.WriteLine("Cinema Address: " + cinema.CinemaAddress);
                cinemaGateway.Insert(cinema);
                size--;
            }
            System.Diagnostics.Debug.WriteLine("Job ended... ");


        }
    }
}