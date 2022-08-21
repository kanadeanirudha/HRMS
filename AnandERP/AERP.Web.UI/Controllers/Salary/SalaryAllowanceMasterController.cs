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
    public class SalaryAllowanceMasterController : BaseController
    {
        ISalaryAllowanceMasterBA _SalaryAllowanceMasterBA = null;

        string _centreCode = string.Empty;
        string _designationId = string.Empty;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public SalaryAllowanceMasterController()
        {
            _SalaryAllowanceMasterBA = new SalaryAllowanceMasterBA();
        }

        #region Controller Methods

        /// <summary>
        /// First Load When controller call List Method
        /// </summary>
        /// <returns>view</returns>
        [HttpGet]
        public ActionResult Index()
        {
            if (Convert.ToString(Session["UserType"]) == "A" || Convert.ToInt32(Session["HR Manager"]) > 0)
            {
                return View("/Views/Salary/SalaryAllowanceMaster/Index.cshtml");
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
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Salary/SalaryAllowanceMaster/List.cshtml");

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
            SalaryAllowanceMasterViewModel model = new SalaryAllowanceMasterViewModel();
            try
            {
                List<SelectListItem> li_AllowanceType = new List<SelectListItem>();
                li_AllowanceType.Add(new SelectListItem { Text = "House Rent Allowance", Value = "HRA" });
                li_AllowanceType.Add(new SelectListItem { Text = "Dearness Allowance", Value = "DA" });
                li_AllowanceType.Add(new SelectListItem { Text = "Travelling Allowance", Value = "TA" });
                li_AllowanceType.Add(new SelectListItem { Text = "Leave With Wages", Value = "LWW" });
                li_AllowanceType.Add(new SelectListItem { Text = "Over Time", Value = "OT" });
                li_AllowanceType.Add(new SelectListItem { Text = "Reimbursement Allowance", Value = "RIA" });
                li_AllowanceType.Add(new SelectListItem { Text = "Additional Allowance", Value = "AddA" });
                li_AllowanceType.Add(new SelectListItem { Text = "Other", Value = "Other" });
                ViewBag.AllowanceTypeList = new SelectList(li_AllowanceType, "Value", "Text");

                List<SelectListItem> li_ComplianceType = new List<SelectListItem>();
                li_ComplianceType.Add(new SelectListItem { Text = "Compliance", Value = "1" });
                li_ComplianceType.Add(new SelectListItem { Text = "Non Compliance", Value = "2" });
                ViewBag.ComplianceTypeList = new SelectList(li_ComplianceType, "Value", "Text");

                return PartialView("/Views/Salary/SalaryAllowanceMaster/Create.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public ActionResult Create(SalaryAllowanceMasterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.SalaryAllowanceMasterDTO != null)
                    {
                        model.SalaryAllowanceMasterDTO.ConnectionString = _connectioString;

                        model.SalaryAllowanceMasterDTO.AllowanceHeadName = model.AllowanceHeadName;
                        model.SalaryAllowanceMasterDTO.AllowanceType = model.AllowanceType;
                        model.SalaryAllowanceMasterDTO.AllowanceSubType = model.AllowanceSubType;
                        model.SalaryAllowanceMasterDTO.ComplianceType = model.ComplianceType;

                        model.SalaryAllowanceMasterDTO.CreatedBy = Convert.ToInt32(Session["UserId"]);

                        IBaseEntityResponse<SalaryAllowanceMaster> response = _SalaryAllowanceMasterBA.InsertSalaryAllowanceMaster(model.SalaryAllowanceMasterDTO);
                        model.SalaryAllowanceMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    }
                    return Json(model.SalaryAllowanceMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public ActionResult CreateSalaryAllowanceRules(byte ID)
        {
            SalaryAllowanceMasterViewModel model = new SalaryAllowanceMasterViewModel();
            try
            {
                model.ID = ID;

                List<SelectListItem> li_Gender = new List<SelectListItem>();
                li_Gender.Add(new SelectListItem { Text = "Male", Value = "1" });
                li_Gender.Add(new SelectListItem { Text = "Female", Value = "2" });
                li_Gender.Add(new SelectListItem { Text = "Third Gender", Value = "3" });
                ViewBag.GenderList = new SelectList(li_Gender, "Value", "Text");

                model.CalculateOnListForRules = GetCalculateOnListForRules(0);

                return PartialView("/Views/Salary/SalaryAllowanceMaster/CreateSalaryAllowanceRules.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public ActionResult CreateSalaryAllowanceRules(SalaryAllowanceMasterViewModel model)
        {
            try
            {

                if (model != null && model.SalaryAllowanceMasterDTO != null)
                {
                    model.SalaryAllowanceMasterDTO.ConnectionString = _connectioString;

                    model.SalaryAllowanceMasterDTO.ID = model.ID;
                    model.SalaryAllowanceMasterDTO.IsGenderSpecific = model.IsGenderSpecific;
                    model.SalaryAllowanceMasterDTO.Gender = model.Gender;
                    model.SalaryAllowanceMasterDTO.FixedAmount = model.FixedAmount;
                    model.SalaryAllowanceMasterDTO.Percentage = model.Percentage;
                    model.SalaryAllowanceMasterDTO.CalculateOn = model.CalculateOn;
                    model.SalaryAllowanceMasterDTO.EffectedDate = model.EffectedDate;
                    model.SalaryAllowanceMasterDTO.CloseDate = model.CloseDate;
                    model.SalaryAllowanceMasterDTO.IsCurrent = model.IsCurrent;
                    model.SalaryAllowanceMasterDTO.RangeFrom = model.RangeFrom;
                    model.SalaryAllowanceMasterDTO.RangeUpto = model.RangeUpto;
                    model.SalaryAllowanceMasterDTO.CalculateOnFixedAmount = model.CalculateOnFixedAmount;
                    model.SalaryAllowanceMasterDTO.XMLStringForCalculateOn = model.XMLStringForCalculateOn;

                    model.SalaryAllowanceMasterDTO.CreatedBy = Convert.ToInt32(Session["UserId"]);

                    IBaseEntityResponse<SalaryAllowanceMaster> response = _SalaryAllowanceMasterBA.InsertSalaryAllowanceRules(model.SalaryAllowanceMasterDTO);
                    model.SalaryAllowanceMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                }
                return Json(model.SalaryAllowanceMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);

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
                SalaryAllowanceMasterViewModel model = new SalaryAllowanceMasterViewModel();
                model.SalaryAllowanceMasterDTO = new SalaryAllowanceMaster();
                model.SalaryAllowanceMasterDTO.ID = ID;
                model.SalaryAllowanceMasterDTO.ConnectionString = _connectioString;

                List<SelectListItem> li_AllowanceType = new List<SelectListItem>();
                li_AllowanceType.Add(new SelectListItem { Text = "House Rent Allowance", Value = "HRA" });
                li_AllowanceType.Add(new SelectListItem { Text = "Dearness Allowance", Value = "DA" });
                li_AllowanceType.Add(new SelectListItem { Text = "Travelling Allowance", Value = "TA" });
                li_AllowanceType.Add(new SelectListItem { Text = "Leave With Wages", Value = "LWW" });
                li_AllowanceType.Add(new SelectListItem { Text = "Over Time", Value = "OT" });
                li_AllowanceType.Add(new SelectListItem { Text = "Reimbursement Allowance", Value = "RIA" });
                li_AllowanceType.Add(new SelectListItem { Text = "Additional Allowance", Value = "AddA" });
                li_AllowanceType.Add(new SelectListItem { Text = "Other", Value = "Other" });
                ViewBag.AllowanceTypeList = new SelectList(li_AllowanceType, "Value", "Text");

                List<SelectListItem> li_ComplianceType = new List<SelectListItem>();
                li_ComplianceType.Add(new SelectListItem { Text = "Compliance", Value = "1" });
                li_ComplianceType.Add(new SelectListItem { Text = "Non Compliance", Value = "2" });
                ViewBag.ComplianceTypeList = new SelectList(li_ComplianceType, "Value", "Text");

                IBaseEntityResponse<SalaryAllowanceMaster> response = _SalaryAllowanceMasterBA.SelectByID(model.SalaryAllowanceMasterDTO);
                if (response != null && response.Entity != null)
                {
                    model.SalaryAllowanceMasterDTO.ID = response.Entity.ID;
                    model.SalaryAllowanceMasterDTO.AllowanceHeadName = response.Entity.AllowanceHeadName;
                    model.SalaryAllowanceMasterDTO.AllowanceSubType = response.Entity.AllowanceSubType;
                    model.SalaryAllowanceMasterDTO.AllowanceType = response.Entity.AllowanceType;
                    model.SalaryAllowanceMasterDTO.ComplianceType = response.Entity.ComplianceType;
                }
                return PartialView("/Views/Salary/SalaryAllowanceMaster/Edit.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(SalaryAllowanceMasterViewModel model)
        {
            try
            {

                if (model != null && model.SalaryAllowanceMasterDTO != null)
                {
                    model.SalaryAllowanceMasterDTO.ConnectionString = _connectioString;

                    model.SalaryAllowanceMasterDTO.ID = model.ID;
                    model.SalaryAllowanceMasterDTO.AllowanceHeadName = model.AllowanceHeadName;
                    model.SalaryAllowanceMasterDTO.AllowanceType = model.AllowanceType;
                    model.SalaryAllowanceMasterDTO.AllowanceSubType = model.AllowanceSubType;
                    model.SalaryAllowanceMasterDTO.ComplianceType = model.ComplianceType;


                    model.SalaryAllowanceMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserId"]);

                    IBaseEntityResponse<SalaryAllowanceMaster> response = _SalaryAllowanceMasterBA.UpdateSalaryAllowanceMaster(model.SalaryAllowanceMasterDTO);
                    model.SalaryAllowanceMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                }
                return Json(model.SalaryAllowanceMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpGet]
        public ActionResult EditSalaryAllowanceRules(byte ID)
        {
            try
            {
                SalaryAllowanceMasterViewModel model = new SalaryAllowanceMasterViewModel();

                model.SalaryAllowanceMasterDTO = new SalaryAllowanceMaster();
                model.SalaryAllowanceMasterDTO.SalaryAllowanceRulesID = ID;
                model.SalaryAllowanceMasterDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<SalaryAllowanceMaster> response = _SalaryAllowanceMasterBA.SelectBySalaryAllowanceRulesID(model.SalaryAllowanceMasterDTO);

                List<SelectListItem> li_Gender = new List<SelectListItem>();
                li_Gender.Add(new SelectListItem { Text = "Male", Value = "1" });
                li_Gender.Add(new SelectListItem { Text = "Female", Value = "2" });
                li_Gender.Add(new SelectListItem { Text = "Third Gender", Value = "3" });
                ViewBag.GenderList = new SelectList(li_Gender, "Value", "Text");

                List<SelectListItem> li_CalculateOn = new List<SelectListItem>();
                li_CalculateOn.Add(new SelectListItem { Text = "Basic", Value = "1" });
                li_CalculateOn.Add(new SelectListItem { Text = "Gross Pay", Value = "2" });
                li_CalculateOn.Add(new SelectListItem { Text = "Total", Value = "3" });
                ViewBag.CalculateOnList = new SelectList(li_CalculateOn, "Value", "Text");

                if (response != null && response.Entity != null)
                {
                    model.SalaryAllowanceMasterDTO.ID = response.Entity.ID;
                    model.SalaryAllowanceMasterDTO.SalaryAllowanceRulesID = response.Entity.SalaryAllowanceRulesID;
                    model.SalaryAllowanceMasterDTO.IsGenderSpecific = response.Entity.IsGenderSpecific;
                    model.SalaryAllowanceMasterDTO.Gender = response.Entity.Gender;
                    model.SalaryAllowanceMasterDTO.FixedAmount = response.Entity.FixedAmount;
                    model.SalaryAllowanceMasterDTO.Percentage = response.Entity.Percentage;
                    model.SalaryAllowanceMasterDTO.CalculateOn = response.Entity.CalculateOn;
                    model.SalaryAllowanceMasterDTO.EffectedDate = response.Entity.EffectedDate;
                    model.SalaryAllowanceMasterDTO.CloseDate = response.Entity.CloseDate;
                    model.SalaryAllowanceMasterDTO.IsCurrent = response.Entity.IsCurrent;
                    model.SalaryAllowanceMasterDTO.RangeFrom = response.Entity.RangeFrom;
                    model.SalaryAllowanceMasterDTO.RangeUpto = response.Entity.RangeUpto;
                    model.SalaryAllowanceMasterDTO.CalculateOnFixedAmount = response.Entity.CalculateOnFixedAmount;

                    model.CalculateOnListForRules = GetCalculateOnListForRules(model.SalaryAllowanceMasterDTO.SalaryAllowanceRulesID);

                }
                return PartialView("/Views/Salary/SalaryAllowanceMaster/EditSalaryAllowanceRules.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public ActionResult EditSalaryAllowanceRules(SalaryAllowanceMasterViewModel model)
        {
            try
            {

                if (model != null && model.SalaryAllowanceMasterDTO != null)
                {
                    model.SalaryAllowanceMasterDTO.ConnectionString = _connectioString;

                    model.SalaryAllowanceMasterDTO.ID = model.ID;
                    model.SalaryAllowanceMasterDTO.SalaryAllowanceRulesID = model.SalaryAllowanceRulesID;
                    model.SalaryAllowanceMasterDTO.IsGenderSpecific = model.IsGenderSpecific;
                    model.SalaryAllowanceMasterDTO.Gender = model.Gender;
                    model.SalaryAllowanceMasterDTO.FixedAmount = model.FixedAmount;
                    model.SalaryAllowanceMasterDTO.Percentage = model.Percentage;
                    model.SalaryAllowanceMasterDTO.CalculateOn = model.CalculateOn;
                    model.SalaryAllowanceMasterDTO.EffectedDate = model.EffectedDate;
                    model.SalaryAllowanceMasterDTO.CloseDate = model.CloseDate;
                    model.SalaryAllowanceMasterDTO.IsCurrent = model.IsCurrent;
                    model.SalaryAllowanceMasterDTO.RangeFrom = model.RangeFrom;
                    model.SalaryAllowanceMasterDTO.RangeUpto = model.RangeUpto;
                    model.SalaryAllowanceMasterDTO.CalculateOnFixedAmount = model.CalculateOnFixedAmount;
                    model.SalaryAllowanceMasterDTO.XMLStringForCalculateOn = model.XMLStringForCalculateOn;

                    model.SalaryAllowanceMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserId"]);

                    IBaseEntityResponse<SalaryAllowanceMaster> response = _SalaryAllowanceMasterBA.UpdateSalaryAllowanceRules(model.SalaryAllowanceMasterDTO);
                    model.SalaryAllowanceMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                }
                return Json(model.SalaryAllowanceMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        public ActionResult DeleteSalaryAllowanceRules(byte ID)
        {
            try
            {
                SalaryAllowanceMasterViewModel model = new SalaryAllowanceMasterViewModel();

                if (ID > 0)
                {
                    model.SalaryAllowanceMasterDTO = new SalaryAllowanceMaster();
                    model.SalaryAllowanceMasterDTO.ConnectionString = _connectioString;
                    model.SalaryAllowanceMasterDTO.SalaryAllowanceRulesID = ID;

                    model.SalaryAllowanceMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<SalaryAllowanceMaster> response = _SalaryAllowanceMasterBA.DeleteSalaryAllowanceRules(model.SalaryAllowanceMasterDTO);
                    model.SalaryAllowanceMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
                }
                return Json(model.SalaryAllowanceMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }
        #endregion

        #region Methods

        protected List<SalaryAllowanceMaster> GetCalculateOnListForRules(byte SalaryAllowanceRulesID)
        {

            SalaryAllowanceMasterSearchRequest searchRequest = new SalaryAllowanceMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.SalaryAllowanceRulesID = SalaryAllowanceRulesID;

            List<SalaryAllowanceMaster> listSalaryAllowanceMaster = new List<SalaryAllowanceMaster>();
            IBaseEntityCollectionResponse<SalaryAllowanceMaster> baseEntityCollectionResponse = _SalaryAllowanceMasterBA.GetCalculateOnListForRules(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listSalaryAllowanceMaster = baseEntityCollectionResponse.CollectionResponse.ToList();

                }
            }
            return listSalaryAllowanceMaster;
        }

        [NonAction]
        public IEnumerable<SalaryAllowanceMasterViewModel> GetSalaryAllowanceMaster(out int TotalRecords)
        {
            try
            {
                SalaryAllowanceMasterSearchRequest searchRequest = new SalaryAllowanceMasterSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
                _actionMode = Convert.ToString(TempData["ActionMode"]);
                if (Enum.TryParse(_actionMode, out actionModeEnum))     // checks actionMode i.e. Insert or Update // 
                {
                    if (actionModeEnum == ActionModeEnum.Insert)        // parameters for SelectAll procedures under Insert or Update mode condition
                    {
                        searchRequest.SortBy = "B.CreatedDate";
                        searchRequest.StartRow = 0;
                        searchRequest.EndRow = 10;
                        searchRequest.SearchBy = string.Empty;
                        searchRequest.SortDirection = "Desc";
                    }
                    if (actionModeEnum == ActionModeEnum.Update)
                    {
                        searchRequest.SortBy = "B.ModifiedDate";
                        searchRequest.StartRow = 0;
                        searchRequest.EndRow = 10;
                        searchRequest.SearchBy = string.Empty;
                        searchRequest.SortDirection = "Desc";
                    }
                }
                else
                {
                    searchRequest.SortBy = _sortBy;                     // parameters for SelectAll procedures under normal condition(Procedure Name : USP_AdminPostApplicableToRole_SelectAll)
                    searchRequest.StartRow = _startRow;
                    searchRequest.EndRow = _startRow + _rowLength;
                    searchRequest.SearchBy = _searchBy;
                    searchRequest.SortDirection = _sortDirection;
                }

                List<SalaryAllowanceMasterViewModel> listSalaryAllowanceMasterViewModel = new List<SalaryAllowanceMasterViewModel>();
                List<SalaryAllowanceMaster> listSalaryAllowanceMaster = new List<SalaryAllowanceMaster>();
                IBaseEntityCollectionResponse<SalaryAllowanceMaster> baseEntityCollectionResponse = _SalaryAllowanceMasterBA.GetBySearch(searchRequest);
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        listSalaryAllowanceMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                        foreach (SalaryAllowanceMaster item in listSalaryAllowanceMaster)
                        {
                            SalaryAllowanceMasterViewModel SalaryAllowanceMasterViewModel = new SalaryAllowanceMasterViewModel();
                            SalaryAllowanceMasterViewModel.SalaryAllowanceMasterDTO = item;
                            listSalaryAllowanceMasterViewModel.Add(SalaryAllowanceMasterViewModel);
                        }
                    }
                }
                TotalRecords = baseEntityCollectionResponse.TotalRecords;

                return listSalaryAllowanceMasterViewModel;
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }
        #endregion

        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        {
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc
            int TotalRecords;
            IEnumerable<SalaryAllowanceMasterViewModel> filteredSalaryAllowanceMaster;

            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "A.AllowanceHeadName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "A.AllowanceHeadName Like '%" + param.sSearch + "%' or B.Gender Like '%" + param.sSearch + "%' or B.FixedAmount Like '%" + param.sSearch + "%' or B.Percentage Like '%" + param.sSearch + "%' or B.EffectedDate Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "B.Gender";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "A.AllowanceHeadName Like '%" + param.sSearch + "%' or B.Gender Like '%" + param.sSearch + "%' or B.FixedAmount Like '%" + param.sSearch + "%' or B.Percentage Like '%" + param.sSearch + "%' or B.EffectedDate Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 2:
                    _sortBy = "B.FixedAmount";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "A.AllowanceHeadName Like '%" + param.sSearch + "%' or B.Gender Like '%" + param.sSearch + "%' or B.FixedAmount Like '%" + param.sSearch + "%' or B.Percentage Like '%" + param.sSearch + "%' or B.EffectedDate Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 3:
                    _sortBy = "B.Percentage";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "A.AllowanceHeadName Like '%" + param.sSearch + "%' or B.Gender Like '%" + param.sSearch + "%' or B.FixedAmount Like '%" + param.sSearch + "%' or B.Percentage Like '%" + param.sSearch + "%' or B.EffectedDate Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 4:
                    _sortBy = "B.EffectedDate";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "A.AllowanceHeadName Like '%" + param.sSearch + "%' or B.Gender Like '%" + param.sSearch + "%' or B.FixedAmount Like '%" + param.sSearch + "%' or B.Percentage Like '%" + param.sSearch + "%' or B.EffectedDate Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
            }

            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;

            filteredSalaryAllowanceMaster = GetSalaryAllowanceMaster(out TotalRecords);

            var records = filteredSalaryAllowanceMaster.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.ID), Convert.ToString(c.AllowanceHeadName), Convert.ToString(c.AllowanceType), Convert.ToString(c.SalaryAllowanceRulesID), Convert.ToString(c.Gender), Convert.ToString(c.FixedAmount), Convert.ToString(c.Percentage), Convert.ToString(c.EffectedDate) };
            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);

        }
        #endregion
    }
}


