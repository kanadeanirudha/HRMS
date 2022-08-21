using AMS.DTO;
using System;
using System.Collections.Generic;

namespace AMS.ViewModel
{
   public interface IEmployeePaperPresentViewModel
    {
        EmployeePaperPresent EmployeePaperPresentDTO
        {
            get;
            set;
        }
        //---------------------------------------EmployeePaperPresent Properties------------------------------------//
         int ID
        {
            get;
            set;
        }
         string PaperTopic
        {
            get;
            set;
        }
         string JournalName
        {
            get;
            set;
        }
         string JournalVolumeNumber
        {
            get;
            set;
        }
         string JournalPageNumber
        {
            get;
            set;
        }
         DateTime EmployeeYear
        {
            get;
            set;
        }
         string PaperType
        {
            get;
            set;
        }
         int GeneralLevelMasterID
        {
            get;
            set;
        }
         string EmployeeBookReview
        {
            get;
            set;
        }
         string EmployeeArticleReview
        {
            get;
            set;
        }
         string PublishMedium
        {
            get;
            set;
        }
         DateTime EmployeeCoferenceDateFrom
        {
            get;
            set;
        }
         string ConferenceName
        {
            get;
            set;
        }
         string EmployeeConferenceVenue
        {
            get;
            set;
        }
         DateTime PublishDate
        {
            get;
            set;
        }
         string EmployeeProceedingPageNumber
        {
            get;
            set;
        }
         string EmployeeConferenceProceeding
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


        //---------------------------------------EmployeePaperPresent Properties------------------------------------//
         int EmployeePaperPresenterID
        {
            get;
            set;
        }
         int EmployeePaperPresentID
        {
            get;
            set;
        }
         int EmployeeID
        {
            get;
            set;
        }
         string EmployeeParticipationRole
        {
            get;
            set;
        }
    }
}
