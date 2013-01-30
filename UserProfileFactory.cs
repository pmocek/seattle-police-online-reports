using System;
using Seattle.DoIT.PoliceReports.Web.UserProfileServices;

namespace Seattle.DoIT.PoliceReports.Web
{
   internal class UserProfileFactory
   {
      public static UserProfile Create(string userName, string email)
      {
         return new UserProfile() { UserName = userName, Email = email, IsActive = true };
      }
   }
}