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
    public class CCRMBillTypeMasterController : BaseController
    {
        ICCRMBillTypeMasterBA _CCRMBillTypeMasterBA = null;
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

        public CCRMBillTypeMasterController()
        {
            _CCRMBillTypeMasterBA = new CCRMBillTypeMasterBA();

        }
        #region Controller Methods
        // GET: CCRMBillTypeMaster
        public ActionResult Index()
        {
            if (Convert.ToString(Session["UserType"]) == "A" || Convert.ToInt32(Session["Admin Manager"]) > 0)
            {
                return View("/Views/CCRM/CCRMBillTypeMaster/Index.cshtml");
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
                CCRMBillTypeMasterViewModel model = new CCRMBillTypeMasterViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/CCRM/CCRMBillTypeMaster/List.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }
        [HttpGet]
        public ActionResult Create()
        {
            CCRMBillTypeMasterViewModel model = new CCRMBillTypeMasterViewModel();

            List<SelectListItem> BillType = new List<SelectListItem>();
            ViewBag.BillType = new SelectList(BillType, "Value", "Text");
            List<SelectListItem> li_BillType = new List<SelectListItem>();

            if (model.CCRMBillTypeMasterDTO.BillType > 0)
            {
                li_BillType.Add(new SelectListItem { Text = "Contract", Value = "1" });
                li_BillType.Add(new SelectListItem { Text = "Sales", Value = "2" });
                li_BillType.Add(new SelectListItem { Text = "Services", Value = "3" });
                //ViewData["SerialAndBatchManagedBy"] = li_SerialAndBatchManagedBy;
                ViewData["BillType"] = new SelectList(li_BillType, "Value", "Text", (model.CCRMBillTypeMasterDTO.BillType).ToString().Trim());
            }
            else
            {

                li_BillType.Add(new SelectListItem { Text = "Contract", Value = "1" });
                li_BillType.Add(new SelectListItem { Text = "Sales", Value = "2" });
                li_BillType.Add(new SelectListItem { Text = "Services", Value = "3" });
                ViewData["BillType"] = li_BillType;
            }

            return PartialView("/Views/CCRM/CCRMBillTypeMaster/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(CCRMBillTypeMasterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.CCRMBillTypeMasterDTO != null)
                    {
                        model.CCRMBillTypeMasterDTO.ConnectionString = _connectioString;

                        model.CCRMBillTypeMasterDTO.BillTypeName = model.BillTypeName;
                        model.CCRMBillTypeMasterDTO.BillPrefix = model.BillPrefix;
                        model.CCRMBillTypeMasterDTO.BillType = model.BillType;
                        model.CCRMBillTypeMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<CCRMBillTypeMaster> response = _CCRMBillTypeMasterBA.InsertCCRMBillTypeMaster(model.CCRMBillTypeMasterDTO);
                        model.CCRMBillTypeMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);

                    }
                    return Json(model.CCRMBillTypeMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        [HttpGet]
        public ActionResult Edit(Int16 id)
        {
            CCRMBillTypeMasterViewModel model = new CCRMBillTypeMasterViewModel();
            List<SelectListItem> li = new List<SelectListItem>();
            // li1.Add(new SelectListItem { Text = "--Select--", Value = " " });
            li.Add(new SelectListItem { Text = "Contract", Value = "1" });
            li.Add(new SelectListItem { Text = "Sales", Value = "2" });
            li.Add(new SelectListItem { Text = "Services", Value = "3" });
            ViewData["BillType"] = li;
            try
            {
                model.CCRMBillTypeMasterDTO = new CCRMBillTypeMaster();
                model.CCRMBillTypeMasterDTO.ID = id;
                model.CCRMBillTypeMasterDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<CCRMBillTypeMaster> response = _CCRMBillTypeMasterBA.SelectByID(model.CCRMBillTypeMasterDTO);
                if (response != null && response.Entity != null)
                {
                    model.CCRMBillTypeMasterDTO.ID = response.Entity.ID;
                    model.CCRMBillTypeMasterDTO.BillTypeName = response.Entity.BillTypeName;
                    model.CCRMBillTypeMasterDTO.BillPrefix = response.Entity.BillPrefix;
                    model.CCRMBillTypeMasterDTO.BillType = response.Entity.BillType;
                }
                ViewData["BillType"] = new SelectList(li, "Value", "Text", (model.BillType).ToString().Trim());
                return PartialView("/Views/CCRM/CCRMBillTypeMaster/Edit.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(CCRMBillTypeMasterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.CCRMBillTypeMasterDTO != null)
                    {
                        if (model != null && model.CCRMBillTypeMasterDTO != null)
                        {
                            model.CCRMBillTypeMasterDTO.ConnectionString = _connectioString;
                            model.CCRMBillTypeMasterDTO.BillTypeName = model.BillTypeName;
                            model.CCRMBillTypeMasterDTO.BillPrefix = model.BillPrefix;
                            model.CCRMBillTypeMasterDTO.BillType = model.BillType;
                            model.CCRMBillTypeMasterDTO.ID = model.ID;
                            model.CCRMBillTypeMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                            IBaseEntityResponse<CCRMBillTypeMaster> response = _CCRMBillTypeMasterBA.UpdateCCRMBillTypeMaster(model.CCRMBillTypeMasterDTO);
                            model.CCRMBillTypeMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                        }
                    }
                    return Json(model.CCRMBillTypeMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public ActionResult Delete(Int16 ID)
        {
            CCRMBillTypeMasterViewModel model = new CCRMBillTypeMasterViewModel();
            try
            {
                if (ID > 0)
                {
                    if (ID > 0)
                    {
                        CCRMBillTypeMaster CCRMBillTypeMasterDTO = new CCRMBillTypeMaster();
                        CCRMBillTypeMasterDTO.ConnectionString = _connectioString;
                        CCRMBillTypeMasterDTO.ID = ID;
                        CCRMBillTypeMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<CCRMBillTypeMaster> response = _CCRMBillTypeMasterBA.DeleteCCRMBillTypeMaster(CCRMBillTypeMasterDTO);
                        model.CCRMBillTypeMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
                    }
                    return Json(model.CCRMBillTypeMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public IEnumerable<CCRMBillTypeMasterViewModel> GetCCRMBillTypeMaster(out int TotalRecords)
        {
            CCRMBillTypeMasterSearchRequest searchRequest = new CCRMBillTypeMasterSearchRequest();
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
            List<CCRMBillTypeMasterViewModel> listCCRMBillTypeMasterViewModel = new List<CCRMBillTypeMasterViewModel>();
            List<CCRMBillTypeMaster> listCCRMBillTypeMaster = new List<CCRMBillTypeMaster>();
            IBaseEntityCollectionResponse<CCRMBillTypeMaster> baseEntityCollectionResponse = _CCRMBillTypeMasterBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listCCRMBillTypeMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (CCRMBillTypeMaster item in listCCRMBillTypeMaster)
                    {
                        CCRMBillTypeMasterViewModel CCRMBillTypeMasterViewModel = new CCRMBillTypeMasterViewModel();
                        CCRMBillTypeMasterViewModel.CCRMBillTypeMasterDTO = item;
                        listCCRMBillTypeMasterViewModel.Add(CCRMBillTypeMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listCCRMBillTypeMasterViewModel;
        }
        #endregion
        // AjaxHandler Method
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc
            IEnumerable<CCRMBillTypeMasterViewModel> filteredCCRMBillTypeMasterViewModel;

            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "ID";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "ID Like '%" + param.sSearch + "%' or BillTypeName Like '%" + param.sSearch + "%' or BillPrefix Like '%" + param.sSearch + "%'or BillType Like '%" + param.sSearch + "%'";
                        //_searchBy = "ID Like '%" + param.sSearch + "%' or FeedbackPoints Like '%" + param.sSearch + "%'";
                        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "BillTypeName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "ID Like '%" + param.sSearch + "%' or BillTypeName Like '%" + param.sSearch + "%' or BillPrefix Like '%" + param.sSearch + "%'or BillType Like '%" + param.sSearch + "%'";
                        // _searchBy = "ID Like '%" + param.sSearch + "%' or FeedbackPoints Like '%" + param.sSearch + "%'";
                        //this "if" block is added for search functionality
                    }
                    break;
                case 2:
                    _sortBy = "BillPrefix";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "ID Like '%" + param.sSearch + "%' or BillTypeName Like '%" + param.sSearch + "%' or BillPrefix Like '%" + param.sSearch + "%'or BillType Like '%" + param.sSearch + "%'";
                        //_searchBy = "ID Like '%" + param.sSearch + "%' or FeedbackPoints Like '%" + param.sSearch + "%'";
                        //this "if" block is added for search functionality
                    }
                    break;
                case 3:
                    _sortBy = "BillType";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "ID Like '%" + param.sSearch + "%' or BillTypeName Like '%" + param.sSearch + "%' or BillPrefix Like '%" + param.sSearch + "%'or BillType Like '%" + param.sSearch + "%'";
                        //_searchBy = "ID Like '%" + param.sSearch + "%' or FeedbackPoints Like '%" + param.sSearch + "%'";
                        //this "if" block is added for search functionality
                    }
                    break;

            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            filteredCCRMBillTypeMasterViewModel = GetCCRMBillTypeMaster(out TotalRecords);
            var records = filteredCCRMBillTypeMasterViewModel.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { c.BillTypeName.ToString(), Convert.ToString(c.ID), Convert.ToString(c.BillPrefix), Convert.ToString(c.BillType) };

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}