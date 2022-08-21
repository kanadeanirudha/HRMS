using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class ContractEmployeeReportViewModel
    {

        public ContractEmployeeReportViewModel()
        {
            ContractEmployeeReportDTO = new ContractEmployeeReport();
            SaleContractSpanList = new List<SaleContractAttendance>();
            ContractEmployeeReportList = new List<ContractEmployeeReport>();
            ListGetAdminRoleApplicableCentre = new List<AdminRoleApplicableDetails>();
            ListAccountSessionMasterReport = new List<AccountSessionMaster>();
        }
        public List<AccountSessionMaster> ListAccountSessionMasterReport { get; set; }
        public List<SaleContractAttendance> SaleContractSpanList { get; set; }
        public List<ContractEmployeeReport> ContractEmployeeReportList { get; set; }
        public List<AdminRoleApplicableDetails> ListGetAdminRoleApplicableCentre
        {
            get;
            set;
        }
        public IEnumerable<SelectListItem> AccountSessionMasterReportItems
        {
            get
            {
                return new SelectList(ListAccountSessionMasterReport, "ID", "SessionName");
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

        public ContractEmployeeReport ContractEmployeeReportDTO
        {
            get;
            set;
        }

        public Int64 ID
        {
            get
            {
                return (ContractEmployeeReportDTO != null && ContractEmployeeReportDTO.ID > 0) ? ContractEmployeeReportDTO.ID : new Int64();
            }
            set
            {
                ContractEmployeeReportDTO.ID = value;
            }
        }
        [Display(Name = "Employee Code")]
        public string EmployeeCode
        {
            get
            {
                return (ContractEmployeeReportDTO != null) ? ContractEmployeeReportDTO.EmployeeCode : string.Empty;
            }
            set
            {
                ContractEmployeeReportDTO.EmployeeCode = value;
            }
        }
        [Display(Name = "First Name")]
        public string FirstName
        {
            get
            {
                return (ContractEmployeeReportDTO != null) ? ContractEmployeeReportDTO.FirstName : string.Empty;
            }
            set
            {
                ContractEmployeeReportDTO.FirstName = value;
            }
        }

        public bool IsPosted { get; set; }
        public string CentreCode
        {
            get;
            set;
        }
        public string CentreName { get; set; }
        public byte ReportType { get; set; }
        [Display(Name = "Is Deleted")]
        public bool IsDeleted
        {
            get
            {
                return (ContractEmployeeReportDTO != null) ? ContractEmployeeReportDTO.IsDeleted : false;
            }
            set
            {
                ContractEmployeeReportDTO.IsDeleted = value;
            }
        }

        [Display(Name = "Created By")]
        public int CreatedBy
        {
            get
            {
                return (ContractEmployeeReportDTO != null && ContractEmployeeReportDTO.CreatedBy > 0) ? ContractEmployeeReportDTO.CreatedBy : new int();
            }
            set
            {
                ContractEmployeeReportDTO.CreatedBy = value;
            }
        }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate
        {
            get
            {
                return (ContractEmployeeReportDTO != null) ? ContractEmployeeReportDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                ContractEmployeeReportDTO.CreatedDate = value;
            }
        }

        [Display(Name = "Modified By")]
        public int ModifiedBy
        {
            get
            {
                return (ContractEmployeeReportDTO != null && ContractEmployeeReportDTO.ModifiedBy > 0) ? ContractEmployeeReportDTO.ModifiedBy : new int();
            }
            set
            {
                ContractEmployeeReportDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "Modified Date")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (ContractEmployeeReportDTO != null && ContractEmployeeReportDTO.ModifiedDate.HasValue) ? ContractEmployeeReportDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                ContractEmployeeReportDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "Deleted By")]
        public int DeletedBy
        {
            get
            {
                return (ContractEmployeeReportDTO != null && ContractEmployeeReportDTO.DeletedBy > 0) ? ContractEmployeeReportDTO.DeletedBy : new int();
            }
            set
            {
                ContractEmployeeReportDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (ContractEmployeeReportDTO != null && ContractEmployeeReportDTO.DeletedDate.HasValue) ? ContractEmployeeReportDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                ContractEmployeeReportDTO.DeletedDate = value;
            }
        }
       
        [Display(Name = "Last Name")]
        public string LastName
        {
            get
            {
                return (ContractEmployeeReportDTO != null) ? ContractEmployeeReportDTO.LastName : string.Empty;
            }
            set
            {
                ContractEmployeeReportDTO.LastName = value;
            }
        }
        [Display(Name = "Employee Name")]
        public Int32 SaleContractEmployeeMasterID
        {
            get
            {
                return (ContractEmployeeReportDTO != null && ContractEmployeeReportDTO.SaleContractEmployeeMasterID > 0) ? ContractEmployeeReportDTO.SaleContractEmployeeMasterID : new Int32();
            }
            set
            {
                ContractEmployeeReportDTO.SaleContractEmployeeMasterID = value;
            }
        }
        [Display(Name = "Employee Name")]
        public string SaleContractEmployeeMasterName
        {
            get
            {
                return (ContractEmployeeReportDTO != null) ? ContractEmployeeReportDTO.SaleContractEmployeeMasterName : string.Empty;
            }
            set
            {
                ContractEmployeeReportDTO.SaleContractEmployeeMasterName = value;
            }
        }
        public string errorMessage { get; set; }
    }
}

