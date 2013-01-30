using System;
using System.Web.Security;
using Seattle.DoIT.PoliceReports.Web.UserProfileServices;
using System.Threading;

namespace Seattle.DoIT.PoliceReports.Web.Master
{
   public partial class PoliceReport : System.Web.UI.MasterPage
   {
      protected void Page_Load(object sender, EventArgs e)
      {
      }

      protected void SignOutButton_Click(object sender, EventArgs e)
      {
         SignOut();
         RedirectToPoliceHomePage();
      }

      private void SignOut()
      {
         FormsAuthentication.SignOut();
         Response.Expires = 0;
      }

      private void RedirectToPoliceHomePage()
      {
         try
         {
            Response.Redirect("http://www.seattle.gov/police/");
         }
         catch (System.Threading.ThreadAbortException)
         {
         }
      }
   }
}
