using System.Text;
using System.Threading.Tasks;
using AERP.DTO;
using System.ComponentModel.DataAnnotations;
using System;
namespace AERP.ViewModel
{
   public class CCRMFeedbackMasterViewModel :ICCRMFeedbackMasterViewModel
    {
        public CCRMFeedbackMasterViewModel()
        {
            CCRMFeedbackMasterDTO = new CCRMFeedbackMaster();
        }
        public CCRMFeedbackMaster CCRMFeedbackMasterDTO
        {
            get;
            set;
        }
        public byte ID
        {
            get
            {
                return (CCRMFeedbackMasterDTO != null && CCRMFeedbackMasterDTO.ID > 0) ? CCRMFeedbackMasterDTO.ID : new byte();
            }
            set
            {
                CCRMFeedbackMasterDTO.ID = value;
            }
        }
            [Display(Name = "Feedback Name")]
            [Required(ErrorMessage = "Feedback Name Required")]
            public string FeedbackName
        {
            get
            {
                return (CCRMFeedbackMasterDTO != null) ? CCRMFeedbackMasterDTO.FeedbackName : string.Empty;
            }
            set
            {
                CCRMFeedbackMasterDTO.FeedbackName = value;
            }
        }
        [Display(Name = "Feedback Points")]
        [Required(ErrorMessage = "Feedback Points Required")]
        public byte FeedbackPoints
        {
            get
            {
                return (CCRMFeedbackMasterDTO != null) ? CCRMFeedbackMasterDTO.FeedbackPoints : new byte();
            }
            set 
            {
                CCRMFeedbackMasterDTO.FeedbackPoints = value;
            }
        }

        public Nullable<int> CreatedBy
        {
            get
            {
                return (CCRMFeedbackMasterDTO != null && CCRMFeedbackMasterDTO.CreatedBy > 0) ? CCRMFeedbackMasterDTO.CreatedBy : new int();
            }
            set
            {
                CCRMFeedbackMasterDTO.CreatedBy = value;
            }
        }
        [Display(Name = "IsDeleted")]
        public Nullable<bool> IsDeleted
        {
            get
            {
                return (CCRMFeedbackMasterDTO != null) ? CCRMFeedbackMasterDTO.IsDeleted : false;
            }
            set
            {
                CCRMFeedbackMasterDTO.IsDeleted = value;
            }
        }
        public Nullable<DateTime> CreatedDate
        {
            get
            {
                return (CCRMFeedbackMasterDTO != null) ? CCRMFeedbackMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                CCRMFeedbackMasterDTO.CreatedDate = value;
            }
        }
        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (CCRMFeedbackMasterDTO != null && CCRMFeedbackMasterDTO.ModifiedBy.HasValue) ? CCRMFeedbackMasterDTO.ModifiedBy : new int();
            }
            set
            {
                CCRMFeedbackMasterDTO.ModifiedBy = value;
            }
        }
        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (CCRMFeedbackMasterDTO != null && CCRMFeedbackMasterDTO.ModifiedDate.HasValue) ? CCRMFeedbackMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                CCRMFeedbackMasterDTO.ModifiedDate = value;
            }
        }
        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (CCRMFeedbackMasterDTO != null && CCRMFeedbackMasterDTO.DeletedBy.HasValue) ? CCRMFeedbackMasterDTO.DeletedBy : new int();
            }
            set
            {
                CCRMFeedbackMasterDTO.DeletedBy = value;
            }
        }
        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (CCRMFeedbackMasterDTO != null && CCRMFeedbackMasterDTO.DeletedDate.HasValue) ? CCRMFeedbackMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                CCRMFeedbackMasterDTO.DeletedDate = value;
            }
        }

    }
}
