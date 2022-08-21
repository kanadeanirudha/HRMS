using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{

    public class GeneralEducationMasterBaseViewModel : IGeneralEducationMasterBaseViewModel
    {
        public GeneralEducationMasterBaseViewModel()
        {
            ListGeneralEducationMaster = new List<GeneralEducationMaster>();

            ListGeneralEducationTypeMaster = new List<GeneralEducationTypeMaster>();


        }

        public List<GeneralEducationMaster> ListGeneralEducationMaster
        {
            get;
            set;
        }

        public List<GeneralEducationTypeMaster> ListGeneralEducationTypeMaster
        {
            get;
            set;
        }
        
        public string SelectedEducationTypeID
        {
            get;
            set;
        }

       


        public IEnumerable<SelectListItem> ListGeneralRegionMasterItems
        {
            get
            {
                return new SelectList(ListGeneralEducationTypeMaster, "EducationTypeID", "Description");
            }
        }      

    }


    public class GeneralEducationMasterViewModel : IGeneralEducationMasterViewModel
    {
        public GeneralEducationMasterViewModel()
        {
            GeneralEducationMasterDTO = new GeneralEducationMaster();
        }

        public GeneralEducationMaster GeneralEducationMasterDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (GeneralEducationMasterDTO != null && GeneralEducationMasterDTO.ID > 0) ? GeneralEducationMasterDTO.ID : new int();
            }
            set
            {
                GeneralEducationMasterDTO.ID = value;
            }
        }
        [Display(Name = "Qualification Description")]
        [Required(ErrorMessage = "Qualification Description Required")]
        public string Description
        {
            get
            {
                return (GeneralEducationMasterDTO != null) ? GeneralEducationMasterDTO.Description : string.Empty;
            }
            set
            {
                GeneralEducationMasterDTO.Description = value;
            }
        }
        
        //[Required(ErrorMessage ="Education Unit Required")]
        public string Unit
        {
            get
            {
                return (GeneralEducationMasterDTO != null) ? GeneralEducationMasterDTO.Unit : string.Empty;
            }
            set
            {
                GeneralEducationMasterDTO.Unit = value;
            }
        }

        [Display(Name = "Qualification Type")]
        [Required(ErrorMessage ="Qualification Type Required")]
        public int EducationTypeID
        {
            get
            {
                return (GeneralEducationMasterDTO != null) ? GeneralEducationMasterDTO.EducationTypeID : new int();
            }
            set
            {
                GeneralEducationMasterDTO.EducationTypeID = value;
            }
        }

        [Display(Name = "Number Of Years")]
        [Required(ErrorMessage ="Number Of Years Required")]
        public int NumberOfYears
        {
            get
            {
                return (GeneralEducationMasterDTO != null && GeneralEducationMasterDTO.NumberOfYears > 0) ? GeneralEducationMasterDTO.NumberOfYears : new int();
            }
            set
            {
                GeneralEducationMasterDTO.NumberOfYears = value;
            }
        }

       

        [Display(Name = "IsDeleted")]
          public Nullable<bool> IsDeleted
        {
            get
            {
                return (GeneralEducationMasterDTO != null) ? GeneralEducationMasterDTO.IsDeleted : false;
            }
            set
            {
                GeneralEducationMasterDTO.IsDeleted = value;
            }
        }
        public bool IsUserDefined
        {
            get
            {
                return (GeneralEducationMasterDTO != null) ? GeneralEducationMasterDTO.IsUserDefined : false;
            }
            set
            {
                GeneralEducationMasterDTO.IsUserDefined = value;
            }
        }
        [Display(Name = "CreatedBy")]
        public Nullable<int> CreatedBy
        {
            get
            {
                return (GeneralEducationMasterDTO != null && GeneralEducationMasterDTO.CreatedBy > 0) ? GeneralEducationMasterDTO.CreatedBy : new int();
            }
            set
            {
                GeneralEducationMasterDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public Nullable<DateTime> CreatedDate
        {
            get
            {
                return (GeneralEducationMasterDTO != null) ? GeneralEducationMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                GeneralEducationMasterDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (GeneralEducationMasterDTO != null && GeneralEducationMasterDTO.ModifiedBy.HasValue) ? GeneralEducationMasterDTO.ModifiedBy : new int();
            }
            set
            {
                GeneralEducationMasterDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (GeneralEducationMasterDTO != null && GeneralEducationMasterDTO.ModifiedDate.HasValue) ? GeneralEducationMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                GeneralEducationMasterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (GeneralEducationMasterDTO != null && GeneralEducationMasterDTO.DeletedBy.HasValue) ? GeneralEducationMasterDTO.DeletedBy : new int();
            }
            set
            {
                GeneralEducationMasterDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (GeneralEducationMasterDTO != null && GeneralEducationMasterDTO.DeletedDate.HasValue) ? GeneralEducationMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                GeneralEducationMasterDTO.DeletedDate = value;
            }
        }

        public string SelectedEducationTypeID
        {
            get;
            set;
        }

    }
}
