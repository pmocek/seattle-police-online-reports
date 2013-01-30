﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Seattle.DoIT.PoliceReports.Web.PoliceReportServices {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="PoliceReportSummary", Namespace="http://www.seattle.gov/DoIT/SPD/Services/2010/02/")]
    [System.SerializableAttribute()]
    public partial class PoliceReportSummary : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string GoNumberField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime OccurrenceDateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string OffenseCodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime ReportedDateField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string GoNumber {
            get {
                return this.GoNumberField;
            }
            set {
                if ((object.ReferenceEquals(this.GoNumberField, value) != true)) {
                    this.GoNumberField = value;
                    this.RaisePropertyChanged("GoNumber");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime OccurrenceDate {
            get {
                return this.OccurrenceDateField;
            }
            set {
                if ((this.OccurrenceDateField.Equals(value) != true)) {
                    this.OccurrenceDateField = value;
                    this.RaisePropertyChanged("OccurrenceDate");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string OffenseCode {
            get {
                return this.OffenseCodeField;
            }
            set {
                if ((object.ReferenceEquals(this.OffenseCodeField, value) != true)) {
                    this.OffenseCodeField = value;
                    this.RaisePropertyChanged("OffenseCode");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime ReportedDate {
            get {
                return this.ReportedDateField;
            }
            set {
                if ((this.ReportedDateField.Equals(value) != true)) {
                    this.ReportedDateField = value;
                    this.RaisePropertyChanged("ReportedDate");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="PoliceReportSummaryQuery", Namespace="http://www.seattle.gov/DoIT/SPD/Services/2010/02/")]
    [System.SerializableAttribute()]
    public partial class PoliceReportSummaryQuery : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime OccurrenceEndDateTimeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime OccurrenceStartDateTimeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string[] OffenseCodeFilterField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime OccurrenceEndDateTime {
            get {
                return this.OccurrenceEndDateTimeField;
            }
            set {
                if ((this.OccurrenceEndDateTimeField.Equals(value) != true)) {
                    this.OccurrenceEndDateTimeField = value;
                    this.RaisePropertyChanged("OccurrenceEndDateTime");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime OccurrenceStartDateTime {
            get {
                return this.OccurrenceStartDateTimeField;
            }
            set {
                if ((this.OccurrenceStartDateTimeField.Equals(value) != true)) {
                    this.OccurrenceStartDateTimeField = value;
                    this.RaisePropertyChanged("OccurrenceStartDateTime");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string[] OffenseCodeFilter {
            get {
                return this.OffenseCodeFilterField;
            }
            set {
                if ((object.ReferenceEquals(this.OffenseCodeFilterField, value) != true)) {
                    this.OffenseCodeFilterField = value;
                    this.RaisePropertyChanged("OffenseCodeFilter");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="PoliceReport", Namespace="http://www.seattle.gov/DoIT/SPD/Services/2010/02/")]
    [System.SerializableAttribute()]
    public partial class PoliceReport : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private byte[] ContentField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string GoNumberField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime ModifiedDateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public byte[] Content {
            get {
                return this.ContentField;
            }
            set {
                if ((object.ReferenceEquals(this.ContentField, value) != true)) {
                    this.ContentField = value;
                    this.RaisePropertyChanged("Content");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string GoNumber {
            get {
                return this.GoNumberField;
            }
            set {
                if ((object.ReferenceEquals(this.GoNumberField, value) != true)) {
                    this.GoNumberField = value;
                    this.RaisePropertyChanged("GoNumber");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime ModifiedDate {
            get {
                return this.ModifiedDateField;
            }
            set {
                if ((this.ModifiedDateField.Equals(value) != true)) {
                    this.ModifiedDateField = value;
                    this.RaisePropertyChanged("ModifiedDate");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://www.seattle.gov/DoIT/SPD/Services/2010/05/", ConfigurationName="PoliceReportServices.PoliceReportService")]
    public interface PoliceReportService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.seattle.gov/DoIT/SPD/Services/2010/05/PoliceReportService/GetReportSum" +
            "maryByGoNumber", ReplyAction="http://www.seattle.gov/DoIT/SPD/Services/2010/05/PoliceReportService/GetReportSum" +
            "maryByGoNumberResponse")]
        Seattle.DoIT.PoliceReports.Web.PoliceReportServices.PoliceReportSummary GetReportSummaryByGoNumber(string go);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.seattle.gov/DoIT/SPD/Services/2010/05/PoliceReportService/GetReportSum" +
            "mariesByQuery", ReplyAction="http://www.seattle.gov/DoIT/SPD/Services/2010/05/PoliceReportService/GetReportSum" +
            "mariesByQueryResponse")]
        Seattle.DoIT.PoliceReports.Web.PoliceReportServices.PoliceReportSummary[] GetReportSummariesByQuery(Seattle.DoIT.PoliceReports.Web.PoliceReportServices.PoliceReportSummaryQuery query);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.seattle.gov/DoIT/SPD/Services/2010/05/PoliceReportService/GetReportByI" +
            "d", ReplyAction="http://www.seattle.gov/DoIT/SPD/Services/2010/05/PoliceReportService/GetReportByI" +
            "dResponse")]
        Seattle.DoIT.PoliceReports.Web.PoliceReportServices.PoliceReport GetReportById(string requesterUserName, int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.seattle.gov/DoIT/SPD/Services/2010/05/PoliceReportService/GetReportByG" +
            "oNumber", ReplyAction="http://www.seattle.gov/DoIT/SPD/Services/2010/05/PoliceReportService/GetReportByG" +
            "oNumberResponse")]
        Seattle.DoIT.PoliceReports.Web.PoliceReportServices.PoliceReport GetReportByGoNumber(string requesterUserName, string go);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.seattle.gov/DoIT/SPD/Services/2010/05/PoliceReportService/GetMostRecen" +
            "tSummaries", ReplyAction="http://www.seattle.gov/DoIT/SPD/Services/2010/05/PoliceReportService/GetMostRecen" +
            "tSummariesResponse")]
        Seattle.DoIT.PoliceReports.Web.PoliceReportServices.PoliceReportSummary[] GetMostRecentSummaries();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface PoliceReportServiceChannel : Seattle.DoIT.PoliceReports.Web.PoliceReportServices.PoliceReportService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class PoliceReportServiceClient : System.ServiceModel.ClientBase<Seattle.DoIT.PoliceReports.Web.PoliceReportServices.PoliceReportService>, Seattle.DoIT.PoliceReports.Web.PoliceReportServices.PoliceReportService {
        
        public PoliceReportServiceClient() {
        }
        
        public PoliceReportServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public PoliceReportServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PoliceReportServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PoliceReportServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Seattle.DoIT.PoliceReports.Web.PoliceReportServices.PoliceReportSummary GetReportSummaryByGoNumber(string go) {
            return base.Channel.GetReportSummaryByGoNumber(go);
        }
        
        public Seattle.DoIT.PoliceReports.Web.PoliceReportServices.PoliceReportSummary[] GetReportSummariesByQuery(Seattle.DoIT.PoliceReports.Web.PoliceReportServices.PoliceReportSummaryQuery query) {
            return base.Channel.GetReportSummariesByQuery(query);
        }
        
        public Seattle.DoIT.PoliceReports.Web.PoliceReportServices.PoliceReport GetReportById(string requesterUserName, int id) {
            return base.Channel.GetReportById(requesterUserName, id);
        }
        
        public Seattle.DoIT.PoliceReports.Web.PoliceReportServices.PoliceReport GetReportByGoNumber(string requesterUserName, string go) {
            return base.Channel.GetReportByGoNumber(requesterUserName, go);
        }
        
        public Seattle.DoIT.PoliceReports.Web.PoliceReportServices.PoliceReportSummary[] GetMostRecentSummaries() {
            return base.Channel.GetMostRecentSummaries();
        }
    }
}
