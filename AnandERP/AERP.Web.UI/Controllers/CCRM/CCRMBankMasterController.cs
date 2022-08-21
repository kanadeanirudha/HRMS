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
    public class CCRMBankMasterController : BaseController
    {
        ICCRMBankMasterBA _CCRMBankMasterBA = null;
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

        public CCRMBankMasterController()
        {
            _CCRMBankMasterBA = new CCRMBankMasterBA();

        }
        #region Controller Methods
        // GET: CCRMBankMaster
        public ActionResult Index()
        {
            if (Convert.ToString(Session["UserType"]) == "A" || Convert.ToInt32(Session["Admin Manager"]) > 0)
            {
                return View("/Views/CCRM/CCRMBankMaster/Index.cshtml");
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
                CCRMBankMasterViewModel model = new CCRMBankMasterViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/CCRM/CCRMBankMaster/List.cshtml", model);
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
            CCRMBankMasterViewModel model = new CCRMBankMasterViewModel();

            return PartialView("/Views/CCRM/CCRMBankMaster/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(CCRMBankMasterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.CCRMBankMasterDTO != null)
                    {
                        model.CCRMBankMasterDTO.ConnectionString = _connectioString;

                        model.CCRMBankMasterDTO.BankName = model.BankName;
                        model.CCRMBankMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<CCRMBankMaster> response = _CCRMBankMasterBA.InsertCCRMBankMaster(model.CCRMBankMasterDTO);
                        model.CCRMBankMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);

                    }
                    return Json(model.CCRMBankMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
            CCRMBankMasterViewModel model = new CCRMBankMasterViewModel();
            try
            {



                model.CCRMBankMasterDTO = new CCRMBankMaster();
                model.CCRMBankMasterDTO.ID = id;
                model.CCRMBankMasterDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<CCRMBankMaster> response = _CCRMBankMasterBA.SelectByID(model.CCRMBankMasterDTO);
                if (response != null && response.Entity != null)
                {
                    model.CCRMBankMasterDTO.ID = response.Entity.ID;
                    model.CCRMBankMasterDTO.BankName = response.Entity.BankName;



                }

                return PartialView("/Views/CCRM/CCRMBankMaster/Edit.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(CCRMBankMasterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.CCRMBankMasterDTO != null)
                    {
                        if (model != null && model.CCRMBankMasterDTO != null)
                        {
                            model.CCRMBankMasterDTO.ConnectionString = _connectioString;
                            model.CCRMBankMasterDTO.BankName = model.BankName;
                            model.CCRMBankMasterDTO.ID = model.ID;
                            model.CCRMBankMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                            IBaseEntityResponse<CCRMBankMaster> response = _CCRMBankMasterBA.UpdateCCRMBankMaster(model.CCRMBankMasterDTO);
                            model.CCRMBankMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                        }
                    }
                    return Json(model.CCRMBankMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
            CCRMBankMasterViewModel model = new CCRMBankMasterViewModel();
            try
            {
                if (ID > 0)
                {
                    if (ID > 0)
                    {
                        CCRMBankMaster CCRMBankMasterDTO = new CCRMBankMaster();
                        CCRMBankMasterDTO.ConnectionString = _connectioString;
                        CCRMBankMasterDTO.ID = ID;
                        CCRMBankMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<CCRMBankMaster> response = _CCRMBankMasterBA.DeleteCCRMBankMaster(CCRMBankMasterDTO);
                        model.CCRMBankMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
                    }
                    return Json(model.CCRMBankMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public IEnumerable<CCRMBankMasterViewModel> GetCCRMBankMaster(out int TotalRecords)
        {
            CCRMBankMasterSearchRequest searchRequest = new CCRMBankMasterSearchRequest();
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
            List<CCRMBankMasterViewModel> listCCRMBankMasterViewModel = new List<CCRMBankMasterViewModel>();
            List<CCRMBankMaster> listCCRMBankMaster = new List<CCRMBankMaster>();
            IBaseEntityCollectionResponse<CCRMBankMaster> baseEntityCollectionResponse = _CCRMBankMasterBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listCCRMBankMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (CCRMBankMaster item in listCCRMBankMaster)
                    {
                        CCRMBankMasterViewModel CCRMBankMasterViewModel = new CCRMBankMasterViewModel();
                        CCRMBankMasterViewModel.CCRMBankMasterDTO = item;
                        listCCRMBankMasterViewModel.Add(CCRMBankMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listCCRMBankMasterViewModel;
        }
        #endregion

        // AjaxHandler Method
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc
            IEnumerable<CCRMBankMasterViewModel> filteredCCRMBankMasterViewModel;

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
                        _searchBy = "ID Like '%" + param.sSearch + "%' or BankName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "BankName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "ID Like '%" + param.sSearch + "%' or BankName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;

            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            filteredCCRMBankMasterViewModel = GetCCRMBankMaster(out TotalRecords);
            var records = filteredCCRMBankMasterViewModel.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { c.BankName.ToString(), Convert.ToString(c.ID) };

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}