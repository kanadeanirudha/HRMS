using AERP.DTO;
using System;
namespace AERP.ViewModel
{
    public interface IGeneralMapTypeOfAccountViewModel
    {
        GeneralMapTypeOfAccount GeneralMapTypeOfAccountDTO { get; set; }
        Int32 ID { get; set; }
        Int16 GeneralTypeOfAccountId { get; set; }
        string MenuCode { get; set; }
        byte DebitCreditStatus { get; set; }
        string ControlName { get; set; }
        Int32 CreatedBy { get; set; }
        DateTime CreatedDate { get; set; }
        Int32 ModifiedBy { get; set; }
        DateTime ModifiedDate { get; set; }
        Int32 DeletedBy { get; set; }
        DateTime DeletedDate { get; set; }
        bool IsDeleted { get; set; }
    }
}
