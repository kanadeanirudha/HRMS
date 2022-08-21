using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AERP.Base.DTO;
using AERP.DTO;
using AERP.ExceptionManager;
using AERP.ViewModel;
using AERP.Common;
using AERP.DataProvider;
using AERP.Business.BusinessAction;

using System.Configuration;

namespace AERP.Web.UI.Controllers
{
    public class LeaveApplicationCancelSelfController : BaseController
    {
        IEmpEmployeeMasterBA _IEmpEmployeeMasterBA = null;
        ILeaveSessionBA _ILeaveSessionBA = null;
        ILeaveApplicationBA _ILeaveApplicationBA = null;
        ILeaveSummaryBA _ILeaveSummaryBA = null;
        ILeaveApplicationViewModel _LeaveApplicationViewModel = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortOrder = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public LeaveApplicationCancelSelfController()
        {
            _IEmpEmployeeMasterBA = new EmpEmployeeMasterBA();
            _ILeaveSessionBA = new LeaveSessionBA();
            _ILeaveApplicationBA = new LeaveApplicationBA();
            _ILeaveSummaryBA = new LeaveSummaryBA();
        }
        // GET: /LeaveApplicationCancel/

        //  Controller Methods
        #region ------------------Controller Methods------------------

        public ActionResult Index()
        {
            return View("/Views/Leave/LeaveApplicationCancelSelf/Index.cshtml");
        }

