using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public interface ILeaveApplicationViewModel
    {
        LeaveApplication LeaveApplicationDTO
        {
            get;
            set;
        }

        List<AdminRoleApplicableDetails> ListGetAdminRoleApplicableCentre { get; set; }
        List<OrganisationDepartmentMaster> ListOrganisationDepartmentMaster { get; set; }

        int ID
        {
            get;
            set;
        }
        string ApplicationCode
        {
            get;
            set;
        }
        int EmployeeID
        {
            get;
            set;
        }
        int LeaveMasterID
        {
            get;
            set;
        }
        string LeaveTotalDay
        {
            get;
            set;
        }
        string SubmittedOnDate
        {
            get;
            set;
        }
        string FromDate
        {
            get;
            set;
        }
        string UptoDate
        {
            get;
            set;
        }
        Int16 TotalfullDaysLeave
        {
            get;
            set;
        }
        Int16 TotalHalfDayLeave
        {
            get;
            set;
        }
        string HalfLeaveStatus
        {
            get;
            set;
        }
        string EmployeeRemark
        {
            get;
            set;
        }
        bool DocumentRequire
        {
            get;
            set;
        }
        string LeaveReason
        {
            get;
            set;
        }
        byte LeavePriority
        {
            get;
            set;
        }
        string ApplicationStatus
        {
            get;
            set;
        }
        byte PendingAtApprovalLevel
        {
            get;
            set;
        }
        int LeaveSessionID
        {
            get;
            set;
        }
        string CancelRemark
        {
            get;
            set;
        }
        string ApplicationDate
        {
            get;
            set;
        }
        Int16 SactionedFullDay
        {
            get;
            set;
        }
        Int16 SactionedHalfDay
        {
            get;
            set;
        }
        string SactionedHalfLeaveStatus
        {
            get;
            set;
        }
        decimal TransferToLWP
        {
            get;
            set;
        }
        int ApprovedByUser
        {
            get;
            set;
        }
        string CentreCode
        {
            get;
            set;
        }
        string CancelDays
        {
            get;
            set;
        }
        int LeaveRuleMasterID
        {
            get;
            set;
        }
        int PendingJobSrNo
        {
            get;
            set;
        }
        int PendingLevelSeqNumber
        {
            get;
            set;
        }
        int SancWorkReportingMstID
        {
            get;
            set;
        }
        int PendAtWorkReportingDetailID
        {
            get;
            set;
        }
        string SactionFromDate
        {
            get;
            set;
        }
        string SactionUptoDate
        {
            get;
            set;
        }
        int AdminRoleMasterID
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
        string errorMessage { get; set; }
        bool IsSecondHalf
        {
            get;
            set;
        }
        bool IsFirstHalf
        {
            get;
            set;
        }

        string LeaveCode
        {
            get;
            set;
        }
        string LeaveDescription
        {
            get;
            set;
        }
        string NumberOfLeaves
        {
            get;
            set;
        }
        double BalanceLeave
        {
            get;
            set;
        }
        string TotalFullDayUtilized
        {
            get;
            set;
        }
        string TotalHalfDayUtilized
        {
            get;
            set;
        }
        string LeaveApplicationApprocedPendingStatusDetails
        {
            get;
            set;
        }
        int NumberOfApprovalStages
        {
            get;
            set;
        }

        List<LeaveCompensatoryWorkDay> CompensatoryWorkDayList { get; set; }
        string SelectedIDs
        {
            get;
            set;
        }


        /// <summary>
        /// fields for leave attached document//////////////////
        /// </summary>
        int LeaveAttachedDocumentID            ////////ID for Leave Attached Document
        {
            get;
            set;
        }
        int DocumentRequiredID
        {
            get;
            set;
        }
        string DateOfSubmission
        {
            get;
            set;
        }
        string FileName
        {
            get;
            set;
        }
        bool DocumentCompulsaryFlag { get; set; }
        bool DocumentRequiredFlag { get; set; }

        string DepartmentID { get; set; }
        string DepartmentName { get; set; }
        string EntityLevel { get; set; }
        string CentreName { get; set; }
        string LeaveList { get; set; }
    }
}
