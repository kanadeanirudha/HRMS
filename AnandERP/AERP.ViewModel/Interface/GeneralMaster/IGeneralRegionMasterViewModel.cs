using AERP.DTO;
using System;
using System.Collections.Generic;
namespace AERP.ViewModel
{
    public interface IGeneralRegionMasterViewModel
    {
        GeneralRegionMaster GeneralRegionMasterDTO
        {
            get;
            set;
        }
         int ID 
        { 
            get; 
            set; 
        }
         string RegionName 
        { 
            get; 
            set;
        }
         string CountryName
         {
             get;
             set;
         }
         Nullable<int> CountryID 
        {
            get; 
            set;
        }
         string ShortName 
        { 
            get; 
            set;
        }
         bool DefaultFlag 
        {
            get; 
            set; 
        }
         Nullable<bool> IsDeleted 
        { 
            get; 
            set; 
        }
         bool IsUserDefined { get; set; }
         Nullable<int> CreatedBy 
        { 
            get; 
            set; 
        }
         Nullable<System.DateTime> CreatedDate 
        { 
            get; 
            set; 
        }
         Nullable<int> ModifiedBy
        { 
            get; 
            set; 
        }
         Nullable<System.DateTime> ModifiedDate 
        { 
            get; 
            set; 
        }
         Nullable<int> DeletedBy 
        { 
            get; 
            set; 
        }
         Nullable<System.DateTime> DeletedDate 
        { 
            get; 
            set; 
        }
       
    }
    public interface IGeneralRegionMasterBaseViewModel
    {

        List<GeneralCountryMaster> ListGeneralCountryMaster
        {
            get;
            set;
        }
    }
}
