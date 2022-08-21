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
    public class AccountChequeBookMasterController : BaseController
    {
        //
        // GET: /AccountChequeBookMaster/

        #region ------------CONTROLLER CLASS VARIABLE------------
        IAccountChequeBookMasterBA _accountChequeBookMasterBA = null;
        IAccountChequeBookMasterBaseViewModel _accountChequeBookMasterBaseViewModel = null;
        IAccountBalancesheetMasterBA _accountBalancesheetMasterBA = null;
        IAccountMasterBA _accountMasterBA = null;
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
        public AccountChequeBookMasterController()
        {
            _accountChequeBookMasterBA = new AccountChequeBookMasterBA();
            _accountBalancesheetMasterBA = new AccountBalancesheetMasterBA();
           _accountChequeBookMasterBaseViewModel = new AccountChequeBookMasterBaseViewModel();
            _accountMasterBA = new AccountMasterBA();
        }
        #endregion

        #region ------------CONTROLLER ACTION METHODS------------
        public ActionResult Index( )
        {
            if (Convert.ToInt32(Session["Account Manager"]) > 0)
            {
                return View("/Views/Accounts/AccountChequeBookMaster/Index.cshtml");
            }
            else
            {
                return RedirectToAction("UnauthorizedAccess", "Home");
            }
        }

        public ActionResult List( string BalanceSheetID)
        {
            try
            {
                if (!string.IsNullOrEmpty(BalanceSheetID))
                {
                    AccountChequeBookMasterBaseViewModel model = new AccountChequeBookMasterBaseViewModel();
                    model.ListOrganisationStudyCentreMaster = GetListOrgStudyCentreMaster();
                    return PartialView("/Views/Accounts/AccountChequeBookMaster/List.cshtml",model);  
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
        public ActionResult Create( string Balancesheet, string AccID)
        {
            try
            {
                AccountChequeBookMasterViewModel model = new AccountChequeBookMasterViewModel();
                string [] splitBalancesheet = Balancesheet.Split(':');
                model.SelectedBalanceSheet = splitBalancesheet[0].Replace('~', ' ');
                model.AccBalsheetMstID =Convert.ToInt16(splitBalancesheet[1]);
                string[] splitAccID = AccID.Split(':');
                model.AccountName = splitAccID[0].Replace('~', ' ');
                model.AccountID = Convert.ToInt16(splitAccID[1]);

                model.AccountChequeBookMasterDTO.ConnectionString = _connectioString;
                model.AccountChequeBookMasterDTO.AccountID = model.AccountID; 
                IBaseEntityResponse<AccountChequeBookMaster> response = _accountChequeBookMasterBA.SelectByAccountID(model.AccountChequeBookMasterDTO);
                if (response.Entity.ChequeToNo > 0)
                {
                    model.ChequeFromNo = response.Entity.ChequeToNo + 1;    
                }
                else
                {
                    model.ChequeFromNo = response.Entity.ChequeToNo;    
                }

                return PartialView("/Views/Accounts/AccountChequeBookMaster/Create.cshtml",model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public ActionResult Create(AccountChequeBookMasterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.AccountChequeBookMasterDTO != null)
                    {
                        model.AccountChequeBookMasterDTO.ConnectionString = _connectioString;
                        model.AccountChequeBookMasterDTO.ID = model.ID;
                        model.AccountChequeBookMasterDTO.AccBalsheetMstID = model.AccBalsheetMstID;
                        model.AccountChequeBookMasterDTO.AccountID = model.AccountID;
                        model.AccountChequeBookMasterDTO.TotalNoCheque = model.TotalNoCheque;
                        model.AccountChequeBookMasterDTO.ChequeFromNo = model.ChequeFromNo;
                        model.AccountChequeBookMasterDTO.ChequeToNo = model.ChequeToNo;
                        model.AccountChequeBookMasterDTO.ActiveFlag = model.ActiveFlag;
                        model.AccountChequeBookMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        model.AccountChequeBookMasterDTO.IsActive = true;
                        IBaseEntityResponse<AccountChequeBookMaster> response = _accountChequeBookMasterBA.InsertAccountChequeBookMaster(model.AccountChequeBookMasterDTO);
                        model.AccountChequeBookMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                        var actionMode = model.AccountChequeBookMasterDTO.errorMessage.Split(',');
                        TempData["ActionMode"] = actionMode[2];
                    }
                    return Json(model.AccountChequeBookMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public ActionResult Edit( int ID, string Balancesheet, string AccVal)
        {
            try
            {
                AccountChequeBookMasterViewModel model = new AccountChequeBookMasterViewModel();
                model.ID = ID;
                model.AccountChequeBookMasterDTO.ConnectionString = _connectioString;
                IBaseEntityResponse<AccountChequeBookMaster> response = _accountChequeBookMasterBA.SelectByID(model.AccountChequeBookMasterDTO);
                if (response != null && response.Entity != null)
                {
                    model.AccountChequeBookMasterDTO.ID = response.Entity.ID;
                    model.AccountChequeBookMasterDTO.CentreCode = response.Entity.CentreCode;
                    model.AccountChequeBookMasterDTO.AccBalsheetMstID = response.Entity.AccBalsheetMstID;
                    model.AccountChequeBookMasterDTO.AccountID = response.Entity.AccountID;
                    model.AccountChequeBookMasterDTO.TotalNoCheque = response.Entity.TotalNoCheque;
                    model.AccountChequeBookMasterDTO.ChequeFromNo = response.Entity.ChequeFromNo;
                    model.AccountChequeBookMasterDTO.ChequeToNo = response.Entity.ChequeToNo;
                    model.AccountChequeBookMasterDTO.ActiveFlag = response.Entity.ActiveFlag;
                    model.AccountChequeBookMasterDTO.IsActive = response.Entity.IsActive;
                }
                // These values used for display purpose
                model.SelectedBalanceSheet = Balancesheet.Replace('~', ' ');              
                model.AccountName = AccVal.Replace('~', ' ');
                return PartialView("/Views/Accounts/AccountChequeBookMaster/Edit.cshtml",model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(AccountChequeBookMasterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.AccountChequeBookMasterDTO != null)
                    {
                        model.AccountChequeBookMasterDTO.ConnectionString = _connectioString;
                        model.AccountChequeBookMasterDTO.ID = model.ID;
                        model.AccountChequeBookMasterDTO.AccBalsheetMstID = model.AccBalsheetMstID;
                        model.AccountChequeBookMasterDTO.AccountID = model.AccountID;
                        model.AccountChequeBookMasterDTO.TotalNoCheque = model.TotalNoCheque;
                        model.AccountChequeBookMasterDTO.ChequeFromNo = model.ChequeFromNo;
                        model.AccountChequeBookMasterDTO.ChequeToNo = model.ChequeToNo;
                        model.AccountChequeBookMasterDTO.ActiveFlag = model.ActiveFlag;
                        model.AccountChequeBookMasterDTO.IsActive = model.IsActive;
                        model.AccountChequeBookMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<AccountChequeBookMaster> response = _accountChequeBookMasterBA.UpdateAccountChequeBookMaster(model.AccountChequeBookMasterDTO);
                        model.AccountChequeBookMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                        var actionMode = model.AccountChequeBookMasterDTO.errorMessage.Split(',');
                        TempData["ActionMode"] = actionMode[2];
                    }
                    return Json(model.AccountChequeBookMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        
        public ActionResult Delete(int ID)
        {
            try
            {
                
                    AccountChequeBookMasterViewModel model = new AccountChequeBookMasterViewModel();
                    AccountChequeBookMaster AccountChequeBookMasterDTO = new AccountChequeBookMaster();
                    AccountChequeBookMasterDTO.ConnectionString = _connectioString;
                    AccountChequeBookMasterDTO.ID = ID;
                    AccountChequeBookMasterDTO.AccountID = model.AccountID;
                    AccountChequeBookMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]); ;
                    IBaseEntityResponse<AccountChequeBookMaster> response = _accountChequeBookMasterBA.DeleteAccountChequeBookMaster(AccountChequeBookMasterDTO);
                    model.AccountChequeBookMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
                    //var actionMode = model.AccountChequeBookMasterDTO.errorMessage.Split(',');
                    //TempData["ActionMode"] = actionMode[2];
                    return Json(model.AccountChequeBookMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
                
                
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }
        #endregion

        #region ------------CONTROLLER NON ACTION METHODS------------
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetBalanceSheetByCentreCode(string SelectedCentreCode)
        {
             if (String.IsNullOrEmpty(SelectedCentreCode))
                {
                    throw new ArgumentNullException("SelectedCentreCode");
                }
                var BalanceSheet = GetListAccountBalanceSheetMaster(SelectedCentreCode);
                var result = (from s in BalanceSheet
                              select new
                              {
                                  id = s.ID, //+ ":" + s.AccBalsheetHeadDesc,
                                  name = s.AccBalsheetHeadDesc,
                              }).ToList();
                return Json(result, JsonRequestBehavior.AllowGet);
        }

        [NonAction]
        public List<AccountChequeBookMaster> GetListAccountChequeBookMaster( string SelectedBalanceSheet, out int _totalRecords)
        {
            List<AccountChequeBookMaster> listAccountChequeBookMaster = new List<AccountChequeBookMaster>();
            AccountChequeBookMasterSearchRequest searchRequest = new AccountChequeBookMasterSearchRequest();
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
                    searchRequest.AccBalsheetMstID = Convert.ToInt32(SelectedBalanceSheet);
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "ModifiedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                    searchRequest.AccBalsheetMstID = Convert.ToInt32(SelectedBalanceSheet);
                }
            }
            else
            {
                searchRequest.SortBy = _sortBy;                     // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;
                searchRequest.AccBalsheetMstID = Convert.ToInt32(SelectedBalanceSheet);
            }
            IBaseEntityCollectionResponse<AccountChequeBookMaster> baseEntityCollectionResponse = _accountChequeBookMasterBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listAccountChequeBookMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            _totalRecords = baseEntityCollectionResponse.TotalRecords;
            return listAccountChequeBookMaster;
        }

        [NonAction]
        public List<AccountBalancesheetMaster> GetListAccountBalanceSheetMaster(string CentreCode)
        {
            List<AccountBalancesheetMaster> listAccountBalancesheetMaster = new List<AccountBalancesheetMaster>();
            AccountBalancesheetMasterSearchRequest searchRequest = new AccountBalancesheetMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.CentreCode = CentreCode;
            IBaseEntityCollectionResponse<AccountBalancesheetMaster> baseEntityCollectionResponse = _accountBalancesheetMasterBA.GetBalanceSheetList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listAccountBalancesheetMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listAccountBalancesheetMaster;
        }
        #endregion

        #region ------------CONTROLLER AJAX HANDLER METHODS------------

        /// <summary>
        /// AJAX Method for binding List Account category master
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public ActionResult AjaxHandler(JQueryDataTableParamModel param,  string SelectedBalanceSheet)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<AccountChequeBookMaster> filteredAccountChequeBookMaster;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "AccountName";//b.TotalNoCheque";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "TotalNoCheque Like '%" + param.sSearch + "%' or ChequeFromNo Like '%" + param.sSearch + "%'  or ChequeToNo Like '%" + param.sSearch + "%' or AccountName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "b.ChequeFromNo";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "TotalNoCheque Like '%" + param.sSearch + "%' or ChequeFromNo Like '%" + param.sSearch + "%'  or ChequeToNo Like '%" + param.sSearch + "%' or AccountName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                break;
                case 2:
                    _sortBy = "b.ChequeToNo";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "TotalNoCheque Like '%" + param.sSearch + "%' or ChequeFromNo Like '%" + param.sSearch + "%'  or ChequeToNo Like '%" + param.sSearch + "%'  or AccountName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 3:
                    _sortBy = "AccountName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "TotalNoCheque Like '%" + param.sSearch + "%' or ChequeFromNo Like '%" + param.sSearch + "%'  or ChequeToNo Like '%" + param.sSearch + "%'  or AccountName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            if (!string.IsNullOrEmpty(SelectedBalanceSheet))
            {
                filteredAccountChequeBookMaster = GetListAccountChequeBookMaster(SelectedBalanceSheet, out TotalRecords);
            }
            else
            {
                filteredAccountChequeBookMaster = new List<AccountChequeBookMaster>();
                TotalRecords = 0;
            }
          
            var records = filteredAccountChequeBookMaster.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.TotalNoCheque), Convert.ToString(c.ChequeFromNo), Convert.ToString(c.ChequeToNo), Convert.ToString(c.AccountName), Convert.ToString(c.AccountID), Convert.ToString(c.ID) };

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet); 
        }
        #endregion

    }
}
