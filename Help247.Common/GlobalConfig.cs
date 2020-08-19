using System;
using System.Collections.Generic;
using System.Text;

namespace Help247.Common
{
    public static class GlobalConfig
    {
        //Production
        //public static string APIBaseUrl = "http://hishamhafeel-001-site1.dtempurl.com/app";
        //public static string PresentationBaseUrl = "http://hishamhafeel-001-site1.dtempurl.com/app/auth/login";

        //Development
        public static string APIBaseUrl = "https://localhost:44936";
        public static string PresentationBaseUrl = "http://localhost:4200/auth/login";
    }
}
