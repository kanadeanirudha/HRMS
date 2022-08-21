using AERP.DTO;
using System;
using System.Collections.Generic;

namespace AERP.ViewModel
{
    public interface IGeneralPriceListAndListLineViewModel
    {
        GeneralPriceListAndListLine GeneralPriceListAndListLineDTO
        {
            get;
            set;
        }
         Int16 GeneralPriceListID
        {
            get;
            set;
        }
         string PriceListName
        {
            get;
            set;
        }
         bool IsRoot
        {
            get;
            set;
        }
         bool IsUpdationAutomatic
        {
            get;
            set;
        }
        //**************************************//
          Int16 GeneralPriceListLineID
         {
             get;
             set;
         }
          Int16 BasePriseListID
         {
             get;
             set;
         }
          decimal Factor
         {
             get;
             set;
         }
          byte RoundingMethod
         {
             get;
             set;
         }
          Int16 PriceGroupId
         {
             get;
             set;
         }
          string ValidFromDate
         {
             get;
             set;
         }
          string GeneralPriceGroupCode
          {
              get;
              set;
          }
          string GeneralPriceGroupDescription
          {
              get;
              set;
          }
         
          string ValidUptoDate
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
