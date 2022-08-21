using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;

namespace AERP.ViewModel
{

    public interface IAccountChequeBookDetailsBaseViewModel
    {
        List<AccountChequeBookDetails> ListAccountChequeBookDetails
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

    public interface IAccountChequeBookDetailsViewModel
    {
        AccountChequeBookDetails AccountChequeBookDetailsDTO
        {
            get;
            set;
        }
        int ID
        {
            get;
            set;
        }
        int ChequeBookID
        {
            get;
            set;
        }
        int ChequeNo
        {
            get;
            set;
        }
        DateTime ChequeDatetime
        {
            get;
            set;
        }
        decimal ChequeAmount
        {
            get;
            set;
        }
        string CanceledBy
        {
            get;
            set;
        }
        int TransactionSubID
        {
            get;
            set;
        }
        DateTime TransactionDatetime
        {
            get;
            set;
        }
        string ChequeStatus
        {
            get;
            set;
        }
        string ChequeDescription
        {
            get;
            set;
        }
        string CentreCode
        {
            get;
            set;
        }
        bool IsActive
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
        bool IsDeleted
        {
            get;
            set;
        }
    }
}
