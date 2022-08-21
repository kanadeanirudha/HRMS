using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class OrganisationMaster : BaseDTO
    {
        public int ID
        {
            get;
            set;
        }
        public string EstablishmentCode
        {
            get;
            set;
        }
        public string OrgName
        {
            get;
            set;
        }
        public string FoundationDatetime
        {
            get;
            set;
        }
        public string FounderMember
        {
            get;
            set;
        }
        public string Address1
        {
            get;
            set;
        }
        public string Address2
        {
            get;
            set;
        }
        public string PlotNumber
        {
            get;
            set;
        }
        public string StreetNumber
        {
            get;
            set;
        }
        public int LocationID
        {
            get;
            set;
        }
        public string Pincode
        {
            get;
            set;
        }
        public string EmailID
        {
            get;
            set;
        }
        public string Url
        {
            get;
            set;
        }
        public string OfficeComment
        {
            get;
            set;
        }
        public string MissionStatement
        {
            get;
            set;
        }
        public string MobileNumber
        {
            get;
            set;
        }
        public string FaxNumber
        {
            get;
            set;
        }
        public string OfficePhone1
        {
            get;
            set;
        }
        public string OfficePhone2
        {
            get;
            set;
        }
        public int TotalRecordsFound
        {
            get;
            set;
        }
        public bool IsActive
        {
            get;
            set;
        }
        public bool IsDeleted
        {
            get;
            set;
        }
        public int CreatedBy
        {
            get;
            set;
        }
        public DateTime CreatedDate
        {
            get;
            set;
        }
        public int? ModifiedBy
        {
            get;
            set;
        }
        public DateTime? ModifiedDate
        {
            get;
            set;
        }
        public int? DeletedBy
        {
            get;
            set;
        }
        public DateTime? DeletedDate
        {
            get;
            set;
        }
        public string errorMessage { get; set; }
        public string PFNumber { get; set; }
        public string ESICNumber { get; set; }
        public string OrgShortCode { get; set; }

    }
}
