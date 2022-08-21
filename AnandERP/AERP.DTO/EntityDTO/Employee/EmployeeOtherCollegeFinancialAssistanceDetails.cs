using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class EmployeeOtherCollegeFinancialAssistanceDetails : BaseDTO
    {
        public int ID
        {
            get;
            set;
        }
        public int EmployeeID
        {
            get;
            set;
        }
        public string FundingAgency
        {
            get;
            set;
        }
        public string DateOfGrantReceived
        {
            get;
            set;
        }
        public decimal AmountOfGrant
        {
            get;
            set;
        }
        public string PurposeOfGrant
        {
            get;
            set;
        }
        public string Remarks
        {
            get;
            set;
        }
      
        public bool IsActive
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
        public int? ModifiedBy
        {
            get;
            set;
        }
        public DateTime? ModifiedDate
        {
            get;
            set;
        }
        public int? DeletedBy
        {
            get;
            set;
        }
        public DateTime? DeletedDate
        {
            get;
            set;
        }


        public string errorMessage { get; set; }
    }
}
