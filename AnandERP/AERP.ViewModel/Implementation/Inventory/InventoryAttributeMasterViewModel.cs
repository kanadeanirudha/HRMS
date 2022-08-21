using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class InventoryAttributeMasterViewModel : IInventoryAttributeMasterViewModel
    {

        public InventoryAttributeMasterViewModel()
        {
            InventoryAttributeMasterDTO = new InventoryAttributeMaster();

        }



        public InventoryAttributeMaster InventoryAttributeMasterDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (InventoryAttributeMasterDTO != null) ? InventoryAttributeMasterDTO.ID : new int();
            }
            set
            {
                InventoryAttributeMasterDTO.ID = value;
            }
        }

        public int InventoryAttributeMasterID
        {
            get
            {
                return (InventoryAttributeMasterDTO != null) ? InventoryAttributeMasterDTO.InventoryAttributeMasterID : new int();
            }
            set
            {
                InventoryAttributeMasterDTO.InventoryAttributeMasterID = value;
            }
        }


        [Required(ErrorMessage = "Attribute Name should not be blank.")]
        [Display(Name = "Attribute Name")]
        public string AttributeName
        {
            get
            {
                return (InventoryAttributeMasterDTO != null) ? InventoryAttributeMasterDTO.AttributeName : string.Empty;
            }
            set
            {
                InventoryAttributeMasterDTO.AttributeName = value;
            }
        }

        [Required(ErrorMessage = "Attribute Description should not be blank.")]
        [Display(Name = "Attribute Description")]
        public string AttributeDescription
        {
            get
            {
                return (InventoryAttributeMasterDTO != null) ? InventoryAttributeMasterDTO.AttributeDescription : string.Empty;
            }
            set
            {
                InventoryAttributeMasterDTO.AttributeDescription = value;
            }
        }


        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (InventoryAttributeMasterDTO != null) ? InventoryAttributeMasterDTO.IsDeleted : false;
            }
            set
            {
                InventoryAttributeMasterDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (InventoryAttributeMasterDTO != null && InventoryAttributeMasterDTO.CreatedBy > 0) ? InventoryAttributeMasterDTO.CreatedBy : new int();
            }
            set
            {
                InventoryAttributeMasterDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (InventoryAttributeMasterDTO != null) ? InventoryAttributeMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                InventoryAttributeMasterDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int ModifiedBy
        {
            get
            {
                return (InventoryAttributeMasterDTO != null) ? InventoryAttributeMasterDTO.ModifiedBy : new int();
            }
            set
            {
                InventoryAttributeMasterDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime ModifiedDate
        {
            get
            {
                return (InventoryAttributeMasterDTO != null) ? InventoryAttributeMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                InventoryAttributeMasterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int DeletedBy
        {
            get
            {
                return (InventoryAttributeMasterDTO != null) ? InventoryAttributeMasterDTO.DeletedBy : new int();
            }
            set
            {
                InventoryAttributeMasterDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime DeletedDate
        {
            get
            {
                return (InventoryAttributeMasterDTO != null) ? InventoryAttributeMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                InventoryAttributeMasterDTO.DeletedDate = value;
            }
        }


        public string errorMessage { get; set; }






    }
}

