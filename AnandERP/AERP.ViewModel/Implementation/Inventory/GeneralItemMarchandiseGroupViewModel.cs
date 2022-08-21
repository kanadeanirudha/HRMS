using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class GeneralItemMarchandiseGroupViewModel : IGeneralItemMarchandiseGroupViewModel
    {

        public GeneralItemMarchandiseGroupViewModel()
        {
            GeneralItemMarchandiseGroupDTO = new GeneralItemMarchandiseGroup();
           
        }
       
       
      
        public GeneralItemMarchandiseGroup GeneralItemMarchandiseGroupDTO
        {
            get;
            set;
        }

        public Int16 ID
        {
            get
            {
                return (GeneralItemMarchandiseGroupDTO != null && GeneralItemMarchandiseGroupDTO.ID > 0) ? GeneralItemMarchandiseGroupDTO.ID : new Int16();
            }
            set
            {
                GeneralItemMarchandiseGroupDTO.ID = value;
            }
        }

        [Required(ErrorMessage = "Merchandise Group Description should not be blank.")]
        [Display(Name = "Merchandise Group Description")]
        public string GroupDescription
        {
            get
            {
                return (GeneralItemMarchandiseGroupDTO != null) ? GeneralItemMarchandiseGroupDTO.GroupDescription : string.Empty;
            }
            set
            {
                GeneralItemMarchandiseGroupDTO.GroupDescription = value;
            }
        }

        [Required(ErrorMessage = "Merchandise Group Code should not be blank.")]
        [Display(Name = "Merchandise Group Code")]
        public string MarchandiseGroupCode
        {
            get
            {
                return (GeneralItemMarchandiseGroupDTO != null) ? GeneralItemMarchandiseGroupDTO.MarchandiseGroupCode : string.Empty;
            }
            set
            {
                GeneralItemMarchandiseGroupDTO.MarchandiseGroupCode = value;
            }
        }
       
      
        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (GeneralItemMarchandiseGroupDTO != null) ? GeneralItemMarchandiseGroupDTO.IsDeleted : false;
            }
            set
            {
                GeneralItemMarchandiseGroupDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (GeneralItemMarchandiseGroupDTO != null && GeneralItemMarchandiseGroupDTO.CreatedBy > 0) ? GeneralItemMarchandiseGroupDTO.CreatedBy : new int();
            }
            set
            {
                GeneralItemMarchandiseGroupDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (GeneralItemMarchandiseGroupDTO != null) ? GeneralItemMarchandiseGroupDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                GeneralItemMarchandiseGroupDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int ModifiedBy
        {
            get
            {
                return (GeneralItemMarchandiseGroupDTO != null) ? GeneralItemMarchandiseGroupDTO.ModifiedBy : new int();
            }
            set
            {
                GeneralItemMarchandiseGroupDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime ModifiedDate
        {
            get
            {
                return (GeneralItemMarchandiseGroupDTO != null) ? GeneralItemMarchandiseGroupDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                GeneralItemMarchandiseGroupDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int DeletedBy
        {
            get
            {
                return (GeneralItemMarchandiseGroupDTO != null) ? GeneralItemMarchandiseGroupDTO.DeletedBy : new int();
            }
            set
            {
                GeneralItemMarchandiseGroupDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime DeletedDate
        {
            get
            {
                return (GeneralItemMarchandiseGroupDTO != null) ? GeneralItemMarchandiseGroupDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                GeneralItemMarchandiseGroupDTO.DeletedDate = value;
            }
        }


        public string errorMessage { get; set; }

      
        
       
        
       
    }
}

