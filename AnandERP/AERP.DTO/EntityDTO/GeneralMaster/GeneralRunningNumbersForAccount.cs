using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class GeneralRunningNumbersForAccount : BaseDTO
    {
        public int ID
        {
            get;
            set;
        }
        public string Description		
        {
            get;
            set;
        }
        public string KeyField		
        {
            get;
            set;
        }
        public Int16 FinancialYearID
        {
            get;
            set;
        }
        public string FinancialYear { get; set; }
        
        public string CentreCode		
        {
            get;
            set;
        }
        public string Seperator { get; set; }
        public string Prefix1		
        {
            get;
            set;
        }
          public string TransactionDate		
        {
            get;
            set;
        }
          public string DisplayFormat		
        {
            get;
            set;
        }
          public int StartNumber		
        {
            get;
            set;
        }
          public int CurrentCounter		
        {
            get;
            set;
        }
        public bool IsDeleted
        {
            get;
            set;
        }
        public int CreatedBy
        {
            get;
            set;
        }
        public DateTime CreatedDate
        {
            get;
            set;
        }
        public int ModifiedBy
        {
            get;
            set;
        }
        public DateTime ModifiedDate
        {
            get;
            set;
        }
        public int DeletedBy
        {
            get;
            set;
        }
        public DateTime DeletedDate
        {
            get;
            set;
        }
        public string errorMessage { get; set; }
        public string XMLstring { get; set; }
    }
}
