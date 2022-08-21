using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{
    public interface IEmployeeLanguageDetailsViewModel
    {
        EmployeeLanguageDetails EmployeeLanguageDetailsDTO
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

         string EmployeeCode
         {
             get;
             set;
         }

         int EmployeeName
         {
             get;
             set;
         }

		 int LanguageID
		{
			get;
			set;
		}
         string CanRead
         {
             get;
             set;
         }
         string CanWrite
         {
             get;
             set;
         }
         string CanSpeak
         {
             get;
             set;
         }
         string SelectedIDs
         {
             get;
             set;
         }
        
        // string Fluency
        //{
        //    get;
        //    set;
        //}
        // string Competency
        //{
        //    get;
        //    set;
        //}
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
