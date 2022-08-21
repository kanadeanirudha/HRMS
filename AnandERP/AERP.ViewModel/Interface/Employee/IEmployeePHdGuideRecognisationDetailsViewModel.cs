using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
	public class IEmployeePHdGuideRecognisationDetailsViewModel : BaseDTO
	{
       
        //---------------------------------------   EmployeePHdGuideRecognisationDetails Properties  ------------------------------------------//
         int ID
        {
            get;
            set;
        }
         int EmployeeID
        {
            get;
            set;
        }
         int GeneralBoardUniversityID
        {
            get;
            set;
        }
         string ApprovalSubjectName
        {
            get;
            set;
        }
         string ApprovalFromDate
        {
            get;
            set;
        }
         string ApprovalUptoDate
        {
            get;
            set;
        }
         string UniversityApprovalNumber
        {
            get;
            set;
        }
         string UniversityApprovalDate
        {
            get;
            set;
        }
         int NoOfCandidateCompletedPHd
        {
            get;
            set;
        }
         int NumberOfCandidateRegistered
        {
            get;
            set;
        }
         string Remarks
        {
            get;
            set;
        }
         bool IsActive
        {
            get;
            set;
        }
        // bool IsDeleted
        //{
        //    get;
        //    set;
        //}
        // int CreatedBy
        //{
        //    get;
        //    set;
        //}
        // DateTime CreatedDate
        //{
        //    get;
        //    set;
        //}
        // int? ModifiedBy
        //{
        //    get;
        //    set;
        //}
        // DateTime? ModifiedDate
        //{
        //    get;
        //    set;
        //}
        // int? DeletedBy
        //{
        //    get;
        //    set;
        //}
        // DateTime? DeletedDate
        //{
        //    get;
        //    set;
        //}

        //---------------------------------------   EmployeePHdGuideStudentsDetails  Properties  ------------------------------------------//
         int EmployeePHdGuideStudentsDetailsID
        {
            get;
            set;
        }
         string StudentName
        {
            get;
            set;
        }
         string Synopsis
        {
            get;
            set;
        }
         string PersuingFromDate
        {
            get;
            set;
        }
         string PersuingUptoDate
        {
            get;
            set;
        }
         string ApprovalStatus
        {
            get;
            set;
        }
         string ApprovalDate
        {
            get;
            set;
        }
         string errorMessage { get; set; }
         //bool StatusFlag { get; set; }
	}
}
