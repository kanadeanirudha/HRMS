using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{
    public interface IEmployeePrizesWonDetailsViewModel
    {
        EmployeePrizesWonDetails EmployeePrizesWonDetailsDTO
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
          int GeneralLevelMasterID
         {
             get;
             set;
         }
          string PrizeName
         {
             get;
             set;
         }
          string PrizeGivenBy
         {
             get;
             set;
         }
          string PrizeReceivingDate
         {
             get;
             set;

         }
          string PrizeIssuingAuthority
         {
             get;
             set;
         }
          string Remark
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
