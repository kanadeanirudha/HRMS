using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class PaymentOfBonusViewModel
    {

        public PaymentOfBonusViewModel()
        {
            PaymentOfBonus = new PaymentOfBonus();
            PaymentOfBonusList = new List<PaymentOfBonus>();
            PaymentOfBonusDetailListForparticulars = new List<PaymentOfBonus>();
            PaymentOfBonusDTO = new PaymentOfBonus();

        }
        public PaymentOfBonus PaymentOfBonusDTO
        { get; set; }

        public List<PaymentOfBonus> PaymentOfBonusList { get; set; }
        public List<PaymentOfBonus> PaymentOfBonusDetailListForparticulars { get; set; }

        public PaymentOfBonus PaymentOfBonus
        {
            get;
            set;
        }

        public Int64 ID
        {
            get
            {
                return (PaymentOfBonus != null && PaymentOfBonus.ID > 0) ? PaymentOfBonus.ID : new Int64();
            }
            set
            {
                PaymentOfBonus.ID = value;
            }
        }
        [Display(Name = "Employee Name")]
        public int SaleContractEmployeeMasterID
        {
            get
            {
                return (PaymentOfBonus != null && PaymentOfBonus.SaleContractEmployeeMasterID > 0) ? PaymentOfBonus.SaleContractEmployeeMasterID : new int();
            }
            set
            {
                PaymentOfBonus.ID = value;
            }
        }
        [Display(Name = "Year")]
        public string MonthYear
        {
            get
            {
                return (PaymentOfBonus != null) ? PaymentOfBonus.MonthYear : string.Empty;
            }
            set
            {
                PaymentOfBonus.MonthYear = value;
            }
        }

        [Display(Name = "Employee Name")]
        public string SaleContractEmployeeMasterName
        {
            get
            {
                return (PaymentOfBonus != null) ? PaymentOfBonus.SaleContractEmployeeMasterName : string.Empty;
            }
            set
            {
                PaymentOfBonus.SaleContractEmployeeMasterName = value;
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
                return (PaymentOfBonus != null) ? PaymentOfBonus.IsDeleted : false;
            }
            set
            {
                PaymentOfBonus.IsDeleted = value;
            }
        }

        [Display(Name = "Created By")]
        public int CreatedBy
        {
            get
            {
                return (PaymentOfBonus != null && PaymentOfBonus.CreatedBy > 0) ? PaymentOfBonus.CreatedBy : new int();
            }
            set
            {
                PaymentOfBonus.CreatedBy = value;
            }
        }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate
        {
            get
            {
                return (PaymentOfBonus != null) ? PaymentOfBonus.CreatedDate : DateTime.Now;
            }
            set
            {
                PaymentOfBonus.CreatedDate = value;
            }
        }

        [Display(Name = "Modified By")]
        public int ModifiedBy
        {
            get
            {
                return (PaymentOfBonus != null && PaymentOfBonus.ModifiedBy > 0) ? PaymentOfBonus.ModifiedBy : new int();
            }
            set
            {
                PaymentOfBonus.ModifiedBy = value;
            }
        }

        [Display(Name = "Modified Date")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (PaymentOfBonus != null && PaymentOfBonus.ModifiedDate.HasValue) ? PaymentOfBonus.ModifiedDate : DateTime.Now;
            }
            set
            {
                PaymentOfBonus.ModifiedDate = value;
            }
        }

        [Display(Name = "Deleted By")]
        public int DeletedBy
        {
            get
            {
                return (PaymentOfBonus != null && PaymentOfBonus.DeletedBy > 0) ? PaymentOfBonus.DeletedBy : new int();
            }
            set
            {
                PaymentOfBonus.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (PaymentOfBonus != null && PaymentOfBonus.DeletedDate.HasValue) ? PaymentOfBonus.DeletedDate : DateTime.Now;
            }
            set
            {
                PaymentOfBonus.DeletedDate = value;
            }
        }



        public string errorMessage { get; set; }
    }
}

