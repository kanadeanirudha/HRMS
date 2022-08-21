using AERP.DTO;
using System;
using System.Collections.Generic;

namespace AERP.ViewModel
{
    public interface IGeneralPolicyRulesViewModel
    {
        GeneralPolicyRules GeneralPolicyRulesDTO
        {
            get;
            set;
        }

        int ID
        {
            get;
            set;
        }
        string PolicyCode
        {
            get;
            set;
        }
        string PolicyQuestionDescription	
        {
            get;
            set;
        }
        string PolicyRange	
        {
            get;
            set;
        }
        string PolicyDefaultAnswer	
        {
            get;
            set;
        }
        string PolicyAnsType	
        {
            get;
            set;
        }
        string RangeSeparateBy	
        {
            get;
            set;
        }
        bool IsDeleted
        {
            get;
            set;
        }
        int CreatedBy
        {
            get;
            set;
        }
        DateTime CreatedDate
        {
            get;
            set;
        }
        int ModifiedBy
        {
            get;
            set;
        }
        DateTime ModifiedDate
        {
            get;
            set;
        }
        int DeletedBy
        {
            get;
            set;
        }
        DateTime DeletedDate
        {
            get;
            set;
        }
        string errorMessage { get; set; }
    }
}

