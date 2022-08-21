using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class RegisterofOvertimeViewModel
    {

        public RegisterofOvertimeViewModel()
        {
            RegisterofOvertime = new RegisterofOvertime();
            RegisterofOvertimeList = new List<RegisterofOvertime>();
            RegisterofOvertimeDetailListForparticulars = new List<RegisterofOvertime>();
            RegisterofOvertimeDTO = new RegisterofOvertime();

        }
        public RegisterofOvertime RegisterofOvertimeDTO
        { get; set; }

        public List<RegisterofOvertime> RegisterofOvertimeList { get; set; }
        public List<RegisterofOvertime> RegisterofOvertimeDetailListForparticulars { get; set; }

        public RegisterofOvertime RegisterofOvertime
        {
            get;
            set;
        }

        public Int64 ID
        {
            get
            {
                return (RegisterofOvertime != null && RegisterofOvertime.ID > 0) ? RegisterofOvertime.ID : new Int64();
            }
            set
            {
                RegisterofOvertime.ID = value;
            }
        }
        [Display(Name = "Employee Name")]
        public int SaleContractEmployeeMasterID
        {
            get
            {
                return (RegisterofOvertime != null && RegisterofOvertime.SaleContractEmployeeMasterID > 0) ? RegisterofOvertime.SaleContractEmployeeMasterID : new int();
            }
            set
            {
                RegisterofOvertime.ID = value;
            }
        }
        [Display(Name = "Year")]
        public string MonthYear
        {
            get
            {
                return (RegisterofOvertime != null) ? RegisterofOvertime.MonthYear : string.Empty;
            }
            set
            {
                RegisterofOvertime.MonthYear = value;
            }
        }

        [Display(Name = "Employee Name")]
        public string SaleContractEmployeeMasterName
        {
            get
            {
                return (RegisterofOvertime != null) ? RegisterofOvertime.SaleContractEmployeeMasterName : string.Empty;
            }
            set
            {
                RegisterofOvertime.SaleContractEmployeeMasterName = value;
            }
        }

        public bool IsPosted { get; set; }
        public string CentreCode
        {
            get;
            set;
        }
        [Display(Name = "Is Deleted")]
        public bool IsDeleted
        {
            get
            {
                return (RegisterofOvertime != null) ? RegisterofOvertime.IsDeleted : false;
            }
            set
            {
                RegisterofOvertime.IsDeleted = value;
            }
        }

        [Display(Name = "Created By")]
        public int CreatedBy
        {
            get
            {
                return (RegisterofOvertime != null && RegisterofOvertime.CreatedBy > 0) ? RegisterofOvertime.CreatedBy : new int();
            }
            set
            {
                RegisterofOvertime.CreatedBy = value;
            }
        }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate
        {
            get
            {
                return (RegisterofOvertime != null) ? RegisterofOvertime.CreatedDate : DateTime.Now;
            }
            set
            {
                RegisterofOvertime.CreatedDate = value;
            }
        }

        [Display(Name = "Modified By")]
        public int ModifiedBy
        {
            get
            {
                return (RegisterofOvertime != null && RegisterofOvertime.ModifiedBy > 0) ? RegisterofOvertime.ModifiedBy : new int();
            }
            set
            {
                RegisterofOvertime.ModifiedBy = value;
            }
        }

        [Display(Name = "Modified Date")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (RegisterofOvertime != null && RegisterofOvertime.ModifiedDate.HasValue) ? RegisterofOvertime.ModifiedDate : DateTime.Now;
            }
            set
            {
                RegisterofOvertime.ModifiedDate = value;
            }
        }

        [Display(Name = "Deleted By")]
        public int DeletedBy
        {
            get
            {
                return (RegisterofOvertime != null && RegisterofOvertime.DeletedBy > 0) ? RegisterofOvertime.DeletedBy : new int();
            }
            set
            {
                RegisterofOvertime.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (RegisterofOvertime != null && RegisterofOvertime.DeletedDate.HasValue) ? RegisterofOvertime.DeletedDate : DateTime.Now;
            }
            set
            {
                RegisterofOvertime.DeletedDate = value;
            }
        }



        public string errorMessage { get; set; }
    }
}

