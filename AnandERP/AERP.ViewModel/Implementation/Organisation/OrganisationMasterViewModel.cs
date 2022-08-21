using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
namespace AERP.ViewModel
{
    public class OrganisationMasterBaseViewModel : IOrganisationMasterBaseViewModel
    {
        public OrganisationMasterBaseViewModel()
        {
            ListOrganisationMaster = new List<OrganisationMaster>();

            ListGeneralLocationMaster = new List<GeneralLocationMaster>();

        }

        public List<OrganisationMaster> ListOrganisationMaster
        {
            get;
            set;
        }

        public List<GeneralLocationMaster> ListGeneralLocationMaster
        {
            get;
            set;
        }

        public string SelectedLocationID
        {
            get;
            set;
        }

        public IEnumerable<SelectListItem> ListGeneralLocationMasterItems
        {
            get
            {
                return new SelectList(ListGeneralLocationMaster, "ID", "LocationAddress");
            }
        }

    }


    public class OrganisationMasterViewModel : IOrganisationMasterViewModel
    {

        public OrganisationMasterViewModel()
        {
            OrganisationMasterDTO = new OrganisationMaster();
        }

        public OrganisationMaster OrganisationMasterDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (OrganisationMasterDTO != null && OrganisationMasterDTO.ID > 0) ? OrganisationMasterDTO.ID : new int();
            }
            set
            {
                OrganisationMasterDTO.ID = value;
            }
        }

        public int LocationID
        {
            get
            {
                return (OrganisationMasterDTO != null && OrganisationMasterDTO.LocationID > 0) ? OrganisationMasterDTO.LocationID : new int();
            }
            set
            {
                OrganisationMasterDTO.LocationID = value;
            }
        }

        [Display(Name = "Organisation Name")]
        [Required(ErrorMessage = "Organisation Name Required")]
        public string OrgName
        {
            get
            {
                return (OrganisationMasterDTO != null) ? OrganisationMasterDTO.OrgName : string.Empty;
            }
            set
            {
                OrganisationMasterDTO.OrgName = value;
            }
        }

        [Display(Name = "Establishment Code")]
        public string EstablishmentCode
        {
            get
            {
                return (OrganisationMasterDTO != null) ? OrganisationMasterDTO.EstablishmentCode : string.Empty;
            }
            set
            {
                OrganisationMasterDTO.EstablishmentCode = value;
            }
        }

        [Display(Name = "Foundation Date")]
        [Required(ErrorMessage = "Foundation Date Required")]
        public string FoundationDatetime
        {
            get
            {
                return (OrganisationMasterDTO != null) ? OrganisationMasterDTO.FoundationDatetime : string.Empty;
            }
            set
            {
                OrganisationMasterDTO.FoundationDatetime = value;
            }
        }

        [Display(Name = "Founder Member")]
        [Required(ErrorMessage = "Founder Member Required")]
        public string FounderMember
        {
            get
            {
                return (OrganisationMasterDTO != null) ? OrganisationMasterDTO.FounderMember : string.Empty;
            }
            set
            {
                OrganisationMasterDTO.FounderMember = value;
            }
        }
        [Display(Name = "Address1")]
        [Required(ErrorMessage = "Address1 Required")]
        public string Address1
        {
            get
            {
                return (OrganisationMasterDTO != null) ? OrganisationMasterDTO.Address1 : string.Empty;
            }
            set
            {
                OrganisationMasterDTO.Address1 = value;
            }
        }

        [Display(Name = "Address2")]
        public string Address2
        {
            get
            {
                return (OrganisationMasterDTO != null) ? OrganisationMasterDTO.Address2 : string.Empty;
            }
            set
            {
                OrganisationMasterDTO.Address2 = value;
            }
        }

        [Display(Name = "Plot Number")]
        [Required(ErrorMessage = "Plot Number Required")]
        public string PlotNumber
        {
            get
            {
                return (OrganisationMasterDTO != null) ? OrganisationMasterDTO.PlotNumber : string.Empty;
            }
            set
            {
                OrganisationMasterDTO.PlotNumber = value;
            }
        }

        [Display(Name = "Street Number")]
        public string StreetNumber
        {
            get
            {
                return (OrganisationMasterDTO != null) ? OrganisationMasterDTO.StreetNumber : string.Empty;
            }
            set
            {
                OrganisationMasterDTO.StreetNumber = value;
            }
        }

        [Display(Name = "Pincode")]
        [Required(ErrorMessage = "Pincode Required")]
        public string Pincode
        {
            get
            {
                return (OrganisationMasterDTO != null) ? OrganisationMasterDTO.Pincode : string.Empty;
            }
            set
            {
                OrganisationMasterDTO.Pincode = value;
            }
        }


        [Display(Name = "Fax Number")]
        public string FaxNumber
        {
            get
            {
                return (OrganisationMasterDTO != null) ? OrganisationMasterDTO.FaxNumber : string.Empty;
            }
            set
            {
                OrganisationMasterDTO.FaxNumber = value;
            }
        }



        [Display(Name = "Mobile Number")]
        public string MobileNumber
        {
            get
            {
                return (OrganisationMasterDTO != null) ? OrganisationMasterDTO.MobileNumber : string.Empty;
            }
            set
            {
                OrganisationMasterDTO.MobileNumber = value;
            }
        }


        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Email Address Required")]
        public string EmailID
        {
            get
            {
                return (OrganisationMasterDTO != null) ? OrganisationMasterDTO.EmailID : string.Empty;
            }
            set
            {
                OrganisationMasterDTO.EmailID = value;
            }
        }


        [Display(Name = "Url")]
        [Required(ErrorMessage = "Url Required")]
        public string Url
        {
            get
            {
                return (OrganisationMasterDTO != null) ? OrganisationMasterDTO.Url : string.Empty;
            }
            set
            {
                OrganisationMasterDTO.Url = value;
            }
        }


        [Display(Name = "Office Comment")]
        public string OfficeComment
        {
            get
            {
                return (OrganisationMasterDTO != null) ? OrganisationMasterDTO.OfficeComment : string.Empty;
            }
            set
            {
                OrganisationMasterDTO.OfficeComment = value;
            }
        }


        [Display(Name = "Mission Statement")]
        public string MissionStatement
        {
            get
            {
                return (OrganisationMasterDTO != null) ? OrganisationMasterDTO.MissionStatement : string.Empty;
            }
            set
            {
                OrganisationMasterDTO.MissionStatement = value;
            }
        }


        [Display(Name = "Office Phone1")]
        [Required(ErrorMessage = "Office Phone1 Required")]
        public string OfficePhone1
        {
            get
            {
                return (OrganisationMasterDTO != null) ? OrganisationMasterDTO.OfficePhone1 : string.Empty;
            }
            set
            {
                OrganisationMasterDTO.OfficePhone1 = value;
            }
        }

        [Display(Name = "Office Phone2")]
        public string OfficePhone2
        {
            get
            {
                return (OrganisationMasterDTO != null) ? OrganisationMasterDTO.OfficePhone2 : string.Empty;
            }
            set
            {
                OrganisationMasterDTO.OfficePhone2 = value;
            }
        }

        public int TotalRecordsFound
        {
            get
            {
                return (OrganisationMasterDTO != null && OrganisationMasterDTO.LocationID > 0) ? OrganisationMasterDTO.TotalRecordsFound : new int();
            }
            set
            {
                OrganisationMasterDTO.TotalRecordsFound = value;
            }
        }

        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (OrganisationMasterDTO != null) ? OrganisationMasterDTO.IsDeleted : false;
            }
            set
            {
                OrganisationMasterDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (OrganisationMasterDTO != null && OrganisationMasterDTO.CreatedBy > 0) ? OrganisationMasterDTO.CreatedBy : new int();
            }
            set
            {
                OrganisationMasterDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (OrganisationMasterDTO != null) ? OrganisationMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                OrganisationMasterDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (OrganisationMasterDTO != null && OrganisationMasterDTO.ModifiedBy > 0) ? OrganisationMasterDTO.ModifiedBy : new int();
            }
            set
            {
                OrganisationMasterDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (OrganisationMasterDTO != null && OrganisationMasterDTO.ModifiedDate.HasValue) ? OrganisationMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                OrganisationMasterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (OrganisationMasterDTO != null && OrganisationMasterDTO.DeletedBy.HasValue) ? OrganisationMasterDTO.DeletedBy : new int();
            }
            set
            {
                OrganisationMasterDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (OrganisationMasterDTO != null && OrganisationMasterDTO.DeletedDate.HasValue) ? OrganisationMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                OrganisationMasterDTO.DeletedDate = value;
            }
        }

        [Display(Name = "Location Name")]
        [Required(ErrorMessage = "Location Required")]
        public string SelectedLocationID
        {
            get;
            set;
        }
        [Display(Name = "PF Number")]
        public string PFNumber
        {
            get
            {
                return (OrganisationMasterDTO != null) ? OrganisationMasterDTO.PFNumber : string.Empty;
            }
            set
            {
                OrganisationMasterDTO.PFNumber = value;
            }
        }
        [Display(Name = "ESIC Number")]
        public string ESICNumber
        {
            get
            {
                return (OrganisationMasterDTO != null) ? OrganisationMasterDTO.ESICNumber : string.Empty;
            }
            set
            {
                OrganisationMasterDTO.ESICNumber = value;
            }
        }
        [Display(Name = "Org ShortCode")]
        public string OrgShortCode
        {
            get
            {
                return (OrganisationMasterDTO != null) ? OrganisationMasterDTO.OrgShortCode : string.Empty;
            }
            set
            {
                OrganisationMasterDTO.OrgShortCode = value;
            }
        }
    }
}
