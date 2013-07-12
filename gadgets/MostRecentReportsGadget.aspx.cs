using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Seattle.DoIT.PoliceReports.Web.UI;
using Seattle.DoIT.PoliceReports.Web.PoliceReportServices;
using System.Text;


namespace Seattle.DoIT.PoliceReports.Web
{
   public partial class MostRecentReportsGadget : SecuredGadgetPage
   {
      private const string _comma = ",";
      private const string _manualReportReleaseType = "1";
      private const string _manualPoliceReportSuffix = "*";

      protected void Page_Load(object sender, EventArgs e)
      {
         if (!IsPostBack)
         {
            RefreshTreeData();
         }
      }

      private void RefreshTreeData()
      {
         try
         {
            PoliceReportSummary[] reportSummaries = GetMostRecentReportSummaries();
            string treeDataJson = TreeDataJson = GetTreeDataJson(reportSummaries);
            if (treeDataJson.Length == 0)
            {
               DisplayNoReportsFoundMessage();
            }
            else
            {
               HideNoReportsFoundMessage();
            }
         }
         catch(Exception x)
         {
            DisplayNoReportsFoundMessage();
         }
      }

      private string TreeDataJson
      {
         get { return ViewState["TreeDataJson"] == null ? "null" : Convert.ToString(ViewState["TreeDataJson"]); }
         set { ViewState["TreeDataJson"] = value; }
      }

      private void DisplayNoReportsFoundMessage()
      {
         NoReportsFoundMessage.Visible = true;
      }

      private void HideNoReportsFoundMessage()
      {
         NoReportsFoundMessage.Visible = false;
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

      private string GetTreeDataJson(PoliceReportSummary[] summaryList)
      {
         string json = string.Empty;

         if (summaryList != null && summaryList.Length > 0)
         {
            // Sort/group the list
            const string nodeDisplayFormat = "{0} ({1})";
            var data = from s1 in summaryList group s1 by s1.ReportedDate.Date into dateGroup orderby dateGroup.Key descending
               select new
               {
                  data = string.Format(nodeDisplayFormat, dateGroup.Key.ToShortDateString(), dateGroup.Count()),
                  children = from s2 in dateGroup group s2 by s2.OffenseCode into offenseGroup orderby offenseGroup.Key ascending
                     select new
                     {
                        data = string.Format(nodeDisplayFormat, offenseGroup.Key, offenseGroup.Count()),
                        children = from s3 in offenseGroup orderby s3.OccurrenceDate.Date descending, s3.AddressBlock ascending 
                           select new
                           {
                              GoNumber = s3.GoNumber,
                              AddressBlock = string.Compare(s3.ReleaseType, _manualReportReleaseType, true) == 0 ? s3.AddressBlock + _manualPoliceReportSuffix : s3.AddressBlock
                           }
                     }
               };

            
            // Build json string 
            string reportClientUrlPrefix = Page.ResolveUrl("~/PoliceReport.ashx?go=");
            StringBuilder sb = new StringBuilder();
            sb.Append(JsTreeHelper.JsonDataArrayPrefix);
            bool firstDate = true;
            foreach (var dateNode in data)
            {
               if (!firstDate)
               {
                  sb.Append(_comma);
               }
               sb.Append(JsTreeHelper.JsonFolderDataPrefix);
               sb.Append(dateNode.data);
               sb.Append(JsTreeHelper.JsonChildrenPrefix);
               bool firstOffense = true;
               foreach (var offenseNode in dateNode.children)
               {
                  if (!firstOffense)
                  {
                      sb.Append(_comma);
                  }

                  sb.Append(JsTreeHelper.JsonFolderDataPrefix); // inner data 1
                  sb.Append(offenseNode.data);
                  sb.Append(JsTreeHelper.JsonChildrenPrefix); // inner children
                  bool firstReport = true;
                  foreach (var reportNode in offenseNode.children)
                  {
                     if (!firstReport)
                     {
                        firstReport = false;
                        sb.Append(_comma);
                     }
                     sb.Append(JsTreeHelper.JsonReportDataPrefix); // inner data 1
                     sb.Append(reportNode.AddressBlock);
                     sb.Append(JsTreeHelper.JsonReportLinkAttrPrefix);
                     sb.Append(reportClientUrlPrefix);
                     sb.Append(reportNode.GoNumber);
                     sb.Append(JsTreeHelper.JsonReportLinkAttrSuffix);
                     firstReport = false;
                  }
                  sb.Append(JsTreeHelper.JsonChildrenSuffix); // inner children/data
                  firstOffense = false;
               }
               sb.Append(JsTreeHelper.JsonChildrenSuffix); // children/data
               firstDate = false;
            }
            sb.Append(JsTreeHelper.JsonDataArraySuffix);
            json = sb.ToString();
         }

         return json;
      }

      protected override void OnPreRender(EventArgs e)
      {
         string scriptKey = "treedata";
         Type pageType = this.GetType();
         if (!ClientScript.IsStartupScriptRegistered(pageType,scriptKey))
         {
            ClientScript.RegisterStartupScript(pageType, scriptKey, "<script type=\"text/javascript\"> var treeData = " + TreeDataJson + ";</script>");
         }
         base.OnPreRender(e);
      }
   }
}
