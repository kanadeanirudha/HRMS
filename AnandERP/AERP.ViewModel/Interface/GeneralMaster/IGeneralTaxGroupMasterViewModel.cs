using AERP.DTO;
using System;

namespace AERP.ViewModel
{
    public interface IGeneralTaxGroupMasterViewModel
    {
        GeneralTaxGroupMaster GeneralTaxGroupMasterDTO
        {
            get;
            set;
        }

        int ID
        {
            get;
            set;
        }

        string TaxGroupName
        {
            get;
            set;
        }
       int TaxMasterID
        {
            get;
            set;
        }
      String TaxName
        { get; set; }

        bool IsDeleted
        {
            get;
            set;
        }

        int CreatedBy
        {
            get;
            set;
        }

        DateTime CreatedDate
        {
            get;
            set;
        }

        int? ModifiedBy
        {
            get;
            set;
        }

        DateTime? ModifiedDate
        {
            get;
            set;
        }

        int? DeletedBy
        {
            get;
            set;
        }

        DateTime? DeletedDate
        {
            get;
            set;
        }
    }
}
