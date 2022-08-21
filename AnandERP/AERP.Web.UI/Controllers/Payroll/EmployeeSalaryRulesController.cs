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
    public class EmployeeSalaryRulesController : BaseController
    {
        IEmployeeSalaryRulesBA _EmployeeSalaryRulesBA = null;
        IGeneralItemMasterBA _generalItemMasterBA = null;
        ISalaryAllowanceMasterBA _SalaryAllowanceMasterBA = null;
        ISalaryDeductionMasterBA _SalaryDeductionMasterBA = null;
        IEmployeeSalarySpanBA _EmployeeSalarySpanBA = null;

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

        public EmployeeSalaryRulesController()
        {
            _EmployeeSalaryRulesBA = new EmployeeSalaryRulesBA();
            _generalItemMasterBA = new GeneralItemMasterBA();
            _SalaryAllowanceMasterBA = new SalaryAllowanceMasterBA();
            _SalaryDeductionMasterBA = new SalaryDeductionMasterBA();
            _EmployeeSalarySpanBA = new EmployeeSalarySpanBA();
        }

        #region Controller Methods

        /// <summary>
        /// First Load When controller call List Method
        /// </summary>
        /// <returns>view</returns>
        [HttpGet]
        public ActionResult Index()
        {
            bool IsApplied = CheckMenuApplicableOrNot(ControllerContext.RouteData.Values["Controller"].ToString());
            if  (Convert.ToInt32(Session["HR Manager"]) > 0 && IsApplied == true)
            {
                EmployeeSalaryRulesViewModel _EmployeeSalaryRulesViewModel = new EmployeeSalaryRulesViewModel();

                int AdminRoleMasterID = 0;
                if (Session["RoleID"] == null)
                {
                    AdminRoleMasterID = Convert.ToInt32(Session["DefaultRoleID"]);
                }
                else
                {
                    AdminRoleMasterID = Convert.ToInt32(Session["RoleID"]);
                }
                List<AdminRoleApplicableDetails> listAdminRoleApplicableDetails = null;
                if (Convert.ToInt32(Session["HR Manager"]) > 0)
                {
                    listAdminRoleApplicableDetails = GetAdminRoleApplicableCentreByHRManager(AdminRoleMasterID);
                }
                AdminRoleApplicableDetails a = null;
                foreach (var item in listAdminRoleApplicableDetails)
                {
                    a = new AdminRoleApplicableDetails();
                    a.CentreCode = item.CentreCode;
                    a.CentreName = item.CentreName;
                    a.ScopeIdentity = item.ScopeIdentity;
                    _EmployeeSalaryRulesViewModel.ListGetAdminRoleApplicableCentre.Add(a);
                }
                foreach (var b in _EmployeeSalaryRulesViewModel.ListGetAdminRoleApplicableCentre)
                {
                    b.CentreCode = b.CentreCode + ":" + b.ScopeIdentity;
                }

                return View("/Views/Payroll/EmployeeSalaryRules/Index.cshtml", _EmployeeSalaryRulesViewModel);
            }
            else
            {
                return RedirectToAction("UnauthorizedAccess", "Home");
            }
        }

        public ActionResult List(string centerCode, string departmentID, string actionMode)
        {
            try
            {
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Payroll/EmployeeSalaryRules/List.cshtml");

            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpGet]
        public ActionResult Create(string EmployeeMasterID, string EmployeeName)
        {
            EmployeeSalaryRulesViewModel model = new EmployeeSalaryRulesViewModel();
            try
            {
                model.EmployeeMasterID = Convert.ToInt32(EmployeeMasterID);
                model.EmployeeName= EmployeeName;

                List<SelectListItem> li_RuleType = new List<SelectListItem>();
                li_RuleType.Add(new SelectListItem { Text = "Allowance", Value = "Allowance" });
                li_RuleType.Add(new SelectListItem { Text = "Deduction", Value = "Deduction" });
                ViewBag.RuleType = new SelectList(li_RuleType, "Value", "Text");

                return PartialView("/Views/Payroll/EmployeeSalaryRules/Create.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public ActionResult Create(EmployeeSalaryRulesViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.EmployeeSalaryRulesDTO != null)
                    {
                        model.EmployeeSalaryRulesDTO.ConnectionString = _connectioString;

                        model.EmployeeSalaryRulesDTO.EmployeeMasterID = model.EmployeeMasterID;
                        model.EmployeeSalaryRulesDTO.TotalAmount = model.TotalAmount;
                        model.EmployeeSalaryRulesDTO.GrossSalaryAmount = model.GrossSalaryAmount;
                        model.EmployeeSalaryRulesDTO.NetSalaryAmount = model.NetSalaryAmount;
                        model.EmployeeSalaryRulesDTO.BasicSalayAmount = model.BasicSalayAmount;
                        model.EmployeeSalaryRulesDTO.XMLStringManPowerItemRules = model.XMLStringManPowerItemRules;
                        model.EmployeeSalaryRulesDTO.XMLStringForCalculateOn = model.XMLStringForCalculateOn;

                        model.EmployeeSalaryRulesDTO.CreatedBy = Convert.ToInt32(Session["UserId"]);

                        IBaseEntityResponse<EmployeeSalaryRules> response = _EmployeeSalaryRulesBA.InsertEmployeeSalaryRules(model.EmployeeSalaryRulesDTO);
                        model.EmployeeSalaryRulesDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    }
                    return Json(model.EmployeeSalaryRulesDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public ActionResult Edit(string ID, string EmployeeMasterID, string EmployeeName)
        {
            EmployeeSalaryRulesViewModel model = new EmployeeSalaryRulesViewModel();
            try
            {
                model.EmployeeSalaryRulesID = Convert.ToInt64(ID);
                model.EmployeeMasterID = Convert.ToInt32(EmployeeMasterID);
                model.EmployeeName = EmployeeName;

                model.EmployeeSalaryRulesList = GetEmployeeSalaryRulesList(model.EmployeeSalaryRulesID);

                if(model.EmployeeSalaryRulesList.Count > 0)
                {
                    model.EmployeeSalaryRulesDTO.BasicSalayAmount = model.EmployeeSalaryRulesList[0].BasicSalayAmount;
                }

                List<SelectListItem> li_RuleType = new List<SelectListItem>();
                li_RuleType.Add(new SelectListItem { Text = "Allowance", Value = "Allowance" });
                li_RuleType.Add(new SelectListItem { Text = "Deduction", Value = "Deduction" });
                ViewBag.RuleType = new SelectList(li_RuleType, "Value", "Text");

                model.EmployeeSalarySpanList = GetEmployeeSalarySpanList();

                return PartialView("/Views/Payroll/EmployeeSalaryRules/Edit.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(EmployeeSalaryRulesViewModel model)
        {
            try
            {

                if (model != null && model.EmployeeSalaryRulesDTO != null)
                {
                    model.EmployeeSalaryRulesDTO.ConnectionString = _connectioString;

                    model.EmployeeSalaryRulesDTO.EmployeeSalaryRulesID = model.EmployeeSalaryRulesID;
                    model.EmployeeSalaryRulesDTO.TotalAmount = model.TotalAmount;
                    model.EmployeeSalaryRulesDTO.GrossSalaryAmount = model.GrossSalaryAmount;
                    model.EmployeeSalaryRulesDTO.NetSalaryAmount = model.NetSalaryAmount;
                    model.EmployeeSalaryRulesDTO.BasicSalayAmount = model.BasicSalayAmount;
                    model.EmployeeSalaryRulesDTO.FromEmployeeSalarySpanID = model.FromEmployeeSalarySpanID;
                    model.EmployeeSalaryRulesDTO.XMLStringManPowerItemRules = model.XMLStringManPowerItemRules;
                    model.EmployeeSalaryRulesDTO.XMLStringForCalculateOn = model.XMLStringForCalculateOn;

                    model.EmployeeSalaryRulesDTO.CreatedBy = Convert.ToInt32(Session["UserId"]);

                    IBaseEntityResponse<EmployeeSalaryRules> response = _EmployeeSalaryRulesBA.UpdateEmployeeSalaryRules(model.EmployeeSalaryRulesDTO);
                    model.EmployeeSalaryRulesDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                }
                return Json(model.EmployeeSalaryRulesDTO.errorMessage, JsonRequestBehavior.AllowGet);

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
        protected List<EmployeeSalaryRules> GetEmployeeSalaryRulesList(Int64 ID)
        {
            EmployeeSalaryRulesSearchRequest searchRequest = new EmployeeSalaryRulesSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            searchRequest.ID = ID;
            List<EmployeeSalaryRules> listEmployeeSalaryRules = new List<EmployeeSalaryRules>();
            IBaseEntityCollectionResponse<EmployeeSalaryRules> baseEntityCollectionResponse = _EmployeeSalaryRulesBA.GetEmployeeSalaryRules(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listEmployeeSalaryRules = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listEmployeeSalaryRules;
        }

        [NonAction]
        protected List<EmployeeSalarySpan> GetEmployeeSalarySpanList()
        {
            EmployeeSalarySpanSearchRequest searchRequest = new EmployeeSalarySpanSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            
            List<EmployeeSalarySpan> listEmployeeSalaryRules = new List<EmployeeSalarySpan>();
            IBaseEntityCollectionResponse<EmployeeSalarySpan> baseEntityCollectionResponse = _EmployeeSalarySpanBA.GetSalarySpanList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listEmployeeSalaryRules = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listEmployeeSalaryRules;
        }

        [HttpPost]
        public JsonResult GetItemSearchList(string term)
        {
            GeneralItemMasterSearchRequest searchRequest = new GeneralItemMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            searchRequest.SearchWord = term;
            List<GeneralItemMaster> listFeeSubType = new List<GeneralItemMaster>();
            IBaseEntityCollectionResponse<GeneralItemMaster> baseEntityCollectionResponse = _generalItemMasterBA.GetGeneralServiceItemList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listFeeSubType = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            var result = (from r in listFeeSubType
                          select new
                          {
                              ItemNumber = r.ItemNumber,
                              ItemDescription = r.ItemDescription,

                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetHeadNameSearchList(string term, string RuleType)
        {
            if (RuleType == "Allowance")
            {
                SalaryAllowanceMasterSearchRequest searchRequest = new SalaryAllowanceMasterSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

                searchRequest.SearchWord = term;
                List<SalaryAllowanceMaster> listSalaryAllowanceMaster = new List<SalaryAllowanceMaster>();
                IBaseEntityCollectionResponse<SalaryAllowanceMaster> baseEntityCollectionResponse = _SalaryAllowanceMasterBA.GetBySearchList(searchRequest);
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        listSalaryAllowanceMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    }
                }
                var result = (from r in listSalaryAllowanceMaster
                              select new
                              {
                                  HeadID = r.ID,
                                  HeadName = r.AllowanceHeadName,
                                  HeadType = r.AllowanceType,

                              }).ToList();
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                SalaryDeductionMasterSearchRequest searchRequest = new SalaryDeductionMasterSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

                searchRequest.SearchWord = term;
                List<SalaryDeductionMaster> listSalaryDeductionMaster = new List<SalaryDeductionMaster>();
                IBaseEntityCollectionResponse<SalaryDeductionMaster> baseEntityCollectionResponse = _SalaryDeductionMasterBA.GetBySearchList(searchRequest);
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        listSalaryDeductionMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    }
                }
                var result = (from r in listSalaryDeductionMaster
                              select new
                              {
                                  HeadID = r.ID,
                                  HeadName = r.DeductionHeadName,
                                  HeadType = r.DeductionType,
                              }).ToList();
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult GetHeadNameRulesSearchList(string HeadID, string RuleType)
        {
            if (RuleType == "Allowance")
            {
                SalaryAllowanceMasterSearchRequest searchRequest = new SalaryAllowanceMasterSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

                searchRequest.ID = Convert.ToByte(HeadID);
                List<SalaryAllowanceMaster> listSalaryAllowanceMaster = new List<SalaryAllowanceMaster>();
                IBaseEntityCollectionResponse<SalaryAllowanceMaster> baseEntityCollectionResponse = _SalaryAllowanceMasterBA.GetAllowanceRulesByAllowanceMaster(searchRequest);
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        listSalaryAllowanceMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    }
                }
                var result = (from r in listSalaryAllowanceMaster
                              select new
                              {
                                  HeadID = r.ID,
                                  RuleID = r.SalaryAllowanceRulesID,
                                  HeadName = r.AllowanceHeadName,
                                  FixedAmount = r.FixedAmount,
                                  Percentage = r.Percentage,
                                  CalculateOn = r.CalculateOn,
                                  IsGenderSpecific = r.IsGenderSpecific,
                                  Gender = r.Gender,
                                  EffectedDate = r.EffectedDate,
                                  RangeFrom = r.RangeFrom,
                                  RangeUpto = r.RangeUpto,
                                  CalculateOnFixedAmount = r.CalculateOnFixedAmount
                              }).ToList();
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                SalaryDeductionMasterSearchRequest searchRequest = new SalaryDeductionMasterSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

                searchRequest.ID = Convert.ToByte(HeadID);
                List<SalaryDeductionMaster> listSalaryDeductionMaster = new List<SalaryDeductionMaster>();
                IBaseEntityCollectionResponse<SalaryDeductionMaster> baseEntityCollectionResponse = _SalaryDeductionMasterBA.GetDeductionRulesByDeductionMaster(searchRequest);
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        listSalaryDeductionMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    }
                }
                var result = (from r in listSalaryDeductionMaster
                              select new
                              {
                                  HeadID = r.ID,
                                  RuleID = r.SalaryDeductionRulesID,
                                  HeadName = r.DeductionHeadName,
                                  FixedAmount = r.FixedAmount,
                                  Percentage = r.Percentage,
                                  CalculateOn = r.CalculateOn,
                                  IsGenderSpecific = r.IsGenderSpecific,
                                  Gender = r.Gender,
                                  EffectedDate = r.EffectedDate,
                                  RangeFrom = r.RangeFrom,
                                  RangeUpto = r.RangeUpto,
                                  CalculateOnFixedAmount = r.CalculateOnFixedAmount,
                                  ContributionType = r.ContributionType,
                              }).ToList();
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult GetRulesCalculateOnSearchList(string RuleID, string RuleType)
        {
            if (RuleType == "Allowance")
            {
                SalaryAllowanceMasterSearchRequest searchRequest = new SalaryAllowanceMasterSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

                searchRequest.SalaryAllowanceRulesID = Convert.ToByte(RuleID);
                List<SalaryAllowanceMaster> listSalaryAllowanceMaster = new List<SalaryAllowanceMaster>();
                IBaseEntityCollectionResponse<SalaryAllowanceMaster> baseEntityCollectionResponse = _SalaryAllowanceMasterBA.GetCalculateOnListForRules(searchRequest);
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        listSalaryAllowanceMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    }
                }
                var result = (from r in listSalaryAllowanceMaster
                              select new
                              {
                                  ReferenceID = r.ReferenceID,
                                  CalculateOnName = r.CalculateOnName,
                                  AllowanceOrDeduction = r.AllowanceOrDeduction,
                                  SelectedStatusFlag = r.SelectedStatusFlag,
                                  SalarySumOfID = r.SalaryAllowanceSumOfID,
                              }).ToList();
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                SalaryDeductionMasterSearchRequest searchRequest = new SalaryDeductionMasterSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

                searchRequest.SalaryDeductionRulesID = Convert.ToByte(RuleID);
                List<SalaryDeductionMaster> listSalaryDeductionMaster = new List<SalaryDeductionMaster>();
                IBaseEntityCollectionResponse<SalaryDeductionMaster> baseEntityCollectionResponse = _SalaryDeductionMasterBA.GetCalculateOnListForRules(searchRequest);
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        listSalaryDeductionMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    }
                }
                var result = (from r in listSalaryDeductionMaster
                              select new
                              {
                                  ReferenceID = r.ReferenceID,
                                  CalculateOnName = r.CalculateOnName,
                                  AllowanceOrDeduction = r.AllowanceOrDeduction,
                                  SelectedStatusFlag = r.SelectedStatusFlag,
                                  SalarySumOfID = r.SalaryDeductionSumOfID,
                              }).ToList();
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult GetEmployeeSalaryRulesSearchList(string term, string CustomerMasterID, string CustomerBranchMasterID)
        {
            EmployeeSalaryRulesSearchRequest searchRequest = new EmployeeSalaryRulesSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            searchRequest.SearchWord = term;
            searchRequest.CustomerMasterID = !string.IsNullOrEmpty(CustomerMasterID) ? Convert.ToInt32(CustomerMasterID) : 0;
            searchRequest.CustomerBranchMasterID = !string.IsNullOrEmpty(CustomerBranchMasterID) ? Convert.ToInt32(CustomerBranchMasterID) : 0;
            List<EmployeeSalaryRules> listFeeSubType = new List<EmployeeSalaryRules>();
            IBaseEntityCollectionResponse<EmployeeSalaryRules> baseEntityCollectionResponse = _EmployeeSalaryRulesBA.GetEmployeeSalaryRulesBySearchWord(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listFeeSubType = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            var result = (from r in listFeeSubType
                          select new
                          {
                              EmployeeSalaryRulesID = r.ID,
                              EmployeeSalaryRulesName = r.DesignationMasterName,
                              TotalAmount = r.TotalAmount,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetEmployeeSalaryRulesAllowancesSearchList(string term, string CustomerMasterID, string CustomerBranchMasterID)
        {
            EmployeeSalaryRulesSearchRequest searchRequest = new EmployeeSalaryRulesSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            searchRequest.SearchWord = term;
            searchRequest.CustomerMasterID = !string.IsNullOrEmpty(CustomerMasterID) ? Convert.ToInt32(CustomerMasterID) : 0;
            searchRequest.CustomerBranchMasterID = !string.IsNullOrEmpty(CustomerBranchMasterID) ? Convert.ToInt32(CustomerBranchMasterID) : 0;
            List<EmployeeSalaryRules> listFeeSubType = new List<EmployeeSalaryRules>();
            IBaseEntityCollectionResponse<EmployeeSalaryRules> baseEntityCollectionResponse = _EmployeeSalaryRulesBA.GetEmployeeSalaryRulesAllowancesBySearchWord(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listFeeSubType = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            var result = (from r in listFeeSubType
                          select new
                          {
                              SalaryAllowanceMasterID = r.HeadID,
                              SalaryAllowanceMasterName = r.HeadName,
                              BasicOrAllowance = r.AllowanceOrDeduction,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [NonAction]
        public IEnumerable<EmployeeSalaryRulesViewModel> GetEmployeeSalaryRules(out int TotalRecords, string CenterCode, string DepartmentMasterID)
        {
            try
            {
                EmployeeSalaryRulesSearchRequest searchRequest = new EmployeeSalaryRulesSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
                searchRequest.CenterCode = CenterCode;
                searchRequest.DepartmentMasterID = Convert.ToInt32(DepartmentMasterID);
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
                    searchRequest.SortBy = _sortBy;                     // parameters for SelectAll procedures under normal condition(Procedure Name : USP_AdminPostApplicableToRole_SelectAll)
                    searchRequest.StartRow = _startRow;
                    searchRequest.EndRow = _startRow + _rowLength;
                    searchRequest.SearchBy = _searchBy;
                    searchRequest.SortDirection = _sortDirection;
                }

                List<EmployeeSalaryRulesViewModel> listEmployeeSalaryRulesViewModel = new List<EmployeeSalaryRulesViewModel>();
                List<EmployeeSalaryRules> listEmployeeSalaryRules = new List<EmployeeSalaryRules>();
                IBaseEntityCollectionResponse<EmployeeSalaryRules> baseEntityCollectionResponse = _EmployeeSalaryRulesBA.GetBySearch(searchRequest);
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        listEmployeeSalaryRules = baseEntityCollectionResponse.CollectionResponse.ToList();
                        foreach (EmployeeSalaryRules item in listEmployeeSalaryRules)
                        {
                            EmployeeSalaryRulesViewModel EmployeeSalaryRulesViewModel = new EmployeeSalaryRulesViewModel();
                            EmployeeSalaryRulesViewModel.EmployeeSalaryRulesDTO = item;
                            listEmployeeSalaryRulesViewModel.Add(EmployeeSalaryRulesViewModel);
                        }
                    }
                }
                TotalRecords = baseEntityCollectionResponse.TotalRecords;

                return listEmployeeSalaryRulesViewModel;
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }
        #endregion

        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param, string SelectedCentreCode, string SelectedDepartmentID)
        {
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc
            int TotalRecords;
            IEnumerable<EmployeeSalaryRulesViewModel> filteredEmployeeSalaryRules;

            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "EmployeeName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "EmployeeName Like '%" + param.sSearch + "%' or EmployeeCode Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "EmployeeCode";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "EmployeeName Like '%" + param.sSearch + "%' or EmployeeCode Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 2:
                    _sortBy = "BasicSalayAmount";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "EmployeeName Like '%" + param.sSearch + "%' or EmployeeCode Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 3:
                    _sortBy = "NetSalaryAmount";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "EmployeeName Like '%" + param.sSearch + "%' or EmployeeCode Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 4:
                    _sortBy = "TotalAmount";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "EmployeeName Like '%" + param.sSearch + "%' or EmployeeCode Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;

            }

            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;

            string[] splitCentreCode = SelectedCentreCode.Split(':');
            var centreCode = splitCentreCode[0];

            filteredEmployeeSalaryRules = GetEmployeeSalaryRules(out TotalRecords, centreCode, SelectedDepartmentID);

            var records = filteredEmployeeSalaryRules.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.EmployeeSalaryRulesID), Convert.ToString(c.EmployeeMasterID), Convert.ToString(c.EmployeeName), Convert.ToString(c.EmployeeCode), Convert.ToString(c.BasicSalayAmount), Convert.ToString(c.NetSalaryAmount), Convert.ToString(c.TotalAmount) };
            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);

        }
        #endregion
    }
}


