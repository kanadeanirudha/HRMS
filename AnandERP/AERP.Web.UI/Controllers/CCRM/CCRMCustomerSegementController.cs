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
    public class CCRMCustomerSegementController : BaseController
    {
        ICCRMCustomerSegementBA _CCRMCustomerSegementBA = null;
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

        public CCRMCustomerSegementController()
        {
            _CCRMCustomerSegementBA = new CCRMCustomerSegementBA();

        }
        #region Controller Methods
        // GET: CCRMCustomerSegement
        public ActionResult Index()
        {
            if (Convert.ToString(Session["UserType"]) == "A" || Convert.ToInt32(Session["Admin Manager"]) > 0)
            {
                return View("/Views/CCRM/CCRMCustomerSegement/Index.cshtml");
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
                CCRMCustomerSegementViewModel model = new CCRMCustomerSegementViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/CCRM/CCRMCustomerSegement/List.cshtml", model);
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
            CCRMCustomerSegementViewModel model = new CCRMCustomerSegementViewModel();

            return PartialView("/Views/CCRM/CCRMCustomerSegement/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(CCRMCustomerSegementViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.CCRMCustomerSegementDTO != null)
                    {
                        model.CCRMCustomerSegementDTO.ConnectionString = _connectioString;

                        model.CCRMCustomerSegementDTO.SegementName = model.SegementName;
                        model.CCRMCustomerSegementDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<CCRMCustomerSegement> response = _CCRMCustomerSegementBA.InsertCCRMCustomerSegement(model.CCRMCustomerSegementDTO);
                        model.CCRMCustomerSegementDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);

                    }
                    return Json(model.CCRMCustomerSegementDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public ActionResult Edit(byte id)
        {
            CCRMCustomerSegementViewModel model = new CCRMCustomerSegementViewModel();
            try
            {



                model.CCRMCustomerSegementDTO = new CCRMCustomerSegement();
                model.CCRMCustomerSegementDTO.ID = id;
                model.CCRMCustomerSegementDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<CCRMCustomerSegement> response = _CCRMCustomerSegementBA.SelectByID(model.CCRMCustomerSegementDTO);
                if (response != null && response.Entity != null)
                {
                    model.CCRMCustomerSegementDTO.ID = response.Entity.ID;
                    model.CCRMCustomerSegementDTO.SegementName = response.Entity.SegementName;



                }

                return PartialView("/Views/CCRM/CCRMCustomerSegement/Edit.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(CCRMCustomerSegementViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.CCRMCustomerSegementDTO != null)
                    {
                        if (model != null && model.CCRMCustomerSegementDTO != null)
                        {
                            model.CCRMCustomerSegementDTO.ConnectionString = _connectioString;
                            model.CCRMCustomerSegementDTO.SegementName = model.SegementName;
                            model.CCRMCustomerSegementDTO.ID = model.ID;
                            model.CCRMCustomerSegementDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                            IBaseEntityResponse<CCRMCustomerSegement> response = _CCRMCustomerSegementBA.UpdateCCRMCustomerSegement(model.CCRMCustomerSegementDTO);
                            model.CCRMCustomerSegementDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                        }
                    }
                    return Json(model.CCRMCustomerSegementDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public ActionResult Delete(byte ID)
        {
            CCRMCustomerSegementViewModel model = new CCRMCustomerSegementViewModel();
            try
            {
                if (ID > 0)
                {
                    if (ID > 0)
                    {
                        CCRMCustomerSegement CCRMCustomerSegementDTO = new CCRMCustomerSegement();
                        CCRMCustomerSegementDTO.ConnectionString = _connectioString;
                        CCRMCustomerSegementDTO.ID = ID;
                        CCRMCustomerSegementDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<CCRMCustomerSegement> response = _CCRMCustomerSegementBA.DeleteCCRMCustomerSegement(CCRMCustomerSegementDTO);
                        model.CCRMCustomerSegementDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
                    }
                    return Json(model.CCRMCustomerSegementDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public IEnumerable<CCRMCustomerSegementViewModel> GetCCRMCustomerSegement(out int TotalRecords)
        {
            CCRMCustomerSegementSearchRequest searchRequest = new CCRMCustomerSegementSearchRequest();
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
            List<CCRMCustomerSegementViewModel> listCCRMCustomerSegementViewModel = new List<CCRMCustomerSegementViewModel>();
            List<CCRMCustomerSegement> listCCRMCustomerSegement = new List<CCRMCustomerSegement>();
            IBaseEntityCollectionResponse<CCRMCustomerSegement> baseEntityCollectionResponse = _CCRMCustomerSegementBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listCCRMCustomerSegement = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (CCRMCustomerSegement item in listCCRMCustomerSegement)
                    {
                        CCRMCustomerSegementViewModel CCRMCustomerSegementViewModel = new CCRMCustomerSegementViewModel();
                        CCRMCustomerSegementViewModel.CCRMCustomerSegementDTO = item;
                        listCCRMCustomerSegementViewModel.Add(CCRMCustomerSegementViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listCCRMCustomerSegementViewModel;
        }
        #endregion

        // AjaxHandler Method
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc
            IEnumerable<CCRMCustomerSegementViewModel> filteredCCRMCustomerSegementViewModel;

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
                        _searchBy = "ID Like '%" + param.sSearch + "%' or SegementName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "SegementName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "ID Like '%" + param.sSearch + "%' or SegementName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;

            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            filteredCCRMCustomerSegementViewModel = GetCCRMCustomerSegement(out TotalRecords);
            var records = filteredCCRMCustomerSegementViewModel.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { c.SegementName.ToString(), Convert.ToString(c.ID)};

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}