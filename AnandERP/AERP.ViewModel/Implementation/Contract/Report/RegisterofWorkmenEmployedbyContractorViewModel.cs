using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class RegisterofWorkmenEmployedbyContractorViewModel
    {

        public RegisterofWorkmenEmployedbyContractorViewModel()
        {
            RegisterofWorkmenEmployedbyContractor = new RegisterofWorkmenEmployedbyContractor();
            RegisterofWorkmenEmployedbyContractorList = new List<RegisterofWorkmenEmployedbyContractor>();
            RegisterofWorkmenEmployedbyContractorDetailListForparticulars = new List<RegisterofWorkmenEmployedbyContractor>();
            RegisterofWorkmenEmployedbyContractorDTO = new RegisterofWorkmenEmployedbyContractor();

        }
        public RegisterofWorkmenEmployedbyContractor RegisterofWorkmenEmployedbyContractorDTO
        { get; set; }

        public List<RegisterofWorkmenEmployedbyContractor> RegisterofWorkmenEmployedbyContractorList { get; set; }
        public List<RegisterofWorkmenEmployedbyContractor> RegisterofWorkmenEmployedbyContractorDetailListForparticulars { get; set; }

        public RegisterofWorkmenEmployedbyContractor RegisterofWorkmenEmployedbyContractor
        {
            get;
            set;
        }

        public Int64 ID
        {
            get
            {
                return (RegisterofWorkmenEmployedbyContractor != null && RegisterofWorkmenEmployedbyContractor.ID > 0) ? RegisterofWorkmenEmployedbyContractor.ID : new Int64();
            }
            set
            {
                RegisterofWorkmenEmployedbyContractor.ID = value;
            }
        }
        [Display(Name = "Employee Name")]
        public int SaleContractEmployeeMasterID
        {
            get
            {
                return (RegisterofWorkmenEmployedbyContractor != null && RegisterofWorkmenEmployedbyContractor.SaleContractEmployeeMasterID > 0) ? RegisterofWorkmenEmployedbyContractor.SaleContractEmployeeMasterID : new int();
            }
            set
            {
                RegisterofWorkmenEmployedbyContractor.ID = value;
            }
        }
        [Display(Name = "Year")]
        public string MonthYear
        {
            get
            {
                return (RegisterofWorkmenEmployedbyContractor != null) ? RegisterofWorkmenEmployedbyContractor.MonthYear : string.Empty;
            }
            set
            {
                RegisterofWorkmenEmployedbyContractor.MonthYear = value;
            }
        }

        [Display(Name = "Employee Name")]
        public string SaleContractEmployeeMasterName
        {
            get
            {
                return (RegisterofWorkmenEmployedbyContractor != null) ? RegisterofWorkmenEmployedbyContractor.SaleContractEmployeeMasterName : string.Empty;
            }
            set
            {
                RegisterofWorkmenEmployedbyContractor.SaleContractEmployeeMasterName = value;
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
                return (RegisterofWorkmenEmployedbyContractor != null) ? RegisterofWorkmenEmployedbyContractor.IsDeleted : false;
            }
            set
            {
                RegisterofWorkmenEmployedbyContractor.IsDeleted = value;
            }
        }

        [Display(Name = "Created By")]
        public int CreatedBy
        {
            get
            {
                return (RegisterofWorkmenEmployedbyContractor != null && RegisterofWorkmenEmployedbyContractor.CreatedBy > 0) ? RegisterofWorkmenEmployedbyContractor.CreatedBy : new int();
            }
            set
            {
                RegisterofWorkmenEmployedbyContractor.CreatedBy = value;
            }
        }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate
        {
            get
            {
                return (RegisterofWorkmenEmployedbyContractor != null) ? RegisterofWorkmenEmployedbyContractor.CreatedDate : DateTime.Now;
            }
            set
            {
                RegisterofWorkmenEmployedbyContractor.CreatedDate = value;
            }
        }

        [Display(Name = "Modified By")]
        public int ModifiedBy
        {
            get
            {
                return (RegisterofWorkmenEmployedbyContractor != null && RegisterofWorkmenEmployedbyContractor.ModifiedBy > 0) ? RegisterofWorkmenEmployedbyContractor.ModifiedBy : new int();
            }
            set
            {
                RegisterofWorkmenEmployedbyContractor.ModifiedBy = value;
            }
        }

        [Display(Name = "Modified Date")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (RegisterofWorkmenEmployedbyContractor != null && RegisterofWorkmenEmployedbyContractor.ModifiedDate.HasValue) ? RegisterofWorkmenEmployedbyContractor.ModifiedDate : DateTime.Now;
            }
            set
            {
                RegisterofWorkmenEmployedbyContractor.ModifiedDate = value;
            }
        }

        [Display(Name = "Deleted By")]
        public int DeletedBy
        {
            get
            {
                return (RegisterofWorkmenEmployedbyContractor != null && RegisterofWorkmenEmployedbyContractor.DeletedBy > 0) ? RegisterofWorkmenEmployedbyContractor.DeletedBy : new int();
            }
            set
            {
                RegisterofWorkmenEmployedbyContractor.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (RegisterofWorkmenEmployedbyContractor != null && RegisterofWorkmenEmployedbyContractor.DeletedDate.HasValue) ? RegisterofWorkmenEmployedbyContractor.DeletedDate : DateTime.Now;
            }
            set
            {
                RegisterofWorkmenEmployedbyContractor.DeletedDate = value;
            }
        }



        public string errorMessage { get; set; }
    }
}

