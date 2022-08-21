using System;
using System.Collections.Generic;
using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.DataProvider
{
   public  interface IGeneralTaskReportingDetailsDataProvider
    {
        /// <summary>
        /// data provider interface of select all record of GeneralTaskReportingDetails.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralTaskReportingDetails> GetGeneralTaskReportingDetailsBySearch(GeneralTaskReportingDetailsSearchRequest searchRequest);

        /// <summary>
        /// data provider interface of select all record of GeneralTaskReportingDetails.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralTaskReportingDetails> GetTaskReportingDetailsApprovalStages(GeneralTaskReportingDetailsSearchRequest searchRequest);    
   
        /// <summary>
        /// data provider interface of select all record of GeneralTaskReportingDetails.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralTaskReportingDetails> GetTaskReportingDetailsApprovalStageDetails(GeneralTaskReportingDetailsSearchRequest searchRequest);           

        /// <summary>
        /// data provider interface of select all record of GeneralTaskReportingDetails.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralTaskReportingDetails> ReportingRoleIDsSearchList(GeneralTaskReportingDetailsSearchRequest searchRequest);
       
        /// <summary>
        /// data provider interface of select all record of GeneralTaskReportingDetails.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralTaskReportingDetails> DepartmentList(GeneralTaskReportingDetailsSearchRequest searchRequest);   
       
        /// <summary>
        /// data provider interface of select all record of GeneralTaskReportingDetails.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralTaskReportingDetails> GetTaskApprovalBasedTableList(GeneralTaskReportingDetailsSearchRequest searchRequest);
        
        /// <summary>
        /// data provider interface of select all record of GeneralTaskReportingDetails.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralTaskReportingDetails> GetTaskApprovalParamPrimaryKeyList(GeneralTaskReportingDetailsSearchRequest searchRequest);
        
        /// <summary>
        /// data provider interface of select all record of GeneralTaskReportingDetails.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralTaskReportingDetails> GetTaskApprovalKeyValueList(GeneralTaskReportingDetailsSearchRequest searchRequest);

        /// <summary>
        /// data provider interface of select all record of GeneralTaskReportingDetails.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralTaskReportingDetails> GetGeneralTaskModelList(GeneralTaskReportingDetailsSearchRequest searchRequest);     
  
        /// <summary>
        /// data provider interface of select all record of GeneralTaskReportingDetails.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralTaskReportingDetails> GetTaskApprovalBaseTableDisplayFieldList(GeneralTaskReportingDetailsSearchRequest searchRequest);            

        /// <summary>
        /// data provider interface of select one record of GeneralTaskReportingDetails.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralTaskReportingDetails> GetGeneralTaskReportingDetailsByID(GeneralTaskReportingDetails item);

        /// <summary>
        /// data provider interface of insert new record of InsertGeneralTaskReportingMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralTaskReportingDetails> InsertGeneralTaskReportingMaster(GeneralTaskReportingDetails item);       

        /// <summary>
        /// data provider interface of insert new record of InsertGeneralTaskReportingMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralTaskReportingDetails> InsertGeneralTaskApprovalStageDetails(GeneralTaskReportingDetails item);              

        /// <summary>
        /// data provider interface of insert new record of GeneralTaskReportingDetails.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralTaskReportingDetails> InsertGeneralTaskReportingDetails(GeneralTaskReportingDetails item);

        /// <summary>
        /// data provider interface of update record of GeneralTaskReportingDetails.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralTaskReportingDetails> UpdateGeneralTaskReportingDetails(GeneralTaskReportingDetails item);

        /// <summary>
        /// data provider interface of dalete record of GeneralTaskReportingDetails.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralTaskReportingDetails> DeleteGeneralTaskReportingDetails(GeneralTaskReportingDetails item);

        /// <summary>
        /// data provider interface of update record of GeneralTaskReportingDetails.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralTaskReportingDetails> UpdateEnagedByUserID(GeneralTaskReportingDetails item);

        IBaseEntityResponse<GeneralTaskReportingDetails> GetTotalPendingCountTaskEmployeewise(GeneralTaskReportingDetails item);
       
    }
}
