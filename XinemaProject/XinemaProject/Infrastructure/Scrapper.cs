using OpenQA.Selenium;
using OpenQA.Selenium.PhantomJS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XinemaProject.Models;

namespace Infrastructure.Scrapper
{
    public class Scrapper
    {
        private List<Cinema> allCinemas;

        public Scrapper()
        {
            allCinemas = new List<Cinema>();

        }

        public void scrapCinemaName(string googleURL)
        {
            IWebDriver driver = new PhantomJSDriver();
            var url = googleURL;
            driver.Navigate().GoToUrl(url);

            for (int i = 0; i < 5; i++)
            {
                //add current page cinemas 
                var cinemasName = scrapOnePageCinema(driver);

                //add all
                allCinemas.AddRange(cinemasName);

                //Go goto next on current page
                try
                {
                    var nextUrl = driver.FindElements(By.PartialLinkText("Next")).Last().GetAttribute("href");
                    driver.Navigate().GoToUrl(nextUrl);
                }
                catch (InvalidOperationException e)
                {
                    //Console.WriteLine(e.Source);
                }

            }

            //close driver
            driver.Dispose();
        }

        private List<Cinema> scrapOnePageCinema(IWebDriver driver)
        {
            var cinemaList = new List<Cinema>();
            var cinemas = driver.FindElements(By.CssSelector(".theater"));

            foreach (var cinema in cinemas)
            {
                var currCinemaName = cinema.FindElement(By.CssSelector("a[id^='link_1_theater_']")).Text;
                var currCinemaAddress = cinema.FindElement(By.CssSelector(".info")).Text;

                cinemaList.Add(new Cinema() { CinemaName = currCinemaName, CinemaAddress = currCinemaAddress });
            }

            return cinemaList;
        }

        public List<Cinema> getCinemaNames()
        {
            return allCinemas;
        }

    }

}