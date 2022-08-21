using AERP.DTO;
using System;
using System.Collections.Generic;
namespace AERP.ViewModel
{
    public interface IGeneralCityMasterViewModel
    {
        GeneralCityMaster GeneralCityMasterDTO { get; set; }
         int ID { get; set; }
          bool DefaultFlag { get; set; }
         string Description { get; set; }
         string RegionName { get; set; }
         string RegionCode { get;set; }
         Nullable<int> RegionID { get; set; }
         Nullable<bool> IsDeleted { get; set; }
         Nullable<int> CreatedBy { get; set; }
         Nullable<System.DateTime> CreatedDate { get; set; }
         Nullable<int> ModifiedBy { get; set; }
         Nullable<System.DateTime> ModifiedDate { get; set; }
         Nullable<int> DeletedBy { get; set; }
         Nullable<System.DateTime> DeletedDate { get; set; }
    }
    public interface IGeneralCityMasterBaseViewModel
    {

        List<GeneralCityMaster> ListGeneralCityMaster
        {
            get;
            set;
        }
    }
}
