using System;
using System.Web;
using System.Web.Security;
using Seattle.DoIT.PoliceReports.Web.UserProfileServices;

namespace Seattle.DoIT.PoliceReports.Web.UI
{
   public class SecuredPage : System.Web.UI.Page
   {
      private UserProfile _userProfile = null;

      protected override void OnLoad(EventArgs e)
      {
         if (!Page.User.Identity.IsAuthenticated)
         {
            SiteNavigator.RedirectToSignInPage();
         }
         else
         {
            UserProfile userProfile = UserProfile;
            if (userProfile == null)
            {
               SiteNavigator.RedirectToUserRegistrationPage();
            }
            else if (!userProfile.IsActive)
            {
               SiteNavigator.RedirectToAccessDeniedPage();
            }
         }

         base.OnLoad(e);
      }

      internal UserProfile UserProfile
      {
         get
         {
            if (_userProfile == null && Page.User.Identity.IsAuthenticated)
            {
               UserProfileService svc = UserProfileServiceFactory.Create();
               using (svc as IDisposable)
               {
                  _userProfile = svc.GetByUserName(Page.User.Identity.Name);
               }
            }
            return _userProfile;
         }
      }

      /*
      private void RedirectToDeactivatedUserPage()
      {
         try
         {
            Response.Redirect("~/DeactivatedUser.aspx");
         }
         catch (System.Threading.ThreadAbortException)
         {
         }
      }

      private void RedirectToUserRegistrationPage()
      {
         try
         {
            Response.Redirect("~/UserRegistration.aspx");
         }
         catch (System.Threading.ThreadAbortException)
         {
         }
      }
      */

      protected void SignOut()
      {
         FormsAuthentication.SignOut();
         Response.Expires = 0;
      }
   }
}