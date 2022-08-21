using System;
using System.Collections.Generic;
using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public interface ILeaveShiftAllocateToCentreViewModel
    {
        LeaveShiftAllocateToCentre LeaveShiftAllocateToCentreDTO
        {
            get;
            set;
        }

         int ID
        {
            get;
            set;
        }
         int ShiftID
        {
            get;
            set;
        }
         string ShiftDesc
        {
            get;
            set;
        }
         string CentreName
        {
            get;
            set;
        }
         string CentreCode
        {
            get;
            set;
        }
         bool Status { get; set; }
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
         string EntityLevel { get; set; }
         List<AdminRoleApplicableDetails> ListGetAdminRoleApplicableCentre
         {
             get;
             set;
         }
    }
}
