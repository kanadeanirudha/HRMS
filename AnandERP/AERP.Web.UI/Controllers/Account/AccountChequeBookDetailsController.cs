using AERP.Base.DTO;
using AERP.DTO;
using AERP.Business.BusinessAction;
using AERP.ExceptionManager;
using AERP.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using AERP.Common;
using AERP.DataProvider;
namespace AERP.Web.UI.Controllers
{
    public class AccountChequeBookDetailsController : BaseController
    {
        IAccountChequeBookDetailsBA _accountChequeBookDetailsBA = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public AccountChequeBookDetailsController()
        {
            _accountChequeBookDetailsBA = new AccountChequeBookDetailsBA();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
            if (Convert.ToInt32(Session["Account Manager"]) > 0)
            {
                return View("/Views/Accounts/AccountChequeBookDetails/Index.cshtml");
            }
            else
            {
                return RedirectToAction("UnauthorizedAccess", "Home");
            }
        }

        public ActionResult List(string actionMode, string selectedBalsheet)
        {
            try
            {
                if (!string.IsNullOrEmpty(selectedBalsheet))
                {
                    AccountChequeBookDetailsViewModel model = new AccountChequeBookDetailsViewModel();
                    if (!string.IsNullOrEmpty(actionMode))
                    {
                        TempData["ActionMode"] = actionMode;
                    }
                    return PartialView("/Views/Accounts/AccountChequeBookDetails/List.cshtml", model);
                }
                else
                {
                    return RedirectToActionPermanent("BalancesheetError", "Home");
                }
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpGet]
        public ActionResult Edit(string accountDetailsWithactionMode)
        {
            try
            {

                string[] splitData = accountDetailsWithactionMode.Split(':');
                Int16 AccountID = Convert.ToInt16(splitData[0]);
                string AccountName = splitData[1].Replace('~', ' ');
                AccountChequeBookDetailsViewModel model = new AccountChequeBookDetailsViewModel();
                model.AccountID = AccountID;
                model.AccountName = AccountName;
                TempData["ActionMode"] = splitData[2];
                return PartialView("/Views/Accounts/AccountChequeBookDetails/Edit.cshtml",model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }
        [HttpGet]
        public ActionResult CancelCheque(int ChequeNumber, int ChequeBookID, string AccountName, Int16 AccountID)
        {
            try
            {

                AccountChequeBookDetailsViewModel model = new AccountChequeBookDetailsViewModel();
                model.AccountID = AccountID;
                model.AccountName = AccountName;
                model.ChequeNo = ChequeNumber;
                model.ChequeBookID = ChequeBookID;
                return PartialView("/Views/Accounts/AccountChequeBookDetails/CancelCheque.cshtml",model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }
        [HttpPost]
        public ActionResult CancelCheque(AccountChequeBookDetailsViewModel model)
        {
            try
            {
                if (model != null && model.AccountChequeBookDetailsDTO != null)
                {
                    if (model != null && model.AccountChequeBookDetailsDTO != null)
                    {
                        model.AccountChequeBookDetailsDTO.ConnectionString = _connectioString;
                        model.AccountChequeBookDetailsDTO.ChequeNo = model.ChequeNo;
                        model.AccountChequeBookDetailsDTO.ChequeBookID = model.ChequeBookID;
                        model.AccountChequeBookDetailsDTO.ChequeDescription = model.ChequeDescription;
                        //model.AccountChequeBookDetailsDTO.AccountID = model.AccountID;
                        //model.AccountChequeBookDetailsDTO.AccountName = model.AccountName;
                        model.AccountChequeBookDetailsDTO.ChequeStatus = "C";
                        model.AccountChequeBookDetailsDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<AccountChequeBookDetails> response = _accountChequeBookDetailsBA.InsertAccountChequeBookDetails(model.AccountChequeBookDetailsDTO);
                        model.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                        TempData["ActionMode"] = ActionModeEnum.Insert;
                    }
                    
                    return Json(model, JsonRequestBehavior.AllowGet);
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
        #endregion

        // Non-Action Method
        #region Methods
        public IEnumerable<AccountChequeBookDetailsViewModel> GetAccountChequeBookDetails(out int TotalRecords, string SelectedBalsheetMstID)
        {

            AccountChequeBookDetailsSearchRequest searchRequest = new AccountChequeBookDetailsSearchRequest();
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
                    searchRequest.AccBalsheetID = Convert.ToInt16(SelectedBalsheetMstID);
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "ModifiedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.AccBalsheetID = Convert.ToInt16(SelectedBalsheetMstID);
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
                searchRequest.AccBalsheetID = Convert.ToInt16(SelectedBalsheetMstID);
            }
            List<AccountChequeBookDetailsViewModel> listAccountChequeBookDetailsViewModel = new List<AccountChequeBookDetailsViewModel>();
            List<AccountChequeBookDetails> listAccountChequeBookDetails = new List<AccountChequeBookDetails>();
            IBaseEntityCollectionResponse<AccountChequeBookDetails> baseEntityCollectionResponse = _accountChequeBookDetailsBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listAccountChequeBookDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (AccountChequeBookDetails item in listAccountChequeBookDetails)
                    {
                        AccountChequeBookDetailsViewModel AccountChequeBookDetailsViewModel = new AccountChequeBookDetailsViewModel();
                        AccountChequeBookDetailsViewModel.AccountChequeBookDetailsDTO = item;
                        listAccountChequeBookDetailsViewModel.Add(AccountChequeBookDetailsViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listAccountChequeBookDetailsViewModel;
        }
        public IEnumerable<AccountChequeBookDetailsViewModel> GetAccountChequeBookDetailsForEditView(out int TotalRecords, string SelectedBalsheetMstID, string AccountID)
        {
            AccountChequeBookDetailsSearchRequest searchRequest = new AccountChequeBookDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            _actionMode = Convert.ToString(TempData["ActionMode"]);
            if (Enum.TryParse(_actionMode, out actionModeEnum))     // checks actionMode i.e. Insert or Update // 
            {
                if (actionModeEnum == ActionModeEnum.Insert)        // parameters for SelectAll procedures under Insert or Update mode condition
                {
                    searchRequest.SortBy = "DD.CreatedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "desc";
                    searchRequest.AccountID = Convert.ToInt16(AccountID);
                    searchRequest.AccBalsheetID = Convert.ToInt16(SelectedBalsheetMstID);
                }
            }
            else
            {
                searchRequest.SortBy = _sortBy;
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;
                searchRequest.AccountID = Convert.ToInt16(AccountID);
                searchRequest.AccBalsheetID = Convert.ToInt16(SelectedBalsheetMstID);
            }
            List<AccountChequeBookDetailsViewModel> listAccountChequeBookDetailsViewModel = new List<AccountChequeBookDetailsViewModel>();
            List<AccountChequeBookDetails> listAccountChequeBookDetails = new List<AccountChequeBookDetails>();
            IBaseEntityCollectionResponse<AccountChequeBookDetails> baseEntityCollectionResponse = _accountChequeBookDetailsBA.GetBySearchForEditView(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listAccountChequeBookDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (AccountChequeBookDetails item in listAccountChequeBookDetails)
                    {
                        AccountChequeBookDetailsViewModel AccountChequeBookDetailsViewModel = new AccountChequeBookDetailsViewModel();
                        AccountChequeBookDetailsViewModel.AccountChequeBookDetailsDTO = item;
                        listAccountChequeBookDetailsViewModel.Add(AccountChequeBookDetailsViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listAccountChequeBookDetailsViewModel;
        }
        #endregion

        // AjaxHandler Method
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param, string SelectedBalancesheetID)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<AccountChequeBookDetailsViewModel> filteredAccountChequeBookDetails;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "AccountName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "AccountName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            if (!string.IsNullOrEmpty(SelectedBalancesheetID))
            {
                filteredAccountChequeBookDetails = GetAccountChequeBookDetails(out TotalRecords, SelectedBalancesheetID);
            }
            else
            {
                filteredAccountChequeBookDetails = new List<AccountChequeBookDetailsViewModel>();
                TotalRecords = 0;
            }

            var records = filteredAccountChequeBookDetails.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.AccountName), Convert.ToString(c.AccountID) };

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);


        }
        public ActionResult AjaxHandlerForEditView(JQueryDataTableParamModel param, string SelectedBalancesheetID, string AccountID)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<AccountChequeBookDetailsViewModel> filteredAccountChequeBookDetails;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "Number";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "Number Like '%" + param.sSearch + "%'";           //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "ChequeDescription";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "Number Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;

            if (!string.IsNullOrEmpty(SelectedBalancesheetID) && !string.IsNullOrEmpty(AccountID))
            {
                filteredAccountChequeBookDetails = GetAccountChequeBookDetailsForEditView(out TotalRecords, SelectedBalancesheetID, AccountID);
            }
            else
            {
                filteredAccountChequeBookDetails = new List<AccountChequeBookDetailsViewModel>();
                TotalRecords = 0;
            }
            var records = filteredAccountChequeBookDetails.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.ChequeNo), Convert.ToString(c.ChequeStatus), Convert.ToString(c.CanceledBy + " " + c.ChequeDescription), Convert.ToString(c.ChequeBookID), Convert.ToString(c.ChequeAmount) };

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}