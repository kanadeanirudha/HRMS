using AMS.DTO;
using System;
using System.Collections.Generic;

namespace AMS.ViewModel
{
    public interface IGeneralPackingTypeInfoViewModel
    {
        GeneralPackingTypeInfo GeneralPackingTypeInfoDTO
        {
            get;
            set;
        }

        Int32 ID
        {
            get;
            set;
        }
        Int32 ItemCodeID
        {
            get;
            set;
        }
        int UomCodeId
        {
            get;
            set;
        }
        int ItemNumber
        {
            get;
            set;
        }
         string UomCode
        {
            get;
            set;
        }
         string ItemDescription
         {
             get;
             set;
         }
         Int32 PackageTypeID
        {
            get;
            set;
        }
         string PackageType
         {
             get;
             set;
         }
          decimal QuantityPerPackage
         {
             get;
             set;
         }
        
        decimal Height
        {
            get;
            set;
        }

        decimal Length
        {
            get;
            set;
        }
        decimal Width
        {
            get;
            set;
        }

        decimal Weight
        {
            get;
            set;
        }
        decimal Volume
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
