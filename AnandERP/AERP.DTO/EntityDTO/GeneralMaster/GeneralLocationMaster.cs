using System;
using AERP.Base.DTO;


namespace AERP.DTO
{
    public class GeneralLocationMaster : BaseDTO
    {
        public int ID { get; set; }
        public bool DefaultFlag { get; set; }
        public int RegionID { get; set; }
        public int CountryID { get; set; }
        public string CountryName { get; set; }
        public string RegionName { get; set; }
        public string Description { get; set; }
        public string LocationAddress { get; set; }
        public string PostCode { get; set; }
        public int CityID { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> DeletedBy { get; set; }
        public Nullable<System.DateTime> DeletedDate { get; set; }
        public string errorMessage { get; set; }
        public bool IsUserDefined { get;set; }
    }
}
