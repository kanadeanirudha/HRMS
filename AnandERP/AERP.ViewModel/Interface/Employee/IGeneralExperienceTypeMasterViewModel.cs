using AERP.DTO;
using System;
using System.Collections.Generic;

namespace AERP.ViewModel.Interface.Employee
{
    public interface IGeneralExperienceTypeMasterViewModel
    {
        GeneralExperienceTypeMaster GeneralExperienceTypeMasterDTO
        {
            get;
            set;
        }
        int ID { get; set; }
        string ExperienceTypeDescription { get; set; }
        int IsActive { get; set; }
        bool IsDeleted { get; set; }
        int CreatedBy { get; set; }
        System.DateTime CreatedDate { get; set; }
        int ModifiedBy { get; set; }
        System.DateTime ModifiedDate { get; set; }
        int DeletedBy { get; set; }
        System.DateTime DeletedDate { get; set; }
        string errorMessage { get; set; }
    }
}
