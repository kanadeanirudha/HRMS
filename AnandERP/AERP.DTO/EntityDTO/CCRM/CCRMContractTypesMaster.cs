using AERP.Base.DTO;
using System;

namespace AERP.DTO
{
   public class CCRMContractTypesMaster :BaseDTO
    {

        public int ID
        {
            get;
            set;
        }
        public int ContractTypeId
        {
            get;
            set;
        }
        public string ContractCode
        {
            get;
            set;
        }
        public string ContractName
        {
            get;
            set;
        }
        public byte ContractType
        {
            get;
            set;
        }
        public int CCRMContractTypeDetailsID { get; set; }
        public int ItemCategoryMasterID { get; set; }
        public string ItemCategoryCode { get; set; }
        public bool IsSpares { get; set; }
        public bool IsConsumables { get; set; }
        public bool ISService { get; set; }
        public bool IsRentMachine { get; set; }

        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> DeletedBy { get; set; }
        public Nullable<System.DateTime> DeletedDate { get; set; }
        public string errorMessage { get; set; }
        public string SelectedCategoryMasterIDs
        {
            get;
            set;
        }
        public string StatusFlag
        {
            get;
            set;

        }
        public bool IsActive
        {
            get;
            set;

        }

    }
}
