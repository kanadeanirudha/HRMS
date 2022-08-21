using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class TaskNotificationSearchRequest : Request
    {
        #region -------------- TaskNotificationMaster ---------------
        public int TaskNotificationMasterID
        {
            get;
            set;
        }
        public string TaskCode
        {
            get;
            set;
        }
        public int GeneralTaskReportingMasterID
        {
            get;
            set;
        }
        public string EntitytableName
        {
            get;
            set;
        }
        public string EntityPKName
        {
            get;
            set;
        }
        public int EntityPKValue
        {
            get;
            set;
        }
        public int PersonID
        {
            get;
            set;
        }
        public string PersonType
        {
            get;
            set;
        }
        public string Status
        {
            get;
            set;
        }
        public int LastApprovalStatus
        {
            get;
            set;
        }
        public string SortOrder
        {
            get;
            set;
        }
        public string SortBy
        {
            get;
            set;
        }
        public int StartRow
        {
            get;
            set;
        }
        public int RowLength
        {
            get;
            set;
        }
        public int EndRow
        {
            get;
            set;
        }
        public string SearchBy
        {
            get;
            set;
        }
        public string SortDirection
        {
            get;
            set;
        }
        public int AdminRoleMasterID
        {
            get;
            set;
        }
        public bool IsEngaged
        {
            get;
            set;
        }
        #endregion

        #region -------------- TaskNotificationDetails --------------

        public int TaskNotificationDetailsID
        {
            get;
            set;
        }
        public int GeneralTaskReportingDetailsID
        {
            get;
            set;
        }
        public int NextGeneralTaskReportingDetailsID
        {
            get;
            set;
        }
        public bool IsLastRecordFlag
        {
            get;
            set;
        }
        public int ApprovalStatus
        {
            get;
            set;
        }
        public string MenuCodeLink
        {
            get;
            set;
        }
        public string Description
        {
            get;
            set;
        }
        public string Remark
        {
            get;
            set;
        }

        #endregion

        #region -------------- RequestNotificationDetails --------------

        public int GeneralRequestTransactionID
        {
            get;
            set;
        }

        #endregion

        public string ModuleCode { get; set; }
    }
}
