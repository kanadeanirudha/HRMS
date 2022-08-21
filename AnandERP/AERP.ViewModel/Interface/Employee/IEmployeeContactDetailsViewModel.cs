using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
     public interface IEmployeeContactDetailsViewModel
        {
        EmployeeContactDetails EmployeeContactDetailsDTO
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
         string AddressType
        {
            get;
            set;
        }
         string EmployeeAddress1
        {
            get;
            set;
        }
         string EmployeeAddress2
        {
            get;
            set;
        }
         string PlotNumber
        {
            get;
            set;
        }
         string StreetName
        {
            get;
            set;
        }
         int CountryID
        {
            get;
            set;
        }
         int RegionID
        {
            get;
            set;
        }
         int CityID
        {
            get;
            set;
        }
         int LocationID
        {
            get;
            set;
        }
         string Pincode
        {
            get;
            set;
        }
         string TelephoneNumber
        {
            get;
            set;
        }
         string MobileNumber
        {
            get;
            set;
        }
         bool CurrentAddressFlag
        {
            get;
            set;
        }
         string CountryName
         {
             get;
             set;
         }
         string RegionName
         {
             get;
             set;
         }
         string CityName
         {
             get;
             set;
         }
         string Location
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
