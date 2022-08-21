using System.Text;
using System.Threading.Tasks;
using AERP.DTO;
using System.ComponentModel.DataAnnotations;
using System;

namespace AERP.ViewModel
{
   public class CCRMCallApprovalMasterViewModel :ICCRMCallApprovalMasterViewModel
    {
        public CCRMCallApprovalMasterViewModel()
        {
            CCRMCallApprovalMasterDTO = new CCRMCallApprovalMaster();
        }
        public CCRMCallApprovalMaster CCRMCallApprovalMasterDTO
        {
            get;
            set;
        }
        public Int32 ID
        {
            get
            {
                return (CCRMCallApprovalMasterDTO != null && CCRMCallApprovalMasterDTO.ID > 0) ? CCRMCallApprovalMasterDTO.ID : new Int32();
            }
            set
            {
                CCRMCallApprovalMasterDTO.ID = value;
            }
        }
        [Display(Name = "Call No")]
      
        public string CallTktNo
        {
            get
            {
                return (CCRMCallApprovalMasterDTO != null) ? CCRMCallApprovalMasterDTO.CallTktNo : string.Empty;
            }
            set
            {
                CCRMCallApprovalMasterDTO.CallTktNo = value;
            }
        }
        [Display(Name = "Call Date")]
       
        public string CallDate
        {
            get
            {
                return (CCRMCallApprovalMasterDTO != null) ? CCRMCallApprovalMasterDTO.CallDate : string.Empty;
            }
            set
            {
                CCRMCallApprovalMasterDTO.CallDate = value;
            }
        }
        [Display(Name = "Serial No")]
        //[Required(ErrorMessage = "Action Desciption Required")]
        public string SerialNo
        {

            get
            {
                return (CCRMCallApprovalMasterDTO != null) ? CCRMCallApprovalMasterDTO.SerialNo : string.Empty;
            }
            set
            {
                CCRMCallApprovalMasterDTO.SerialNo = value;
            }
        }
        public string ModelNo
        {

            get
            {
                return (CCRMCallApprovalMasterDTO != null) ? CCRMCallApprovalMasterDTO.ModelNo : string.Empty;
            }
            set
            {
                CCRMCallApprovalMasterDTO.ModelNo = value;
            }
        }
        public string CallType
        {

            get
            {
                return (CCRMCallApprovalMasterDTO != null) ? CCRMCallApprovalMasterDTO.CallType : string.Empty;
            }
            set
            {
                CCRMCallApprovalMasterDTO.CallType = value;
            }
        }
        public string MIFName
        {

            get
            {
                return (CCRMCallApprovalMasterDTO != null) ? CCRMCallApprovalMasterDTO.MIFName : string.Empty;
            }
            set
            {
                CCRMCallApprovalMasterDTO.MIFName = value;
            }
        }
        public decimal CallCharges
        {

            get
            {
                return (CCRMCallApprovalMasterDTO != null) ? CCRMCallApprovalMasterDTO.CallCharges : new decimal();
            }
            set
            {
                CCRMCallApprovalMasterDTO.CallCharges = value;
            }
        }
        public bool NotApproved
        {

            get
            {
                return (CCRMCallApprovalMasterDTO != null) ? CCRMCallApprovalMasterDTO.NotApproved : new bool();
            }
            set
            {
                CCRMCallApprovalMasterDTO.NotApproved = value;
            }
        }
        public Nullable<int> CreatedBy
        {
            get
            {
                return (CCRMCallApprovalMasterDTO != null && CCRMCallApprovalMasterDTO.CreatedBy > 0) ? CCRMCallApprovalMasterDTO.CreatedBy : new int();
            }
            set
            {
                CCRMCallApprovalMasterDTO.CreatedBy = value;
            }
        }
        [Display(Name = "IsDeleted")]
        public Nullable<bool> IsDeleted
        {
            get
            {
                return (CCRMCallApprovalMasterDTO != null) ? CCRMCallApprovalMasterDTO.IsDeleted : false;
            }
            set
            {
                CCRMCallApprovalMasterDTO.IsDeleted = value;
            }
        }
        public Nullable<DateTime> CreatedDate
        {
            get
            {
                return (CCRMCallApprovalMasterDTO != null) ? CCRMCallApprovalMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                CCRMCallApprovalMasterDTO.CreatedDate = value;
            }
        }
        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (CCRMCallApprovalMasterDTO != null && CCRMCallApprovalMasterDTO.ModifiedBy.HasValue) ? CCRMCallApprovalMasterDTO.ModifiedBy : new int();
            }
            set
            {
                CCRMCallApprovalMasterDTO.ModifiedBy = value;
            }
        }
        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (CCRMCallApprovalMasterDTO != null && CCRMCallApprovalMasterDTO.ModifiedDate.HasValue) ? CCRMCallApprovalMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                CCRMCallApprovalMasterDTO.ModifiedDate = value;
            }
        }
        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (CCRMCallApprovalMasterDTO != null && CCRMCallApprovalMasterDTO.DeletedBy.HasValue) ? CCRMCallApprovalMasterDTO.DeletedBy : new int();
            }
            set
            {
                CCRMCallApprovalMasterDTO.DeletedBy = value;
            }
        }
        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (CCRMCallApprovalMasterDTO != null && CCRMCallApprovalMasterDTO.DeletedDate.HasValue) ? CCRMCallApprovalMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                CCRMCallApprovalMasterDTO.DeletedDate = value;
            }
        }
        public string CallTypeName
        {

            get
            {
                return (CCRMCallApprovalMasterDTO != null) ? CCRMCallApprovalMasterDTO.CallTypeName : string.Empty;
            }
            set
            {
                CCRMCallApprovalMasterDTO.CallTypeName = value;
            }
        }
        public string ItemDescription
        {

            get
            {
                return (CCRMCallApprovalMasterDTO != null) ? CCRMCallApprovalMasterDTO.ItemDescription : string.Empty;
            }
            set
            {
                CCRMCallApprovalMasterDTO.ItemDescription = value;
            }
        }
        public bool CustApproval
        {

            get
            {
                return (CCRMCallApprovalMasterDTO != null) ? CCRMCallApprovalMasterDTO.CustApproval : new bool();
            }
            set
            {
                CCRMCallApprovalMasterDTO.CustApproval = value;
            }
        }
    }
}
