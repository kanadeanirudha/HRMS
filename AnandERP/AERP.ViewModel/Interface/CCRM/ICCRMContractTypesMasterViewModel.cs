using AERP.DTO;
using System;
using System.Collections.Generic;

namespace AERP.ViewModel
{
   public interface ICCRMContractTypesMasterViewModel
    {
        CCRMContractTypesMaster CCRMContractTypesMasterDTO
        {
            get;
            set;
        }
        Int32 ID { get; set; }
        string ContractCode { get; set; }
        string ContractName { get; set; }
        byte ContractType { get; set; }
        Int32 CCRMContractTypesMasterID { get; set; }
        Int32 ItemCategoryMasterID { get; set; }
        string ItemCategoryCode { get; set; }
        Int32 CCRMContractTypeDetailsID { get; set; }
        bool IsSpares { get; set; }
        bool IsConsumables { get; set; }
        bool ISService { get; set; }
        bool IsRentMachine { get; set; }
        Nullable<bool> IsDeleted { get; set; }
        Nullable<int> CreatedBy { get; set; }
        Nullable<System.DateTime> CreatedDate { get; set; }
        Nullable<int> ModifiedBy { get; set; }
        Nullable<System.DateTime> ModifiedDate { get; set; }
        Nullable<int> DeletedBy { get; set; }
        Nullable<System.DateTime> DeletedDate { get; set; }
        string errorMessage { get; set; }
    }
}
