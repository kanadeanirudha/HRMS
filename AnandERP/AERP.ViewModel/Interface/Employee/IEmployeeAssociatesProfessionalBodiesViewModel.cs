using AMS.DTO;
using System;
using System.Collections.Generic;

namespace AMS.ViewModel
{
    public interface IEmployeeAssociatesProfessionalBodiesViewModel
    {
        EmployeeAssociatesProfessionalBodies EmployeeAssociatesProfessionalBodiesDTO
        {
            get;
            set;
        }
       int EmployeeID
        {
            get;
            set;
        }
      string ActivityName
        {
            get;
            set;
        }
       string FromPeriod
        {
            get;
            set;
        }
       string UptoPeriod
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
        string errorMessage { get; set; }
    }


}

