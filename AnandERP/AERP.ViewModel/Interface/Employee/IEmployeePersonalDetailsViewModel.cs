using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public interface IEmployeePersonalDetailsViewModel
    {
        EmployeePersonalDetails EmployeePersonalDetailsDTO
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
         string PlaceOfBirth
        {
            get;
            set;
        }
         int ReligionID
        {
            get;
            set;
        }
         int CategoryID
        {
            get;
            set;
        }
         int CasteID
        {
            get;
            set;
        }
         int SubCasteID
        {
            get;
            set;
        }
         string Hobby
        {
            get;
            set;
        }
         bool GotAnyMedal
        {
            get;
            set;
        }
         bool GotAnyScholarship
        {
            get;
            set;
        }
         string IdentifacationMark
        {
            get;
            set;
        }
         string BloodGroup
        {
            get;
            set;
        }
         string Allergy
        {
            get;
            set;
        }
         string CreditCardNumber
        {
            get;
            set;
        }
         bool ControlHead
        {
            get;
            set;
        }
         string BankAccountCode
        {
            get;
            set;
        }
         int MotherTongueID
        {
            get;
            set;
        }
         string BankCode
        {
            get;
            set;
        }
         string SelectionCasteCategory
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
         string errorMessage
        {
            get;
            set;
        }
    }
}
