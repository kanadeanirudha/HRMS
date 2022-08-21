using AMS.DTO;
using System;
using System.Collections.Generic;

namespace AMS.ViewModel
{
    public interface IGeneralCasteMasterViewModel
    {

        GeneralCasteMaster GeneralCasteMasterDTO
        {
            get;
            set;
        }

        int ID
        {
            get;
            set;
        }

        int CategoryID
        {
            get;
            set;
        }

        string CategoryName
        {
            get;
            set;
        }

        string Description
        {
            get;
            set;
        }

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
        string CastName { get; set; }
    }
    public interface IGeneralCasteMasterBaseViewModel
    {

        List<GeneralCasteMaster> ListGeneralCasteMaster
        {
            get;
            set;
        }
    }
}
