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
    public class SalaryDeductionMasterController : BaseController
    {
        ISalaryDeductionMasterBA _SalaryDeductionMasterBA = null;

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

        public SalaryDeductionMasterController()
        {
            _SalaryDeductionMasterBA = new SalaryDeductionMasterBA();
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
                return View("/Views/Salary/SalaryDeductionMaster/Index.cshtml");
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
                return PartialView("/Views/Salary/SalaryDeductionMaster/List.cshtml");

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
            SalaryDeductionMasterViewModel model = new SalaryDeductionMasterViewModel();
            try
            {
                List<SelectListItem> li_DeductionType = new List<SelectListItem>();
                li_DeductionType.Add(new SelectListItem { Text = "Provident Fund", Value = "PF" });
                li_DeductionType.Add(new SelectListItem { Text = "ESIC", Value = "ESIC" });
                li_DeductionType.Add(new SelectListItem { Text = "Professional Tax", Value = "PT" });
                li_DeductionType.Add(new SelectListItem { Text = "LIC", Value = "LIC" });
                li_DeductionType.Add(new SelectListItem { Text = "Loan", Value = "Loan" });
                li_DeductionType.Add(new SelectListItem { Text = "TDS", Value = "TDS" });
                li_DeductionType.Add(new SelectListItem { Text = "Bonus", Value = "BONUS" });
                li_DeductionType.Add(new SelectListItem { Text = "Gratuity", Value = "GRTY" });
                li_DeductionType.Add(new SelectListItem { Text = "MLWF", Value = "MLWF" });
                li_DeductionType.Add(new SelectListItem { Text = "Uniform & Shoes", Value = "UAS" });
                li_DeductionType.Add(new SelectListItem { Text = "Advance Amount", Value = "ADVA" });
                li_DeductionType.Add(new SelectListItem { Text = "Fine", Value = "Fine" });
                li_DeductionType.Add(new SelectListItem { Text = "Food Deduction", Value = "FOODD" });
                li_DeductionType.Add(new SelectListItem { Text = "Leave With Wages", Value = "LWW" });
                li_DeductionType.Add(new SelectListItem { Text = "Other", Value = "Other" });
                ViewBag.DeductionTypeList = new SelectList(li_DeductionType, "Value", "Text");

                List<SelectListItem> li_ComplianceType = new List<SelectListItem>();
                li_ComplianceType.Add(new SelectListItem { Text = "Compliance", Value = "1" });
                li_ComplianceType.Add(new SelectListItem { Text = "Non Compliance", Value = "2" });
                ViewBag.ComplianceTypeList = new SelectList(li_ComplianceType, "Value", "Text");

                return PartialView("/Views/Salary/SalaryDeductionMaster/Create.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public ActionResult Create(SalaryDeductionMasterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.SalaryDeductionMasterDTO != null)
                    {
                        model.SalaryDeductionMasterDTO.ConnectionString = _connectioString;

                        model.SalaryDeductionMasterDTO.DeductionHeadName = model.DeductionHeadName;
                        model.SalaryDeductionMasterDTO.DeductionType = model.DeductionType;
                        model.SalaryDeductionMasterDTO.DeductionSubType = model.DeductionSubType;
                        model.SalaryDeductionMasterDTO.ComplianceType = model.ComplianceType; 

                        model.SalaryDeductionMasterDTO.CreatedBy = Convert.ToInt32(Session["UserId"]);

                        IBaseEntityResponse<SalaryDeductionMaster> response = _SalaryDeductionMasterBA.InsertSalaryDeductionMaster(model.SalaryDeductionMasterDTO);
                        model.SalaryDeductionMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    }
                    return Json(model.SalaryDeductionMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public ActionResult CreateSalaryDeductionRules(byte ID)
        {
            SalaryDeductionMasterViewModel model = new SalaryDeductionMasterViewModel();
            try
            {
                model.ID = ID;

                List<SelectListItem> li_Gender = new List<SelectListItem>();
                li_Gender.Add(new SelectListItem { Text = "Male", Value = "1" });
                li_Gender.Add(new SelectListItem { Text = "Female", Value = "2" });
                li_Gender.Add(new SelectListItem { Text = "Third Gender", Value = "3" });
                ViewBag.GenderList = new SelectList(li_Gender, "Value", "Text");

                //List<SelectListItem> li_CalculateOn = new List<SelectListItem>();
                //li_CalculateOn.Add(new SelectListItem { Text = "Basic", Value = "1" });
                //li_CalculateOn.Add(new SelectListItem { Text = "Gross Pay", Value = "2" });
                //li_CalculateOn.Add(new SelectListItem { Text = "Total", Value = "3" });
                //ViewBag.CalculateOnList = new SelectList(li_CalculateOn, "Value", "Text");

                List<SelectListItem> li_ContributionType = new List<SelectListItem>();
                li_ContributionType.Add(new SelectListItem { Text = "Employee", Value = "1" });
                li_ContributionType.Add(new SelectListItem { Text = "Employer", Value = "2" });
                ViewBag.ContributionTypeList = new SelectList(li_ContributionType, "Value", "Text");

                model.CalculateOnListForRules = GetCalculateOnListForRules(0);

                return PartialView("/Views/Salary/SalaryDeductionMaster/CreateSalaryDeductionRules.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public ActionResult CreateSalaryDeductionRules(SalaryDeductionMasterViewModel model)
        {
            try
            {

                if (model != null && model.SalaryDeductionMasterDTO != null)
                {
                    model.SalaryDeductionMasterDTO.ConnectionString = _connectioString;

                    model.SalaryDeductionMasterDTO.ID = model.ID;
                    model.SalaryDeductionMasterDTO.IsGenderSpecific = model.IsGenderSpecific;
                    model.SalaryDeductionMasterDTO.Gender = model.Gender;
                    model.SalaryDeductionMasterDTO.FixedAmount = model.FixedAmount;
                    model.SalaryDeductionMasterDTO.Percentage = model.Percentage;
                    model.SalaryDeductionMasterDTO.CalculateOn = model.CalculateOn;
                    model.SalaryDeductionMasterDTO.EffectedDate = model.EffectedDate;
                    model.SalaryDeductionMasterDTO.CloseDate = model.CloseDate;
                    model.SalaryDeductionMasterDTO.IsCurrent = model.IsCurrent;
                    model.SalaryDeductionMasterDTO.ContributionType = model.ContributionType;
                    model.SalaryDeductionMasterDTO.RangeFrom = model.RangeFrom;
                    model.SalaryDeductionMasterDTO.RangeUpto = model.RangeUpto;
                    model.SalaryDeductionMasterDTO.CalculateOnFixedAmount = model.CalculateOnFixedAmount;
                    model.SalaryDeductionMasterDTO.XMLStringForCalculateOn = model.XMLStringForCalculateOn;

                    model.SalaryDeductionMasterDTO.CreatedBy = Convert.ToInt32(Session["UserId"]);

                    IBaseEntityResponse<SalaryDeductionMaster> response = _SalaryDeductionMasterBA.InsertSalaryDeductionRules(model.SalaryDeductionMasterDTO);
                    model.SalaryDeductionMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                }
                return Json(model.SalaryDeductionMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);

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
                SalaryDeductionMasterViewModel model = new SalaryDeductionMasterViewModel();
                model.SalaryDeductionMasterDTO = new SalaryDeductionMaster();
                model.SalaryDeductionMasterDTO.ID = ID;
                model.SalaryDeductionMasterDTO.ConnectionString = _connectioString;

                List<SelectListItem> li_DeductionType = new List<SelectListItem>();
                li_DeductionType.Add(new SelectListItem { Text = "Provident Fund", Value = "PF" });
                li_DeductionType.Add(new SelectListItem { Text = "ESIC", Value = "ESIC" });
                li_DeductionType.Add(new SelectListItem { Text = "Professional Tax", Value = "PT" });
                li_DeductionType.Add(new SelectListItem { Text = "LIC", Value = "LIC" });
                li_DeductionType.Add(new SelectListItem { Text = "Loan", Value = "Loan" });
                li_DeductionType.Add(new SelectListItem { Text = "TDS", Value = "TDS" });
                li_DeductionType.Add(new SelectListItem { Text = "Bonus", Value = "BONUS" });
                li_DeductionType.Add(new SelectListItem { Text = "Gratuity", Value = "GRTY" });
                li_DeductionType.Add(new SelectListItem { Text = "MLWF", Value = "MLWF" });
                li_DeductionType.Add(new SelectListItem { Text = "Uniform & Shoes", Value = "UAS" });
                li_DeductionType.Add(new SelectListItem { Text = "Advance Amount", Value = "ADVA" });
                li_DeductionType.Add(new SelectListItem { Text = "Fine", Value = "Fine" });
                li_DeductionType.Add(new SelectListItem { Text = "Food Deduction", Value = "FOODD" });
                li_DeductionType.Add(new SelectListItem { Text = "Leave With Wages", Value = "LWW" });
                li_DeductionType.Add(new SelectListItem { Text = "Other", Value = "Other" });
                ViewBag.DeductionTypeList = new SelectList(li_DeductionType, "Value", "Text");

                List<SelectListItem> li_ComplianceType = new List<SelectListItem>();
                li_ComplianceType.Add(new SelectListItem { Text = "Compliance", Value = "1" });
                li_ComplianceType.Add(new SelectListItem { Text = "Non Compliance", Value = "2" });
                ViewBag.ComplianceTypeList = new SelectList(li_ComplianceType, "Value", "Text");

                IBaseEntityResponse<SalaryDeductionMaster> response = _SalaryDeductionMasterBA.SelectByID(model.SalaryDeductionMasterDTO);
                if (response != null && response.Entity != null)
                {
                    model.SalaryDeductionMasterDTO.ID = response.Entity.ID;
                    model.SalaryDeductionMasterDTO.DeductionHeadName = response.Entity.DeductionHeadName;
                    model.SalaryDeductionMasterDTO.DeductionSubType = response.Entity.DeductionSubType;
                    model.SalaryDeductionMasterDTO.DeductionType = response.Entity.DeductionType;
                    model.SalaryDeductionMasterDTO.ComplianceType = response.Entity.ComplianceType;
                }
                return PartialView("/Views/Salary/SalaryDeductionMaster/Edit.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(SalaryDeductionMasterViewModel model)
        {
            try
            {
                if (model != null && model.SalaryDeductionMasterDTO != null)
                {
                    model.SalaryDeductionMasterDTO.ConnectionString = _connectioString;

                    model.SalaryDeductionMasterDTO.ID = model.ID;
                    model.SalaryDeductionMasterDTO.DeductionHeadName = model.DeductionHeadName;
                    model.SalaryDeductionMasterDTO.DeductionType = model.DeductionType;
                    model.SalaryDeductionMasterDTO.DeductionSubType = model.DeductionSubType;
                    model.SalaryDeductionMasterDTO.ComplianceType = model.ComplianceType;

                    model.SalaryDeductionMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserId"]);

                    IBaseEntityResponse<SalaryDeductionMaster> response = _SalaryDeductionMasterBA.UpdateSalaryDeductionMaster(model.SalaryDeductionMasterDTO);
                    model.SalaryDeductionMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                }
                return Json(model.SalaryDeductionMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }


        [HttpGet]
        public ActionResult EditSalaryDeductionRules(byte ID)
        {
            try
            {
                SalaryDeductionMasterViewModel model = new SalaryDeductionMasterViewModel();

                model.SalaryDeductionMasterDTO = new SalaryDeductionMaster();
                model.SalaryDeductionMasterDTO.SalaryDeductionRulesID = ID;
                model.SalaryDeductionMasterDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<SalaryDeductionMaster> response = _SalaryDeductionMasterBA.SelectBySalaryDeductionRulesID(model.SalaryDeductionMasterDTO);

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

                List<SelectListItem> li_ContributionType = new List<SelectListItem>();
                li_ContributionType.Add(new SelectListItem { Text = "Employee", Value = "1" });
                li_ContributionType.Add(new SelectListItem { Text = "Employer", Value = "2" });
                ViewBag.ContributionTypeList = new SelectList(li_ContributionType, "Value", "Text");

                if (response != null && response.Entity != null)
                {
                    model.SalaryDeductionMasterDTO.ID = response.Entity.ID;
                    model.SalaryDeductionMasterDTO.SalaryDeductionRulesID = response.Entity.SalaryDeductionRulesID;
                    model.SalaryDeductionMasterDTO.IsGenderSpecific = response.Entity.IsGenderSpecific;
                    model.SalaryDeductionMasterDTO.Gender = response.Entity.Gender;
                    model.SalaryDeductionMasterDTO.FixedAmount = response.Entity.FixedAmount;
                    model.SalaryDeductionMasterDTO.Percentage = response.Entity.Percentage;
                    model.SalaryDeductionMasterDTO.CalculateOn = response.Entity.CalculateOn;
                    model.SalaryDeductionMasterDTO.EffectedDate = response.Entity.EffectedDate;
                    model.SalaryDeductionMasterDTO.CloseDate = response.Entity.CloseDate;
                    model.SalaryDeductionMasterDTO.IsCurrent = response.Entity.IsCurrent;
                    model.SalaryDeductionMasterDTO.ContributionType = response.Entity.ContributionType;
                    model.SalaryDeductionMasterDTO.RangeFrom = response.Entity.RangeFrom;
                    model.SalaryDeductionMasterDTO.RangeUpto = response.Entity.RangeUpto;
                    model.SalaryDeductionMasterDTO.CalculateOnFixedAmount = response.Entity.CalculateOnFixedAmount;

                    model.CalculateOnListForRules = GetCalculateOnListForRules(model.SalaryDeductionMasterDTO.SalaryDeductionRulesID);
                }
                return PartialView("/Views/Salary/SalaryDeductionMaster/EditSalaryDeductionRules.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public ActionResult EditSalaryDeductionRules(SalaryDeductionMasterViewModel model)
        {
            try
            {

                if (model != null && model.SalaryDeductionMasterDTO != null)
                {
                    model.SalaryDeductionMasterDTO.ConnectionString = _connectioString;

                    model.SalaryDeductionMasterDTO.ID = model.ID;
                    model.SalaryDeductionMasterDTO.SalaryDeductionRulesID = model.SalaryDeductionRulesID;
                    model.SalaryDeductionMasterDTO.IsGenderSpecific = model.IsGenderSpecific;
                    model.SalaryDeductionMasterDTO.Gender = model.Gender;
                    model.SalaryDeductionMasterDTO.FixedAmount = model.FixedAmount;
                    model.SalaryDeductionMasterDTO.Percentage = model.Percentage;
                    model.SalaryDeductionMasterDTO.CalculateOn = model.CalculateOn;
                    model.SalaryDeductionMasterDTO.EffectedDate = model.EffectedDate;
                    model.SalaryDeductionMasterDTO.CloseDate = model.CloseDate;
                    model.SalaryDeductionMasterDTO.IsCurrent = model.IsCurrent;
                    model.SalaryDeductionMasterDTO.ContributionType = model.ContributionType;
                    model.SalaryDeductionMasterDTO.RangeFrom = model.RangeFrom;
                    model.SalaryDeductionMasterDTO.RangeUpto = model.RangeUpto;
                    model.SalaryDeductionMasterDTO.CalculateOnFixedAmount = model.CalculateOnFixedAmount;
                    model.SalaryDeductionMasterDTO.XMLStringForCalculateOn = model.XMLStringForCalculateOn;

                    model.SalaryDeductionMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserId"]);

                    IBaseEntityResponse<SalaryDeductionMaster> response = _SalaryDeductionMasterBA.UpdateSalaryDeductionRules(model.SalaryDeductionMasterDTO);
                    model.SalaryDeductionMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                }
                return Json(model.SalaryDeductionMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        public ActionResult DeleteSalaryDeductionRules(byte ID)
        {
            try
            {
                SalaryDeductionMasterViewModel model = new SalaryDeductionMasterViewModel();

                if (ID > 0)
                {
                    model.SalaryDeductionMasterDTO = new SalaryDeductionMaster();
                    model.SalaryDeductionMasterDTO.ConnectionString = _connectioString;
                    model.SalaryDeductionMasterDTO.SalaryDeductionRulesID = ID;

                    model.SalaryDeductionMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<SalaryDeductionMaster> response = _SalaryDeductionMasterBA.DeleteSalaryDeductionRules(model.SalaryDeductionMasterDTO);
                    model.SalaryDeductionMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
                }
                return Json(model.SalaryDeductionMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }
        #endregion

        #region Methods

        protected List<SalaryDeductionMaster> GetCalculateOnListForRules(byte SalaryDeductionRulesID)
        {

            SalaryDeductionMasterSearchRequest searchRequest = new SalaryDeductionMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.SalaryDeductionRulesID = SalaryDeductionRulesID;

            List<SalaryDeductionMaster> listSalaryDeductionMaster = new List<SalaryDeductionMaster>();
            IBaseEntityCollectionResponse<SalaryDeductionMaster> baseEntityCollectionResponse = _SalaryDeductionMasterBA.GetCalculateOnListForRules(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listSalaryDeductionMaster = baseEntityCollectionResponse.CollectionResponse.ToList();

                }
            }
            return listSalaryDeductionMaster;
        }

        [NonAction]
        public IEnumerable<SalaryDeductionMasterViewModel> GetSalaryDeductionMaster(out int TotalRecords)
        {
            try
            {
                SalaryDeductionMasterSearchRequest searchRequest = new SalaryDeductionMasterSearchRequest();
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

                List<SalaryDeductionMasterViewModel> listSalaryDeductionMasterViewModel = new List<SalaryDeductionMasterViewModel>();
                List<SalaryDeductionMaster> listSalaryDeductionMaster = new List<SalaryDeductionMaster>();
                IBaseEntityCollectionResponse<SalaryDeductionMaster> baseEntityCollectionResponse = _SalaryDeductionMasterBA.GetBySearch(searchRequest);
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        listSalaryDeductionMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                        foreach (SalaryDeductionMaster item in listSalaryDeductionMaster)
                        {
                            SalaryDeductionMasterViewModel SalaryDeductionMasterViewModel = new SalaryDeductionMasterViewModel();
                            SalaryDeductionMasterViewModel.SalaryDeductionMasterDTO = item;
                            listSalaryDeductionMasterViewModel.Add(SalaryDeductionMasterViewModel);
                        }
                    }
                }
                TotalRecords = baseEntityCollectionResponse.TotalRecords;

                return listSalaryDeductionMasterViewModel;
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
            IEnumerable<SalaryDeductionMasterViewModel> filteredSalaryDeductionMaster;

            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "A.DeductionHeadName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "A.DeductionHeadName Like '%" + param.sSearch + "%' or B.Gender Like '%" + param.sSearch + "%' or B.FixedAmount Like '%" + param.sSearch + "%' or B.Percentage Like '%" + param.sSearch + "%' or B.EffectedDate Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
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
                        _searchBy = "A.DeductionHeadName Like '%" + param.sSearch + "%' or B.Gender Like '%" + param.sSearch + "%' or B.FixedAmount Like '%" + param.sSearch + "%' or B.Percentage Like '%" + param.sSearch + "%' or B.EffectedDate Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
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
                        _searchBy = "A.DeductionHeadName Like '%" + param.sSearch + "%' or B.Gender Like '%" + param.sSearch + "%' or B.FixedAmount Like '%" + param.sSearch + "%' or B.Percentage Like '%" + param.sSearch + "%' or B.EffectedDate Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
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
                        _searchBy = "A.DeductionHeadName Like '%" + param.sSearch + "%' or B.Gender Like '%" + param.sSearch + "%' or B.FixedAmount Like '%" + param.sSearch + "%' or B.Percentage Like '%" + param.sSearch + "%' or B.EffectedDate Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
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
                        _searchBy = "A.DeductionHeadName Like '%" + param.sSearch + "%' or B.Gender Like '%" + param.sSearch + "%' or B.FixedAmount Like '%" + param.sSearch + "%' or B.Percentage Like '%" + param.sSearch + "%' or B.EffectedDate Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 5:
                    _sortBy = "B.ContributionType";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "A.DeductionHeadName Like '%" + param.sSearch + "%' or B.Gender Like '%" + param.sSearch + "%' or B.FixedAmount Like '%" + param.sSearch + "%' or B.Percentage Like '%" + param.sSearch + "%' or B.EffectedDate Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
            }

            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;

            filteredSalaryDeductionMaster = GetSalaryDeductionMaster(out TotalRecords);

            var records = filteredSalaryDeductionMaster.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.ID), Convert.ToString(c.DeductionHeadName), Convert.ToString(c.DeductionType), Convert.ToString(c.SalaryDeductionRulesID), Convert.ToString(c.Gender), Convert.ToString(c.FixedAmount), Convert.ToString(c.Percentage), Convert.ToString(c.EffectedDate), Convert.ToString(c.ContributionType) };
            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);

        }
        #endregion
    }
}


