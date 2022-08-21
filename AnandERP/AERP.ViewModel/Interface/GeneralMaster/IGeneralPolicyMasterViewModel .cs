using AMS.DTO;
using System;
using System.Collections.Generic;

namespace AMS.ViewModel
{
    public interface IGeneralPolicyMasterViewModel
    {
        GeneralPolicyMaster GeneralPolicyMasterDTO
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
        string PolicyName
        {
            get;
            set;
        }
        string PolicyDescription
        {
            get;
            set;
        }
        string PolicyRelatedToModuleCode
        {
            get;
            set;
        }
        string PolicyApplicableStatus
        {
            get;
            set;
        }
        bool IsPolicyActive { get; set; }

        //Fields from Table GeneralPolicyRule
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

