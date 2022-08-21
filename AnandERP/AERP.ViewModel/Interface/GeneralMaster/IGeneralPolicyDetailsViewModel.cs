using AMS.DTO;
using System;
using System.Collections.Generic;

namespace AMS.ViewModel
{
    public interface IGeneralPolicyDetailsViewModel
    {
        GeneralPolicyDetails GeneralPolicyDetailsDTO
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
        string PolicyQuestionDescription
        {
            get;
            set;
        }
        string PolicyDefaultAnswer
        {
            get;
            set;
        }
        int GeneralPolicyRulesID
        {
            get;
            set;
        }
        string CentreCode
        {
            get;
            set;
        }
        string EntityLevel
        {
            get;
            set;
        }
        string CentreName
        {
            get;
            set;
        }
        string PolicyAnswered
        {
            get;
            set;
        }
        string ApplicableFromDate
        {
            get;
            set;
        }
        string ApplicableUptoDate
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
        List<AdminRoleApplicableDetails> ListGetAdminRoleApplicableCentre
        {
            get;
            set;
        }
    }
}

