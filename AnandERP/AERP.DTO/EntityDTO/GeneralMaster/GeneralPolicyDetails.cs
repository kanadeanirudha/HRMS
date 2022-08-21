using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class GeneralPolicyDetails : BaseDTO
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
        public string PolicyQuestionDescription
        {
            get;
            set;
        }
        public string PolicyDefaultAnswer
        {
            get;
            set;
        }
        public int GeneralPolicyRulesID
        {
            get;
            set;
        }
        public bool IsPolicyActive { get; set; }
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
        public string PolicyAnswered
        {
            get;
            set;
        }
        public string ApplicableFromDate 
        {
            get;
            set;
        }
        public string ApplicableUptoDate 
        {
            get;
            set; 
        }
        public string ApplicableUptoDate_Update
        {
            get;
            set;
        }
        public string ApplicableFromDate1
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
