using System;
using Seattle.DoIT.PoliceReports.Web.PoliceReportServices;

namespace Seattle.DoIT.PoliceReports.Web
{
   internal class PoliceReportSummaryQueryFactory
   {
      public static PoliceReportSummaryQuery Create()
      {
         return new PoliceReportSummaryQuery();
      }
      public static PoliceReportSummaryQuery Create(string[] offenseCodeFilter, DateTime startDate, DateTime endDate)
      {
         if (endDate < startDate)
            throw new ArgumentException("End date cannot occur before start date");

         PoliceReportSummaryQuery query = new PoliceReportSummaryQuery();
         if (offenseCodeFilter != null)
         {
            query.OffenseCodeFilter = (string[])(offenseCodeFilter.Clone());
         }
         query.OccurrenceStartDateTime = startDate;
         query.OccurrenceEndDateTime = endDate;
         return query;
      }
   }
}
