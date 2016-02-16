namespace XinemaProject.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using XinemaProject.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<XinemaProject.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(XinemaProject.Models.ApplicationDbContext context)
        {
            context.Showtimes.AddOrUpdate(p => p.showtimesStartTime,
                   new Showtimes
                   {

                       showtimesStartTime = "5:40pm",
                       showtimesDate = "16/02/2016",

                   });
        }
    }
}
