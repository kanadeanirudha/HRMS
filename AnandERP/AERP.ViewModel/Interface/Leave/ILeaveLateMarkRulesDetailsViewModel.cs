using System;
using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
namespace AERP.ViewModel
{
    public interface ILeaveLateMarkRulesDetailsViewModel
    {
        LeaveLateMarkRulesDetails LeaveLateMarkRulesDetailsDTO
        {
            get;
            set;
        }
        int ID
        {
            get;
            set;
        }
        string LateMarkRuleName
        {
            get;
            set;
        }
        Int16 LateMarkCount
        {
            get;
            set;
        }
        decimal NumberLeaveDeducted
        {
            get;
            set;
        }
        int LeaveID1
        {
            get;
            set;
        }
        string LeaveID2
        {
            get;
            set;
        }
        string LeaveID3
        {
            get;
            set;
        }
        string LeaveID4
        {
            get;
            set;
        }
        string LeaveID5
        {
            get;
            set;
        }
        string LeaveDetails
        {
            get;
            set;
        }
        string CentreCode
        {
            get;
            set;
        }
        string CentreName
        {
            get;
            set;
        }
        string EntityLevel
        {
            get;
            set;
        }
        bool IsActive
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
        int? ModifiedBy
        {
            get;
            set;
        }
        DateTime ModifiedDate
        {
            get;
            set;
        }
        int? DeletedBy
        {
            get;
            set;
        }
        DateTime DeletedDate
        {
            get;
            set;
        }
        List<AdminRoleApplicableDetails> ListGetAdminRoleApplicableCentre
        {
            get;
            set;
        }


    }
}
