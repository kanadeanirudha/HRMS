using AERP.DTO;
using System;
using System.Collections.Generic;
namespace AERP.ViewModel
{
    public interface IGeneralLocationMasterViewModel
    {
        GeneralLocationMaster GeneralLocationMasterDTO { get; set; }
         int ID { get; set; }
         bool DefaultFlag { get; set; }
         int RegionID { get; set; }
         int CountryID { get; set; }
         string CountryName { get; set; }
         string RegionName { get; set; }
         string Description { get; set; }
         string LocationAddress { get; set; }
         string PostCode { get; set; }
         int CityID { get; set; }
         string Latitude { get; set; }
         string Longitude { get; set; }
         Nullable<bool> IsDeleted { get; set; }
         Nullable<int> CreatedBy { get; set; }
         Nullable<System.DateTime> CreatedDate { get; set; }
         Nullable<int> ModifiedBy { get; set; }
         Nullable<System.DateTime> ModifiedDate { get; set; }
         Nullable<int> DeletedBy { get; set; }
         Nullable<System.DateTime> DeletedDate { get; set; }
    
    }
    public interface IGeneralLocationMasterBaseViewModel
    {

        List<GeneralLocationMaster> ListGeneralLocationMaster
        {
            get;
            set;
        }
    }
}
