using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class EmployeeDocumentRequired : BaseDTO
    {
        public int ID
        {
            get;
            set;
        }
        public int DocumentID
        {
            get;
            set;
        }
        public string DocumentName
        {
            get;
            set;
        }
        public int LeaveRuleMasterID
        {
            get;
            set;
        }
        public bool DocumentCompulsaryFlag
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
        public string CentreCode
        {
            get;
            set;
        }
        public string CentreName
        {
            get;
            set;
        }
        public string EntityLevel
        {
            get;
            set;
        }
        public string LeaveRuleDescription
        {
            get;
            set;
        }
        public int LeaveMasterID
        {
            get;
            set;
        }
        public string LeaveDescription
        {
            get;
            set;
        }
        public string SelectedIDs
        {
            get;
            set;
        }
    }
}
