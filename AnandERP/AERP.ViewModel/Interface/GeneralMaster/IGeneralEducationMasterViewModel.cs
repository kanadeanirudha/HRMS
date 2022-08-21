using AERP.DTO;
using System;
using System.Collections.Generic;
namespace AERP.ViewModel
{
    public interface IGeneralEducationMasterViewModel
    {
        GeneralEducationMaster GeneralEducationMasterDTO
        {
            get;
            set;
        }

        int ID
        {
            get;
            set;
        }

        string Description
        {
            get;
            set;
        }
        string Unit
        {
            get;
            set;
        }
        int EducationTypeID
        {
            get;
            set;
        }

        int NumberOfYears
        {
            get;
            set;
        }
         bool IsUserDefined { get; set; }
        Nullable<bool> IsDeleted
        {
            get;
            set;
        }

        Nullable<int> CreatedBy
        {
            get;
            set;
        }

        Nullable<System.DateTime> CreatedDate
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
    public interface IGeneralEducationMasterBaseViewModel
    {

        List<GeneralEducationMaster> ListGeneralEducationMaster
        {
            get;
            set;
        }
    }
}
