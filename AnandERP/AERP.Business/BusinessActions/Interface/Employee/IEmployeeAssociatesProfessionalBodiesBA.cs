using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessAction
{
    public interface IEmployeeAssociatesProfessionalBodiesBA
    {
        IBaseEntityResponse<EmployeeAssociatesProfessionalBodies> InsertEmployeeAssociatesProfessionalBodies(EmployeeAssociatesProfessionalBodies item);
        IBaseEntityResponse<EmployeeAssociatesProfessionalBodies> UpdateEmployeeAssociatesProfessionalBodies(EmployeeAssociatesProfessionalBodies item);
        IBaseEntityResponse<EmployeeAssociatesProfessionalBodies> DeleteEmployeeAssociatesProfessionalBodies(EmployeeAssociatesProfessionalBodies item);
        IBaseEntityCollectionResponse<EmployeeAssociatesProfessionalBodies> GetBySearch(EmployeeAssociatesProfessionalBodiesSearchRequest searchRequest);
        IBaseEntityResponse<EmployeeAssociatesProfessionalBodies> SelectByID(EmployeeAssociatesProfessionalBodies item);
    }
}
