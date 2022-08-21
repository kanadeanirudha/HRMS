using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public interface IEmployeeDependentsViewModel
    {
        EmployeeDependents EmployeeDependentsDTO
        {
            get;
            set;
        }
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
         int SequenceNumber
        {
            get;
            set;
        }
         string NameTitle
        {
            get;
            set;
        }
        string DependentName
        {
            get;
            set;
        }

      string RelationshipType
        {
            get;
            set;
        }
        string Address1
        {
            get;
            set;
        }
         string Address2
        {
            get;
            set;
        }
         int CityID
        {
            get;
            set;
        }
         int CountryID
         {
             get;
             set;
         }

         int RegionID
         {
             get;
             set;
         }


         string PhoneNumber
        {
            get;
            set;
        }
        string MobileNumber
        {
            get;
            set;
        }

     string GenderCode
        {
            get;
            set;
        }
         string EmployeeDependentQualification
        {
            get;
            set;
        }
      string EmployeeDependentDesignation
        {
            get;
            set;
        }
       bool GotAnyMedal
        {
            get;
            set;
        }
        string MedalReceivedDate
        {
            get;
            set;
        }
      string MedalDescription
        {
            get;
            set;
        }
       bool IsScholarshipReceived
        {
            get;
            set;
        }
       decimal ScholarshipAmount
        {
            get;
            set;
        }
       string ScholarshipStartDate
        {
            get;
            set;
        }
       string ScholarshipUptoDate
        {
            get;
            set;
        }
      string ScholarshipDescription
        {
            get;
            set;
        }
       string Hobbies
        {
            get;
            set;
        }
       string CurriculumActivity
        {
            get;
            set;
        }
        string DateOfBirth
        {
            get;
            set;
        }
       string PlaceOfBirth
        {
            get;
            set;
        }
      int GeneralRelationshipTypeMasterID
        {
            get;
            set;
        }
       int MotherTongueID
        {
            get;
            set;
        }
        string LanguageKnown
        {
            get;
            set;
        }
        int NationalityID
        {
            get;
            set;
        }
      int ReligionID
        {
            get;
            set;
        }
     int CasteID
        {
            get;
            set;
        }
        int SubCasteID
        {
            get;
            set;
        }
        int CategoryID
        {
            get;
            set;
        }
        string WeddingAnniversaryDate
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
    }
}
