using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{
    public interface IEmployeeElectionNomineeBodyViewModel
    {
        EmployeeElectionNomineeBody EmployeeElectionNomineeBodyDTO
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
        int GeneralBoardUniversityID
        {
            get;
            set;
        }
        string NameOfBoardBody
        {
            get;
            set;
        }
        string PostHeld
        {
            get;
            set;
        }
        string FromDate
        {
            get;
            set;
        }
        string ToDate
        {
            get;
            set;
        }
        string Remarks
        {
            get;
            set;
        }
        bool IsActive
        {
            get;
            set;
        }
        string InActiveReason
        {
            get;
            set;
        }
        string InActiveDate
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
        DateTime? ModifiedDate
        {
            get;
            set;
        }
        int? DeletedBy
        {
            get;
            set;
        }
        DateTime? DeletedDate
        {
            get;
            set;
        }
    }
}
