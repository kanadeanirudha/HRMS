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
    public class AccountSessionMasterController : BaseController
    {
        IAccountSessionMasterBA _accountSessionMasterBA = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public AccountSessionMasterController()
        {
            _accountSessionMasterBA = new AccountSessionMasterBA();
        }

        #region Controller Methods
        public ActionResult Index()
        {
            if (Convert.ToInt32(Session["Account Manager"]) > 0)
            {
                return View("/Views/Accounts/AccountSessionMaster/Index.cshtml");
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
                AccountSessionMasterViewModel model = new AccountSessionMasterViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Accounts/AccountSessionMaster/List.cshtml", model);
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
            AccountSessionMasterViewModel model = new AccountSessionMasterViewModel();
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem { Text = Resources.DisplayName_Cash, Value = "Cash" });
            list.Add(new SelectListItem { Text = Resources.DisplayName_Merchandise, Value = "Merchandise" });
            ViewData["Account_System"] = list;
            return PartialView("/Views/Accounts/AccountSessionMaster/Create.cshtml",model);
        }

        [HttpPost]
        public ActionResult Create(AccountSessionMasterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.AccountSessionMasterDTO != null)
                    {
                        model.AccountSessionMasterDTO.ConnectionString = _connectioString;
                        model.AccountSessionMasterDTO.SessionStartDatetime = model.SessionStartDatetime;
                        model.AccountSessionMasterDTO.SessionEndDatetime= model.SessionEndDatetime;
                        model.AccountSessionMasterDTO.Account_System = model.Account_System;
                        model.AccountSessionMasterDTO.IsActive = model.IsActive;
                        model.AccountSessionMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);

                        IBaseEntityResponse<AccountSessionMaster> response = _accountSessionMasterBA.InsertAccountSessionMaster(model.AccountSessionMasterDTO);
                        model.AccountSessionMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    }
                    return Json(model.AccountSessionMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
                AccountSessionMasterViewModel model = new AccountSessionMasterViewModel();
                List<SelectListItem> list = new List<SelectListItem>();
                list.Add(new SelectListItem { Text = "Cash", Value = "Cash" });
                list.Add(new SelectListItem { Text = "Merchandise", Value = "Merchandise" });

                model.AccountSessionMasterDTO = new AccountSessionMaster();
                model.AccountSessionMasterDTO.ID = ID;
                model.AccountSessionMasterDTO.ConnectionString = _connectioString;
                IBaseEntityResponse<AccountSessionMaster> response = _accountSessionMasterBA.SelectByID(model.AccountSessionMasterDTO);

                if (response != null && response.Entity != null)
                {
                    model.AccountSessionMasterDTO.ID = response.Entity.ID;
                    model.AccountSessionMasterDTO.SessionStartDatetime = response.Entity.SessionStartDatetime;
                    model.AccountSessionMasterDTO.SessionEndDatetime = response.Entity.SessionEndDatetime;
                    model.AccountSessionMasterDTO.IsActive = response.Entity.IsActive;
                    ViewData["Account_System"] = new SelectList(list, "Text", "Value", response.Entity.Account_System);
                }

                return PartialView("/Views/Accounts/AccountSessionMaster/Edit.cshtml",model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }

        [HttpPost]
        public ActionResult Edit(AccountSessionMasterViewModel model)
        {
            try
            {
                //if (ModelState.IsValid)
                //{
                    if (model != null && model.AccountSessionMasterDTO != null)
                    {
                        model.AccountSessionMasterDTO.ConnectionString = _connectioString;
                        model.AccountSessionMasterDTO.ID = model.ID;
                        //model.AccountSessionMasterDTO.SessionStartDatetime = model.SessionStartDatetime;
                        //model.AccountSessionMasterDTO.SessionEndDatetime = model.SessionEndDatetime;
                        //model.AccountSessionMasterDTO.Account_System = model.Account_System;
                        model.AccountSessionMasterDTO.IsActive = model.IsActive;
                        model.AccountSessionMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<AccountSessionMaster> response = _accountSessionMasterBA.UpdateAccountSessionMaster(model.AccountSessionMasterDTO);
                        model.AccountSessionMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                         return Json(model.AccountSessionMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json("Please review your form");
                    }
                //}
                //else
                //{
                //    return Json("Please review your form");
                //}
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }
        
        public ActionResult Delete(short ID)
        {
            AccountSessionMasterViewModel model = new AccountSessionMasterViewModel();
            try
            {
                if (ID > 0)
                {

                    AccountSessionMaster AccountSessionMasterDTO = new AccountSessionMaster();
                    AccountSessionMasterDTO.ConnectionString = _connectioString;
                    AccountSessionMasterDTO.ID = ID;
                    AccountSessionMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<AccountSessionMaster> response = _accountSessionMasterBA.DeleteAccountSessionMaster(AccountSessionMasterDTO);
                    model.AccountSessionMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
                    return Json(model.AccountSessionMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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

        #region Methods
        [NonAction]
        public List<AccountSessionMaster> GetListAccountSessionMaster(out int TotalRecords)
        {
            List<AccountSessionMaster> listAccountSessionMaster = new List<AccountSessionMaster>();
            AccountSessionMasterSearchRequest searchRequest = new AccountSessionMasterSearchRequest();
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
            IBaseEntityCollectionResponse<AccountSessionMaster> baseEntityCollectionResponse = _accountSessionMasterBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listAccountSessionMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listAccountSessionMaster;
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

            IEnumerable<AccountSessionMaster> filteredAccountSessionMaster;

            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "Account_System";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "Account_System Like '%" + param.sSearch + "%' or SessionStartDatetime Like '%" + param.sSearch + "%' or SessionEndDatetime Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "SessionStartDatetime";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "Account_System Like '%" + param.sSearch + "%' or SessionStartDatetime Like '%" + param.sSearch + "%' or SessionEndDatetime Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 2:
                    _sortBy = "SessionEndDatetime";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "Account_System Like '%" + param.sSearch + "%' or SessionStartDatetime Like '%" + param.sSearch + "%' or SessionEndDatetime Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            filteredAccountSessionMaster = GetListAccountSessionMaster(out TotalRecords);
            var records = filteredAccountSessionMaster.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.Account_System), Convert.ToString(c.SessionStartDatetime), Convert.ToString(c.SessionEndDatetime),Convert.ToString(c.IsActive), Convert.ToString(c.ID), };

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
         #endregion
    }

}
