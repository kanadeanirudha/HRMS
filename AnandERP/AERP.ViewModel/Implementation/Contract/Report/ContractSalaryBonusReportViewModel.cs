using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class ContractSalaryBonusReportViewModel
    {

        public ContractSalaryBonusReportViewModel()
        {
            ContractSalaryBonusReportDTO = new ContractSalaryBonusReport();
            SaleContractSpanList = new List<SaleContractAttendance>();
            ContractSalaryBonusReportList = new List<ContractSalaryBonusReport>();
            ListGetAdminRoleApplicableCentre = new List<AdminRoleApplicableDetails>();
            ListBankMaster = new List<BankMaster>();
            ListAccountSessionMaster = new List<AccountSessionMaster>();
        }
        public List<BankMaster> ListBankMaster { get; set; }
        public List<SaleContractAttendance> SaleContractSpanList { get; set; }
        public List<ContractSalaryBonusReport> ContractSalaryBonusReportList { get; set; }
        public List<AccountSessionMaster> ListAccountSessionMaster { get; set; }
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
        public IEnumerable<SelectListItem> AccountSessionMasterItems
        {
            get
            {
                return new SelectList(ListAccountSessionMaster, "ID", "SessionName");
            }
        }
        public ContractSalaryBonusReport ContractSalaryBonusReportDTO
        {
            get;
            set;
        }

        public Int64 ID
        {
            get
            {
                return (ContractSalaryBonusReportDTO != null && ContractSalaryBonusReportDTO.ID > 0) ? ContractSalaryBonusReportDTO.ID : new Int64();
            }
            set
            {
                ContractSalaryBonusReportDTO.ID = value;
            }
        }
        [Display(Name = "Employee Code")]
        public string EmployeeCode
        {
            get
            {
                return (ContractSalaryBonusReportDTO != null) ? ContractSalaryBonusReportDTO.EmployeeCode : string.Empty;
            }
            set
            {
                ContractSalaryBonusReportDTO.EmployeeCode = value;
            }
        }
        [Display(Name = "First Name")]
        public string FirstName
        {
            get
            {
                return (ContractSalaryBonusReportDTO != null) ? ContractSalaryBonusReportDTO.FirstName : string.Empty;
            }
            set
            {
                ContractSalaryBonusReportDTO.FirstName = value;
            }
        }

        public bool IsPosted { get; set; }
        
        public string FromDate
        {
            get
            {
                return (ContractSalaryBonusReportDTO != null) ? ContractSalaryBonusReportDTO.FromDate : string.Empty;
            }
            set
            {
                ContractSalaryBonusReportDTO.FromDate = value;
            }
        }
        
        public string UptoDate
        {
            get
            {
                return (ContractSalaryBonusReportDTO != null) ? ContractSalaryBonusReportDTO.UptoDate : string.Empty;
            }
            set
            {
                ContractSalaryBonusReportDTO.UptoDate = value;
            }
        }
        
        public string BankName
        {
            get
            {
                return (ContractSalaryBonusReportDTO != null) ? ContractSalaryBonusReportDTO.BankName : string.Empty;
            }
            set
            {
                ContractSalaryBonusReportDTO.BankName = value;
            }
        }
        
        public byte BankMasterID
        {
            get
            {
                return (ContractSalaryBonusReportDTO != null) ? ContractSalaryBonusReportDTO.BankMasterID : new byte();
            }
            set
            {
                ContractSalaryBonusReportDTO.BankMasterID = value;
            }
        }
        
        public string ReportType
        {
            get
            {
                return (ContractSalaryBonusReportDTO != null) ? ContractSalaryBonusReportDTO.ReportType : string.Empty;
            }
            set
            {
                ContractSalaryBonusReportDTO.ReportType = value;
            }
        }
        public string ReportTypeDisplay
        {
            get
            {
                return (ContractSalaryBonusReportDTO != null) ? ContractSalaryBonusReportDTO.ReportTypeDisplay : string.Empty;
            }
            set
            {
                ContractSalaryBonusReportDTO.ReportTypeDisplay = value;
            }
        }
        
        public string SalaryMonth
        {
            get
            {
                return (ContractSalaryBonusReportDTO != null) ? ContractSalaryBonusReportDTO.SalaryMonth : string.Empty;
            }
            set
            {
                ContractSalaryBonusReportDTO.SalaryMonth = value;
            }
        }
        public string SalaryYear
        {
            get
            {
                return (ContractSalaryBonusReportDTO != null) ? ContractSalaryBonusReportDTO.SalaryYear : string.Empty;
            }
            set
            {
                ContractSalaryBonusReportDTO.SalaryYear = value;
            }
        }
        public string SalaryMonthName
        {
            get
            {
                return (ContractSalaryBonusReportDTO != null) ? ContractSalaryBonusReportDTO.SalaryMonthName : string.Empty;
            }
            set
            {
                ContractSalaryBonusReportDTO.SalaryMonthName = value;
            }
        }

        public bool IsDeleted
        {
            get
            {
                return (ContractSalaryBonusReportDTO != null) ? ContractSalaryBonusReportDTO.IsDeleted : false;
            }
            set
            {
                ContractSalaryBonusReportDTO.IsDeleted = value;
            }
        }

        [Display(Name = "Created By")]
        public int CreatedBy
        {
            get
            {
                return (ContractSalaryBonusReportDTO != null && ContractSalaryBonusReportDTO.CreatedBy > 0) ? ContractSalaryBonusReportDTO.CreatedBy : new int();
            }
            set
            {
                ContractSalaryBonusReportDTO.CreatedBy = value;
            }
        }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate
        {
            get
            {
                return (ContractSalaryBonusReportDTO != null) ? ContractSalaryBonusReportDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                ContractSalaryBonusReportDTO.CreatedDate = value;
            }
        }

        [Display(Name = "Modified By")]
        public int ModifiedBy
        {
            get
            {
                return (ContractSalaryBonusReportDTO != null && ContractSalaryBonusReportDTO.ModifiedBy > 0) ? ContractSalaryBonusReportDTO.ModifiedBy : new int();
            }
            set
            {
                ContractSalaryBonusReportDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "Modified Date")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (ContractSalaryBonusReportDTO != null && ContractSalaryBonusReportDTO.ModifiedDate.HasValue) ? ContractSalaryBonusReportDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                ContractSalaryBonusReportDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "Deleted By")]
        public int DeletedBy
        {
            get
            {
                return (ContractSalaryBonusReportDTO != null && ContractSalaryBonusReportDTO.DeletedBy > 0) ? ContractSalaryBonusReportDTO.DeletedBy : new int();
            }
            set
            {
                ContractSalaryBonusReportDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (ContractSalaryBonusReportDTO != null && ContractSalaryBonusReportDTO.DeletedDate.HasValue) ? ContractSalaryBonusReportDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                ContractSalaryBonusReportDTO.DeletedDate = value;
            }
        }
       
        [Display(Name = "Last Name")]
        public string LastName
        {
            get
            {
                return (ContractSalaryBonusReportDTO != null) ? ContractSalaryBonusReportDTO.LastName : string.Empty;
            }
            set
            {
                ContractSalaryBonusReportDTO.LastName = value;
            }
        }
        [Display(Name = "Customer Name")]
        public string CustomerMasterName
        {
            get
            {
                return (ContractSalaryBonusReportDTO != null) ? ContractSalaryBonusReportDTO.CustomerMasterName : string.Empty;
            }
            set
            {
                ContractSalaryBonusReportDTO.CustomerMasterName = value;
            }
        }
        [Display(Name = "Customer Branch")]
        public string CustomerBranchMasterName
        {
            get
            {
                return (ContractSalaryBonusReportDTO != null) ? ContractSalaryBonusReportDTO.CustomerBranchMasterName : string.Empty;
            }
            set
            {
                ContractSalaryBonusReportDTO.CustomerBranchMasterName = value;
            }
        }
        [Display(Name = "Customer Name")]
        public Int32 CustomerMasterID
        {
            get
            {
                return (ContractSalaryBonusReportDTO != null) ? ContractSalaryBonusReportDTO.CustomerMasterID : new Int32();
            }
            set
            {
                ContractSalaryBonusReportDTO.CustomerMasterID = value;
            }
        }
        [Display(Name = "Customer Type")]
        public byte CustomerType
        {
            get
            {
                return (ContractSalaryBonusReportDTO != null) ? ContractSalaryBonusReportDTO.CustomerType : new byte ();
            }
            set
            {
                ContractSalaryBonusReportDTO.CustomerType = value;
            }
        }
        [Display(Name = "Customer Branch")]
        public Int32 CustomerBranchMasterID
        {
            get
            {
                return (ContractSalaryBonusReportDTO != null) ? ContractSalaryBonusReportDTO.CustomerBranchMasterID : new Int32();
            }
            set
            {
                ContractSalaryBonusReportDTO.CustomerBranchMasterID = value;
            }
        }
        [Display(Name = "SearchFor")]
        public string SearchFor
        {
            get
            {
                return (ContractSalaryBonusReportDTO != null) ? ContractSalaryBonusReportDTO.SearchFor : string.Empty;
            }
            set
            {
                ContractSalaryBonusReportDTO.SearchFor = value;
            }
        }
        [Display(Name = "SearchForDisplay")]
        public string SearchForDisplay
        {
            get
            {
                return (ContractSalaryBonusReportDTO != null) ? ContractSalaryBonusReportDTO.SearchForDisplay : string.Empty;
            }
            set
            {
                ContractSalaryBonusReportDTO.SearchForDisplay = value;
            }
        }
        [Display(Name = "SearchForXML")]
        [AllowHtml]
        public string SearchForXML
        {
            get
            {
                return (ContractSalaryBonusReportDTO != null) ? ContractSalaryBonusReportDTO.SearchForXML : string.Empty;
            }
            set
            {
                ContractSalaryBonusReportDTO.SearchForXML = value;
            }
        }
        
        public string errorMessage { get; set; }
        [Display(Name = "Contract Number")]
        public Int64 SaleContractMasterID
        {
            get
            {
                return (ContractSalaryBonusReportDTO != null && ContractSalaryBonusReportDTO.SaleContractMasterID > 0) ? ContractSalaryBonusReportDTO.SaleContractMasterID : new Int64();
            }
            set
            {
                ContractSalaryBonusReportDTO.SaleContractMasterID = value;
            }
        }
        [Display(Name = "Contract Number")]
        public string ContractNumber
        {
            get
            {
                return (ContractSalaryBonusReportDTO != null) ? ContractSalaryBonusReportDTO.ContractNumber : string.Empty;
            }
            set
            {
                ContractSalaryBonusReportDTO.ContractNumber = value;
            }
        }
        [Display(Name = "Report For NR")]
        public bool IsRemovalForAdjustment
        {
            get
            {
                return (ContractSalaryBonusReportDTO != null) ? ContractSalaryBonusReportDTO.IsRemovalForAdjustment : false;
            }
            set
            {
                ContractSalaryBonusReportDTO.IsRemovalForAdjustment = value;
            }
        }
        [Display(Name = "Account Session")]
        public Int32 AccountSessionID
        {
            get
            {
                return (ContractSalaryBonusReportDTO != null && ContractSalaryBonusReportDTO.AccountSessionID > 0) ? ContractSalaryBonusReportDTO.AccountSessionID : new Int32();
            }
            set
            {
                ContractSalaryBonusReportDTO.AccountSessionID = value;
            }
        }
        
    }
}

