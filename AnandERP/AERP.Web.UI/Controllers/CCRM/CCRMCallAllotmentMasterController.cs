using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AERP.Base.DTO;
using AERP.DTO;
using AERP.Business.BusinessAction;
using AERP.ExceptionManager;
using AERP.ViewModel;
using System.Web.Mvc;
using System.Configuration;

namespace AERP.Web.UI.Controllers
{
    public class CCRMCallAllotmentMasterController : BaseController
    {
        ICCRMCallAllotmentMasterBA _CCRMCallAllotmentMasterBA = null;
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

        public CCRMCallAllotmentMasterController()
        {
            _CCRMCallAllotmentMasterBA = new CCRMCallAllotmentMasterBA();

        }
        #region Controller Methods
        // GET: CCRMCallAllotmentMaster
        public ActionResult Index()
        {
            if (Convert.ToString(Session["UserType"]) == "A" || Convert.ToInt32(Session["Admin Manager"]) > 0)
            {
                return View("/Views/CCRM/CCRMCallAllotmentMaster/Index.cshtml");
            }
            else
            {
                return RedirectToAction("UnauthorizedAccess", "Home");
            }
        }
        public ActionResult List(string actionMode)
        {
            try
            {
                CCRMCallAllotmentMasterViewModel model = new CCRMCallAllotmentMasterViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/CCRM/CCRMCallAllotmentMaster/List.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }
        [HttpGet]
        public ActionResult Edit(Int32 id)
        {
            CCRMCallAllotmentMasterViewModel model = new CCRMCallAllotmentMasterViewModel();
            CCRMCallAllotmentMasterSearchRequest searchRequest = new CCRMCallAllotmentMasterSearchRequest();
            try
            {



                model.CCRMCallAllotmentMasterDTO = new CCRMCallAllotmentMaster();
                model.CCRMCallAllotmentMasterDTO.ID = id;
                model.CCRMCallAllotmentMasterDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<CCRMCallAllotmentMaster> response = _CCRMCallAllotmentMasterBA.SelectByID(model.CCRMCallAllotmentMasterDTO);
                if (response != null && response.Entity != null)
                {
                    model.CCRMCallAllotmentMasterDTO.ID = response.Entity.ID;
                    model.CCRMCallAllotmentMasterDTO.CallTktNo = response.Entity.CallTktNo;
                    model.CCRMCallAllotmentMasterDTO.CallDate = response.Entity.CallDate;
                    model.CCRMCallAllotmentMasterDTO.SerialNo = response.Entity.SerialNo;
                    model.CCRMCallAllotmentMasterDTO.ModelNo = response.Entity.ModelNo;
                    model.CCRMCallAllotmentMasterDTO.MIFName = response.Entity.MIFName;
                    model.CCRMCallAllotmentMasterDTO.EmailID = response.Entity.EmailID;
                    model.CCRMCallAllotmentMasterDTO.CallerName = response.Entity.CallerName;
                    model.CCRMCallAllotmentMasterDTO.CallerPh = response.Entity.CallerPh;
                    model.CCRMCallAllotmentMasterDTO.EngineerID = response.Entity.EngineerID;
                    model.CCRMCallAllotmentMasterDTO.CallTypeID = response.Entity.CallTypeID;
                    model.CCRMCallAllotmentMasterDTO.CallTypeName = response.Entity.CallTypeName;
                    model.CCRMCallAllotmentMasterDTO.ComPlaint = response.Entity.ComPlaint;
                    model.CCRMCallAllotmentMasterDTO.EnggMobNo = response.Entity.EnggMobNo;
                    model.CCRMCallAllotmentMasterDTO.AreaPatchName = response.Entity.AreaPatchName;
                    model.CCRMCallAllotmentMasterDTO.ItemDescription = response.Entity.ItemDescription;
                    model.CCRMCallAllotmentMasterDTO.CentreCode = response.Entity.CentreCode;
                    model.CCRMCallAllotmentMasterDTO.AdminRoleMasterID = response.Entity.AdminRoleMasterID;
                    model.CCRMCallAllotmentMasterDTO.RightName = response.Entity.RightName;
                    model.CCRMCallAllotmentMasterDTO.EmployeeID = response.Entity.EmployeeID;
                    model.CCRMCallAllotmentMasterDTO.EmployeeCode = response.Entity.EmployeeCode;
                    model.CCRMCallAllotmentMasterDTO.EmployeeName = response.Entity.EmployeeName;
                   // model.CCRMCallAllotmentMasterDTO.ContractStatus = response.Entity.ContractStatus;
                    model.CCRMCallAllotmentMasterDTO.AllotPeriod = response.Entity.AllotPeriod;
                    model.CCRMCallAllotmentMasterDTO.CallStatus = response.Entity.CallStatus;
                    //model.CCRMCallAllotmentMasterDTO.EngineerID = response.Entity.EngineerID;
                    //model.CCRMCallAllotmentMasterDTO.AllotEnggName = response.Entity.AllotEnggName;
                }
                //******************************************//
                searchRequest.ConnectionString = _connectioString;
                searchRequest.CCRMCallAllotmentMasterID = id;

                IBaseEntityCollectionResponse<CCRMCallAllotmentMaster> baseEntityCollectionResponse = _CCRMCallAllotmentMasterBA.GetListPendingCallByID(searchRequest);

                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        model.PendingCallByCCRMCallAllotmentMasterID = baseEntityCollectionResponse.CollectionResponse.ToList();

                    }
                }
                //******************************************//
                return PartialView("/Views/CCRM/CCRMCallAllotmentMaster/Edit.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(CCRMCallAllotmentMasterViewModel model)
        {
            try
            {
                
                    if (model != null && model.CCRMCallAllotmentMasterDTO != null)
                    {
                        if (model != null && model.CCRMCallAllotmentMasterDTO != null)
                        {
                            model.CCRMCallAllotmentMasterDTO.ConnectionString = _connectioString;
                            model.CCRMCallAllotmentMasterDTO.AllotDate = model.AllotDate;
                            model.CCRMCallAllotmentMasterDTO.CallerName = model.CallerName;
                            model.CCRMCallAllotmentMasterDTO.CallTktNo = model.CallTktNo;
                            model.CCRMCallAllotmentMasterDTO.CallDate = model.CallDate;
                            model.CCRMCallAllotmentMasterDTO.EngineerID = model.EngineerID;
                            model.CCRMCallAllotmentMasterDTO.AllotEnggName = model.AllotEnggName;
                            model.CCRMCallAllotmentMasterDTO.CallStatus = model.CallStatus;
                            //model.CCRMCallAllotmentMasterDTO.UserID = model.UserID;
                            model.CCRMCallAllotmentMasterDTO.AllotPeriod = model.AllotPeriod;
                        model.CCRMCallAllotmentMasterDTO.Allotment = model.Allotment;
                        model.CCRMCallAllotmentMasterDTO.ID = model.ID;
                        model.CCRMCallAllotmentMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        model.CCRMCallAllotmentMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                            IBaseEntityResponse<CCRMCallAllotmentMaster> response = _CCRMCallAllotmentMasterBA.UpdateCCRMCallAllotmentMaster(model.CCRMCallAllotmentMasterDTO);
                            model.CCRMCallAllotmentMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                        }
                    }
                    return Json(model.CCRMCallAllotmentMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
                
                

            }
            catch (Exception)
            {
                throw;
            }
        }
        public ActionResult Delete(Int32 ID)
        {
            CCRMCallAllotmentMasterViewModel model = new CCRMCallAllotmentMasterViewModel();
            try
            {
                if (ID > 0)
                {
                    if (ID > 0)
                    {
                        CCRMCallAllotmentMaster CCRMCallAllotmentMasterDTO = new CCRMCallAllotmentMaster();
                        CCRMCallAllotmentMasterDTO.ConnectionString = _connectioString;
                        CCRMCallAllotmentMasterDTO.ID = ID;
                        CCRMCallAllotmentMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<CCRMCallAllotmentMaster> response = _CCRMCallAllotmentMasterBA.DeleteCCRMCallAllotmentMaster(CCRMCallAllotmentMasterDTO);
                        model.CCRMCallAllotmentMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
                    }
                    return Json(model.CCRMCallAllotmentMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json("Please review your form");
                }

            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
        // Non-Action Method
        #region Methods
        public IEnumerable<CCRMCallAllotmentMasterViewModel> GetCCRMCallAllotmentMaster(out int TotalRecords)
        {
            CCRMCallAllotmentMasterSearchRequest searchRequest = new CCRMCallAllotmentMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            _actionMode = Convert.ToString(TempData["ActionMode"]);
            if (Enum.TryParse(_actionMode, out actionModeEnum))     // checks actionMode i.e. Insert or Update // 
            {
                if (actionModeEnum == ActionModeEnum.Insert)        // parameters for SelectAll procedures under Insert or Update mode condition
                {
                    searchRequest.SortBy = "CreatedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "ModifiedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                }
            }
            else
            {
                searchRequest.SortBy = _sortBy;                     // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;
            }
            List<CCRMCallAllotmentMasterViewModel> listCCRMCallAllotmentMasterViewModel = new List<CCRMCallAllotmentMasterViewModel>();
            List<CCRMCallAllotmentMaster> listCCRMCallAllotmentMaster = new List<CCRMCallAllotmentMaster>();
            IBaseEntityCollectionResponse<CCRMCallAllotmentMaster> baseEntityCollectionResponse = _CCRMCallAllotmentMasterBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listCCRMCallAllotmentMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (CCRMCallAllotmentMaster item in listCCRMCallAllotmentMaster)
                    {
                        CCRMCallAllotmentMasterViewModel CCRMCallAllotmentMasterViewModel = new CCRMCallAllotmentMasterViewModel();
                        CCRMCallAllotmentMasterViewModel.CCRMCallAllotmentMasterDTO = item;
                        listCCRMCallAllotmentMasterViewModel.Add(CCRMCallAllotmentMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listCCRMCallAllotmentMasterViewModel;
        }
        #endregion
        // AjaxHandler Method
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc
            IEnumerable<CCRMCallAllotmentMasterViewModel> filteredCCRMCallAllotmentMasterViewModel;

            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "CallTktNo";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "CallTktNo Like '%" + param.sSearch + "%' or SerialNo Like '%" + param.sSearch + "%' or MIFName Like '%" + param.sSearch + "%'";
                        //_searchBy = "ID Like '%" + param.sSearch + "%' or FeedbackPoints Like '%" + param.sSearch + "%'";
                        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "SerialNo";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "CallTktNo Like '%" + param.sSearch + "%' or SerialNo Like '%" + param.sSearch + "%' or MIFName Like '%" + param.sSearch + "%'";
                        // _searchBy = "ID Like '%" + param.sSearch + "%' or FeedbackPoints Like '%" + param.sSearch + "%'";
                        //this "if" block is added for search functionality
                    }
                    break;
                case 2:
                    _sortBy = "MIFName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "CallTktNo Like '%" + param.sSearch + "%' or SerialNo Like '%" + param.sSearch + "%' or MIFName Like '%" + param.sSearch + "%'";
                        //_searchBy = "ID Like '%" + param.sSearch + "%' or FeedbackPoints Like '%" + param.sSearch + "%'";
                        //this "if" block is added for search functionality
                    }
                    break;


            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            filteredCCRMCallAllotmentMasterViewModel = GetCCRMCallAllotmentMaster(out TotalRecords);
            var records = filteredCCRMCallAllotmentMasterViewModel.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.CallTktNo), Convert.ToString(c.ID), Convert.ToString(c.CallDate), Convert.ToString(c.SerialNo), Convert.ToString(c.ModelNo), Convert.ToString(c.EngineerID), Convert.ToString(c.MIFName), Convert.ToString(c.ItemDescription), Convert.ToString(c.SymptomTitle), Convert.ToString(c.Priority), Convert.ToString(c.EmployeeName), Convert.ToString(c.ComPlaint) };

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}