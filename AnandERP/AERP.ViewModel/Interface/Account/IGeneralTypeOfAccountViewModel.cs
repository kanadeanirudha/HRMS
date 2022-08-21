using AERP.DTO;
using System;
namespace AERP.ViewModel
{
    public interface IGeneralTypeOfAccountViewModel
    {
        GeneralTypeOfAccount GeneralTypeOfAccountDTO { get; set; }
        Int16 ID { get; set; }
        string Name { get; set; }
        bool IsActive { get; set; }
        Int32 CreatedBy { get; set; }
        string CreatedDate { get; set; }
        Int32 ModifiedBy { get; set; }
        string ModifiedDate { get; set; }
        Int32 DeletedBy { get; set; }
        string DeletedDate { get; set; }
        bool IsDeleted { get; set; }
    }
}
