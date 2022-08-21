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

namespace AERP.Web.UI.Controllers
{
    public class AccountTransactionMasterController : BaseController
    {
        #region ------------CONTROLLER CLASS VARIABLE------------

        IAccountTransactionMasterBA _accountTransactionMasterBA = null;
        AccountTransactionMasterViewModel _accountTransactionMasterBaseViewModel = null;
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
        public AccountTransactionMasterController()
        {
            _accountTransactionMasterBA = new AccountTransactionMasterBA();
            _accountTransactionMasterBaseViewModel = new AccountTransactionMasterViewModel();
        }
        #endregion

        #region ------------CONTROLLER ACTION METHODS------------
        public ActionResult Index(string selectedTransactionCode, string selectedTransactionTypeText, string selectedBalsheet, string actionMode, string TransactionID)
        {
            if (Convert.ToInt32(Session["Account Manager"]) > 0)
            {
                AccountTransactionMasterViewModel model = new AccountTransactionMasterViewModel();
                if (Convert.ToInt64(TransactionID) > 0)
                {
                    model.IsPosted = 1;
                    model.TransactionMainID = Convert.ToInt64(TransactionID);
                    model.ListAccountTransactionMaster = GetListAccountTransactionMasterForEditView(TransactionID);
                    model.TransactionDate = model.ListAccountTransactionMaster[0].TransactionDate;
                    model.NarrationDescription = model.ListAccountTransactionMaster[0].NarrationDescription;
                }
                else
                {
                    model.IsPosted = 0;
                }
                model.ListAccountTransactionTypeMaster = GetListOfAccountTransactionType();
                model.SelectedTransactionType = selectedTransactionCode + " ";
                model.TransactionTypeWithCode = selectedTransactionCode + ":" + selectedTransactionTypeText;
                model.AccountSessionMasterDTO = GetCurrentAccountSession();
                if (model != null && model.AccountSessionMasterDTO != null)
                {
                    var from = model.AccountSessionMasterDTO.SessionStartDatetime.Split(' ');
                    var to = model.AccountSessionMasterDTO.SessionEndDatetime.Split(' ');
                    model.SessionName = from[2] + " - " + to[2];
                    model.AccSessionID = model.AccountSessionMasterDTO.ID;
                }
                else
                {
                    model.SessionName = "Session not defined !";
                }
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Accounts/AccountTransactionMaster/Index.cshtml", model);
            }
            else
            {
                return RedirectToAction("UnauthorizedAccess", "Home");
            }
        }

