using AERP.DTO;
using System;
namespace AERP.ViewModel
{
    public interface IGeneralEducationTypeMasterViewModel
    {
        GeneralEducationTypeMaster GeneralEducationTypeMasterDTO
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

        int EduSequenceNumber
        {
            get;
            set;
        }
        
       bool IsDeleted
        {
            get;
            set;
        }
       bool IsUserDefined
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
