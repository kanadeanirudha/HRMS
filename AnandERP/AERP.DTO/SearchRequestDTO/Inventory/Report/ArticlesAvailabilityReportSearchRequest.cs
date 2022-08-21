using System;
using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class ArticlesAvailabilityReportSearchRequest : BaseDTO
    {

        public String VendorName
        {
            get;
            set;
        }
        public string ContactPerson
        {
            get;
            set;
        }
        public String DateFrom
        {
            get;
            set;
        }
        public String DateTo
        {
            get;
            set;
        }

        public string ReportFor { get; set; }
        public int OrganisationMasterKey { get; set; }
        public int GeneralUnitsID { get; set; }
        public string CentreCode { get; set; }
        public string Society { get; set; }
    }
}





