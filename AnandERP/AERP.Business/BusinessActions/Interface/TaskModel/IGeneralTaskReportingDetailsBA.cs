using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessAction
{
    public interface IGeneralTaskReportingDetailsBA
    {
        IBaseEntityResponse<GeneralTaskReportingDetails> InsertGeneralTaskReportingMaster(GeneralTaskReportingDetails item);
        IBaseEntityResponse<GeneralTaskReportingDetails> InsertGeneralTaskApprovalStageDetails(GeneralTaskReportingDetails item);
        IBaseEntityResponse<GeneralTaskReportingDetails> InsertGeneralTaskReportingDetails(GeneralTaskReportingDetails item);
        IBaseEntityResponse<GeneralTaskReportingDetails> UpdateGeneralTaskReportingDetails(GeneralTaskReportingDetails item);
        IBaseEntityResponse<GeneralTaskReportingDetails> DeleteGeneralTaskReportingDetails(GeneralTaskReportingDetails item);
        IBaseEntityCollectionResponse<GeneralTaskReportingDetails> GetBySearch(GeneralTaskReportingDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<GeneralTaskReportingDetails> GetTaskReportingDetailsApprovalStages(GeneralTaskReportingDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<GeneralTaskReportingDetails> GetTaskReportingDetailsApprovalStageDetails(GeneralTaskReportingDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<GeneralTaskReportingDetails> ReportingRoleIDsSearchList(GeneralTaskReportingDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<GeneralTaskReportingDetails> DepartmentList(GeneralTaskReportingDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<GeneralTaskReportingDetails> GetTaskApprovalBasedTableList(GeneralTaskReportingDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<GeneralTaskReportingDetails> GetTaskApprovalParamPrimaryKeyList(GeneralTaskReportingDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<GeneralTaskReportingDetails> GetTaskApprovalKeyValueList(GeneralTaskReportingDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<GeneralTaskReportingDetails> GetGeneralTaskModelList(GeneralTaskReportingDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<GeneralTaskReportingDetails> GetTaskApprovalBaseTableDisplayFieldList(GeneralTaskReportingDetailsSearchRequest searchRequest);
        IBaseEntityResponse<GeneralTaskReportingDetails> SelectByID(GeneralTaskReportingDetails item);
        IBaseEntityResponse<GeneralTaskReportingDetails> UpdateEnagedByUserID(GeneralTaskReportingDetails item);

        IBaseEntityResponse<GeneralTaskReportingDetails> GetTotalPendingCountTaskEmployeewise(GeneralTaskReportingDetails item);
        
    }
}
