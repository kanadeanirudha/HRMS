using AMS.DTO;
using System;
using System.Collections.Generic;

namespace AMS.ViewModel
{
    public interface IOrganisationDirectorMasterViewModel
    {
        OrganisationDirectorMaster OrganisationDirectorMasterDTO
        {
            get;
            set;
        }
        
        int ID
        {
            get;
            set;
        }
        int OrganisationMembersMasterID
        {
            get;
            set;
        }
        bool IsLifeTimeDirector
        {
            get;
            set;
        }
        int DesignationID
        {
            get;
            set;
        }
        string JoiningDate
        {
            get;
            set;
        }
        string LeavingDate
        {
            get;
            set;
        }
        int PrintingSeqOrder
        {
            get;
            set;
        }
        string CentreCode
        {
            get;
            set;
        }
        bool IsCurrentDirector
        {
            get;
            set;
        }
        bool IsActive
        {
            get;
            set;
        }
        bool IsDeleted
        {
            get;
            set;
        }
        int CreatedBy
        {
            get;
            set;
        }
        DateTime CreatedDate
        {
            get;
            set;
        }
        int? ModifiedBy
        {
            get;
            set;
        }
        DateTime? ModifiedDate
        {
            get;
            set;
        }
        int? DeletedBy
        {
            get;
            set;
        }
        DateTime? DeletedDate
        {
            get;
            set;
        }
    }
}
