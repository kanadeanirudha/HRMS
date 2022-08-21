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
    public class CCRMServiceMasterController : BaseController
    {

        ICCRMServiceMasterBA _CCRMServiceMasterBA = null;
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

        public CCRMServiceMasterController()
        {
            _CCRMServiceMasterBA = new CCRMServiceMasterBA();

        }
        #region Controller Methods
        // GET: CCRMServiceMaster
        public ActionResult Index()
        {
            if (Convert.ToString(Session["UserType"]) == "A" || Convert.ToInt32(Session["Admin Manager"]) > 0)
            {
                return View("/Views/CCRM/CCRMServiceMaster/Index.cshtml");
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
                CCRMServiceMasterViewModel model = new CCRMServiceMasterViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/CCRM/CCRMServiceMaster/List.cshtml", model);
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
            CCRMServiceMasterViewModel model = new CCRMServiceMasterViewModel();

            List<SelectListItem> ServiceType = new List<SelectListItem>();
            ViewBag.ServiceType = new SelectList(ServiceType, "Value", "Text");
            List<SelectListItem> li_ServiceType = new List<SelectListItem>();

            if (model.CCRMServiceMasterDTO.ServiceType > 0)
            {
                li_ServiceType.Add(new SelectListItem { Text = "Service", Value = "1" });
                li_ServiceType.Add(new SelectListItem { Text = "Contract", Value = "2" });
                li_ServiceType.Add(new SelectListItem { Text = "AMC Charges", Value = "3" });
                li_ServiceType.Add(new SelectListItem { Text = "Copy Charges", Value = "4" });
                li_ServiceType.Add(new SelectListItem { Text = " Machine Rent", Value = "5" });
                //ViewData["SerialAndBatchManagedBy"] = li_SerialAndBatchManagedBy;
                ViewData["ServiceType"] = new SelectList(li_ServiceType, "Value", "Text", (model.CCRMServiceMasterDTO.ServiceType).ToString().Trim());
            }
            else
            {

                li_ServiceType.Add(new SelectListItem { Text = "Service", Value = "1" });
                li_ServiceType.Add(new SelectListItem { Text = "Contract", Value = "2" });
                li_ServiceType.Add(new SelectListItem { Text = "AMC Charges", Value = "3" });
                li_ServiceType.Add(new SelectListItem { Text = "Copy Charges", Value = "4" });
                li_ServiceType.Add(new SelectListItem { Text = "Machine Rent", Value = "5" });
                ViewData["ServiceType"] = li_ServiceType;
            }
            return PartialView("/Views/CCRM/CCRMServiceMaster/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(CCRMServiceMasterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.CCRMServiceMasterDTO != null)
                    {
                        model.CCRMServiceMasterDTO.ConnectionString = _connectioString;

                        model.CCRMServiceMasterDTO.ServiceDetails = model.ServiceDetails;
                        model.CCRMServiceMasterDTO.ServiceDescription = model.ServiceDescription;
                        model.CCRMServiceMasterDTO.CallCharges = model.CallCharges;
                        model.CCRMServiceMasterDTO.ServiceType = model.ServiceType;
                        model.CCRMServiceMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<CCRMServiceMaster> response = _CCRMServiceMasterBA.InsertCCRMServiceMaster(model.CCRMServiceMasterDTO);
                        model.CCRMServiceMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);

                    }
                    return Json(model.CCRMServiceMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
            CCRMServiceMasterViewModel model = new CCRMServiceMasterViewModel();
            List<SelectListItem> li = new List<SelectListItem>();
            // li1.Add(new SelectListItem { Text = "--Select--", Value = " " });
            li.Add(new SelectListItem { Text = "Service", Value = "1" });
            li.Add(new SelectListItem { Text = "Contract", Value = "2" });
            li.Add(new SelectListItem { Text = "AMC Charges", Value = "3" });
            li.Add(new SelectListItem { Text = "Copy Charges", Value = "4" });
            li.Add(new SelectListItem { Text = "Machine Rent", Value = "5" });

            ViewData["ServiceType"] = li;

            try
            {



                model.CCRMServiceMasterDTO = new CCRMServiceMaster();
                model.CCRMServiceMasterDTO.ID = id;
                model.CCRMServiceMasterDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<CCRMServiceMaster> response = _CCRMServiceMasterBA.SelectByID(model.CCRMServiceMasterDTO);
                if (response != null && response.Entity != null)
                {
                    model.CCRMServiceMasterDTO.ID = response.Entity.ID;
                    model.CCRMServiceMasterDTO.ServiceDetails = response.Entity.ServiceDetails;
                    model.CCRMServiceMasterDTO.ServiceDescription = response.Entity.ServiceDescription;
                    model.CCRMServiceMasterDTO.CallCharges = response.Entity.CallCharges;
                    model.CCRMServiceMasterDTO.ServiceType = response.Entity.ServiceType;
                }
                ViewData["ServiceType"] = new SelectList(li, "Value", "Text", (model.ServiceType).ToString().Trim());
                return PartialView("/Views/CCRM/CCRMServiceMaster/Edit.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(CCRMServiceMasterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.CCRMServiceMasterDTO != null)
                    {
                        if (model != null && model.CCRMServiceMasterDTO != null)
                        {
                            model.CCRMServiceMasterDTO.ConnectionString = _connectioString;
                            model.CCRMServiceMasterDTO.ServiceDetails = model.ServiceDetails;
                            model.CCRMServiceMasterDTO.ServiceDescription = model.ServiceDescription;
                            model.CCRMServiceMasterDTO.CallCharges = model.CallCharges;
                            model.CCRMServiceMasterDTO.ServiceType = model.ServiceType;
                            model.CCRMServiceMasterDTO.ID = model.ID;
                            model.CCRMServiceMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                            IBaseEntityResponse<CCRMServiceMaster> response = _CCRMServiceMasterBA.UpdateCCRMServiceMaster(model.CCRMServiceMasterDTO);
                            model.CCRMServiceMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                        }
                    }
                    return Json(model.CCRMServiceMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
            CCRMServiceMasterViewModel model = new CCRMServiceMasterViewModel();
            try
            {
                if (ID > 0)
                {
                    if (ID > 0)
                    {
                        CCRMServiceMaster CCRMServiceMasterDTO = new CCRMServiceMaster();
                        CCRMServiceMasterDTO.ConnectionString = _connectioString;
                        CCRMServiceMasterDTO.ID = ID;
                        CCRMServiceMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<CCRMServiceMaster> response = _CCRMServiceMasterBA.DeleteCCRMServiceMaster(CCRMServiceMasterDTO);
                        model.CCRMServiceMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
                    }
                    return Json(model.CCRMServiceMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public IEnumerable<CCRMServiceMasterViewModel> GetCCRMServiceMaster(out int TotalRecords)
        {
            CCRMServiceMasterSearchRequest searchRequest = new CCRMServiceMasterSearchRequest();
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
            List<CCRMServiceMasterViewModel> listCCRMServiceMasterViewModel = new List<CCRMServiceMasterViewModel>();
            List<CCRMServiceMaster> listCCRMServiceMaster = new List<CCRMServiceMaster>();
            IBaseEntityCollectionResponse<CCRMServiceMaster> baseEntityCollectionResponse = _CCRMServiceMasterBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listCCRMServiceMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (CCRMServiceMaster item in listCCRMServiceMaster)
                    {
                        CCRMServiceMasterViewModel CCRMServiceMasterViewModel = new CCRMServiceMasterViewModel();
                        CCRMServiceMasterViewModel.CCRMServiceMasterDTO = item;
                        listCCRMServiceMasterViewModel.Add(CCRMServiceMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listCCRMServiceMasterViewModel;
        }
        #endregion
        // AjaxHandler Method
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc
            IEnumerable<CCRMServiceMasterViewModel> filteredCCRMServiceMasterViewModel;

            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "ServiceDetails";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "ServiceDetails Like '%" + param.sSearch + "%' or CallCharges Like '%" + param.sSearch + "%'or ServiceType Like '%" + param.sSearch + "%'";
                        //_searchBy = "ID Like '%" + param.sSearch + "%' or FeedbackPoints Like '%" + param.sSearch + "%'";
                        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "CallCharges";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "ServiceDetails Like '%" + param.sSearch + "%'  or CallCharges Like '%" + param.sSearch + "%'or ServiceType Like '%" + param.sSearch + "%'";
                        // _searchBy = "ID Like '%" + param.sSearch + "%' or FeedbackPoints Like '%" + param.sSearch + "%'";
                        //this "if" block is added for search functionality
                    }
                    break;
                case 2:
                    _sortBy = "ServiceType";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "ServiceDetails Like '%" + param.sSearch + "%' or CallCharges Like '%" + param.sSearch + "%'or ServiceType Like '%" + param.sSearch + "%'";
                        //_searchBy = "ID Like '%" + param.sSearch + "%' or FeedbackPoints Like '%" + param.sSearch + "%'";
                        //this "if" block is added for search functionality
                    }
                    break;
              

            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            filteredCCRMServiceMasterViewModel = GetCCRMServiceMaster(out TotalRecords);
            var records = filteredCCRMServiceMasterViewModel.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { c.ServiceDetails.ToString(), Convert.ToString(c.ID), Convert.ToString(c.ServiceDescription), Convert.ToString(c.CallCharges), Convert.ToString(c.ServiceType) };

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}