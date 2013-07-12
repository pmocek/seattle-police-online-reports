<%@ Page Title="City of Seattle Online Police Reports Search" Language="C#" MasterPageFile="~/Master/PoliceReport.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="Seattle.DoIT.PoliceReports.Web.Search" %>
<asp:Content id="HeadContent" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
   <script type="text/javascript">
	   $(function() {
	      var $NavTabs = $("#ReportSearchTabs").tabs({
	         select: function(event, ui) {
	            var url = $.data(ui.tab, "load.tabs");
	            if (url) {
	               location.href = url;
	               return false;
	            }
	            return true;
	         },
	         selected: 1
	      });
	      $(".DateTime").datepicker({ showOn: "both", buttonImage: "images/icon_date_picker.png", buttonImageOnly: true });
	   });		
	</script>
</asp:Content>
<asp:Content id="MainContent" contentplaceholderid="MainContentPlaceHolder" runat="server">
   <div id="ReportSearchTabs">
       <ul>
           <li><a href="Default.aspx">MOST RECENT OFFENSES</a> </li>
           <li><a href="#AdvancedSearchTab">SEARCH</a> </li>
       </ul>
      <div id="AdvancedSearchTab">
         <table id="AdvancedSearchCriteriaTable" border="0" cellpadding="1" cellspacing="1" style="text-align:left">
            <tr>
               <td>Offense:</td>
               <td colspan="2">
                  <asp:DropDownList id="OffenseTypeDropDownList" runat="server" AppendDataBoundItems="true">
                     <asp:ListItem text="- Any -" value="0" />
                  </asp:DropDownList>
               </td>
            </tr>
            <tr>
               <td>Occurred Date Range:</td>
               <td><asp:TextBox id="DateRange1TextBox" runat="server" maxlength="10" cssclass="DateTime" /></td>
            </tr>
            <tr>
               <td>
               </td>
               <td><asp:TextBox id="DateRange2TextBox" runat="server" maxlength="10" cssclass="DateTime" /></td>
               <td style="text-align:right"><asp:Button id="SearchButton" runat="server" text="Search" OnClick="SearchButton_Click" /></td>
            </tr>
         </table>
         <hr />
         <table border="0" cellpadding="0" cellspacing="1">
            <tr>
               <td style="width: 1%; white-space:nowrap; padding-right: 2ex; vertical-align: top">Search Results:</td>
               <td style="vertical-align:top"><asp:Label id="ResultCountMessageLabel" runat="server"></asp:Label></td>
            </tr>
         </table>
         <asp:Repeater id="ResultsRepeater" runat="server" visible="false">
            <HeaderTemplate>
               <ul class="med_blue SearchResults">
            </HeaderTemplate>
            <ItemTemplate>
               <li><a class="med_blue" href='<%# DataBinder.Eval(Container.DataItem, "GoNumber", "PoliceReport.ashx?go={0}") %>' target="_blank"><%# Server.HtmlEncode(((Seattle.DoIT.PoliceReports.Web.Search)Page).FormatReportDescription((Seattle.DoIT.PoliceReports.Web.PoliceReportServices.PoliceReportSummary)Container.DataItem))%></a></li>
            </ItemTemplate>
            <FooterTemplate>
               </ul>
            </FooterTemplate>
         </asp:Repeater>
      </div>  
   </div>
</asp:Content>
