using AMS.DTO;
using System;
using System.Collections.Generic;

namespace AMS.ViewModel
{
    public interface IGeneralPreTablesForMainTypeMasterViewModel
    {
        GeneralPreTablesForMainTypeMaster GeneralPreTablesForMainTypeMasterDTO { get; set; }

        int ID { get; set; }
        string RefTableEntity { get; set; }
        string RefTableEntityKey { get; set; }
        string RefTableEntityDisplayKey { get; set; }
        string MenuCode { get; set; }
        string ModuleCode { get; set; }
        bool IsDeleted { get; set; }
        int CreatedBy { get; set; }
        DateTime CreatedDate { get; set; }
        int? ModifiedBy { get; set; }
        DateTime? ModifiedDate { get; set; }
        int? DeletedBy { get; set; }
        DateTime? DeletedDate { get; set; }
    }
}
