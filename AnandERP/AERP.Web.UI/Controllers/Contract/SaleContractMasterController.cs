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
    public class SaleContractMasterController : BaseController
    {
        ISaleContractMasterBA _SaleContractMasterBA = null;
        IGeneralItemMasterBA _GeneralItemMasterBA = null;
        IEmpEmployeeMasterBA _empEmployeeMasterBA = null;

        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public SaleContractMasterController()
        {
            _SaleContractMasterBA = new SaleContractMasterBA();
            _GeneralItemMasterBA = new GeneralItemMasterBA();
            _empEmployeeMasterBA = new EmpEmployeeMasterBA();
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
            if (Convert.ToString(Session["UserType"]) == "A" || (Convert.ToInt32(Session["Admin Manager"]) > 0 && IsApplied == true))
            {
                SaleContractMasterViewModel _SaleContractMasterViewModel = new SaleContractMasterViewModel();

                return View("/Views/Contract/SaleContractMaster/Index.cshtml", _SaleContractMasterViewModel);
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
                return PartialView("/Views/Contract/SaleContractMaster/List.cshtml");

            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpGet]
        public ActionResult SaleContractDetails()
        {
            if (Convert.ToString(Session["UserType"]) == "A" || Convert.ToInt32(Session["Sales Manager"]) > 0)
            {
                SaleContractMasterViewModel _SaleContractMasterViewModel = new SaleContractMasterViewModel();

                return View("/Views/Contract/SaleContractMaster/SaleContractDetails.cshtml", _SaleContractMasterViewModel);
            }
            else
            {
                return RedirectToAction("UnauthorizedAccess", "Home");
            }
        }

        public ActionResult SaleContractDetailsHome(string actionMode, string SaleContractMasterID, string ContractNumber)
        {
            try
            {
                SaleContractMasterViewModel _SaleContractMasterViewModel = new SaleContractMasterViewModel();
                _SaleContractMasterViewModel.ID = Convert.ToInt64(!string.IsNullOrEmpty(SaleContractMasterID) ? SaleContractMasterID : null);
                _SaleContractMasterViewModel.ContractNumber = ContractNumber;
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Contract/SaleContractMaster/SaleContractDetailsHome.cshtml", _SaleContractMasterViewModel);

            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        public ActionResult CreateGeneralContractDetails(string TaskCode, string SaleContractMasterID)
        {
            SaleContractMasterViewModel model = new SaleContractMasterViewModel();
            model.TaskCode = TaskCode;
            model.ID = Convert.ToInt64(!string.IsNullOrEmpty(SaleContractMasterID) ? SaleContractMasterID : null);
            model.SaleContractMasterDTO.ConnectionString = _connectionString;

            List<SelectListItem> li_BillingType = new List<SelectListItem>();
            li_BillingType.Add(new SelectListItem { Text = "Rate Contract", Value = "1" });
            li_BillingType.Add(new SelectListItem { Text = "Fixed Amount", Value = "2" });
            li_BillingType.Add(new SelectListItem { Text = "Job Work Item", Value = "3" });
            ViewBag.BillingTypeList = new SelectList(li_BillingType, "Value", "Text");

            List<SelectListItem> li_FixedBillingType = new List<SelectListItem>();
            li_FixedBillingType.Add(new SelectListItem { Text = "Billing For 1 Item", Value = "1" });
            li_FixedBillingType.Add(new SelectListItem { Text = "Billing Month Wise", Value = "2" });
            li_FixedBillingType.Add(new SelectListItem { Text = "Billing Person Wise", Value = "3" });
            li_FixedBillingType.Add(new SelectListItem { Text = "Billing On Summary", Value = "4" });
            ViewBag.FixedBillingTypeList = new SelectList(li_FixedBillingType, "Value", "Text");

            List<SelectListItem> li_ShortExtraPostingRateAccTo = new List<SelectListItem>();
            li_ShortExtraPostingRateAccTo.Add(new SelectListItem { Text = "Total CTC", Value = "1" });
            li_ShortExtraPostingRateAccTo.Add(new SelectListItem { Text = "Fixed Rate", Value = "2" });
            ViewBag.ShortExtraPostingRateAccToList = new SelectList(li_ShortExtraPostingRateAccTo, "Value", "Text");

            int AdminRoleMasterID = 0;
            if (Session["RoleID"] == null)
            {
                AdminRoleMasterID = !string.IsNullOrEmpty(Convert.ToString(Session["DefaultRoleID"])) ? Convert.ToInt32(Session["DefaultRoleID"]) : 0;
            }

            else
            {
                AdminRoleMasterID = !string.IsNullOrEmpty(Convert.ToString(Session["RoleID"])) ? Convert.ToInt32(Session["RoleID"]) : 0;
            }

            List<AdminRoleApplicableDetails> listAdminRoleApplicableDetails = GetAdminRoleApplicableCentreByStoreManager(AdminRoleMasterID);
            AdminRoleApplicableDetails a = null;
            foreach (var item in listAdminRoleApplicableDetails)
            {
                a = new AdminRoleApplicableDetails();
                a.CentreCode = item.CentreCode;
                a.CentreName = item.CentreName;
                model.ListGetAdminRoleApplicableCentre.Add(a);
            }

            if (model.ID > 0)
            {
                IBaseEntityResponse<SaleContractMaster> response = _SaleContractMasterBA.GetGeneralContractDetails(model.SaleContractMasterDTO);

                if (response != null && response.Entity != null)
                {
                    model.SaleContractMasterDTO.CustomerMasterID = response.Entity.CustomerMasterID;
                    model.SaleContractMasterDTO.CustomerMasterName = response.Entity.CustomerMasterName;
                    model.SaleContractMasterDTO.CustomerBranchMasterID = response.Entity.CustomerBranchMasterID;
                    model.SaleContractMasterDTO.CustomerBranchMasterName = response.Entity.CustomerBranchMasterName;
                    model.SaleContractMasterDTO.CustomerContactPersonID = response.Entity.CustomerContactPersonID;
                    model.SaleContractMasterDTO.CustomerContactPersonName = response.Entity.CustomerContactPersonName;
                    model.SaleContractMasterDTO.ContractStartDate = response.Entity.ContractStartDate;
                    model.SaleContractMasterDTO.ContractEndDate = response.Entity.ContractEndDate;
                    model.SaleContractMasterDTO.CentreCode = response.Entity.CentreCode;
                    model.SaleContractMasterDTO.BillingType = response.Entity.BillingType;
                    model.SaleContractMasterDTO.BillingFixedAmount = response.Entity.BillingFixedAmount;
                    model.SaleContractMasterDTO.FixedBillingType = response.Entity.FixedBillingType;
                    model.SaleContractMasterDTO.FixedBillingForManPowerItemID = response.Entity.FixedBillingForManPowerItemID;
                    model.SaleContractMasterDTO.FixedBillingForManPowerItemName = response.Entity.FixedBillingForManPowerItemName;
                    model.SaleContractMasterDTO.ShortExtraPostingRateAccTo = response.Entity.ShortExtraPostingRateAccTo;
                    model.SaleContractMasterDTO.IsIncludeAllPostingForShortExtraRate = response.Entity.IsIncludeAllPostingForShortExtraRate;
                    model.SaleContractMasterDTO.Narration = response.Entity.Narration;
                    model.SaleContractMasterDTO.EmployeeMasterID = response.Entity.EmployeeMasterID;
                    model.SaleContractMasterDTO.EmployeeMasterName = response.Entity.EmployeeMasterName;
                    model.SaleContractMasterDTO.PurchaseOrderNumber = response.Entity.PurchaseOrderNumber;
                    model.SaleContractMasterDTO.PurchaseOrderDate = response.Entity.PurchaseOrderDate;
                    model.SaleContractMasterDTO.IsDisplayPurchaseDetails = response.Entity.IsDisplayPurchaseDetails;
                }
            }
            return PartialView("/Views/Contract/SaleContractMaster/CreateGeneralContractDetails.cshtml", model);
        }

        public ActionResult CreateGeneralModifyContract(string TaskCode, string SaleContractMasterID)
        {
            SaleContractMasterViewModel model = new SaleContractMasterViewModel();
            model.TaskCode = TaskCode;
            model.ID = Convert.ToInt64(!string.IsNullOrEmpty(SaleContractMasterID) ? SaleContractMasterID : null);
            model.SaleContractMasterDTO.ConnectionString = _connectionString;

            List<SelectListItem> li_BillingType = new List<SelectListItem>();
            li_BillingType.Add(new SelectListItem { Text = "Rate Contract", Value = "1" });
            li_BillingType.Add(new SelectListItem { Text = "Fixed Amount", Value = "2" });
            li_BillingType.Add(new SelectListItem { Text = "Job Work Item", Value = "3" });
            ViewBag.BillingTypeList = new SelectList(li_BillingType, "Value", "Text");

            int AdminRoleMasterID = 0;
            if (Session["RoleID"] == null)
            {
                AdminRoleMasterID = !string.IsNullOrEmpty(Convert.ToString(Session["DefaultRoleID"])) ? Convert.ToInt32(Session["DefaultRoleID"]) : 0;
            }

            else
            {
                AdminRoleMasterID = !string.IsNullOrEmpty(Convert.ToString(Session["RoleID"])) ? Convert.ToInt32(Session["RoleID"]) : 0;
            }

            List<AdminRoleApplicableDetails> listAdminRoleApplicableDetails = GetAdminRoleApplicableCentreByStoreManager(AdminRoleMasterID);
            AdminRoleApplicableDetails a = null;
            foreach (var item in listAdminRoleApplicableDetails)
            {
                a = new AdminRoleApplicableDetails();
                a.CentreCode = item.CentreCode;
                a.CentreName = item.CentreName;
                model.ListGetAdminRoleApplicableCentre.Add(a);
            }

            if (model.ID > 0)
            {
                IBaseEntityResponse<SaleContractMaster> response = _SaleContractMasterBA.GetGeneralContractDetails(model.SaleContractMasterDTO);

                if (response != null && response.Entity != null)
                {
                    model.SaleContractMasterDTO.CustomerMasterID = response.Entity.CustomerMasterID;
                    model.SaleContractMasterDTO.CustomerMasterName = response.Entity.CustomerMasterName;
                    model.SaleContractMasterDTO.CustomerBranchMasterID = response.Entity.CustomerBranchMasterID;
                    model.SaleContractMasterDTO.CustomerBranchMasterName = response.Entity.CustomerBranchMasterName;
                    model.SaleContractMasterDTO.CustomerContactPersonID = response.Entity.CustomerContactPersonID;
                    model.SaleContractMasterDTO.CustomerContactPersonName = response.Entity.CustomerContactPersonName;
                    model.SaleContractMasterDTO.ContractStartDate = response.Entity.ContractStartDate;
                    model.SaleContractMasterDTO.ContractEndDate = response.Entity.ContractEndDate;
                    model.SaleContractMasterDTO.CentreCode = response.Entity.CentreCode;
                    model.SaleContractMasterDTO.BillingType = response.Entity.BillingType;
                    model.SaleContractMasterDTO.BillingFixedAmount = response.Entity.BillingFixedAmount;
                    model.SaleContractMasterDTO.FixedBillingType = response.Entity.FixedBillingType;
                    model.SaleContractMasterDTO.FixedBillingForManPowerItemID = response.Entity.FixedBillingForManPowerItemID;
                    model.SaleContractMasterDTO.FixedBillingForManPowerItemName = response.Entity.FixedBillingForManPowerItemName;
                    model.SaleContractMasterDTO.ShortExtraPostingRateAccTo = response.Entity.ShortExtraPostingRateAccTo;
                    model.SaleContractMasterDTO.IsIncludeAllPostingForShortExtraRate = response.Entity.IsIncludeAllPostingForShortExtraRate;
                    model.SaleContractMasterDTO.Narration = response.Entity.Narration;
                    model.SaleContractMasterDTO.EmployeeMasterID = response.Entity.EmployeeMasterID;
                    model.SaleContractMasterDTO.EmployeeMasterName = response.Entity.EmployeeMasterName;
                    model.SaleContractMasterDTO.PurchaseOrderNumber = response.Entity.PurchaseOrderNumber;
                    model.SaleContractMasterDTO.PurchaseOrderDate = response.Entity.PurchaseOrderDate;
                    model.SaleContractMasterDTO.IsDisplayPurchaseDetails = response.Entity.IsDisplayPurchaseDetails;
                }
            }

            return PartialView("/Views/Contract/SaleContractMaster/CreateGeneralModifyContract.cshtml", model);
        }

        public ActionResult CreateGeneralExtendContract(string TaskCode, string SaleContractMasterID)
        {
            SaleContractMasterViewModel model = new SaleContractMasterViewModel();
            model.TaskCode = TaskCode;
            model.ID = Convert.ToInt64(!string.IsNullOrEmpty(SaleContractMasterID) ? SaleContractMasterID : null);
            model.SaleContractMasterDTO.ConnectionString = _connectionString;

            List<SelectListItem> li_BillingType = new List<SelectListItem>();
            li_BillingType.Add(new SelectListItem { Text = "Rate Contract", Value = "1" });
            li_BillingType.Add(new SelectListItem { Text = "Fixed Amount", Value = "2" });
            li_BillingType.Add(new SelectListItem { Text = "Job Work Item", Value = "3" });
            ViewBag.BillingTypeList = new SelectList(li_BillingType, "Value", "Text");

            List<SelectListItem> li_FixedBillingType = new List<SelectListItem>();
            li_FixedBillingType.Add(new SelectListItem { Text = "Billing For 1 Item", Value = "1" });
            li_FixedBillingType.Add(new SelectListItem { Text = "Billing Month Wise", Value = "2" });
            li_FixedBillingType.Add(new SelectListItem { Text = "Billing Person Wise", Value = "3" });
            li_FixedBillingType.Add(new SelectListItem { Text = "Billing On Summary", Value = "4" });
            ViewBag.FixedBillingTypeList = new SelectList(li_FixedBillingType, "Value", "Text");

            List<SelectListItem> li_ShortExtraPostingRateAccTo = new List<SelectListItem>();
            li_ShortExtraPostingRateAccTo.Add(new SelectListItem { Text = "Total CTC", Value = "1" });
            li_ShortExtraPostingRateAccTo.Add(new SelectListItem { Text = "Fixed Rate", Value = "2" });
            ViewBag.ShortExtraPostingRateAccToList = new SelectList(li_ShortExtraPostingRateAccTo, "Value", "Text");

            int AdminRoleMasterID = 0;
            if (Session["RoleID"] == null)
            {
                AdminRoleMasterID = !string.IsNullOrEmpty(Convert.ToString(Session["DefaultRoleID"])) ? Convert.ToInt32(Session["DefaultRoleID"]) : 0;
            }

            else
            {
                AdminRoleMasterID = !string.IsNullOrEmpty(Convert.ToString(Session["RoleID"])) ? Convert.ToInt32(Session["RoleID"]) : 0;
            }

            List<AdminRoleApplicableDetails> listAdminRoleApplicableDetails = GetAdminRoleApplicableCentreByStoreManager(AdminRoleMasterID);
            AdminRoleApplicableDetails a = null;
            foreach (var item in listAdminRoleApplicableDetails)
            {
                a = new AdminRoleApplicableDetails();
                a.CentreCode = item.CentreCode;
                a.CentreName = item.CentreName;
                model.ListGetAdminRoleApplicableCentre.Add(a);
            }

            if (model.ID > 0)
            {
                IBaseEntityResponse<SaleContractMaster> response = _SaleContractMasterBA.GetGeneralContractDetails(model.SaleContractMasterDTO);

                if (response != null && response.Entity != null)
                {
                    model.SaleContractMasterDTO.CustomerMasterID = response.Entity.CustomerMasterID;
                    model.SaleContractMasterDTO.CustomerMasterName = response.Entity.CustomerMasterName;
                    model.SaleContractMasterDTO.CustomerBranchMasterID = response.Entity.CustomerBranchMasterID;
                    model.SaleContractMasterDTO.CustomerBranchMasterName = response.Entity.CustomerBranchMasterName;
                    model.SaleContractMasterDTO.CustomerContactPersonID = response.Entity.CustomerContactPersonID;
                    model.SaleContractMasterDTO.CustomerContactPersonName = response.Entity.CustomerContactPersonName;
                    model.SaleContractMasterDTO.ContractStartDate = response.Entity.ContractStartDate;
                    model.SaleContractMasterDTO.ContractEndDate = response.Entity.ContractEndDate;
                    model.SaleContractMasterDTO.CentreCode = response.Entity.CentreCode;
                    model.SaleContractMasterDTO.BillingType = response.Entity.BillingType;
                    model.SaleContractMasterDTO.BillingFixedAmount = response.Entity.BillingFixedAmount;
                    model.SaleContractMasterDTO.FixedBillingType = response.Entity.FixedBillingType;
                    model.SaleContractMasterDTO.FixedBillingForManPowerItemID = response.Entity.FixedBillingForManPowerItemID;
                    model.SaleContractMasterDTO.FixedBillingForManPowerItemName = response.Entity.FixedBillingForManPowerItemName;
                    model.SaleContractMasterDTO.ShortExtraPostingRateAccTo = response.Entity.ShortExtraPostingRateAccTo;
                    model.SaleContractMasterDTO.IsIncludeAllPostingForShortExtraRate = response.Entity.IsIncludeAllPostingForShortExtraRate;
                    model.SaleContractMasterDTO.Narration = response.Entity.Narration;
                    model.SaleContractMasterDTO.EmployeeMasterID = response.Entity.EmployeeMasterID;
                    model.SaleContractMasterDTO.EmployeeMasterName = response.Entity.EmployeeMasterName;
                    model.SaleContractMasterDTO.PurchaseOrderNumber = response.Entity.PurchaseOrderNumber;
                    model.SaleContractMasterDTO.PurchaseOrderDate = response.Entity.PurchaseOrderDate;
                    model.SaleContractMasterDTO.IsDisplayPurchaseDetails = response.Entity.IsDisplayPurchaseDetails;
                }
            }

            return PartialView("/Views/Contract/SaleContractMaster/CreateGeneralExtendContract.cshtml", model);
        }

        public ActionResult CreateGeneralShiftEmployee(string TaskCode, string SaleContractMasterID)
        {
            SaleContractMasterViewModel model = new SaleContractMasterViewModel();
            model.TaskCode = TaskCode;
            model.ID = Convert.ToInt64(!string.IsNullOrEmpty(SaleContractMasterID) ? SaleContractMasterID : null);
            model.SaleContractMasterDTO.ConnectionString = _connectionString;

            model.SaleContractMasterListForAssignedEmployee = GetSaleContractMasterListForAssignedEmployee(model.ID);

            return PartialView("/Views/Contract/SaleContractMaster/CreateGeneralShiftEmployee.cshtml", model);
        }

        public ActionResult CreateGeneralRenewContract(string TaskCode, string SaleContractMasterID)
        {
            SaleContractMasterViewModel model = new SaleContractMasterViewModel();
            model.TaskCode = TaskCode;
            model.ID = Convert.ToInt64(!string.IsNullOrEmpty(SaleContractMasterID) ? SaleContractMasterID : null);
            model.SaleContractMasterDTO.ConnectionString = _connectionString;

            List<SelectListItem> li_BillingType = new List<SelectListItem>();
            li_BillingType.Add(new SelectListItem { Text = "Rate Contract", Value = "1" });
            li_BillingType.Add(new SelectListItem { Text = "Fixed Amount", Value = "2" });
            li_BillingType.Add(new SelectListItem { Text = "Job Work Item", Value = "3" });
            ViewBag.BillingTypeList = new SelectList(li_BillingType, "Value", "Text");

            List<SelectListItem> li_FixedBillingType = new List<SelectListItem>();
            li_FixedBillingType.Add(new SelectListItem { Text = "Billing For 1 Item", Value = "1" });
            li_FixedBillingType.Add(new SelectListItem { Text = "Billing Month Wise", Value = "2" });
            li_FixedBillingType.Add(new SelectListItem { Text = "Billing Person Wise", Value = "3" });
            li_FixedBillingType.Add(new SelectListItem { Text = "Billing On Summary", Value = "4" });
            ViewBag.FixedBillingTypeList = new SelectList(li_FixedBillingType, "Value", "Text");

            List<SelectListItem> li_ShortExtraPostingRateAccTo = new List<SelectListItem>();
            li_ShortExtraPostingRateAccTo.Add(new SelectListItem { Text = "Total CTC", Value = "1" });
            li_ShortExtraPostingRateAccTo.Add(new SelectListItem { Text = "Fixed Rate", Value = "2" });
            ViewBag.ShortExtraPostingRateAccToList = new SelectList(li_ShortExtraPostingRateAccTo, "Value", "Text");

            if (model.ID > 0)
            {
                IBaseEntityResponse<SaleContractMaster> response = _SaleContractMasterBA.GetGeneralContractDetails(model.SaleContractMasterDTO);

                if (response != null && response.Entity != null)
                {
                    model.SaleContractMasterDTO.CustomerMasterID = response.Entity.CustomerMasterID;
                    model.SaleContractMasterDTO.CustomerMasterName = response.Entity.CustomerMasterName;
                    model.SaleContractMasterDTO.CustomerBranchMasterID = response.Entity.CustomerBranchMasterID;
                    model.SaleContractMasterDTO.CustomerBranchMasterName = response.Entity.CustomerBranchMasterName;
                    model.SaleContractMasterDTO.CustomerContactPersonID = response.Entity.CustomerContactPersonID;
                    model.SaleContractMasterDTO.CustomerContactPersonName = response.Entity.CustomerContactPersonName;
                    model.SaleContractMasterDTO.ContractStartDate = response.Entity.ContractStartDate;
                    model.SaleContractMasterDTO.ContractEndDate = response.Entity.ContractEndDate;
                    model.SaleContractMasterDTO.CentreCode = response.Entity.CentreCode;
                    model.SaleContractMasterDTO.BillingType = response.Entity.BillingType;
                    model.SaleContractMasterDTO.BillingFixedAmount = response.Entity.BillingFixedAmount;
                    model.SaleContractMasterDTO.FixedBillingType = response.Entity.FixedBillingType;
                    model.SaleContractMasterDTO.FixedBillingForManPowerItemID = response.Entity.FixedBillingForManPowerItemID;
                    model.SaleContractMasterDTO.FixedBillingForManPowerItemName = response.Entity.FixedBillingForManPowerItemName;
                    model.SaleContractMasterDTO.ShortExtraPostingRateAccTo = response.Entity.ShortExtraPostingRateAccTo;
                    model.SaleContractMasterDTO.IsIncludeAllPostingForShortExtraRate = response.Entity.IsIncludeAllPostingForShortExtraRate;
                    model.SaleContractMasterDTO.Narration = response.Entity.Narration;
                    model.SaleContractMasterDTO.EmployeeMasterID = response.Entity.EmployeeMasterID;
                    model.SaleContractMasterDTO.EmployeeMasterName = response.Entity.EmployeeMasterName;
                    model.SaleContractMasterDTO.PurchaseOrderNumber = response.Entity.PurchaseOrderNumber;
                    model.SaleContractMasterDTO.PurchaseOrderDate = response.Entity.PurchaseOrderDate;
                    model.SaleContractMasterDTO.IsDisplayPurchaseDetails = response.Entity.IsDisplayPurchaseDetails;
                }
            }

            return PartialView("/Views/Contract/SaleContractMaster/CreateGeneralRenewContract.cshtml", model);
        }

        public ActionResult CreateGeneralCancelContract(string TaskCode, string SaleContractMasterID)
        {
            SaleContractMasterViewModel model = new SaleContractMasterViewModel();
            model.TaskCode = TaskCode;
            model.ID = Convert.ToInt64(!string.IsNullOrEmpty(SaleContractMasterID) ? SaleContractMasterID : null);
            model.SaleContractMasterDTO.ConnectionString = _connectionString;

            return PartialView("/Views/Contract/SaleContractMaster/CreateGeneralCancelContract.cshtml", model);
        }

        public ActionResult CreateGeneralUpdateAttendance(string TaskCode, string SaleContractMasterID)
        {
            SaleContractMasterViewModel model = new SaleContractMasterViewModel();
            model.TaskCode = TaskCode;
            model.ID = Convert.ToInt64(!string.IsNullOrEmpty(SaleContractMasterID) ? SaleContractMasterID : null);
            model.SaleContractMasterDTO.ConnectionString = _connectionString;

            return PartialView("/Views/Contract/SaleContractMaster/CreateGeneralUpdateAttendance.cshtml", model);
        }

        //[HttpGet]
        //public ActionResult ManPowerItemList(Int64 SaleContractMasterID)
        //{
        //    SaleContractMasterViewModel SaleContractMasterViewModel = new SaleContractMasterViewModel();
        //    try
        //    {
        //        SaleContractMasterViewModel.ID = SaleContractMasterID;

        //        List<EmployeeShiftMaster> employeeShiftMasterList = GetListEmployeeShiftMasterForContract();
        //        List<SelectListItem> employeeShiftMaster = new List<SelectListItem>();
        //        //employeeShiftMaster.Add(new SelectListItem { Text = "--Select Shift--", Value = "0" });
        //        foreach (EmployeeShiftMaster item in employeeShiftMasterList)
        //        {
        //            employeeShiftMaster.Add(new SelectListItem { Text = item.EmployeeShiftDescription, Value = item.EmployeeShiftMasterID.ToString() });
        //        }
        //        ViewBag.ShiftMasterList = new SelectList(employeeShiftMaster, "Value", "Text");

        //        List<SelectListItem> li_Gender = new List<SelectListItem>();
        //        li_Gender.Add(new SelectListItem { Text = "---Select Gender---", Value = "0" });
        //        li_Gender.Add(new SelectListItem { Text = "Male", Value = "1" });
        //        li_Gender.Add(new SelectListItem { Text = "Female", Value = "2" });
        //        ViewBag.GenderList = new SelectList(li_Gender, "Value", "Text");

        //        SaleContractMasterViewModel.SaleContractMasterListForManPowerItem = GetSaleContractMasterListForManPowerItem(SaleContractMasterID);

        //        SaleContractMasterViewModel.SaleContractMasterListForAssignedEmployee = GetSaleContractMasterListForAssignedEmployee(SaleContractMasterID);

        //        return PartialView("/Views/Contract/SaleContractMaster/ManPowerItemList.cshtml", SaleContractMasterViewModel);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logException.Error(ex.Message);
        //        throw;
        //    }
        //}

        //[HttpGet]
        //public ActionResult ModifyManPowerItemList(Int64 SaleContractMasterID, string TaskCode)
        //{
        //    SaleContractMasterViewModel SaleContractMasterViewModel = new SaleContractMasterViewModel();
        //    try
        //    {
        //        SaleContractMasterViewModel.ID = SaleContractMasterID;
        //        SaleContractMasterViewModel.TaskCode = TaskCode;

        //        List<EmployeeShiftMaster> employeeShiftMasterList = GetListEmployeeShiftMasterForContract();
        //        List<SelectListItem> employeeShiftMaster = new List<SelectListItem>();
        //        //employeeShiftMaster.Add(new SelectListItem { Text = "--Select Shift--", Value = "0" });
        //        foreach (EmployeeShiftMaster item in employeeShiftMasterList)
        //        {
        //            employeeShiftMaster.Add(new SelectListItem { Text = item.EmployeeShiftDescription, Value = item.EmployeeShiftMasterID.ToString() });
        //        }
        //        ViewBag.ShiftMasterList = new SelectList(employeeShiftMaster, "Value", "Text");

        //        List<SelectListItem> li_Gender = new List<SelectListItem>();
        //        li_Gender.Add(new SelectListItem { Text = "---Select Gender---", Value = "0" });
        //        li_Gender.Add(new SelectListItem { Text = "Male", Value = "1" });
        //        li_Gender.Add(new SelectListItem { Text = "Female", Value = "2" });
        //        ViewBag.GenderList = new SelectList(li_Gender, "Value", "Text");

        //        SaleContractMasterViewModel.SaleContractMasterListForManPowerItem = GetSaleContractMasterListForManPowerItem(SaleContractMasterID);

        //        SaleContractMasterViewModel.SaleContractMasterListForAssignedEmployee = GetSaleContractMasterListForAssignedEmployee(SaleContractMasterID);

        //        return PartialView("/Views/Contract/SaleContractMaster/ModifyManPowerItemList.cshtml", SaleContractMasterViewModel);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logException.Error(ex.Message);
        //        throw;
        //    }
        //}

        [HttpGet]
        public ActionResult ContractMaterialList(Int64 SaleContractMasterID)
        {
            SaleContractMasterViewModel SaleContractMasterViewModel = new SaleContractMasterViewModel();
            try
            {
                SaleContractMasterViewModel.ID = SaleContractMasterID;

                SaleContractMasterViewModel.SaleContractMasterListForContractMaterial = GetSaleContractMasterListForContractMaterial(SaleContractMasterID);

                return PartialView("/Views/Contract/SaleContractMaster/ContractMaterialList.cshtml", SaleContractMasterViewModel);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpGet]
        public ActionResult MachineMasterList(Int64 SaleContractMasterID)
        {
            SaleContractMasterViewModel SaleContractMasterViewModel = new SaleContractMasterViewModel();
            try
            {
                SaleContractMasterViewModel.ID = SaleContractMasterID;

                SaleContractMasterViewModel.SaleContractMasterListForMachineMaster = GetSaleContractMasterListForMachineMaster(SaleContractMasterID);

                return PartialView("/Views/Contract/SaleContractMaster/MachineMasterList.cshtml", SaleContractMasterViewModel);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpGet]
        public ActionResult ModifyMachineMasterList(Int64 SaleContractMasterID, string TaskCode)
        {
            SaleContractMasterViewModel SaleContractMasterViewModel = new SaleContractMasterViewModel();
            try
            {
                SaleContractMasterViewModel.ID = SaleContractMasterID;
                SaleContractMasterViewModel.TaskCode = TaskCode;

                SaleContractMasterViewModel.SaleContractMasterListForMachineMaster = GetSaleContractMasterListForMachineMaster(SaleContractMasterID);

                return PartialView("/Views/Contract/SaleContractMaster/ModifyMachineMasterList.cshtml", SaleContractMasterViewModel);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpGet]
        public ActionResult JobWorkItemList(Int64 SaleContractMasterID)
        {
            SaleContractMasterViewModel SaleContractMasterViewModel = new SaleContractMasterViewModel();
            try
            {
                SaleContractMasterViewModel.ID = SaleContractMasterID;

                SaleContractMasterViewModel.SaleContractMasterListForJobWorkItem = GetSaleContractMasterListForJobWorkItem(SaleContractMasterID);

                return PartialView("/Views/Contract/SaleContractMaster/JobWorkItemList.cshtml", SaleContractMasterViewModel);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpGet]
        public ActionResult ModifyJobWorkItemList(Int64 SaleContractMasterID, string TaskCode)
        {
            SaleContractMasterViewModel SaleContractMasterViewModel = new SaleContractMasterViewModel();
            try
            {
                SaleContractMasterViewModel.ID = SaleContractMasterID;
                SaleContractMasterViewModel.TaskCode = TaskCode;

                SaleContractMasterViewModel.SaleContractMasterListForJobWorkItem = GetSaleContractMasterListForJobWorkItem(SaleContractMasterID);

                return PartialView("/Views/Contract/SaleContractMaster/ModifyJobWorkItemList.cshtml", SaleContractMasterViewModel);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpGet]
        public ActionResult FixItemList(Int64 SaleContractMasterID)
        {
            SaleContractMasterViewModel SaleContractMasterViewModel = new SaleContractMasterViewModel();
            try
            {
                SaleContractMasterViewModel.ID = SaleContractMasterID;

                SaleContractMasterViewModel.SaleContractMasterListForFixItem = GetSaleContractMasterListForFixItem(SaleContractMasterID);

                return PartialView("/Views/Contract/SaleContractMaster/FixItemList.cshtml", SaleContractMasterViewModel);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpGet]
        public ActionResult ModifyFixItemList(Int64 SaleContractMasterID, string TaskCode)
        {
            SaleContractMasterViewModel SaleContractMasterViewModel = new SaleContractMasterViewModel();
            try
            {
                SaleContractMasterViewModel.ID = SaleContractMasterID;
                SaleContractMasterViewModel.TaskCode = TaskCode;

                SaleContractMasterViewModel.SaleContractMasterListForFixItem = GetSaleContractMasterListForFixItem(SaleContractMasterID);

                return PartialView("/Views/Contract/SaleContractMaster/ModifyFixItemList.cshtml", SaleContractMasterViewModel);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpGet]
        public ActionResult ServiceItemList(Int64 SaleContractMasterID)
        {
            SaleContractMasterViewModel SaleContractMasterViewModel = new SaleContractMasterViewModel();
            try
            {
                SaleContractMasterViewModel.ID = SaleContractMasterID;

                SaleContractMasterViewModel.SaleContractMasterListForServiceItem = GetSaleContractMasterListForServiceItem(SaleContractMasterID);

                return PartialView("/Views/Contract/SaleContractMaster/ServiceItemList.cshtml", SaleContractMasterViewModel);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpGet]
        public ActionResult ModifyServiceItemList(Int64 SaleContractMasterID, string TaskCode)
        {
            SaleContractMasterViewModel SaleContractMasterViewModel = new SaleContractMasterViewModel();
            try
            {
                SaleContractMasterViewModel.ID = SaleContractMasterID;
                SaleContractMasterViewModel.TaskCode = TaskCode;

                SaleContractMasterViewModel.SaleContractMasterListForServiceItem = GetSaleContractMasterListForServiceItem(SaleContractMasterID);

                return PartialView("/Views/Contract/SaleContractMaster/ModifyServiceItemList.cshtml", SaleContractMasterViewModel);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpGet]
        public ActionResult TermDetailsData(Int64 SaleContractMasterID, string TaskCode)
        {
            SaleContractMasterViewModel model = new SaleContractMasterViewModel();
            try
            {
                model.ID = SaleContractMasterID;
                model.TaskCode = TaskCode;
                model.SaleContractMasterDTO.ConnectionString = _connectionString;
                if (model.ID > 0)
                {
                    IBaseEntityResponse<SaleContractMaster> response = _SaleContractMasterBA.GetTermDetailsData(model.SaleContractMasterDTO);

                    if (response != null && response.Entity != null)
                    {
                        model.SaleContractMasterDTO.AdditionalAllowancePaidBy = response.Entity.AdditionalAllowancePaidBy;
                        model.SaleContractMasterDTO.MaterialSupplyDay = response.Entity.MaterialSupplyDay;
                        model.SaleContractMasterDTO.RenewCallBeforeDays = response.Entity.RenewCallBeforeDays;
                        model.SaleContractMasterDTO.MaterialSupplyFixAmount = response.Entity.MaterialSupplyFixAmount;
                        model.SaleContractMasterDTO.ServiceChargesDependOn = response.Entity.ServiceChargesDependOn;
                        model.SaleContractMasterDTO.ServiceChargesCalculateOn = response.Entity.ServiceChargesCalculateOn;
                        model.SaleContractMasterDTO.IsInclusiveServiceCharges = response.Entity.IsInclusiveServiceCharges;
                        model.SaleContractMasterDTO.IsServiceChargesAppliedToAddAmount = response.Entity.IsServiceChargesAppliedToAddAmount;
                        model.SaleContractMasterDTO.IsServiceChargesAppliedToServiceItem = response.Entity.IsServiceChargesAppliedToServiceItem;
                        model.SaleContractMasterDTO.IsServiceChargesAppliedToOverTime = response.Entity.IsServiceChargesAppliedToOverTime;
                        model.SaleContractMasterDTO.IsRateFixedForRateContract = response.Entity.IsRateFixedForRateContract;
                        model.SaleContractMasterDTO.SalaryEffectiveFromDate = response.Entity.SalaryEffectiveFromDate;
                        model.SaleContractMasterDTO.SalaryEffectiveUptoDate = response.Entity.SalaryEffectiveUptoDate;
                        model.SaleContractMasterDTO.ServiceChargesPercentage = response.Entity.ServiceChargesPercentage;
                        model.SaleContractMasterDTO.SaleContractTermDetailsID = response.Entity.SaleContractTermDetailsID;
                        model.SaleContractMasterDTO.OverTimeDependOn = response.Entity.OverTimeDependOn;
                        //model.SaleContractMasterDTO.OverTimeDisplayFormat = response.Entity.OverTimeDisplayFormat;
                        //model.SaleContractMasterDTO.SaleContractOvertimeID = response.Entity.SaleContractOvertimeID;
                        //model.SaleContractMasterDTO.FixedAmountForInvoice = response.Entity.FixedAmountForInvoice;
                        //model.SaleContractMasterDTO.FixedAmountForSalaryCompliance = response.Entity.FixedAmountForSalaryCompliance;

                        if (model.SaleContractMasterDTO.ServiceChargesDependOn == 2)
                        {
                            model.SaleContractMasterListForServiceCharge = GetSaleContractMasterListForServiceCharge(model.SaleContractMasterDTO.SaleContractTermDetailsID);
                        }
                        if (model.SaleContractMasterDTO.OverTimeDependOn == 2)
                        {
                            model.SaleContractMasterListForOverTime = GetSaleContractMasterListForOverTime(model.ID);
                        }
                        else if (model.SaleContractMasterDTO.OverTimeDependOn == 1)
                        {
                            model.SaleContractMasterListForOverTimeFix = GetSaleContractMasterListForOverTimeFix(model.ID);
                        }
                    }
                }

                if (model.SaleContractMasterDTO.ServiceChargesDependOn == 1 || model.ID == 0 || model.TaskCode == "GeneralRenewContract")
                {
                    model.SaleContractMasterListForServiceChargeForHead = GetSaleContractMasterListForServiceChargeForHead(model.SaleContractMasterDTO.SaleContractTermDetailsID);
                }

                List<SelectListItem> li_AdditionalAllowancePaidBy = new List<SelectListItem>();
                li_AdditionalAllowancePaidBy.Add(new SelectListItem { Text = "Self", Value = "1" });
                li_AdditionalAllowancePaidBy.Add(new SelectListItem { Text = "Customer", Value = "2" });
                ViewBag.AdditionalAllowancePaidByList = new SelectList(li_AdditionalAllowancePaidBy, "Value", "Text");

                List<SelectListItem> li_ServiceChargesDependOn = new List<SelectListItem>();
                li_ServiceChargesDependOn.Add(new SelectListItem { Text = "Salary", Value = "1" });
                li_ServiceChargesDependOn.Add(new SelectListItem { Text = "Man Power Item", Value = "2" });
                ViewBag.ServiceChargesDependOnList = new SelectList(li_ServiceChargesDependOn, "Value", "Text");

                //List<SelectListItem> li_ServiceChargesCalculateOn = new List<SelectListItem>();
                //li_ServiceChargesCalculateOn.Add(new SelectListItem { Text = "Gross", Value = "1" });
                //li_ServiceChargesCalculateOn.Add(new SelectListItem { Text = "Total CTC", Value = "2" });
                //ViewBag.ServiceChargesCalculateOnList = new SelectList(li_ServiceChargesCalculateOn, "Value", "Text");

                List<SelectListItem> li_OverTimeDependOn = new List<SelectListItem>();
                li_OverTimeDependOn.Add(new SelectListItem { Text = "Fixed Amount", Value = "1" });
                //li_OverTimeDependOn.Add(new SelectListItem { Text = "Allowance", Value = "2" });
                ViewBag.OverTimeDependOnList = new SelectList(li_OverTimeDependOn, "Value", "Text");

                List<SelectListItem> li_OverTimeDisplayFormat = new List<SelectListItem>();
                li_OverTimeDisplayFormat.Add(new SelectListItem { Text = "Seperate", Value = "1" });
                li_OverTimeDisplayFormat.Add(new SelectListItem { Text = "Include In Posting", Value = "2" });
                ViewBag.OverTimeDisplayFormatList = new SelectList(li_OverTimeDisplayFormat, "Value", "Text");

                List<SelectListItem> li_ForInvoiceOrSalaryCompliance = new List<SelectListItem>();
                li_ForInvoiceOrSalaryCompliance.Add(new SelectListItem { Text = "Invoice", Value = "1" });
                li_ForInvoiceOrSalaryCompliance.Add(new SelectListItem { Text = "Salary", Value = "2" });
                ViewBag.ForInvoiceOrSalaryComplianceList = new SelectList(li_ForInvoiceOrSalaryCompliance, "Value", "Text");

                return PartialView("/Views/Contract/SaleContractMaster/TermDetailsData.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpGet]
        public ActionResult ModifyTermDetailsData(Int64 SaleContractMasterID, string TaskCode)
        {
            SaleContractMasterViewModel model = new SaleContractMasterViewModel();
            try
            {
                model.ID = SaleContractMasterID;
                model.TaskCode = TaskCode;
                model.SaleContractMasterDTO.ConnectionString = _connectionString;
                if (model.ID > 0)
                {
                    IBaseEntityResponse<SaleContractMaster> response = _SaleContractMasterBA.GetTermDetailsData(model.SaleContractMasterDTO);

                    if (response != null && response.Entity != null)
                    {
                        model.SaleContractMasterDTO.AdditionalAllowancePaidBy = response.Entity.AdditionalAllowancePaidBy;
                        model.SaleContractMasterDTO.MaterialSupplyDay = response.Entity.MaterialSupplyDay;
                        model.SaleContractMasterDTO.RenewCallBeforeDays = response.Entity.RenewCallBeforeDays;
                        model.SaleContractMasterDTO.MaterialSupplyFixAmount = response.Entity.MaterialSupplyFixAmount;
                        model.SaleContractMasterDTO.ServiceChargesDependOn = response.Entity.ServiceChargesDependOn;
                        model.SaleContractMasterDTO.ServiceChargesCalculateOn = response.Entity.ServiceChargesCalculateOn;
                        model.SaleContractMasterDTO.IsInclusiveServiceCharges = response.Entity.IsInclusiveServiceCharges;
                        model.SaleContractMasterDTO.IsServiceChargesAppliedToAddAmount = response.Entity.IsServiceChargesAppliedToAddAmount;
                        model.SaleContractMasterDTO.IsServiceChargesAppliedToServiceItem = response.Entity.IsServiceChargesAppliedToServiceItem;
                        model.SaleContractMasterDTO.IsServiceChargesAppliedToOverTime = response.Entity.IsServiceChargesAppliedToOverTime;
                        model.SaleContractMasterDTO.IsRateFixedForRateContract = response.Entity.IsRateFixedForRateContract;
                        model.SaleContractMasterDTO.SalaryEffectiveFromDate = response.Entity.SalaryEffectiveFromDate;
                        model.SaleContractMasterDTO.SalaryEffectiveUptoDate = response.Entity.SalaryEffectiveUptoDate;
                        model.SaleContractMasterDTO.ServiceChargesPercentage = response.Entity.ServiceChargesPercentage;
                        model.SaleContractMasterDTO.SaleContractTermDetailsID = response.Entity.SaleContractTermDetailsID;
                        model.SaleContractMasterDTO.OverTimeDependOn = response.Entity.OverTimeDependOn;
                        //model.SaleContractMasterDTO.OverTimeDisplayFormat = response.Entity.OverTimeDisplayFormat;
                        //model.SaleContractMasterDTO.SaleContractOvertimeID = response.Entity.SaleContractOvertimeID;
                        //model.SaleContractMasterDTO.FixedAmountForInvoice = response.Entity.FixedAmountForInvoice;
                        //model.SaleContractMasterDTO.FixedAmountForSalaryCompliance = response.Entity.FixedAmountForSalaryCompliance;

                        if (model.SaleContractMasterDTO.ServiceChargesDependOn == 2)
                        {
                            model.SaleContractMasterListForServiceCharge = GetSaleContractMasterListForServiceCharge(model.SaleContractMasterDTO.SaleContractTermDetailsID);
                        }
                        if (model.SaleContractMasterDTO.OverTimeDependOn == 2)
                        {
                            model.SaleContractMasterListForOverTime = GetSaleContractMasterListForOverTime(model.ID);
                        }
                        else if (model.SaleContractMasterDTO.OverTimeDependOn == 1)
                        {
                            model.SaleContractMasterListForOverTimeFix = GetSaleContractMasterListForOverTimeFix(model.ID);
                        }
                    }
                }

                if (model.SaleContractMasterDTO.ServiceChargesDependOn == 1 || model.ID == 0)
                {
                    model.SaleContractMasterListForServiceChargeForHead = GetSaleContractMasterListForServiceChargeForHead(model.SaleContractMasterDTO.SaleContractTermDetailsID);
                }

                List<SelectListItem> li_AdditionalAllowancePaidBy = new List<SelectListItem>();
                li_AdditionalAllowancePaidBy.Add(new SelectListItem { Text = "Self", Value = "1" });
                li_AdditionalAllowancePaidBy.Add(new SelectListItem { Text = "Customer", Value = "2" });
                ViewBag.AdditionalAllowancePaidByList = new SelectList(li_AdditionalAllowancePaidBy, "Value", "Text");

                List<SelectListItem> li_ServiceChargesDependOn = new List<SelectListItem>();
                li_ServiceChargesDependOn.Add(new SelectListItem { Text = "Salary", Value = "1" });
                li_ServiceChargesDependOn.Add(new SelectListItem { Text = "Man Power Item", Value = "2" });
                ViewBag.ServiceChargesDependOnList = new SelectList(li_ServiceChargesDependOn, "Value", "Text");

                //List<SelectListItem> li_ServiceChargesCalculateOn = new List<SelectListItem>();
                //li_ServiceChargesCalculateOn.Add(new SelectListItem { Text = "Gross", Value = "1" });
                //li_ServiceChargesCalculateOn.Add(new SelectListItem { Text = "Total CTC", Value = "2" });
                //ViewBag.ServiceChargesCalculateOnList = new SelectList(li_ServiceChargesCalculateOn, "Value", "Text");

                List<SelectListItem> li_OverTimeDependOn = new List<SelectListItem>();
                li_OverTimeDependOn.Add(new SelectListItem { Text = "Fixed Amount", Value = "1" });
                //li_OverTimeDependOn.Add(new SelectListItem { Text = "Allowance", Value = "2" });
                ViewBag.OverTimeDependOnList = new SelectList(li_OverTimeDependOn, "Value", "Text");

                List<SelectListItem> li_OverTimeDisplayFormat = new List<SelectListItem>();
                li_OverTimeDisplayFormat.Add(new SelectListItem { Text = "Seperate", Value = "1" });
                li_OverTimeDisplayFormat.Add(new SelectListItem { Text = "Include In Posting", Value = "2" });
                ViewBag.OverTimeDisplayFormatList = new SelectList(li_OverTimeDisplayFormat, "Value", "Text");

                List<SelectListItem> li_ForInvoiceOrSalaryCompliance = new List<SelectListItem>();
                li_ForInvoiceOrSalaryCompliance.Add(new SelectListItem { Text = "Invoice", Value = "1" });
                li_ForInvoiceOrSalaryCompliance.Add(new SelectListItem { Text = "Salary", Value = "2" });
                ViewBag.ForInvoiceOrSalaryComplianceList = new SelectList(li_ForInvoiceOrSalaryCompliance, "Value", "Text");

                return PartialView("/Views/Contract/SaleContractMaster/ModifyTermDetailsData.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public ActionResult Create(SaleContractMasterViewModel model)
        {
            try
            {
                if (model != null && model.SaleContractMasterDTO != null)
                {
                    //SaleContractMaster
                    model.SaleContractMasterDTO.ConnectionString = _connectionString;
                    model.SaleContractMasterDTO.ID = model.ID;
                    //var splitedCentre = model.CentreCode.Split(':');
                    model.SaleContractMasterDTO.CentreCode = model.CentreCode;
                    model.SaleContractMasterDTO.Narration = model.Narration;
                    model.SaleContractMasterDTO.EmployeeMasterID = model.EmployeeMasterID;
                    model.SaleContractMasterDTO.PurchaseOrderNumber = model.PurchaseOrderNumber;
                    model.SaleContractMasterDTO.PurchaseOrderDate = model.PurchaseOrderDate;
                    model.SaleContractMasterDTO.IsDisplayPurchaseDetails = model.IsDisplayPurchaseDetails;
                    model.SaleContractMasterDTO.IsConfidential = model.IsConfidential;
                    model.SaleContractMasterDTO.CustomerMasterID = model.CustomerMasterID;
                    model.SaleContractMasterDTO.CustomerBranchMasterID = model.CustomerBranchMasterID;
                    model.SaleContractMasterDTO.CustomerContactPersonID = model.CustomerContactPersonID;
                    model.SaleContractMasterDTO.ContractStartDate = model.ContractStartDate;
                    model.SaleContractMasterDTO.ContractEndDate = model.ContractEndDate;
                    model.SaleContractMasterDTO.BillingType = model.BillingType;
                    model.SaleContractMasterDTO.BillingFixedAmount = model.BillingFixedAmount;
                    model.SaleContractMasterDTO.FixedBillingType = model.FixedBillingType;
                    model.SaleContractMasterDTO.FixedBillingForManPowerItemID = model.FixedBillingForManPowerItemID;
                    model.SaleContractMasterDTO.ShortExtraPostingRateAccTo = model.ShortExtraPostingRateAccTo;
                    model.SaleContractMasterDTO.IsIncludeAllPostingForShortExtraRate = model.IsIncludeAllPostingForShortExtraRate;
                    model.SaleContractMasterDTO.AdditionalAllowancePaidBy = model.AdditionalAllowancePaidBy;
                    model.SaleContractMasterDTO.MaterialSupplyDay = model.MaterialSupplyDay;
                    model.SaleContractMasterDTO.RenewCallBeforeDays = model.RenewCallBeforeDays;
                    model.SaleContractMasterDTO.MaterialSupplyFixAmount = model.MaterialSupplyFixAmount;
                    model.SaleContractMasterDTO.SalaryEffectiveFromDate = model.SalaryEffectiveFromDate;
                    model.SaleContractMasterDTO.SalaryEffectiveUptoDate = model.SalaryEffectiveUptoDate;
                    model.SaleContractMasterDTO.ServiceChargesDependOn = model.ServiceChargesDependOn;
                    model.SaleContractMasterDTO.ServiceChargesCalculateOn = model.ServiceChargesCalculateOn;
                    model.SaleContractMasterDTO.IsInclusiveServiceCharges = model.IsInclusiveServiceCharges;
                    model.SaleContractMasterDTO.IsServiceChargesAppliedToAddAmount = model.IsServiceChargesAppliedToAddAmount;
                    model.SaleContractMasterDTO.IsServiceChargesAppliedToServiceItem = model.IsServiceChargesAppliedToServiceItem;
                    model.SaleContractMasterDTO.IsServiceChargesAppliedToOverTime = model.IsServiceChargesAppliedToOverTime;
                    model.SaleContractMasterDTO.IsRateFixedForRateContract = model.IsRateFixedForRateContract;
                    model.SaleContractMasterDTO.ServiceChargesPercentage = model.ServiceChargesPercentage;
                    model.SaleContractMasterDTO.OverTimeDependOn = model.OverTimeDependOn;
                    //model.SaleContractMasterDTO.OverTimeDisplayFormat = model.OverTimeDisplayFormat;
                    //model.SaleContractMasterDTO.FixedAmountForInvoice = model.FixedAmountForInvoice;
                    //model.SaleContractMasterDTO.FixedAmountForSalaryCompliance = model.FixedAmountForSalaryCompliance;
                    model.SaleContractMasterDTO.XMLstringForOverTime = model.XMLstringForOverTime;
                    model.SaleContractMasterDTO.XMLstringForOverTimeFix = model.XMLstringForOverTimeFix;
                    model.SaleContractMasterDTO.XMLstringForManPowerServiceCharge = model.XMLstringForManPowerServiceCharge;
                    model.SaleContractMasterDTO.XMLstringForManPowerServiceChargeForHead = model.XMLstringForManPowerServiceChargeForHead;
                    model.SaleContractMasterDTO.XMLstringForManPowerItem = model.XMLstringForManPowerItem;
                    model.SaleContractMasterDTO.XMLstringForAssignedEmployee = model.XMLstringForAssignedEmployee;
                    model.SaleContractMasterDTO.XMLstringForContractMaterial = model.XMLstringForContractMaterial;
                    model.SaleContractMasterDTO.XMLstringForMachine = model.XMLstringForMachine;
                    model.SaleContractMasterDTO.XMLstringForJobWorkItem = model.XMLstringForJobWorkItem;
                    model.SaleContractMasterDTO.XMLstringForFixItem = model.XMLstringForFixItem;
                    model.SaleContractMasterDTO.XMLstringForServiceItem = model.XMLstringForServiceItem;

                    int AdminRoleID = 0;
                    if (Session["RoleID"] == null)
                    {
                        AdminRoleID = !string.IsNullOrEmpty(Convert.ToString(Session["DefaultRoleID"])) ? Convert.ToInt32(Session["DefaultRoleID"]) : 0;
                    }
                    else
                    {
                        AdminRoleID = !string.IsNullOrEmpty(Convert.ToString(Session["RoleID"])) ? Convert.ToInt32(Session["RoleID"]) : 0;
                    }

                    model.SaleContractMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    model.SaleContractMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                    model.SaleContractMasterDTO.AdminRoleID = AdminRoleID;

                    IBaseEntityResponse<SaleContractMaster> response = _SaleContractMasterBA.InsertSaleContractMaster(model.SaleContractMasterDTO);
                    model.SaleContractMasterDTO.ID = response.Entity.ID;
                    model.SaleContractMasterDTO.ContractNumber = response.Entity.ContractNumber;

                    if (response.Entity.ErrorCode == 15)
                    {
                        string[] arrayList = { "Un Authorized Access!", "warning", string.Empty };
                        model.SaleContractMasterDTO.errorMessage = string.Join(",", arrayList);
                    }
                    else
                    {
                        model.SaleContractMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    }

                    return Json(model.SaleContractMasterDTO, JsonRequestBehavior.AllowGet);
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

        [HttpPost]
        public ActionResult Modify(SaleContractMasterViewModel model)
        {
            try
            {
                if (model != null && model.SaleContractMasterDTO != null)
                {
                    //SaleContractMaster
                    model.SaleContractMasterDTO.ConnectionString = _connectionString;
                    model.SaleContractMasterDTO.ID = model.ID;
                    model.SaleContractMasterDTO.Narration = model.Narration;
                    model.SaleContractMasterDTO.EmployeeMasterID = model.EmployeeMasterID;
                    model.SaleContractMasterDTO.PurchaseOrderNumber = model.PurchaseOrderNumber;
                    model.SaleContractMasterDTO.PurchaseOrderDate = model.PurchaseOrderDate;
                    model.SaleContractMasterDTO.IsDisplayPurchaseDetails = model.IsDisplayPurchaseDetails;
                    model.SaleContractMasterDTO.XMLstringForManPowerServiceCharge = model.XMLstringForManPowerServiceCharge;
                    model.SaleContractMasterDTO.XMLstringForOverTime = model.XMLstringForOverTime;
                    model.SaleContractMasterDTO.XMLstringForOverTimeFix = model.XMLstringForOverTimeFix;
                    model.SaleContractMasterDTO.XMLstringForManPowerItem = model.XMLstringForManPowerItem;
                    model.SaleContractMasterDTO.XMLstringForAssignedEmployee = model.XMLstringForAssignedEmployee;
                    model.SaleContractMasterDTO.XMLstringForMachine = model.XMLstringForMachine;
                    model.SaleContractMasterDTO.XMLstringForJobWorkItem = model.XMLstringForJobWorkItem;
                    model.SaleContractMasterDTO.XMLstringForFixItem = model.XMLstringForFixItem;
                    model.SaleContractMasterDTO.XMLstringForServiceItem = model.XMLstringForServiceItem;

                    model.SaleContractMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    model.SaleContractMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);

                    IBaseEntityResponse<SaleContractMaster> response = _SaleContractMasterBA.ModifySaleContractMaster(model.SaleContractMasterDTO);

                    model.SaleContractMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);

                    return Json(model.SaleContractMasterDTO, JsonRequestBehavior.AllowGet);
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

        [HttpPost]
        public ActionResult Extend(SaleContractMasterViewModel model)
        {
            try
            {
                if (model != null && model.SaleContractMasterDTO != null)
                {
                    //SaleContractMaster
                    model.SaleContractMasterDTO.ConnectionString = _connectionString;
                    model.SaleContractMasterDTO.ID = model.ID;
                    model.SaleContractMasterDTO.ContractEndDate = model.ContractEndDate;
                    model.SaleContractMasterDTO.SalaryEffectiveUptoDate = model.SalaryEffectiveUptoDate;

                    model.SaleContractMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    model.SaleContractMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);

                    IBaseEntityResponse<SaleContractMaster> response = _SaleContractMasterBA.ExtendSaleContractMaster(model.SaleContractMasterDTO);

                    model.SaleContractMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);

                    return Json(model.SaleContractMasterDTO, JsonRequestBehavior.AllowGet);
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

        [HttpPost]
        public ActionResult ShiftEmployee(SaleContractMasterViewModel model)
        {
            try
            {
                if (model != null && model.SaleContractMasterDTO != null)
                {
                    //SaleContractMaster
                    model.SaleContractMasterDTO.ConnectionString = _connectionString;
                    model.SaleContractMasterDTO.ID = model.ID;
                    model.SaleContractMasterDTO.XMLstringForShiftingEmployee = model.XMLstringForShiftingEmployee;

                    model.SaleContractMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    model.SaleContractMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);

                    IBaseEntityResponse<SaleContractMaster> response = _SaleContractMasterBA.SaleContractMasterShiftEmployee(model.SaleContractMasterDTO);

                    model.SaleContractMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);

                    return Json(model.SaleContractMasterDTO, JsonRequestBehavior.AllowGet);
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

        [HttpPost]
        public ActionResult Renew(SaleContractMasterViewModel model)
        {
            try
            {
                if (model != null && model.SaleContractMasterDTO != null)
                {

                    model.SaleContractMasterDTO.ConnectionString = _connectionString;
                    model.SaleContractMasterDTO.ID = model.ID;
                    model.SaleContractMasterDTO.Narration = model.Narration;
                    model.SaleContractMasterDTO.EmployeeMasterID = model.EmployeeMasterID;
                    model.SaleContractMasterDTO.PurchaseOrderNumber = model.PurchaseOrderNumber;
                    model.SaleContractMasterDTO.PurchaseOrderDate = model.PurchaseOrderDate;
                    model.SaleContractMasterDTO.IsDisplayPurchaseDetails = model.IsDisplayPurchaseDetails;
                    model.SaleContractMasterDTO.ContractStartDate = model.ContractStartDate;
                    model.SaleContractMasterDTO.ContractEndDate = model.ContractEndDate;
                    model.SaleContractMasterDTO.BillingType = model.BillingType;
                    model.SaleContractMasterDTO.BillingFixedAmount = model.BillingFixedAmount;
                    model.SaleContractMasterDTO.FixedBillingType = model.FixedBillingType;
                    model.SaleContractMasterDTO.FixedBillingForManPowerItemID = model.FixedBillingForManPowerItemID;
                    model.SaleContractMasterDTO.ShortExtraPostingRateAccTo = model.ShortExtraPostingRateAccTo;
                    model.SaleContractMasterDTO.IsIncludeAllPostingForShortExtraRate = model.IsIncludeAllPostingForShortExtraRate;
                    model.SaleContractMasterDTO.AdditionalAllowancePaidBy = model.AdditionalAllowancePaidBy;
                    model.SaleContractMasterDTO.MaterialSupplyDay = model.MaterialSupplyDay;
                    model.SaleContractMasterDTO.RenewCallBeforeDays = model.RenewCallBeforeDays;
                    model.SaleContractMasterDTO.MaterialSupplyFixAmount = model.MaterialSupplyFixAmount;
                    model.SaleContractMasterDTO.SalaryEffectiveFromDate = model.SalaryEffectiveFromDate;
                    model.SaleContractMasterDTO.SalaryEffectiveUptoDate = model.SalaryEffectiveUptoDate;
                    model.SaleContractMasterDTO.ServiceChargesDependOn = model.ServiceChargesDependOn;
                    model.SaleContractMasterDTO.ServiceChargesCalculateOn = model.ServiceChargesCalculateOn;
                    model.SaleContractMasterDTO.IsInclusiveServiceCharges = model.IsInclusiveServiceCharges;
                    model.SaleContractMasterDTO.IsServiceChargesAppliedToAddAmount = model.IsServiceChargesAppliedToAddAmount;
                    model.SaleContractMasterDTO.IsServiceChargesAppliedToServiceItem = model.IsServiceChargesAppliedToServiceItem;
                    model.SaleContractMasterDTO.IsServiceChargesAppliedToOverTime = model.IsServiceChargesAppliedToOverTime;
                    model.SaleContractMasterDTO.IsRateFixedForRateContract = model.IsRateFixedForRateContract;
                    model.SaleContractMasterDTO.ServiceChargesPercentage = model.ServiceChargesPercentage;
                    model.SaleContractMasterDTO.OverTimeDependOn = model.OverTimeDependOn;
                    //model.SaleContractMasterDTO.OverTimeDisplayFormat = model.OverTimeDisplayFormat;
                    //model.SaleContractMasterDTO.FixedAmountForInvoice = model.FixedAmountForInvoice;
                    //model.SaleContractMasterDTO.FixedAmountForSalaryCompliance = model.FixedAmountForSalaryCompliance;
                    model.SaleContractMasterDTO.XMLstringForOverTime = model.XMLstringForOverTime;
                    model.SaleContractMasterDTO.XMLstringForOverTimeFix = model.XMLstringForOverTimeFix;
                    model.SaleContractMasterDTO.XMLstringForManPowerServiceCharge = model.XMLstringForManPowerServiceCharge;
                    model.SaleContractMasterDTO.XMLstringForManPowerServiceChargeForHead = model.XMLstringForManPowerServiceChargeForHead;
                    model.SaleContractMasterDTO.XMLstringForManPowerItem = model.XMLstringForManPowerItem;
                    model.SaleContractMasterDTO.XMLstringForAssignedEmployee = model.XMLstringForAssignedEmployee;
                    model.SaleContractMasterDTO.XMLstringForContractMaterial = model.XMLstringForContractMaterial;
                    model.SaleContractMasterDTO.XMLstringForMachine = model.XMLstringForMachine;
                    model.SaleContractMasterDTO.XMLstringForJobWorkItem = model.XMLstringForJobWorkItem;
                    model.SaleContractMasterDTO.XMLstringForFixItem = model.XMLstringForFixItem;
                    model.SaleContractMasterDTO.XMLstringForServiceItem = model.XMLstringForServiceItem;

                    model.SaleContractMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    model.SaleContractMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<SaleContractMaster> response = _SaleContractMasterBA.RenewSaleContractMaster(model.SaleContractMasterDTO);
                    model.SaleContractMasterDTO.ID = response.Entity.ID;
                    model.SaleContractMasterDTO.ContractNumber = response.Entity.ContractNumber;

                    model.SaleContractMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);

                    return Json(model.SaleContractMasterDTO, JsonRequestBehavior.AllowGet);
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
        protected List<SaleContractMaster> GetSaleContractMasterListForManPowerItem(Int64 SaleContractMasterID)
        {
            SaleContractMasterSearchRequest searchRequest = new SaleContractMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            searchRequest.ID = SaleContractMasterID;
            List<SaleContractMaster> listSaleContractMaster = new List<SaleContractMaster>();
            IBaseEntityCollectionResponse<SaleContractMaster> baseEntityCollectionResponse = _SaleContractMasterBA.GetManPowerItemList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listSaleContractMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listSaleContractMaster;
        }

        [NonAction]
        protected List<SaleContractMaster> GetSaleContractMasterListForAssignedEmployee(Int64 SaleContractMasterID)
        {
            SaleContractMasterSearchRequest searchRequest = new SaleContractMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            searchRequest.ID = SaleContractMasterID;
            List<SaleContractMaster> listSaleContractMaster = new List<SaleContractMaster>();
            IBaseEntityCollectionResponse<SaleContractMaster> baseEntityCollectionResponse = _SaleContractMasterBA.GetAssignedEmployeeList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listSaleContractMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listSaleContractMaster;
        }

        [NonAction]
        protected List<SaleContractMaster> GetSaleContractMasterListForContractMaterial(Int64 SaleContractMasterID)
        {
            SaleContractMasterSearchRequest searchRequest = new SaleContractMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            searchRequest.ID = SaleContractMasterID;
            List<SaleContractMaster> listSaleContractMaster = new List<SaleContractMaster>();
            IBaseEntityCollectionResponse<SaleContractMaster> baseEntityCollectionResponse = _SaleContractMasterBA.GetContractMaterialList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listSaleContractMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listSaleContractMaster;
        }

        [NonAction]
        protected List<SaleContractMaster> GetSaleContractMasterListForMachineMaster(Int64 SaleContractMasterID)
        {
            SaleContractMasterSearchRequest searchRequest = new SaleContractMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            searchRequest.ID = SaleContractMasterID;
            List<SaleContractMaster> listSaleContractMaster = new List<SaleContractMaster>();
            IBaseEntityCollectionResponse<SaleContractMaster> baseEntityCollectionResponse = _SaleContractMasterBA.GetMachineMasterList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listSaleContractMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listSaleContractMaster;
        }

        [NonAction]
        protected List<SaleContractMaster> GetSaleContractMasterListForJobWorkItem(Int64 SaleContractMasterID)
        {
            SaleContractMasterSearchRequest searchRequest = new SaleContractMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            searchRequest.ID = SaleContractMasterID;
            List<SaleContractMaster> listSaleContractMaster = new List<SaleContractMaster>();
            IBaseEntityCollectionResponse<SaleContractMaster> baseEntityCollectionResponse = _SaleContractMasterBA.GetJobWorkItemList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listSaleContractMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listSaleContractMaster;
        }

        [NonAction]
        protected List<SaleContractMaster> GetSaleContractMasterListForFixItem(Int64 SaleContractMasterID)
        {
            SaleContractMasterSearchRequest searchRequest = new SaleContractMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            searchRequest.ID = SaleContractMasterID;
            List<SaleContractMaster> listSaleContractMaster = new List<SaleContractMaster>();
            IBaseEntityCollectionResponse<SaleContractMaster> baseEntityCollectionResponse = _SaleContractMasterBA.GetFixItemList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listSaleContractMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listSaleContractMaster;
        }

        [NonAction]
        protected List<SaleContractMaster> GetSaleContractMasterListForServiceItem(Int64 SaleContractMasterID)
        {
            SaleContractMasterSearchRequest searchRequest = new SaleContractMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            searchRequest.ID = SaleContractMasterID;
            List<SaleContractMaster> listSaleContractMaster = new List<SaleContractMaster>();
            IBaseEntityCollectionResponse<SaleContractMaster> baseEntityCollectionResponse = _SaleContractMasterBA.GetServiceItemList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listSaleContractMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listSaleContractMaster;
        }

        [NonAction]
        protected List<SaleContractMaster> GetSaleContractMasterListForServiceCharge(Int64 SaleContractTermDetailsID)
        {
            SaleContractMasterSearchRequest searchRequest = new SaleContractMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            searchRequest.SaleContractTermDetailsID = SaleContractTermDetailsID;
            List<SaleContractMaster> listSaleContractMaster = new List<SaleContractMaster>();
            IBaseEntityCollectionResponse<SaleContractMaster> baseEntityCollectionResponse = _SaleContractMasterBA.GetServiceChargeList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listSaleContractMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listSaleContractMaster;
        }

        [NonAction]
        protected List<SaleContractMaster> GetSaleContractMasterListForServiceChargeForHead(Int64 SaleContractTermDetailsID)
        {
            SaleContractMasterSearchRequest searchRequest = new SaleContractMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            searchRequest.SaleContractTermDetailsID = SaleContractTermDetailsID;
            List<SaleContractMaster> listSaleContractMaster = new List<SaleContractMaster>();
            IBaseEntityCollectionResponse<SaleContractMaster> baseEntityCollectionResponse = _SaleContractMasterBA.GetServiceChargeOnAllowanceList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listSaleContractMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listSaleContractMaster;
        }

        [NonAction]
        protected List<SaleContractMaster> GetSaleContractMasterListForOverTime(Int64 ID)
        {
            SaleContractMasterSearchRequest searchRequest = new SaleContractMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            searchRequest.ID = ID;
            List<SaleContractMaster> listSaleContractMaster = new List<SaleContractMaster>();
            IBaseEntityCollectionResponse<SaleContractMaster> baseEntityCollectionResponse = _SaleContractMasterBA.GetOverTimeList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listSaleContractMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listSaleContractMaster;
        }

        [NonAction]
        protected List<SaleContractMaster> GetSaleContractMasterListForOverTimeFix(Int64 ID)
        {
            SaleContractMasterSearchRequest searchRequest = new SaleContractMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            searchRequest.ID = ID;
            List<SaleContractMaster> listSaleContractMaster = new List<SaleContractMaster>();
            IBaseEntityCollectionResponse<SaleContractMaster> baseEntityCollectionResponse = _SaleContractMasterBA.GetOverTimeFixList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listSaleContractMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listSaleContractMaster;
        }


        [HttpPost]
        public JsonResult GetSaleContractMaterialItemList(string term)
        {
            GeneralItemMasterSearchRequest searchRequest = new GeneralItemMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.SearchWord = term;
            List<GeneralItemMaster> listFeeSubType = new List<GeneralItemMaster>();
            IBaseEntityCollectionResponse<GeneralItemMaster> baseEntityCollectionResponse = _GeneralItemMasterBA.GetGeneralItemMasterForSaleUOMBySearchWord(searchRequest);
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
        public JsonResult GetContractNumberSearchList(string term)
        {
            SaleContractMasterSearchRequest searchRequest = new SaleContractMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.SearchWord = term;
            int AdminRoleID = 0;
            if (Session["RoleID"] == null)
            {
                AdminRoleID = !string.IsNullOrEmpty(Convert.ToString(Session["DefaultRoleID"])) ? Convert.ToInt32(Session["DefaultRoleID"]) : 0;
            }
            else
            {
                AdminRoleID = !string.IsNullOrEmpty(Convert.ToString(Session["RoleID"])) ? Convert.ToInt32(Session["RoleID"]) : 0;
            }
            searchRequest.AdminRoleID = AdminRoleID;
            List<SaleContractMaster> listFeeSubType = new List<SaleContractMaster>();
            IBaseEntityCollectionResponse<SaleContractMaster> baseEntityCollectionResponse = _SaleContractMasterBA.GetContractNumberSearchList(searchRequest);
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
                              ID = r.ID,
                              ContractNumber = r.ContractNumber,

                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetEmployeeeMasterSearchList(string term, string CentreCode)
        {
            EmpEmployeeMasterSearchRequest searchRequest = new EmpEmployeeMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            searchRequest.SearchWord = term;
            searchRequest.CentreCode = CentreCode;

            List<EmpEmployeeMaster> listCustomerMaster = new List<EmpEmployeeMaster>();
            IBaseEntityCollectionResponse<EmpEmployeeMaster> baseEntityCollectionResponse = _empEmployeeMasterBA.GetEmployeeCentrewiseSearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listCustomerMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            var result = (from r in listCustomerMaster
                          select new
                          {
                              EmployeeMasterID = r.ID,
                              EmployeeMasterName = r.EmployeeFirstName

                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [NonAction]
        public IEnumerable<SaleContractMasterViewModel> GetSaleContractMaster(out int TotalRecords)
        {
            try
            {
                SaleContractMasterSearchRequest searchRequest = new SaleContractMasterSearchRequest();
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
                searchRequest.AdminRoleID = AdminRoleID;

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

                List<SaleContractMasterViewModel> listSaleContractMasterViewModel = new List<SaleContractMasterViewModel>();
                List<SaleContractMaster> listSaleContractMaster = new List<SaleContractMaster>();
                IBaseEntityCollectionResponse<SaleContractMaster> baseEntityCollectionResponse = _SaleContractMasterBA.GetSaleContractMasterBySearch(searchRequest);
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        listSaleContractMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                        foreach (SaleContractMaster item in listSaleContractMaster)
                        {
                            SaleContractMasterViewModel SaleContractMasterViewModel = new SaleContractMasterViewModel();
                            SaleContractMasterViewModel.SaleContractMasterDTO = item;
                            listSaleContractMasterViewModel.Add(SaleContractMasterViewModel);
                        }
                    }
                }
                TotalRecords = baseEntityCollectionResponse.TotalRecords;

                return listSaleContractMasterViewModel;
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
            IEnumerable<SaleContractMasterViewModel> filteredSaleContractMaster;

            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "ContractNumber";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "ContractNumber Like '%" + param.sSearch + "%' or concat(B.FirstName,' ',B.MiddleName,' ',B.LastName) Like '%" + param.sSearch + "%' or B.CompanyName like '%" + param.sSearch + "%' or C.BranchName like '%" + param.sSearch + "%' or A.Narration like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "ContractNumber";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "ContractNumber Like '%" + param.sSearch + "%' or concat(B.FirstName,' ',B.MiddleName,' ',B.LastName) Like '%" + param.sSearch + "%' or B.CompanyName like '%" + param.sSearch + "%' or C.BranchName like '%" + param.sSearch + "%' or A.Narration like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
            }

            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;

            filteredSaleContractMaster = GetSaleContractMaster(out TotalRecords);

            var records = filteredSaleContractMaster.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.ID), Convert.ToString(c.CustomerMasterName + (c.CustomerBranchMasterName != "" ? " (" + c.CustomerBranchMasterName + ")" : "")).Trim().Replace(",", "#"), Convert.ToString(c.ContractNumber), Convert.ToString(c.SaleContractType), Convert.ToString(c.Narration) };
            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);

        }
        #endregion
    }
}


