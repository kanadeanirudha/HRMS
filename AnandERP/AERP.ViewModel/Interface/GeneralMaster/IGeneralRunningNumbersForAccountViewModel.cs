using AERP.DTO;
using System;
using System.Collections.Generic;

namespace AERP.ViewModel
{
    public interface IGeneralRunningNumbersForAccountViewModel
    {
        GeneralRunningNumbersForAccount GeneralRunningNumbersForAccountDTO
        {
            get;
            set;
        }

        int ID
        {
            get;
            set;
        }
         string Description
        {
            get;
            set;
        }
         string KeyField
        {
            get;
            set;
        }
         Int16 FinancialYearID
        {
            get;
            set;
        }

         string CentreCode
        {
            get;
            set;
        }
         string Seperator { get; set; }
         string Prefix1
        {
            get;
            set;
        }
         string TransactionDate
        {
            get;
            set;
        }
         string DisplayFormat
        {
            get;
            set;
        }
         int StartNumber
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
        string FinancialYear { get; set; }
        string errorMessage { get; set; }
    }
}

