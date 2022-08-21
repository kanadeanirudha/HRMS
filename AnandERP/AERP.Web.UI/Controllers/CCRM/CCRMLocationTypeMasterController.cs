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
using AERP.Common;
namespace AERP.Web.UI.Controllers
{
    public class CCRMLocationTypeMasterController : BaseController
    {
        ICCRMLocationTypeMasterBA _CCRMLocationTypeMasterBA = null;
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

        public CCRMLocationTypeMasterController()
        {
            _CCRMLocationTypeMasterBA = new CCRMLocationTypeMasterBA();

        }
        #region Controller Methods
        // GET: CCRMLocationTypeMaster
        public ActionResult Index()
        {
            if (Convert.ToString(Session["UserType"]) == "A" || Convert.ToInt32(Session["Admin Manager"]) > 0)
            {
                return View("/Views/CCRM/CCRMLocationTypeMaster/Index.cshtml");
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
                CCRMLocationTypeMasterViewModel model = new CCRMLocationTypeMasterViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/CCRM/CCRMLocationTypeMaster/List.cshtml", model);
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
            CCRMLocationTypeMasterViewModel model = new CCRMLocationTypeMasterViewModel();

            List<SelectListItem> LocationType = new List<SelectListItem>();
            ViewBag.LocationType = new SelectList(LocationType, "Value", "Text");
            List<SelectListItem> li_LocationType = new List<SelectListItem>();

            if (model.CCRMLocationTypeMasterDTO.LocationType > 0)
            {
                li_LocationType.Add(new SelectListItem { Text = "Metro", Value = "1" });
                li_LocationType.Add(new SelectListItem { Text = "Remote", Value = "2" });
               // li_LocationType.Add(new SelectListItem { Text = "None", Value = "3" });
                //ViewData["SerialAndBatchManagedBy"] = li_SerialAndBatchManagedBy;
                ViewData["LocationType"] = new SelectList(li_LocationType, "Value", "Text", (model.CCRMLocationTypeMasterDTO.LocationType).ToString().Trim());
            }
            else
            {

                li_LocationType.Add(new SelectListItem { Text = "Metro", Value = "1" });
                li_LocationType.Add(new SelectListItem { Text = "Remote", Value = "2" });
               // li_LocationType.Add(new SelectListItem { Text = "None", Value = "3" });
                ViewData["LocationType"] = li_LocationType;
            }
            return PartialView("/Views/CCRM/CCRMLocationTypeMaster/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(CCRMLocationTypeMasterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.CCRMLocationTypeMasterDTO != null)
                    {
                        model.CCRMLocationTypeMasterDTO.ConnectionString = _connectioString;

                        model.CCRMLocationTypeMasterDTO.LocationTypeCode = model.LocationTypeCode;
                        model.CCRMLocationTypeMasterDTO.LocationType = model.LocationType;
                        model.CCRMLocationTypeMasterDTO.LocationTypeDesc = model.LocationTypeDesc;
                        model.CCRMLocationTypeMasterDTO.ResponseTime = model.ResponseTime;
                        model.CCRMLocationTypeMasterDTO.ResponseUnit = model.ResponseUnit;
                        model.CCRMLocationTypeMasterDTO.CallCharges = model.CallCharges;
                        model.CCRMLocationTypeMasterDTO.Distance = model.Distance;
                        model.CCRMLocationTypeMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<CCRMLocationTypeMaster> response = _CCRMLocationTypeMasterBA.InsertCCRMLocationTypeMaster(model.CCRMLocationTypeMasterDTO);
                        model.CCRMLocationTypeMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);

                    }
                    return Json(model.CCRMLocationTypeMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public ActionResult Edit(Int32 id)
        {
            CCRMLocationTypeMasterViewModel model = new CCRMLocationTypeMasterViewModel();
            List<SelectListItem> li = new List<SelectListItem>();
            // li1.Add(new SelectListItem { Text = "--Select--", Value = " " });
            li.Add(new SelectListItem { Text = "Metro", Value = "1" });
            li.Add(new SelectListItem { Text = "Remote", Value = "2" });
            ViewData["LocationType"] = li;
            try
            {



                model.CCRMLocationTypeMasterDTO = new CCRMLocationTypeMaster();
                model.CCRMLocationTypeMasterDTO.ID = id;
                model.CCRMLocationTypeMasterDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<CCRMLocationTypeMaster> response = _CCRMLocationTypeMasterBA.SelectByID(model.CCRMLocationTypeMasterDTO);
                if (response != null && response.Entity != null)
                {
                    model.CCRMLocationTypeMasterDTO.ID = response.Entity.ID;
                    model.CCRMLocationTypeMasterDTO.LocationTypeCode = response.Entity.LocationTypeCode;
                    model.CCRMLocationTypeMasterDTO.LocationType = response.Entity.LocationType;
                    model.CCRMLocationTypeMasterDTO.LocationTypeDesc = response.Entity.LocationTypeDesc;
                    model.CCRMLocationTypeMasterDTO.ResponseTime = response.Entity.ResponseTime;
                    model.CCRMLocationTypeMasterDTO.ResponseUnit = response.Entity.ResponseUnit;
                    model.CCRMLocationTypeMasterDTO.CallCharges = response.Entity.CallCharges;
                    model.CCRMLocationTypeMasterDTO.Distance = response.Entity.Distance;
                }
                ViewData["LocationType"] = new SelectList(li, "Value", "Text", (model.LocationType).ToString().Trim());
                return PartialView("/Views/CCRM/CCRMLocationTypeMaster/Edit.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(CCRMLocationTypeMasterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.CCRMLocationTypeMasterDTO != null)
                    {
                        if (model != null && model.CCRMLocationTypeMasterDTO != null)
                        {
                            model.CCRMLocationTypeMasterDTO.ConnectionString = _connectioString;
                            model.CCRMLocationTypeMasterDTO.LocationTypeCode = model.LocationTypeCode;
                            model.CCRMLocationTypeMasterDTO.LocationType = model.LocationType;
                            model.CCRMLocationTypeMasterDTO.LocationTypeDesc = model.LocationTypeDesc;
                            model.CCRMLocationTypeMasterDTO.ResponseTime = model.ResponseTime;
                            model.CCRMLocationTypeMasterDTO.ResponseUnit = model.ResponseUnit;
                            model.CCRMLocationTypeMasterDTO.CallCharges = model.CallCharges;
                            model.CCRMLocationTypeMasterDTO.Distance = model.Distance;
                            model.CCRMLocationTypeMasterDTO.ID = model.ID;
                            model.CCRMLocationTypeMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                            IBaseEntityResponse<CCRMLocationTypeMaster> response = _CCRMLocationTypeMasterBA.UpdateCCRMLocationTypeMaster(model.CCRMLocationTypeMasterDTO);
                            model.CCRMLocationTypeMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                        }
                    }
                    return Json(model.CCRMLocationTypeMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
            CCRMLocationTypeMasterViewModel model = new CCRMLocationTypeMasterViewModel();
            try
            {
                if (ID > 0)
                {
                    if (ID > 0)
                    {
                        CCRMLocationTypeMaster CCRMLocationTypeMasterDTO = new CCRMLocationTypeMaster();
                        CCRMLocationTypeMasterDTO.ConnectionString = _connectioString;
                        CCRMLocationTypeMasterDTO.ID = ID;
                        CCRMLocationTypeMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<CCRMLocationTypeMaster> response = _CCRMLocationTypeMasterBA.DeleteCCRMLocationTypeMaster(CCRMLocationTypeMasterDTO);
                        model.CCRMLocationTypeMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
                    }
                    return Json(model.CCRMLocationTypeMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public IEnumerable<CCRMLocationTypeMasterViewModel> GetCCRMLocationTypeMaster(out int TotalRecords)
        {
            CCRMLocationTypeMasterSearchRequest searchRequest = new CCRMLocationTypeMasterSearchRequest();
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
            List<CCRMLocationTypeMasterViewModel> listCCRMLocationTypeMasterViewModel = new List<CCRMLocationTypeMasterViewModel>();
            List<CCRMLocationTypeMaster> listCCRMLocationTypeMaster = new List<CCRMLocationTypeMaster>();
            IBaseEntityCollectionResponse<CCRMLocationTypeMaster> baseEntityCollectionResponse = _CCRMLocationTypeMasterBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listCCRMLocationTypeMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (CCRMLocationTypeMaster item in listCCRMLocationTypeMaster)
                    {
                        CCRMLocationTypeMasterViewModel CCRMLocationTypeMasterViewModel = new CCRMLocationTypeMasterViewModel();
                        CCRMLocationTypeMasterViewModel.CCRMLocationTypeMasterDTO = item;
                        listCCRMLocationTypeMasterViewModel.Add(CCRMLocationTypeMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listCCRMLocationTypeMasterViewModel;
        }
        #endregion
        // AjaxHandler Method
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc
            IEnumerable<CCRMLocationTypeMasterViewModel> filteredCCRMLocationTypeMasterViewModel;

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
                        _searchBy = "ID Like '%" + param.sSearch + "%' or LocationTypeCode Like '%" + param.sSearch + "%' or LocationType Like '%" + param.sSearch + "%'or LocationTypeDesc Like '%" + param.sSearch + "%'or ResponseTime Like '%" + param.sSearch + "%'or ResponseUnit Like '%" + param.sSearch + "%'or CallCharges Like '%" + param.sSearch + "%'or Distance Like '%" + param.sSearch + "%'";
                        //_searchBy = "ID Like '%" + param.sSearch + "%' or FeedbackPoints Like '%" + param.sSearch + "%'";
                        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "LocationTypeCode";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "ID Like '%" + param.sSearch + "%' or LocationTypeCode Like '%" + param.sSearch + "%' or LocationType Like '%" + param.sSearch + "%'or LocationTypeDesc Like '%" + param.sSearch + "%'or ResponseTime Like '%" + param.sSearch + "%'or ResponseUnit Like '%" + param.sSearch + "%'or CallCharges Like '%" + param.sSearch + "%'or Distance Like '%" + param.sSearch + "%'";
                        // _searchBy = "ID Like '%" + param.sSearch + "%' or FeedbackPoints Like '%" + param.sSearch + "%'";
                        //this "if" block is added for search functionality
                    }
                    break;
                case 2:
                    _sortBy = "LocationType";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "ID Like '%" + param.sSearch + "%' or LocationTypeCode Like '%" + param.sSearch + "%' or LocationType Like '%" + param.sSearch + "%'or LocationTypeDesc Like '%" + param.sSearch + "%'or ResponseTime Like '%" + param.sSearch + "%'or ResponseUnit Like '%" + param.sSearch + "%'or CallCharges Like '%" + param.sSearch + "%'or Distance Like '%" + param.sSearch + "%'";
                        //_searchBy = "ID Like '%" + param.sSearch + "%' or FeedbackPoints Like '%" + param.sSearch + "%'";
                        //this "if" block is added for search functionality
                    }
                    break;
                case 3:
                    _sortBy = "LocationTypeDesc";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "ID Like '%" + param.sSearch + "%' or LocationTypeCode Like '%" + param.sSearch + "%' or LocationType Like '%" + param.sSearch + "%'or LocationTypeDesc Like '%" + param.sSearch + "%'or ResponseTime Like '%" + param.sSearch + "%'or ResponseUnit Like '%" + param.sSearch + "%'or CallCharges Like '%" + param.sSearch + "%'or Distance Like '%" + param.sSearch + "%'";
                        //_searchBy = "ID Like '%" + param.sSearch + "%' or FeedbackPoints Like '%" + param.sSearch + "%'";
                        //this "if" block is added for search functionality
                    }
                    break;
                case 4:
                    _sortBy = "ResponseTime";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "ID Like '%" + param.sSearch + "%' or LocationTypeCode Like '%" + param.sSearch + "%' or LocationType Like '%" + param.sSearch + "%'or LocationTypeDesc Like '%" + param.sSearch + "%'or ResponseTime Like '%" + param.sSearch + "%'or ResponseUnit Like '%" + param.sSearch + "%'or CallCharges Like '%" + param.sSearch + "%'or Distance Like '%" + param.sSearch + "%'";
                        //_searchBy = "ID Like '%" + param.sSearch + "%' or FeedbackPoints Like '%" + param.sSearch + "%'";
                        //this "if" block is added for search functionality
                    }
                    break;
                case 5:
                    _sortBy = "ResponseUnit";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "ID Like '%" + param.sSearch + "%' or LocationTypeCode Like '%" + param.sSearch + "%' or LocationType Like '%" + param.sSearch + "%'or LocationTypeDesc Like '%" + param.sSearch + "%'or ResponseTime Like '%" + param.sSearch + "%'or ResponseUnit Like '%" + param.sSearch + "%'or CallCharges Like '%" + param.sSearch + "%'or Distance Like '%" + param.sSearch + "%'";
                        //_searchBy = "ID Like '%" + param.sSearch + "%' or FeedbackPoints Like '%" + param.sSearch + "%'";
                        //this "if" block is added for search functionality
                    }
                    break;
                case 6:
                    _sortBy = "CallCharges";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "ID Like '%" + param.sSearch + "%' or LocationTypeCode Like '%" + param.sSearch + "%' or LocationType Like '%" + param.sSearch + "%'or LocationTypeDesc Like '%" + param.sSearch + "%'or ResponseTime Like '%" + param.sSearch + "%'or ResponseUnit Like '%" + param.sSearch + "%'or CallCharges Like '%" + param.sSearch + "%'or Distance Like '%" + param.sSearch + "%'";
                        //_searchBy = "ID Like '%" + param.sSearch + "%' or FeedbackPoints Like '%" + param.sSearch + "%'";
                        //this "if" block is added for search functionality
                    }
                    break;
                case 7:
                    _sortBy = "Distance";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "ID Like '%" + param.sSearch + "%' or LocationTypeCode Like '%" + param.sSearch + "%' or LocationType Like '%" + param.sSearch + "%'or LocationTypeDesc Like '%" + param.sSearch + "%'or ResponseTime Like '%" + param.sSearch + "%'or ResponseUnit Like '%" + param.sSearch + "%'or CallCharges Like '%" + param.sSearch + "%'or Distance Like '%" + param.sSearch + "%'";
                        //_searchBy = "ID Like '%" + param.sSearch + "%' or FeedbackPoints Like '%" + param.sSearch + "%'";
                        //this "if" block is added for search functionality
                    }
                    break;


            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            filteredCCRMLocationTypeMasterViewModel = GetCCRMLocationTypeMaster(out TotalRecords);
            var records = filteredCCRMLocationTypeMasterViewModel.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { c.LocationTypeCode.ToString(), Convert.ToString(c.ID), Convert.ToString(c.LocationType),Convert.ToString(c.LocationTypeDesc),Convert.ToString(c.ResponseTime),Convert.ToString(c.ResponseUnit),Convert.ToString(c.CallCharges),Convert.ToString(c.Distance) };

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}