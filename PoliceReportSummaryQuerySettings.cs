using System;
using System.Configuration;

namespace Seattle.DoIT.PoliceReports.Web
{
   internal class PoliceReportSummaryQuerySettings
   {
      private const int _defaultTimeRangeInDays = 7;
      private const int _defaultMaxQueryResultCount = 200;
      public static int MostRecentQueryDefaultTimeRange
      {
         get
         {
            int timeRangeInDays = _defaultTimeRangeInDays;
            return int.TryParse(ConfigurationManager.AppSettings["MostRecentQueryDefaultTimeRange"], out timeRangeInDays) &&
               timeRangeInDays > 0 ? timeRangeInDays : _defaultTimeRangeInDays;
         }
      }

      public static int MaxQueryResultCount
      {
         get
         {
            int maxCount = _defaultMaxQueryResultCount;
            return int.TryParse(ConfigurationManager.AppSettings["MaxQueryResultCount"], out maxCount) && maxCount > 0 ? maxCount : _defaultMaxQueryResultCount;
         }
      }
   }
}
