using AERP.Base.DTO;
using AERP.DTO;
using AERP.ExceptionManager;
using AERP.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using AERP.Common;
using AERP.Business.BusinessAction;

namespace AERP.Web.UI.Controllers
{
    public class LeaveAvailedController : BaseController
    {
        ILeaveAvailedBA _ILeaveAvailedBA = null;
        ILeaveAvailedViewModel _LeaveAvailedViewModel = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public LeaveAvailedController()
        {
            _ILeaveAvailedBA = new LeaveAvailedBA();
            _LeaveAvailedViewModel = new LeaveAvailedViewModel();
        }

        //  Controller Methods
        #region Controller Methods
        
        [HttpGet]
        public ActionResult RequestApproval(int PersonID, string TNDID, string TNMID, string GTRDID1, string TaskCode, string StageSequenceNumber, string IsLast,string IsActiveMember)
        {
            _LeaveAvailedViewModel.PersonID = Convert.ToInt32(PersonID);
            _LeaveAvailedViewModel.TaskNotificationDetailsID = Convert.ToInt32(TNDID);
            _LeaveAvailedViewModel.TaskNotificationMasterID = Convert.ToInt32(TNMID);
            _LeaveAvailedViewModel.GeneralTaskReportingDetailsID = Convert.ToInt32(GTRDID1);
            _LeaveAvailedViewModel.TaskCode = TaskCode;
            _LeaveAvailedViewModel.StageSequenceNumber = Convert.ToInt32(StageSequenceNumber);
            _LeaveAvailedViewModel.IsLastRecord = Convert.ToBoolean(IsLast);
            _LeaveAvailedViewModel.IsActiveMember = Convert.ToBoolean(IsActiveMember);
            //_LeaveAvailedViewModel.LeaveDescription = LeaveDescription.Replace('~', ' ');

            return View("/Views/Leave/LeaveAvailed/RequestApproval.cshtml", _LeaveAvailedViewModel);
        }

        [HttpGet]
        public ActionResult RequestApprovalV2(int PersonID, string TNDID, string TNMID, string GTRDID1, string TaskCode, string StageSequenceNumber, string IsLast, string IsActiveMember)
        {
            _LeaveAvailedViewModel.PersonID = Convert.ToInt32(PersonID);
            _LeaveAvailedViewModel.TaskNotificationDetailsID = Convert.ToInt32(TNDID);
            _LeaveAvailedViewModel.TaskNotificationMasterID = Convert.ToInt32(TNMID);
            _LeaveAvailedViewModel.GeneralTaskReportingDetailsID = Convert.ToInt32(GTRDID1);
            _LeaveAvailedViewModel.TaskCode = TaskCode;
            _LeaveAvailedViewModel.StageSequenceNumber = Convert.ToInt32(StageSequenceNumber);
            _LeaveAvailedViewModel.IsLastRecord = Convert.ToBoolean(IsLast);
            _LeaveAvailedViewModel.IsActiveMember = Convert.ToBoolean(IsActiveMember);
            //_LeaveAvailedViewModel.LeaveDescription = LeaveDescription.Replace('~', ' ');

            return View("/Views/Leave/LeaveAvailed/RequestApprovalV2.cshtml", _LeaveAvailedViewModel);
        }

