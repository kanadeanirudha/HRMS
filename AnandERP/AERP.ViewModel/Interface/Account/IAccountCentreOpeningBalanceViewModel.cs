using AERP.DTO;
using System;
using System.Collections.Generic;

namespace AERP.ViewModel
{
    public interface IAccountCentreOpeningBalanceViewModel
    {
        AccountCentreOpeningBalance AccountCentreOpeningBalanceDTO { get; set; }
         int ID { get; set; }         
         Int16 AccBalsheetMstID { get; set; }
         Nullable<Int16> AccSessionID { get; set; }
         Int16 AccountID { get; set; }
         Nullable<System.DateTime> OpeningDatetime { get; set; }
         Nullable<decimal> OpeningBalance { get; set; }
         Nullable<decimal> TotalDebitAmount { get; set; }
         Nullable<decimal> TotalCreditAmount { get; set; }
         Nullable<decimal> ClosingBalance { get; set; }
         bool IsActive { get; set; }
         Nullable<int> CreatedBy { get; set; }
         Nullable<System.DateTime> CreatedDate { get; set; }
         Nullable<int> ModifiedBy { get; set; }
         Nullable<System.DateTime> ModifiedDate { get; set; }
         Nullable<int> DeletedBy { get; set; }
         Nullable<System.DateTime> DeletedDate { get; set; }
         bool IsDeleted { get; set; }
         string BalancesheetName { get; set; }


        /// <summary>
        /// properties of table AccountIndividualOpeningBalance
        /// </summary>

         int AccIndiOpeningBalID { get; set; }
         string PersonType { get; set; }
         Nullable<int> PersonID { get; set; }
         string CarryForward { get; set; }

        /// <summary>
        /// properties required for select all procedure
        /// </summary>
         string AccountCode { get; set; }
         string AccountName { get; set; }
         string HeadCode { get; set; }

        /// <summary>
        /// properties required for USP_AccIndividualOpeningBalance_SelectAll procedure
        /// </summary>

         string PersonName { get; set; }
         int StudentID { get; set; }

    }

    public interface IAccountCentreOpeningBalanceBaseViewModel
    {
    
    }
}
