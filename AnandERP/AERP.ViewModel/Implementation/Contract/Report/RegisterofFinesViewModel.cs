using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class RegisterofFinesViewModel
    {

        public RegisterofFinesViewModel()
        {
            RegisterofFines = new RegisterofFines();
            RegisterofFinesList = new List<RegisterofFines>();
            RegisterofFinesDetailListForparticulars = new List<RegisterofFines>();
            RegisterofFinesDTO = new RegisterofFines();

        }
        public RegisterofFines RegisterofFinesDTO
        { get; set; }

        public List<RegisterofFines> RegisterofFinesList { get; set; }
        public List<RegisterofFines> RegisterofFinesDetailListForparticulars { get; set; }

        public RegisterofFines RegisterofFines
        {
            get;
            set;
        }

        public Int64 ID
        {
            get
            {
                return (RegisterofFines != null && RegisterofFines.ID > 0) ? RegisterofFines.ID : new Int64();
            }
            set
            {
                RegisterofFines.ID = value;
            }
        }
        [Display(Name = "Employee Name")]
        public int SaleContractEmployeeMasterID
        {
            get
            {
                return (RegisterofFines != null && RegisterofFines.SaleContractEmployeeMasterID > 0) ? RegisterofFines.SaleContractEmployeeMasterID : new int();
            }
            set
            {
                RegisterofFines.ID = value;
            }
        }
        [Display(Name = "Year")]
        public string MonthYear
        {
            get
            {
                return (RegisterofFines != null) ? RegisterofFines.MonthYear : string.Empty;
            }
            set
            {
                RegisterofFines.MonthYear = value;
            }
        }

        [Display(Name = "Employee Name")]
        public string SaleContractEmployeeMasterName
        {
            get
            {
                return (RegisterofFines != null) ? RegisterofFines.SaleContractEmployeeMasterName : string.Empty;
            }
            set
            {
                RegisterofFines.SaleContractEmployeeMasterName = value;
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
                return (RegisterofFines != null) ? RegisterofFines.IsDeleted : false;
            }
            set
            {
                RegisterofFines.IsDeleted = value;
            }
        }

        [Display(Name = "Created By")]
        public int CreatedBy
        {
            get
            {
                return (RegisterofFines != null && RegisterofFines.CreatedBy > 0) ? RegisterofFines.CreatedBy : new int();
            }
            set
            {
                RegisterofFines.CreatedBy = value;
            }
        }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate
        {
            get
            {
                return (RegisterofFines != null) ? RegisterofFines.CreatedDate : DateTime.Now;
            }
            set
            {
                RegisterofFines.CreatedDate = value;
            }
        }

        [Display(Name = "Modified By")]
        public int ModifiedBy
        {
            get
            {
                return (RegisterofFines != null && RegisterofFines.ModifiedBy > 0) ? RegisterofFines.ModifiedBy : new int();
            }
            set
            {
                RegisterofFines.ModifiedBy = value;
            }
        }

        [Display(Name = "Modified Date")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (RegisterofFines != null && RegisterofFines.ModifiedDate.HasValue) ? RegisterofFines.ModifiedDate : DateTime.Now;
            }
            set
            {
                RegisterofFines.ModifiedDate = value;
            }
        }

        [Display(Name = "Deleted By")]
        public int DeletedBy
        {
            get
            {
                return (RegisterofFines != null && RegisterofFines.DeletedBy > 0) ? RegisterofFines.DeletedBy : new int();
            }
            set
            {
                RegisterofFines.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (RegisterofFines != null && RegisterofFines.DeletedDate.HasValue) ? RegisterofFines.DeletedDate : DateTime.Now;
            }
            set
            {
                RegisterofFines.DeletedDate = value;
            }
        }



        public string errorMessage { get; set; }
    }
}

