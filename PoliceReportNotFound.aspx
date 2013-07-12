<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Basic.Master" AutoEventWireup="true" CodeBehind="PoliceReportNotFound.aspx.cs" Inherits="Seattle.DoIT.PoliceReports.Web.PoliceReportNotFound" EnableViewState="false" %>
<asp:Content ID="HeadContent" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
   <script type="text/javascript">
      function CloseWindow() {
         window.focus();
         window.close();
      }
   </script>
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
   <div style="margin: 100px 0px; text-align:center">
      <p >Police Report Not Found.</p>
      <input type="button" onclick="javascript:CloseWindow();" value="Close"/>
   </div>
</asp:Content> 
