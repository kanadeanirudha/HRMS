using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{
    public class GeneralTimeSlotMasterViewModel : IGeneralTimeSlotMasterViewModel
    {

        public GeneralTimeSlotMasterViewModel()
        {
            GeneralTimeSlotMasterDTO = new GeneralTimeSlotMaster();
        }

        public GeneralTimeSlotMaster GeneralTimeSlotMasterDTO
        {
            get;
            set;
        }

        public Int16 ID
        {
            get
            {
                return (GeneralTimeSlotMasterDTO != null && GeneralTimeSlotMasterDTO.ID > 0) ? GeneralTimeSlotMasterDTO.ID : new Int16();
            }
            set
            {
                GeneralTimeSlotMasterDTO.ID = value;
            }
        }

        [Display(Name = "DisplayName_FromTime", ResourceType = typeof(AMS.Common.Resources))]
        public string FromTime
        {
            get
            {
                return (GeneralTimeSlotMasterDTO != null) ? GeneralTimeSlotMasterDTO.FromTime : string.Empty;
            }
            set
            {
                GeneralTimeSlotMasterDTO.FromTime = value;
            }
        }

        [Display(Name = "DisplayName_ToTime", ResourceType = typeof(Resources))]       
        public string ToTime
        {
            get
            {
                return (GeneralTimeSlotMasterDTO != null) ? GeneralTimeSlotMasterDTO.ToTime : string.Empty;
            }
            set
            {
                GeneralTimeSlotMasterDTO.ToTime = value;
            }
        }

      //  [Display(Name = "DisplayName_ToTime", ResourceType = typeof(Resources))]
        public string TimeSlot
        {
            get
            {
                return (GeneralTimeSlotMasterDTO != null) ? GeneralTimeSlotMasterDTO.TimeSlot : string.Empty;
            }
            set
            {
                GeneralTimeSlotMasterDTO.TimeSlot = value;
            }
        }
        

        [Display(Name = "Is Active?")]
        public bool IsActive
        {
            get
            {
                return (GeneralTimeSlotMasterDTO != null) ? GeneralTimeSlotMasterDTO.IsActive : false;
            }
            set
            {
                GeneralTimeSlotMasterDTO.IsActive = value;
            }
        }
       
        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (GeneralTimeSlotMasterDTO != null) ? GeneralTimeSlotMasterDTO.IsDeleted : false;
            }
            set
            {
                GeneralTimeSlotMasterDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (GeneralTimeSlotMasterDTO != null && GeneralTimeSlotMasterDTO.CreatedBy > 0) ? GeneralTimeSlotMasterDTO.CreatedBy : new int();
            }
            set
            {
                GeneralTimeSlotMasterDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (GeneralTimeSlotMasterDTO != null) ? GeneralTimeSlotMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                GeneralTimeSlotMasterDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (GeneralTimeSlotMasterDTO != null && GeneralTimeSlotMasterDTO.ModifiedBy.HasValue) ? GeneralTimeSlotMasterDTO.ModifiedBy : new int();
            }
            set
            {
                GeneralTimeSlotMasterDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (GeneralTimeSlotMasterDTO != null && GeneralTimeSlotMasterDTO.ModifiedDate.HasValue) ? GeneralTimeSlotMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                GeneralTimeSlotMasterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (GeneralTimeSlotMasterDTO != null && GeneralTimeSlotMasterDTO.DeletedBy.HasValue) ? GeneralTimeSlotMasterDTO.DeletedBy : new int();
            }
            set
            {
                GeneralTimeSlotMasterDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (GeneralTimeSlotMasterDTO != null && GeneralTimeSlotMasterDTO.DeletedDate.HasValue) ? GeneralTimeSlotMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                GeneralTimeSlotMasterDTO.DeletedDate = value;
            }
        }
      
        public string errorMessage { get; set; }
    }
}

