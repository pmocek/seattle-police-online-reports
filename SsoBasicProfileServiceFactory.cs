using System;
using Seattle.DoIT.PoliceReports.Web.SsoServices;

namespace Seattle.DoIT.PoliceReports.Web
{
   internal class SsoBasicProfileServiceFactory
   {
      public static BasicProfileService Create()
      {
         return new BasicProfileServiceClient();
      }
   }
}