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
    public class AccountCentreOpeningBalanceController : BaseController
    {
        #region ------------CONTROLLER CLASS VARIABLE------------

        IAccountCentreOpeningBalanceBA _accountCentreOpeningBalanceBA = null;
        //  AccountCentreOpeningBalanceViewModel _accountCentreOpeningBalanceViewModel = null;
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
        public AccountCentreOpeningBalanceController()
        {
            _accountCentreOpeningBalanceBA = new AccountCentreOpeningBalanceBA();
            //    _accountCentreOpeningBalanceViewModel = new AccountCentreOpeningBalanceViewModel();
        }
        #endregion

        #region ------------CONTROLLER ACTION METHODS------------
        public ActionResult Index()
        {
            return View("/Views/Accounts/AccountCentreOpeningBalance/Index.cshtml");
        }

        public ActionResult List(string selectedBalsheet, string AccountType)
        {
            try
            {
                if (!string.IsNullOrEmpty(selectedBalsheet))
                {
                    AccountCentreOpeningBalanceViewModel model = new AccountCentreOpeningBalanceViewModel();
                    //   List<SelectListItem> AccountTypeList = new List<SelectListItem>();
                    //  AccountTypeList.Add(new SelectListItem { Text = "------Select Account Type------", Value = "" });
                    //AccountTypeList.Add(new SelectListItem { Text = "Non Control Head Type", Value = "0" });
                    //AccountTypeList.Add(new SelectListItem { Text = "Control Head Type", Value = "1" });
                    //ViewData["AccountType"] = AccountTypeList;


                    model.AccountSessionMasterDTO = GetCurrentAccountSession();
                    if (model.AccountSessionMasterDTO != null)
                    {
                        var from = model.AccountSessionMasterDTO.SessionStartDatetime.Split(' ');
                        var to = model.AccountSessionMasterDTO.SessionEndDatetime.Split(' ');
                        model.SessionName = from[2] + " - " + to[2];
                        model.SessionID = model.AccountSessionMasterDTO.ID;
                    }
                    else
                    {
                        model.SessionName = "Session not defined !";
                    }

                    model.SelectedAccountType =AccountType;
                    return PartialView("/Views/Accounts/AccountCentreOpeningBalance/List.cshtml",model);
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

        [HttpPost]
        public ActionResult Create(AccountCentreOpeningBalanceViewModel model)
        {
            try
            {
                if (model != null && model.AccountCentreOpeningBalanceDTO != null)
                {
                    model.AccountCentreOpeningBalanceDTO.ConnectionString = _connectioString;
                    model.AccountCentreOpeningBalanceDTO.ID = model.ID;
                    model.AccountCentreOpeningBalanceDTO.AccSessionID = model.AccSessionID;
                    model.AccountCentreOpeningBalanceDTO.AccBalsheetMstID = model.AccBalsheetMstID;
                    model.AccountCentreOpeningBalanceDTO.SelectedXmlData = model.SelectedXmlData;
                    model.AccountCentreOpeningBalanceDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<AccountCentreOpeningBalance> response = _accountCentreOpeningBalanceBA.InsertAccountCentreOpeningBalance(model.AccountCentreOpeningBalanceDTO);
                    model.AccountCentreOpeningBalanceDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                    return Json(model.AccountCentreOpeningBalanceDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public ActionResult IndividualOpeningBalance(string IDs)
        {
            try
            {
                AccountCentreOpeningBalanceViewModel model = new AccountCentreOpeningBalanceViewModel();
                string[] splitIDs = IDs.Split('~');
                model.AccountCentreOpeningBalanceDTO.AccBalsheetMstID = Convert.ToInt16(splitIDs[0]);
                model.AccountCentreOpeningBalanceDTO.PersonType = splitIDs[1];
                model.AccountCentreOpeningBalanceDTO.AccountID = Convert.ToInt16(splitIDs[2]);
                model.AccountCentreOpeningBalanceDTO.AccountName = splitIDs[3].Replace(':', ' ');
                model.AccountCentreOpeningBalanceDTO.BalancesheetName = splitIDs[4].Replace(':', ' ');

                model.AccountSessionMasterDTO = GetCurrentAccountSession();
                if (model.AccountSessionMasterDTO != null)
                {
                    var from = model.AccountSessionMasterDTO.SessionStartDatetime.Split(' ');
                    var to = model.AccountSessionMasterDTO.SessionEndDatetime.Split(' ');
                    model.SessionName = from[2] + " - " + to[2];
                    model.SessionID = model.AccountSessionMasterDTO.ID;
                }
                else
                {
                    model.SessionName = "Session not defined !";
                }
                return PartialView("/Views/Accounts/AccountCentreOpeningBalance/IndividualOpeningBalance.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public ActionResult IndividualOpeningBalance(AccountCentreOpeningBalanceViewModel model)
        {
            try
            {
                if (model != null && model.AccountCentreOpeningBalanceDTO != null)
                {
                    model.AccountCentreOpeningBalanceDTO.ConnectionString = _connectioString;
                    model.AccountCentreOpeningBalanceDTO.AccBalsheetMstID = model.AccBalsheetMstID;
                    model.AccountCentreOpeningBalanceDTO.AccountID = model.AccountID;
                    model.AccountCentreOpeningBalanceDTO.AccSessionID = model.AccSessionID;
                    model.AccountCentreOpeningBalanceDTO.PersonType = model.PersonType;
                    model.AccountCentreOpeningBalanceDTO.SelectedXmlDataForIndividualBalance = model.SelectedXmlDataForIndividualBalance;
                    model.AccountCentreOpeningBalanceDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<AccountCentreOpeningBalance> response = _accountCentreOpeningBalanceBA.UpdateAccountCentreOpeningBalance(model.AccountCentreOpeningBalanceDTO);
                    model.AccountCentreOpeningBalanceDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                    return Json(model.AccountCentreOpeningBalanceDTO.errorMessage, JsonRequestBehavior.AllowGet);
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

        #region ------------CONTROLLER NON ACTION METHODS------------


        [NonAction]
        public List<AccountCentreOpeningBalance> GetListAccountCentreOpeningBalance(string SelectedBalanceSheet, string SelectedAccountType, string SelectedSessionID, out int TotalRecords)
        {
            List<AccountCentreOpeningBalance> listAccountCentreOpeningBalance = new List<AccountCentreOpeningBalance>();
            AccountCentreOpeningBalanceSearchRequest searchRequest = new AccountCentreOpeningBalanceSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.SortBy = _sortBy;
            searchRequest.StartRow = _startRow;
            searchRequest.EndRow = _startRow + _rowLength;
            searchRequest.BalancesheetID = Convert.ToInt16(SelectedBalanceSheet);
            searchRequest.AccountType = Convert.ToInt32(SelectedAccountType);
            searchRequest.AccSessionID = Convert.ToInt32(SelectedSessionID);
            searchRequest.SearchBy = _searchBy;
            searchRequest.SortDirection = _sortDirection;
            IBaseEntityCollectionResponse<AccountCentreOpeningBalance> baseEntityCollectionResponse = _accountCentreOpeningBalanceBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listAccountCentreOpeningBalance = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listAccountCentreOpeningBalance;
        }

        public List<AccountCentreOpeningBalance> GetListAccountIndividualOpeningBalance(int SelectedBalanceSheet, int SelectedAccountID, string SelectedPersonType, string SelectedSessionID, out int TotalRecords)
        {
            List<AccountCentreOpeningBalance> listAccountCentreOpeningBalance = new List<AccountCentreOpeningBalance>();
            AccountCentreOpeningBalanceSearchRequest searchRequest = new AccountCentreOpeningBalanceSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.SortBy = _sortBy;
            searchRequest.StartRow = _startRow;
            searchRequest.EndRow = _startRow + _rowLength;
            searchRequest.BalancesheetID = SelectedBalanceSheet;
            searchRequest.AccountID = SelectedAccountID;
            searchRequest.PersonType = SelectedPersonType;
            searchRequest.AccSessionID = Convert.ToInt32(SelectedSessionID);
            searchRequest.SearchBy = _searchBy;
            searchRequest.SortDirection = _sortDirection;
            IBaseEntityCollectionResponse<AccountCentreOpeningBalance> baseEntityCollectionResponse = _accountCentreOpeningBalanceBA.GetBySearchIndividualAccount(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listAccountCentreOpeningBalance = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listAccountCentreOpeningBalance;
        }

        #endregion

        #region ------------CONTROLLER AJAX HANDLER METHODS------------

        /// <summary>
        /// AJAX Method for binding List Account category master
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public ActionResult AjaxHandler(JQueryDataTableParamModel param, string SelectedBalanceSheet, string SelectedAccountType, string SelectedSessionID)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<AccountCentreOpeningBalance> filteredAccountCentreOpeningBalance;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "HeadCode";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "AccountName Like '%" + param.sSearch + "%' or PersonType Like '%" + param.sSearch + "%' or headcode  Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "PersonType";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "AccountName Like '%" + param.sSearch + "%' or PersonType Like '%" + param.sSearch + "%' or headcode  Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            if (!string.IsNullOrEmpty(SelectedBalanceSheet) && !string.IsNullOrEmpty(SelectedAccountType) && !string.IsNullOrEmpty(SelectedSessionID))
            {
                filteredAccountCentreOpeningBalance = GetListAccountCentreOpeningBalance(SelectedBalanceSheet, SelectedAccountType, SelectedSessionID, out TotalRecords);
            }
            else
            {
                filteredAccountCentreOpeningBalance = new List<AccountCentreOpeningBalance>();
                TotalRecords = 0;
            }

            var records = filteredAccountCentreOpeningBalance.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.AccountName), Convert.ToString(c.PersonType), Convert.ToString(c.AccountCode), Convert.ToString(c.HeadCode), Convert.ToString(c.ID), Convert.ToString(c.AccountID), String.Format("{0:0.00}", System.Math.Abs(c.OpeningBalance.Value)), Convert.ToString(c.TotalCreditAmount), Convert.ToString(c.TotalDebitAmount), /*Below property is used to decide the CreditDebitFlag in List View*/  Convert.ToString(c.OpeningBalance), };

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }



        /// <summary>
        /// AJAX Method for binding List Account category master
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public ActionResult AjaxHandlerIndividualOpeningBalance(JQueryDataTableParamModel param, string AccBalsheetMstID, string AccountID, string PersonType, string SelectedSessionID)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<AccountCentreOpeningBalance> filteredAccountIndividualOpeningBalance;
            if (PersonType == "E")
            {
                _sortBy = "EmployeeFirstName";
                if (string.IsNullOrEmpty(param.sSearch))
                {
                    _searchBy = string.Empty;
                }
                else
                {
                    _searchBy = "EmployeeFirstName Like '%" + param.sSearch + "%'  or EmployeeMiddleName Like '%" + param.sSearch + "%'  or EmployeeLastName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                }
            }
            if (PersonType == "S")
            {
                _sortBy = "FirstName";
                if (string.IsNullOrEmpty(param.sSearch))
                {
                    _searchBy = string.Empty;
                }
                else
                {
                    _searchBy = "FirstName Like '%" + param.sSearch + "%' or MiddleName Like '%" + param.sSearch + "%' or LastName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                }
            }
            if (PersonType == "U")
            {
                _sortBy = "FirstName";
                if (string.IsNullOrEmpty(param.sSearch))
                {
                    _searchBy = string.Empty;
                }
                else
                {
                    _searchBy = "FirstName Like '%" + param.sSearch + "%' or MiddleName Like '%" + param.sSearch + "%' or LastName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                }
            }
            if (PersonType == "C")
            {
                _sortBy = "CustomerName";
                if (string.IsNullOrEmpty(param.sSearch))
                {
                    _searchBy = string.Empty;
                }
                else
                {
                    _searchBy = "CustomerName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                }
            }

            if (PersonType == "B")
            {
                _sortBy = "BranchName";
                if (string.IsNullOrEmpty(param.sSearch))
                {
                    _searchBy = string.Empty;
                }
                else
                {
                    _searchBy = "BranchName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                }
            }
            if (PersonType == "F")
            {
                _sortBy = "FirstName";
                if (string.IsNullOrEmpty(param.sSearch))
                {
                    _searchBy = string.Empty;
                }
                else
                {
                    _searchBy = "FirstName Like '%" + param.sSearch + "%' or MiddleName Like '%" + param.sSearch + "%' or LastName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                }
            }
            if (PersonType == "D")
            {
                _sortBy = "FirstName";
                if (string.IsNullOrEmpty(param.sSearch))
                {
                    _searchBy = string.Empty;
                }
                else
                {
                    _searchBy = "FirstName Like '%" + param.sSearch + "%' or MiddleName Like '%" + param.sSearch + "%' or LastName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                }
            }
            if (PersonType == "M")
            {
                _sortBy = "FirstName";
                if (string.IsNullOrEmpty(param.sSearch))
                {
                    _searchBy = string.Empty;
                }
                else
                {
                    _searchBy = "FirstName Like '%" + param.sSearch + "%' or MiddleName Like '%" + param.sSearch + "%' or LastName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                }
            }
            if (PersonType == "T")
            {
                _sortBy = "ContractEmployeeName";
                if (string.IsNullOrEmpty(param.sSearch))
                {
                    _searchBy = string.Empty;
                }
                else
                {
                    _searchBy = "FirstName Like '%" + param.sSearch + "%'  or MiddleName Like '%" + param.sSearch + "%'  or LastName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                }
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            if (!string.IsNullOrEmpty(AccBalsheetMstID) && !string.IsNullOrEmpty(AccountID) && !string.IsNullOrEmpty(PersonType) && !string.IsNullOrEmpty(SelectedSessionID))
            {
                filteredAccountIndividualOpeningBalance = GetListAccountIndividualOpeningBalance(Convert.ToInt32(AccBalsheetMstID), Convert.ToInt32(AccountID), PersonType, SelectedSessionID, out TotalRecords);
            }
            else
            {
                filteredAccountIndividualOpeningBalance = new List<AccountCentreOpeningBalance>();
                TotalRecords = 0;
            }

            var records = filteredAccountIndividualOpeningBalance.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.PersonName), String.Format("{0:0.00}", System.Math.Abs(c.OpeningBalance.Value)), Convert.ToString(c.PersonID), Convert.ToString(c.ID), Convert.ToString(c.TotalCreditAmount), Convert.ToString(c.TotalDebitAmount), Convert.ToString(c.OpeningBalance), };

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}
