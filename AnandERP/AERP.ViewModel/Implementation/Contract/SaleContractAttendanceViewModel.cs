using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class SaleContractAttendanceViewModel : ISaleContractAttendanceViewModel
    {

        public SaleContractAttendanceViewModel()
        {
            SaleContractAttendanceDTO = new SaleContractAttendance();
            SaleContractAttendanceList = new List<SaleContractAttendance>();
        }

        public List<SaleContractAttendance> SaleContractAttendanceList { get; set; }

        public IEnumerable<SelectListItem> ListGetContractMonths
        {
            get
            {
                return new SelectList(SaleContractAttendanceList, "Months", "Months");
            }
        }
        public IEnumerable<SelectListItem> ListGetContractSpans
        {
            get
            {
                return new SelectList(SaleContractAttendanceList, "SaleContractBillingSpanID", "SaleContractBillingSpanName");
            }
        }
        
        public SaleContractAttendance SaleContractAttendanceDTO
        {
            get;
            set;
        }

        public Int64 ID
        {
            get
            {
                return (SaleContractAttendanceDTO != null && SaleContractAttendanceDTO.ID > 0) ? SaleContractAttendanceDTO.ID : new Int64();
            }
            set
            {
                SaleContractAttendanceDTO.ID = value;
            }
        }
        public Int64 SaleContractMasterID
        {
            get
            {
                return (SaleContractAttendanceDTO != null && SaleContractAttendanceDTO.SaleContractMasterID > 0) ? SaleContractAttendanceDTO.SaleContractMasterID : new Int64();
            }
            set
            {
                SaleContractAttendanceDTO.SaleContractMasterID = value;
            }
        }

        [Display(Name = "Customer Branch")]
        public Int32 CustomerBranchMasterID
        {
            get
            {
                return (SaleContractAttendanceDTO != null && SaleContractAttendanceDTO.CustomerBranchMasterID > 0) ? SaleContractAttendanceDTO.CustomerBranchMasterID : new Int32();
            }
            set
            {
                SaleContractAttendanceDTO.CustomerBranchMasterID = value;
            }
        }
        [Display(Name = "Customer Branch")]
        public string CustomerBranchMasterName
        {
            get
            {
                return (SaleContractAttendanceDTO != null) ? SaleContractAttendanceDTO.CustomerBranchMasterName : string.Empty;
            }
            set
            {
                SaleContractAttendanceDTO.CustomerBranchMasterName = value;
            }
        }

        [Display(Name = "Customer")]
        [Required(ErrorMessage = "Customer Required")]
        public Int32 CustomerMasterID
        {
            get
            {
                return (SaleContractAttendanceDTO != null && SaleContractAttendanceDTO.CustomerMasterID > 0) ? SaleContractAttendanceDTO.CustomerMasterID : new Int32();
            }
            set
            {
                SaleContractAttendanceDTO.CustomerMasterID = value;
            }
        }
        [Required(ErrorMessage = "Customer Required")]
        [Display(Name = "Customer")]
        public string CustomerMasterName
        {
            get
            {
                return (SaleContractAttendanceDTO != null) ? SaleContractAttendanceDTO.CustomerMasterName : string.Empty;
            }
            set
            {
                SaleContractAttendanceDTO.CustomerMasterName = value;
            }
        }
        [Display(Name = "Customer Type")]
        public byte CustomerType
        {
            get
            {
                return (SaleContractAttendanceDTO != null) ? SaleContractAttendanceDTO.CustomerType : new byte();
            }
            set
            {
                SaleContractAttendanceDTO.CustomerType = value;
            }
        }

        [Display(Name = "Contract Number")]
        public string ContractNumber
        {
            get
            {
                return (SaleContractAttendanceDTO != null) ? SaleContractAttendanceDTO.ContractNumber : string.Empty;
            }
            set
            {
                SaleContractAttendanceDTO.ContractNumber = value;
            }
        }

        public Int32 SaleContractManPowerItemID
        {
            get
            {
                return (SaleContractAttendanceDTO != null && SaleContractAttendanceDTO.SaleContractManPowerItemID > 0) ? SaleContractAttendanceDTO.SaleContractManPowerItemID : new Int32();
            }
            set
            {
                SaleContractAttendanceDTO.SaleContractManPowerItemID = value;

            }
        }

        [Display(Name = "Post Name")]
        public string SaleContractManPowerItemName
        {
            get
            {
                return (SaleContractAttendanceDTO != null) ? SaleContractAttendanceDTO.SaleContractManPowerItemName : string.Empty;
            }
            set
            {
                SaleContractAttendanceDTO.SaleContractManPowerItemName = value;
            }
        }

        [Display(Name = "Contract Employee")]
        public Int64 SaleContractEmployeeMasterID
        {
            get
            {
                return (SaleContractAttendanceDTO != null) ? SaleContractAttendanceDTO.SaleContractEmployeeMasterID : new Int64();
            }
            set
            {
                SaleContractAttendanceDTO.SaleContractEmployeeMasterID = value;
            }
        }
        [Display(Name = "Contract Employee")]
        public string SaleContractEmployeeMasterName
        {
            get
            {
                return (SaleContractAttendanceDTO != null) ? SaleContractAttendanceDTO.SaleContractEmployeeMasterName : string.Empty;
            }
            set
            {
                SaleContractAttendanceDTO.SaleContractEmployeeMasterName = value;
            }
        }
        [Display(Name = "Attendance Date")]
        public string AttendanceDate
        {
            get
            {
                return (SaleContractAttendanceDTO != null) ? SaleContractAttendanceDTO.AttendanceDate : string.Empty;
            }
            set
            {
                SaleContractAttendanceDTO.AttendanceDate = value;
            }
        }
        [Display(Name = "Split From Date")]
        public string SplitFromDate
        {
            get
            {
                return (SaleContractAttendanceDTO != null) ? SaleContractAttendanceDTO.SplitFromDate : string.Empty;
            }
            set
            {
                SaleContractAttendanceDTO.SplitFromDate = value;
            }
        }
        [Display(Name = "Attendance Status")]
        public byte AttendanceStatus
        {
            get
            {
                return (SaleContractAttendanceDTO != null) ? SaleContractAttendanceDTO.AttendanceStatus : new byte();
            }
            set
            {
                SaleContractAttendanceDTO.AttendanceStatus = value;
            }
        }
        [Display(Name = "Is Half Day Leave")]
        public bool IsHalfDayLeave
        {
            get
            {
                return (SaleContractAttendanceDTO != null) ? SaleContractAttendanceDTO.IsHalfDayLeave : false;
            }
            set
            {
                SaleContractAttendanceDTO.IsHalfDayLeave = value;
            }
        }
        [Display(Name = "Over Time Hours")]
        public decimal OvertimeHours
        {
            get
            {
                return (SaleContractAttendanceDTO != null) ? SaleContractAttendanceDTO.OvertimeHours : new decimal();
            }
            set
            {
                SaleContractAttendanceDTO.OvertimeHours = value;
            }
        }
        [Display(Name = "Invoice Number")]
        public string InvoiceNumber
        {
            get
            {
                return (SaleContractAttendanceDTO != null) ? SaleContractAttendanceDTO.InvoiceNumber : string.Empty;
            }
            set
            {
                SaleContractAttendanceDTO.InvoiceNumber = value;
            }
        }
        [Display(Name = "Salary ID")]
        public Int32 SalaryGenerateID
        {
            get
            {
                return (SaleContractAttendanceDTO != null && SaleContractAttendanceDTO.SalaryGenerateID > 0) ? SaleContractAttendanceDTO.SalaryGenerateID : new Int32();
            }
            set
            {
                SaleContractAttendanceDTO.SalaryGenerateID = value;

            }
        }
        [Display(Name = "Month")]
        public string Months
        {
            get
            {
                return (SaleContractAttendanceDTO != null) ? SaleContractAttendanceDTO.Months : string.Empty;
            }
            set
            {
                SaleContractAttendanceDTO.Months = value;
            }
        }
        [Display(Name = "AttendanceStatusList")]
        public string AttendanceStatusList
        {
            get
            {
                return (SaleContractAttendanceDTO != null) ? SaleContractAttendanceDTO.AttendanceStatusList : string.Empty;
            }
            set
            {
                SaleContractAttendanceDTO.AttendanceStatusList = value;
            }
        }
        [Display(Name = "AttendanceDays")]
        public string AttendanceDays
        {
            get
            {
                return (SaleContractAttendanceDTO != null) ? SaleContractAttendanceDTO.AttendanceDays : string.Empty;
            }
            set
            {
                SaleContractAttendanceDTO.AttendanceDays = value;
            }
        }
        [Display(Name = "Attendance For Month")]
        public string AttendanceForMonth
        {
            get
            {
                return (SaleContractAttendanceDTO != null) ? SaleContractAttendanceDTO.AttendanceForMonth : string.Empty;
            }
            set
            {
                SaleContractAttendanceDTO.AttendanceForMonth = value;
            }
        }
        [Display(Name = "Total Attendance")]
        public decimal TotalAttendance
        {
            get
            {
                return (SaleContractAttendanceDTO != null) ? SaleContractAttendanceDTO.TotalAttendance : new decimal();
            }
            set
            {
                SaleContractAttendanceDTO.TotalAttendance = value;
            }
        }
        [Display(Name = "Total Days")]
        public byte TotalDays
        {
            get
            {
                return (SaleContractAttendanceDTO != null) ? SaleContractAttendanceDTO.TotalDays : new byte();
            }
            set
            {
                SaleContractAttendanceDTO.TotalDays = value;
            }
        }
        [Display(Name = "Billing Span")]
        public Int64 SaleContractBillingSpanID
        {
            get
            {
                return (SaleContractAttendanceDTO != null) ? SaleContractAttendanceDTO.SaleContractBillingSpanID : new Int64();
            }
            set
            {
                SaleContractAttendanceDTO.SaleContractBillingSpanID = value;
            }
        }
        [Display(Name = "Billing Span")]
        public string SaleContractBillingSpanName
        {
            get
            {
                return (SaleContractAttendanceDTO != null) ? SaleContractAttendanceDTO.SaleContractBillingSpanName : string.Empty;
            }
            set
            {
                SaleContractAttendanceDTO.SaleContractBillingSpanName = value;
            }
        }
        [Display(Name = "Is Deleted")]
        public bool IsDeleted
        {
            get
            {
                return (SaleContractAttendanceDTO != null) ? SaleContractAttendanceDTO.IsDeleted : false;
            }
            set
            {
                SaleContractAttendanceDTO.IsDeleted = value;
            }
        }

        [Display(Name = "Created By")]
        public int CreatedBy
        {
            get
            {
                return (SaleContractAttendanceDTO != null && SaleContractAttendanceDTO.CreatedBy > 0) ? SaleContractAttendanceDTO.CreatedBy : new int();
            }
            set
            {
                SaleContractAttendanceDTO.CreatedBy = value;
            }
        }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate
        {
            get
            {
                return (SaleContractAttendanceDTO != null) ? SaleContractAttendanceDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                SaleContractAttendanceDTO.CreatedDate = value;
            }
        }

        [Display(Name = "Modified By")]
        public int ModifiedBy
        {
            get
            {
                return (SaleContractAttendanceDTO != null && SaleContractAttendanceDTO.ModifiedBy > 0) ? SaleContractAttendanceDTO.ModifiedBy : new int();
            }
            set
            {
                SaleContractAttendanceDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "Modified Date")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (SaleContractAttendanceDTO != null && SaleContractAttendanceDTO.ModifiedDate.HasValue) ? SaleContractAttendanceDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                SaleContractAttendanceDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "Deleted By")]
        public int DeletedBy
        {
            get
            {
                return (SaleContractAttendanceDTO != null && SaleContractAttendanceDTO.DeletedBy > 0) ? SaleContractAttendanceDTO.DeletedBy : new int();
            }
            set
            {
                SaleContractAttendanceDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (SaleContractAttendanceDTO != null && SaleContractAttendanceDTO.DeletedDate.HasValue) ? SaleContractAttendanceDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                SaleContractAttendanceDTO.DeletedDate = value;
            }
        }

        public string errorMessage { get; set; }
        public string XMLstringForAttendance { get; set; }

        [Display(Name = "Man Power Item")]
        public Int64 SalaryForManPowerItemID
        {
            get
            {
                return (SaleContractAttendanceDTO != null) ? SaleContractAttendanceDTO.SalaryForManPowerItemID : new Int64();
            }
            set
            {
                SaleContractAttendanceDTO.SalaryForManPowerItemID = value;
            }
        }
        [Display(Name = "Man Power Item")]
        public string SalaryForManPowerItemName
        {
            get
            {
                return (SaleContractAttendanceDTO != null) ? SaleContractAttendanceDTO.SalaryForManPowerItemName : string.Empty;
            }
            set
            {
                SaleContractAttendanceDTO.SalaryForManPowerItemName = value;
            }
        }
    }
}