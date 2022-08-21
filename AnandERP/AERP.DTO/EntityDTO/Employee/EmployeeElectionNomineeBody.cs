using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class EmployeeElectionNomineeBody : BaseDTO
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
        public int GeneralBoardUniversityID
        {
            get;
            set;
        }
        public string NameOfBoardBody
        {
            get;
            set;
        }
        public string PostHeld
        {
            get;
            set;
        }
        public string FromDate
        {
            get;
            set;
        }
        public string ToDate
        {
            get;
            set;
        }
        public string Remarks
        {
            get;
            set;
        }
        public string InActiveReason
        {
            get;
            set;
        }
        public string InActiveDate
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
