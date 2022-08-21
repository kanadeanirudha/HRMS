using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class GeneralAllocateSaleProcessUnitViewModel : IGeneralAllocateSaleProcessUnitViewModel
    {

        public GeneralAllocateSaleProcessUnitViewModel()
        {
            GeneralAllocateSaleProcessUnitDTO = new GeneralAllocateSaleProcessUnit();
            ListGetAdminRoleApplicableCentre = new List<AdminRoleApplicableDetails>();
        }
        public List<AdminRoleApplicableDetails> ListGetAdminRoleApplicableCentre
        {
            get;
            set;
        }
        public IEnumerable<SelectListItem> ListGetAdminRoleApplicableCentreItems
        {
            get
            {
                return new SelectList(ListGetAdminRoleApplicableCentre, "CentreCode", "CentreName");
            }
        }
        public string SelectedCentreCode
        {
            get;
            set;
        }
        public string SelectedCentreName
        {
            get;
            set;
        }
        public GeneralAllocateSaleProcessUnit GeneralAllocateSaleProcessUnitDTO
        {
            get;
            set;
        }

        public Int16 ID
        {
            get
            {
                return (GeneralAllocateSaleProcessUnitDTO != null && GeneralAllocateSaleProcessUnitDTO.ID > 0) ? GeneralAllocateSaleProcessUnitDTO.ID : new Int16();
            }
            set
            {
                GeneralAllocateSaleProcessUnitDTO.ID = value;
            }
        }
        public Int16 GeneralUnitsID
        {
            get
            {
                return (GeneralAllocateSaleProcessUnitDTO != null && GeneralAllocateSaleProcessUnitDTO.GeneralUnitsID > 0) ? GeneralAllocateSaleProcessUnitDTO.GeneralUnitsID : new Int16();
            }
            set
            {
                GeneralAllocateSaleProcessUnitDTO.GeneralUnitsID = value;
            }
        }
       
        public Int16 SalesUnitID
        {
            get
            {
                return (GeneralAllocateSaleProcessUnitDTO != null && GeneralAllocateSaleProcessUnitDTO.SalesUnitID > 0) ? GeneralAllocateSaleProcessUnitDTO.SalesUnitID : new Int16();
            }
            set
            {
                GeneralAllocateSaleProcessUnitDTO.SalesUnitID = value;
            }
        }
   
        public Int16 SalesUnitProssessID
        {
            get
            {
                return (GeneralAllocateSaleProcessUnitDTO != null && GeneralAllocateSaleProcessUnitDTO.SalesUnitProssessID > 0) ? GeneralAllocateSaleProcessUnitDTO.SalesUnitProssessID : new Int16();
            }
            set
            {
                GeneralAllocateSaleProcessUnitDTO.SalesUnitProssessID = value;
            }
        }
        [Display(Name = " Sales Unit Name")]
        public string UnitName
        {
            get
            {
                return (GeneralAllocateSaleProcessUnitDTO != null) ? GeneralAllocateSaleProcessUnitDTO.UnitName : string.Empty;
            }
            set
            {
                GeneralAllocateSaleProcessUnitDTO.UnitName = value;
            }
        }
        public string CentreCode
        {
            get
            {
                return (GeneralAllocateSaleProcessUnitDTO != null) ? GeneralAllocateSaleProcessUnitDTO.CentreCode : string.Empty;
            }
            set
            {
                GeneralAllocateSaleProcessUnitDTO.CentreCode = value;
            }
        }
        [Display(Name = " Process Unit Name")]
        public string ProcessUnitName
        {
            get
            {
                return (GeneralAllocateSaleProcessUnitDTO != null) ? GeneralAllocateSaleProcessUnitDTO.ProcessUnitName : string.Empty;
            }
            set
            {
                GeneralAllocateSaleProcessUnitDTO.ProcessUnitName = value;
            }
        }
          
         [Display(Name = " Allocated Upto Date")]
        public string AllocatedUptoDate
        {
            get
            {
                return (GeneralAllocateSaleProcessUnitDTO != null) ? GeneralAllocateSaleProcessUnitDTO.AllocatedUptoDate : string.Empty;
            }
            set
            {
                GeneralAllocateSaleProcessUnitDTO.AllocatedUptoDate = value;
            }
        }
        [Required(ErrorMessage = "Allocated From Date should not be blank.")]
        [Display(Name = " Allocated From Date")]
        public string AllocatedFromDate
        {
            get
            {
                return (GeneralAllocateSaleProcessUnitDTO != null) ? GeneralAllocateSaleProcessUnitDTO.AllocatedFromDate : string.Empty;
            }
            set
            {
                GeneralAllocateSaleProcessUnitDTO.AllocatedFromDate = value;
            }
        }
        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (GeneralAllocateSaleProcessUnitDTO != null) ? GeneralAllocateSaleProcessUnitDTO.IsDeleted : false;
            }
            set
            {
                GeneralAllocateSaleProcessUnitDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (GeneralAllocateSaleProcessUnitDTO != null && GeneralAllocateSaleProcessUnitDTO.CreatedBy > 0) ? GeneralAllocateSaleProcessUnitDTO.CreatedBy : new int();
            }
            set
            {
                GeneralAllocateSaleProcessUnitDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (GeneralAllocateSaleProcessUnitDTO != null) ? GeneralAllocateSaleProcessUnitDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                GeneralAllocateSaleProcessUnitDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int ModifiedBy
        {
            get
            {
                return (GeneralAllocateSaleProcessUnitDTO != null) ? GeneralAllocateSaleProcessUnitDTO.ModifiedBy : new int();
            }
            set
            {
                GeneralAllocateSaleProcessUnitDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime ModifiedDate
        {
            get
            {
                return (GeneralAllocateSaleProcessUnitDTO != null) ? GeneralAllocateSaleProcessUnitDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                GeneralAllocateSaleProcessUnitDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int DeletedBy
        {
            get
            {
                return (GeneralAllocateSaleProcessUnitDTO != null) ? GeneralAllocateSaleProcessUnitDTO.DeletedBy : new int();
            }
            set
            {
                GeneralAllocateSaleProcessUnitDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime DeletedDate
        {
            get
            {
                return (GeneralAllocateSaleProcessUnitDTO != null) ? GeneralAllocateSaleProcessUnitDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                GeneralAllocateSaleProcessUnitDTO.DeletedDate = value;
            }
        }


        public string errorMessage { get; set; }

       
    }
}

