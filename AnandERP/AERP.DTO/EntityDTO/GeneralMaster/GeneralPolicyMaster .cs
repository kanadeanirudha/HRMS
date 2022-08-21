using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class GeneralPolicyMaster : BaseDTO
    {
        public int ID
        {
            get;
            set;
        }
        public string PolicyCode		
        {
            get;
            set;
        }
        public string PolicyName		
        {
            get;
            set;
        }
        public string PolicyDescription		
        {
            get;
            set;
        }
        public string PolicyRelatedToModuleCode		
        {
            get;
            set;
        }
        public string PolicyApplicableStatus	
        {
            get;
            set;
        }
        public bool IsPolicyActive { get; set; }

        //Fields from Table GeneralPolicyRules
        public string PolicyRange
        {
            get;
            set;
        }
        public string PolicyDefaultAnswer
        {
            get;
            set;
        }
        public string PolicyAnsType
        {
            get;
            set;
        }
        public string RangeSeparateBy
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
    }
}
