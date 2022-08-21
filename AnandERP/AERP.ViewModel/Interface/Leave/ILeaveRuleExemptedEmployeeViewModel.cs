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
    public interface ILeaveRuleExemptedEmployeeViewModel
    {
        LeaveRuleExemptedEmployee LeaveRuleExemptedEmployeeDTO
        {
            get;
            set;
        }
        int ID
        {
            get;
            set;
        }
        int EmployeeID
        {
            get;
            set;
        }

        int LeaveMasterID
        {
            get;
            set;
        }
        int LeaveRuleMasterID
        {
            get;
            set;
        }
        string FromDate
        {
            get;
            set;
        }
        string UptoDate
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
