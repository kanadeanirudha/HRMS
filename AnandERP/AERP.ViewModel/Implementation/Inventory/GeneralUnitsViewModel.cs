using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class GeneralUnitsViewModel : IGeneralUnitsViewModel
    {

        public GeneralUnitsViewModel()
        {
            GeneralUnitsDTO = new GeneralUnits();
            ListGetAdminRoleApplicableCentre = new List<AdminRoleApplicableDetails>();
            ListGetOrganisationDepartmentCentreAndRoleWise = new List<OrganisationDepartmentMaster>();
            GetAdminRoleDomainList = new List<AdminRoleMaster>();
        }

        public List<AdminRoleMaster> GetAdminRoleDomainList { get; set; }

        public IEnumerable<SelectListItem> ListAdminRoleDomainItems
        {
            get
            {
                return new SelectList(GetAdminRoleDomainList, "AdminRoleDomainID", "AdminRoleDomainName");
            }
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
        public List<OrganisationDepartmentMaster> ListGetOrganisationDepartmentCentreAndRoleWise
        {
            get;
            set;
        }
        public IEnumerable<SelectListItem> ListGetOrganisationDepartmentCentreAndRoleWiseItems
        {
            get
            {
                return new SelectList(ListGetOrganisationDepartmentCentreAndRoleWise, "ID", "DepartmentName");
            }
        }
        public GeneralUnits GeneralUnitsDTO
        {
            get;
            set;
        }

        public Int16 ID
        {
            get
            {
                return (GeneralUnitsDTO != null && GeneralUnitsDTO.ID > 0) ? GeneralUnitsDTO.ID : new Int16();
            }
            set
            {
                GeneralUnitsDTO.ID = value;
            }
        }

        [Required(ErrorMessage = "Unit Name should not be blank.")]
        [Display(Name = "Unit Name")]
        public string UnitName
        {
            get
            {
                return (GeneralUnitsDTO != null) ? GeneralUnitsDTO.UnitName : string.Empty;
            }
            set
            {
                GeneralUnitsDTO.UnitName = value;
            }
        }
        public Int16 GeneralUnitTypeID
        {
            get
            {
                return (GeneralUnitsDTO != null && GeneralUnitsDTO.GeneralUnitTypeID > 0) ? GeneralUnitsDTO.GeneralUnitTypeID : new Int16();
            }
            set
            {
                GeneralUnitsDTO.GeneralUnitTypeID = value;
            }
        }
        [Required(ErrorMessage = "Centre Code should not be blank.")]
        [Display(Name = "Centre Code")]
        public string CentreCode
        {
            get
            {
                return (GeneralUnitsDTO != null) ? GeneralUnitsDTO.CentreCode : string.Empty;
            }
            set
            {
                GeneralUnitsDTO.CentreCode = value;
            }
        }
        public int DepartmentID
        {
            get
            {
                return (GeneralUnitsDTO != null && GeneralUnitsDTO.DepartmentID > 0) ? GeneralUnitsDTO.DepartmentID : new int();
            }
            set
            {
                GeneralUnitsDTO.DepartmentID = value;
            }
        }

        public int GeneralUnitsStorageLocationID
        {
            get
            {
                return (GeneralUnitsDTO != null && GeneralUnitsDTO.GeneralUnitsStorageLocationID > 0) ? GeneralUnitsDTO.GeneralUnitsStorageLocationID : new int();
            }
            set
            {
                GeneralUnitsDTO.GeneralUnitsStorageLocationID = value;
            }
        }
        
      
        public int CityId
        {
            get
            {
                return (GeneralUnitsDTO != null && GeneralUnitsDTO.CityId > 0) ? GeneralUnitsDTO.CityId : new int();
            }
            set
            {
                GeneralUnitsDTO.CityId = value;
            }
        }
        [Required(ErrorMessage = " Sub Location Name should not be blank.")]
        [Display(Name = "Sub Location Name")]
        public string LocationName
        {

            get
            {
                return (GeneralUnitsDTO != null) ? GeneralUnitsDTO.LocationName : string.Empty;
            }
            set
            {
                GeneralUnitsDTO.LocationName = value;
            }
        }
        public int InventoryLocationMasterID
        {
            get
            {
                return (GeneralUnitsDTO != null) ? GeneralUnitsDTO.InventoryLocationMasterID : new int();
            }
            set
            {
                GeneralUnitsDTO.InventoryLocationMasterID = value;
            }
        }
        //[Required(ErrorMessage = "Location Address should not be blank.")]
        [Display(Name = "Location Address")]
        public string LocationAddress
        {
            get
            {
                return (GeneralUnitsDTO != null) ? GeneralUnitsDTO.LocationAddress : string.Empty;
            }
            set
            {
                GeneralUnitsDTO.LocationAddress = value;
            }
        }
        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (GeneralUnitsDTO != null) ? GeneralUnitsDTO.IsDeleted : false;
            }
            set
            {
                GeneralUnitsDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (GeneralUnitsDTO != null && GeneralUnitsDTO.CreatedBy > 0) ? GeneralUnitsDTO.CreatedBy : new int();
            }
            set
            {
                GeneralUnitsDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (GeneralUnitsDTO != null) ? GeneralUnitsDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                GeneralUnitsDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int ModifiedBy
        {
            get
            {
                return (GeneralUnitsDTO != null) ? GeneralUnitsDTO.ModifiedBy : new int();
            }
            set
            {
                GeneralUnitsDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime ModifiedDate
        {
            get
            {
                return (GeneralUnitsDTO != null) ? GeneralUnitsDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                GeneralUnitsDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int DeletedBy
        {
            get
            {
                return (GeneralUnitsDTO != null) ? GeneralUnitsDTO.DeletedBy : new int();
            }
            set
            {
                GeneralUnitsDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime DeletedDate
        {
            get
            {
                return (GeneralUnitsDTO != null) ? GeneralUnitsDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                GeneralUnitsDTO.DeletedDate = value;
            }
        }


        public string errorMessage { get; set; }

        public string EntityLevel { get; set; }
        public string SelectedDepartmentID
        {
            get;
            set;
        }
        public string SelectedDepartmentIDs
        {
            get;
            set;
        }
          [Display(Name = "Unit Type")]
        public string UnitType
        {
            get
            {
                return (GeneralUnitsDTO != null) ? GeneralUnitsDTO.UnitType : string.Empty;
            }
            set
            {
                GeneralUnitsDTO.UnitType = value;
            }
        }
         //[Required(ErrorMessage = "City Name should not be blank.")] 
        [Display(Name = "City")]
        public string CityName
        {
            get
            {
                return (GeneralUnitsDTO != null) ? GeneralUnitsDTO.CityName : string.Empty;
            }
            set
            {
                GeneralUnitsDTO.CityName = value;
            }
        }
        public Int16 Relatedwith
        {
            get
            {
                return (GeneralUnitsDTO != null && GeneralUnitsDTO.Relatedwith > 0) ? GeneralUnitsDTO.Relatedwith : new Int16();
            }
            set
            {
                GeneralUnitsDTO.Relatedwith = value;
            }
        }
        [Display(Name = "Related with Unit Type")]
        public string RelatedwithUnitType
        {
            get
            {
                return (GeneralUnitsDTO != null) ? GeneralUnitsDTO.RelatedwithUnitType : string.Empty;
            }
            set
            {
                GeneralUnitsDTO.RelatedwithUnitType = value;
            }
        }
          [Display(Name = "Department Name")]
        public string DepartmentName
        {
            get
            {
                return (GeneralUnitsDTO != null) ? GeneralUnitsDTO.DepartmentName : string.Empty;
            }
            set
            {
                GeneralUnitsDTO.DepartmentName = value;
            }
        }
          [Display(Name = "Centre Name")]
        public string CentreName
        {
            get
            {
                return (GeneralUnitsDTO != null) ? GeneralUnitsDTO.CentreName : string.Empty;
            }
            set
            {
                GeneralUnitsDTO.CentreName = value;
            }
        }
          public string ListingDate
          {
              get
              {
                  return (GeneralUnitsDTO != null) ? GeneralUnitsDTO.ListingDate : string.Empty;
              }
              set
              {
                  GeneralUnitsDTO.ListingDate = value;
              }
          }
          public string DeListingDate
          {
              get
              {
                  return (GeneralUnitsDTO != null) ? GeneralUnitsDTO.DeListingDate : string.Empty;
              }
              set
              {
                  GeneralUnitsDTO.DeListingDate = value;
              }
          }

        //Fields for unit details
          public string Footer
          {
              get
              {
                  return (GeneralUnitsDTO != null) ? GeneralUnitsDTO.Footer : string.Empty;
              }
              set
              {
                  GeneralUnitsDTO.Footer = value;
              }
          }
          [Display(Name = "Logo Path")]
          public string LogoPath
          {
              get
              {
                  return (GeneralUnitsDTO != null) ? GeneralUnitsDTO.LogoPath : string.Empty;
              }
              set
              {
                  GeneralUnitsDTO.LogoPath = value;
              }
          }
          public string LogoName
          {
              get
              {
                  return (GeneralUnitsDTO != null) ? GeneralUnitsDTO.LogoName : string.Empty;
              }
              set
              {
                  GeneralUnitsDTO.LogoName = value;
              }
          }
          public string LogoPathName
          {
              get
              {
                  return (GeneralUnitsDTO != null) ? GeneralUnitsDTO.LogoPathName : string.Empty;
              }
              set
              {
                  GeneralUnitsDTO.LogoPathName = value;
              }
          }
          public string Pincode
          {
              get
              {
                  return (GeneralUnitsDTO != null) ? GeneralUnitsDTO.Pincode : string.Empty;
              }
              set
              {
                  GeneralUnitsDTO.Pincode = value;
              }
          }
           [Display(Name = "Telephone Number")]
          public string TelephoneNumber
          {
              get
              {
                  return (GeneralUnitsDTO != null) ? GeneralUnitsDTO.TelephoneNumber : string.Empty;
              }
              set
              {
                  GeneralUnitsDTO.TelephoneNumber = value;
              }
          }
        [Display(Name = "Fax Number")]
          public string FaxNumber
          {
              get
              {
                  return (GeneralUnitsDTO != null) ? GeneralUnitsDTO.FaxNumber : string.Empty;
              }
              set
              {
                  GeneralUnitsDTO.FaxNumber = value;
              }
          }

          public string Url
          {
              get
              {
                  return (GeneralUnitsDTO != null) ? GeneralUnitsDTO.Url : string.Empty;
              }
              set
              {
                  GeneralUnitsDTO.Url = value;
              }
          }
           [Display(Name = "Display Icon")]
          public string DisplayIcon
          {
              get
              {
                  return (GeneralUnitsDTO != null) ? GeneralUnitsDTO.DisplayIcon : string.Empty;
              }
              set
              {
                  GeneralUnitsDTO.DisplayIcon = value;
              }
          }
           [Display(Name = "Email ID")]
          public string EmailID
          {
              get
              {
                  return (GeneralUnitsDTO != null) ? GeneralUnitsDTO.EmailID : string.Empty;
              }
              set
              {
                  GeneralUnitsDTO.EmailID = value;
              }
          }
          public string Greeting
          {
              get
              {
                  return (GeneralUnitsDTO != null) ? GeneralUnitsDTO.Greeting : string.Empty;
              }
              set
              {
                  GeneralUnitsDTO.Greeting = value;
              }
          }

          public bool IsFooter
          {
              get
              {
                  return (GeneralUnitsDTO != null) ? GeneralUnitsDTO.IsFooter : false;
              }
              set
              {
                  GeneralUnitsDTO.IsFooter = value;
              }
          }

          public bool IsLogoPath
          {
              get
              {
                  return (GeneralUnitsDTO != null) ? GeneralUnitsDTO.IsLogoPath : false;
              }
              set
              {
                  GeneralUnitsDTO.IsLogoPath = value;
              }
          }

          public bool IsPincode
          {
              get
              {
                  return (GeneralUnitsDTO != null) ? GeneralUnitsDTO.IsPincode : false;
              }
              set
              {
                  GeneralUnitsDTO.IsPincode = value;
              }
          }

          public bool IsTelephoneNumber
          {
              get
              {
                  return (GeneralUnitsDTO != null) ? GeneralUnitsDTO.IsTelephoneNumber : false;
              }
              set
              {
                  GeneralUnitsDTO.IsTelephoneNumber = value;
              }
          }

          public bool IsFaxNumber
          {
              get
              {
                  return (GeneralUnitsDTO != null) ? GeneralUnitsDTO.IsFaxNumber : false;
              }
              set
              {
                  GeneralUnitsDTO.IsFaxNumber = value;
              }
          }

          public bool IsEmailID
          {
              get
              {
                  return (GeneralUnitsDTO != null) ? GeneralUnitsDTO.IsEmailID : false;
              }
              set
              {
                  GeneralUnitsDTO.IsEmailID = value;
              }
          }

          public bool IsUrl
          {
              get
              {
                  return (GeneralUnitsDTO != null) ? GeneralUnitsDTO.IsUrl : false;
              }
              set
              {
                  GeneralUnitsDTO.IsUrl = value;
              }
          }

          public bool isGreeting
          {
              get
              {
                  return (GeneralUnitsDTO != null) ? GeneralUnitsDTO.isGreeting : false;
              }
              set
              {
                  GeneralUnitsDTO.isGreeting = value;
              }
          }

          public bool IsAddress
          {
              get
              {
                  return (GeneralUnitsDTO != null) ? GeneralUnitsDTO.IsAddress : false;
              }
              set
              {
                  GeneralUnitsDTO.IsAddress = value;
              }
          }

          public bool IsCityName
          {
              get
              {
                  return (GeneralUnitsDTO != null) ? GeneralUnitsDTO.IsCityName : false;
              }
              set
              {
                  GeneralUnitsDTO.IsCityName = value;
              }
          }
        public string SelectedDomainIDs
        {
            get;set;
        }
        [Display(Name = "Is Default Unit")]
        public bool IsDefaultUnit
        {
            get
            {
                return (GeneralUnitsDTO != null) ? GeneralUnitsDTO.IsDefaultUnit : false;
            }
            set
            {
                GeneralUnitsDTO.IsDefaultUnit = value;
            }
        }
    }
}

