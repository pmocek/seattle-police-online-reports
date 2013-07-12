using System;
using System.Web;
using System.Web.Security;
using Seattle.DoIT.PoliceReports.Web.UserProfileServices;

namespace Seattle.DoIT.PoliceReports.Web.UI
{
   public class SecuredGadgetPage : System.Web.UI.Page
   {
      private UserProfile _userProfile = null;

      protected override void OnLoad(EventArgs e)
      {
         if (!Page.User.Identity.IsAuthenticated)
         {
            SiteNavigator.RedirectToSignInRequiredGadgetPage();
         }
         else
         {
            UserProfile userProfile = UserProfile;
            if (userProfile == null)
            {
               SiteNavigator.RedirectToUserRegistrationGadgetPage(Page.AppRelativeVirtualPath.Remove(0,1));
            }
            else if (!userProfile.IsActive)
            {
               SiteNavigator.RedirectToAccessRevokedGadgetPage();
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
   }
}