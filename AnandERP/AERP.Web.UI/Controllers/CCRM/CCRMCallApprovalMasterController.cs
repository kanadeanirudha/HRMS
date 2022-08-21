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
    public class CCRMCallApprovalMasterController : BaseController
    {
        ICCRMCallApprovalMasterBA _CCRMCallApprovalMasterBA = null;
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

        public CCRMCallApprovalMasterController()
        {
            _CCRMCallApprovalMasterBA = new CCRMCallApprovalMasterBA();

        }
        #region Controller Methods
        // GET: CCRMCallApprovalMaster
        public ActionResult Index()
        {
            if (Convert.ToString(Session["UserType"]) == "A" || Convert.ToInt32(Session["Admin Manager"]) > 0)
            {
                return View("/Views/CCRM/CCRMCallApprovalMaster/Index.cshtml");
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
                CCRMCallApprovalMasterViewModel model = new CCRMCallApprovalMasterViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/CCRM/CCRMCallApprovalMaster/List.cshtml", model);
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
            CCRMCallApprovalMasterViewModel model = new CCRMCallApprovalMasterViewModel();
            try
            {



                model.CCRMCallApprovalMasterDTO = new CCRMCallApprovalMaster();
                model.CCRMCallApprovalMasterDTO.ID = id;
                model.CCRMCallApprovalMasterDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<CCRMCallApprovalMaster> response = _CCRMCallApprovalMasterBA.SelectByID(model.CCRMCallApprovalMasterDTO);
                if (response != null && response.Entity != null)
                {
                    model.CCRMCallApprovalMasterDTO.ID = response.Entity.ID;
                    model.CCRMCallApprovalMasterDTO.CallTktNo = response.Entity.CallTktNo;
                    model.CCRMCallApprovalMasterDTO.CallDate = response.Entity.CallDate;
                    model.CCRMCallApprovalMasterDTO.SerialNo = response.Entity.SerialNo;
                    model.CCRMCallApprovalMasterDTO.ModelNo = response.Entity.ModelNo;
                    model.CCRMCallApprovalMasterDTO.CallTypeID = response.Entity.CallTypeID;
                    model.CCRMCallApprovalMasterDTO.MIFName = response.Entity.MIFName;
                    model.CCRMCallApprovalMasterDTO.CallCharges = response.Entity.CallCharges;
                    model.CCRMCallApprovalMasterDTO.CallTypeName = response.Entity.CallTypeName;
                    model.CCRMCallApprovalMasterDTO.ItemDescription = response.Entity.ItemDescription;
                }

                return PartialView("/Views/CCRM/CCRMCallApprovalMaster/Edit.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(CCRMCallApprovalMasterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.CCRMCallApprovalMasterDTO != null)
                    {
                        if (model != null && model.CCRMCallApprovalMasterDTO != null)
                        {
                            model.CCRMCallApprovalMasterDTO.ConnectionString = _connectioString;
                            model.CCRMCallApprovalMasterDTO.CustApproval = model.CustApproval;
                           
                            model.CCRMCallApprovalMasterDTO.ID = model.ID;
                            model.CCRMCallApprovalMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                            IBaseEntityResponse<CCRMCallApprovalMaster> response = _CCRMCallApprovalMasterBA.UpdateCCRMCallApprovalMaster(model.CCRMCallApprovalMasterDTO);
                            model.CCRMCallApprovalMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                        }
                    }
                    return Json(model.CCRMCallApprovalMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public ActionResult Delete(Int32 ID)
        {
            CCRMCallApprovalMasterViewModel model = new CCRMCallApprovalMasterViewModel();
            try
            {
                if (ID > 0)
                {
                    if (ID > 0)
                    {
                        CCRMCallApprovalMaster CCRMCallApprovalMasterDTO = new CCRMCallApprovalMaster();
                        CCRMCallApprovalMasterDTO.ConnectionString = _connectioString;
                        CCRMCallApprovalMasterDTO.ID = ID;
                        CCRMCallApprovalMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<CCRMCallApprovalMaster> response = _CCRMCallApprovalMasterBA.DeleteCCRMCallApprovalMaster(CCRMCallApprovalMasterDTO);
                        model.CCRMCallApprovalMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
                    }
                    return Json(model.CCRMCallApprovalMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public IEnumerable<CCRMCallApprovalMasterViewModel> GetCCRMCallApprovalMaster(out int TotalRecords)
        {
            CCRMCallApprovalMasterSearchRequest searchRequest = new CCRMCallApprovalMasterSearchRequest();
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
            List<CCRMCallApprovalMasterViewModel> listCCRMCallApprovalMasterViewModel = new List<CCRMCallApprovalMasterViewModel>();
            List<CCRMCallApprovalMaster> listCCRMCallApprovalMaster = new List<CCRMCallApprovalMaster>();
            IBaseEntityCollectionResponse<CCRMCallApprovalMaster> baseEntityCollectionResponse = _CCRMCallApprovalMasterBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listCCRMCallApprovalMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (CCRMCallApprovalMaster item in listCCRMCallApprovalMaster)
                    {
                        CCRMCallApprovalMasterViewModel CCRMCallApprovalMasterViewModel = new CCRMCallApprovalMasterViewModel();
                        CCRMCallApprovalMasterViewModel.CCRMCallApprovalMasterDTO = item;
                        listCCRMCallApprovalMasterViewModel.Add(CCRMCallApprovalMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listCCRMCallApprovalMasterViewModel;
        }
        #endregion
        // AjaxHandler Method
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc
            IEnumerable<CCRMCallApprovalMasterViewModel> filteredCCRMCallApprovalMasterViewModel;

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
            filteredCCRMCallApprovalMasterViewModel = GetCCRMCallApprovalMaster(out TotalRecords);
            var records = filteredCCRMCallApprovalMasterViewModel.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.CallTktNo), Convert.ToString(c.ID), Convert.ToString(c.CallDate), Convert.ToString(c.SerialNo), Convert.ToString(c.ModelNo), Convert.ToString(c.CallType), Convert.ToString(c.MIFName), Convert.ToString(c.CallCharges), Convert.ToString(c.NotApproved), Convert.ToString(c.CallTypeName), Convert.ToString(c.ItemDescription) };

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}