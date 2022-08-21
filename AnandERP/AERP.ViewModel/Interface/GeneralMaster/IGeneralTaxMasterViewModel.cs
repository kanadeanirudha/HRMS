using AERP.DTO;
using System;
using System.Collections.Generic;

namespace AERP.ViewModel
{
    public interface IGeneralTaxMasterViewModel
    {
        GeneralTaxMaster GeneralTaxMasterDTO
        {
            get;
            set;
        }
        int ID { get; set; }
        string TaxName { get; set; }
        decimal TaxRate { get; set; }
        bool IsCompoundTax { get; set; }
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
