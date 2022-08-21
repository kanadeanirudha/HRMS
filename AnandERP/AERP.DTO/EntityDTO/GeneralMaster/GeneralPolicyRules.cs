using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class GeneralPolicyRules : BaseDTO
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
        //public string PolicyMasterCode 
        //{
        //    get;
        //    set;
        //}
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
        public int PolicyMasterID
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
        public string PolicyApplicableStatus
        {
            get;
            set;
        }
    }
}
