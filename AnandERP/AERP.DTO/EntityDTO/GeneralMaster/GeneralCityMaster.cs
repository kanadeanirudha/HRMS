using System;
using AERP.Base.DTO;



namespace AERP.DTO
{
    public class GeneralCityMaster : BaseDTO
    {
        public int ID { get; set; }
        public bool DefaultFlag { get; set; }
        public string Description { get; set; }
        public string RegionName { get; set; }
        public Nullable<int> RegionID { get; set; }
        public string CountryName { get; set; }
        public Nullable<int> CountryID { get; set; }
        public bool IsUserDefined { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> DeletedBy { get; set; }
        public Nullable<System.DateTime> DeletedDate { get; set; }
        public string errorMessage { get; set; }
        public string RegionCode { get; set; }
        public string CountryCode { get; set; }

    }
}
