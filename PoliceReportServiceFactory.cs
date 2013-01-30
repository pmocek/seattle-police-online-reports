using Seattle.DoIT.PoliceReports.Web.PoliceReportServices;

namespace Seattle.DoIT.PoliceReports.Web
{
   internal class PoliceReportServiceFactory
   {
      public static PoliceReportService Create()
      {
         return new PoliceReportServiceClient();
      }
   }
}
