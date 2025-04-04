using System;

namespace Graph.API.DataTransfers;

    public class UpdatePersonRequest
    {
        public string name_first { get; set; }
        public string name_last { get; set; }
        public string name_other { get; set; }
        public UpdatePersonAddress address { get; set; }
        public UpdateBackgroundInformation background_information { get; set; }
        public List<UpdateDocument> documents { get; set; }
    }

    public class UpdatePersonAddress
    {
        public string line1 { get; set; }
        public string line2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public string postal_code { get; set; }
    }

    public class UpdateBackgroundInformation
    {
        public string employment_status { get; set; }
        public string occupation { get; set; }
        public string primary_purpose { get; set; }
        public string source_of_funds { get; set; }
        public int expected_monthly_inflow { get; set; }
    }

    public class UpdateDocument
    {
        public string type { get; set; }
        public string url { get; set; }
        public string issue_date { get; set; }
        public string expiry_date { get; set; }
    }

  