        public ActionResult List(string selectedTransactionCode, string selectedTransactionTypeText, string selectedBalsheet, string actionMode)
        {
            try
            {

                AccountTransactionMasterViewModel model = new AccountTransactionMasterViewModel();
                model.ListAccountTransactionTypeMaster = GetListOfAccountTransactionType();
                //if (selectedTransactionTypeText == null)
                //{
                //    Session["TransactionType"] = model.ListAccountTransactionTypeMaster[0].TransactionTypeName;
                //    Session["TransactionCode"] = model.ListAccountTransactionTypeMaster[0].TransactionTypeCode;
                //}
                //else
                //{
                //    Session["TransactionType"] = selectedTransactionTypeText;
                //    Session["TransactionCode"] = selectedTransactionCode;
                //}
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                model.SelectedTransactionType = selectedTransactionCode;
                model.TransactionTypeWithCode = selectedTransactionCode + ":" + selectedTransactionTypeText;
                //model.AccountSessionMasterDTO = GetCurrentAccountSession();
                //if (model != null && model.AccountSessionMasterDTO != null)
                //{
                //    var from = model.AccountSessionMasterDTO.SessionStartDatetime.Split(' ');
                //    var to = model.AccountSessionMasterDTO.SessionEndDatetime.Split(' ');
                //    model.SessionName = from[2] + " - " + to[2];
                //    model.AccSessionID = model.AccountSessionMasterDTO.ID;
                //}
                //else
                //{
                //    model.SessionName = "Session not defined !";
                //}
                return PartialView("/Views/Accounts/AccountTransactionMaster/List.cshtml", model);
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
            AccountTransactionMasterViewModel model = new AccountTransactionMasterViewModel();
            //model.ListAccountTransactionMaster = new List<AccountTransactionMaster>();
            //model.TransactionTypeName = TransactionTypeWithCode.Split(':')[1];
            //model.TransactionTypeCode = TransactionTypeWithCode.Split(':')[0];
            //model.AccSessionID = sID;
            return PartialView("/Views/Accounts/AccountTransactionMaster/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(AccountTransactionMasterViewModel model)
        {
            try
            {
                if (model != null && model.AccountTransactionMasterDTO != null)
                {
                    model.AccountTransactionMasterDTO.ConnectionString = _connectioString;
                    model.AccountTransactionMasterDTO.ID = model.ID;
                    model.AccountTransactionMasterDTO.AccBalsheetMstID = model.AccBalsheetMstID;
                    model.AccountTransactionMasterDTO.TransactionDate = model.TransactionDate;
                    model.AccountTransactionMasterDTO.TransactionTypeCode = model.TransactionTypeCode;
                    model.AccountTransactionMasterDTO.NarrationDescription = model.NarrationDescription;
                    model.AccountTransactionMasterDTO.SelectedXmlData = model.SelectedXmlData;
                    model.AccountTransactionMasterDTO.VoucherAmount = model.VoucherAmount;
                    model.AccountTransactionMasterDTO.ModeCode = "Mode";// model.ModeCode;
                    model.AccountTransactionMasterDTO.AccSessionID = model.AccSessionID;
                    model.AccountTransactionMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);

                    IBaseEntityResponse<AccountTransactionMaster> response = _accountTransactionMasterBA.InsertAccountTransactionMaster(model.AccountTransactionMasterDTO);
                    if (response.Entity != null && !string.IsNullOrEmpty(response.Entity.ErrorMessage))
                    {
                        string[] arrayList = { response.Entity.ErrorMessage, "#F5CCCC", string.Empty };
                        model.AccountTransactionMasterDTO.errorMessage = string.Join(",", arrayList);
                    }
                    else
                    {
                        model.AccountTransactionMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    }
                    return Json(model.AccountTransactionMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public ActionResult Edit(string TransactionID, Int16 AccSessionID, string TransactionTypeWithCode)
        {
            try
            {
                AccountTransactionMasterViewModel model = new AccountTransactionMasterViewModel();
                model.ListAccountTransactionMaster = new List<AccountTransactionMaster>();
                model.TransactionTypeName = TransactionTypeWithCode.Split(':')[1];
                model.TransactionTypeCode = TransactionTypeWithCode.Split(':')[0];
                model.ListAccountTransactionMaster = GetListAccountTransactionMasterForEditView(TransactionID);
                model.TransactionDate = model.ListAccountTransactionMaster[0].TransactionDate;
                model.NarrationDescription = model.ListAccountTransactionMaster[0].NarrationDescription;
                model.AccSessionID = AccSessionID;
                model.ID = Convert.ToInt64(TransactionID);
                return PartialView("/Views/Accounts/AccountTransactionMaster/Edit.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }

        [HttpPost]
        public ActionResult Edit(AccountTransactionMasterViewModel model)
        {
            try
            {
                if (model != null && model.AccountTransactionMasterDTO != null)
                {
                    model.AccountTransactionMasterDTO.ConnectionString = _connectioString;
                    model.AccountTransactionMasterDTO.ID = model.ID;
                    model.AccountTransactionMasterDTO.AccBalsheetMstID = model.AccBalsheetMstID;
                    model.AccountTransactionMasterDTO.AccSessionID = model.AccSessionID;
                    model.AccountTransactionMasterDTO.TransactionDate = model.TransactionDate;
                    model.AccountTransactionMasterDTO.TransactionTypeCode = model.TransactionTypeCode;
                    model.AccountTransactionMasterDTO.NarrationDescription = model.NarrationDescription;
                    model.AccountTransactionMasterDTO.SelectedXmlData = model.SelectedXmlData;
                    model.AccountTransactionMasterDTO.ModeCode = "Mode";// model.ModeCode;
                    model.AccountTransactionMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<AccountTransactionMaster> response = _accountTransactionMasterBA.InsertAccountTransactionMaster(model.AccountTransactionMasterDTO);
                    if (response.Entity != null && !string.IsNullOrEmpty(response.Entity.ErrorMessage))
                    {
                        string[] arrayList = { response.Entity.ErrorMessage, "#F5CCCC", string.Empty };
                        model.AccountTransactionMasterDTO.errorMessage = string.Join(",", arrayList);
                    }
                    else
                    {
                        model.AccountTransactionMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                    }

                    return Json(model.AccountTransactionMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(Boolean.FalseString);
                }
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpGet]
        public ActionResult AccountVoucherRequestApproval(int PersonID, string TNDID, string TNMID, string GTRDID1, string TaskCode, string StageSequenceNumber, string IsLast)
        {
            AccountTransactionMasterViewModel model = new AccountTransactionMasterViewModel();
            model.PersonID = Convert.ToInt32(PersonID);
            model.TaskNotificationDetailsID = Convert.ToInt32(TNDID);
            model.TaskNotificationMasterID = Convert.ToInt32(TNMID);
            model.GeneralTaskReportingDetailsID = Convert.ToInt32(GTRDID1);
            model.TaskCode = TaskCode;
            model.StageSequenceNumber = Convert.ToInt32(StageSequenceNumber);
            model.IsLastRecord = Convert.ToBoolean(IsLast);


            model.AccountVoucherDetailsList = GetAccountVoucherListForApproval(PersonID, Convert.ToInt32(TNMID));
            if (model.AccountVoucherDetailsList.Count > 0)
            {
                model.AccBalsheetName = model.AccountVoucherDetailsList[0].AccBalsheetName;
                model.TransactionType = model.AccountVoucherDetailsList[0].TransactionType;
                model.VoucherNumber = model.AccountVoucherDetailsList[0].VoucherNumber;
                model.TransactionDate = model.AccountVoucherDetailsList[0].TransactionDate;
                model.TransactionMainID = model.AccountVoucherDetailsList[0].TransactionMainID;
                model.AccBalsheetMstID = model.AccountVoucherDetailsList[0].AccBalsheetMstID;
                model.AccSessionID = model.AccountVoucherDetailsList[0].AccSessionID;
                model.TransactionType = model.AccountVoucherDetailsList[0].TransactionType;
                model.NarrationDescription = model.AccountVoucherDetailsList[0].NarrationDescription;
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult AccountVoucherRequestApproval(AccountTransactionMasterViewModel model)
        {
            model.AccountTransactionMasterDTO.ConnectionString = _connectioString;
            model.AccountTransactionMasterDTO.XMLstring = model.XMLstring;
            model.AccountTransactionMasterDTO.AccSessionID = model.AccSessionID;
            model.AccountTransactionMasterDTO.AccBalsheetMstID = model.AccBalsheetMstID;
            model.AccountTransactionMasterDTO.TransactionMainID = model.TransactionMainID;
            model.AccountTransactionMasterDTO.TransactionType = model.TransactionType;
            model.AccountTransactionMasterDTO.NarrationDescription = model.NarrationDescription;
            model.AccountTransactionMasterDTO.TransactionDate = model.TransactionDate;
            model.AccountTransactionMasterDTO.VoucherAmount = model.VoucherAmount;
            model.AccountTransactionMasterDTO.RequestApprovedStatus = model.RequestApprovedStatus;
            model.AccountTransactionMasterDTO.PersonID = model.PersonID;
            model.AccountTransactionMasterDTO.StageSequenceNumber = model.StageSequenceNumber;
            model.AccountTransactionMasterDTO.TaskNotificationMasterID = model.TaskNotificationMasterID;
            model.AccountTransactionMasterDTO.TaskNotificationDetailsID = model.TaskNotificationDetailsID;
            model.AccountTransactionMasterDTO.GeneralTaskReportingDetailsID = model.GeneralTaskReportingDetailsID;
            model.AccountTransactionMasterDTO.IsLastRecord = model.IsLastRecord;
            model.AccountTransactionMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
            IBaseEntityResponse<AccountTransactionMaster> response = _accountTransactionMasterBA.InsertAccountVoucherRequest(model.AccountTransactionMasterDTO);
            model.AccountTransactionMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
            return Json(model.AccountTransactionMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult AccountVoucherRequestApprovalV2(int PersonID, string TNDID, string TNMID, string GTRDID1, string TaskCode, string StageSequenceNumber, string IsLast)
        {
            AccountTransactionMasterViewModel model = new AccountTransactionMasterViewModel();
            model.PersonID = Convert.ToInt32(PersonID);
            model.TaskNotificationDetailsID = Convert.ToInt32(TNDID);
            model.TaskNotificationMasterID = Convert.ToInt32(TNMID);
            model.GeneralTaskReportingDetailsID = Convert.ToInt32(GTRDID1);
            model.TaskCode = TaskCode;
            model.StageSequenceNumber = Convert.ToInt32(StageSequenceNumber);
            model.IsLastRecord = Convert.ToBoolean(IsLast);

            model.AccountVoucherDetailsList = GetAccountVoucherListForApproval(PersonID, Convert.ToInt32(TNMID));
            if (model.AccountVoucherDetailsList.Count > 0)
            {
                model.AccBalsheetName = model.AccountVoucherDetailsList[0].AccBalsheetName;
                model.TransactionType = model.AccountVoucherDetailsList[0].TransactionType;
                model.VoucherNumber = model.AccountVoucherDetailsList[0].VoucherNumber;
                model.TransactionDate = model.AccountVoucherDetailsList[0].TransactionDate;
                model.TransactionMainID = model.AccountVoucherDetailsList[0].TransactionMainID;
                model.AccBalsheetMstID = model.AccountVoucherDetailsList[0].AccBalsheetMstID;
                model.AccSessionID = model.AccountVoucherDetailsList[0].AccSessionID;
                model.TransactionType = model.AccountVoucherDetailsList[0].TransactionType;
                model.NarrationDescription = model.AccountVoucherDetailsList[0].NarrationDescription;
            }
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult AccountVoucherRequestApprovalV2(AccountTransactionMasterViewModel model)
        {
            model.AccountTransactionMasterDTO.ConnectionString = _connectioString;
            model.AccountTransactionMasterDTO.XMLstring = model.XMLstring;
            model.AccountTransactionMasterDTO.AccSessionID = model.AccSessionID;
            model.AccountTransactionMasterDTO.AccBalsheetMstID = model.AccBalsheetMstID;
            model.AccountTransactionMasterDTO.TransactionMainID = model.TransactionMainID;
            model.AccountTransactionMasterDTO.TransactionType = model.TransactionType;
            model.AccountTransactionMasterDTO.NarrationDescription = model.NarrationDescription;
            model.AccountTransactionMasterDTO.TransactionDate = model.TransactionDate;
            model.AccountTransactionMasterDTO.VoucherAmount = model.VoucherAmount;
            model.AccountTransactionMasterDTO.RequestApprovedStatus = model.RequestApprovedStatus;
            model.AccountTransactionMasterDTO.PersonID = model.PersonID;
            model.AccountTransactionMasterDTO.StageSequenceNumber = model.StageSequenceNumber;
            model.AccountTransactionMasterDTO.TaskNotificationMasterID = model.TaskNotificationMasterID;
            model.AccountTransactionMasterDTO.TaskNotificationDetailsID = model.TaskNotificationDetailsID;
            model.AccountTransactionMasterDTO.GeneralTaskReportingDetailsID = model.GeneralTaskReportingDetailsID;
            model.AccountTransactionMasterDTO.IsLastRecord = model.IsLastRecord;
            model.AccountTransactionMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);

            IBaseEntityResponse<AccountTransactionMaster> response = _accountTransactionMasterBA.InsertAccountVoucherRequest(model.AccountTransactionMasterDTO);
            model.AccountTransactionMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
            return Json(model.AccountTransactionMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region ------------CONTROLLER NON ACTION METHODS------------
        [HttpPost]
        public JsonResult GetAccounts(string term, int accountId, string personType, string transactionTypeCode)
        {
            var data = GetAccountList(term, accountId, personType, transactionTypeCode);
            var result = (from r in data
                          select new
                          {
                              id = r.AccountID,
                              name = r.AccountName,
                              personType = r.PersonType,
                              subLedgerName = r.SubLedgerName,
                              personId = r.PersonID,
                              cashBankFlag = r.CashBankFlag
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);

            //var data = new [] {"ActionScript","AppleScript","Asp",
            //  "BASIC",
            //  "C","C++","Clojure","COBOL","ColdFusion",
            //  "Erlang",
            //  "Fortran",
            //  "Groovy",
            //  "Haskell",
            //  "instinctcoder.com",
            //  "Java","JavaScript",
            //  "Lisp",
            //  "Perl","PHP","Python",
            //  "Ruby",
            //  "Scala","Scheme"};

            //var result = data.Where(x => x.ToLower().StartsWith(term.ToLower())).ToList();

            //return Json(result, JsonRequestBehavior.AllowGet);

        }
        [NonAction]
        protected List<AccountTransactionMaster> GetAccountList(string SearchKeyWord, int accountId, string personType, string transactionTypeCode)
        {
            AccountTransactionMasterSearchRequest searchRequest = new AccountTransactionMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.SearchWord = SearchKeyWord;
            searchRequest.AccountId = accountId;
            searchRequest.PersonType = personType;
            searchRequest.TransactionTypeCode = transactionTypeCode;
            List<AccountTransactionMaster> listAccountTransactionMaster = new List<AccountTransactionMaster>();
            IBaseEntityCollectionResponse<AccountTransactionMaster> baseEntityCollectionResponse = _accountTransactionMasterBA.GetAccountList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listAccountTransactionMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listAccountTransactionMaster;
        }
        [NonAction]
        public List<AccountTransactionMaster> GetListAccountTransactionMaster(string SelectedTransactionType, string SelectedBalancesheetID, string SelectedAccSessionID, out int TotalRecords)
        {
            List<AccountTransactionMaster> listAccountTransactionMaster = new List<AccountTransactionMaster>();
            AccountTransactionMasterSearchRequest searchRequest = new AccountTransactionMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            searchRequest.TransactionType = SelectedTransactionType;
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
                    searchRequest.TransactionType = SelectedTransactionType;
                    searchRequest.AccBalsheetMstID = Convert.ToInt16(SelectedBalancesheetID);
                    searchRequest.AccSessionID = Convert.ToInt16(SelectedAccSessionID);
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "ModifiedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                    searchRequest.TransactionType = SelectedTransactionType;
                    searchRequest.AccBalsheetMstID = Convert.ToInt16(SelectedBalancesheetID);
                    searchRequest.AccSessionID = Convert.ToInt16(SelectedAccSessionID);
                }
            }
            else
            {
                searchRequest.SortBy = _sortBy;                     // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;
                searchRequest.TransactionType = SelectedTransactionType;
                searchRequest.AccBalsheetMstID = Convert.ToInt16(SelectedBalancesheetID);
                searchRequest.AccSessionID = Convert.ToInt16(SelectedAccSessionID);
            }
            IBaseEntityCollectionResponse<AccountTransactionMaster> baseEntityCollectionResponse = _accountTransactionMasterBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listAccountTransactionMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listAccountTransactionMaster;
        }
        [NonAction]
        public List<AccountTransactionMaster> GetListAccountTransactionMasterForEditView(string TransactionMainID)
        {
            List<AccountTransactionMaster> listAccountTransactionMaster = new List<AccountTransactionMaster>();
            AccountTransactionMasterSearchRequest searchRequest = new AccountTransactionMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.ID = Convert.ToInt32(TransactionMainID);
            IBaseEntityCollectionResponse<AccountTransactionMaster> baseEntityCollectionResponse = _accountTransactionMasterBA.GetBySearchForEditView(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listAccountTransactionMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listAccountTransactionMaster;
        }

        [NonAction]
        protected List<AccountTransactionMaster> GetAccountVoucherListForApproval(int personId, int taskNotificationMasterID)
        {
            AccountTransactionMasterSearchRequest searchRequest = new AccountTransactionMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.PersonID = personId;
            searchRequest.TaskNotificationMasterID = taskNotificationMasterID;
            List<AccountTransactionMaster> listFeeApproval = new List<AccountTransactionMaster>();
            IBaseEntityCollectionResponse<AccountTransactionMaster> baseEntityCollectionResponse = _accountTransactionMasterBA.GetVoucherDetailsForApproval(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listFeeApproval = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listFeeApproval;
        }
        #endregion

        #region ------------CONTROLLER AJAX HANDLER METHODS------------
        /// <summary>
        /// AJAX Method for binding List Account Transaction master
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public ActionResult AjaxHandler(JQueryDataTableParamModel param, string SelectedTransactionType, string SelectedBalancesheetID, string SelectedAccSessionID)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<AccountTransactionMaster> filteredAccountTransactionMaster;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "A.NarrationDescription";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "A.TransactionDate Like '%" + param.sSearch + "%' or A.VoucherNumber Like '%" + param.sSearch + "%' or A.NarrationDescription Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "A.VoucherNumber";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "A.TransactionDate Like '%" + param.sSearch + "%' or A.VoucherNumber Like '%" + param.sSearch + "%' or A.NarrationDescription Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 2:
                    _sortBy = "A.TransactionDate";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "A.TransactionDate Like '%" + param.sSearch + "%' or A.VoucherNumber Like '%" + param.sSearch + "%' or A.NarrationDescription Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            if (!string.IsNullOrEmpty(SelectedTransactionType) && !string.IsNullOrEmpty(SelectedBalancesheetID) && !string.IsNullOrEmpty(SelectedAccSessionID))
            {
                filteredAccountTransactionMaster = GetListAccountTransactionMaster(SelectedTransactionType, SelectedBalancesheetID, SelectedAccSessionID, out TotalRecords);
            }
            else
            {
                filteredAccountTransactionMaster = new List<AccountTransactionMaster>();
                TotalRecords = 0;
            }

            var records = filteredAccountTransactionMaster.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.NarrationDescription), Convert.ToString(c.VoucherNumber), c.TransactionDate.ToString()/*c.TransactionDate.ToString("d/MM/yyyy")*/, Convert.ToString(c.IsPosted), Convert.ToString(c.ID), Convert.ToString(Math.Round(c.TransactionAmount, 2)) };

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// AJAX Method for binding List Account Transaction master
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public ActionResult AjaxHandlerForEditView(JQueryDataTableParamModel param, string TransactionMainID)
        {
            IEnumerable<AccountTransactionMaster> filteredAccountTransactionMaster;
            filteredAccountTransactionMaster = GetListAccountTransactionMasterForEditView(TransactionMainID);
            var records = filteredAccountTransactionMaster.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.AccountName), Convert.ToString(c.AccTransDetailsID), Convert.ToString(c.AccountID), Convert.ToString(c.BranchName), Convert.ToString(c.NarrationDescription), Convert.ToString(c.ChequeNo), Convert.ToString(c.DebitCreditFlag), Convert.ToString(c.TransactionAmount), Convert.ToString(c.ChequeDatetime), Convert.ToString(c.PersonID), Convert.ToString(c.PersonType), Convert.ToString(c.CashBankFlag), c.TransactionDate.ToString(), Convert.ToString(c.TransactionMasterNarration), Convert.ToString(c.ID), };

            return Json(new { sEcho = param.sEcho,/* iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords,*/ aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion

    }
}