        [HttpPost]
        public ActionResult RequestApproval(LeaveAvailedViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.LeaveAvailedDTO != null)
                    {
                        model.LeaveAvailedDTO.ConnectionString = _connectioString;
                        model.LeaveAvailedDTO.PersonID = model.PersonID;
                        model.LeaveAvailedDTO.LeaveApplicationID = model.LeaveApplicationID;
                        model.LeaveAvailedDTO.IsLastRecord = Convert.ToBoolean(model.IsLastRecord);
                        model.LeaveAvailedDTO.TaskNotificationMasterID = model.TaskNotificationMasterID;
                        model.LeaveAvailedDTO.TaskNotificationDetailsID = model.TaskNotificationDetailsID;
                        model.LeaveAvailedDTO.GeneralTaskReportingDetailsID = model.GeneralTaskReportingDetailsID;
                        model.LeaveAvailedDTO.ApprovalStatus = model.ApprovalStatus;
                        model.LeaveAvailedDTO.CentreCode = model.CentreCode;
                        model.LeaveAvailedDTO.LeaveMasterID = model.LeaveMasterID;
                        model.LeaveAvailedDTO.StageSequenceNumber = model.StageSequenceNumber;
                        model.LeaveAvailedDTO.Remark = model.Remark;
                        model.LeaveAvailedDTO.SelectedIDs = model.SelectedIDs;
                        model.LeaveAvailedDTO.TotalDays = model.TotalDays;
                        model.LeaveAvailedDTO.TotalApprovedFullDay = model.TotalApprovedFullDay;
                        model.LeaveAvailedDTO.TotalApprovedHalfDay = model.TotalApprovedHalfDay; 
                        model.LeaveAvailedDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<LeaveAvailed> response = _ILeaveAvailedBA.InsertLeaveAvailed(model.LeaveAvailedDTO);
                        model.LeaveAvailedDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    }
                    return Json(model.LeaveAvailedDTO.errorMessage, JsonRequestBehavior.AllowGet);

                }
                else
                {
                    return Json("Please review your form");
                }

            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public ActionResult RequestApprovalV2(LeaveAvailedViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.LeaveAvailedDTO != null)
                    {
                        model.LeaveAvailedDTO.ConnectionString = _connectioString;
                        model.LeaveAvailedDTO.PersonID = model.PersonID;
                        model.LeaveAvailedDTO.LeaveApplicationID = model.LeaveApplicationID;
                        model.LeaveAvailedDTO.IsLastRecord = Convert.ToBoolean(model.IsLastRecord);
                        model.LeaveAvailedDTO.TaskNotificationMasterID = model.TaskNotificationMasterID;
                        model.LeaveAvailedDTO.TaskNotificationDetailsID = model.TaskNotificationDetailsID;
                        model.LeaveAvailedDTO.GeneralTaskReportingDetailsID = model.GeneralTaskReportingDetailsID;
                        model.LeaveAvailedDTO.ApprovalStatus = model.ApprovalStatus;
                        model.LeaveAvailedDTO.CentreCode = model.CentreCode;
                        model.LeaveAvailedDTO.LeaveMasterID = model.LeaveMasterID;
                        model.LeaveAvailedDTO.StageSequenceNumber = model.StageSequenceNumber;
                        model.LeaveAvailedDTO.Remark = model.Remark;
                        model.LeaveAvailedDTO.SelectedIDs = model.SelectedIDs;
                        model.LeaveAvailedDTO.TotalDays = model.TotalDays;
                        model.LeaveAvailedDTO.TotalApprovedFullDay = model.TotalApprovedFullDay;
                        model.LeaveAvailedDTO.TotalApprovedHalfDay = model.TotalApprovedHalfDay;
                        model.LeaveAvailedDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<LeaveAvailed> response = _ILeaveAvailedBA.InsertLeaveAvailed(model.LeaveAvailedDTO);
                        model.LeaveAvailedDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    }
                    return Json(model.LeaveAvailedDTO.errorMessage, JsonRequestBehavior.AllowGet);

                }
                else
                {
                    return Json("Please review your form");
                }

            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }
        #endregion

       //  Non-Action Methods
        #region Methods
        public IEnumerable<LeaveAvailedViewModel> GetLeaveAvailedRecords(out int TotalRecords, string PersonID, string TaskNotificationMasterID)
        {
            LeaveAvailedSearchRequest searchRequest = new LeaveAvailedSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            _actionMode = Convert.ToString(TempData["ActionMode"]);
            if (Enum.TryParse(_actionMode, out actionModeEnum))     // checks actionMode i.e. Insert or Update // 
            {
                if (actionModeEnum == ActionModeEnum.Insert)        // parameters for SelectAll procedures under Insert or Update mode condition
                {                   
                    searchRequest.PersonID = Convert.ToInt32(PersonID);
                    searchRequest.TaskNotificationMasterID = Convert.ToInt32(TaskNotificationMasterID);
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {                   
                    searchRequest.PersonID = Convert.ToInt32(PersonID);
                    searchRequest.TaskNotificationMasterID = Convert.ToInt32(TaskNotificationMasterID);
                }
            }
            else
            {              
                searchRequest.PersonID = Convert.ToInt32(PersonID);
                searchRequest.TaskNotificationMasterID = Convert.ToInt32(TaskNotificationMasterID);
            }
            List<LeaveAvailedViewModel> listLeaveAvailedViewModel = new List<LeaveAvailedViewModel>();
            List<LeaveAvailed> listLeaveAvailed = new List<LeaveAvailed>();
            IBaseEntityCollectionResponse<LeaveAvailed> baseEntityCollectionResponse = _ILeaveAvailedBA.GetLeaveRequestForApproval_ByPersonID(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listLeaveAvailed = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (LeaveAvailed item in listLeaveAvailed)
                    {
                        LeaveAvailedViewModel _LeaveAvailedViewModel = new LeaveAvailedViewModel();
                        _LeaveAvailedViewModel.LeaveAvailedDTO = item;
                        listLeaveAvailedViewModel.Add(_LeaveAvailedViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listLeaveAvailedViewModel;
        }

        #endregion

        // AjaxHandler Methods
        #region AjaxHandler
        public ActionResult AjaxHandlerMyDataTableLeaveRequestApproval(JQueryDataTableParamModel param, string PersonID, string TaskNotificationMasterID)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<LeaveAvailedViewModel> filteredLeaveAvailed;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "LeaveDescription";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "LeaveDescription Like '%" + param.sSearch + "%' or LeaveRuleDescription Like '%" + param.sSearch + "%' or NumberOfLeaves Like '%" + param.sSearch + "%' or MaxLeaveAccumulated Like '%" + param.sSearch + "%' or IsLocked Like '%" + param.sSearch + "%'";         //this "if" block is added for search functionality
                    }
                    break;

                case 1:
                    _sortBy = "LeaveRuleDescription";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "LeaveDescription Like '%" + param.sSearch + "%' or LeaveRuleDescription Like '%" + param.sSearch + "%' or NumberOfLeaves Like '%" + param.sSearch + "%' or MaxLeaveAccumulated Like '%" + param.sSearch + "%' or IsLocked Like '%" + param.sSearch + "%'";         //this "if" block is added for search functionality
                    }
                    break;

                case 2:
                    _sortBy = "NumberOfLeaves";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "LeaveDescription Like '%" + param.sSearch + "%' or LeaveRuleDescription Like '%" + param.sSearch + "%' or NumberOfLeaves Like '%" + param.sSearch + "%' or MaxLeaveAccumulated Like '%" + param.sSearch + "%' or IsLocked Like '%" + param.sSearch + "%'";         //this "if" block is added for search functionality
                    }
                    break;
                case 3:
                    _sortBy = "MaxLeaveAccumulated";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "LeaveDescription Like '%" + param.sSearch + "%' or LeaveRuleDescription Like '%" + param.sSearch + "%' or NumberOfLeaves Like '%" + param.sSearch + "%' or MaxLeaveAccumulated Like '%" + param.sSearch + "%' or IsLocked Like '%" + param.sSearch + "%'";         //this "if" block is added for search functionality
                    }
                    break;
                case 4:
                    _sortBy = "IsLocked";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "LeaveDescription Like '%" + param.sSearch + "%' or LeaveRuleDescription Like '%" + param.sSearch + "%' or NumberOfLeaves Like '%" + param.sSearch + "%' or MaxLeaveAccumulated Like '%" + param.sSearch + "%' or IsLocked Like '%" + param.sSearch + "%'";         //this "if" block is added for search functionality
                    }
                    break;
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            if (!string.IsNullOrEmpty(PersonID) && !string.IsNullOrEmpty(TaskNotificationMasterID))
            {

                //string[] splitCentreCode = CentreCode.Split(':');
                var personID = PersonID;
                var RoleID = "";
                if (Session["UserType"].ToString() == "A" && Session["UserType"].ToString() != null)
                {
                    RoleID = Convert.ToString(0);
                }
                else if (Session["UserType"].ToString() != "A" && Session["UserType"].ToString() != null)
                {
                    RoleID = Session["RoleID"].ToString();
                }
                //centerCode = splitCentreCode[0];

                filteredLeaveAvailed = GetLeaveAvailedRecords(out TotalRecords, personID, TaskNotificationMasterID);
            }
            else
            {
                filteredLeaveAvailed = new List<LeaveAvailedViewModel>();
                TotalRecords = 0;
            }
            var iDisplayRecordLength = filteredLeaveAvailed.Count();
            var records = filteredLeaveAvailed.Skip(0).Take(iDisplayRecordLength);
            var result = from c in records select new[] { Convert.ToString(c.LeaveDescription + "(" + Convert.ToString(c.LeaveReason) + ")"), Convert.ToString(c.Dates), Convert.ToString(c.FullDayHalfDayFlag), Convert.ToString(c.HalfLeaveStatus), Convert.ToString(c.LeaveApplicationID + "/" + c.CentreCode + "/" + c.LeaveMasterID), Convert.ToString(c.LeaveTransactionHistoryStatus), Convert.ToString(c.ApprovalStatus), Convert.ToString(c.LeaveApplicationTransactionID), Convert.ToString(c.ActionFlag) };

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}


