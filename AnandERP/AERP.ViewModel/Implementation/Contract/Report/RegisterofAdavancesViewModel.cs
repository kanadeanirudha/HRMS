using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class RegisterofAdavancesViewModel
    {

        public RegisterofAdavancesViewModel()
        {
            RegisterofAdavances = new RegisterofAdavances();
            RegisterofAdavancesList = new List<RegisterofAdavances>();
            RegisterofAdavancesDetailListForparticulars = new List<RegisterofAdavances>();
            RegisterofAdavancesDTO = new RegisterofAdavances();

        }
        public RegisterofAdavances RegisterofAdavancesDTO
        { get; set; }

        public List<RegisterofAdavances> RegisterofAdavancesList { get; set; }
        public List<RegisterofAdavances> RegisterofAdavancesDetailListForparticulars { get; set; }

        public RegisterofAdavances RegisterofAdavances
        {
            get;
            set;
        }

        public Int64 ID
        {
            get
            {
                return (RegisterofAdavances != null && RegisterofAdavances.ID > 0) ? RegisterofAdavances.ID : new Int64();
            }
            set
            {
                RegisterofAdavances.ID = value;
            }
        }
        [Display(Name = "Employee Name")]
        public int SaleContractEmployeeMasterID
        {
            get
            {
                return (RegisterofAdavances != null && RegisterofAdavances.SaleContractEmployeeMasterID > 0) ? RegisterofAdavances.SaleContractEmployeeMasterID : new int();
            }
            set
            {
                RegisterofAdavances.ID = value;
            }
        }
        [Display(Name = "Year")]
        public string MonthYear
        {
            get
            {
                return (RegisterofAdavances != null) ? RegisterofAdavances.MonthYear : string.Empty;
            }
            set
            {
                RegisterofAdavances.MonthYear = value;
            }
        }

        [Display(Name = "Employee Name")]
        public string SaleContractEmployeeMasterName
        {
            get
            {
                return (RegisterofAdavances != null) ? RegisterofAdavances.SaleContractEmployeeMasterName : string.Empty;
            }
            set
            {
                RegisterofAdavances.SaleContractEmployeeMasterName = value;
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
                return (RegisterofAdavances != null) ? RegisterofAdavances.IsDeleted : false;
            }
            set
            {
                RegisterofAdavances.IsDeleted = value;
            }
        }

        [Display(Name = "Created By")]
        public int CreatedBy
        {
            get
            {
                return (RegisterofAdavances != null && RegisterofAdavances.CreatedBy > 0) ? RegisterofAdavances.CreatedBy : new int();
            }
            set
            {
                RegisterofAdavances.CreatedBy = value;
            }
        }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate
        {
            get
            {
                return (RegisterofAdavances != null) ? RegisterofAdavances.CreatedDate : DateTime.Now;
            }
            set
            {
                RegisterofAdavances.CreatedDate = value;
            }
        }

        [Display(Name = "Modified By")]
        public int ModifiedBy
        {
            get
            {
                return (RegisterofAdavances != null && RegisterofAdavances.ModifiedBy > 0) ? RegisterofAdavances.ModifiedBy : new int();
            }
            set
            {
                RegisterofAdavances.ModifiedBy = value;
            }
        }

        [Display(Name = "Modified Date")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (RegisterofAdavances != null && RegisterofAdavances.ModifiedDate.HasValue) ? RegisterofAdavances.ModifiedDate : DateTime.Now;
            }
            set
            {
                RegisterofAdavances.ModifiedDate = value;
            }
        }

        [Display(Name = "Deleted By")]
        public int DeletedBy
        {
            get
            {
                return (RegisterofAdavances != null && RegisterofAdavances.DeletedBy > 0) ? RegisterofAdavances.DeletedBy : new int();
            }
            set
            {
                RegisterofAdavances.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (RegisterofAdavances != null && RegisterofAdavances.DeletedDate.HasValue) ? RegisterofAdavances.DeletedDate : DateTime.Now;
            }
            set
            {
                RegisterofAdavances.DeletedDate = value;
            }
        }



        public string errorMessage { get; set; }
    }
}

