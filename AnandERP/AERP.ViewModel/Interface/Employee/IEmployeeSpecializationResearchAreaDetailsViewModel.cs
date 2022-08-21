using AMS.DTO;
using System;
using System.Collections.Generic;

namespace AMS.ViewModel
{
    public interface IEmployeeSpecializationResearchAreaDetailsViewModel
    {
        EmployeeSpecializationResearchAreaDetails EmployeeSpecializationResearchAreaDetailsDTO
        {
            get;
            set;
        }
        int ID { get; set; }
        int EmployeeID { get; set; }
        string SpecializationField { get; set; }
        string ResearchArea { get; set; }
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
