using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class GeneralShipperMasterViewModel : IGeneralShipperMasterViewModel
    {

        public GeneralShipperMasterViewModel()
        {
            GeneralShipperMasterDTO = new GeneralShipperMaster();

        }



        public GeneralShipperMaster GeneralShipperMasterDTO
        {
            get;
            set;
        }

        public Int16 ID
        {
            get
            {
                return (GeneralShipperMasterDTO != null && GeneralShipperMasterDTO.ID > 0) ? GeneralShipperMasterDTO.ID : new Int16();
            }
            set
            {
                GeneralShipperMasterDTO.ID = value;
            }
        }

        [Display(Name = "Company Name")]
        public string CompanyName
        {
            get
            {
                return (GeneralShipperMasterDTO != null) ? GeneralShipperMasterDTO.CompanyName : string.Empty;
            }
            set
            {
                GeneralShipperMasterDTO.CompanyName = value;
            }
        }
        [Display(Name = "Email")]
        public string Email
        {
            get
            {
                return (GeneralShipperMasterDTO != null) ? GeneralShipperMasterDTO.Email : string.Empty;
            }
            set
            {
                GeneralShipperMasterDTO.Email = value;
            }
        }
        [Display(Name = "Mobile Number")]
        public string MobileNumber
        {
            get
            {
                return (GeneralShipperMasterDTO != null) ? GeneralShipperMasterDTO.MobileNumber : string.Empty;
            }
            set
            {
                GeneralShipperMasterDTO.MobileNumber = value;
            }
        }
        [Display(Name = "Phone Number")]
        public string PhoneNumber
        {
            get
            {
                return (GeneralShipperMasterDTO != null) ? GeneralShipperMasterDTO.PhoneNumber : string.Empty;
            }
            set
            {
                GeneralShipperMasterDTO.PhoneNumber = value;
            }
        }

        [Display(Name = "Is Active")]
        public bool IsActive
        {
            get
            {
                return (GeneralShipperMasterDTO != null) ? GeneralShipperMasterDTO.IsActive : false;
            }
            set
            {
                GeneralShipperMasterDTO.IsActive = value;
            }
        }

        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (GeneralShipperMasterDTO != null) ? GeneralShipperMasterDTO.IsDeleted : false;
            }
            set
            {
                GeneralShipperMasterDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (GeneralShipperMasterDTO != null && GeneralShipperMasterDTO.CreatedBy > 0) ? GeneralShipperMasterDTO.CreatedBy : new int();
            }
            set
            {
                GeneralShipperMasterDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (GeneralShipperMasterDTO != null) ? GeneralShipperMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                GeneralShipperMasterDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int ModifiedBy
        {
            get
            {
                return (GeneralShipperMasterDTO != null) ? GeneralShipperMasterDTO.ModifiedBy : new int();
            }
            set
            {
                GeneralShipperMasterDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime ModifiedDate
        {
            get
            {
                return (GeneralShipperMasterDTO != null) ? GeneralShipperMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                GeneralShipperMasterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int DeletedBy
        {
            get
            {
                return (GeneralShipperMasterDTO != null) ? GeneralShipperMasterDTO.DeletedBy : new int();
            }
            set
            {
                GeneralShipperMasterDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime DeletedDate
        {
            get
            {
                return (GeneralShipperMasterDTO != null) ? GeneralShipperMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                GeneralShipperMasterDTO.DeletedDate = value;
            }
        }


        public string errorMessage { get; set; }






    }
}

