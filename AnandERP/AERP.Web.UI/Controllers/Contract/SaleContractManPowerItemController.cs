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
    public class SaleContractManPowerItemController : BaseController
    {
        ISaleContractManPowerItemBA _SaleContractManPowerItemBA = null;
        IGeneralItemMasterBA _generalItemMasterBA = null;
        ISalaryAllowanceMasterBA _SalaryAllowanceMasterBA = null;
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

        public SaleContractManPowerItemController()
        {
            _SaleContractManPowerItemBA = new SaleContractManPowerItemBA();
            _generalItemMasterBA = new GeneralItemMasterBA();
            _SalaryAllowanceMasterBA = new SalaryAllowanceMasterBA();
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
            bool IsApplied = CheckMenuApplicableOrNot(ControllerContext.RouteData.Values["Controller"].ToString());
            if (Convert.ToString(Session["UserType"]) == "A" || ((Convert.ToInt32(Session["Sales Manager"]) > 0 || Convert.ToInt32(Session["Admin Manager"]) > 0 || Convert.ToInt32(Session["HR Manager"]) > 0) && IsApplied == true))
            {
                SaleContractManPowerItemViewModel _SaleContractManPowerItemViewModel = new SaleContractManPowerItemViewModel();

                return View("/Views/Contract/SaleContractManPowerItem/Index.cshtml", _SaleContractManPowerItemViewModel);
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
                return PartialView("/Views/Contract/SaleContractManPowerItem/List.cshtml");

            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpGet]
        public ActionResult Create(string CustomerID, string CustomerName, string CustomerBranchID, string CustomerBranchName)
        {
            SaleContractManPowerItemViewModel model = new SaleContractManPowerItemViewModel();
            try
            {
                model.CustomerMasterID = Convert.ToInt32(CustomerID);
                model.CustomerMasterName = CustomerName;
                model.CustomerBranchMasterID = Convert.ToInt32(CustomerBranchID);
                model.CustomerBranchMasterName = CustomerBranchName;

                return PartialView("/Views/Contract/SaleContractManPowerItem/Create.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public ActionResult Create(SaleContractManPowerItemViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.SaleContractManPowerItemDTO != null)
                    {
                        model.SaleContractManPowerItemDTO.ConnectionString = _connectioString;

                        model.SaleContractManPowerItemDTO.ItemNumber = model.ItemNumber;
                        model.SaleContractManPowerItemDTO.DesignationMasterID = model.DesignationMasterID;
                        model.SaleContractManPowerItemDTO.BasicSalayAmount = model.BasicSalayAmount;
                        model.SaleContractManPowerItemDTO.TotalAmount = model.TotalAmount;
                        model.SaleContractManPowerItemDTO.CustomerBranchMasterID = model.CustomerBranchMasterID;
                        model.SaleContractManPowerItemDTO.CustomerMasterID = model.CustomerMasterID;
                        model.SaleContractManPowerItemDTO.FixedSalaryAmount = model.FixedSalaryAmount;
                        model.SaleContractManPowerItemDTO.BillingDisplayName = model.BillingDisplayName;

                        int AdminRoleID = 0;
                        if (Session["RoleID"] == null)
                        {
                            AdminRoleID = !string.IsNullOrEmpty(Convert.ToString(Session["DefaultRoleID"])) ? Convert.ToInt32(Session["DefaultRoleID"]) : 0;
                        }

                        else
                        {
                            AdminRoleID = !string.IsNullOrEmpty(Convert.ToString(Session["RoleID"])) ? Convert.ToInt32(Session["RoleID"]) : 0;
                        }

                        model.SaleContractManPowerItemDTO.CreatedBy = Convert.ToInt32(Session["UserId"]);
                        model.SaleContractManPowerItemDTO.AdminRoleID = AdminRoleID;

                        IBaseEntityResponse<SaleContractManPowerItem> response = _SaleContractManPowerItemBA.InsertSaleContractManPowerItem(model.SaleContractManPowerItemDTO);
                        if (response.Entity.ErrorCode == 15)
                        {
                            string[] arrayList = { "Un Authorized Access!", "warning", string.Empty };
                            model.SaleContractManPowerItemDTO.errorMessage = string.Join(",", arrayList);
                        }
                        else
                        {
                            model.SaleContractManPowerItemDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                        }
                    }
                    return Json(model.SaleContractManPowerItemDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public ActionResult CreateManPowerItemRules(string ID, string BasicAmount, string CustomerMasterName, string CustomerBranchMasterName, string ManPowerItemName)
        {
            SaleContractManPowerItemViewModel model = new SaleContractManPowerItemViewModel();
            try
            {
                model.ID = Convert.ToInt32(ID);
                model.BasicSalayAmount = Convert.ToDecimal(BasicAmount);
                model.CustomerMasterName = CustomerMasterName;
                model.CustomerBranchMasterName = CustomerBranchMasterName;
                model.DesignationMasterName = ManPowerItemName;

                List<SelectListItem> li_RuleType = new List<SelectListItem>();
                li_RuleType.Add(new SelectListItem { Text = "Allowance", Value = "Allowance" });
                li_RuleType.Add(new SelectListItem { Text = "Deduction", Value = "Deduction" });
                ViewBag.RuleType = new SelectList(li_RuleType, "Value", "Text");

                return PartialView("/Views/Contract/SaleContractManPowerItem/CreateManPowerItemRules.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public ActionResult CreateManPowerItemRules(SaleContractManPowerItemViewModel model)
        {
            try
            {

                if (model != null && model.SaleContractManPowerItemDTO != null)
                {
                    model.SaleContractManPowerItemDTO.ConnectionString = _connectioString;

                    model.SaleContractManPowerItemDTO.ID = model.ID;
                    model.SaleContractManPowerItemDTO.TotalAmount = model.TotalAmount;
                    model.SaleContractManPowerItemDTO.GrossSalaryAmount = model.GrossSalaryAmount;
                    model.SaleContractManPowerItemDTO.NetSalaryAmount = model.NetSalaryAmount;
                    model.SaleContractManPowerItemDTO.XMLStringManPowerItemRules = model.XMLStringManPowerItemRules;
                    model.SaleContractManPowerItemDTO.XMLStringForCalculateOn = model.XMLStringForCalculateOn;

                    model.SaleContractManPowerItemDTO.CreatedBy = Convert.ToInt32(Session["UserId"]);

                    IBaseEntityResponse<SaleContractManPowerItem> response = _SaleContractManPowerItemBA.InsertSaleContractManPowerItemRules(model.SaleContractManPowerItemDTO);
                    model.SaleContractManPowerItemDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                }
                return Json(model.SaleContractManPowerItemDTO.errorMessage, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpGet]
        public ActionResult ViewManPowerItemRules(string RuleID, string RuleType)
        {
            SaleContractManPowerItemViewModel model = new SaleContractManPowerItemViewModel();
            try
            {
                model.SaleContractManPowerItemDTO = new SaleContractManPowerItem();
                model.SaleContractManPowerItemDTO.ConnectionString = _connectioString;

                model.SaleContractManPowerItemDTO.RuleID = Convert.ToInt32(RuleID);
                model.SaleContractManPowerItemDTO.RuleType = RuleType;

                IBaseEntityResponse<SaleContractManPowerItem> response = _SaleContractManPowerItemBA.ViewSaleContractManPowerItemRules(model.SaleContractManPowerItemDTO);

                if (response != null && response.Entity != null)
                {
                    model.RuleType = response.Entity.RuleType;
                    model.HeadName = response.Entity.HeadName;
                    model.FixedAmount = response.Entity.FixedAmount;
                    model.Percentage = response.Entity.Percentage;
                    model.CalculateOn = response.Entity.CalculateOn;
                    model.IsGenderSpecific = response.Entity.IsGenderSpecific;
                    model.Gender = response.Entity.Gender;
                    model.RangeFrom = response.Entity.RangeFrom;
                    model.RangeUpto = response.Entity.RangeUpto;
                    model.ContributionType = response.Entity.ContributionType;
                    model.CalculateOnString = response.Entity.CalculateOnString;
                    model.CalculateOnFixedAmount = response.Entity.CalculateOnFixedAmount;
                }

                return PartialView("/Views/Contract/SaleContractManPowerItem/ViewManPowerItemRules.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        public ActionResult DeleteManPowerItemRules(string ID)
        {
            var errorMessage = string.Empty;
            if (ID != null && Convert.ToString(Session["UserType"]) == "A" || Convert.ToInt32(Session["Admin Manager"]) > 0)
            {
                SaleContractManPowerItemViewModel model = new SaleContractManPowerItemViewModel();
                model.SaleContractManPowerItemDTO = new SaleContractManPowerItem();
                model.SaleContractManPowerItemDTO.ConnectionString = _connectioString;
                model.SaleContractManPowerItemDTO.ID = Convert.ToInt32(ID);
                model.SaleContractManPowerItemDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                IBaseEntityResponse<SaleContractManPowerItem> response = _SaleContractManPowerItemBA.DeleteSaleContractManPowerItemRules(model.SaleContractManPowerItemDTO);
                model.SaleContractManPowerItemDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
            }
            return Json(errorMessage, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult EditManPowerItemRules(string ID, string BasicAmount, string CustomerMasterName, string CustomerBranchMasterName, string ManPowerItemName)
        {
            SaleContractManPowerItemViewModel model = new SaleContractManPowerItemViewModel();
            try
            {
                model.ID = Convert.ToInt32(ID);
                model.BasicSalayAmount = Convert.ToDecimal(BasicAmount);
                model.CustomerMasterName = CustomerMasterName;
                model.CustomerBranchMasterName = CustomerBranchMasterName;
                model.DesignationMasterName = ManPowerItemName;

                model.SaleContractManPowerItemList = GetSaleContractManPowerItemRulesList(model.ID);

                if(model.SaleContractManPowerItemList.Count > 0)
                {
                    model.SaleContractManPowerItemDTO.BasicSalayAmount = model.SaleContractManPowerItemList[0].BasicSalayAmount;
                    model.SaleContractManPowerItemDTO.FixedSalaryAmount = model.SaleContractManPowerItemList[0].FixedSalaryAmount;
                }

                List<SelectListItem> li_RuleType = new List<SelectListItem>();
                li_RuleType.Add(new SelectListItem { Text = "Allowance", Value = "Allowance" });
                li_RuleType.Add(new SelectListItem { Text = "Deduction", Value = "Deduction" });
                ViewBag.RuleType = new SelectList(li_RuleType, "Value", "Text");

                return PartialView("/Views/Contract/SaleContractManPowerItem/EditManPowerItemRules.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public ActionResult EditManPowerItemRules(SaleContractManPowerItemViewModel model)
        {
            try
            {

                if (model != null && model.SaleContractManPowerItemDTO != null)
                {
                    model.SaleContractManPowerItemDTO.ConnectionString = _connectioString;

                    model.SaleContractManPowerItemDTO.ID = model.ID;
                    model.SaleContractManPowerItemDTO.TotalAmount = model.TotalAmount;
                    model.SaleContractManPowerItemDTO.GrossSalaryAmount = model.GrossSalaryAmount;
                    model.SaleContractManPowerItemDTO.NetSalaryAmount = model.NetSalaryAmount;
                    model.SaleContractManPowerItemDTO.BasicSalayAmount = model.BasicSalayAmount;
                    model.SaleContractManPowerItemDTO.FixedSalaryAmount = model.FixedSalaryAmount;
                    model.SaleContractManPowerItemDTO.GenerateSeperateInvoice = model.GenerateSeperateInvoice;
                    model.SaleContractManPowerItemDTO.WithEffectiveFromDate = model.WithEffectiveFromDate;
                    model.SaleContractManPowerItemDTO.WithEffectiveUptoDate = model.WithEffectiveUptoDate;
                    model.SaleContractManPowerItemDTO.CalculateArrears = model.CalculateArrears;
                    model.SaleContractManPowerItemDTO.XMLStringManPowerItemRules = model.XMLStringManPowerItemRules;
                    model.SaleContractManPowerItemDTO.XMLStringForCalculateOn = model.XMLStringForCalculateOn;

                    model.SaleContractManPowerItemDTO.CreatedBy = Convert.ToInt32(Session["UserId"]);

                    IBaseEntityResponse<SaleContractManPowerItem> response = _SaleContractManPowerItemBA.UpdateSaleContractManPowerItemRules(model.SaleContractManPowerItemDTO);
                    model.SaleContractManPowerItemDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                }
                return Json(model.SaleContractManPowerItemDTO.errorMessage, JsonRequestBehavior.AllowGet);

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
        protected List<SaleContractManPowerItem> GetSaleContractManPowerItemRulesList(Int32 ID)
        {
            SaleContractManPowerItemSearchRequest searchRequest = new SaleContractManPowerItemSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            searchRequest.ID = ID;
            List<SaleContractManPowerItem> listSaleContractManPowerItem = new List<SaleContractManPowerItem>();
            IBaseEntityCollectionResponse<SaleContractManPowerItem> baseEntityCollectionResponse = _SaleContractManPowerItemBA.GetSaleContractManPowerItemRules(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listSaleContractManPowerItem = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listSaleContractManPowerItem;
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
                                  CalculateOnFixedAmount = r.CalculateOnFixedAmount,
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
                                  ContributionType = r.ContributionType,
                                  CalculateOnFixedAmount = r.CalculateOnFixedAmount,
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
        public JsonResult GetSaleContractManPowerItemSearchList(string term, string CustomerMasterID, string CustomerBranchMasterID)
        {
            SaleContractManPowerItemSearchRequest searchRequest = new SaleContractManPowerItemSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            searchRequest.SearchWord = term;
            searchRequest.CustomerMasterID = !string.IsNullOrEmpty(CustomerMasterID) ? Convert.ToInt32(CustomerMasterID) : 0;
            searchRequest.CustomerBranchMasterID = !string.IsNullOrEmpty(CustomerBranchMasterID) ? Convert.ToInt32(CustomerBranchMasterID) : 0;
            List<SaleContractManPowerItem> listFeeSubType = new List<SaleContractManPowerItem>();
            IBaseEntityCollectionResponse<SaleContractManPowerItem> baseEntityCollectionResponse = _SaleContractManPowerItemBA.GetSaleContractManPowerItemBySearchWord(searchRequest);
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
                              SaleContractManPowerItemID = r.ID,
                              SaleContractManPowerItemName = r.DesignationMasterName,
                              TotalAmount = r.TotalAmount,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetSaleContractManPowerItemAllowancesSearchList(string term, string CustomerMasterID, string CustomerBranchMasterID)
        {
            SaleContractManPowerItemSearchRequest searchRequest = new SaleContractManPowerItemSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            searchRequest.SearchWord = term;
            searchRequest.CustomerMasterID = !string.IsNullOrEmpty(CustomerMasterID) ? Convert.ToInt32(CustomerMasterID) : 0;
            searchRequest.CustomerBranchMasterID = !string.IsNullOrEmpty(CustomerBranchMasterID) ? Convert.ToInt32(CustomerBranchMasterID) : 0;
            List<SaleContractManPowerItem> listFeeSubType = new List<SaleContractManPowerItem>();
            IBaseEntityCollectionResponse<SaleContractManPowerItem> baseEntityCollectionResponse = _SaleContractManPowerItemBA.GetSaleContractManPowerItemAllowancesBySearchWord(searchRequest);
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
        public IEnumerable<SaleContractManPowerItemViewModel> GetSaleContractManPowerItem(out int TotalRecords, string CustomerMasterID, string CustomerBranchMasterID)
        {
            try
            {
                SaleContractManPowerItemSearchRequest searchRequest = new SaleContractManPowerItemSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

                int AdminRoleID = 0;
                if (Session["RoleID"] == null)
                {
                    AdminRoleID = !string.IsNullOrEmpty(Convert.ToString(Session["DefaultRoleID"])) ? Convert.ToInt32(Session["DefaultRoleID"]) : 0;
                }

                else
                {
                    AdminRoleID = !string.IsNullOrEmpty(Convert.ToString(Session["RoleID"])) ? Convert.ToInt32(Session["RoleID"]) : 0;
                }

                searchRequest.CustomerMasterID = Convert.ToInt32(CustomerMasterID);
                searchRequest.AdminRoleID = Convert.ToInt32(AdminRoleID); 
                searchRequest.CustomerBranchMasterID = Convert.ToInt32(CustomerBranchMasterID);
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

                List<SaleContractManPowerItemViewModel> listSaleContractManPowerItemViewModel = new List<SaleContractManPowerItemViewModel>();
                List<SaleContractManPowerItem> listSaleContractManPowerItem = new List<SaleContractManPowerItem>();
                IBaseEntityCollectionResponse<SaleContractManPowerItem> baseEntityCollectionResponse = _SaleContractManPowerItemBA.GetBySearch(searchRequest);
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        listSaleContractManPowerItem = baseEntityCollectionResponse.CollectionResponse.ToList();
                        foreach (SaleContractManPowerItem item in listSaleContractManPowerItem)
                        {
                            SaleContractManPowerItemViewModel SaleContractManPowerItemViewModel = new SaleContractManPowerItemViewModel();
                            SaleContractManPowerItemViewModel.SaleContractManPowerItemDTO = item;
                            listSaleContractManPowerItemViewModel.Add(SaleContractManPowerItemViewModel);
                        }
                    }
                }
                TotalRecords = baseEntityCollectionResponse.TotalRecords;

                return listSaleContractManPowerItemViewModel;
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }
        #endregion

        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param, string CustomerMasterID, string CustomerBranchMasterID)
        {
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc
            int TotalRecords;
            IEnumerable<SaleContractManPowerItemViewModel> filteredSaleContractManPowerItem;

            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "CustomerMasterName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "CustomerMasterName Like '%" + param.sSearch + "%' or ItemDescription Like '%" + param.sSearch + "%' or DesignationMasterName Like '%" + param.sSearch + "%' or BasicSalayAmount Like '%" + param.sSearch + "%' or TotalAmount Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "ItemDescription";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "CustomerMasterName Like '%" + param.sSearch + "%' or ItemDescription Like '%" + param.sSearch + "%' or DesignationMasterName Like '%" + param.sSearch + "%' or BasicSalayAmount Like '%" + param.sSearch + "%' or TotalAmount Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 2:
                    _sortBy = "DesignationMasterName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "CustomerMasterName Like '%" + param.sSearch + "%' or ItemDescription Like '%" + param.sSearch + "%' or DesignationMasterName Like '%" + param.sSearch + "%' or BasicSalayAmount Like '%" + param.sSearch + "%' or TotalAmount Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 3:
                    _sortBy = "BasicSalayAmount";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "CustomerMasterName Like '%" + param.sSearch + "%' or ItemDescription Like '%" + param.sSearch + "%' or DesignationMasterName Like '%" + param.sSearch + "%' or BasicSalayAmount Like '%" + param.sSearch + "%' or TotalAmount Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
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
                        _searchBy = "CustomerMasterName Like '%" + param.sSearch + "%' or ItemDescription Like '%" + param.sSearch + "%' or DesignationMasterName Like '%" + param.sSearch + "%' or BasicSalayAmount Like '%" + param.sSearch + "%' or TotalAmount Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
            }

            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;

            filteredSaleContractManPowerItem = GetSaleContractManPowerItem(out TotalRecords, CustomerMasterID, CustomerBranchMasterID);

            var records = filteredSaleContractManPowerItem.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.ID), Convert.ToString(c.CustomerMasterName + " " + c.CustomerBranchMasterName).Trim().Replace(",", "#"), Convert.ToString(c.ItemDescription), Convert.ToString(c.DesignationMasterName), Convert.ToString(c.BasicSalayAmount), Convert.ToString(c.TotalAmount), Convert.ToString(c.CustomerMasterID), Convert.ToString(c.CustomerBranchMasterID), Convert.ToString(c.RuleID), Convert.ToString(c.RuleType), Convert.ToString(c.FixedAmount), Convert.ToString(c.Percentage), Convert.ToString(c.HeadName), Convert.ToString(c.CustomerMasterName).Trim().Replace(",", "#"), Convert.ToString(c.CustomerBranchMasterName).Trim().Replace(",", "#"), Convert.ToString(c.GrossSalaryAmount), Convert.ToString(c.NetSalaryAmount), Convert.ToString(c.IsApplied) };
            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);

        }
        #endregion
    }
}


