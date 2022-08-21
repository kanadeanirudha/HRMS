﻿using System;
using System.Collections.Generic;
using AERP.Base.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AERP.DTO
{
    public class AccountTradingReport : BaseDTO
    {
        public int ID
        {
            get;
            set;
        }

        public string SessionUptoDate
        {
            get;
            set;
        }
        public string SessionFromDate
        {
            get;
            set;
        }
        public int AccountId
        {
            get;
            set;
        }
        public int AccountSessionID
        {
            get;
            set;
        }
        public int AccBalsheetMstId
        {
            get;
            set;
        }
        public string AccBalsheetName { get; set; }
        public string CentreCode
        {
            get;
            set;
        }
        public bool IsZeroBalance
        {
            get;
            set;
        }
        public string GroupBy
        {
            get;
            set;
        }
        public bool IsSubLedger
        {
            get;
            set;
        }
        public string HeadName
        {
            get;
            set;
        }
        public string HeadCode
        {
            get;
            set;
        }
        public string CategoryDescription
        {
            get;
            set;
        }
        public string CategoryCode
        {
            get;
            set;
        }
        public int CategoryID
        {
            get;
            set;
        }
        public string GroupDescription
        {
            get;
            set;
        }
        public string GroupCode
        {
            get;
            set;
        }
        public int GroupID
        {
            get;
            set;
        }
        public string AltGroupDescription
        {
            get;
            set;
        }
        public int AltGroupID
        {
            get;
            set;
        }
        public int AccountID
        {
            get;
            set;
        }
        public string AccountName
        {
            get;
            set;
        }
        public string AccountCode
        {
            get;
            set;
        }
        public string AccBalsheetCode
        {
            get;
            set;
        }
        public string AccBalsheetTypeDesc
        {
            get;
            set;
        }
        public int AccBalsheetTypeID
        {
            get;
            set;
        }
        public int BalanceSheetMstID
        {
            get;
            set;
        }
        public bool IsPosted { get; set; }
        public decimal OpeningBalanceDebit
        {
            get;
            set;
        }
        public decimal OpeningBalanceCerdit
        {
            get;
            set;
        }
        public decimal TotalDebit
        {
            get;
            set;
        }
        public decimal OpeningBalance
        {
            get;
            set;
        }
        public decimal TotalCredit
        {
            get;
            set;
        }
        public decimal ClosingBalance
        {
            get;
            set;
        }
        public decimal ClosingDebitAmount
        {
            get;
            set;
        }
        public decimal ClosingCreditAmount
        {
            get;
            set;
        }
        public decimal TotalBalanceSum
        {
            get;
            set;
        }
       
     
    }
}
