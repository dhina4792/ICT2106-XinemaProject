using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XinemaProject.Controllers
{
    public class DataJob: IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            //Data crawling codes here
            System.Diagnostics.Debug.WriteLine("Executing job...");
        }
    }
}