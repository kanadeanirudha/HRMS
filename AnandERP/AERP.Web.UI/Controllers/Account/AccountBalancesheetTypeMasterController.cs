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
    public class AccountBalancesheetTypeMasterController : BaseController
    {
        IAccountBalancesheetTypeMasterBA _accountBalancesheetTypeMasterBA = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public AccountBalancesheetTypeMasterController()
        {
            _accountBalancesheetTypeMasterBA = new AccountBalancesheetTypeMasterBA();
        }

        #region Controller Methods
        public ActionResult Index()
        {
            //if (Convert.ToInt32(Session["SuperUser"]) > 0 || Convert.ToInt32(Session["FinMgr"]) > 0)
            if (Convert.ToInt32(Session["Account Manager"]) > 0)
            {
                return View("/Views/Accounts/AccountBalancesheetTypeMaster/Index.cshtml");
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
                AccountBalancesheetTypeMasterViewModel model = new AccountBalancesheetTypeMasterViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Accounts/AccountBalancesheetTypeMaster/List.cshtml", model);
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
            AccountBalancesheetTypeMasterViewModel model = new AccountBalancesheetTypeMasterViewModel();
            List<SelectListItem> li = new List<SelectListItem>();
            li.Add(new SelectListItem { Text = "Grant", Value = "1" });
            li.Add(new SelectListItem { Text = "Non-Grant", Value = "2" });
            ViewData["AccBalsheetType"] = li;
            return PartialView("/Views/Accounts/AccountBalancesheetTypeMaster/Create.cshtml",model);
        }

        [HttpPost]
        public ActionResult Create(AccountBalancesheetTypeMasterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.AccountBalancesheetTypeMasterDTO != null)
                    {
                        model.AccountBalancesheetTypeMasterDTO.ConnectionString = _connectioString;
                        model.AccountBalancesheetTypeMasterDTO.AccBalsheetTypeDesc = model.AccBalsheetTypeDesc;
                        model.AccountBalancesheetTypeMasterDTO.AccBalsheetTypeCode = model.AccBalsheetTypeCode;
                        model.AccountBalancesheetTypeMasterDTO.AccBalsheetType = model.AccBalsheetType;
                        model.AccountBalancesheetTypeMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<AccountBalancesheetTypeMaster> response = _accountBalancesheetTypeMasterBA.InsertAccountBalancesheetTypeMaster(model.AccountBalancesheetTypeMasterDTO);
                        model.AccountBalancesheetTypeMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    }
                    return Json(model.AccountBalancesheetTypeMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public ActionResult Edit(byte ID)
        {
            try
            {
                AccountBalancesheetTypeMasterViewModel model = new AccountBalancesheetTypeMasterViewModel();

                model.AccountBalancesheetTypeMasterDTO = new AccountBalancesheetTypeMaster();
                model.AccountBalancesheetTypeMasterDTO.ID = ID;
                model.AccountBalancesheetTypeMasterDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<AccountBalancesheetTypeMaster> response = _accountBalancesheetTypeMasterBA.SelectByID(model.AccountBalancesheetTypeMasterDTO);

                if (response != null && response.Entity != null)
                {
                    model.AccountBalancesheetTypeMasterDTO.ID = response.Entity.ID;
                    model.AccountBalancesheetTypeMasterDTO.AccBalsheetTypeDesc = response.Entity.AccBalsheetTypeDesc;
                    model.AccountBalancesheetTypeMasterDTO.AccBalsheetTypeCode = response.Entity.AccBalsheetTypeCode;
                    model.AccountBalancesheetTypeMasterDTO.IsActive = response.Entity.IsActive;
                }

                return PartialView("/Views/Accounts/AccountBalancesheetTypeMaster/Edit.cshtml",model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }

        [HttpPost]
        public ActionResult Edit(AccountBalancesheetTypeMasterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.AccountBalancesheetTypeMasterDTO != null)
                    {
                        model.AccountBalancesheetTypeMasterDTO.ConnectionString = _connectioString;
                        model.AccountBalancesheetTypeMasterDTO.ID = model.ID;
                        model.AccountBalancesheetTypeMasterDTO.AccBalsheetTypeDesc = model.AccBalsheetTypeDesc;
                        model.AccountBalancesheetTypeMasterDTO.AccBalsheetTypeCode = model.AccBalsheetTypeCode;
                        model.AccountBalancesheetTypeMasterDTO.IsActive = model.IsActive;
                        model.AccountBalancesheetTypeMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<AccountBalancesheetTypeMaster> response = _accountBalancesheetTypeMasterBA.UpdateAccountBalancesheetTypeMaster(model.AccountBalancesheetTypeMasterDTO);
                        model.AccountBalancesheetTypeMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                    }
                    return Json(model.AccountBalancesheetTypeMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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

       
        public ActionResult Delete(byte ID)
        {
            try
            {
                
                    AccountBalancesheetTypeMasterViewModel model = new AccountBalancesheetTypeMasterViewModel();
                    AccountBalancesheetTypeMaster accountBalancesheetTypeMasterDTO = new AccountBalancesheetTypeMaster();
                    accountBalancesheetTypeMasterDTO.ConnectionString = _connectioString;
                    accountBalancesheetTypeMasterDTO.ID = ID;
                    accountBalancesheetTypeMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<AccountBalancesheetTypeMaster> response = _accountBalancesheetTypeMasterBA.DeleteAccountBalancesheetTypeMaster(accountBalancesheetTypeMasterDTO);
                    model.AccountBalancesheetTypeMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
                    return Json(model.AccountBalancesheetTypeMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
                
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }
        #endregion

        #region Methods
        [NonAction]
        public List<AccountBalancesheetTypeMaster> GetListAccountBalancesheetTypeMaster(out int TotalRecords)
        {
            List<AccountBalancesheetTypeMaster> listAccountBalancesheetTypeMaster = new List<AccountBalancesheetTypeMaster>();
            AccountBalancesheetTypeMasterSearchRequest searchRequest = new AccountBalancesheetTypeMasterSearchRequest();
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
            IBaseEntityCollectionResponse<AccountBalancesheetTypeMaster> baseEntityCollectionResponse = _accountBalancesheetTypeMasterBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listAccountBalancesheetTypeMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listAccountBalancesheetTypeMaster;
        }
        #endregion

         #region Ajax Handler
        /// <summary>
        /// AJAX Method for binding List Account Balance Sheet master
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<AccountBalancesheetTypeMaster> filteredAccountBalancesheetTypeMaster;

            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "ActBalsheetTypeDesc";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "ActBalsheetTypeDesc Like '%" + param.sSearch + "%' or ActBalsheetTypeCode Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "ActBalsheetTypeCode";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "ActBalsheetTypeDesc Like '%" + param.sSearch + "%' or ActBalsheetTypeCode Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            filteredAccountBalancesheetTypeMaster = GetListAccountBalancesheetTypeMaster(out TotalRecords);
            var records = filteredAccountBalancesheetTypeMaster.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.AccBalsheetTypeDesc), Convert.ToString(c.AccBalsheetTypeCode), Convert.ToString(c.ID), };

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
         #endregion
    }

}
