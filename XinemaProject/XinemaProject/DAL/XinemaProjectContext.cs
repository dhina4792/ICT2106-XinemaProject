using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using XinemaProject.Models;

namespace XinemaProject.DAL
{
    public class XinemaProjectContext: DbContext
    {
        public XinemaProjectContext()
            : base("XinemaProjectDB")
        {
        }
        public DbSet<Cinema> Cinemas { get; set; }
    }
}