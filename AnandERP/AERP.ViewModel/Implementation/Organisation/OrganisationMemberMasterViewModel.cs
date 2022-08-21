using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{
    public class OrganisationMemberMasterViewModel : IOrganisationMemberMasterViewModel
    {
        public OrganisationMemberMasterViewModel()
        {
            OrganisationMemberMasterDTO = new OrganisationMemberMaster();
            ListGetAdminRoleApplicableCentre = new List<AdminRoleApplicableDetails>();
            ListOrganisationStudyCentreMaster = new List<OrganisationStudyCentreMaster>();
        }
        public OrganisationMemberMaster OrganisationMemberMasterDTO
        {
            get;
            set;
        }
        public List<OrganisationStudyCentreMaster> ListOrganisationStudyCentreMaster
        {
            get;
            set;
        }
        public List<AdminRoleApplicableDetails> ListGetAdminRoleApplicableCentre
        {
            get;
            set;
        }
        public IEnumerable<SelectListItem> ListOrganisationStudyCentreMasterItems
        {
            get
            {
                return new SelectList(ListOrganisationStudyCentreMaster, "CentreCode", "CentreName");
            }
        }
        public IEnumerable<SelectListItem> ListGetAdminRoleApplicableCentreItems
        {
            get
            {
                return new SelectList(ListGetAdminRoleApplicableCentre, "CentreCode", "CentreName");
            }
        }
        //------------------------------------------------Model Properties-----------------------------------------------------------------------------------------------------
        public int ID
        {
            get
            {
                return (OrganisationMemberMasterDTO != null && OrganisationMemberMasterDTO.ID > 0) ? OrganisationMemberMasterDTO.ID : new int();
            }
            set
            {
                OrganisationMemberMasterDTO.ID = value;
            }
        }
        public int PersonID
        {
            get
            {
                return (OrganisationMemberMasterDTO != null && OrganisationMemberMasterDTO.PersonID > 0) ? OrganisationMemberMasterDTO.PersonID : new int();
            }
            set
            {
                OrganisationMemberMasterDTO.PersonID = value;
            }
        }
        public string PersonType
        {
            get
            {
                return (OrganisationMemberMasterDTO != null) ? OrganisationMemberMasterDTO.PersonType : string.Empty;
            }
            set
            {
                OrganisationMemberMasterDTO.PersonType = value;
            }
        }
        public string JoiningDate
        {
            get
            {
                return (OrganisationMemberMasterDTO != null) ? OrganisationMemberMasterDTO.JoiningDate : string.Empty;
            }
            set
            {
                OrganisationMemberMasterDTO.JoiningDate = value;
            }
        }
        public string LeavingDate
        {
            get
            {
                return (OrganisationMemberMasterDTO != null) ? OrganisationMemberMasterDTO.LeavingDate : string.Empty;
            }
            set
            {
                OrganisationMemberMasterDTO.LeavingDate = value;
            }
        }
        public decimal ShareQuantity
        {
            get
            {
                return (OrganisationMemberMasterDTO != null && OrganisationMemberMasterDTO.ShareQuantity > 0) ? OrganisationMemberMasterDTO.ShareQuantity : new decimal();
            }
            set
            {
                OrganisationMemberMasterDTO.ShareQuantity = value;
            }
        }
        public decimal EachSharePrice
        {
            get
            {
                return (OrganisationMemberMasterDTO != null && OrganisationMemberMasterDTO.EachSharePrice > 0) ? OrganisationMemberMasterDTO.EachSharePrice : new decimal();
            }
            set
            {
                OrganisationMemberMasterDTO.EachSharePrice = value;
            }
        }
        public string CentreCode
        {
            get
            {
                return (OrganisationMemberMasterDTO != null) ? OrganisationMemberMasterDTO.CentreCode : string.Empty;
            }
            set
            {
                OrganisationMemberMasterDTO.CentreCode = value;
            }
        }
        public string CentreName
        {
            get
            {
                return (OrganisationMemberMasterDTO != null) ? OrganisationMemberMasterDTO.CentreName : string.Empty;
            }
            set
            {
                OrganisationMemberMasterDTO.CentreName = value;
            }
        }
        public string FirstName
        {
            get
            {
                return (OrganisationMemberMasterDTO != null) ? OrganisationMemberMasterDTO.FirstName : string.Empty;
            }
            set
            {
                OrganisationMemberMasterDTO.FirstName = value;
            }
        }
        public string MiddleName
        {
            get
            {
                return (OrganisationMemberMasterDTO != null) ? OrganisationMemberMasterDTO.MiddleName : string.Empty;
            }
            set
            {
                OrganisationMemberMasterDTO.MiddleName = value;
            }
        }
        public string LastName
        {
            get
            {
                return (OrganisationMemberMasterDTO != null) ? OrganisationMemberMasterDTO.LastName : string.Empty;
            }
            set
            {
                OrganisationMemberMasterDTO.LastName = value;
            }
        }
        public string TransDate
        {
            get
            {
                return (OrganisationMemberMasterDTO != null) ? OrganisationMemberMasterDTO.TransDate : string.Empty;
            }
            set
            {
                OrganisationMemberMasterDTO.TransDate = value;
            }
        }
        public bool IsDeleted
        {
            get
            {
                return (OrganisationMemberMasterDTO != null) ? OrganisationMemberMasterDTO.IsDeleted : false;
            }
            set
            {
                OrganisationMemberMasterDTO.IsDeleted = value;
            }
        }
        public int CreatedBy
        {
            get
            {
                return (OrganisationMemberMasterDTO != null && OrganisationMemberMasterDTO.CreatedBy > 0) ? OrganisationMemberMasterDTO.CreatedBy : new int();
            }
            set
            {
                OrganisationMemberMasterDTO.CreatedBy = value;
            }
        }
        public DateTime CreatedDate
        {
            get
            {
                return (OrganisationMemberMasterDTO != null) ? OrganisationMemberMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                OrganisationMemberMasterDTO.CreatedDate = value;
            }
        }
        public int? ModifiedBy
        {
            get
            {
                return (OrganisationMemberMasterDTO != null && OrganisationMemberMasterDTO.ModifiedBy.HasValue) ? OrganisationMemberMasterDTO.ModifiedBy : new int();
            }
            set
            {
                OrganisationMemberMasterDTO.ModifiedBy = value;
            }
        }
        public DateTime? ModifiedDate
        {
            get
            {
                return (OrganisationMemberMasterDTO != null && OrganisationMemberMasterDTO.ModifiedDate.HasValue) ? OrganisationMemberMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                OrganisationMemberMasterDTO.ModifiedDate = value;
            }
        }
        public int? DeletedBy
        {
            get
            {
                return (OrganisationMemberMasterDTO != null && OrganisationMemberMasterDTO.DeletedBy.HasValue) ? OrganisationMemberMasterDTO.DeletedBy : new int();
            }
            set
            {
                OrganisationMemberMasterDTO.DeletedBy = value;
            }
        }
        public DateTime? DeletedDate
        {
            get
            {
                return (OrganisationMemberMasterDTO != null && OrganisationMemberMasterDTO.DeletedDate.HasValue) ? OrganisationMemberMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                OrganisationMemberMasterDTO.DeletedDate = value;
            }
        }
        public string errorMessage { get; set; }
        public string EntityLevel
        {
            get
            {
                return (OrganisationMemberMasterDTO != null) ? OrganisationMemberMasterDTO.EntityLevel : string.Empty;
            }
            set
            {
                OrganisationMemberMasterDTO.EntityLevel = value;
            }
        }
    }
}
