using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Seattle.DoIT.PoliceReports.Web.UserProfileServices;
using System.Threading;
using System.Web.Security;
using Seattle.DoIT.PoliceReports.Web.SsoServices;

namespace Seattle.DoIT.PoliceReports.Web
{
   public partial class UserRegistrationGadget : System.Web.UI.Page
   {
      private UserProfile _userProfile;

      protected void Page_Load(object sender, EventArgs e)
      {
         if (!Page.User.Identity.IsAuthenticated)
         {
            SiteNavigator.RedirectToSignInPage();
         }
         else
         {
            UserProfile userProfile = UserProfile;
            if (userProfile != null)
            {
               if (userProfile.IsActive)
               {
                  RedirectToDestination();
               }
               else
               {
                  SiteNavigator.RedirectToAccessDeniedPage();
               }
            }
            else
            {
               LoadSsoBasicProfile();
            }
         }
      }

      private void LoadSsoBasicProfile()
      {
         try
         {
            BasicProfile basicProfile = null;
            BasicProfileService svc = SsoBasicProfileServiceFactory.Create();
            using (svc as IDisposable)
            {
               basicProfile = svc.GetByUserName(User.Identity.Name);
            }

            if (basicProfile == null || string.IsNullOrEmpty(basicProfile.Email))
            {
               throw new Exception("Failed to retrieve email from SSO Basic profile");
            }
            else
            {
               UserEmail = basicProfile.Email;
            }
         }
         catch
         {
         }
      }

      protected void RegisterButton_Click(object sender, EventArgs e)
      {
         if (Page.IsValid)
         {
            RegisterUser();
            RedirectToDestination();
         }
      }

      private void RegisterUser()
      {
         UserProfile newUserProfile = UserProfileFactory.Create(User.Identity.Name, UserEmail);

         // Register by adding this user's profile profile for this user
         UserProfileService svc = UserProfileServiceFactory.Create();
         using (svc as IDisposable)
         {
            svc.Add(newUserProfile);
         }
      }

      private UserProfile UserProfile
      {
         get
         {
            if (_userProfile == null)
            {
               UserProfileService svc = UserProfileServiceFactory.Create();
               using (svc as IDisposable)
               {
                  _userProfile = svc.GetByUserName(User.Identity.Name);
               }
            }

            return _userProfile;
         }
      }

      private bool IsUserRegistered
      {
         get
         {
            return UserProfile == null ? false : true;
         }
      }

      private string DestinationUrl
      {
         get 
         {
            string destUrl = string.Empty;
            if (ViewState["DestinationUrl"] != null)
            {
               destUrl = Convert.ToString(ViewState["DestinationUrl"]);
            }
            else if (Request["dest"] != null)
            {
               try
               {
                  destUrl = "~/" + Server.UrlDecode(Request["dest"]);
               }
               catch
               {
                  destUrl = string.Empty;
               }
            }
            return string.IsNullOrEmpty(destUrl) ? "~/" : destUrl; 
         }
      }

      private void RedirectToDestination()
      {
         SiteNavigator.Redirect(DestinationUrl);
      }

      protected void AcceptCheckboxIsCheckedValidator_ServerValidate(object source, ServerValidateEventArgs args)
      {
         args.IsValid = AgreeCheckbox.Checked;
      }

      private string UserEmail 
      {
         get
         {
            object email = ViewState["UserEmail"];
            return email == null ? string.Empty : email.ToString();
         }
         set
         {
            ViewState["UserEmail"] = value;
         }
      }
   }
}