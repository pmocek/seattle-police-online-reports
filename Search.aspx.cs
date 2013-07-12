using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using Seattle.DoIT.PoliceReports.Web.UI;
using Seattle.DoIT.PoliceReports.Web.PoliceReportServices;

namespace Seattle.DoIT.PoliceReports.Web
{
   public partial class Search : SecuredPage
   {
      private const string _defaultDateTimeFormat = "MM/dd/yyyy";
      private const string _reportDescriptionFormat = "{0} - {1} - {2}{3}";
      private const string _reportDescriptionDateTimeFormat = "MMM d yyyy h:mmtt";
      private const string _manualReportReleaseType = "1";
      private const string _manualPoliceReportSuffix = "*";

      protected void Page_Load(object sender, EventArgs e)
      {
         if (!IsPostBack)
         {
            InitializeOffenseDropDown();
            InitializeSearchDateRange();
         }
      }

      private void InitializeOffenseDropDown()
      {
         OffenseTypeDropDownList.DataSource = GetAllOffenseTypes();
         OffenseTypeDropDownList.DataBind();
      }

      private void InitializeSearchDateRange()
      {
         DateTime today = DateTime.Today;
         DateRangeBoundary2 = today;
         DateRangeBoundary1 = today.AddDays(-7);
      }

      protected void SearchButton_Click(object sender, EventArgs e)
      {
         if (IsValid)
         {
            try
            {
               ResultsRepeater.DataSource = null;
               PoliceReportSummaryQuery query = CreateQuery();
               IEnumerable<PoliceReportSummary> reportSummaries = GetQueryResults(query);
               UpdateSearchResults(reportSummaries);
            }
            catch (Exception x)
            {
               DisplayEmptyResults();
            }
         }
      }

      private string ResultCountMessage
      {
         get { return ResultCountMessageLabel.Text; }
         set { ResultCountMessageLabel.Text = value; }
      }

      private void DisplayEmptyResults()
      {
         ResultsRepeater.DataSource = null;
         ResultsRepeater.DataBind();
         ResultsRepeater.Visible = false;
         ResultCountMessage = Resources.Messages.NoReportsFoundMessage;
      }

      private DateTime DateRangeBoundary1
      {
         get
         {
            DateTime dateRangeBoundary;
            return DateTime.TryParse(DateRange1TextBox.Text, out dateRangeBoundary) ?
               dateRangeBoundary.Date : DateTime.Today;
         }
         set
         {
            DateRange1TextBox.Text = value.Date.ToString(_defaultDateTimeFormat);
         }
      }

      private DateTime DateRangeBoundary2
      {
         get
         {
            DateTime dateRangeBoundary;
            return DateTime.TryParse(DateRange2TextBox.Text, out dateRangeBoundary) ?
               dateRangeBoundary.Date : DateTime.Today;
         }
         set
         {
            DateRange2TextBox.Text = value.Date.ToString(_defaultDateTimeFormat);
         }
      }

      private PoliceReportSummaryQuery CreateQuery()
     {
         string[] offenseCodeFilter = OffenseTypeDropDownList.SelectedValue == "0" ?
            null : new string[1] { OffenseTypeDropDownList.SelectedValue };
         DateTime dateRangeBoundary1 = DateRangeBoundary1;
         DateTime dateRangeBoundary2 = DateRangeBoundary2;
         DateTime startDate = dateRangeBoundary1 <= dateRangeBoundary2 ? dateRangeBoundary1 : dateRangeBoundary2;
         DateTime endDate = dateRangeBoundary1 > dateRangeBoundary2 ? dateRangeBoundary1 : dateRangeBoundary2;
         return PoliceReportSummaryQueryFactory.Create(offenseCodeFilter, startDate, endDate);
      }

      private IEnumerable<PoliceReportSummary> GetQueryResults(PoliceReportSummaryQuery query)
      {
         IEnumerable<PoliceReportSummary> sortedReportSummaries = null;
         if (query != null)
         {
            PoliceReportSummary[] reportSummaries = null;
            PoliceReportService svc = PoliceReportServiceFactory.Create();
            using (svc as IDisposable)
            {
               reportSummaries = svc.GetReportSummariesByQuery(query);
            }
            if (reportSummaries != null)
            {
               sortedReportSummaries =
                  reportSummaries.OrderByDescending(r => r.OccurrenceDate).ThenBy(r => r.OffenseCode).ThenBy(r => r.AddressBlock);
            }
         }
         return sortedReportSummaries;
      }

      private void UpdateSearchResults(IEnumerable<PoliceReportSummary> reportSummaries)
      {
         if (reportSummaries == null || reportSummaries.Count() == 0)
         {
            DisplayEmptyResults();
         }
         else
         {
            int actualResultCount = reportSummaries.Count();
            int maxResultCount = PoliceReportSummaryQuerySettings.MaxQueryResultCount;

            IEnumerable<PoliceReportSummary> resultData = reportSummaries.Take(maxResultCount);

            /*
            var resultData = from s in reportSummaries.Take(maxResultCount)
                             select new 
                             {
                                GoNumber = s.GoNumber,
                                Description = string.Format(descriptionFormat, s.OccurrenceDate.ToString("MMM d yyyy h:mmtt"), s.OffenseCode, s.AddressBlock)
                             };
            */
            /*
            IEnumerable<PoliceReportSummary> displayedReportSummaries = actualResultCount > maxResultCount ?
               reportSummaries.Take(maxResultCount) : reportSummaries;
            int displayedResultCount = displayedReportSummaries.Count();
            */
            int displayedResultCount = resultData.Count();

            ResultsRepeater.DataSource = resultData;
            ResultsRepeater.DataBind();
            ResultsRepeater.Visible = true;
            string msgFormat = actualResultCount > displayedResultCount ?
               Resources.Messages.TooManyReportsFoundMessageFormat : Resources.Messages.ReportsFoundMessageFormat;
            ResultCountMessage = string.Format(msgFormat, displayedResultCount);
         }
      }

      public string FormatReportDescription(PoliceReportSummary report)
      {
         string desc = string.Empty;

         if (report != null)
         {
            desc = string.Format(_reportDescriptionFormat,
                                 report.OccurrenceDate.ToString(_reportDescriptionDateTimeFormat),
                                 report.OffenseCode,
                                 report.AddressBlock,
                                 string.Compare(report.ReleaseType, _manualReportReleaseType, true) == 0 ? _manualPoliceReportSuffix : string.Empty);
         }

         return desc;
      }

      private string[] GetAllOffenseTypes()
      {
         string[] offenseTypes = null;
         PoliceReportService svc = PoliceReportServiceFactory.Create();
         using (svc as IDisposable)
         {
            offenseTypes = svc.GetAllOffenseTypes();
         }
         return offenseTypes;
      }
   }
}
