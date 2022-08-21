using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class GeneralBoardUniversityMaster : BaseDTO
    {
        public int ID
        {
            get;
            set;
        }
        public string UniversityName
        {
            get;
            set;
        }
        public string EstablishmentCode
        {
            get;
            set;
        }
        public DateTime UniversityFoundationDatetime
        {
            get;
            set;
        }
        public string UniversityFounderMember
        {
            get;
            set;
        }
        public string UniversityAddress1
        {
            get;
            set;
        }
        public string UniversityAddress2
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
        public int CityID
        {
            get;
            set;
        }
        public string Pincode
        {
            get;
            set;
        }
        public string FaxNumber
        {
            get;
            set;
        }
        public string PhoneNumberOffice
        {
            get;
            set;
        }
        public string Extention
        {
            get;
            set;
        }
        public string CellPhone
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
        public bool DefaultFlag
        {
            get;
            set;
        }
        public string UniversityReportPath
        {
            get;
            set;
        }
        public string UniversityShortName
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
    }
}
