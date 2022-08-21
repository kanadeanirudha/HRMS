using AERP.Common;
using AERP.DTO;
using System;
using System.ComponentModel.DataAnnotations;


namespace AERP.ViewModel
{
    public class AdminRoleDetailsViewModel : IAdminRoleDetailsViewModel
    {
        public AdminRoleDetailsViewModel()
        {
            AdminRoleDetailsDTO = new AdminRoleDetails();
        }

        public AdminRoleDetails AdminRoleDetailsDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (AdminRoleDetailsDTO != null && AdminRoleDetailsDTO.ID > 0) ? AdminRoleDetailsDTO.ID : new int();
            }
            set
            {
                AdminRoleDetailsDTO.ID = value;
            }
        }

        public int AdminRoleMasterID
        {
            get
            {
                return (AdminRoleDetailsDTO != null && AdminRoleDetailsDTO.AdminRoleMasterID > 0) ? AdminRoleDetailsDTO.AdminRoleMasterID : new int();
            }
            set
            {
                AdminRoleDetailsDTO.AdminRoleMasterID = value;
            }
        }

        public int AdminRoleMasterIDOld
        {
            get
            {
                return (AdminRoleDetailsDTO != null && AdminRoleDetailsDTO.AdminRoleMasterIDOld > 0) ? AdminRoleDetailsDTO.AdminRoleMasterIDOld : new int();
            }
            set
            {
                AdminRoleDetailsDTO.AdminRoleMasterIDOld = value;
            }
        }

        [Display(Name = "AdminRoleCode")]
        public string AdminRoleCode
        {
            get
            {
                return (AdminRoleDetailsDTO != null) ? AdminRoleDetailsDTO.AdminRoleCode : string.Empty;
            }
            set
            {
                AdminRoleDetailsDTO.AdminRoleCode = value;
            }
        }

        [Display(Name = "IsActive")]
        public bool IsActive
        {
            get
            {
                return (AdminRoleDetailsDTO != null) ? AdminRoleDetailsDTO.IsActive : false;
            }
            set
            {
                AdminRoleDetailsDTO.IsActive = value;
            }
        }

        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (AdminRoleDetailsDTO != null) ? AdminRoleDetailsDTO.IsActive : false;
            }
            set
            {
                AdminRoleDetailsDTO.IsActive = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (AdminRoleDetailsDTO != null && AdminRoleDetailsDTO.CreatedBy > 0) ? AdminRoleDetailsDTO.CreatedBy : new int();
            }
            set
            {
                AdminRoleDetailsDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (AdminRoleDetailsDTO != null) ? AdminRoleDetailsDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                AdminRoleDetailsDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (AdminRoleDetailsDTO != null && AdminRoleDetailsDTO.ModifiedBy.HasValue) ? AdminRoleDetailsDTO.ModifiedBy : new int();
            }
            set
            {
                AdminRoleDetailsDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (AdminRoleDetailsDTO != null && AdminRoleDetailsDTO.ModifiedDate.HasValue) ? AdminRoleDetailsDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                AdminRoleDetailsDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (AdminRoleDetailsDTO != null && AdminRoleDetailsDTO.DeletedBy.HasValue) ? AdminRoleDetailsDTO.DeletedBy : new int();
            }
            set
            {
                AdminRoleDetailsDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (AdminRoleDetailsDTO != null && AdminRoleDetailsDTO.DeletedDate.HasValue) ? AdminRoleDetailsDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                AdminRoleDetailsDTO.DeletedDate = value;
            }
        }

    }
}
