<%@ Page Title="City of Seattle Online Police Reports" Language="C#" MasterPageFile="~/Master/PoliceReportGadget.Master" AutoEventWireup="true" CodeBehind="MostRecentReportsGadget.aspx.cs" Inherits="Seattle.DoIT.PoliceReports.Web.MostRecentReportsGadget" %>
<asp:Content id="HeadContent" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
	<script type="text/javascript">
	   $(function () {
	      var reportsPanel = $('#ReportsPanel');
	      var helpPanel = $('#HelpPanel');

	      $('#ShowHelpLink').click(function () {
	         reportsPanel.hide();
	         helpPanel.show();
	      });

	      $('#CloseHelpLink').click(function () {
	         helpPanel.hide();
	         reportsPanel.show();
	      });


	      if (treeData != null) {
	         $('#MostRecentReportsTree').jstree({
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
	      }
	   });		
	</script>

</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
   <div id="ReportsPanel" class="panel">
      <div class="panelTitleBar">
         <div class="panelTitle">Most recently reported offenses</div>
         <div class="panelTitleButtonContainer"><a id="ShowHelpLink" href="#">Help</a></div>
      </div>
      <div style="clear:both"></div>
      <div class="gadgetPanelContent">
         <p id="NoReportsFoundMessage" runat="server">No offenses found.</p>
         <div id="MostRecentReportsTree"></div>
       </div>
   </div> 
   <div id="HelpPanel" class="panel" style="display:none">
      <div class="panelTitleBar">
         <div class="panelTitle">Police Reports Help</div>
         <div class="panelTitleButtonContainer"><a id="CloseHelpLink" href="#">Close</a></div>
      </div>
      <div style="clear:both"></div>
      <div class="panelContent">
      	<p>
				<span style="font-weight: bold">General Offense (GO) Reports</span> in PDF format are available for the offenses listed here.  
				These reports are made available within 8 hours after the event is closed.
         </p>
         <p>
            For the major crimes of <span style="font-weight: bold">Burglaries, Robberies, Aggravated Assaults and Homicides</span>, 
            additional information is made available through a redacted full narrative. These reports are available within
            3 business days after the event.
			</p>
			<p>
				Please be aware that these reports recount initial descriptions of crime incidents. Reports are edited only to protect 
            the privacy of the individuals involved. Dialog may be quoted and event descriptions included in some reports may not 
            be appropriate for all viewers.
			</p>
         <p style="font-weight: bold">
            Additional Help Links:
         </p>
         <ul class="helpLinks">
			   <li>
				   <a href="http://www.seattle.gov/police/records/PoliceReportsFAQ.htm#IncidentNumber" target="_blank">Don't have a GO number?</a>
			   </li>
            <li>
               <a href="http://www.seattle.gov/police/records/" target="_blank">Need a Report for Insurance?</a>
            </li>
            <li>
               <a href="http://www.seattle.gov/police/records/" target="_blank">Can't Find a Report?</a>
            </li>
            <li>
               <a href="http://www.seattle.gov/police/records/" target="_blank">Question about Report Content?</a>
            </li>
            <li>
               <a href="http://www.seattle.gov/police/records/" target="_blank">Site Not Working?</a>
            </li>
            <li>
               <a href="http://www.seattle.gov/police/records/PoliceReportsFAQ.htm" target="_blank">Other Frequent Questions</a>
            </li>
         </ul>
       </div>
   </div>
</asp:Content>
