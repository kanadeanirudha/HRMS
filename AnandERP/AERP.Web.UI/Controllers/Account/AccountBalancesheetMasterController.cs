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
    public class AccountBalancesheetMasterController : BaseController
    {
        IAccountBalancesheetMasterBA _accountBalancesheetMasterBA = null;
        IAccountBalancesheetTypeMasterBA _accountBalancesheetTypeMasterBA = null;

        string _centreCode = string.Empty;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public AccountBalancesheetMasterController()
        {
            _accountBalancesheetTypeMasterBA = new AccountBalancesheetTypeMasterBA();
            _accountBalancesheetMasterBA = new AccountBalancesheetMasterBA();

        }

        /// <summary>
        /// First Load When controller call List Method
        /// </summary>
        /// <returns>view</returns>
        [HttpGet]
        public ActionResult Index()
        {
            if (Convert.ToInt32(Session["Account Manager"]) > 0)
            {
                return View("/Views/Accounts/AccountBalancesheetMaster/Index.cshtml");
            }
            else
            {
                return RedirectToAction("UnauthorizedAccess", "Home");
            }
        }
        
        public ActionResult List(string centerCode, string actionMode)
        {
            try
            {

                AccountBalancesheetMasterViewModel model = new AccountBalancesheetMasterViewModel();

                int AdminRoleMasterID = 0;
                if (Session["RoleID"] == null)
                {
                    AdminRoleMasterID = !string.IsNullOrEmpty(Convert.ToString(Session["DefaultRoleID"])) ? Convert.ToInt32(Session["DefaultRoleID"]) : 0;
                }

                else
                {
                    AdminRoleMasterID = !string.IsNullOrEmpty(Convert.ToString(Session["RoleID"])) ? Convert.ToInt32(Session["RoleID"]) : 0;
                }

                List<AdminRoleApplicableDetails> listAdminRoleApplicableDetails = GetAdminRoleApplicableCentreByFinanceManager(AdminRoleMasterID);
                AdminRoleApplicableDetails a = null;
                foreach (var item in listAdminRoleApplicableDetails)
                {
                    a = new AdminRoleApplicableDetails();
                    a.CentreCode = item.CentreCode;
                    a.CentreName = item.CentreName;
                    model.ListGetAdminRoleApplicableCentre.Add(a);
                }
                model.SelectedCentreCode = centerCode;
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Accounts/AccountBalancesheetMaster/List.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Create new balance sheet according to centre code
        /// </summary>
        /// <param name="Centre Code"></param>
        /// <returns>Account Balance Sheet View Model</returns>
        [HttpGet]
        public ActionResult Create(string CentreCode, string BalsheetTypeDetails)
        {
            try
            {
                AccountBalancesheetMasterViewModel model = new AccountBalancesheetMasterViewModel();
                string[] splitBalsheetTypeDetails = BalsheetTypeDetails.Split(':');

                model.CentreCode = CentreCode;
                model.AccBalsheetTypeID = Convert.ToByte(splitBalsheetTypeDetails[0]);
                model.AccBalsheetTypeDesc = splitBalsheetTypeDetails[1].Replace('~', ' '); ;
                model.CentreName = splitBalsheetTypeDetails[2].Replace('~', ' ');

                return PartialView("/Views/Accounts/AccountBalancesheetMaster/Create.cshtml",model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public ActionResult Create(AccountBalancesheetMasterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.AccBalsheetMasterDTO != null)
                    {
                        model.AccBalsheetMasterDTO.ConnectionString = _connectioString;
                        model.AccBalsheetMasterDTO.AccBalsheetCode = model.AccBalsheetCode;
                        model.AccBalsheetMasterDTO.AccBalsheetHeadDesc = model.AccBalsheetHeadDesc;
                        model.AccBalsheetMasterDTO.AccBalsheetTypeID = model.AccBalsheetTypeID;
                        model.AccBalsheetMasterDTO.CentreCode = model.CentreCode;
                        model.AccBalsheetMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<AccountBalancesheetMaster> response = _accountBalancesheetMasterBA.InsertAccBalsheetMaster(model.AccBalsheetMasterDTO);
                        model.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    }
                    model.CentreCodeWithName = model.CentreCode;
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

        [HttpGet]
        public ActionResult Edit(Int16 id, string CentreCode)
        {
            try
            {
                AccountBalancesheetMasterViewModel model = new AccountBalancesheetMasterViewModel();
                model.AccBalsheetMasterDTO = new AccountBalancesheetMaster();
                model.AccBalsheetMasterDTO.ID = id;
                model.AccBalsheetMasterDTO.ConnectionString = _connectioString;
                IBaseEntityResponse<AccountBalancesheetMaster> response = _accountBalancesheetMasterBA.SelectByID(model.AccBalsheetMasterDTO);
                if (response != null && response.Entity != null)
                {
                    model.AccBalsheetMasterDTO.ID = response.Entity.ID;
                    model.AccBalsheetMasterDTO.AccBalsheetCode = response.Entity.AccBalsheetCode;
                    model.AccBalsheetMasterDTO.AccBalsheetHeadDesc = response.Entity.AccBalsheetHeadDesc;
                    model.AccBalsheetMasterDTO.AccBalsheetTypeDesc = response.Entity.AccBalsheetTypeDesc;
                    model.AccBalsheetMasterDTO.AccBalsheetTypeID = response.Entity.AccBalsheetTypeID;
                    model.AccBalsheetMasterDTO.CreatedBy = response.Entity.CreatedBy;
                    model.AccBalsheetMasterDTO.CreatedDate = response.Entity.CreatedDate;
                    model.AccBalsheetMasterDTO.IsActive = response.Entity.IsActive;
                    model.AccBalsheetMasterDTO.CentreCode = CentreCode;
                    model.AccBalsheetMasterDTO.CentreName = response.Entity.CentreName;
                }

                return PartialView("/Views/Accounts/AccountBalancesheetMaster/Edit.cshtml",model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(AccountBalancesheetMasterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.AccBalsheetMasterDTO != null)
                    {
                        model.AccBalsheetMasterDTO.ConnectionString = _connectioString;
                        model.AccBalsheetMasterDTO.AccBalsheetCode = model.AccBalsheetCode;
                        model.AccBalsheetMasterDTO.AccBalsheetHeadDesc = model.AccBalsheetHeadDesc;
                        model.AccBalsheetMasterDTO.AccBalsheetTypeID = model.AccBalsheetTypeID;
                        model.AccBalsheetMasterDTO.CentreCode = model.CentreCode;
                        model.AccBalsheetMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<AccountBalancesheetMaster> response = _accountBalancesheetMasterBA.UpdateAccBalsheetMaster(model.AccBalsheetMasterDTO);
                        model.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                    }
                    model.CentreCodeWithName = model.CentreCode;
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

        [HttpGet]
        public ActionResult Delete(Int16 ID)
        {
            AccountBalancesheetMasterViewModel model = new AccountBalancesheetMasterViewModel();
            model.AccBalsheetMasterDTO = new AccountBalancesheetMaster();
            model.AccBalsheetMasterDTO.ID = ID;
            return PartialView("/Views/Accounts/AccountBalancesheetMaster/Delete.cshtml",model);
        }

        [HttpPost]
        public ActionResult Delete(AccountBalancesheetMasterViewModel model)
        {
            try
            {
                if (model.ID > 0)
                {
                    AccountBalancesheetMaster accountBalancesheetMasterDTO = new AccountBalancesheetMaster();
                    accountBalancesheetMasterDTO.ConnectionString = _connectioString;
                    accountBalancesheetMasterDTO.ID = model.ID;
                    IBaseEntityResponse<AccountBalancesheetMaster> response = _accountBalancesheetMasterBA.DeleteAccBalsheetMaster(accountBalancesheetMasterDTO);
                    model.AccBalsheetMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
                    return Json(model.AccBalsheetMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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

        #region Methods
        [NonAction]
        public List<AccountBalancesheetMaster> GetListAccountBalancesheetMaster(string centerCode, out int TotalRecords)
        {
            List<AccountBalancesheetMaster> listAccountBalancesheetMaster = new List<AccountBalancesheetMaster>();
            AccountBalancesheetMasterSearchRequest searchRequest = new AccountBalancesheetMasterSearchRequest();
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
                    searchRequest.CentreCode = centerCode;
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "ModifiedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                    searchRequest.CentreCode = centerCode;
                }
            }
            else
            {
                searchRequest.SortBy = _sortBy;                     // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;
                searchRequest.CentreCode = centerCode;
            }
            IBaseEntityCollectionResponse<AccountBalancesheetMaster> baseEntityCollectionResponse = _accountBalancesheetMasterBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listAccountBalancesheetMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listAccountBalancesheetMaster;
        }

        [NonAction]
        public List<AccountBalancesheetTypeMaster> GetListAccountBalancesheetTypeMaster()
        {
            AccountBalancesheetTypeMasterSearchRequest searchRequest = new AccountBalancesheetTypeMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.IsDeleted = false;
            searchRequest.SearchType = "SearchAll";
            List<AccountBalancesheetTypeMaster> listAccountBalancesheetTypeMaster = new List<AccountBalancesheetTypeMaster>();
            IBaseEntityCollectionResponse<AccountBalancesheetTypeMaster> baseEntityCollectionResponse = _accountBalancesheetTypeMasterBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listAccountBalancesheetTypeMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listAccountBalancesheetTypeMaster;
        }

        [NonAction]
        public AccountBalancesheetMasterViewModel GetAccountBalancesheetMaster()
        {
            AccountBalancesheetMasterViewModel accountBalancesheetMasterViewModel = new AccountBalancesheetMasterViewModel();
            List<AccountBalancesheetTypeMaster> listAccountBalancesheetTypeMaster = new List<AccountBalancesheetTypeMaster>();
            AccountBalancesheetTypeMasterSearchRequest searchRequest = new AccountBalancesheetTypeMasterSearchRequest();

            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]); // Set parameter
            IBaseEntityCollectionResponse<AccountBalancesheetTypeMaster> baseEntityCollectionResponse = _accountBalancesheetTypeMasterBA.GetBySearch(searchRequest); //Get Result From Database
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listAccountBalancesheetTypeMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    accountBalancesheetMasterViewModel.AccountBalancesheetTypeMasterDTO = listAccountBalancesheetTypeMaster;
                }
            }
            return accountBalancesheetMasterViewModel;
        }
        #endregion

        #region Ajax Handler
        /// <summary>
        /// AJAX Method for binding List Account Balance Sheet master
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public ActionResult AjaxHandler(JQueryDataTableParamModel param, string SelectedCentreCode)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<AccountBalancesheetMaster> filteredAccountBalanceSheetMaster;
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
                        _searchBy = "ActBalsheetTypeDesc Like '%" + param.sSearch + "%' or ActBalsheetHeadDesc Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;

            if (!string.IsNullOrEmpty(SelectedCentreCode))
            {
                filteredAccountBalanceSheetMaster = GetListAccountBalancesheetMaster(SelectedCentreCode, out TotalRecords);
            }
            else
            {
                filteredAccountBalanceSheetMaster = new List<AccountBalancesheetMaster>();
                TotalRecords = 0;
            }
            var records = filteredAccountBalanceSheetMaster.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.AccBalsheetTypeDesc), Convert.ToString(c.ID), Convert.ToString(c.StatusFlag), Convert.ToString(c.AccBalsheetHeadDesc), Convert.ToString(c.AccBalsheetTypeID) };

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}
