using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Seattle.DoIT.PoliceReports.Web.UI;
using Seattle.DoIT.PoliceReports.Web.PoliceReportServices;


namespace Seattle.DoIT.PoliceReports.Web
{
   public partial class _Default : SecuredPage
   {
      protected void Page_Load(object sender, EventArgs e)
      {
         if (!IsPostBack)
         {
            RefreshMostRecentReports();
         }
      }

      private void RefreshMostRecentReports()
      {
         try
         {
            PoliceReportSummary[] reportSummaries = GetMostRecentReportSummaries();
            object treeData = CreateTreeData(reportSummaries);
            if (treeData == null)
            {
               DisplayNoReportsFoundMessage();
            }
            else
            {
               MostRecentReportsRepeater.DataSource = treeData;
               MostRecentReportsRepeater.DataBind();
               DisplayReportsTreeView();
            }
         }
         catch(Exception x)
         {
            DisplayNoReportsFoundMessage();
         }
      }

      private void DisplayNoReportsFoundMessage()
      {
         NoReportsFoundMessage.Visible = true;
         MostRecentReportsRepeater.Visible = false;
      }

      private void DisplayReportsTreeView()
      {
         NoReportsFoundMessage.Visible = false;
         MostRecentReportsRepeater.Visible = true;
      }

      private PoliceReportSummaryQuery CreateQuery()
      {
         DateTime endDate = DateTime.Today;
         DateTime startDate = endDate.AddDays(-(PoliceReportSummaryQuerySettings.MostRecentQueryDefaultTimeRange));
         return PoliceReportSummaryQueryFactory.Create(null, startDate, endDate);
      }

      private PoliceReportSummary[] GetMostRecentReportSummaries()
      {
         PoliceReportSummary[] reportSummaries = null;
         PoliceReportService svc = PoliceReportServiceFactory.Create();
         using (svc as IDisposable)
         {
            reportSummaries = svc.GetMostRecentSummaries();
         }
         return reportSummaries;
      }

      private object CreateTreeData(PoliceReportSummary[] summaryList)
      {
         object data = null;
         if (summaryList != null)
         {
            const string nodeDisplayFormat = "{0} ({1})";
            data = from s1 in summaryList
                   group s1 by s1.ReportedDate.Date into dateGroup
                   orderby dateGroup.Key descending
                   select new
                   {
                      ReportedDate = string.Format(nodeDisplayFormat, dateGroup.Key.ToShortDateString(), dateGroup.Count()),
                      Offenses = from s2 in dateGroup
                                     group s2 by s2.OffenseCode into offenseGroup
                                     orderby offenseGroup.Key ascending
                                     select new
                                     {
                                        Offense = string.Format(nodeDisplayFormat, offenseGroup.Key, offenseGroup.Count()),
                                        Reports = from s3 in offenseGroup
                                                  orderby s3.OccurrenceDate descending
                                                  select new
                                                  {
                                                    Id = s3.Id,
                                                    GoNumber = s3.GoNumber,
                                                    Name = s3.Name
                                                  }
                                     }
                   };
         }
         return data;
      }
   }
}
