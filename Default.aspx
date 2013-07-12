<%@ Page Title="City of Seattle Online Police Reports" Language="C#" MasterPageFile="~/Master/PoliceReport.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Seattle.DoIT.PoliceReports.Web._Default" %>
<asp:Content id="HeadContent" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
	<script type="text/javascript">
	   $(function () {
	      $("#ReportSearchTabs").tabs({
	         select: function (event, ui) {
	            var url = $.data(ui.tab, "load.tabs");
	            if (url) {
	               location.href = url;
	               return false;
	            }
	            return true;
	         }
	      });
      });
      $(function() {
	      if (treeData != null) {
	         $(function () {
	            var tree = $('#MostRecentReportsTree').jstree({
	               'core': {
	                  'animation': 200
	               },
	               'themes': {
	                  'theme': 'default',
	                  'dots': false,
	                  'icons': false
	               },
	               'json_data': treeData,
	               'plugins': ['themes', 'types', 'json_data', 'seaui']
	            });
	         });
	      }
	   });		
	</script>
   <style type="text/css">
      .jstree a:hover { text-decoration: underline !important; }
   </style>
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
   <div id="ReportSearchTabs">
      <ul>
         <li><a href="#MostRecentReportsTab">MOST RECENT OFFENSES</a> </li>
         <li><a href="Search.aspx">SEARCH</a> </li>
      </ul>
      <div id="MostRecentReportsTab">
         <p>Most recently reported offenses:</p>
         <p id="NoReportsFoundMessage" runat="server">No offenses found.</p>
         <div id="MostRecentReportsTree" class="med_blue"></div>
      </div>
   </div>
</asp:Content>
