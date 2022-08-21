using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{
    public class GeneralCounterMasterViewModel : IGeneralCounterMasterViewModel
    {

        public GeneralCounterMasterViewModel()
        {
            GeneralCounterMasterDTO = new GeneralCounterMaster();
           
        }
       
       
      
        public GeneralCounterMaster GeneralCounterMasterDTO
        {
            get;
            set;
        }

        public Int32 ID
        {
            get
            {
                return (GeneralCounterMasterDTO != null && GeneralCounterMasterDTO.ID > 0) ? GeneralCounterMasterDTO.ID : new Int32();
            }
            set
            {
                GeneralCounterMasterDTO.ID = value;
            }
        }

        [Required(ErrorMessage = "Counter Name should not be blank.")]
        [Display(Name = "Counter Name")]
        public string CounterName
        {
            get
            {
                return (GeneralCounterMasterDTO != null) ? GeneralCounterMasterDTO.CounterName : string.Empty;
            }
            set
            {
                GeneralCounterMasterDTO.CounterName = value;
            }
        }

        [Required(ErrorMessage = "Counter Code should not be blank.")]
        [Display(Name = "Counter Code")]
        public string CounterCode
        {
            get
            {
                return (GeneralCounterMasterDTO != null) ? GeneralCounterMasterDTO.CounterCode : string.Empty;
            }
            set
            {
                GeneralCounterMasterDTO.CounterCode = value;
            }
        }
         [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (GeneralCounterMasterDTO != null && GeneralCounterMasterDTO.CreatedBy > 0) ? GeneralCounterMasterDTO.CreatedBy : new int();
            }
            set
            {
                GeneralCounterMasterDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (GeneralCounterMasterDTO != null) ? GeneralCounterMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                GeneralCounterMasterDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int ModifiedBy
        {
            get
            {
                return (GeneralCounterMasterDTO != null) ? GeneralCounterMasterDTO.ModifiedBy : new int();
            }
            set
            {
                GeneralCounterMasterDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime ModifiedDate
        {
            get
            {
                return (GeneralCounterMasterDTO != null) ? GeneralCounterMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                GeneralCounterMasterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int DeletedBy
        {
            get
            {
                return (GeneralCounterMasterDTO != null) ? GeneralCounterMasterDTO.DeletedBy : new int();
            }
            set
            {
                GeneralCounterMasterDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime DeletedDate
        {
            get
            {
                return (GeneralCounterMasterDTO != null) ? GeneralCounterMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                GeneralCounterMasterDTO.DeletedDate = value;
            }
        }
        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (GeneralCounterMasterDTO != null) ? GeneralCounterMasterDTO.IsDeleted : false;
            }
            set
            {
                GeneralCounterMasterDTO.IsDeleted = value;
            }
        }

        public string errorMessage { get; set; }

       }
}


