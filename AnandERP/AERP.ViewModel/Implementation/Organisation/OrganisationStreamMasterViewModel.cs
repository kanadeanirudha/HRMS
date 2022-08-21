using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{

    public class OrganisationStreamMasterBaseViewModel : IOrganisationStreamMasterBaseViewModel
    {
        public OrganisationStreamMasterBaseViewModel()
        {
            ListOrganisationStreamMaster = new List<OrganisationStreamMaster>();

            ListOrganisationDivisionMaster = new List<OrganisationDivisionMaster>();

        }

        public List<OrganisationStreamMaster> ListOrganisationStreamMaster
        {
            get;
            set;
        }

        public List<OrganisationDivisionMaster> ListOrganisationDivisionMaster
        {
            get;
            set;
        }

        public string SelectedDivisionID
        {
            get;
            set;
        }

        public IEnumerable<SelectListItem> ListOrganisationDivisionMasterItems
        {
            get
            {
                return new SelectList(ListOrganisationDivisionMaster, "DivisionID", "DivisionDescription");
            }
        }

    }


    public class OrganisationStreamMasterViewModel : IOrganisationStreamMasterViewModel
    {

        public OrganisationStreamMasterViewModel()
        {
            OrganisationStreamMasterDTO = new OrganisationStreamMaster();
        }

        public OrganisationStreamMaster OrganisationStreamMasterDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (OrganisationStreamMasterDTO != null && OrganisationStreamMasterDTO.ID > 0) ? OrganisationStreamMasterDTO.ID : new int();
            }
            set
            {
                OrganisationStreamMasterDTO.ID = value;
            }
        }
         
        public int DivisionID
        {
            get
            {
                return (OrganisationStreamMasterDTO != null && OrganisationStreamMasterDTO.DivisionID > 0) ? OrganisationStreamMasterDTO.DivisionID : new int();
            }
            set
            {
                OrganisationStreamMasterDTO.DivisionID = value;
            }
        }

         [Display(Name = "DisplayName_StreamDescription", ResourceType = typeof(AMS.Common.Resources))]
         [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_StreamDescriptionRequired")]
        public string StreamDescription
        {
            get
            {
                return (OrganisationStreamMasterDTO != null) ? OrganisationStreamMasterDTO.StreamDescription : string.Empty;
            }
            set
            {
                OrganisationStreamMasterDTO.StreamDescription = value;
            }
        }

         [Display(Name = "DisplayName_StreamShortCode", ResourceType = typeof(AMS.Common.Resources))]
         [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_StreamShortCodeRequired")]
        public string StreamShortCode
        {
            get
            {
                return (OrganisationStreamMasterDTO != null) ? OrganisationStreamMasterDTO.StreamShortCode : string.Empty;
            }
            set
            {
                OrganisationStreamMasterDTO.StreamShortCode = value;
            }
        }

         [Display(Name = "DisplayName_PrintShortCode", ResourceType = typeof(AMS.Common.Resources))]
         [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_PrintShortCodeRequired")]
        public string PrintShortCode
        {
            get
            {
                return (OrganisationStreamMasterDTO != null) ? OrganisationStreamMasterDTO.PrintShortCode : string.Empty;
            }
            set
            {
                OrganisationStreamMasterDTO.PrintShortCode = value;
            }
        }

         public bool IsUserDefined 
        {
            get
            {
                return (OrganisationStreamMasterDTO != null) ? OrganisationStreamMasterDTO.IsUserDefined : false;
            }
            set
            {
                OrganisationStreamMasterDTO.IsUserDefined = value;
            }
        }

        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (OrganisationStreamMasterDTO != null) ? OrganisationStreamMasterDTO.IsDeleted : false;
            }
            set
            {
                OrganisationStreamMasterDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (OrganisationStreamMasterDTO != null && OrganisationStreamMasterDTO.CreatedBy > 0) ? OrganisationStreamMasterDTO.CreatedBy : new int();
            }
            set
            {
                OrganisationStreamMasterDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (OrganisationStreamMasterDTO != null) ? OrganisationStreamMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                OrganisationStreamMasterDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (OrganisationStreamMasterDTO != null && OrganisationStreamMasterDTO.ModifiedBy.HasValue) ? OrganisationStreamMasterDTO.ModifiedBy : new int();
            }
            set
            {
                OrganisationStreamMasterDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (OrganisationStreamMasterDTO != null && OrganisationStreamMasterDTO.ModifiedDate.HasValue) ? OrganisationStreamMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                OrganisationStreamMasterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (OrganisationStreamMasterDTO != null && OrganisationStreamMasterDTO.DeletedBy.HasValue) ? OrganisationStreamMasterDTO.DeletedBy : new int();
            }
            set
            {
                OrganisationStreamMasterDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (OrganisationStreamMasterDTO != null && OrganisationStreamMasterDTO.DeletedDate.HasValue) ? OrganisationStreamMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                OrganisationStreamMasterDTO.DeletedDate = value;
            }
        }

        [Display(Name = "DisplayName_SelectedDivisionID", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_SelectedDivisionIDRequired")]
        public string SelectedDivisionID
        {
            get;
            set;
        }
    }
}