        public ActionResult List(string actionMode)
        {
            try
            {
                ILeaveApplicationViewModel _leaveApplicationViewModel = new LeaveApplicationViewModel();
                _leaveApplicationViewModel.EmployeeID = Convert.ToInt32(Session["PersonID"]);
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Leave/LeaveApplicationCancelSelf/List.cshtml", _leaveApplicationViewModel);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpGet]
        public ActionResult LeaveApplicationCancelSelf()
        {
          
            List<LeaveApplication> LeaveApplicationList = GetLeaveApplicationApprocedPendingStatus_SearchList();
            List<SelectListItem> LeaveApplicationApprocedPendingStatus = new List<SelectListItem>();
            foreach (LeaveApplication item in LeaveApplicationList)
            {
                LeaveApplicationApprocedPendingStatus.Add(new SelectListItem { Text = (item.LeaveDate + "-" + item.LeaveCode + "-" + item.FullDayHalfDayDetails + "-" + item.LeaveApprovalStatus), Value = (item.ID + "~" + item.LeaveApplicationTransactionID + "~" + item.LeaveSessionID + "~" + item.LeaveMasterID).ToString().Trim() });
            }
            ViewBag.LeaveApplicationApprocedPendingStatus = new SelectList(LeaveApplicationApprocedPendingStatus, "Value", "Text");
            
            return PartialView("/Views/Leave/LeaveApplicationCancelSelf/LeaveApplicationCancelSelf.cshtml", _LeaveApplicationViewModel);
        }
        [HttpPost]
        public ActionResult LeaveApplicationCancelSelf(LeaveApplicationViewModel _LeaveApplicationViewModel)
        {
            try
            {
                //if (ModelState.IsValid)
                //{
                    if (_LeaveApplicationViewModel != null && _LeaveApplicationViewModel.LeaveApplicationDTO != null)
                    {
                        _LeaveApplicationViewModel.LeaveApplicationDTO.ConnectionString = _connectioString;
                        _LeaveApplicationViewModel.LeaveApplicationDTO.LeaveApplicationApprocedPendingStatusDetails = _LeaveApplicationViewModel.LeaveApplicationApprocedPendingStatusDetails;
                        _LeaveApplicationViewModel.LeaveApplicationDTO.EmployeeID = Convert.ToInt32(Session["PersonID"]);
                        _LeaveApplicationViewModel.LeaveApplicationDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<LeaveApplication> response = _ILeaveApplicationBA.InsertLeaveApplicationCancel(_LeaveApplicationViewModel.LeaveApplicationDTO);
                        _LeaveApplicationViewModel.LeaveApplicationDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    }
                    return Json(_LeaveApplicationViewModel.LeaveApplicationDTO.errorMessage, JsonRequestBehavior.AllowGet);

                //}
                //else
                //{
                //    return Json("Please review your form");
                //}
                    
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        #endregion

        // Non-Action Method
        #region ---------------------Methods-ddd----------------------

        protected List<LeaveApplication> GetLeaveApplicationApprocedPendingStatus_SearchList()
        {
            LeaveApplicationSearchRequest searchRequest = new LeaveApplicationSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.EmployeeID = Convert.ToInt32(Session["PersonID"]); 
            List<LeaveApplication> listLeaveApplication = new List<LeaveApplication>();
            IBaseEntityCollectionResponse<LeaveApplication> baseEntityCollectionResponse = _ILeaveApplicationBA.GetLeaveApplicationApprocedPendingStatus_SearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listLeaveApplication = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listLeaveApplication;
        }


        public IEnumerable<LeaveApplicationViewModel> GetLeaveApplicationCancel(out int TotalRecords, int EmployeeID)
        {
            LeaveApplicationSearchRequest searchRequest = new LeaveApplicationSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            _actionMode = Convert.ToString(TempData["ActionMode"]);
            if (Enum.TryParse(_actionMode, out actionModeEnum))     // checks actionMode i.e. Insert or Update // 
            {
                if (actionModeEnum == ActionModeEnum.Insert)        // parameters for SelectAll procedures under Insert or Update mode condition
                {
                    searchRequest.SortBy = "A.CreatedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                    searchRequest.EmployeeID = EmployeeID;
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "A.ModifiedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                    searchRequest.EmployeeID = EmployeeID;
                }
            }
            else
            {
                searchRequest.SortBy = _sortBy;                     // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;
                searchRequest.EmployeeID = EmployeeID;
            }
            List<LeaveApplicationViewModel> listLeaveApplicationViewModel = new List<LeaveApplicationViewModel>();
            List<LeaveApplication> listLeaveApplication = new List<LeaveApplication>();
            IBaseEntityCollectionResponse<LeaveApplication> baseEntityCollectionResponse = _ILeaveApplicationBA.GetLeaveApplicationCancelBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listLeaveApplication = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (LeaveApplication item in listLeaveApplication)
                    {
                        LeaveApplicationViewModel LeaveApplicationViewModel = new LeaveApplicationViewModel();
                        LeaveApplicationViewModel.LeaveApplicationDTO = item;
                        listLeaveApplicationViewModel.Add(LeaveApplicationViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listLeaveApplicationViewModel;
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetLeaveDetailsByLeaveMaster_Employee_LeaveSessionID(int LeaveMasterID, int EmployeeID, int LeaveSessionID)
        {
            ILeaveApplicationViewModel leaveApplicationViewModel = new LeaveApplicationViewModel();
            leaveApplicationViewModel.LeaveMasterID = LeaveMasterID;
            leaveApplicationViewModel.EmployeeID = EmployeeID;
            leaveApplicationViewModel.LeaveSessionID = LeaveSessionID;

            var leaveDetails = GetLeaveDetailsByLeaveMasterID(leaveApplicationViewModel.LeaveMasterID, leaveApplicationViewModel.EmployeeID, leaveApplicationViewModel.LeaveSessionID);
            double[] result = new double[3];
            if (leaveDetails != null)
            {
                result = new double[4] { leaveDetails.NumberOfLeaves, leaveDetails.MaxLeaveAtTime, leaveDetails.BalanceLeave, leaveDetails.ID };
            } //  = from c in leaveDetails select new[] { Convert.ToString(c.LeaveDescription), Convert.ToString(c.LeaveCode), Convert.ToString(c.NumberOfLeaves), Convert.ToString(c.TotalFullDayUtilized), Convert.ToString(c.TotalHalfDayUtilized), Convert.ToString(c.BalanceLeave) };

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion

        // AjaxHandler Method
        #region ----------------------AjaxHandler---------------------
        public ActionResult AjaxHandler(JQueryDataTableParamModel param, string EmployeeID)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<LeaveApplicationViewModel> filteredLeaveApplication;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "LeaveDescription,ApplicationDate";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "C.LeaveDescription Like '%" + param.sSearch + "%' or A.ApplicationDate Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "A.TotalfullDaysLeave";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "C.LeaveDescription Like '%" + param.sSearch + "%' or A.ApplicationDate Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;



            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;

            if (Convert.ToInt32(EmployeeID) > 0)
            {
                filteredLeaveApplication = GetLeaveApplicationCancel(out TotalRecords, Convert.ToInt32(EmployeeID));
            }
            else
            {
                filteredLeaveApplication = new List<LeaveApplicationViewModel>();
                TotalRecords = 0;
            }

            var records = filteredLeaveApplication.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.LeaveDescription), Convert.ToString(c.ApplicationDate), Convert.ToString(c.FromDate + " - " + c.UptoDate), Convert.ToString(c.LeaveTotalDay), Convert.ToString(c.CancelDays) };

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);

        }
        #endregion
    }
}
