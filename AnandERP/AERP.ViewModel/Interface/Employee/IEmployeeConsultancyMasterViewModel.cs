using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{
     public interface IEmployeeConsultancyMasterViewModel
        {
            //---------------------------------------   EmployeeConsultancyMaster Properties  ------------------------------------------//
             int ID
            {
                get;
                set;
            }
             string ConsultancyDate
            {
                get;
                set;
            }
             string ConsultancyName
            {
                get;
                set;
            }
             string TitleOfAssignment
            {
                get;
                set;
            }
             decimal ConsultancyCost
            {
                get;
                set;
            }
             decimal EmployeeShare
            {
                get;
                set;
            }
             string AssignmentFromDate
            {
                get;
                set;
            }
             string AssignmentToDate
            {
                get;
                set;
            }
             string Remarks
            {
                get;
                set;
            }
             string CentreCode { get; set; }
             // bool IsActive
             //{
             //    get;
             //    set;
             //}
             //bool IsDeleted
             //{
             //    get;
             //    set;
             //}
             //int CreatedBy
             //{
             //    get;
             //    set;
             //}
             //DateTime CreatedDate
             //{
             //    get;
             //    set;
             //}
             //int? ModifiedBy
             //{
             //    get;
             //    set;
             //}
             //DateTime? ModifiedDate
             //{
             //    get;
             //    set;
             //}
             //int? DeletedBy
             //{
             //    get;
             //    set;
             //}
             //DateTime? DeletedDate
             //{
             //    get;
             //    set;
             //}

            //---------------------------------------   EmployeeConsultancyDetails Properties  ------------------------------------------//
             int EmpConsultancyDetID
            {
                get;
                set;
            }
             int EmployeeConsultancyMasterID
            {
                get;
                set;
            }
             int EmployeeID
            {
                get;
                set;
            }
             string ConsultingFromDate
            {
                get;
                set;
            }
             string ConsultingToDate
            {
                get;
                set;
            }
             string EmployeeRemark
            {
                get;
                set;
            }



             string errorMessage { get; set; }
       
         
    }
}
