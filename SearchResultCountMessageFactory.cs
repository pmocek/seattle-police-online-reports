using System;

namespace Seattle.DoIT.PoliceReports.Web
{
   public class SearchResultCountMessageFactory
   {
      public static string Create(int displayedResultCount, int actualResultCount)
      {
         string msg;
         if (displayedResultCount < 1)
         {
            msg = "No reports found";
         }
         else if (actualResultCount > displayedResultCount)
         {
            msg = string.Format("More than {0} reports found. Displaying latest {1}. Plea");
         }
         else
         {
            msg = string.Format("{0} reports found.");
         }
         return msg;
      }
   }
}
