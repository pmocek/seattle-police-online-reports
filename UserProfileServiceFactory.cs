using System;
using Seattle.DoIT.PoliceReports.Web.UserProfileServices;

namespace Seattle.DoIT.PoliceReports.Web
{
   internal class UserProfileServiceFactory
   {
      public static UserProfileService Create()
      {
         return new UserProfileServiceClient();
      }
   }
}