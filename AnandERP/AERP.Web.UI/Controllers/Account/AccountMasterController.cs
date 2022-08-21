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
    public class AccountMasterController : BaseController
    {
        #region ------------CONTROLLER CLASS VARIABLE------------

        IAccountMasterBA _accountMasterBA = null;
        IAccountBalancesheetMasterBA _accountBalancesheetMasterBA = null;
        IUserMasterBA _userMasterBA = null;
        AccountMasterBaseViewModel _accountMasterBaseViewModel = null;
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
        public AccountMasterController()
        {
            _accountMasterBA = new AccountMasterBA();
            _accountBalancesheetMasterBA = new AccountBalancesheetMasterBA();
            _userMasterBA = new UserMasterBA();
            _accountMasterBaseViewModel = new AccountMasterBaseViewModel();
        }
        #endregion

        #region ------------CONTROLLER ACTION METHODS------------
        public ActionResult Index()
        {
            if (Convert.ToInt32(Session["Account Manager"]) > 0)
            {
                return View("/Views/Accounts/AccountMaster/Index.cshtml");
            }
            else
            {
                return RedirectToAction("UnauthorizedAccess", "Home");
            }
        }

        public ActionResult List(string selectedBalsheet, string actionMode)
        {
            try
            {
                if (!string.IsNullOrEmpty(selectedBalsheet))
                {
                    AccountMasterBaseViewModel model = new AccountMasterBaseViewModel();
                    if (!string.IsNullOrEmpty(actionMode))
                    {
                        TempData["ActionMode"] = actionMode;
                    }
                    return PartialView("/Views/Accounts/AccountMaster/List.cshtml",model);
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
        public ActionResult Create(string GroupVal)
        {
            try
            {
                int accountId = 0;
                AccountMasterViewModel model = new AccountMasterViewModel();
                 model.UserTypeList  = GetUserTypeMaster();
                var splitGroupVal = GroupVal.Split(':');
                model.GroupID = Convert.ToInt16(splitGroupVal[0]);
                model.GroupDescription = splitGroupVal[1].Replace('~', ' ');
                model.AccBalsheetMstID = Convert.ToInt16(splitGroupVal[2]);

                List<SelectListItem> CashBankFlaglist = new List<SelectListItem>();
                //CashBankFlaglist.Add(new SelectListItem { Text = "---------------Select---------------", Value = "" });

                CashBankFlaglist.Add(new SelectListItem { Text = Resources.DisplayName_Cash, Value = "C" });
                CashBankFlaglist.Add(new SelectListItem { Text = Resources.DisplayName_Ledger, Value = "L" });
                CashBankFlaglist.Add(new SelectListItem { Text = Resources.DisplayName_Bank, Value = "B" });
                ViewData["AccountType"] = CashBankFlaglist;

               
               
                List<SelectListItem> ControlHeadlist = new List<SelectListItem>();
                ControlHeadlist.Add(new SelectListItem { Text = Resources.DisplayName_Select, Value = "" });
                ControlHeadlist.Add(new SelectListItem { Text = Resources.DisplayName_E_Employee, Value = "E" });
                //ControlHeadlist.Add(new SelectListItem { Text = Resources.DisplayName_S_Student, Value = "S" });
                ControlHeadlist.Add(new SelectListItem { Text = Resources.DisplayName_U_Suppliers, Value = "U" });
                ControlHeadlist.Add(new SelectListItem { Text = Resources.DisplayName_C_Customers, Value = "C" });
                ControlHeadlist.Add(new SelectListItem { Text = Resources.DisplayName_T_ContractEmployee, Value = "T" });
                ControlHeadlist.Add(new SelectListItem { Text = "B-Branch", Value = "B" });
                //ControlHeadlist.Add(new SelectListItem { Text = "Fishermen", Value = "F" });
                //ControlHeadlist.Add(new SelectListItem { Text = "Director", Value = "D" });
                ViewData["ControlHeadlist"] = ControlHeadlist;


                model.ListAccountMaster = GetSurplusDeficitList();
                if (model.ListAccountMaster[0].SurpDifiFlag != "")
                {
                    List<SelectListItem> SurplusDeficitList = new List<SelectListItem>();
                    foreach (AccountMaster item in model.ListAccountMaster)
                    {
                        SurplusDeficitList.Add(new SelectListItem { Text = item.SurpDifiFlag, Value = item.SurpDifiFlag.ToString() });
                    }
                    ViewBag.SurplusDeficitList = new SelectList(SurplusDeficitList, "Value", "Text");
                }
                else
                {
                    ViewBag.SurplusDeficitList = new SelectList("");
                }

                model.ListAlternateGroupList = GetAlternateGroupList(model.GroupID);
               
                List<SelectListItem> AlternateGroupList = new List<SelectListItem>();
                foreach (AccountMaster item in model.ListAlternateGroupList)
                {
                    AlternateGroupList.Add(new SelectListItem { Text = item.GroupDescription, Value = item.GroupID.ToString() });
                }
                ViewBag.AlternateGroupList = new SelectList(AlternateGroupList, "Value", "Text");
               
               
                
                List<SelectListItem> InterestModeList = new List<SelectListItem>();
                //InterestModeList.Add(new SelectListItem { Text = "---------------Select---------------", Value = "" });
                InterestModeList.Add(new SelectListItem { Text = Resources.DisplayName_Monthly, Value = "M" });
                InterestModeList.Add(new SelectListItem { Text = Resources.DisplayName_Quaterly, Value = "Q" });
                InterestModeList.Add(new SelectListItem { Text = Resources.DisplayName_HalfYearly, Value = "H" });
                InterestModeList.Add(new SelectListItem { Text = Resources.DisplayName_Yearly, Value = "Y" });
                ViewData["InterestModeList"] = InterestModeList;

                List<SelectListItem> InterestTypeList = new List<SelectListItem>();
                //InterestTypeList.Add(new SelectListItem { Text = "---------------Select---------------", Value = "" });
                InterestTypeList.Add(new SelectListItem { Text = Resources.DisplayName_SimpleInterest, Value = "S" });
                InterestTypeList.Add(new SelectListItem { Text = Resources.DisplayName_CompoundInterest, Value = "C" });
                ViewData["InterestTypeList"] = InterestTypeList;

                model.ListAccountBalancesheetMaster = GetBalsheetMasterList(accountId, Convert.ToInt32(Session["RoleID"]));
                
                return PartialView("/Views/Accounts/AccountMaster/Create.cshtml",model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public ActionResult Create(AccountMasterViewModel model)
        {
            try
            {
                if (model != null && model.AccountMasterDTO != null)
                {
                    model.AccountMasterDTO.ConnectionString = _connectioString;
                    model.AccountMasterDTO.ID = model.ID;
                    model.AccountMasterDTO.AccBalsheetMstID = model.AccBalsheetMstID;
                    model.AccountMasterDTO.GroupID = model.GroupID;
                    model.AltGroupID = model.AltGroupID;
                    model.AccountMasterDTO.AccountCode = model.AccountCode;
                    model.AccountMasterDTO.AccountName = model.AccountName;
                    model.AccountMasterDTO.CashBankFlag = model.CashBankFlag;
                    

                    model.AccountMasterDTO.ExclusivelyForCentre = model.ExclusivelyForCentre;
                    model.AccountMasterDTO.BackDatetimedEntries = model.BackDatetimedEntries;
                    model.AccountMasterDTO.DebitCreditFlag = model.DebitCreditFlag;
                    if (model.SurpDifiFlag == null)
                    {
                        model.AccountMasterDTO.SurpDifiFlag = string.Empty;
                    }
                    else
                    {
                        model.AccountMasterDTO.SurpDifiFlag = model.SurpDifiFlag;
                    }
                    if (model.PersonType == null)
                    {
                        model.AccountMasterDTO.PersonType = string.Empty;
                    }
                    else
                    {
                        model.AccountMasterDTO.PersonType = model.PersonType;
                    }
                    if (model.BankAccountNumber == null)
                    {
                        model.AccountMasterDTO.BankAccountNumber = string.Empty;
                    }
                    else
                    {
                        model.AccountMasterDTO.BankAccountNumber = model.BankAccountNumber;
                    }
                    if (model.BankLimitAmount <= 0)
                    {
                        model.AccountMasterDTO.BankLimitAmount = 0;
                    }
                    else
                    {
                        model.AccountMasterDTO.BankLimitAmount = model.BankLimitAmount;
                    }

                    if (model.AccountInNameOf == null)
                    {
                        model.AccountMasterDTO.AccountInNameOf = string.Empty;
                    }
                    else
                    {
                        model.AccountMasterDTO.AccountInNameOf = model.AccountInNameOf;
                    }
                    if (model.BankBranchName == null)
                    {
                        model.AccountMasterDTO.BankBranchName = string.Empty;
                    }
                    else
                    {
                        model.AccountMasterDTO.BankBranchName = model.BankBranchName;
                    }
                    if (model.InterestMode == null)
                    {
                        model.AccountMasterDTO.InterestMode = string.Empty;
                    }
                    else
                    {
                        model.AccountMasterDTO.InterestMode = model.InterestMode;
                    }
                    if (model.InterestType == null)
                    {
                        model.AccountMasterDTO.InterestType = string.Empty;
                    }
                    else
                    {
                        model.AccountMasterDTO.InterestType = model.InterestType;
                    }
                    if (model.RateOfInterest <= 0)
                    {
                        model.AccountMasterDTO.RateOfInterest = Convert.ToDecimal(0.00);
                    }
                    else
                    {
                        model.AccountMasterDTO.RateOfInterest = model.RateOfInterest;
                    }
                    model.AccountMasterDTO.SelectedXml = model.SelectedXml;

                    model.AccountMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    model.AccountMasterDTO.IsActive = true;
                    IBaseEntityResponse<AccountMaster> response = _accountMasterBA.InsertAccountMaster(model.AccountMasterDTO);
                    model.AccountMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.AccountMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public ActionResult Edit(Int16 ID, string GroupDesc)
        {
            try
            {
                AccountMasterViewModel model = new AccountMasterViewModel();
                model.ID = ID;
                string splitGroupDesc = GroupDesc.Replace('~', ' ');
                model.GroupDescription = splitGroupDesc;

                List<SelectListItem> CashBankFlaglist = new List<SelectListItem>();
                //CashBankFlaglist.Add(new SelectListItem { Text = "---------------Select---------------", Value = "" });
                CashBankFlaglist.Add(new SelectListItem { Text = Resources.DisplayName_Bank, Value = "B" });
                CashBankFlaglist.Add(new SelectListItem { Text = Resources.DisplayName_Cash, Value = "C" });
                CashBankFlaglist.Add(new SelectListItem { Text = Resources.DisplayName_Ledger, Value = "L" });
                //ViewData["AccountType"] = CashBankFlaglist;

                List<SelectListItem> ControlHeadlist = new List<SelectListItem>();
                ControlHeadlist.Add(new SelectListItem { Text = Resources.DisplayName_Select, Value = "" });
                ControlHeadlist.Add(new SelectListItem { Text = Resources.DisplayName_E_Employee, Value = "E" });
                //ControlHeadlist.Add(new SelectListItem { Text = Resources.DisplayName_S_Student, Value = "S" });
                ControlHeadlist.Add(new SelectListItem { Text = Resources.DisplayName_U_Suppliers, Value = "U" });
                ControlHeadlist.Add(new SelectListItem { Text = Resources.DisplayName_C_Customers, Value = "C" });
                ControlHeadlist.Add(new SelectListItem { Text = Resources.DisplayName_T_ContractEmployee, Value = "T" });
                ControlHeadlist.Add(new SelectListItem { Text = "B-Branch", Value = "B" });
                //ControlHeadlist.Add(new SelectListItem { Text = "Fishermen", Value = "F" });
                //ControlHeadlist.Add(new SelectListItem { Text = "Director", Value = "D" });
                //ViewData["ControlHeadlist"] = ControlHeadlist;

                List<SelectListItem> SurpDefFlagList = new List<SelectListItem>();
                SurpDefFlagList.Add(new SelectListItem { Text = Resources.DisplayName_Select, Value = "" });
                SurpDefFlagList.Add(new SelectListItem { Text = Resources.DisplayName_Surplus, Value = "Surplus" });
                SurpDefFlagList.Add(new SelectListItem { Text = Resources.DisplayName_Deficit, Value = "Deficit" });
                //ViewData["SurpDefFlagList"] = SurpDefFlagList;

                List<SelectListItem> InterestModeList = new List<SelectListItem>();
                //InterestModeList.Add(new SelectListItem { Text = "---------------Select---------------", Value = "" });
                InterestModeList.Add(new SelectListItem { Text = Resources.DisplayName_Monthly, Value = "M" });
                InterestModeList.Add(new SelectListItem { Text = Resources.DisplayName_Quaterly, Value = "Q" });
                InterestModeList.Add(new SelectListItem { Text = Resources.DisplayName_HalfYearly, Value = "H" });
                InterestModeList.Add(new SelectListItem { Text = Resources.DisplayName_Yearly, Value = "Y" });
                //ViewData["InterestModeList"] = InterestModeList;

                List<SelectListItem> InterestTypeList = new List<SelectListItem>();
                //InterestTypeList.Add(new SelectListItem { Text = "---------------Select---------------", Value = "" });
                InterestTypeList.Add(new SelectListItem { Text = Resources.DisplayName_SimpleInterest, Value = "S" });
                InterestTypeList.Add(new SelectListItem { Text = Resources.DisplayName_CompoundInterest, Value = "C" });
                //ViewData["InterestTypeList"] = InterestTypeList;

                model.ListAccountBalancesheetMaster = GetBalsheetMasterList(ID,Convert.ToInt32(Session["RoleID"]));
                foreach (var b in model.ListAccountBalancesheetMaster)
                {
                    if (b.StatusFlag == true)
                    {
                        model.SelectedBalanceSheet = "selected";
                    }
                    else
                    {
                        model.SelectedBalanceSheet = "";
                    }
                }
                model.AccountMasterDTO.ConnectionString = _connectioString;
                IBaseEntityResponse<AccountMaster> response = _accountMasterBA.SelectByID(model.AccountMasterDTO);

                if (response != null && response.Entity != null)
                {
                    model.AccountMasterDTO.ID = response.Entity.ID;
                    model.AccBankDetailsID = response.Entity.AccBankDetailsID;
                    model.AccountMasterDTO.AccBalsheetMstID = response.Entity.AccBalsheetMstID;
                    model.AccountMasterDTO.GroupID = response.Entity.GroupID;
                    model.AccountMasterDTO.AccountCode = response.Entity.AccountCode;
                    model.AccountMasterDTO.AccountName = response.Entity.AccountName;
                    //model.AccountMasterDTO.CashBankFlag = response.Entity.CashBankFlag;
                    //model.AccountMasterDTO.PersonType = response.Entity.PersonType;
                    //model.AccountMasterDTO.SurpDifiFlag = response.Entity.SurpDifiFlag;
                    model.AccountMasterDTO.ExclusivelyForCentre = response.Entity.ExclusivelyForCentre;
                    model.AccountMasterDTO.BackDatetimedEntries = response.Entity.BackDatetimedEntries;
                    model.AccountMasterDTO.DebitCreditFlag = response.Entity.DebitCreditFlag;
                    model.AccountMasterDTO.BankAccountNumber = response.Entity.BankAccountNumber;
                    model.AccountMasterDTO.BankLimitAmount = response.Entity.BankLimitAmount;
                    model.AccountMasterDTO.OpenDatetime = response.Entity.OpenDatetime;
                    //  DateTime.ParseExact(response.Entity.OpenDatetime, "dd/MM/yyyy HH:mm:ss",);
                    model.AccountMasterDTO.DueDatetime = response.Entity.DueDatetime;
                    model.AccountMasterDTO.AccountInNameOf = response.Entity.AccountInNameOf;
                    model.AccountMasterDTO.BankBranchName = response.Entity.BankBranchName;
                    //model.AccountMasterDTO.InterestMode = response.Entity.InterestMode;
                    //model.AccountMasterDTO.InterestType = response.Entity.InterestType;
                    model.AccountMasterDTO.RateOfInterest = response.Entity.RateOfInterest;

                    ViewData["AccountType"] = new SelectList(CashBankFlaglist, "Value", "Text", response.Entity.CashBankFlag);
                    ViewData["ControlHeadlist"] = new SelectList(ControlHeadlist, "Value", "Text", response.Entity.PersonType);
                    ViewData["SurpDefFlagList"] = new SelectList(SurpDefFlagList, "Value", "Text", response.Entity.SurpDifiFlag);
                    ViewData["InterestModeList"] = new SelectList(InterestModeList, "Value", "Text", response.Entity.InterestMode);
                    ViewData["InterestTypeList"] = new SelectList(InterestTypeList, "Value", "Text", response.Entity.InterestType);
                }

                model.ListAlternateGroupList = GetAlternateGroupList(response.Entity.GroupID);
                model.CashBankFlag = response.Entity.CashBankFlag;
                List<SelectListItem> AlternateGroupList = new List<SelectListItem>();
                foreach (AccountMaster item in model.ListAlternateGroupList)
                {
                    AlternateGroupList.Add(new SelectListItem { Text = item.GroupDescription, Value = item.GroupID.ToString() });
                }
               ViewData["AlternateGroupList"]  = new SelectList(AlternateGroupList, "Value", "Text",response.Entity.AltGroupID);

                return PartialView("/Views/Accounts/AccountMaster/Edit.cshtml",model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(AccountMasterViewModel model)
        {
            try
            {
                if (model != null && model.AccountMasterDTO != null)
                {
                    model.AccountMasterDTO.ConnectionString = _connectioString;
                    model.AccountMasterDTO.ID = model.ID;
                    model.AltGroupID = model.AltGroupID;
                    model.AccountMasterDTO.AccBankDetailsID = model.AccBankDetailsID;
                    model.AccountMasterDTO.CashBankFlag = model.CashBankFlag;
                    model.AccountMasterDTO.SurpDifiFlag = model.SurpDifiFlag;
                    model.AccountMasterDTO.BackDatetimedEntries = model.BackDatetimedEntries;
                    model.AccountMasterDTO.DebitCreditFlag = model.DebitCreditFlag;
                    model.AccountMasterDTO.BankLimitAmount = model.BankLimitAmount;
                    model.AccountMasterDTO.DueDatetime = model.DueDatetime;
                    model.AccountMasterDTO.AccountInNameOf = model.AccountInNameOf;
                    model.AccountMasterDTO.BankBranchName = model.BankBranchName;
                    model.AccountMasterDTO.InterestMode = model.InterestMode;
                    model.AccountMasterDTO.InterestType = model.InterestType;
                    model.AccountMasterDTO.RateOfInterest = model.RateOfInterest;
                    model.AccountMasterDTO.SelectedXml = model.SelectedXml;
                    
                    //if (model.SelectedXml == null || model.SelectedXml == string.Empty)
                    //{
                    //    model.AccountMasterDTO.SelectedXml = string.Empty;
                    //}
                    //else
                    //{
                    //    model.AccountMasterDTO.SelectedXml = model.SelectedXml;
                    //}

                    model.AccountMasterDTO.IsActive = true;
                    model.AccountMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<AccountMaster> response = _accountMasterBA.UpdateAccountMaster(model.AccountMasterDTO);
                    model.AccountMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                    return Json(model.AccountMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        //Non-Action method to fetch list of Balancesheet

        [HttpPost]
        public JsonResult GetAccountMasterSearchList(string term)
        {
            AccountMasterSearchRequest searchRequest = new AccountMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.SearchWord = term;
            List<AccountMaster> listAccountMaster = new List<AccountMaster>();
            IBaseEntityCollectionResponse<AccountMaster> baseEntityCollectionResponse = _accountMasterBA.GetAccountMasterSearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listAccountMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            var result = (from r in listAccountMaster
                          select new
                          {
                              AccountMasterID = r.ID,
                              AccountMasterName = r.AccountName,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [NonAction]
        protected List<AccountBalancesheetMaster> GetBalsheetMasterList(int accountId,int RoleID)
        {
            AccountBalancesheetMasterSearchRequest searchRequest = new AccountBalancesheetMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.AccountID = accountId;
            searchRequest.RoleId = RoleID;
            List<AccountBalancesheetMaster> listAccountBalancesheetMaster = new List<AccountBalancesheetMaster>();
            IBaseEntityCollectionResponse<AccountBalancesheetMaster> baseEntityCollectionResponse = _accountBalancesheetMasterBA.GetBalancesheetForMultipleSelectList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listAccountBalancesheetMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listAccountBalancesheetMaster;
        }

        //Non-Action method to fetch list of SurplusDefit Flag
        [NonAction]
        protected List<AccountMaster> GetSurplusDeficitList()
        {
            AccountMasterSearchRequest searchRequest = new AccountMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<AccountMaster> listAccountMaster = new List<AccountMaster>();
            IBaseEntityCollectionResponse<AccountMaster> baseEntityCollectionResponse = _accountMasterBA.GetSurplusDeficitList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listAccountMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listAccountMaster;
        }

        protected List<AccountMaster> GetAlternateGroupList(int groupID)  
        {
            AccountMasterSearchRequest searchRequest = new AccountMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.GroupID = groupID;
            List<AccountMaster> listAccountMaster = new List<AccountMaster>();
            IBaseEntityCollectionResponse<AccountMaster> baseEntityCollectionResponse = _accountMasterBA.GetAlternateGroupList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listAccountMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listAccountMaster;
        }

        // Non-Action method to fetch all records from table.
        [NonAction]
        public List<AccountMaster> GetListAccountMaster(int SelectedBalanceSheet, out int TotalRecords)
        {
            List<AccountMaster> listAccountMaster = new List<AccountMaster>();
            AccountMasterSearchRequest searchRequest = new AccountMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            _actionMode = Convert.ToString(TempData["ActionMode"]);
            if (Enum.TryParse(_actionMode, out actionModeEnum))     // checks actionMode i.e. Insert or Update // 
            {
                if (actionModeEnum == ActionModeEnum.Insert)        // parameters for SelectAll procedures under Insert or Update mode condition
                {
                    searchRequest.SortBy = "A.CreatedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                    searchRequest.BalancesheetID = SelectedBalanceSheet;
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "A.ModifiedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                    searchRequest.BalancesheetID = SelectedBalanceSheet;
                }
            }
            else
            {
                searchRequest.SortBy = _sortBy;                     // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;
                searchRequest.BalancesheetID = SelectedBalanceSheet;
            }
            IBaseEntityCollectionResponse<AccountMaster> baseEntityCollectionResponse = _accountMasterBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listAccountMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listAccountMaster;
        }
        #endregion

        #region ------------CONTROLLER AJAX HANDLER METHODS------------
        /// <summary>
        /// AJAX Method for binding List Account category master
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public ActionResult AjaxHandler(JQueryDataTableParamModel param, int SelectedBalanceSheet)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<AccountMaster> filteredAccountMaster;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "GroupDescription";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "GroupDescription Like '%" + param.sSearch + "%' or AccountCode Like '%" + param.sSearch + "%'  or CentreCode Like '%" + param.sSearch + "%'  or AccountName Like '%" + param.sSearch + "%' or ActBalsheetHeadDesc Like '%" + param.sSearch + "%' or BankAccountNumber Like '%" + param.sSearch + "%'";         //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "AccountCode";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "GroupDescription Like '%" + param.sSearch + "%' or AccountCode Like '%" + param.sSearch + "%'  or CentreCode Like '%" + param.sSearch + "%' or AccountName Like '%" + param.sSearch + "%' or ActBalsheetHeadDesc Like '%" + param.sSearch + "%'  or BankAccountNumber Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 2:
                    _sortBy = "BankAccountNumber";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "GroupDescription Like '%" + param.sSearch + "%' or AccountCode Like '%" + param.sSearch + "%'  or CentreCode Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            if (SelectedBalanceSheet > 0)
            {
                filteredAccountMaster = GetListAccountMaster(SelectedBalanceSheet, out TotalRecords);    
            }
            else
            {
                filteredAccountMaster = new List<AccountMaster>();
                TotalRecords = 0;
            }
            
            var records = filteredAccountMaster.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.AccountName), Convert.ToString(c.AccountCode),  Convert.ToString(c.CentreCode + "~" +c.AccBalsheetHeadDesc), Convert.ToString(c.GroupDescription), Convert.ToString(c.GroupID), Convert.ToString(c.AccCenterwiseID), Convert.ToString(c.ID), Convert.ToString(c.AccBankDetailsID) };

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}
