using StackExchange.Profiling;
using StackExchange.Profiling.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BK.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var copy = ViewEngines.Engines.ToList();
            //移除所有视图引擎
            ViewEngines.Engines.Clear();

            //添加Razor视图引擎
            //ViewEngines.Engines.Add(new RazorViewEngine());
            GlobalFilters.Filters.Add(new ProfilingActionFilter());
            foreach (var item in copy)
            {
                ViewEngines.Engines.Add(new ProfilingViewEngine(item));
            }
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            
        }

        protected void Application_BeginRequest()
        {
            if (Request.IsLocal)
            {
                MiniProfiler.Start();
            }
        }

        protected void Application_EndRequest()
        {
            MiniProfiler.Stop();
        }
    }
}
