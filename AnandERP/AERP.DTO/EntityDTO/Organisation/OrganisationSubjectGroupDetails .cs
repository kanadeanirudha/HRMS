using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class OrganisationSubjectGroupDetails : BaseDTO
    {
        public int ID
        {
            get;
            set;
        }
        public string CentreCode
        {
            get;
            set;
        }
        public int UniversityID
        {
            get;
            set;
        }
        public int SubjectID
        {
            get;
            set;
        }
        public string ShortDescription
        {
            get;
            set;
        }
        public string Description
        {
            get;
            set;
        }
        public int OrgSemesterMstID
        {
            get;
            set;
        }
        public int CourseYearDetailID
        {
            get;
            set;
        }
        public int SubjectRuleGrpNumber
        {
            get;
            set;
        }
        public string CompulsoryOptionalFlag
        {
            get;
            set;
        }
        public string UniversityCode
        {
            get;
            set;
        }
        public string Pattern
        {
            get;
            set;
        }
        public string ElectiveGroupFlag
        {
            get;
            set;
        }
        public int OrgElectiveGrpID
        {
            get;
            set;
        }
        public string ElectiveGroupName
        {
            get;
            set;
        }
        public string ElectiveSubGroupFlag
        {
            get;
            set;
        }
        public int OrgSubElectiveGrpID
        {
            get;
            set;
        }
        public string OrgSubElectiveGrpDescription
        {
            get;
            set;
        }
        public string ElectiveSubjectCompFlag
        {
            get;
            set;
        }
        public bool IsElectiveSubjectCompFlag
        {
            get;
            set;
        }
        public bool IsActive
        {
            get;
            set;
        }
        public bool IsDeleted
        {
            get;
            set;
        }
        public int CreatedBy
        {
            get;
            set;
        }
        public DateTime CreatedDate
        {
            get;
            set;
        }
        public int? ModifiedBy
        {
            get;
            set;
        }
        public DateTime? ModifiedDate
        {
            get;
            set;
        }
        public int? DeletedBy
        {
            get;
            set;
        }
        public DateTime? DeletedDate
        {
            get;
            set;
        }
        public bool IsCompulsory
        {
            get;
            set;
        }


       
        public string BranchDescription
        {
            get;
            set;
        }
        public string CourseYearCode
        {
            get;
            set;
        }
       public string OrgSemesterName
       {
            get;
            set;
       }
       public string SemesterType
       {
           get;
           set;
       }
             public string RuleName
       {
           get;
           set;
       }
       public string ConcateField
       {
           get;
           set;
       }
       public int OrgSubjectGrpRuleID
        {
            get;
            set;
        }

       public bool StatusFlag
        {
            get;
            set;
        }

        //Datatable Variable

       public bool Select_Row
       {
           get;
           set;
       }
       public int SubjectTypeID
       {
           get;
           set;

       }

       public string SubjectType_Row
       {
           get;
           set;
       }

       public bool Internal_Row
       {
           get;
           set;

       }
       public int Internal_Max_Marks
       {
           get;
           set;
       }
       public int SubjectCombgrpID
       {
           get;
           set;
       }
       public int SubjectGrpMarksID
       {
           get;
           set;
       }
       public int Internal_Passing_Marks
       {
           get;
           set;

       }
       public bool External_Row
       {
           get;
           set;
       }
       public int External_Max_Marks
       {
           get;
           set;

       }
       public int External_Passing_Marks
       {
           get;
           set;

       }
       public int External_Group_Max_Marks
       {
           get;
           set;

       }
       public int External_Group_Min_Marks
       {
           get;
           set;

       }
       public int WeeklyPeriodAllocation
       {
           get;
           set;

       }
       public int SubHoursGrpAllocationID
       {
           get;
           set;

       }
       public double ExamHours
       {
           get;
           set;

       }
       public string SubjectGrpCombinationIDs
       {
           get;
           set;

       }
       public string SubHoursGrpAllocationIDs
       {
           get;
           set;

       }
       public string SubjectGrpMarksIDs
       {
           get;
           set;

       }

       public int SessionID
       {
           get;
           set;

       }
       public string errorMessage { get; set; }
    }
}
