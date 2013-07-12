using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Seattle.DoIT.PoliceReports.Web
{
   internal class JsTreeHelper
   {
      public const string JsonDataArrayPrefix = "{\"data\": [";
      public const string JsonDataArraySuffix = "],\"progressive_render\":true}";
      public const string JsonFolderDataPrefix = "{\"data\":\"";
      public const string JsonFolderDataSuffix = "{\"data\":\"";
      public const string JsonReportDataPrefix = "{\"data\":{\"title\": \"";
      public const string JsonChildrenPrefix = "\",\"children\": [";
      public const string JsonChildrenSuffix = "]}";
      public const string JsonReportLinkAttrPrefix = "\",\"attr\": { \"href\": \"";
      public const string JsonReportLinkAttrSuffix = "\",\"target\": \"_blank\" }}}";
   }
}