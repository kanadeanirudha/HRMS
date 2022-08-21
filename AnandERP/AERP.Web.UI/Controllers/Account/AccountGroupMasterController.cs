using AERP.Base.DTO;
using AERP.DTO;
using AERP.Business.BusinessAction;
using AERP.ViewModel;
using System;
using AERP.ExceptionManager;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using AERP.Common;   
namespace AERP.Web.UI.Controllers
{
    public class AccountGroupMasterController : BaseController
    {
        #region ------------CONTROLLER CLASS VARIABLE------------
        IAccountGroupMasterBA _accountGroupMasterBA = null;
        IAccountCategoryMasterBA _accountCategoryMasterBA = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        #endregion

        #region ------------CONTROLLER CLASS CONSTRUCTOR------------
        public AccountGroupMasterController()
        {
            _accountGroupMasterBA = new AccountGroupMasterBA();
            _accountCategoryMasterBA = new AccountCategoryMasterBA();
        }
        #endregion

        #region ------------CONTROLLER ACTION METHODS------------
        public ActionResult Index()
        {
            if (Convert.ToInt32(Session["Account Manager"]) > 0)
            {
                return View("/Views/Accounts/AccountGroupMaster/Index.cshtml");
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
                AccountGroupMasterViewModel model = new AccountGroupMasterViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Accounts/AccountGroupMaster/List.cshtml", model);
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
            try
            {
                AccountGroupMasterViewModel model = new AccountGroupMasterViewModel();
                List<AccountCategoryMaster> ListCategoryName = GetListAccountCategoryMaster();
                List<SelectListItem> listItem = new List<SelectListItem>();
                foreach (AccountCategoryMaster accountCategoryMaster in ListCategoryName)
                {
                    listItem.Add(new SelectListItem { Value = accountCategoryMaster.ID.ToString(), Text = accountCategoryMaster.CategoryDescription + " [ " + accountCategoryMaster.HeadName + " ]" });
                }
                ViewBag.AccountCategoryNameList = listItem;
                return PartialView("/Views/Accounts/AccountGroupMaster/Create.cshtml",model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }

        [HttpPost]
        public ActionResult Create(AccountGroupMasterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.AccountGroupMasterDTO != null)
                    {
                        model.AccountGroupMasterDTO.ConnectionString = _connectioString;
                        model.AccountGroupMasterDTO.ID = model.ID;
                        model.AccountGroupMasterDTO.GroupCode = model.GroupCode;
                        model.AccountGroupMasterDTO.GroupDescription = model.GroupDescription;
                        model.AccountGroupMasterDTO.CategoryID = model.CategoryID;
                        model.AccountGroupMasterDTO.PrintingSequence = model.PrintingSequence;
                        model.AccountGroupMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<AccountGroupMaster> response = _accountGroupMasterBA.InsertAccountGroupMaster(model.AccountGroupMasterDTO);
                        model.AccountGroupMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    }
                    return Json(model.AccountGroupMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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

        [HttpGet]
        public ActionResult Edit(Int16 id)
        {
            try
            {
                AccountGroupMasterViewModel model = new AccountGroupMasterViewModel();
                model.ID = id;
                model.AccountGroupMasterDTO.ConnectionString = _connectioString;
                IBaseEntityResponse<AccountGroupMaster> response = _accountGroupMasterBA.SelectByID(model.AccountGroupMasterDTO);

                if (response != null && response.Entity != null)
                {
                    model.AccountGroupMasterDTO.ID = response.Entity.ID;
                    model.AccountGroupMasterDTO.GroupCode = response.Entity.GroupCode;
                    model.AccountGroupMasterDTO.GroupDescription = response.Entity.GroupDescription;
                    model.AccountGroupMasterDTO.CategoryID = response.Entity.CategoryID;
                    model.AccountGroupMasterDTO.PrintingSequence = response.Entity.PrintingSequence;
                    model.AccountGroupMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserId"]);
                    model.AccountGroupMasterDTO.IsActive = response.Entity.IsActive;
                }
                List<AccountCategoryMaster> ListCategoryName = GetListAccountCategoryMaster();
                List<SelectListItem> listItem = new List<SelectListItem>();
                foreach (AccountCategoryMaster accountCategoryMaster in ListCategoryName)
                {
                    listItem.Add(new SelectListItem { Value = accountCategoryMaster.ID.ToString(), Text = accountCategoryMaster.CategoryDescription + " [ " + accountCategoryMaster.HeadName + " ]" });
                }
                ViewBag.AccountCategoryNameList = listItem;
                return PartialView("/Views/Accounts/AccountGroupMaster/Edit.cshtml",model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(AccountGroupMasterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.AccountGroupMasterDTO != null)
                    {
                        if (model != null && model.AccountGroupMasterDTO != null)
                        {
                            model.AccountGroupMasterDTO.ConnectionString = _connectioString;
                            model.AccountGroupMasterDTO.ID = model.ID;
                            model.AccountGroupMasterDTO.GroupCode = model.GroupCode;
                            model.AccountGroupMasterDTO.GroupDescription = model.GroupDescription;
                            model.AccountGroupMasterDTO.CategoryID = model.CategoryID;
                            model.AccountGroupMasterDTO.PrintingSequence = model.PrintingSequence;
                            model.AccountGroupMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                            IBaseEntityResponse<AccountGroupMaster> response = _accountGroupMasterBA.UpdateAccountGroupMaster(model.AccountGroupMasterDTO);
                            model.AccountGroupMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                        }
                    }
                    return Json(model.AccountGroupMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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

        
        public ActionResult Delete(short ID)
        {
            try
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                IBaseEntityResponse<AccountGroupMaster> response = null;
                
                    AccountGroupMasterViewModel model = new AccountGroupMasterViewModel();
                    AccountGroupMaster AccountGroupMasterDTO = new AccountGroupMaster();
                    AccountGroupMasterDTO.ConnectionString = _connectioString;
                    AccountGroupMasterDTO.ID = ID;
                    AccountGroupMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]); 
                    response = _accountGroupMasterBA.DeleteAccountGroupMaster(AccountGroupMasterDTO);
                    model.AccountGroupMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
                    return Json(model.AccountGroupMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
                
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }
        #endregion

        #region ------------CONTROLLER NON ACTION METHODS------------

        [NonAction]
        public List<AccountGroupMaster> GetListAccountGroupMaster(out int _totalRecords)
        {
            List<AccountGroupMaster> listAccountGroupMaster = new List<AccountGroupMaster>();
            AccountGroupMasterSearchRequest searchRequest = new AccountGroupMasterSearchRequest();
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
            IBaseEntityCollectionResponse<AccountGroupMaster> baseEntityCollectionResponse = _accountGroupMasterBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listAccountGroupMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            _totalRecords = baseEntityCollectionResponse.TotalRecords;
            return listAccountGroupMaster;
        }

        [NonAction]
        public List<AccountCategoryMaster> GetListAccountCategoryMaster()
        {
            List<AccountCategoryMaster> listAccountCategoryMaster = new List<AccountCategoryMaster>();
            AccountCategoryMasterSearchRequest searchRequest = new AccountCategoryMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            IBaseEntityCollectionResponse<AccountCategoryMaster> baseEntityCollectionResponse = _accountCategoryMasterBA.GetCategoryList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listAccountCategoryMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listAccountCategoryMaster;
        }

        #endregion

        #region ------------CONTROLLER AJAX HANDLER METHODS------------

        /// <summary>
        /// AJAX Method for binding List Account category master
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<AccountGroupMaster> filteredAccountGroupMaster;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "CategoryDescription";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "GroupDescription Like '%" + param.sSearch + "%' or GroupCode Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "CategoryDescription";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "GroupDescription Like '%" + param.sSearch + "%' or GroupCode Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            filteredAccountGroupMaster = GetListAccountGroupMaster(out TotalRecords);
            var records = filteredAccountGroupMaster.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.GroupDescriptionCategory), Convert.ToString(c.IsActive), Convert.ToString(c.ID), Convert.ToString(c.CategoryDescription) };

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}
