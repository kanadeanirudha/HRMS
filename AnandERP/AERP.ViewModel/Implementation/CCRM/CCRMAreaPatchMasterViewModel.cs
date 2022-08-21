using System.Text;
using System.Threading.Tasks;
using AERP.DTO;
using System.ComponentModel.DataAnnotations;
using System;

namespace AERP.ViewModel
{
   public class CCRMAreaPatchMasterViewModel :ICCRMAreaPatchMasterViewModel
    {
        public CCRMAreaPatchMasterViewModel()
        {
            CCRMAreaPatchMasterDTO = new CCRMAreaPatchMaster();
        }
        public CCRMAreaPatchMaster CCRMAreaPatchMasterDTO
        {
            get;
            set;
        }
        public Int16 ID
        {
            get
            {
                return (CCRMAreaPatchMasterDTO != null && CCRMAreaPatchMasterDTO.ID > 0) ? CCRMAreaPatchMasterDTO.ID : new Int16();
            }
            set
            {
                CCRMAreaPatchMasterDTO.ID = value;
            }
        }
        [Display(Name = "Area Patch Name")]
        [Required(ErrorMessage = "Area Patch Name Required")]
        public string AreaPatchName
        {
            get
            {
                return (CCRMAreaPatchMasterDTO != null) ? CCRMAreaPatchMasterDTO.AreaPatchName : string.Empty;
            }
            set
            {
                CCRMAreaPatchMasterDTO.AreaPatchName = value;
            }
        }
        [Display(Name = "Employee Master ID")]
        public Int32 EmployeeMasterID
        {
            get
            {
                return (CCRMAreaPatchMasterDTO != null) ? CCRMAreaPatchMasterDTO.EmployeeMasterID : new Int32();
            }
            set
            {
                CCRMAreaPatchMasterDTO.EmployeeMasterID = value;
            }
        }
        public Int32 CCRMEngineersGroupMasterID
        {
            get
            {
                return (CCRMAreaPatchMasterDTO != null) ? CCRMAreaPatchMasterDTO.CCRMEngineersGroupMasterID : new Int32();
            }
            set
            {
                CCRMAreaPatchMasterDTO.CCRMEngineersGroupMasterID = value;
            }
        }
        [Display(Name = "Employee Name")]
        //[Required(ErrorMessage = "Employee Name Required")]
        public string EmployeeName
        {
            get
            {
                return (CCRMAreaPatchMasterDTO != null) ? CCRMAreaPatchMasterDTO.EmployeeName : string.Empty;
            }
            set
            {
                CCRMAreaPatchMasterDTO.EmployeeName = value;
            }
        }
        public string GroupName
        {
            get
            {
                return (CCRMAreaPatchMasterDTO != null) ? CCRMAreaPatchMasterDTO.GroupName : string.Empty;
            }
            set
            {
                CCRMAreaPatchMasterDTO.GroupName = value;
            }
        }
        public string EmployeeFirstName
        {
            get
            {
                return (CCRMAreaPatchMasterDTO != null) ? CCRMAreaPatchMasterDTO.EmployeeFirstName : string.Empty;
            }
            set
            {
                CCRMAreaPatchMasterDTO.EmployeeFirstName = value;
            }
        }
        public string EmployeeMiddleName
        {
            get
            {
                return (CCRMAreaPatchMasterDTO != null) ? CCRMAreaPatchMasterDTO.EmployeeMiddleName : string.Empty;
            }
            set
            {
                CCRMAreaPatchMasterDTO.EmployeeMiddleName = value;
            }
        }
        public string EmployeeLastName
        {
            get
            {
                return (CCRMAreaPatchMasterDTO != null) ? CCRMAreaPatchMasterDTO.EmployeeLastName : string.Empty;
            }
            set
            {
                CCRMAreaPatchMasterDTO.EmployeeLastName = value;
            }
        }
        public Nullable<int> CreatedBy
        {
            get
            {
                return (CCRMAreaPatchMasterDTO != null && CCRMAreaPatchMasterDTO.CreatedBy > 0) ? CCRMAreaPatchMasterDTO.CreatedBy : new int();
            }
            set
            {
                CCRMAreaPatchMasterDTO.CreatedBy = value;
            }
        }
        [Display(Name = "IsDeleted")]
        public Nullable<bool> IsDeleted
        {
            get
            {
                return (CCRMAreaPatchMasterDTO != null) ? CCRMAreaPatchMasterDTO.IsDeleted : false;
            }
            set
            {
                CCRMAreaPatchMasterDTO.IsDeleted = value;
            }
        }
        public Nullable<DateTime> CreatedDate
        {
            get
            {
                return (CCRMAreaPatchMasterDTO != null) ? CCRMAreaPatchMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                CCRMAreaPatchMasterDTO.CreatedDate = value;
            }
        }
        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (CCRMAreaPatchMasterDTO != null && CCRMAreaPatchMasterDTO.ModifiedBy.HasValue) ? CCRMAreaPatchMasterDTO.ModifiedBy : new int();
            }
            set
            {
                CCRMAreaPatchMasterDTO.ModifiedBy = value;
            }
        }
        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (CCRMAreaPatchMasterDTO != null && CCRMAreaPatchMasterDTO.ModifiedDate.HasValue) ? CCRMAreaPatchMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                CCRMAreaPatchMasterDTO.ModifiedDate = value;
            }
        }
        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (CCRMAreaPatchMasterDTO != null && CCRMAreaPatchMasterDTO.DeletedBy.HasValue) ? CCRMAreaPatchMasterDTO.DeletedBy : new int();
            }
            set
            {
                CCRMAreaPatchMasterDTO.DeletedBy = value;
            }
        }
        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (CCRMAreaPatchMasterDTO != null && CCRMAreaPatchMasterDTO.DeletedDate.HasValue) ? CCRMAreaPatchMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                CCRMAreaPatchMasterDTO.DeletedDate = value;
            }
        }
        public Nullable<bool> IsActive
        {
            get
            {
                return (CCRMAreaPatchMasterDTO != null) ? CCRMAreaPatchMasterDTO.IsDeleted : false;
            }
            set
            {
                CCRMAreaPatchMasterDTO.IsDeleted = value;
            }
        }
    }
}
