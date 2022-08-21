using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class ContractSalaryATMReportViewModel
    {

        public ContractSalaryATMReportViewModel()
        {
            ContractSalaryATMReportDTO = new ContractSalaryATMReport();
            SaleContractSpanList = new List<SaleContractAttendance>();
            ContractSalaryATMReportList = new List<ContractSalaryATMReport>();
            ListGetAdminRoleApplicableCentre = new List<AdminRoleApplicableDetails>();
            ListBankMaster = new List<BankMaster>();
        }
        public List<BankMaster> ListBankMaster { get; set; }
        public List<SaleContractAttendance> SaleContractSpanList { get; set; }
        public List<ContractSalaryATMReport> ContractSalaryATMReportList { get; set; }
        public List<AdminRoleApplicableDetails> ListGetAdminRoleApplicableCentre
        {
            get;
            set;
        }
        public IEnumerable<SelectListItem> ListBankMasterItems
        {
            get
            {
                return new SelectList(ListBankMaster, "ID", "BankName");
            }
        }
        public IEnumerable<SelectListItem> ListGetAdminRoleApplicableCentreItems
        {
            get
            {
                return new SelectList(ListGetAdminRoleApplicableCentre, "CentreCode", "CentreName");
            }
        }

        public IEnumerable<SelectListItem> ListGetContractSpans
        {
            get
            {
                return new SelectList(SaleContractSpanList, "SaleContractBillingSpanID", "SaleContractBillingSpanName");
            }
        }

        public ContractSalaryATMReport ContractSalaryATMReportDTO
        {
            get;
            set;
        }

        public Int64 ID
        {
            get
            {
                return (ContractSalaryATMReportDTO != null && ContractSalaryATMReportDTO.ID > 0) ? ContractSalaryATMReportDTO.ID : new Int64();
            }
            set
            {
                ContractSalaryATMReportDTO.ID = value;
            }
        }
        [Display(Name = "Employee Code")]
        public string EmployeeCode
        {
            get
            {
                return (ContractSalaryATMReportDTO != null) ? ContractSalaryATMReportDTO.EmployeeCode : string.Empty;
            }
            set
            {
                ContractSalaryATMReportDTO.EmployeeCode = value;
            }
        }
        [Display(Name = "First Name")]
        public string FirstName
        {
            get
            {
                return (ContractSalaryATMReportDTO != null) ? ContractSalaryATMReportDTO.FirstName : string.Empty;
            }
            set
            {
                ContractSalaryATMReportDTO.FirstName = value;
            }
        }

        public bool IsPosted { get; set; }
        
        public string CentreCode
        {
            get
            {
                return (ContractSalaryATMReportDTO != null) ? ContractSalaryATMReportDTO.CentreCode : string.Empty;
            }
            set
            {
                ContractSalaryATMReportDTO.CentreCode = value;
            }
        }
        
        public string CentreName
        {
            get
            {
                return (ContractSalaryATMReportDTO != null) ? ContractSalaryATMReportDTO.CentreName : string.Empty;
            }
            set
            {
                ContractSalaryATMReportDTO.CentreName = value;
            }
        }
        
        public string BankName
        {
            get
            {
                return (ContractSalaryATMReportDTO != null) ? ContractSalaryATMReportDTO.BankName : string.Empty;
            }
            set
            {
                ContractSalaryATMReportDTO.BankName = value;
            }
        }
        
        public byte BankMasterID
        {
            get
            {
                return (ContractSalaryATMReportDTO != null) ? ContractSalaryATMReportDTO.BankMasterID : new byte();
            }
            set
            {
                ContractSalaryATMReportDTO.BankMasterID = value;
            }
        }
        
        public byte ReportType
        {
            get
            {
                return (ContractSalaryATMReportDTO != null) ? ContractSalaryATMReportDTO.ReportType : new byte();
            }
            set
            {
                ContractSalaryATMReportDTO.ReportType = value;
            }
        }
        public string SalaryMonth { get; set; }
        public string SalaryYear { get; set; }

        public bool IsDeleted
        {
            get
            {
                return (ContractSalaryATMReportDTO != null) ? ContractSalaryATMReportDTO.IsDeleted : false;
            }
            set
            {
                ContractSalaryATMReportDTO.IsDeleted = value;
            }
        }

        [Display(Name = "Created By")]
        public int CreatedBy
        {
            get
            {
                return (ContractSalaryATMReportDTO != null && ContractSalaryATMReportDTO.CreatedBy > 0) ? ContractSalaryATMReportDTO.CreatedBy : new int();
            }
            set
            {
                ContractSalaryATMReportDTO.CreatedBy = value;
            }
        }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate
        {
            get
            {
                return (ContractSalaryATMReportDTO != null) ? ContractSalaryATMReportDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                ContractSalaryATMReportDTO.CreatedDate = value;
            }
        }

        [Display(Name = "Modified By")]
        public int ModifiedBy
        {
            get
            {
                return (ContractSalaryATMReportDTO != null && ContractSalaryATMReportDTO.ModifiedBy > 0) ? ContractSalaryATMReportDTO.ModifiedBy : new int();
            }
            set
            {
                ContractSalaryATMReportDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "Modified Date")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (ContractSalaryATMReportDTO != null && ContractSalaryATMReportDTO.ModifiedDate.HasValue) ? ContractSalaryATMReportDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                ContractSalaryATMReportDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "Deleted By")]
        public int DeletedBy
        {
            get
            {
                return (ContractSalaryATMReportDTO != null && ContractSalaryATMReportDTO.DeletedBy > 0) ? ContractSalaryATMReportDTO.DeletedBy : new int();
            }
            set
            {
                ContractSalaryATMReportDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (ContractSalaryATMReportDTO != null && ContractSalaryATMReportDTO.DeletedDate.HasValue) ? ContractSalaryATMReportDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                ContractSalaryATMReportDTO.DeletedDate = value;
            }
        }
       
        [Display(Name = "Last Name")]
        public string LastName
        {
            get
            {
                return (ContractSalaryATMReportDTO != null) ? ContractSalaryATMReportDTO.LastName : string.Empty;
            }
            set
            {
                ContractSalaryATMReportDTO.LastName = value;
            }
        }
        [Display(Name = "Customer Name")]
        public string CustomerMasterName
        {
            get
            {
                return (ContractSalaryATMReportDTO != null) ? ContractSalaryATMReportDTO.CustomerMasterName : string.Empty;
            }
            set
            {
                ContractSalaryATMReportDTO.CustomerMasterName = value;
            }
        }
        [Display(Name = "Customer Branch")]
        public string CustomerBranchMasterName
        {
            get
            {
                return (ContractSalaryATMReportDTO != null) ? ContractSalaryATMReportDTO.CustomerBranchMasterName : string.Empty;
            }
            set
            {
                ContractSalaryATMReportDTO.CustomerBranchMasterName = value;
            }
        }
        [Display(Name = "Customer Name")]
        public Int32 CustomerMasterID
        {
            get
            {
                return (ContractSalaryATMReportDTO != null) ? ContractSalaryATMReportDTO.CustomerMasterID : new Int32();
            }
            set
            {
                ContractSalaryATMReportDTO.CustomerMasterID = value;
            }
        }
        [Display(Name = "Customer Type")]
        public byte CustomerType
        {
            get
            {
                return (ContractSalaryATMReportDTO != null) ? ContractSalaryATMReportDTO.CustomerType : new byte ();
            }
            set
            {
                ContractSalaryATMReportDTO.CustomerType = value;
            }
        }
        [Display(Name = "Customer Branch")]
        public Int32 CustomerBranchMasterID
        {
            get
            {
                return (ContractSalaryATMReportDTO != null) ? ContractSalaryATMReportDTO.CustomerBranchMasterID : new Int32();
            }
            set
            {
                ContractSalaryATMReportDTO.CustomerBranchMasterID = value;
            }
        }
        [Display(Name = "SearchFor")]
        public string SearchFor
        {
            get
            {
                return (ContractSalaryATMReportDTO != null) ? ContractSalaryATMReportDTO.SearchFor : string.Empty;
            }
            set
            {
                ContractSalaryATMReportDTO.SearchFor = value;
            }
        }
        [Display(Name = "SearchForDisplay")]
        public string SearchForDisplay
        {
            get
            {
                return (ContractSalaryATMReportDTO != null) ? ContractSalaryATMReportDTO.SearchForDisplay : string.Empty;
            }
            set
            {
                ContractSalaryATMReportDTO.SearchForDisplay = value;
            }
        }
        [Display(Name = "SearchForXML")]
        [AllowHtml]
        public string SearchForXML
        {
            get
            {
                return (ContractSalaryATMReportDTO != null) ? ContractSalaryATMReportDTO.SearchForXML : string.Empty;
            }
            set
            {
                ContractSalaryATMReportDTO.SearchForXML = value;
            }
        }
        
        public string errorMessage { get; set; }
        [Display(Name = "Contract Number")]
        public Int64 SaleContractMasterID
        {
            get
            {
                return (ContractSalaryATMReportDTO != null && ContractSalaryATMReportDTO.SaleContractMasterID > 0) ? ContractSalaryATMReportDTO.SaleContractMasterID : new Int64();
            }
            set
            {
                ContractSalaryATMReportDTO.SaleContractMasterID = value;
            }
        }
        [Display(Name = "Contract Number")]
        public string ContractNumber
        {
            get
            {
                return (ContractSalaryATMReportDTO != null) ? ContractSalaryATMReportDTO.ContractNumber : string.Empty;
            }
            set
            {
                ContractSalaryATMReportDTO.ContractNumber = value;
            }
        }
        [Display(Name = "Report For NR")]
        public bool IsRemovalForAdjustment
        {
            get
            {
                return (ContractSalaryATMReportDTO != null) ? ContractSalaryATMReportDTO.IsRemovalForAdjustment : false;
            }
            set
            {
                ContractSalaryATMReportDTO.IsRemovalForAdjustment = value;
            }
        }
        
    }
}

