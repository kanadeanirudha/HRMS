using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class RegisterofDeductionsforDamageorLossViewModel
    {

        public RegisterofDeductionsforDamageorLossViewModel()
        {
            RegisterofDeductionsforDamageorLoss = new RegisterofDeductionsforDamageorLoss();
            RegisterofDeductionsforDamageorLossList = new List<RegisterofDeductionsforDamageorLoss>();
            RegisterofDeductionsforDamageorLossDetailListForparticulars = new List<RegisterofDeductionsforDamageorLoss>();
            RegisterofDeductionsforDamageorLossDTO = new RegisterofDeductionsforDamageorLoss();

        }
        public RegisterofDeductionsforDamageorLoss RegisterofDeductionsforDamageorLossDTO
        { get; set; }

        public List<RegisterofDeductionsforDamageorLoss> RegisterofDeductionsforDamageorLossList { get; set; }
        public List<RegisterofDeductionsforDamageorLoss> RegisterofDeductionsforDamageorLossDetailListForparticulars { get; set; }

        public RegisterofDeductionsforDamageorLoss RegisterofDeductionsforDamageorLoss
        {
            get;
            set;
        }

        public Int64 ID
        {
            get
            {
                return (RegisterofDeductionsforDamageorLoss != null && RegisterofDeductionsforDamageorLoss.ID > 0) ? RegisterofDeductionsforDamageorLoss.ID : new Int64();
            }
            set
            {
                RegisterofDeductionsforDamageorLoss.ID = value;
            }
        }
        [Display(Name = "Employee Name")]
        public int SaleContractEmployeeMasterID
        {
            get
            {
                return (RegisterofDeductionsforDamageorLoss != null && RegisterofDeductionsforDamageorLoss.SaleContractEmployeeMasterID > 0) ? RegisterofDeductionsforDamageorLoss.SaleContractEmployeeMasterID : new int();
            }
            set
            {
                RegisterofDeductionsforDamageorLoss.ID = value;
            }
        }
        [Display(Name = "Year")]
        public string MonthYear
        {
            get
            {
                return (RegisterofDeductionsforDamageorLoss != null) ? RegisterofDeductionsforDamageorLoss.MonthYear : string.Empty;
            }
            set
            {
                RegisterofDeductionsforDamageorLoss.MonthYear = value;
            }
        }

        [Display(Name = "Employee Name")]
        public string SaleContractEmployeeMasterName
        {
            get
            {
                return (RegisterofDeductionsforDamageorLoss != null) ? RegisterofDeductionsforDamageorLoss.SaleContractEmployeeMasterName : string.Empty;
            }
            set
            {
                RegisterofDeductionsforDamageorLoss.SaleContractEmployeeMasterName = value;
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
                return (RegisterofDeductionsforDamageorLoss != null) ? RegisterofDeductionsforDamageorLoss.IsDeleted : false;
            }
            set
            {
                RegisterofDeductionsforDamageorLoss.IsDeleted = value;
            }
        }

        [Display(Name = "Created By")]
        public int CreatedBy
        {
            get
            {
                return (RegisterofDeductionsforDamageorLoss != null && RegisterofDeductionsforDamageorLoss.CreatedBy > 0) ? RegisterofDeductionsforDamageorLoss.CreatedBy : new int();
            }
            set
            {
                RegisterofDeductionsforDamageorLoss.CreatedBy = value;
            }
        }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate
        {
            get
            {
                return (RegisterofDeductionsforDamageorLoss != null) ? RegisterofDeductionsforDamageorLoss.CreatedDate : DateTime.Now;
            }
            set
            {
                RegisterofDeductionsforDamageorLoss.CreatedDate = value;
            }
        }

        [Display(Name = "Modified By")]
        public int ModifiedBy
        {
            get
            {
                return (RegisterofDeductionsforDamageorLoss != null && RegisterofDeductionsforDamageorLoss.ModifiedBy > 0) ? RegisterofDeductionsforDamageorLoss.ModifiedBy : new int();
            }
            set
            {
                RegisterofDeductionsforDamageorLoss.ModifiedBy = value;
            }
        }

        [Display(Name = "Modified Date")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (RegisterofDeductionsforDamageorLoss != null && RegisterofDeductionsforDamageorLoss.ModifiedDate.HasValue) ? RegisterofDeductionsforDamageorLoss.ModifiedDate : DateTime.Now;
            }
            set
            {
                RegisterofDeductionsforDamageorLoss.ModifiedDate = value;
            }
        }

        [Display(Name = "Deleted By")]
        public int DeletedBy
        {
            get
            {
                return (RegisterofDeductionsforDamageorLoss != null && RegisterofDeductionsforDamageorLoss.DeletedBy > 0) ? RegisterofDeductionsforDamageorLoss.DeletedBy : new int();
            }
            set
            {
                RegisterofDeductionsforDamageorLoss.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (RegisterofDeductionsforDamageorLoss != null && RegisterofDeductionsforDamageorLoss.DeletedDate.HasValue) ? RegisterofDeductionsforDamageorLoss.DeletedDate : DateTime.Now;
            }
            set
            {
                RegisterofDeductionsforDamageorLoss.DeletedDate = value;
            }
        }



        public string errorMessage { get; set; }
    }
}

