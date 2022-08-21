using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{
    public class OrganisationDirectorMasterViewModel : IOrganisationDirectorMasterViewModel
    {
        public OrganisationDirectorMasterViewModel()
        {
            OrganisationDirectorMasterDTO = new OrganisationDirectorMaster();
            ListGetAdminRoleApplicableCentre = new List<AdminRoleApplicableDetails>();
            ListOrganisationStudyCentreMaster = new List<OrganisationStudyCentreMaster>();
        }

        public OrganisationDirectorMaster OrganisationDirectorMasterDTO { get; set; }

        public List<OrganisationStudyCentreMaster> ListOrganisationStudyCentreMaster
        {
            get;
            set;
        }
        public List<AdminRoleApplicableDetails> ListGetAdminRoleApplicableCentre
        {
            get;
            set;
        }
        public IEnumerable<SelectListItem> ListOrganisationStudyCentreMasterItems
        {
            get
            {
                return new SelectList(ListOrganisationStudyCentreMaster, "CentreCode", "CentreName");
            }
        }
        public IEnumerable<SelectListItem> ListGetAdminRoleApplicableCentreItems
        {
            get
            {
                return new SelectList(ListGetAdminRoleApplicableCentre, "CentreCode", "CentreName");
            }
        }

        //------------------------------------------------Model Properties-----------------------------------------------------------------------------------------------//
        public int ID
        {
            get
            {
                return (OrganisationDirectorMasterDTO != null && OrganisationDirectorMasterDTO.ID > 0) ? OrganisationDirectorMasterDTO.ID : new int();
            }
            set
            {
                OrganisationDirectorMasterDTO.ID = value;
            }
        }


        [Required(ErrorMessage = "Organisation members id should not be blank.")]
        public int OrganisationMembersMasterID
        {
            get
            {
                return (OrganisationDirectorMasterDTO != null && OrganisationDirectorMasterDTO.OrganisationMembersMasterID > 0) ? OrganisationDirectorMasterDTO.OrganisationMembersMasterID : new int();
            }
            set
            {
                OrganisationDirectorMasterDTO.OrganisationMembersMasterID = value;
            }
        }

        [Display(Name="Is Life Time Director")]
        [Required(ErrorMessage = "IsLifeTimeDirector should not be blank.")]
        public bool IsLifeTimeDirector
        {
            get
            {
                return OrganisationDirectorMasterDTO != null ? OrganisationDirectorMasterDTO.IsLifeTimeDirector : false;
            }
            set
            {
                OrganisationDirectorMasterDTO.IsLifeTimeDirector = value;
            }
        }

        [Display(Name = "Designation ID")]
        [Required(ErrorMessage = "Designation should not be blank.")]
        public int DesignationID
        {
            get
            {
                return (OrganisationDirectorMasterDTO != null && OrganisationDirectorMasterDTO.DesignationID > 0) ? OrganisationDirectorMasterDTO.DesignationID : new int();
            }
            set
            {
                OrganisationDirectorMasterDTO.DesignationID = value;
            }
        }

        [Display(Name="Joining Date")]
        [Required(ErrorMessage = "Joining Date should not be blank.")]
        public string JoiningDate
        {
            get
            {
                return OrganisationDirectorMasterDTO.JoiningDate != "" ? OrganisationDirectorMasterDTO.JoiningDate : string.Empty;
            }
            set
            {
                OrganisationDirectorMasterDTO.JoiningDate = value;
            }
        }

        [Display(Name="Leaving Date")]
        [Required(ErrorMessage = "Leaving Date should not be blank.")]
        public string LeavingDate
        {
            get
            {
                return OrganisationDirectorMasterDTO.LeavingDate != "" ? OrganisationDirectorMasterDTO.LeavingDate : string.Empty;
            }
            set
            {
                OrganisationDirectorMasterDTO.LeavingDate = value;
            }
        }

        [Display(Name="Print Sequence")]
        [Required(ErrorMessage = "Print Sequence should not be blank.")]
        public int PrintingSeqOrder
        {
            get
            {
                return (OrganisationDirectorMasterDTO != null && OrganisationDirectorMasterDTO.PrintingSeqOrder > 0) ? OrganisationDirectorMasterDTO.PrintingSeqOrder : new int();
            }
            set
            {
                OrganisationDirectorMasterDTO.PrintingSeqOrder = value;
            }
        }

        [Display(Name = "Centre Code")]
        [Required(ErrorMessage = "Centre Code should not be blank.")]
        public string CentreCode
        {
            get
            {
                return OrganisationDirectorMasterDTO.CentreCode != "" ? OrganisationDirectorMasterDTO.CentreCode : string.Empty;
            }
            set
            {
                OrganisationDirectorMasterDTO.CentreCode = value;
            }
        }

        [Display(Name="Is Current Director")]
        public bool IsCurrentDirector
        {
            get
            {
                return OrganisationDirectorMasterDTO.IsCurrentDirector != null ? OrganisationDirectorMasterDTO.IsCurrentDirector : false;
            }
            set
            {
                OrganisationDirectorMasterDTO.IsCurrentDirector = value;
            }
        }
        
        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return OrganisationDirectorMasterDTO.IsDeleted != null ? OrganisationDirectorMasterDTO.IsDeleted : false;
            }
            set
            {
                OrganisationDirectorMasterDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (OrganisationDirectorMasterDTO.CreatedBy != null && OrganisationDirectorMasterDTO.CreatedBy > 0) ? OrganisationDirectorMasterDTO.CreatedBy : new int();
            }
            set
            {
                OrganisationDirectorMasterDTO.CreatedBy = value;
            }
        }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate
        {
            get
            {
                return (OrganisationDirectorMasterDTO.CreatedDate != null) ? OrganisationDirectorMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                OrganisationDirectorMasterDTO.CreatedDate = value;
            }
        }

        [Display(Name = "Modified By")]
        public Nullable<int> ModifiedBy
        {
            get
            {
                return OrganisationDirectorMasterDTO.ModifiedBy != null ? OrganisationDirectorMasterDTO.ModifiedBy : new int();
            }
            set
            {
                OrganisationDirectorMasterDTO.ModifiedBy = value;
            }
        }

        public Nullable<DateTime> ModifiedDate
        {
            get
            {
                return (OrganisationDirectorMasterDTO.ModifiedDate != null && OrganisationDirectorMasterDTO.ModifiedDate.HasValue) ? OrganisationDirectorMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                OrganisationDirectorMasterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "Delete By")]
        public Nullable<int> DeletedBy
        {
            get
            {
                return (OrganisationDirectorMasterDTO != null && OrganisationDirectorMasterDTO.DeletedBy > 0) ? OrganisationDirectorMasterDTO.DeletedBy : new int();
            }
            set
            {
                OrganisationDirectorMasterDTO.DeletedBy = value;
            }
        }

        [Display(Name = "Delete Date")]
        public Nullable<DateTime> DeletedDate
        {
            get
            {
                return (OrganisationDirectorMasterDTO.DeletedDate != null && OrganisationDirectorMasterDTO.DeletedDate.HasValue) ? OrganisationDirectorMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                OrganisationDirectorMasterDTO.DeletedDate = value;
            }
        }

        public int PersonID
        {
            get
            {
                return (OrganisationDirectorMasterDTO != null && OrganisationDirectorMasterDTO.PersonID > 0) ? OrganisationDirectorMasterDTO.PersonID : new int();
            }
            set
            {
                OrganisationDirectorMasterDTO.PersonID = value;
            }
        }

        public string PersonType
        {
            get
            {
                return OrganisationDirectorMasterDTO.PersonType != null ? OrganisationDirectorMasterDTO.PersonType : string.Empty;
            }
            set
            {
                OrganisationDirectorMasterDTO.PersonType = value;
            }
        }

        [Display(Name="Director Name")]
        [Required(ErrorMessage = "Director name should not be blank.")]
        public string FirstName
        {
            get
            {
                return OrganisationDirectorMasterDTO.FirstName != null ? OrganisationDirectorMasterDTO.FirstName : string.Empty;
            }
            set
            {
                OrganisationDirectorMasterDTO.FirstName = value;
            }
        }

        public string MiddleName
        {
            get
            {
                return OrganisationDirectorMasterDTO.MiddleName != null ? OrganisationDirectorMasterDTO.MiddleName : string.Empty;
            }
            set
            {
                OrganisationDirectorMasterDTO.MiddleName = value;
            }
        }

        public string LastName
        {
            get
            {
                return OrganisationDirectorMasterDTO.LastName != null ? OrganisationDirectorMasterDTO.LastName : string.Empty;
            }
            set
            {
                OrganisationDirectorMasterDTO.LastName = value;
            }
        }


        //----------------------Extra Fields-----------------//

        public string EntityLevel
        {
            get
            {
                return OrganisationDirectorMasterDTO.EntityLevel != null ? OrganisationDirectorMasterDTO.EntityLevel : string.Empty;
            }
            set
            {
                OrganisationDirectorMasterDTO.EntityLevel = value;
            }
        }

        public string CentreName
        {
            get
            {
                return OrganisationDirectorMasterDTO.CentreName != null ? OrganisationDirectorMasterDTO.CentreName : string.Empty;
            }
            set
            {
                OrganisationDirectorMasterDTO.CentreName = value;
            }
        }

       
        public bool IsActive
        {
            get
            {
                return OrganisationDirectorMasterDTO.IsActive != null ? OrganisationDirectorMasterDTO.IsActive : false;
            }
            set
            {
                OrganisationDirectorMasterDTO.IsActive = value;
            }
        }

        public string Designation
        {
            get
            {
                return OrganisationDirectorMasterDTO.Designation != null ? OrganisationDirectorMasterDTO.Designation : string.Empty;
            }
            set
            {
                OrganisationDirectorMasterDTO.Designation = value;
            }
        }

        public string errorMessage
        {
            get
            {
                return OrganisationDirectorMasterDTO.ErrorMessage != null ? OrganisationDirectorMasterDTO.ErrorMessage : string.Empty;
            }
            set
            {
                OrganisationDirectorMasterDTO.ErrorMessage = value;
            }
        }

    }
}
