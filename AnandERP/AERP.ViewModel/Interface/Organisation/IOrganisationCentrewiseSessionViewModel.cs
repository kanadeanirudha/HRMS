using AMS.DTO;
using System;
using System.Collections.Generic;

namespace AMS.ViewModel
{
    public interface IOrganisationCentrewiseSessionViewModel
    {

        OrganisationCentrewiseSession OrganisationCentrewiseSessionDTO
        {
            get;
            set;
        }

        int ID
        {
            get;
            set;
        }
        int SessionID
        {
            get;
            set;
        }
        string SessionName { get; set; }
        string SessionFromDate
        {
            get;
            set;
        }
        string SessionUptoDate
        {
            get;
            set;
        }
        string ActiveSessionType
        {
            get;
            set;
        }
        string ActiveSessionFlag
        {
            get;
            set;
        }
        string CentreCode
        {
            get;
            set;
        }
        string LockStatus
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
        int ModifiedBy
        {
            get;
            set;
        }
        DateTime ModifiedDate
        {
            get;
            set;
        }
        int DeletedBy
        {
            get;
            set;
        }
        DateTime DeletedDate
        {
            get;
            set;
        }
        string errorMessage { get; set; }
    }

}
