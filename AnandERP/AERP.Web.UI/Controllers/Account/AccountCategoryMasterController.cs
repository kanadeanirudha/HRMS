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
    public class AccountCategoryMasterController : BaseController
    {
        IAccountCategoryMasterBA _accountCategoryMasterBA= null;
        IAccountHeadMasterBA _accountHeadMasterBA= null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        #region ------------CONTROLLER CLASS CONSTRUCTOR------------
        public AccountCategoryMasterController()
        {
            _accountCategoryMasterBA= new AccountCategoryMasterBA();
            _accountHeadMasterBA= new AccountHeadMasterBA();
        }
        #endregion

        #region ------------CONTROLLER ACTION METHODS------------
        public ActionResult Index()
        {
            if (Convert.ToInt32(Session["Account Manager"]) > 0)
            {
                return View("/Views/Accounts/AccountCategoryMaster/Index.cshtml");
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
                AccountCategoryMasterViewModel model = new AccountCategoryMasterViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Accounts/AccountCategoryMaster/List.cshtml", model);
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
                AccountCategoryMasterViewModel model = new AccountCategoryMasterViewModel();
                List<AccountHeadMaster> ListHeadName = GetListAccountHeadMaster();
                List<SelectListItem> listItem = new List<SelectListItem>();
                foreach (AccountHeadMaster accountHeadMaster in ListHeadName)
                {
                    listItem.Add(new SelectListItem { Value = accountHeadMaster.ID.ToString(), Text = accountHeadMaster.HeadName });
                }
                ViewBag.AccountHeadNameList = listItem;
                return PartialView("/Views/Accounts/AccountCategoryMaster/Create.cshtml",model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public ActionResult Create(AccountCategoryMasterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.AccountCategoryMasterDTO != null)
                    {
                        model.AccountCategoryMasterDTO.ConnectionString = _connectioString;
                        model.AccountCategoryMasterDTO.ID = model.ID;
                        model.AccountCategoryMasterDTO.CategoryCode = model.CategoryCode;
                        model.AccountCategoryMasterDTO.CategoryDescription = model.CategoryDescription;
                        model.AccountCategoryMasterDTO.HeadID = model.HeadID;
                        model.AccountCategoryMasterDTO.PrintingSequence = model.PrintingSequence;
                        model.AccountCategoryMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<AccountCategoryMaster> response = _accountCategoryMasterBA.InsertAccountCategoryMaster(model.AccountCategoryMasterDTO);
                        model.AccountCategoryMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    }
                    return Json(model.AccountCategoryMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
                AccountCategoryMasterViewModel model = new AccountCategoryMasterViewModel();
                model.ID = id;
                model.AccountCategoryMasterDTO.ConnectionString = _connectioString;
                IBaseEntityResponse<AccountCategoryMaster> response = _accountCategoryMasterBA.SelectByID(model.AccountCategoryMasterDTO);

                if (response != null && response.Entity != null)
                {
                    model.AccountCategoryMasterDTO.ID = response.Entity.ID;
                    model.AccountCategoryMasterDTO.CategoryCode = response.Entity.CategoryCode;
                    model.AccountCategoryMasterDTO.CategoryDescription = response.Entity.CategoryDescription;
                    model.AccountCategoryMasterDTO.HeadID = response.Entity.HeadID;
                    model.AccountCategoryMasterDTO.PrintingSequence = response.Entity.PrintingSequence;
                    model.AccountCategoryMasterDTO.IsActive = response.Entity.IsActive;
                    model.AccountCategoryMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserId"]);
                }
                List<AccountHeadMaster> ListHeadName = GetListAccountHeadMaster();
                List<SelectListItem> listItem = new List<SelectListItem>();
                foreach (AccountHeadMaster accountHeadMaster in ListHeadName)
                {
                    listItem.Add(new SelectListItem { Value = accountHeadMaster.ID.ToString(), Text = accountHeadMaster.HeadName });
                }
                ViewBag.AccountHeadNameList = listItem;
                return PartialView("/Views/Accounts/AccountCategoryMaster/Edit.cshtml",model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(AccountCategoryMasterViewModel model)
        {
            try
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                if (ModelState.IsValid)
                {
                    if (model != null && model.AccountCategoryMasterDTO != null)
                    {
                        model.AccountCategoryMasterDTO.ConnectionString = _connectioString;
                        model.AccountCategoryMasterDTO.ID = model.ID;
                        model.AccountCategoryMasterDTO.CategoryCode = model.CategoryCode;
                        model.AccountCategoryMasterDTO.CategoryDescription = model.CategoryDescription;
                        model.AccountCategoryMasterDTO.HeadID = model.HeadID;
                        model.AccountCategoryMasterDTO.PrintingSequence = model.PrintingSequence;
                        model.AccountCategoryMasterDTO.IsActive = model.IsActive;
                        model.AccountCategoryMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<AccountCategoryMaster> response = _accountCategoryMasterBA.UpdateAccountCategoryMaster(model.AccountCategoryMasterDTO);
                        model.AccountCategoryMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                    }
                    return Json(model.AccountCategoryMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
                AccountCategoryMasterViewModel model = new AccountCategoryMasterViewModel();
                AccountCategoryMaster AccountCategoryMasterDTO = new AccountCategoryMaster();
                AccountCategoryMasterDTO.ConnectionString = _connectioString;
                AccountCategoryMasterDTO.ID = ID;
                AccountCategoryMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                IBaseEntityResponse<AccountCategoryMaster> response  = _accountCategoryMasterBA.DeleteAccountCategoryMaster(AccountCategoryMasterDTO);
                model.AccountCategoryMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
                return Json(model.AccountCategoryMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public List<AccountCategoryMaster> GetListAccountCategoryMaster(out int _totalRecords)
        {
            List<AccountCategoryMaster> listAccountCategoryMaster = new List<AccountCategoryMaster>();

            AccountCategoryMasterSearchRequest searchRequest = new AccountCategoryMasterSearchRequest();
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
            IBaseEntityCollectionResponse<AccountCategoryMaster> baseEntityCollectionResponse = _accountCategoryMasterBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listAccountCategoryMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            _totalRecords = baseEntityCollectionResponse.TotalRecords;
            return listAccountCategoryMaster;
        }

        [NonAction]
        public List<AccountHeadMaster> GetListAccountHeadMaster()
        {
            List<AccountHeadMaster> listAccountHeadMaster = new List<AccountHeadMaster>();
            AccountHeadMasterSearchRequest searchRequest = new AccountHeadMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            IBaseEntityCollectionResponse<AccountHeadMaster> baseEntityCollectionResponse = _accountHeadMasterBA.GetAccountHeadNameList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listAccountHeadMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listAccountHeadMaster;
        }
        #endregion

        #region AjaxHandler Method
        public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<AccountCategoryMaster> filteredAccountCategoryMaster ;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "HeadName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "CategoryDescription Like '%" + param.sSearch + "%' or CategoryCode Like '%" + param.sSearch + "%' or HeadCode Like '%" + param.sSearch + "%' or HeadName Like '%"  +param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "HeadName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "CategoryDescription Like '%" + param.sSearch + "%' or CategoryCode Like '%" + param.sSearch + "%' or HeadCode Like '%" + param.sSearch + "%' or HeadName Like '%" + param.sSearch + "%'";  
                    }
                    break;
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            filteredAccountCategoryMaster = GetListAccountCategoryMaster(out TotalRecords);
            var records = filteredAccountCategoryMaster.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.CategoryDescriptionHead), Convert.ToString(c.IsActive), Convert.ToString(c.ID), Convert.ToString(c.HeadName), Convert.ToString(c.HeadID) };

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}
