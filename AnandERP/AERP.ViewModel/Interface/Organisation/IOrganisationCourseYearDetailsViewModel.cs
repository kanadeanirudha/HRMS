using AMS.DTO;
using System;
using System.Collections.Generic;

namespace AMS.ViewModel
{
    public interface IOrganisationCourseYearDetailsViewModel
    {

        OrganisationCourseYearDetails OrganisationCourseYearDetailsDTO
        {
            get;
            set;
        }
   
        int ID
        {
            get;
            set;
        }

        int StreamID
        {
            get;
            set;
        }


        int BranchID
        {
            get;
            set;
        }

        int MediumID
        {
            get;
            set;
        }

        int Duration
        {
            get;
            set;
        }

        string Description
        {
            get;
            set;
        }

        bool BranchActive
        {
            get;
            set;
        }
        int SectionCapacity
        {
            get;
            set;
        }
        string ExamApplicable
        {
            get;
            set;
        }

          string NextCourseYearDetailID
        {
            get;
            set;
        }
          string ExamPattern
        {
            get;
            set;
        }
        
        int NumberOfSemester
        {
            get;
            set;
        }
            string CourseYearCode

        {
            get;
            set;
        }
            string DegreeName
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

    }
    public interface IOrganisationCourseYearDetailsBaseViewModel
    {


    }
}
