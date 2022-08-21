using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class VendorMasterReport : BaseDTO
    {
        public Int16 ID
        { 
            get; 
            set; 
        }
        public Int16 VendorID
        {
            get;
            set;
        }
        public String  VendorName
        { get; 
          set; 
        }
        public String VendorNumber
        {
            get;
            set;
        }

        public String ContactPerson
        {
            get;
            set;
        }
        public String CategoryCode
        {
            get;
            set;
        }
        public String MerchandiseCategory
        {
            get;
            set;
        } 
        public String LeadTime
        {
            get;
            set;
        } 
        public decimal VendorRestriction
        { 
            get; 
            set; 
        }
       //For Contact Person
        public String ContactPersonMobNo { get; set; }
        public String ContactPersonFirstName
        {
            get;
            set;
        }
        public String ContactPersonMiddleName
        {
            get;
            set;
        }
        public String ContactPersonLastName
        {
            get;
            set;
        }
        
        public string ContactPersonEmailID { get; set; }
        public bool IsPosted { get; set; }
        public string ReportFor{ get; set; }
        public String VendorReportList{get; set;}
        public string ListAllVendor { get; set; }


    }
}
