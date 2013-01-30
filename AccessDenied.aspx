<%@ Page Title="City of Seattle Online Police Reports - Access Denied" Language="C#" MasterPageFile="~/Master/Basic.Master" AutoEventWireup="true" CodeBehind="AccessDenied.aspx.cs" Inherits="Seattle.DoIT.PoliceReports.Web.AccessDenied" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
   <div style="padding:10px; min-height:300px">
      <p>
         Your permissions to use the Seattle Police Reports Online have been revoked. You may request 
         Seattle Police Reports at the public counter of the Police Department Records Section. The 
         <a href="http://www.seattle.gov/police/contact/location/request_unit.htm" target="_blank">Police Records Public Request Unit</a> 
         is located at 610 - 5th Ave., at the corner of 5th Ave and Cherry St.
      </p>
   </div>
</asp:Content>
