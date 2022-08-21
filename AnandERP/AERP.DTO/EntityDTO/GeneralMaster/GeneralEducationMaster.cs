using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class GeneralEducationMaster : BaseDTO
    {
        public int ID { get; set; }
        public int EducationTypeID { get; set; }
        public string Description { get; set; }
        public int NumberOfYears { get; set; }
        public bool IsUserDefined { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> DeletedBy { get; set; }
        public Nullable<System.DateTime> DeletedDate { get; set; }
        public string errorMessage { get; set; }

        public string Unit { get; set; }

    }
}
