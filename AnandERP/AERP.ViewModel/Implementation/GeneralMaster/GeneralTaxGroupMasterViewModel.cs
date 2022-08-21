
using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class GeneralTaxGroupMasterViewModel : IGeneralTaxGroupMasterViewModel
    {

        public GeneralTaxGroupMasterViewModel()
        {
            GeneralTaxGroupMasterDTO = new GeneralTaxGroupMaster();
           GetGeneralTaxMasterList = new List<GeneralTaxMaster>();
        }

        public GeneralTaxGroupMaster GeneralTaxGroupMasterDTO
        {
            get;
            set;
        }
        public List<GeneralTaxMaster> GetGeneralTaxMasterList { get; set; }
        
        public IEnumerable<SelectListItem> ListGeneralTaxMasterItems 
        {
            get
            {
                 return new SelectList(GetGeneralTaxMasterList, "ID", "TaxName");
            }
        }

        public string SelectedTaxMasterID
        {
            get;
            set;
        }
        public List<GeneralTaxGroupMaster> GeneralTaxGroupMasterList
        {
            get;
            set;
        } 
        public int ID
        {
            get
            {
                return (GeneralTaxGroupMasterDTO != null && GeneralTaxGroupMasterDTO.ID > 0) ? GeneralTaxGroupMasterDTO.ID : new int();
            }
            set
            {
                GeneralTaxGroupMasterDTO.ID = value;
            }
        }
        [Required(ErrorMessage = "Tax Name should not be blank.")]
        [Display(Name = "Tax Name")]
        public int TaxMasterID
        {
            get
            {
                return (GeneralTaxGroupMasterDTO != null && GeneralTaxGroupMasterDTO.TaxMasterID > 0) ? GeneralTaxGroupMasterDTO.TaxMasterID : new int();
            }
            set
            {
                GeneralTaxGroupMasterDTO.TaxMasterID = value;
            }
        }

        [Display(Name = "Tax Name")]
        public string TaxName
        {
            get
            {
                return (GeneralTaxGroupMasterDTO != null) ? GeneralTaxGroupMasterDTO.TaxName : string.Empty;
            }
            set
            {
                GeneralTaxGroupMasterDTO.TaxName = value;
            }
        }


        [Required(ErrorMessage = "Tax Group Name should not be blank.")]
        [Display(Name = "Tax Group Name")]
        public string TaxGroupName
        {
            get
            {
                return (GeneralTaxGroupMasterDTO != null) ? GeneralTaxGroupMasterDTO.TaxGroupName : string.Empty;
            }
            set
            {
                GeneralTaxGroupMasterDTO.TaxGroupName = value;
            }
        }
        public string SelectedTaxMaterIDs
        {
            get
            {
                return (GeneralTaxGroupMasterDTO != null) ? GeneralTaxGroupMasterDTO.SelectedTaxMaterIDs : string.Empty;
            }
            set
            {
                GeneralTaxGroupMasterDTO.SelectedTaxMaterIDs = value;
            }
        }
        
        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (GeneralTaxGroupMasterDTO != null) ? GeneralTaxGroupMasterDTO.IsDeleted : false;
            }
            set
            {
                GeneralTaxGroupMasterDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (GeneralTaxGroupMasterDTO != null && GeneralTaxGroupMasterDTO.CreatedBy > 0) ? GeneralTaxGroupMasterDTO.CreatedBy : new int();
            }
            set
            {
                GeneralTaxGroupMasterDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (GeneralTaxGroupMasterDTO != null) ? GeneralTaxGroupMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                GeneralTaxGroupMasterDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (GeneralTaxGroupMasterDTO != null && GeneralTaxGroupMasterDTO.ModifiedBy.HasValue) ? GeneralTaxGroupMasterDTO.ModifiedBy : new int();
            }
            set
            {
                GeneralTaxGroupMasterDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (GeneralTaxGroupMasterDTO != null && GeneralTaxGroupMasterDTO.ModifiedDate.HasValue) ? GeneralTaxGroupMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                GeneralTaxGroupMasterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (GeneralTaxGroupMasterDTO != null && GeneralTaxGroupMasterDTO.DeletedBy.HasValue) ? GeneralTaxGroupMasterDTO.DeletedBy : new int();
            }
            set
            {
                GeneralTaxGroupMasterDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (GeneralTaxGroupMasterDTO != null && GeneralTaxGroupMasterDTO.DeletedDate.HasValue) ? GeneralTaxGroupMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                GeneralTaxGroupMasterDTO.DeletedDate = value;
            }
        }

      

        public string errorMessage { get; set; }
    }
}

