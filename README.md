seattle-police-online-reports
=============================

City of Seattle police reports webapp

Source code to City of Seattle's [online police reports application][1] was
requested by Phil Mocek on 2010-08-06 and received via e-mail from D'Anne Mount
of the City of Seattle Department of Information Technology on 2010-09-10, with
the note, "I am responding to your request for a copy of the source code for
the Seattle Police Department's Online Police Reports Web application from the
Department of Information Technology.  Attached is a copy of the source code
with redactions made in accordance with [RCW 42.56.420(4)][2]."

An updated version was [requested on 2013-01-30][3], provided by Megan
Coppersmith of Seattle Department of Information Technology on 2013-06-03, and
received by Phil Mocek on 2013-07-11.  Updates were then merged and committed
to this repository.

With the 2013-06-03 update, Ms. Coppersmith wrote:

> Information that would provide access to the Seattle Police Department's
> database and other City databases has been redacted throughout the responsive
> records. This information is exempt under RCW 42.56.420(4), which exempts
> "[i]nformation regarding the infrastructure and security of computer and
> telecommunications networks, consisting of security passwords, security
> access codes and programs, access codes for secure software applications,
> security and service recovery plans, security risk assessments, and security
> test results to the extent that they identify specific system
> vulnerabilities." Providing unauthorized access to the City's databases could
> compromise the security of those databases, impair the City's ability to
> perform vital governmental operations and inhibit the City's ability to
> provide a response in an emergency.

Those redactions appear to be indicated by the text "** REDACTED **" which
appears in the following files:

  * Service References/SsoServices/BasicProfile.disco
  * Service References/SsoServices/SingleSignOnProfileService.wsdl
  * Service References/SsoServices/Reference.svcmap
  * Service References/SsoServices/configuration91.svcinfo
  * Service References/SsoServices/configuration.svcinfo
  * Service References/UserProfileServices/configuration91.svcinfo
  * Service References/UserProfileServices/configuration.svcinfo
  * Service References/PoliceReportServices/configuration91.svcinfo
  * Service References/PoliceReportServices/configuration.svcinfo
  * Web.config


 [1]: <https://www.seattle.gov/police/records/>
      (Seattle Police Department: View Police Reports Online)
 [2]: <http://apps.leg.wa.gov/rcw/default.aspx?cite=42.56.420>
      (RCW Title 42 > Chapter 42.56 > Section 42.56.420: Security)
 [3]: <https://www.muckrock.com/foi/seattle-69/source-code-for-seattle-police-dept-online-police-reports-application-2633/>
      (MuckRock: FOI Request: Source code for Seattle Police Dept Online Police Reports application)
