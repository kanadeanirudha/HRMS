using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public interface IGeneralTaskReportingDetailsViewModel
    {
         GeneralTaskReportingDetails GeneralTaskReportingDetailsDTO
        {
            get;
            set;
        }
         //-------------------------------GeneralTaskReportingMaster ------------------------------------
          int ID
         {
             get;
             set;
         }
          string TaskCode
         {
             get;
             set;
         }
          int NumberOfApprovalStages
         {
             get;
             set;
         }
          string CentreCode
         {
             get;
             set;
         }
          string TaskApprovalBasedTable
         {
             get;
             set;
         }
          string TaskApprovalTableDisplayField { get; set; }
          string TaskApprovalParamPrimaryKey
         {
             get;
             set;
         }
          int TaskApprovalKeyValue
         {
             get;
             set;
         }
          string ApprovalType
         {
             get;
             set;
         }
          bool IsActive
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

         //-------------------------------GeneralTaskReportingDetails  ------------------------------------
          int GeneralTaskReportingDetailsID
         {
             get;
             set;
         }
          int StageSequenceNumber
         {
             get;
             set;
         }
          int IsParallel
         {
             get;
             set;
         }
          int TaskReportingRoleID
         {
             get;
             set;
         }
          int RangeFrom
         {
             get;
             set;
         }
          int RangeUpto
         {
             get;
             set;
         }
          string RoleCentreCode
         {
             get;
             set;
         }
          int TaskAutoEscalationTime
         {
             get;
             set;
         }
          string TaskAutoEscalationFlag
         {
             get;
             set;
         }
          string UnitSpan
         {
             get;
             set;
         }
          bool IsLastStage
         {
             get;
             set;
         }

         //-------------------------------GeneralTaskIntiatedDetails  ------------------------------------  
           int GeneralTaskIntiatedDetailsID
         {
             get;
             set;
         }
           int DepartmentID
         {
             get;
             set;
         }

           string errorMessage { get; set; }
           string RoleName { get; set; }
           string DepartmentName { get; set; }
           string EmployeeName { get; set; }
           int EmployeeID { get; set; }
           string EntityLevel { get; set; }
           string TableName { get; set; }
           string PrimaryKey { get; set; }
           string PrimaryKeyValue { get; set; }
           string CentreName { get; set; }
           string KeyValueXmlString { get; set; }
           string SelectedApprovalStageDetailsXMLstring { get; set; }
           int GeneralTaskReportingMasterID { get; set; }
           string TaskDescription { get; set; }
           int RoleID { get; set; }
           string TaskApprovalTableDisplayFieldValue { get;set;}
          List<GeneralTaskReportingDetails> TaskReportingRoleIDsList { get; set; }
          List<GeneralTaskReportingDetails> OrganisationDepartmentList { get; set; }
          List<AdminRoleApplicableDetails> ListGetAdminRoleApplicableCentre
          {
              get;
              set;
          }
          List<GeneralTaskReportingDetails> TaskApprovalBasedTableList
          {
              get;
              set;
          }
          List<GeneralTaskReportingDetails> GeneralTaskModelList
          {
              get;
              set;
          }
          //List<GeneralTaskReportingDetails> TaskApprovalParamPrimaryKeyList
          //{
          //    get;
          //    set;
          //}
          //List<GeneralTaskReportingDetails> TaskApprovalKeyValueList
          //{
          //    get;
          //    set;
          //}
    }
}
