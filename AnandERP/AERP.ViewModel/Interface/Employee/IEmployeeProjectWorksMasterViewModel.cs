using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{
     public interface IEmployeeProjectWorksMasterViewModel
        {
            //---------------------------------------   EmployeeProjectWorksMaster Properties  ------------------------------------------//
             int ID
            {
                get;
                set;
            }
             string ProjectWorkDate
            {
                get;
                set;
            }
             string ProjectWorkName
            {
                get;
                set;
            }
             decimal ProjectCost
            {
                get;
                set;
            }
             string FundingAgency
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
             Int16 Duration
            {
                get;
                set;
            }
             string DurationUnit
            {
                get;
                set;
            }
             bool ProjectStatus
            {
                get;
                set;
            }
             string Remarks
            {
                get;
                set;
            }
             string CentreCode
            {
                get;
                set;
            }


             //---------------------------------------   EmployeeProjectWorksDetails Properties  ------------------------------------------//
              int EmployeeProjectWorksDetailsID
             {
                 get;
                 set;
             }
              int EmployeeProjectWorkMasterID
             {
                 get;
                 set;
             }
              int EmployeeID
             {
                 get;
                 set;
             }
              string ProjectWorkFromDate
             {
                 get;
                 set;
             }
              string ProjectWorkToDate
             {
                 get;
                 set;
             }
              string EmployeeRemark
             {
                 get;
                 set;
             }
              string WorkAsDesignation
             {
                 get;
                 set;
             }
              bool IndividualProjectStatus
             {
                 get;
                 set;
             }
              string InActiveReason
             {
                 get;
                 set;
             }
              string InActiveDate
             {
                 get;
                 set;
             }



             string errorMessage { get; set; }
       
         
    }
}
