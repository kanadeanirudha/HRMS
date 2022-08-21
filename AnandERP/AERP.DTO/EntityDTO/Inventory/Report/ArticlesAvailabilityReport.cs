using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class ArticlesAvailabilityReport : BaseDTO
    {
       
        public string DateFrom { get; set; }
        public string DateTo { get; set; }

        public int  SrNo { get; set; }
        public string Society { get; set; }
        public string Centre { get; set; }
        public string CentreCode { get; set; }
        public string Store { get; set; }
        public string Vendor { get; set; }
       

        public int TotalListedArticles { get; set; }
        public int AvailableArticles { get; set; }
        public int GeneralUnitsID { get; set; }
        public decimal Percentage { get; set; }
        public bool IsPosted { get; set; }

        public int OrganisationMasterKey { get; set; }
    }
}
