using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;

namespace AERP.ViewModel
{

    public interface IAccountChequeBookMasterBaseViewModel
    {
        List<AccountChequeBookMaster> ListAccountChequeBookMaster
        {
            get;
            set;
        }

        List<OrganisationStudyCentreMaster> ListOrganisationStudyCentreMaster
        {
            get;
            set;
        }

        List<AccountBalancesheetMaster> ListAccountBalancesheetMaster
        {
            get;
            set;
        }
    }

    public interface IAccountChequeBookMasterViewModel
    {
        AccountChequeBookMaster AccountChequeBookMasterDTO
        {
            get;
            set;
        }
        int ID
        {
            get;
            set;
        }
        Nullable<Int16> AccountID
        {
            get;
            set;
        }
        string AccountCode
        {
            get;
            set;
        }
        Nullable<int> ChequeFromNo
        {
            get;
            set;
        }
        Nullable<int> ChequeToNo
        {
            get;
            set;
        }
        Nullable<Int16> TotalNoCheque
        {
            get;
            set;
        }
        bool ActiveFlag
        {
            get;
            set;
        }
        string CentreCode
        {
            get;
            set;
        }
        Nullable<Int16> AccBalsheetMstID
        {
            get;
            set;
        }
        bool IsActive
        {
            get;
            set;
        }
        Nullable<int> CreatedBy
        {
            get;
            set;
        }
        Nullable<System.DateTime> CreatedDate
        {
            get;
            set;
        }
        Nullable<int> ModifiedBy
        {
            get;
            set;
        }
        Nullable<System.DateTime> ModifiedDate
        {
            get;
            set;
        }
        Nullable<int> DeletedBy
        {
            get;
            set;
        }
        Nullable<System.DateTime> DeletedDate
        {
            get;
            set;
        }
        Nullable<bool> IsDeleted
        {
            get;
            set;
        }
    }
}
