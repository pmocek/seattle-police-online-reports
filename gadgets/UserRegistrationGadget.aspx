<%@ Page Title="City of Seattle Online Police Reports Registration" Language="C#" MasterPageFile="~/Master/BasicGadget.Master" AutoEventWireup="true" CodeBehind="UserRegistrationGadget.aspx.cs" Inherits="Seattle.DoIT.PoliceReports.Web.UserRegistrationGadget" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
<div style="min-height:300px; padding: 10px">
      <h3>Terms and Conditions of Use</h3>
      <p>
         Seattle Police Reports are available, to the public, at the public counter of the Police Department 
         Records Section. The <a href="http://www.seattle.gov/police/contact/location/request_unit.htm" target="_blank">Police Records Public Request Unit</a> 
         is located at 610 - 5th Ave., at the corner of 5th Ave and Cherry St. You may also get a copy of a 
         Seattle Online Police Report over the Internet using this site. Please read the following terms of use, 
         then click the checkbox below to continue with the registration process. If you do not agree to the terms of 
         use for this service, you must obtain copies of Seattle Police Reports at the Police Records public counter.   
      </p>
      <hr />
      <p>
         The City of Seattle will obtain your e-mail address for the purposes of authenticating access to the Seattle 
         Online Police Report Request Internet application consistent with the <a href="http://www.seattle.gov/pan/privacypol.htm" target="_blank">City of Seattle privacy policies</a>. 
         Your email address will be used solely for this purpose and will not be accessed or divulged to third parties, 
         except as allowed by applicable federal, state or local laws.
      </p>
      <p>
         By agreeing to these terms of use, you affirm that you will not attempt or succeed in abusing, altering, or 
         otherwise circumventing controls set up to limit access to this site, and you understand that access to this 
         site is not a guarantee and your user account may be terminated at the sole discretion of the City of Seattle 
         at any time.
      </p>
      <p>
         Your agreement acknowledges that any abuses resulting from the use or attempted use of this site may subject 
         you to civil or criminal penalties under local, state and federal laws.
      </p>
      <p>
         You also understand that the City of Seattle in no way guarantees that this site will be available at any given 
         time, and that the City is not responsible for any inconvenience or losses that may occur due to the unavailability 
         of this site.  Additionally changes in policies and/or laws may limit the content or terminate this site in the future.
      </p>
      <div style="text-align:center">
         <div>
            <asp:CheckBox ID="AgreeCheckbox" runat="server" Checked="false" EnableViewState="false" Text="I agree to these terms and conditions" />            
         </div>
         <div>
            <asp:CustomValidator ID="AcceptCheckboxIsCheckedValidator" runat="server" ErrorMessage="You must accept the terms and conditions to register." 
               Display="Dynamic" EnableClientScript="False" EnableViewState="False" onservervalidate="AcceptCheckboxIsCheckedValidator_ServerValidate"/>
         </div>
      </div>
      <p style="text-align:center">
            <asp:Button ID="RegisterButton" runat="server" Text="Register" onclick="RegisterButton_Click" />
      </p>
   </div>
</asp:Content>
