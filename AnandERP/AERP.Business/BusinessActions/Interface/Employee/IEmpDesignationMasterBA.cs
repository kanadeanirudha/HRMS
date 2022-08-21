using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessAction
{
    public interface IEmpDesignationMasterBA
    {
        IBaseEntityResponse<EmpDesignationMaster> InsertEmpDesignationMaster(EmpDesignationMaster item);

        IBaseEntityResponse<EmpDesignationMaster> UpdateEmpDesignationMaster(EmpDesignationMaster item);

        IBaseEntityResponse<EmpDesignationMaster> DeleteEmpDesignationMaster(EmpDesignationMaster item);

        IBaseEntityCollectionResponse<EmpDesignationMaster> GetBySearch(EmpDesignationMasterSearchRequest searchRequest);

        IBaseEntityCollectionResponse<EmpDesignationMaster> GetBySearchList(EmpDesignationMasterSearchRequest searchRequest);

        IBaseEntityResponse<EmpDesignationMaster> SelectByID(EmpDesignationMaster item);
        IBaseEntityCollectionResponse<EmpDesignationMaster> GetBySelectList(EmpDesignationMasterSearchRequest searchRequest);
    }
}
