using System;
using System.Web;
using System.Web.Security;
using Seattle.DoIT.PoliceReports.Web.PoliceReportServices;
using Seattle.DoIT.PoliceReports.Web.UserProfileServices;

namespace Seattle.DoIT.PoliceReports.Web
{
   public class PoliceReportHttpHandler : IHttpHandler
   {
      #region IHttpHandler Members

      public void ProcessRequest(HttpContext context)
      {
         HttpRequest request = context.Request;
         long goNumber = 0;
         byte[] contentBytes = null;
         if (context.User.Identity.IsAuthenticated && long.TryParse(request["go"], out goNumber) && goNumber > 0)
         {
            try
            {
               UserProfile userProfile = GetUserProfile(context.User.Identity.Name);
               if (userProfile == null)
               {
                  string url = (request.AppRelativeCurrentExecutionFilePath + request.Url.Query).Remove(0, 1);
                  SiteNavigator.RedirectToUserRegistrationPage(url);
               }
               else if (!userProfile.IsActive)
               {
                  SiteNavigator.RedirectToAccessDeniedPage();
               }

               contentBytes = GetDocumentBytesByGoNumber(userProfile.UserName, goNumber.ToString());
            }
            catch (Exception x)
            {
               contentBytes = null;
            }
         }
         if (contentBytes != null && contentBytes.Length > 0)
         {
            HttpResponse response = context.Response;
            response.Clear();
            response.ClearContent();
            response.ClearHeaders();
            response.AddHeader("Content-Length", contentBytes.Length.ToString());
            response.AddHeader("Content-Disposition", string.Format("attachment; filename=PoliceReport-{0}.pdf", goNumber));
            response.ContentType = "application/pdf";
            response.BinaryWrite(contentBytes);
            response.Flush();
            response.Close();
         }
         else
         {
            SiteNavigator.RedirectToPoliceReportNotFoundPage();
         }
      }

      public bool IsReusable
      {
         get { return false; }
      }

      #endregion

      private UserProfile GetUserProfile(string userName)
      {
         UserProfile userProfile = null;
         if (userName.Length > 0)
         {
            UserProfileService svc = UserProfileServiceFactory.Create();
            using (svc as IDisposable)
            {
               userProfile = svc.GetByUserName(userName);
            }
         }
         return userProfile;
      }

      private byte[] GetDocumentBytesByGoNumber(string userName, string goNumber)
      {
         byte[] contentBytes = null;

         if (!string.IsNullOrEmpty(goNumber))
         {
            PoliceReportService svc = PoliceReportServiceFactory.Create();
            using (svc as IDisposable)
            {
               PoliceReport rpt = svc.GetReportByGoNumber(userName, goNumber);
               if (rpt != null)
               {
                  contentBytes = rpt.Content;
               }
            }
         }

         return contentBytes;
      }
   }
}
