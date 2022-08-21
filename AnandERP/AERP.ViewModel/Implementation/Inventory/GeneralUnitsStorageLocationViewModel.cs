using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class GeneralUnitStorageLocationViewModel : IGeneralUnitsStorageLocationViewModel
    {

        public GeneralUnitStorageLocationViewModel()
        {
            GeneralUnitStorageLocationDTO = new GeneralUnitsStorageLocation();

        }

        public GeneralUnitsStorageLocation GeneralUnitsStorageLocationDTO { get; set; }

        public GeneralUnitsStorageLocation GeneralUnitStorageLocationDTO
        {
            get;
            set;
        }

        public Int16 ID
        {
            get
            {
                return (GeneralUnitStorageLocationDTO != null && GeneralUnitStorageLocationDTO.ID > 0) ? GeneralUnitStorageLocationDTO.ID : new Int16();
            }
            set
            {
                GeneralUnitStorageLocationDTO.ID = value;
            }
        }
        public Int16 GeneralUnitsID 
        {
            get
            {
                return (GeneralUnitStorageLocationDTO != null) ? GeneralUnitStorageLocationDTO.GeneralUnitsID : new Int16();
            }
            set
            {
                GeneralUnitStorageLocationDTO.GeneralUnitsID = value;
            }
        }

        
       // [Required(ErrorMessage = "Related with should not be blank.")]
    //    [Display(Name = "RelatedWith")]
        public int InventoryLocationMasterID
        {
            get
            {
                return (GeneralUnitStorageLocationDTO != null) ? GeneralUnitStorageLocationDTO.InventoryLocationMasterID : new int();
            }
            set
            {
                GeneralUnitStorageLocationDTO.InventoryLocationMasterID = value;
            }
        }
    
        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (GeneralUnitStorageLocationDTO != null) ? GeneralUnitStorageLocationDTO.IsDeleted : false;
            }
            set
            {
                GeneralUnitStorageLocationDTO.IsDeleted = value;
            }
        }
        public int IsDefaultCount
        {
            get
            {
                return (GeneralUnitStorageLocationDTO != null && GeneralUnitStorageLocationDTO.IsDefaultCount > 0) ? GeneralUnitStorageLocationDTO.IsDefaultCount : new int();
            }
            set
            {
                GeneralUnitStorageLocationDTO.IsDefaultCount = value;
            }
        }
        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (GeneralUnitStorageLocationDTO != null && GeneralUnitStorageLocationDTO.CreatedBy > 0) ? GeneralUnitStorageLocationDTO.CreatedBy : new int();
            }
            set
            {
                GeneralUnitStorageLocationDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (GeneralUnitStorageLocationDTO != null) ? GeneralUnitStorageLocationDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                GeneralUnitStorageLocationDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int ModifiedBy
        {
            get
            {
                return (GeneralUnitStorageLocationDTO != null) ? GeneralUnitStorageLocationDTO.ModifiedBy : new int();
            }
            set
            {
                GeneralUnitStorageLocationDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime ModifiedDate
        {
            get
            {
                return (GeneralUnitStorageLocationDTO != null) ? GeneralUnitStorageLocationDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                GeneralUnitStorageLocationDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int DeletedBy
        {
            get
            {
                return (GeneralUnitStorageLocationDTO != null) ? GeneralUnitStorageLocationDTO.DeletedBy : new int();
            }
            set
            {
                GeneralUnitStorageLocationDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime DeletedDate
        {
            get
            {
                return (GeneralUnitStorageLocationDTO != null) ? GeneralUnitStorageLocationDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                GeneralUnitStorageLocationDTO.DeletedDate = value;
            }
        }


        public string errorMessage { get; set; }


        public string XmlString
        {
            get
            {
                return (GeneralUnitStorageLocationDTO != null) ? GeneralUnitStorageLocationDTO.XmlString : string.Empty;
            }
            set
            {
                GeneralUnitStorageLocationDTO.XmlString = value;
            }
        }

        [Required(ErrorMessage = "Location Name should not be blank.")]
           [Display(Name = "Location Name")]
        public string LocationName
        {

            get
            {
                return (GeneralUnitStorageLocationDTO != null) ? GeneralUnitStorageLocationDTO.LocationName : string.Empty;
            }
            set
            {
                GeneralUnitStorageLocationDTO.LocationName = value;
            }
        }
         [Display(Name = "Unit Name")]
        public string UnitName 
        { 
            get
            {
                return (GeneralUnitStorageLocationDTO != null) ? GeneralUnitStorageLocationDTO.UnitName : string.Empty;

            }

            set
            {
                GeneralUnitStorageLocationDTO.UnitName = value;
            }
        
        }
        [Display(Name = "Is Default")]
        public bool IsDefault 
        {
            get
            {
                return (GeneralUnitStorageLocationDTO != null) ? GeneralUnitStorageLocationDTO.IsDefault : false;
            }
            set
            {
                GeneralUnitStorageLocationDTO.IsDefault = value;
            }
        
        }
    }
}

