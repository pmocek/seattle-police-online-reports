<%@ Page Title="City of Seattle Online Police Reports" Language="C#" MasterPageFile="~/Master/PoliceReport.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Seattle.DoIT.PoliceReports.Web._Default" %>
<asp:Content id="HeadContent" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
	<script type="text/javascript">
	   $(function() {
	      $("#ReportSearchTabs").tabs({
	         select: function(event, ui) {
	            var url = $.data(ui.tab, "load.tabs");
	            if (url) {
	               location.href = url;
	               return false;
	            }
	            return true;
	         }
	      });
	      $("#MostRecentReportsTree").treeview({ collapsed: true, animated: "fast", persist: "location" });
	   });		
	</script>
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
   <div id="ReportSearchTabs">
      <ul>
         <li><a href="#MostRecentReportsTab">MOST RECENT OFFENSES</a> </li>
         <li><a href="Search.aspx">SEARCH</a> </li>
      </ul>
      <div id="MostRecentReportsTab">
         <p id="NoReportsFoundMessage" runat="server">No offenses found.</p>
         <asp:Repeater id="MostRecentReportsRepeater" runat="server" Visible="false">
            <HeaderTemplate>
               <ul id="MostRecentReportsTree" class="med_blue" style="margin: 1em 0px">
            </HeaderTemplate>
            <ItemTemplate>
               <li>
                  <span><%# DataBinder.Eval(Container.DataItem, "ReportedDate")%></span>
                  <asp:Repeater id="OffenseTypeRepeater" runat="server" DataSource='<%# DataBinder.Eval(Container.DataItem, "Offenses") %>'>
                     <HeaderTemplate>
                        <ul>
                     </HeaderTemplate>
                     <ItemTemplate>
                        <li>
                           <span><%# DataBinder.Eval(Container.DataItem, "Offense")%></span>
                           <asp:Repeater id="ReportLinkRepeater" runat="server" DataSource='<%# DataBinder.Eval(Container.DataItem, "Reports") %>'>
                              <HeaderTemplate>
                                 <ul>
                              </HeaderTemplate>
                              <ItemTemplate>
                                    <li><a class="med_blue" href='<%# DataBinder.Eval(Container.DataItem, "GoNumber", "PoliceReport.ashx?go={0}") %>' target="_blank"><%# Server.HtmlEncode(DataBinder.Eval(Container.DataItem, "Name").ToString()) %></a></li>
                              </ItemTemplate>
                              <FooterTemplate>
                                 </ul>  
                              </FooterTemplate>
                           </asp:Repeater>
                        </li>
                     </ItemTemplate>
                     <FooterTemplate>
                        </ul>  
                     </FooterTemplate>
                  </asp:Repeater>
               </li>
            </ItemTemplate>
            <FooterTemplate>
               </ul>  
            </FooterTemplate>
         </asp:Repeater>
      </div>
   </div>
</asp:Content>
