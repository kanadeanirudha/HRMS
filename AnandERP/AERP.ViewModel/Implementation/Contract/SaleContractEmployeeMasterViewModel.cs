using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Web;

namespace AERP.ViewModel
{
    public class SaleContractEmployeeMasterViewModel : ISaleContractEmployeeMasterViewModel
    {

        public SaleContractEmployeeMasterViewModel()
        {
            SaleContractEmployeeMasterDTO = new SaleContractEmployeeMaster();
            ListGetAdminRoleApplicableCentre = new List<AdminRoleApplicableDetails>();
        }
        public HttpPostedFileBase ExcelFile { get; set; }
        public List<AdminRoleApplicableDetails> ListGetAdminRoleApplicableCentre
        {
            get;
            set;
        }

        public IEnumerable<SelectListItem> ListGetAdminRoleApplicableCentreItems
        {
            get
            {
                return new SelectList(ListGetAdminRoleApplicableCentre, "CentreCode", "CentreName");
            }
        }

        public SaleContractEmployeeMaster SaleContractEmployeeMasterDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (SaleContractEmployeeMasterDTO != null && SaleContractEmployeeMasterDTO.ID > 0) ? SaleContractEmployeeMasterDTO.ID : new int();
            }
            set
            {
                SaleContractEmployeeMasterDTO.ID = value;
            }
        }

        [Display(Name = "Title")]
        [Required(ErrorMessage = "Title Required")]
        public string Title
        {
            get
            {
                return (SaleContractEmployeeMasterDTO != null ) ? SaleContractEmployeeMasterDTO.Title : string.Empty;
            }
            set
            {
                SaleContractEmployeeMasterDTO.Title = value;
            }
        }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First Name Required")]
        public string FirstName
        {
            get
            {
                return (SaleContractEmployeeMasterDTO != null ) ? SaleContractEmployeeMasterDTO.FirstName : string.Empty;
            }
            set
            {
                SaleContractEmployeeMasterDTO.FirstName = value;
            }
        }

        [Display(Name = "Middle Name")]
        public string MiddleName
        {
            get
            {
                return (SaleContractEmployeeMasterDTO != null) ? SaleContractEmployeeMasterDTO.MiddleName : string.Empty;
            }
            set
            {
                SaleContractEmployeeMasterDTO.MiddleName = value;
            }
        }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name Required")]
        public string LastName
        {
            get
            {
                return (SaleContractEmployeeMasterDTO != null) ? SaleContractEmployeeMasterDTO.LastName : string.Empty;
            }
            set
            {
                SaleContractEmployeeMasterDTO.LastName = value;
            }
        }
        [Display(Name = "Employee Name")]
        public string EmployeeName
        {
            get
            {
                return (SaleContractEmployeeMasterDTO != null) ? SaleContractEmployeeMasterDTO.EmployeeName : string.Empty;
            }
            set
            {
                SaleContractEmployeeMasterDTO.EmployeeName = value;
            }
        }
        
        [Display(Name = "Employee Code")]
        public string EmployeeCode
        {
            get
            {
                return (SaleContractEmployeeMasterDTO != null) ? SaleContractEmployeeMasterDTO.EmployeeCode : string.Empty;
            }
            set
            {
                SaleContractEmployeeMasterDTO.EmployeeCode = value;
            }
        }
        [Display(Name = "Joining Date")]
        [Required(ErrorMessage = "Joining Date Required")]
        public string FirstJoiningDate
        {
            get
            {
                return (SaleContractEmployeeMasterDTO != null) ? SaleContractEmployeeMasterDTO.FirstJoiningDate : string.Empty;
            }
            set
            {
                SaleContractEmployeeMasterDTO.FirstJoiningDate = value;
            }
        }
        [Display(Name = "Left Date")]
        public string LastLeftDate
        {
            get
            {
                return (SaleContractEmployeeMasterDTO != null) ? SaleContractEmployeeMasterDTO.LastLeftDate : string.Empty;
            }
            set
            {
                SaleContractEmployeeMasterDTO.LastLeftDate= value;
            }
        }
        [Display(Name = "Employee ID")]
        public Int32 SaleContractEmployeeMasterID
        {
            get
            {
                return (SaleContractEmployeeMasterDTO != null && SaleContractEmployeeMasterDTO.SaleContractEmployeeMasterID > 0) ? SaleContractEmployeeMasterDTO.SaleContractEmployeeMasterID : new Int32();
            }
            set
            {
                SaleContractEmployeeMasterDTO.SaleContractEmployeeMasterID = value;
            }
        }
        [Display(Name = "Joining Date")]
        public string JoiningDate
        {
            get
            {
                return (SaleContractEmployeeMasterDTO != null) ? SaleContractEmployeeMasterDTO.JoiningDate : string.Empty;
            }
            set
            {
                SaleContractEmployeeMasterDTO.JoiningDate = value;
            }
        }
        [Display(Name = "Left Date")]
        public string LeftDate
        {
            get
            {
                return (SaleContractEmployeeMasterDTO != null) ? SaleContractEmployeeMasterDTO.LeftDate : string.Empty;
            }
            set
            {
                SaleContractEmployeeMasterDTO.LeftDate = value;
            }
        }
        [Display(Name = "Is Left")]
        public bool IsLeft
        {
            get
            {
                return (SaleContractEmployeeMasterDTO != null) ? SaleContractEmployeeMasterDTO.IsLeft : false;
            }
            set
            {
                SaleContractEmployeeMasterDTO.IsLeft = value;
            }
        }
        [Display(Name = "Email ID")]
        public string EmailID
        {
            get
            {
                return (SaleContractEmployeeMasterDTO != null) ? SaleContractEmployeeMasterDTO.EmailID : string.Empty;
            }
            set
            {
                SaleContractEmployeeMasterDTO.EmailID = value;
            }
        }
        [Display(Name = "Date Of Birth")]
        public string BirthDate
        {
            get
            {
                return (SaleContractEmployeeMasterDTO != null) ? SaleContractEmployeeMasterDTO.BirthDate : string.Empty;
            }
            set
            {
                SaleContractEmployeeMasterDTO.BirthDate = value;
            }
        }
        [Display(Name = "Nationality")]
        public Int32 NationalityID
        {
            get
            {
                return (SaleContractEmployeeMasterDTO != null && SaleContractEmployeeMasterDTO.NationalityID > 0) ? SaleContractEmployeeMasterDTO.NationalityID : new Int32();
            }
            set
            {
                SaleContractEmployeeMasterDTO.NationalityID = value;
            }
        }
        [Display(Name = "Nationality")]
        public string Nationality
        {
            get
            {
                return (SaleContractEmployeeMasterDTO != null ) ? SaleContractEmployeeMasterDTO.Nationality :string.Empty;
            }
            set
            {
                SaleContractEmployeeMasterDTO.Nationality = value;
            }
        }
        [Display(Name = "Gender")]
        public string GenderCode
        {
            get
            {
                return (SaleContractEmployeeMasterDTO != null) ? SaleContractEmployeeMasterDTO.GenderCode : string.Empty;
            }
            set
            {
                SaleContractEmployeeMasterDTO.GenderCode = value;
            }
        }
        [Display(Name = "Marrital Staus")]
        public string MarritalStaus
        {
            get
            {
                return (SaleContractEmployeeMasterDTO != null) ? SaleContractEmployeeMasterDTO.MarritalStaus : string.Empty;
            }
            set
            {
                SaleContractEmployeeMasterDTO.MarritalStaus = value;
            }
        }
        [Display(Name = "Social Security Number")]
        public string SSNNumber
        {
            get
            {
                return (SaleContractEmployeeMasterDTO != null) ? SaleContractEmployeeMasterDTO.SSNNumber : string.Empty;
            }
            set
            {
                SaleContractEmployeeMasterDTO.SSNNumber = value;
            }
        }
        [Display(Name = "Social Insurance Number")]
        public string SINNumber
        {
            get
            {
                return (SaleContractEmployeeMasterDTO != null) ? SaleContractEmployeeMasterDTO.SINNumber : string.Empty;
            }
            set
            {
                SaleContractEmployeeMasterDTO.SINNumber = value;
            }
        }
        [Display(Name = "Driving Licence Number")]
        public string DrivingLicenceNumber
        {
            get
            {
                return (SaleContractEmployeeMasterDTO != null) ? SaleContractEmployeeMasterDTO.DrivingLicenceNumber : string.Empty;
            }
            set
            {
                SaleContractEmployeeMasterDTO.DrivingLicenceNumber = value;
            }
        }
        [Display(Name = "Driving Licence Expire Date")]
        public string DrivingLicenceExpireDate
        {
            get
            {
                return (SaleContractEmployeeMasterDTO != null) ? SaleContractEmployeeMasterDTO.DrivingLicenceExpireDate : string.Empty;
            }
            set
            {
                SaleContractEmployeeMasterDTO.DrivingLicenceExpireDate = value;
            }
        }
        [Display(Name = "Other Email ID")]
        public string OtherEmailID
        {
            get
            {
                return (SaleContractEmployeeMasterDTO != null) ? SaleContractEmployeeMasterDTO.OtherEmailID : string.Empty;
            }
            set
            {
                SaleContractEmployeeMasterDTO.OtherEmailID = value;
            }
        }
        [Display(Name = "PAN Number")]
        public string PanNumber
        {
            get
            {
                return (SaleContractEmployeeMasterDTO != null) ? SaleContractEmployeeMasterDTO.PanNumber : string.Empty;
            }
            set
            {
                SaleContractEmployeeMasterDTO.PanNumber = value;
            }
        }
        [Display(Name = "ESI Number")]
        public string ESINumber
        {
            get
            {
                return (SaleContractEmployeeMasterDTO != null) ? SaleContractEmployeeMasterDTO.ESINumber : string.Empty;
            }
            set
            {
                SaleContractEmployeeMasterDTO.ESINumber = value;
            }
        }
        [Display(Name = "Provident Fund Number")]
        public string ProvidentFundNumber
        {
            get
            {
                return (SaleContractEmployeeMasterDTO != null) ? SaleContractEmployeeMasterDTO.ProvidentFundNumber : string.Empty;
            }
            set
            {
                SaleContractEmployeeMasterDTO.ProvidentFundNumber = value;
            }
        }
        [Display(Name = "Provident Fund Applicable Date")]
        public string ProvidentFundApplicableDate
        {
            get
            {
                return (SaleContractEmployeeMasterDTO != null) ? SaleContractEmployeeMasterDTO.ProvidentFundApplicableDate : string.Empty;
            }
            set
            {
                SaleContractEmployeeMasterDTO.ProvidentFundApplicableDate = value;
            }
        }
        [Display(Name = "Bank Name")]
        public string BankName
        {
            get
            {
                return (SaleContractEmployeeMasterDTO != null) ? SaleContractEmployeeMasterDTO.BankName : string.Empty;
            }
            set
            {
                SaleContractEmployeeMasterDTO.BankName = value;
            }
        }
        [Display(Name = "Bank Name")]
        public byte BankMasterID
        {
            get
            {
                return (SaleContractEmployeeMasterDTO != null) ? SaleContractEmployeeMasterDTO.BankMasterID : new byte();
            }
            set
            {
                SaleContractEmployeeMasterDTO.BankMasterID = value;
            }
        }
        [Display(Name = "Bank Account Number")]
        public string BankACNumber
        {
            get
            {
                return (SaleContractEmployeeMasterDTO != null) ? SaleContractEmployeeMasterDTO.BankACNumber : string.Empty;
            }
            set
            {
                SaleContractEmployeeMasterDTO.BankACNumber = value;
            }
        }
        [Display(Name = "Bank IFSI Code")]
        public string BankIFSICode
        {
            get
            {
                return (SaleContractEmployeeMasterDTO != null) ? SaleContractEmployeeMasterDTO.BankIFSICode : string.Empty;
            }
            set
            {
                SaleContractEmployeeMasterDTO.BankIFSICode = value;
            }
        }
        [Display(Name = "Address1")]
        public string Address1
        {
            get
            {
                return (SaleContractEmployeeMasterDTO != null) ? SaleContractEmployeeMasterDTO.Address1 : string.Empty;
            }
            set
            {
                SaleContractEmployeeMasterDTO.Address1 = value;
            }
        }
        [Display(Name = "Address2")]
        public string Address2
        {
            get
            {
                return (SaleContractEmployeeMasterDTO != null) ? SaleContractEmployeeMasterDTO.Address2 : string.Empty;
            }
            set
            {
                SaleContractEmployeeMasterDTO.Address2 = value;
            }
        }
        [Display(Name = "City")]
        public Int32 CityID
        {
            get
            {
                return (SaleContractEmployeeMasterDTO != null && SaleContractEmployeeMasterDTO.CityID>0) ? SaleContractEmployeeMasterDTO.CityID : new Int32();
            }
            set
            {
                SaleContractEmployeeMasterDTO.CityID = value;
            }
        }
        [Display(Name = "Region")]
        public Int32 RegionID
        {
            get
            {
                return (SaleContractEmployeeMasterDTO != null && SaleContractEmployeeMasterDTO.RegionID > 0) ? SaleContractEmployeeMasterDTO.RegionID : new Int32();
            }
            set
            {
                SaleContractEmployeeMasterDTO.RegionID = value;
            }
        }
        [Display(Name = "Country")]
        public Int32 CountryID
        {
            get
            {
                return (SaleContractEmployeeMasterDTO != null && SaleContractEmployeeMasterDTO.CountryID > 0) ? SaleContractEmployeeMasterDTO.CountryID : new Int32();
            }
            set
            {
                SaleContractEmployeeMasterDTO.CountryID = value;
            }
        }
        [Display(Name = "City")]
        public string CityName
        {
            get
            {
                return (SaleContractEmployeeMasterDTO != null ) ? SaleContractEmployeeMasterDTO.CityName: string.Empty;
            }
            set
            {
                SaleContractEmployeeMasterDTO.CityName = value;
            }
        }
        [Display(Name = "Pincode")]
        public string Pincode
        {
            get
            {
                return (SaleContractEmployeeMasterDTO != null) ? SaleContractEmployeeMasterDTO.Pincode : string.Empty;
            }
            set
            {
                SaleContractEmployeeMasterDTO.Pincode = value;
            }
        }
        [Display(Name = "Emergency Contact Number 1")]
        public string EmergencyContactNumber1
        {
            get
            {
                return (SaleContractEmployeeMasterDTO != null) ? SaleContractEmployeeMasterDTO.EmergencyContactNumber1 : string.Empty;
            }
            set
            {
                SaleContractEmployeeMasterDTO.EmergencyContactNumber1 = value;
            }
        }
        [Display(Name = "Emergency Contact Number 2")]
        public string EmergencyContactNumber2
        {
            get
            {
                return (SaleContractEmployeeMasterDTO != null) ? SaleContractEmployeeMasterDTO.EmergencyContactNumber2 : string.Empty;
            }
            set
            {
                SaleContractEmployeeMasterDTO.EmergencyContactNumber2 = value;
            }
        }
        [Display(Name = "Mobile Number")]
        public string MobileNumber
        {
            get
            {
                return (SaleContractEmployeeMasterDTO != null) ? SaleContractEmployeeMasterDTO.MobileNumber : string.Empty;
            }
            set
            {
                SaleContractEmployeeMasterDTO.MobileNumber = value;
            }
        }
        [Display(Name = "Is Deleted")]
        public bool IsDeleted
        {
            get
            {
                return (SaleContractEmployeeMasterDTO != null) ? SaleContractEmployeeMasterDTO.IsDeleted : false;
            }
            set
            {
                SaleContractEmployeeMasterDTO.IsDeleted = value;
            }
        }

        [Display(Name = "Created By")]
        public int CreatedBy
        {
            get
            {
                return (SaleContractEmployeeMasterDTO != null && SaleContractEmployeeMasterDTO.CreatedBy > 0) ? SaleContractEmployeeMasterDTO.CreatedBy : new int();
            }
            set
            {
                SaleContractEmployeeMasterDTO.CreatedBy = value;
            }
        }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate
        {
            get
            {
                return (SaleContractEmployeeMasterDTO != null) ? SaleContractEmployeeMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                SaleContractEmployeeMasterDTO.CreatedDate = value;
            }
        }

        [Display(Name = "Modified By")]
        public int ModifiedBy
        {
            get
            {
                return (SaleContractEmployeeMasterDTO != null && SaleContractEmployeeMasterDTO.ModifiedBy > 0) ? SaleContractEmployeeMasterDTO.ModifiedBy : new int();
            }
            set
            {
                SaleContractEmployeeMasterDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "Modified Date")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (SaleContractEmployeeMasterDTO != null && SaleContractEmployeeMasterDTO.ModifiedDate.HasValue) ? SaleContractEmployeeMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                SaleContractEmployeeMasterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "Deleted By")]
        public int DeletedBy
        {
            get
            {
                return (SaleContractEmployeeMasterDTO != null && SaleContractEmployeeMasterDTO.DeletedBy > 0) ? SaleContractEmployeeMasterDTO.DeletedBy : new int();
            }
            set
            {
                SaleContractEmployeeMasterDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (SaleContractEmployeeMasterDTO != null && SaleContractEmployeeMasterDTO.DeletedDate.HasValue) ? SaleContractEmployeeMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                SaleContractEmployeeMasterDTO.DeletedDate = value;
            }
        }
        [Display(Name = "UAN Number")]
        public string UANNumber
        {
            get
            {
                return (SaleContractEmployeeMasterDTO != null) ? SaleContractEmployeeMasterDTO.UANNumber : string.Empty;
            }
            set
            {
                SaleContractEmployeeMasterDTO.UANNumber = value;
            }
        }
        [Display(Name = "Father's/Husband's Name")]
        public string MiddleFullName
        {
            get
            {
                return (SaleContractEmployeeMasterDTO != null) ? SaleContractEmployeeMasterDTO.MiddleFullName : string.Empty;
            }
            set
            {
                SaleContractEmployeeMasterDTO.MiddleFullName = value;
            }
        }

        

        public string errorMessage { get; set; }
        [Display(Name = "Current ESIC Zone")]
        public Int16 CurrentESICZoneID
        {
            get
            {
                return (SaleContractEmployeeMasterDTO != null && SaleContractEmployeeMasterDTO.CurrentESICZoneID > 0) ? SaleContractEmployeeMasterDTO.CurrentESICZoneID : new Int16();
            }
            set
            {
                SaleContractEmployeeMasterDTO.CurrentESICZoneID = value;
            }
        }
        [Display(Name = "Blood Group")]
        public string BloodGroup
        {
            get
            {
                return (SaleContractEmployeeMasterDTO != null) ? SaleContractEmployeeMasterDTO.BloodGroup : string.Empty;
            }
            set
            {
                SaleContractEmployeeMasterDTO.BloodGroup = value;
            }
        }
        [Display(Name = "Is Police Verified")]
        public bool IsPoliceVerificationComplete
        {
            get
            {
                return (SaleContractEmployeeMasterDTO != null) ? SaleContractEmployeeMasterDTO.IsPoliceVerificationComplete : false;
            }
            set
            {
                SaleContractEmployeeMasterDTO.IsPoliceVerificationComplete = value;
            }
        }

        [Display(Name = "Is ESIC Card Issued")]
        public bool IsESICCardIssued
        {
            get
            {
                return (SaleContractEmployeeMasterDTO != null) ? SaleContractEmployeeMasterDTO.IsESICCardIssued : false;
            }
            set
            {
                SaleContractEmployeeMasterDTO.IsESICCardIssued = value;
            }
        }

        public string CroppedImagePath
        {
            get
            {
                return (SaleContractEmployeeMasterDTO != null) ? SaleContractEmployeeMasterDTO.CroppedImagePath : string.Empty;
            }
            set
            {
                SaleContractEmployeeMasterDTO.CroppedImagePath = value;

            }
        }
        [Display(Name = "Centre Code")]
        public string CentreCode
        {
            get
            {
                return (SaleContractEmployeeMasterDTO != null) ? SaleContractEmployeeMasterDTO.CentreCode : string.Empty;
            }
            set
            {
                SaleContractEmployeeMasterDTO.CentreCode = value;
            }
        }
        [Display(Name = "Reason For Left")]
        public string ReasonForLeft
        {
            get
            {
                return (SaleContractEmployeeMasterDTO != null) ? SaleContractEmployeeMasterDTO.ReasonForLeft : string.Empty;
            }
            set
            {
                SaleContractEmployeeMasterDTO.ReasonForLeft = value;
            }
        }

    }
}

