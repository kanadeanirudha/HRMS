using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public interface IGeneralTaskModelViewModel
    {
         GeneralTaskModel GeneralTaskModelDTO
        {
            get;
            set;
        }
         //-------------------------------GeneralTaskReportingMaster ------------------------------------
          int ID
         {
             get;
             set;
         }
          string TaskCode
         {
             get;
             set;
         }
          string TaskDescription
         {
             get;
             set;
         }
          string MenuCode
         {
             get;
             set;
         }
          string TaskModelApplicableTo
         {
             get;
             set;
         }
          bool IsActive
         {
             get;
             set;
         }
          string LinkMenuCode
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
          string MenuLink { get; set; }
          string MenuName{ get; set; }


          List<GeneralTaskModel> MenuCodeList { get; set; }
          List<GeneralTaskModel> LinkMenuCodeList { get; set; }
        
    }
}
