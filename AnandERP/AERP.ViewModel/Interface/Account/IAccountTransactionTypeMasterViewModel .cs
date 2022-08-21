using AERP.DTO;
using System;
namespace AERP.ViewModel
{
    public interface IAccountTransactionTypeMasterViewModel
    {
        AccountTransactionTypeMaster AccountTransactionTypeMasterDTO 
        { get; set; }
       // int ID { get; set; }
        string TransactionTypeCode { get; set; }
        string TransactionTypeName { get; set; }
        bool IsActive { get; set; }
        bool IsDeleted { get; set; }
        Int32 CreatedBy { get; set; }
        DateTime CreatedDate { get; set; }
        Int32 ModifiedBy { get; set; }
        DateTime ModifiedDate { get; set; }
        Int32 DeletedBy { get; set; }
        DateTime DeletedDate { get; set; }
    }
}
