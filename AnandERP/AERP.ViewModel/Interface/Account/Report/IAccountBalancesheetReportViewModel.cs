using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;

namespace AERP.ViewModel
{
    public interface IAccountBalancesheetReportViewModel
    {
        AccountBalancesheetReport AccountBalancesheetReportDTO
        {
            get;
            set;
        }
         int ID
        {
            get;
            set;
        }
         string SessionUptoDate
        {
            get;
            set;
        }
         string SessionFromDate
        {
            get;
            set;
        }
         int AccountId
        {
            get;
            set;
        }
         int AccountSessionID
        {
            get;
            set;
        }
         int AccBalsheetMstId
        {
            get;
            set;
        }
         string CentreCode
        {
            get;
            set;
        }
         bool IsZeroBalance
        {
            get;
            set;
        }
         string GroupBy
        {
            get;
            set;
        }
         bool IsSubLedger
        {
            get;
            set;
        }
         string HeadName
        {
            get;
            set;
        }
         string HeadCode
        {
            get;
            set;
        }
         string CategoryDescription
        {
            get;
            set;
        }
         string CategoryCode
        {
            get;
            set;
        }
         int CategoryID
        {
            get;
            set;
        }
         string GroupDescription
        {
            get;
            set;
        }
         int GroupID
        {
            get;
            set;
        }
         string AltGroupDescription
        {
            get;
            set;
        }
         int AltGroupID
        {
            get;
            set;
        }
        string AccountName
        {
            get;
            set;
        }
         string AccBalsheetCode
        {
            get;
            set;
        }
         string AccBalsheetTypeDesc
        {
            get;
            set;
        }
         int AccBalsheetTypeID
        {
            get;
            set;
        }
         int BalanceSheetMstID
        {
            get;
            set;
        }
         decimal TransactionAmount { get; set; }
         bool IsPosted { get; set; }
    }
}
