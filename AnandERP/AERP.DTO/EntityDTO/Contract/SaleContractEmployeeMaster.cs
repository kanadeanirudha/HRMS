using AERP.Base.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.DTO
{
    public class SaleContractEmployeeMaster : BaseDTO
    {
        public int ID
        {
            get;
            set;
        }

        public string Title
        {
            get;
            set;
        }

        public string FirstName
        {
            get;
            set;
        }

        public string MiddleName
        {
            get;
            set;
        }

        public string LastName
        {
            get;
            set;
        }

        public string EmployeeCode
        {
            get;
            set;
        }
        public string EmployeeName
        {
            get;
            set;
        }

        public string FirstJoiningDate
        {
            get;
            set;
        }
        public string LastLeftDate
        {
            get;
            set;
        }

        public bool IsLeft
        {
            get; set;
        }
        public Int32 SaleContractEmployeeMasterID
        {
            get; set;
        }
        public string JoiningDate
        {
            get; set;
        }
        public string LeftDate
        {
            get; set;
        }
        public string EmailID
        {
            get; set;
        }
        public string BirthDate
        {
            get; set;
        }
        public int NationalityID
        {
            get; set;
        }
        public string Nationality
        {
            get;set;
        }
        public string GenderCode
        {
            get; set;
        }
        public string MarritalStaus
        {
            get; set;
        }
        public string SSNNumber
        {
            get; set;
        }
        public string SINNumber
        {
            get; set;
        }
        public string DrivingLicenceNumber
        {
            get; set;
        }
        public string DrivingLicenceExpireDate
        {
            get; set;
        }
        public string OtherEmailID
        {
            get; set;
        }
        public string PanNumber
        {
            get; set;
        }
        public string ESINumber
        {
            get; set;
        }
        public string ProvidentFundNumber
        {
            get; set;
        }
        public string ProvidentFundApplicableDate
        {
            get; set;
        }
        public string BankName
        {
            get; set;
        }
        public byte BankMasterID
        {
            get;set;
        }
        public string BankACNumber
        {
            get; set;
        }
        public string BankIFSICode
        {
            get; set;
        }
        public string Address1
        {
            get; set;
        }
        public string Address2
        {
            get; set;
        }
        public int CityID
        {
            get; set;
        }
        public int RegionID
        {
            get; set;
        }
        public int CountryID
        {
            get; set;
        }
        public string CityName
        {
            get;set;
        }
        public string Pincode
        {
            get; set;
        }
        public string EmergencyContactNumber1
        {
            get; set;
        }
        public string EmergencyContactNumber2
        {
            get; set;
        }
        public string MobileNumber
        {
            get; set;
        }
        public string UANNumber
        {
            get; set;
        }
        public string MiddleFullName
        {
            get; set;
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

        public int ModifiedBy
        {
            get;
            set;
        }

        public DateTime? ModifiedDate
        {
            get;
            set;
        }

        public int DeletedBy
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
        public string XMLString
        {
            get;
            set;
        }
        public string ExcelSheetName
        {
            get;
            set;
        }
        public Int16 CurrentESICZoneID
        {
            get;
            set;
        }
        public string ESICZoneCode
        {
            get;
            set;
        }
        public bool IsESICCardIssued
        {
            get;set;
        }
        public bool IsPoliceVerificationComplete
        {
            get; set;
        }
        public string BloodGroup
        {
            get; set;
        }
        public string CroppedImagePath
        {
            get;set;
        }
        public string CentreCode
        {
            get; set;
        }
        public string ReasonForLeft
        {
            get; set;
        }
        
    }
}
