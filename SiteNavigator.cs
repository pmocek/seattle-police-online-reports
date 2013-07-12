using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Seattle.DoIT.PoliceReports.Web
{
   internal class SiteNavigator
   {
      private static string _userRegistrationUrl = "~/UserRegistration.aspx";
      private static string _accessDeniedUrl = "~/AccessDenied.aspx";
      private static string _policeReportNotFoundUrl = "~/PoliceReportNotFound.aspx";
      private static string _userRegistrationGadgetUrl = "~/gadgets/UserRegistrationGadget.aspx";
      private static string _signInRequiredGadgetUrl = "~/gadgets/SignInRequired.aspx";
      private static string _accessRevokedGadgetUrl = "~/gadgets/AccessRevoked.aspx";

      private SiteNavigator() { }

      public static void Redirect(string url)
      {
         try
         {
            HttpContext.Current.Response.Redirect(url);
         }
         catch (System.Threading.ThreadAbortException)
         {
         }
      }

      public static void Transfer(string url)
      {
         try
         {
            HttpContext.Current.Server.Transfer(url);
         }
         catch (System.Threading.ThreadAbortException)
         {
         }
      }

      public static void RedirectToSignInPage()
      {
         FormsAuthentication.RedirectToLoginPage();
      }

      public static void RedirectToUserRegistrationPage()
      {
         Redirect(_userRegistrationUrl);
      }

      public static void TransferToUserRegistrationPage()
      {
         Transfer(_userRegistrationUrl);
      }

      private static string GetUserRegistrationUrlWithDestination(string destUrl)
      {
        return _userRegistrationUrl + "?dest=" + HttpContext.Current.Server.UrlEncode(destUrl);
      }

      public static void RedirectToUserRegistrationPage(string destUrl)
      {
         Redirect(GetUserRegistrationUrlWithDestination(destUrl));
      }

      public static void TransferToUserRegistrationPage(string destUrl)
      {
         Transfer(GetUserRegistrationUrlWithDestination(destUrl));
      }

      public static void RedirectToAccessDeniedPage()
      {
         Redirect(_accessDeniedUrl);
      }

      private static string GetUserRegistrationGadgetUrlWithDestination(string destUrl)
      {
         return _userRegistrationGadgetUrl + "?dest=" + HttpContext.Current.Server.UrlEncode(destUrl);
      }

      public static void RedirectToUserRegistrationGadgetPage(string destUrl)
      {
         Redirect(GetUserRegistrationGadgetUrlWithDestination(destUrl));
      }

      public static void TransferToUserRegistrationGadgetPage(string destUrl)
      {
         Transfer(GetUserRegistrationGadgetUrlWithDestination(destUrl));
      }

      public static void RedirectToAccessRevokedGadgetPage()
      {
         Redirect(_accessRevokedGadgetUrl);
      }

      public static void RedirectToSignInRequiredGadgetPage()
      {
         Redirect(_signInRequiredGadgetUrl);
      }

      public static void RedirectToPoliceReportNotFoundPage()
      {
         Redirect(_policeReportNotFoundUrl);
      }
   }
}