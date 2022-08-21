using AMS.DTO;
using System;
using System.Collections.Generic;

namespace AMS.ViewModel
{
    public interface IOrganisationSectionDetailsViewModel
    {

        OrganisationSectionDetails OrganisationSectionDetailsDTO
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

          int StandardID
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

        string Descriptions
        {
            get;
            set;
        }


        int SectionID
        {
            get;
            set;
        }

        bool SectionActive
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

        string NextSectionDetailID
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
        string SectionDetailCode
        {
            get;
            set;
        }

        string DegreeName
        {
            get;
            set;
        }

        int CourseYearDetailID
        {
            get;
            set;
        }
        int BranchDetID
        {
            get;
            set;
        }
        string CentreCode
        {
            get;
            set;
        }
        int CourseStartDetID
        {
            get;
            set;
        }
        bool ActualExamPattern
        {
            get;
            set;
        }
        string OrgShiftCode
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
    public interface IOrganisationSectionDetailsBaseViewModel
    {

      
    }
}
