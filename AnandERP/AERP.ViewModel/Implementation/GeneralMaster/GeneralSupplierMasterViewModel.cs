using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class GeneralSupplierMasterViewModel
    {
        public GeneralSupplierMasterViewModel()
        {
            GeneralSupplierMasterDTO = new GeneralSupplierMaster();
        }
        public GeneralSupplierMaster GeneralSupplierMasterDTO
        {
            get;
            set;
        }
        public int VendorNumber
        {
            get
            {
                return (GeneralSupplierMasterDTO != null && GeneralSupplierMasterDTO.VendorNumber > 0) ? GeneralSupplierMasterDTO.VendorNumber : new int();
            }
            set
            {
                GeneralSupplierMasterDTO.VendorNumber = value;
            }
        }
        public int ID
        {
            get
            {
                return (GeneralSupplierMasterDTO != null && GeneralSupplierMasterDTO.ID > 0) ? GeneralSupplierMasterDTO.ID : new int();
            }
            set
            {
                GeneralSupplierMasterDTO.ID = value;
            }
        }
        [Required(ErrorMessage = "Vendor is required")]
        public string Vender
        {
            get
            {
                return (GeneralSupplierMasterDTO != null) ? GeneralSupplierMasterDTO.Vender : string.Empty;
            }
            set
            {
                GeneralSupplierMasterDTO.Vender = value;
            }
        }

        [Required(ErrorMessage = "First name is required")]
        public string FirstName
        {
            get
            {
                return (GeneralSupplierMasterDTO != null) ? GeneralSupplierMasterDTO.FirstName : string.Empty;
            }
            set
            {
                GeneralSupplierMasterDTO.FirstName = value;
            }
        }

        [Required(ErrorMessage = "Middle name is required")]
        public string MiddleName
        {
            get
            {
                return (GeneralSupplierMasterDTO != null) ? GeneralSupplierMasterDTO.MiddleName : string.Empty;
            }
            set
            {
                GeneralSupplierMasterDTO.MiddleName = value;
            }
        }

        [Required(ErrorMessage = "Last name is required")]
        public string LastName
        {
            get
            {
                return (GeneralSupplierMasterDTO != null) ? GeneralSupplierMasterDTO.LastName : string.Empty;
            }
            set
            {
                GeneralSupplierMasterDTO.LastName = value;
            }
        }
        public string FullName
        {
            get
            {
                return (GeneralSupplierMasterDTO != null) ? GeneralSupplierMasterDTO.FullName : string.Empty;
            }
            set
            {
                GeneralSupplierMasterDTO.FullName = value;
            }
        }
        public string Sex
        {
            get
            {
                return (GeneralSupplierMasterDTO != null) ? GeneralSupplierMasterDTO.Sex : string.Empty;
            }
            set
            {
                GeneralSupplierMasterDTO.Sex = value;
            }
        }

        [Required(ErrorMessage = "Address is required")]
        public string AddressFirst
        {
            get
            {
                return (GeneralSupplierMasterDTO != null) ? GeneralSupplierMasterDTO.AddressFirst : string.Empty;
            }
            set
            {
                GeneralSupplierMasterDTO.AddressFirst = value;
            }
        }
        public string AddressSecond
        {
            get
            {
                return (GeneralSupplierMasterDTO != null) ? GeneralSupplierMasterDTO.AddressSecond : string.Empty;
            }
            set
            {
                GeneralSupplierMasterDTO.AddressSecond = value;
            }
        }

        [Required(ErrorMessage = "Phone number is required")]
        public string PlotNumber
        {
            get
            {
                return (GeneralSupplierMasterDTO != null) ? GeneralSupplierMasterDTO.PlotNumber : string.Empty;
            }
            set
            {
                GeneralSupplierMasterDTO.PlotNumber = value;
            }
        }

        [Required(ErrorMessage = "Street number is required")]
        public string StreetNumber
        {
            get
            {
                return (GeneralSupplierMasterDTO != null) ? GeneralSupplierMasterDTO.StreetNumber : string.Empty;
            }
            set
            {
                GeneralSupplierMasterDTO.StreetNumber = value;
            }
        }

        [Required(ErrorMessage = "Tahsil is required")]
        public Nullable<int> TahsilID
        {
            get
            {
                return (GeneralSupplierMasterDTO != null && GeneralSupplierMasterDTO.TahsilID > 0) ? GeneralSupplierMasterDTO.TahsilID : new int();
            }
            set
            {
                GeneralSupplierMasterDTO.TahsilID = value;
            }
        }

        [Required(ErrorMessage = "Pin code is required")]
        public Nullable<int> PinCode
        {
            get
            {
                return (GeneralSupplierMasterDTO != null && GeneralSupplierMasterDTO.PinCode > 0) ? GeneralSupplierMasterDTO.PinCode : new int();
            }
            set
            {
                GeneralSupplierMasterDTO.PinCode = value;
            }
        }

        [Required(ErrorMessage = "Phone number is required")]
        public string PhoneNumber
        {
            get
            {
                return (GeneralSupplierMasterDTO != null) ? GeneralSupplierMasterDTO.PhoneNumber : string.Empty;
            }
            set
            {
                GeneralSupplierMasterDTO.PhoneNumber = value;
            }
        }

        [Required(ErrorMessage = "Residence phone number is required")]
        public string ResiPhoneNumber
        {
            get
            {
                return (GeneralSupplierMasterDTO != null) ? GeneralSupplierMasterDTO.ResiPhoneNumber : string.Empty;
            }
            set
            {
                GeneralSupplierMasterDTO.ResiPhoneNumber = value;
            }
        }

        [Required(ErrorMessage = "Cell phone number is required")]
        public string CellPhoneNumber
        {
            get
            {
                return (GeneralSupplierMasterDTO != null) ? GeneralSupplierMasterDTO.CellPhoneNumber : string.Empty;
            }
            set
            {
                GeneralSupplierMasterDTO.CellPhoneNumber = value;
            }
        }

        [Required(ErrorMessage = "Fax number is required")]
        public string FaxNumber
        {
            get
            {
                return (GeneralSupplierMasterDTO != null) ? GeneralSupplierMasterDTO.FaxNumber : string.Empty;
            }
            set
            {
                GeneralSupplierMasterDTO.FaxNumber = value;
            }
        }

        [Required(ErrorMessage = "Email is required")]
        public string Email
        {
            get
            {
                return (GeneralSupplierMasterDTO != null) ? GeneralSupplierMasterDTO.Email : string.Empty;
            }
            set
            {
                GeneralSupplierMasterDTO.Email = value;
            }
        }

        [Required(ErrorMessage = "Web url is required")]
        public string WebUrl
        {
            get
            {
                return (GeneralSupplierMasterDTO != null) ? GeneralSupplierMasterDTO.WebUrl : string.Empty;
            }
            set
            {
                GeneralSupplierMasterDTO.WebUrl = value;
            }
        }

        [Required(ErrorMessage = "Vendor description is required")]
        public string VenderDescription
        {
            get
            {
                return (GeneralSupplierMasterDTO != null) ? GeneralSupplierMasterDTO.VenderDescription : string.Empty;
            }
            set
            {
                GeneralSupplierMasterDTO.VenderDescription = value;
            }
        }
        public Nullable<int> CategoryId
        {
            get
            {
                return (GeneralSupplierMasterDTO != null && GeneralSupplierMasterDTO.CategoryId > 0) ? GeneralSupplierMasterDTO.CategoryId : new int();
            }
            set
            {
                GeneralSupplierMasterDTO.CategoryId = value;
            }
        }
        public Nullable<int> AccountId
        {
            get
            {
                return (GeneralSupplierMasterDTO != null && GeneralSupplierMasterDTO.AccountId > 0) ? GeneralSupplierMasterDTO.AccountId : new int();
            }
            set
            {
                GeneralSupplierMasterDTO.PinCode = value;
            }
        }

        [Required(ErrorMessage = "VAT is required")]
        public string VAT
        {
            get
            {
                return (GeneralSupplierMasterDTO != null) ? GeneralSupplierMasterDTO.VAT : string.Empty;
            }
            set
            {
                GeneralSupplierMasterDTO.VAT = value;
            }
        }

        [Required(ErrorMessage = "CST is required")]
        public string CST
        {
            get
            {
                return (GeneralSupplierMasterDTO != null) ? GeneralSupplierMasterDTO.CST : string.Empty;
            }
            set
            {
                GeneralSupplierMasterDTO.CST = value;
            }
        }

        [Required(ErrorMessage = "Excise is required")]
        public string Excise
        {
            get
            {
                return (GeneralSupplierMasterDTO != null) ? GeneralSupplierMasterDTO.Excise : string.Empty;
            }
            set
            {
                GeneralSupplierMasterDTO.Excise = value;
            }
        }

        [Required(ErrorMessage = "Stablishment number is required")]
        public string StablishmentNumber
        {
            get
            {
                return (GeneralSupplierMasterDTO != null) ? GeneralSupplierMasterDTO.StablishmentNumber : string.Empty;
            }
            set
            {
                GeneralSupplierMasterDTO.StablishmentNumber = value;
            }
        }

        [Required(ErrorMessage = "Reference number is required")]
        public string RefNumber
        {
            get
            {
                return (GeneralSupplierMasterDTO != null) ? GeneralSupplierMasterDTO.RefNumber : string.Empty;
            }
            set
            {
                GeneralSupplierMasterDTO.RefNumber = value;
            }
        }
        [Display(Name = "IsActive")]
        public Nullable<bool> IsActive
        {
            get
            {
                return (GeneralSupplierMasterDTO != null) ? GeneralSupplierMasterDTO.IsActive : false;
            }
            set
            {
                GeneralSupplierMasterDTO.IsActive = value;
            }
        }

        [Display(Name = "Created By")]
        public Nullable<int> CreatedBy
        {
            get
            {
                return (GeneralSupplierMasterDTO != null && GeneralSupplierMasterDTO.CreatedBy > 0) ? GeneralSupplierMasterDTO.CreatedBy : new int();
            }
            set
            {
                GeneralSupplierMasterDTO.CreatedBy = value;
            }
        }

        [Display(Name = "Created Date")]
        public Nullable<System.DateTime> CreatedDate
        {
            get
            {
                return (GeneralSupplierMasterDTO != null) ? GeneralSupplierMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                GeneralSupplierMasterDTO.CreatedDate = value;
            }
        }

        public Nullable<int> ModifiedBy
        {
            get
            {
                return (GeneralSupplierMasterDTO != null && GeneralSupplierMasterDTO.ModifiedBy > 0) ? GeneralSupplierMasterDTO.ModifiedBy : new int();
            }
            set
            {
                GeneralSupplierMasterDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public Nullable<System.DateTime> ModifiedDate
        {
            get
            {
                return (GeneralSupplierMasterDTO != null) ? GeneralSupplierMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                GeneralSupplierMasterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "Deleted By")]
        public Nullable<int> DeletedBy
        {
            get
            {
                return (GeneralSupplierMasterDTO != null && GeneralSupplierMasterDTO.DeletedBy > 0) ? GeneralSupplierMasterDTO.DeletedBy : new int();
            }
            set
            {
                GeneralSupplierMasterDTO.DeletedBy = value;
            }
        }

        [Display(Name = "Deleted Date")]
        public Nullable<System.DateTime> DeletedDate
        {
            get
            {
                return (GeneralSupplierMasterDTO != null) ? GeneralSupplierMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                GeneralSupplierMasterDTO.DeletedDate = value;
            }
        }


        [Display(Name = "IsDeleted")]
        public Nullable<bool> IsDeleted
        {
            get
            {
                return (GeneralSupplierMasterDTO != null) ? GeneralSupplierMasterDTO.IsDeleted : false;
            }
            set
            {
                GeneralSupplierMasterDTO.IsDeleted = value;
            }
        }
    }
}
