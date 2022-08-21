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
using AERP.DataProvider;
using System.IO;
//using System.Data.OleDb;
//using System.Data.SqlClient;
using System.Web.Hosting;
using System.Data;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Text.RegularExpressions;
using System.Collections;


namespace AERP.Web.UI.Controllers
{
    public class PurchaseRequirementMasterController : BaseController
    {
        IPurchaseRequirementMasterBA _PurchaseRequirementMasterBA = null;
        IGeneralItemMasterBA _generalItemMasterBA = null;
        IGeneralPolicyRulesBA _GeneralPolicyRulesBA = null;
        IInventoryLocationMasterBA _InventoryLocationMasterBA = null;
        IAccountSessionMasterBA _accountSessionMasterBA = null;
        IGeneralRunningNumbersForAccountBA _GeneralRunningNumbersForAccountBA = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        static string xmlParameter = null;
        static bool IsExcelValid = true;
        static string errorMessage = null;
        int _startRow;
        int _rowLength;
        string _centreCode = string.Empty;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public PurchaseRequirementMasterController()
        {
            _PurchaseRequirementMasterBA = new PurchaseRequirementMasterBA();
            _generalItemMasterBA = new GeneralItemMasterBA();
            _GeneralPolicyRulesBA = new GeneralPolicyRulesBA();
            _InventoryLocationMasterBA = new InventoryLocationMasterBA();
            _accountSessionMasterBA = new AccountSessionMasterBA();
            _GeneralRunningNumbersForAccountBA = new GeneralRunningNumbersForAccountBA();
        }

        /// <summary>
        /// First Load When controller call List Method
        /// </summary>
        /// <returns>view</returns>
        [HttpGet]
        public ActionResult Index(string centerCode, string departmentIDs)
        {
            if (Convert.ToString(Session["UserType"]) == "A" || Convert.ToInt32(Session["Purchase Manager"]) > 0 || Convert.ToInt32(Session["Purchase Manager:Entity"]) > 0)
            {
                try
                {
                    PurchaseRequirementMasterViewModel model = new PurchaseRequirementMasterViewModel();
                    int AdminRoleMasterID = 0;
                    if (!string.IsNullOrEmpty(centerCode))
                    {
                        string[] splitCentreCode = centerCode.Split(':');
                        model.CentreCode = splitCentreCode[0];
                        model.EntityLevel = splitCentreCode[1];
                    }
                    else
                    {
                        model.CentreCode = centerCode;
                        model.EntityLevel = null;
                    }

                    if (Convert.ToString(Session["UserType"]) == "A")
                    {
                        //--------------------------------------For Centre Code list---------------------------------//
                        List<OrganisationStudyCentreMaster> listAdminRoleApplicableDetails = GetListOrgStudyCentreMaster();
                        AdminRoleApplicableDetails a = null;
                        foreach (var item in listAdminRoleApplicableDetails)
                        {
                            a = new AdminRoleApplicableDetails();
                            a.CentreCode = item.CentreCode;
                            a.CentreName = item.CentreName;
                            a.ScopeIdentity = item.ScopeIdentity;
                            model.ListGetAdminRoleApplicableCentre.Add(a);
                        }
                        model.EntityLevel = "Centre";

                        foreach (var b in model.ListGetAdminRoleApplicableCentre)
                        {
                            b.CentreCode = b.CentreCode + ":" + "Centre";
                        }
                    }
                    else
                    {
                        if (Session["RoleID"] == null)
                        {
                            AdminRoleMasterID = Convert.ToInt32(Session["DefaultRoleID"]);
                        }
                        else
                        {
                            AdminRoleMasterID = Convert.ToInt32(Session["RoleID"]);
                        }
                        List<AdminRoleApplicableDetails> listAdminRoleApplicableDetails = GetAdminRoleApplicableCentreByPurchaseManager(AdminRoleMasterID);
                        AdminRoleApplicableDetails a = null;
                        foreach (var item in listAdminRoleApplicableDetails)
                        {
                            a = new AdminRoleApplicableDetails();
                            a.CentreCode = item.CentreCode;
                            a.CentreName = item.CentreName;
                            a.ScopeIdentity = item.ScopeIdentity;
                            model.ListGetAdminRoleApplicableCentre.Add(a);
                        }
                        foreach (var b in model.ListGetAdminRoleApplicableCentre)
                        {
                            b.CentreCode = b.CentreCode + ":" + b.ScopeIdentity;
                        }
                    }
                    if (!string.IsNullOrEmpty(centerCode))
                    {
                        string[] splitCentreCode = centerCode.Split(':');
                        model.ListGetOrganisationDepartmentCentreAndRoleWise = GetListOrganisationMasterCentreAndRoleWise(splitCentreCode[0], splitCentreCode[1], AdminRoleMasterID);
                    }
                    model.SelectedCentreCode = centerCode;
                    if (departmentIDs != null)
                        model.SelectedDepartmentIDs = departmentIDs.Substring(1);

                    model.SelectedDepartmentID = model.SelectedDepartmentIDs;

                    if (TempData["_errorMsg"] != null)
                    {
                        model.errorMessage = Convert.ToString(TempData["_errorMsg"]);
                    }
                    else
                    {
                        model.errorMessage = "NoMessage";
                    }

                    List<SelectListItem> li1 = new List<SelectListItem>();
                    //li1.Add(new SelectListItem { Text = "--Select--", Value = " " });
                    li1.Add(new SelectListItem { Text = "High", Value = "1" });
                    li1.Add(new SelectListItem { Text = "Medium", Value = "2" });
                    li1.Add(new SelectListItem { Text = "Low", Value = "3" });
                    ViewData["PriorityFlag"] = li1;

                    model.PolicyCode = "IsBackDateAllow";
                    model.PolicyApplicableStatus = GetPolicyApplicableStatus(model.PolicyCode);
                    model.CentreCode = centerCode;
                    model.PolicyAnswerByPolicyStatus = GetPolicyAnswerByPolicyStatus(model.CentreCode, model.PolicyApplicableStatus, model.PolicyCode);
                    model.PolicyDefaultAnswer = model.PolicyAnswerByPolicyStatus.Where(x => x.PolicyCode == model.PolicyCode).Select(x => x.PolicyDefaultAnswer).FirstOrDefault();

                    model.PolicyCode = "IsPurchaseRequirementbyExcelOrManual";
                    model.PolicyApplicableStatus = GetPolicyApplicableStatus(model.PolicyCode);
                    model.CentreCode = centerCode;
                    model.PolicyAnswerByPolicyStatus = GetPolicyAnswerByPolicyStatus(model.CentreCode, model.PolicyApplicableStatus, model.PolicyCode);
                    model.PolicyDefaultAnswerForExcel = model.PolicyAnswerByPolicyStatus.Where(x => x.PolicyCode == model.PolicyCode).Select(x => x.PolicyDefaultAnswer).FirstOrDefault();

                    //Code for Autogenerated Purchase requirement number.
                    //For Current Account Session
                    AccountSessionMasterViewModel model2 = new AccountSessionMasterViewModel();
                    model2.AccountSessionMasterDTO = new AccountSessionMaster();
                    model2.AccountSessionMasterDTO.ConnectionString = _connectioString;
                    IBaseEntityResponse<AccountSessionMaster> response2 = _accountSessionMasterBA.GetCurrentAccountSession(model2.AccountSessionMasterDTO);
                    model2.AccountSessionMasterDTO.ConnectionString = _connectioString;
                    if (response2 != null && response2.Entity != null)
                    {
                        model.PurchaseRequirementMasterDTO.FinancialYearID = response2.Entity.ID;
                    }
                    model.FinancialYearID = model.PurchaseRequirementMasterDTO.FinancialYearID;
                    model.CentreCode = centerCode;
                    model.Description = "Purchase Requirement Number";

                    model.PurchaseRequirementNumber = GetPurchaseRequirementNumber(model.CentreCode, model.Description, model.FinancialYearID);
                    //Code  End for Autogenerated Purchase requirement number.

                    //List For Location.
                    List<InventoryLocationMaster> locationMasterList = GetInventoryIssueLocationMasterList(Convert.ToInt32(Session["BalancesheetID"]));
                    List<SelectListItem> listLocationMaster = new List<SelectListItem>();
                    foreach (InventoryLocationMaster item in locationMasterList)
                    {
                        listLocationMaster.Add(new SelectListItem { Text = item.LocationName, Value = Convert.ToString(item.ID) });
                    }
                    ViewBag.GeneralLocationList = new SelectList(listLocationMaster, "Value", "Text");
                    if (model.PolicyDefaultAnswerForExcel == "1")
                    {
                        return View("/Views/Purchase/PurchaseRequirementMaster/Index1.cshtml", model);
                    }
                    else
                    {
                        return View("/Views/Purchase/PurchaseRequirementMaster/Index.cshtml", model);
                    }
                }
                catch (Exception ex)
                {
                    _logException.Error(ex.Message);
                    throw;
                }
            }
            else
            {
                return RedirectToAction("UnauthorizedAccess", "Home");
            }
        }
        [HttpGet]
        public ActionResult CreateExcel(string centerCode, string departmentIDs)
        {
            PurchaseRequirementMasterViewModel model = new PurchaseRequirementMasterViewModel();

            int AdminRoleMasterID = 0;
            if (!string.IsNullOrEmpty(centerCode))
            {
                string[] splitCentreCode = centerCode.Split(':');
                model.CentreCode = splitCentreCode[0];
                model.EntityLevel = splitCentreCode[1];
            }
            else
            {
                model.CentreCode = centerCode;
                model.EntityLevel = null;
            }

            if (Convert.ToString(Session["UserType"]) == "A")
            {
                //--------------------------------------For Centre Code list---------------------------------//
                List<OrganisationStudyCentreMaster> listAdminRoleApplicableDetails = GetListOrgStudyCentreMaster();
                AdminRoleApplicableDetails a = null;
                foreach (var item in listAdminRoleApplicableDetails)
                {
                    a = new AdminRoleApplicableDetails();
                    a.CentreCode = item.CentreCode;
                    a.CentreName = item.CentreName;
                    a.ScopeIdentity = item.ScopeIdentity;
                    model.ListGetAdminRoleApplicableCentre.Add(a);
                }
                model.EntityLevel = "Centre";

                foreach (var b in model.ListGetAdminRoleApplicableCentre)
                {
                    b.CentreCode = b.CentreCode + ":" + "Centre";
                }
            }
            else
            {
                if (Session["RoleID"] == null)
                {
                    AdminRoleMasterID = Convert.ToInt32(Session["DefaultRoleID"]);
                }
                else
                {
                    AdminRoleMasterID = Convert.ToInt32(Session["RoleID"]);
                }
                List<AdminRoleApplicableDetails> listAdminRoleApplicableDetails = GetAdminRoleApplicableCentre(AdminRoleMasterID, Convert.ToInt32(Session["PersonID"]));
                AdminRoleApplicableDetails a = null;
                foreach (var item in listAdminRoleApplicableDetails)
                {
                    a = new AdminRoleApplicableDetails();
                    a.CentreCode = item.CentreCode;
                    a.CentreName = item.CentreName;
                    a.ScopeIdentity = item.ScopeIdentity;
                    model.ListGetAdminRoleApplicableCentre.Add(a);
                }
                foreach (var b in model.ListGetAdminRoleApplicableCentre)
                {
                    b.CentreCode = b.CentreCode + ":" + b.ScopeIdentity;
                }
            }
            if (!string.IsNullOrEmpty(centerCode))
            {
                string[] splitCentreCode = centerCode.Split(':');
                model.ListGetOrganisationDepartmentCentreAndRoleWise = GetListOrganisationMasterCentreAndRoleWise(splitCentreCode[0], splitCentreCode[1], AdminRoleMasterID);
            }
            model.SelectedCentreCode = centerCode;
            if (departmentIDs != null)
                model.SelectedDepartmentIDs = departmentIDs.Substring(1);

            model.SelectedDepartmentID = model.SelectedDepartmentIDs;



            return PartialView("/Views/Purchase/PurchaseRequirementMaster/CreateExcel.cshtml", model);

        }
        public ActionResult List(string centerCode, string actionMode)
        {
            try
            {
                PurchaseRequirementMasterViewModel model = new PurchaseRequirementMasterViewModel();
                int AdminRoleMasterID = 0;
                if (!string.IsNullOrEmpty(centerCode))
                {
                    string[] splitCentreCode = centerCode.Split(':');
                    model.CentreCode = splitCentreCode[0];
                    model.EntityLevel = splitCentreCode[1];
                }
                else
                {
                    model.CentreCode = centerCode;
                    model.EntityLevel = null;
                }

                if (Convert.ToString(Session["UserType"]) == "A")
                {
                    //--------------------------------------For Centre Code list---------------------------------//
                    List<OrganisationStudyCentreMaster> listAdminRoleApplicableDetails = GetListOrgStudyCentreMaster();
                    AdminRoleApplicableDetails a = null;
                    foreach (var item in listAdminRoleApplicableDetails)
                    {
                        a = new AdminRoleApplicableDetails();
                        a.CentreCode = item.CentreCode;
                        a.CentreName = item.CentreName;
                        a.ScopeIdentity = item.ScopeIdentity;
                        model.ListGetAdminRoleApplicableCentre.Add(a);
                    }
                    model.EntityLevel = "Centre";

                    foreach (var b in model.ListGetAdminRoleApplicableCentre)
                    {
                        b.CentreCode = b.CentreCode + ":" + "Centre";
                    }
                }
                else
                {
                    if (Session["RoleID"] == null)
                    {
                        AdminRoleMasterID = Convert.ToInt32(Session["DefaultRoleID"]);
                    }
                    else
                    {
                        AdminRoleMasterID = Convert.ToInt32(Session["RoleID"]);
                    }
                    List<AdminRoleApplicableDetails> listAdminRoleApplicableDetails = GetAdminRoleApplicableCentreByPurchaseManager(AdminRoleMasterID);
                    AdminRoleApplicableDetails a = null;
                    foreach (var item in listAdminRoleApplicableDetails)
                    {
                        a = new AdminRoleApplicableDetails();
                        a.CentreCode = item.CentreCode;
                        a.CentreName = item.CentreName;
                        a.ScopeIdentity = item.ScopeIdentity;
                        model.ListGetAdminRoleApplicableCentre.Add(a);
                    }
                    foreach (var b in model.ListGetAdminRoleApplicableCentre)
                    {
                        b.CentreCode = b.CentreCode + ":" + b.ScopeIdentity;
                    }
                }
                if (!string.IsNullOrEmpty(centerCode))
                {
                    string[] splitCentreCode = centerCode.Split(':');
                    model.ListGetOrganisationDepartmentCentreAndRoleWise = GetListOrganisationMasterCentreAndRoleWise(splitCentreCode[0], splitCentreCode[1], AdminRoleMasterID);
                }
                model.SelectedCentreCode = centerCode;

                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Purchase/PurchaseRequirementMaster/List.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpGet]
        public ActionResult Create(string PurchaseRequirementMasterID)
        {
            try
            {
                PurchaseRequirementMasterViewModel model = new PurchaseRequirementMasterViewModel();
                string[] splitedCentreCode = PurchaseRequirementMasterID.Split(':');
                model.CentreCode = splitedCentreCode[0];
                // empEmployeeMastermodel.CentreName = splitedCentreCode[2];
                model.DepartmentID = Convert.ToInt32(splitedCentreCode[2]);


                List<SelectListItem> li1 = new List<SelectListItem>();
                //li1.Add(new SelectListItem { Text = "--Select--", Value = " " });
                li1.Add(new SelectListItem { Text = "High", Value = "1" });
                li1.Add(new SelectListItem { Text = "Medium", Value = "2" });
                li1.Add(new SelectListItem { Text = "Low", Value = "3" });
                ViewData["PriorityFlag"] = li1;


                model.PolicyCode = "IsBackDateAllow";
                model.PolicyApplicableStatus = GetPolicyApplicableStatus(model.PolicyCode);
                model.CentreCode = splitedCentreCode[0];
                model.PolicyAnswerByPolicyStatus = GetPolicyAnswerByPolicyStatus(model.CentreCode, model.PolicyApplicableStatus, model.PolicyCode);
                model.PolicyDefaultAnswer = model.PolicyAnswerByPolicyStatus.Where(x => x.PolicyCode == model.PolicyCode).Select(x => x.PolicyDefaultAnswer).FirstOrDefault();



                //List For Location.
                List<InventoryLocationMaster> locationMasterList = GetInventoryIssueLocationMasterList(Convert.ToInt32(Session["BalancesheetID"]));
                List<SelectListItem> listLocationMaster = new List<SelectListItem>();
                foreach (InventoryLocationMaster item in locationMasterList)
                {
                    listLocationMaster.Add(new SelectListItem { Text = item.LocationName, Value = Convert.ToString(item.ID) });
                }
                ViewBag.GeneralLocationList = new SelectList(listLocationMaster, "Value", "Text");


                return PartialView("/Views/Purchase/PurchaseRequirementMaster/Create.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }

        [HttpPost]
        public ActionResult Create(PurchaseRequirementMasterViewModel model)
        {
            try
            {


                if (model != null && model.PurchaseRequirementMasterDTO != null)
                {
                    model.PurchaseRequirementMasterDTO.ConnectionString = _connectioString;

                    model.PurchaseRequirementMasterDTO.PurchaseRequirementNumber = model.PurchaseRequirementNumber;
                    model.PurchaseRequirementMasterDTO.TransDate = model.TransDate;
                    model.PurchaseRequirementMasterDTO.CentreCode = model.SelectedCentreCode;
                    string[] splitedCentreCode = model.CentreCode.Split(':');
                    model.CentreCode = splitedCentreCode[0];
                    model.PurchaseRequirementMasterDTO.CentreCode = model.CentreCode;

                    model.PurchaseRequirementMasterDTO.DepartmentID = Convert.ToInt32(model.SelectedDepartmentID);
                    model.PurchaseRequirementMasterDTO.XMLstring = model.XMLstring;
                    model.PurchaseRequirementMasterDTO.IsActive = true;
                    model.PurchaseRequirementMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);

                    IBaseEntityResponse<PurchaseRequirementMaster> response = _PurchaseRequirementMasterBA.InsertPurchaseRequirementMaster(model.PurchaseRequirementMasterDTO);
                    if (response.Entity.ErrorCode == 10)
                    {
                        model.PurchaseRequirementMasterDTO.errorMessage = "You Don't have permission to create Requirement,warning";
                    }
                    else
                    {
                        model.PurchaseRequirementMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    }



                    // model.PurchaseRequirementMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.PurchaseRequirementMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public ActionResult Edit(int ID)
        {
            try
            {
                PurchaseRequirementMasterViewModel model = new PurchaseRequirementMasterViewModel();
                model.PurchaseRequirementMasterDTO = new PurchaseRequirementMaster();
                model.PurchaseRequirementMasterDTO.ID = ID;
                model.PurchaseRequirementMasterDTO.ConnectionString = _connectioString;

                //      IBaseEntityResponse<PurchaseRequirementMaster> response = _PurchaseRequirementMasterBA.SelectByID(model.PurchaseRequirementMasterDTO);

                //    if (response != null && response.Entity != null)
                //   {
                model.InventoryPurchaseRequirementList = GetPurchaseRequirementMasterList(ID);
                if (model.InventoryPurchaseRequirementList.Count > 0 && model.InventoryPurchaseRequirementList != null)
                {
                    model.PurchaseRequirementNumber = model.InventoryPurchaseRequirementList[0].PurchaseRequirementNumber;
                    model.TransDate = model.InventoryPurchaseRequirementList[0].TransDate;
                    //model.ItemID = model.InventoryPurchaseRequirementList[0].ItemID;
                    //model.ItemName = model.InventoryPurchaseRequirementList[0].ItemName;
                    //model.Rate = model.InventoryPurchaseRequirementList[0].Rate;
                    //model.Quantity = model.InventoryPurchaseRequirementList[0].Quantity;
                    //model.ExpectedDate = model.InventoryPurchaseRequirementList[0].ExpectedDate;
                    //model.PriorityFlag = model.InventoryPurchaseRequirementList[0].PriorityFlag;
                    //model.StorageLocationID = model.InventoryPurchaseRequirementList[0].StorageLocationID;
                    //model.ItemCount = model.InventoryPurchaseRequirementList[0].ItemCount;
                    //model.Status = model.InventoryPurchaseRequirementList[0].Status;
                    //model.ApprovedStatus = model.InventoryPurchaseRequirementList[0].ApprovedStatus;

                }

                //   }

                return PartialView("/Views/Purchase/PurchaseRequirementMaster/Edit.cshtml", model);

            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(PurchaseRequirementMasterViewModel model)
        {
            try
            {
                //if (ModelState.IsValid)
                //{
                if (model != null && model.PurchaseRequirementMasterDTO != null)
                {
                    if (model != null && model.PurchaseRequirementMasterDTO != null)
                    {
                        model.PurchaseRequirementMasterDTO.ConnectionString = _connectioString;
                        model.PurchaseRequirementMasterDTO.ID = model.ID;
                        model.PurchaseRequirementMasterDTO.XMLstring = model.XMLstring;
                        model.PurchaseRequirementMasterDTO.IsActive = false;
                        model.PurchaseRequirementMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<PurchaseRequirementMaster> response = _PurchaseRequirementMasterBA.UpdatePurchaseRequirementMaster(model.PurchaseRequirementMasterDTO);
                        model.PurchaseRequirementMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                        return Json(model.PurchaseRequirementMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
                    }
                    return Json(model.PurchaseRequirementMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
                }

                //}
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
        public ActionResult View(int id)
        {
            try
            {
                PurchaseRequirementMasterViewModel model = new PurchaseRequirementMasterViewModel();

                model.InventoryPurchaseRequirementList = GetPurchaseRequirementMasterList(id);
                if (model.InventoryPurchaseRequirementList.Count > 0 && model.InventoryPurchaseRequirementList != null)
                {
                    model.PurchaseRequirementNumber = model.InventoryPurchaseRequirementList[0].PurchaseRequirementNumber;
                    model.TransDate = model.InventoryPurchaseRequirementList[0].TransDate;
                    model.ItemID = model.InventoryPurchaseRequirementList[0].ItemID;
                    model.ItemName = model.InventoryPurchaseRequirementList[0].ItemName;
                    model.Quantity = model.InventoryPurchaseRequirementList[0].Quantity;
                    model.ExpectedDate = model.InventoryPurchaseRequirementList[0].ExpectedDate;
                    model.PriorityFlag = model.InventoryPurchaseRequirementList[0].PriorityFlag;
                }

                return PartialView("/Views/Purchase/PurchaseRequirementMaster/View.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public ActionResult CreateExcel(PurchaseRequirementMasterViewModel model)
        {
            try
            {

                if (model != null && model.PurchaseRequirementMasterDTO != null)
                {
                    UploadQuestionFile1();
                    model.PurchaseRequirementMasterDTO.ConnectionString = _connectioString;


                    model.PurchaseRequirementMasterDTO.PurchaseRequirementNumber = model.PurchaseRequirementNumber;
                    model.PurchaseRequirementMasterDTO.TransDate = model.TransDate;

                    if (model.SelectedCentreCode == null || model.SelectedCentreCode == "")
                    {
                        errorMessage = "please select Centre ,warning";

                    }
                    else
                    {
                        model.PurchaseRequirementMasterDTO.CentreCode = model.SelectedCentreCode;
                        string[] splitedCentreCode = model.CentreCode.Split(':');
                        model.CentreCode = splitedCentreCode[0];
                        model.PurchaseRequirementMasterDTO.CentreCode = model.CentreCode;
                    }

                    model.PurchaseRequirementMasterDTO.DepartmentID = Convert.ToInt32(model.SelectedDepartmentID);
                    model.PurchaseRequirementMasterDTO.XMLstring = xmlParameter; ;
                    model.PurchaseRequirementMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    model.PurchaseRequirementMasterDTO.errorMessage = errorMessage;
                    if (model.SelectedCentreCode == null || model.SelectedCentreCode == "")
                    {
                        errorMessage = "please select Centre ,warning";

                    }

                    else
                    {
                        if (model.SelectedDepartmentID == "" || model.SelectedDepartmentID == null || model.SelectedDepartmentID == "0")
                        {
                            errorMessage = "please select Department ,warning";
                            model.PurchaseRequirementMasterDTO.errorMessage = errorMessage;
                        }
                        else
                        {
                            if (xmlParameter != string.Empty && xmlParameter != null && IsExcelValid == true)
                            {
                                IBaseEntityResponse<PurchaseRequirementMaster> response = _PurchaseRequirementMasterBA.InsertPurchaseRequirementMasterByExcel(model.PurchaseRequirementMasterDTO);
                                if (response.Entity.ErrorCode == 10)
                                {
                                    model.PurchaseRequirementMasterDTO.errorMessage = "You are not authorised to create Requirement,warning";
                                }
                                else
                                {

                                    model.PurchaseRequirementMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                                }
                            }
                            else if (IsExcelValid == false)
                            {
                                model.PurchaseRequirementMasterDTO.errorMessage = errorMessage;// "Invalide excel column,#FFCC80";
                            }
                            else if (xmlParameter == string.Empty || xmlParameter != null)
                            {
                                model.PurchaseRequirementMasterDTO.errorMessage = errorMessage;// "No data found in excel,#FFCC80";
                            }
                        }
                    }

                    TempData["_errorMsg"] = model.PurchaseRequirementMasterDTO.errorMessage;
                    xmlParameter = null;
                    IsExcelValid = true;
                    errorMessage = null;
                    return RedirectToAction("Index", "PurchaseRequirementMaster");
                }
                else
                {
                    return Json("Please review your form");
                }
            }

            catch (Exception)
            {
                throw;
            }
        }
       

        [HttpGet]
        public ActionResult PurchaseRequirementRequestApproval(int PersonID, string TNDID, string TNMID, string GTRDID1, string TaskCode, string StageSequenceNumber, string IsLast)
        {
            PurchaseRequirementMasterViewModel model = new PurchaseRequirementMasterViewModel();
            model.PersonID = Convert.ToInt32(PersonID);
            model.TaskNotificationDetailsID = Convert.ToInt32(TNDID);
            model.TaskNotificationMasterID = Convert.ToInt32(TNMID);
            model.GeneralTaskReportingDetailsID = Convert.ToInt32(GTRDID1);
            model.TaskCode = TaskCode;
            model.StageSequenceNumber = Convert.ToInt32(StageSequenceNumber);
            model.IsLastRecord = Convert.ToBoolean(IsLast);
            model.InventoryPurchaseRequirementList = GetPurchaseRequirementRecord(PersonID, Convert.ToInt32(TNMID), model.GeneralTaskReportingDetailsID);
            model.ID = model.InventoryPurchaseRequirementList.Count > 0 ? model.InventoryPurchaseRequirementList[0].ID : 0;
            model.TransDate = model.InventoryPurchaseRequirementList.Count > 0 ? model.InventoryPurchaseRequirementList[0].TransDate : null;
            model.PurchaseRequirementNumber = model.InventoryPurchaseRequirementList.Count > 0 ? model.InventoryPurchaseRequirementList[0].PurchaseRequirementNumber : null;

            return View("/Views/Purchase/PurchaseRequirementMaster/PurchaseRequirementRequestApprovalV2.cshtml", model);
        }

        [HttpPost]
        public ActionResult PurchaseRequirementRequestApprovalV2(PurchaseRequirementMasterViewModel model)
        {
            try
            {

                if (model != null && model.PurchaseRequirementMasterDTO != null)
                {
                    model.PurchaseRequirementMasterDTO.ConnectionString = _connectioString;
                    model.PurchaseRequirementMasterDTO.PersonID = model.PersonID;
                    model.PurchaseRequirementMasterDTO.ID = model.ID;
                    model.PurchaseRequirementMasterDTO.XMLstring = model.XMLstring;
                    model.PurchaseRequirementMasterDTO.IsLastRecord = Convert.ToBoolean(model.IsLastRecord);
                    model.PurchaseRequirementMasterDTO.TaskNotificationMasterID = model.TaskNotificationMasterID;
                    model.PurchaseRequirementMasterDTO.TaskNotificationDetailsID = model.TaskNotificationDetailsID;
                    model.PurchaseRequirementMasterDTO.GeneralTaskReportingDetailsID = model.GeneralTaskReportingDetailsID;
                    model.PurchaseRequirementMasterDTO.StageSequenceNumber = model.StageSequenceNumber;
                    model.PurchaseRequirementMasterDTO.ApprovedStatus = model.ApprovedStatus;
                    model.PurchaseRequirementMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<PurchaseRequirementMaster> response = _PurchaseRequirementMasterBA.InsertApprovedPurchaseRequirementRecord(model.PurchaseRequirementMasterDTO);
                    model.PurchaseRequirementMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.PurchaseRequirementMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);

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

        public FileResult Download()
        {
            string FileName = "PurchaseRequirement.xlsx";
            string filePath = Path.Combine(Server.MapPath("~") + "Content\\DownloadFiles\\", FileName);
            string contentType = "application/vnd.ms-excel";
            return File(filePath, contentType, FileName);
        }

        [AcceptVerbs(HttpVerbs.Post)]

        public void UploadQuestionFile1()
        {
            string _ExcelFileXML = string.Empty;
            //   string XMLstring = string.Empty;
            var _comPath = "";
            if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
            {
                var ExcelFile = System.Web.HttpContext.Current.Request.Files["MyFile"];
                if (ExcelFile.ContentLength > 0)
                {
                    string extension = System.IO.Path.GetExtension(ExcelFile.FileName);
                    _comPath = Server.MapPath("~") + "Content\\UploadedFiles\\UplodedExcel\\";
                    string filePath = string.Format("{0}/{1}", _comPath, ExcelFile.FileName);
                    if (!Directory.Exists(_comPath))
                    {
                        Directory.CreateDirectory(_comPath);
                    }
                    if (System.IO.File.Exists(filePath))
                        System.IO.File.Delete(filePath);

                    ExcelFile.SaveAs(filePath);

                    //Create connection string to Excel work book
                    // string excelConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path1 + ";Extended Properties=Excel 12.0;Persist Security Info=False";


                    ////Create Connection to Excel work book
                    //OleDbConnection excelConnection = new OleDbConnection(excelConnectionString);
                    //excelConnection.Open();
                    ////Create OleDbCommand to fetch data from Excel
                    ////OleDbCommand cmd = new OleDbCommand("Select [StudentFirstName],[StudentMiddelName],[StudentLastName],[StudentMobileNo],[StudentEmailID],[Source],[SourceContactPerson] from [Sheet1$]", excelConnection);
                    //DataTable dtExcelSchema;

                    //dtExcelSchema = excelConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                    //string SheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();

                    //OleDbCommand cmd = new OleDbCommand("Select * from [" + SheetName + "]", excelConnection);

                    ////  excelConnection.Open();
                    //OleDbDataReader dReader;
                    //dReader = cmd.ExecuteReader();
                    xmlParameter = "<rows>";
                    //Open the Excel file in Read Mode using OpenXml.
                    using (SpreadsheetDocument doc = SpreadsheetDocument.Open(filePath, false))
                    {
                        //Read the first Sheet from Excel file.
                        Sheet sheet = doc.WorkbookPart.Workbook.Sheets.GetFirstChild<Sheet>();

                        //Get the Worksheet instance.
                        Worksheet worksheet = (doc.WorkbookPart.GetPartById(sheet.Id.Value) as WorksheetPart).Worksheet;

                        //Fetch all the rows present in the Worksheet.
                        // IEnumerable<Row> rows = worksheet.GetFirstChild<SheetData>().Descendants<Row>();
                        SheetData rows = worksheet.GetFirstChild<SheetData>();

                        DataTable dt = new DataTable();
                        //Loop through the Worksheet rows.


                        foreach (Cell cell in rows.ElementAt(0))
                        {
                            dt.Columns.Add(GetCellValue(doc, cell));
                        }
                        foreach (Row row in rows)
                        {
                            DataRow tempRow = dt.NewRow();
                            int columnIndex = 0;
                            foreach (Cell cell in row.Descendants<Cell>())
                            {
                                // Gets the column index of the cell with data

                                int cellColumnIndex = (int)GetColumnIndexFromName(GetColumnName(cell.CellReference));

                                cellColumnIndex--; //zero based index
                                if (columnIndex < cellColumnIndex)
                                {
                                    do
                                    {
                                        tempRow[columnIndex] = ""; //Insert blank data here;
                                        columnIndex++;
                                    }
                                    while (columnIndex < cellColumnIndex);
                                }
                                tempRow[columnIndex] = GetCellValue(doc, cell);

                                columnIndex++;
                            }
                            dt.Rows.Add(tempRow);
                        }
                        dt.Rows.RemoveAt(0); //...so i'm taking it out here.

                        RemoveDuplicateRows(dt, "ItemName");




                        if (extension == ".xls" || extension == ".xlsx")
                        {
                            if (
                                dt.Columns[0].ColumnName != "ItemName" ||
                                dt.Columns[1].ColumnName != "Rate" ||
                                dt.Columns[2].ColumnName != "Quantity" ||
                                dt.Columns[3].ColumnName != "ExpectedDate" ||
                                dt.Columns[4].ColumnName != "PriorityFlag" ||
                                dt.Columns[5].ColumnName != "StorageLocationID" ||
                                dt.Columns[6].ColumnName != "Remark"
                                )
                            {
                                IsExcelValid = false;
                                errorMessage = "Invalid excel column,#FFCC80";
                            }

                            if (IsExcelValid == true)
                            {
                                long result;


                                //while (dReader.Read())
                                for (int i = 0; i < (dt.Rows.Count); i++)
                                {
                                    //if (long.TryParse(dt.Rows[i]["StudentMobileNo"].ToString().Trim(), out result))
                                    //{

                                    double d = double.Parse(dt.Rows[i]["ExpectedDate"].ToString());
                                    DateTime conv = DateTime.FromOADate(d);
                                    string date = conv.ToString("yyyy-MM-dd");

                                    if (!ValidateDate(date))
                                    {
                                        int RowNo = i + 2;
                                        // ScriptManager.RegisterStartupScript(Page, Page.GetType(), "InvalidArgs", "alert('Wrong Date format in row " + RowNo + "');", true);
                                        TempData["Message"] = "You are not authorized.";
                                        return;
                                    }

                                    if (dt.Rows[i]["ItemName"].ToString().Trim().Length > 1)
                                    {

                                        xmlParameter = xmlParameter + "<row><ID>" + 0 + "</ID><ItemName>" + dt.Rows[i]["ItemName"].ToString().Trim() + "</ItemName><Rate>" + dt.Rows[i]["Rate"].ToString().Trim() + "</Rate><Quantity>" + dt.Rows[i]["Quantity"].ToString().Trim() + "</Quantity><ExpectedDate>" + date + "</ExpectedDate><PriorityFlag>" + dt.Rows[i]["PriorityFlag"].ToString().Trim() + "</PriorityFlag><StorageLocationID>" + dt.Rows[i]["StorageLocationID"].ToString().Trim() + "</StorageLocationID><Remark>" + dt.Rows[i]["Remark"].ToString().Trim() + "</Remark></row>";
                                    }
                                    //}
                                }
                                if (xmlParameter.Length > 9)
                                {
                                    xmlParameter = xmlParameter + "</rows>";
                                }
                                else
                                {
                                    xmlParameter = string.Empty;
                                    errorMessage = "No data found in excel,#FFCC80";
                                }
                            }
                        }
                        else
                        {
                            errorMessage = "The selected file does not appear to be an excel file,#FFCC80";
                        }
                        dt.Dispose();
                    }

                    // excelConnection.Close();

                    // SQL Server Connection String
                }
                else
                {
                    errorMessage = "Excel file not selected,#FFCC80";
                }
            }

        }

        private bool ValidateDate(string date)
        {
            try
            {
                string[] dateParts = date.Split('-');
                DateTime testDate = new DateTime(Convert.ToInt32(dateParts[0]), Convert.ToInt32(dateParts[1]), Convert.ToInt32(dateParts[2]));
                return true;
            }
            catch
            {
                return false;
            }
        }

        public DataTable RemoveDuplicateRows(DataTable dTable, string colName)
        {
            Hashtable hTable = new Hashtable();
            ArrayList duplicateList = new ArrayList();

            //Add list of all the unique item value to hashtable, which stores combination of key, value pair.
            //And add duplicate item value in arraylist.
            foreach (DataRow drow in dTable.Rows)
            {
                if (hTable.Contains(drow[colName]) || hTable.Contains(""))
                    duplicateList.Add(drow);
                else
                    hTable.Add(drow[colName], string.Empty);
            }

            //Removing a list of duplicate items from datatable.
            foreach (DataRow dRow in duplicateList)
                dTable.Rows.Remove(dRow);

            //Datatable which contains unique records will be return as output.
            return dTable;
        }
        /// <summary>
        /// Given a cell name, parses the specified cell to get the column name.
        /// </summary>
        /// <param name="cellReference">Address of the cell (ie. B2)</param>
        /// <returns>Column Name (ie. B)</returns>
        public static string GetColumnName(string cellReference)
        {
            // Create a regular expression to match the column name portion of the cell name.
            Regex regex = new Regex("[A-Za-z]+");
            Match match = regex.Match(cellReference);
            return match.Value;
        }
        /// <summary>
        /// Given just the column name (no row index), it will return the zero based column index.
        /// Note: This method will only handle columns with a length of up to two (ie. A to Z and AA to ZZ). 
        /// A length of three can be implemented when needed.
        /// </summary>
        /// <param name="columnName">Column Name (ie. A or AB)</param>
        /// <returns>Zero based index if the conversion was successful; otherwise null</returns>
        public static int? GetColumnIndexFromName(string columnName)
        {

            //return columnIndex;
            string name = columnName;
            int number = 0;
            int pow = 1;
            for (int i = name.Length - 1; i >= 0; i--)
            {
                number += (name[i] - 'A' + 1) * pow;
                pow *= 26;
            }
            return number;
        }
        public static string GetCellValue(SpreadsheetDocument document, Cell cell)
        {
            SharedStringTablePart stringTablePart = document.WorkbookPart.SharedStringTablePart;
            if (cell.CellValue == null)
            {
                return "";
            }
            string value = cell.CellValue.InnerXml;
            if (cell.DataType != null && cell.DataType.Value == CellValues.SharedString)
            {
                return stringTablePart.SharedStringTable.ChildElements[Int32.Parse(value)].InnerText;
            }
            else
            {
                return value;
            }
        }

        //[AcceptVerbs(HttpVerbs.Get)]
        //public ActionResult GetUniversityByCentreCode(string SelectedCentreCode)
        //{
        //    //string[] splited;
        //    //splited = SelectedCentreCode.Split(':');
        //    //_PurchaseRequirementMasterViewModel.SelectedCentreName = splited[1];
        //    //SelectedCentreCode = splited[0];
        //    //if (String.IsNullOrEmpty(SelectedCentreCode))
        //    //{
        //    //    throw new ArgumentNullException("SelectedCentreCode");
        //    //}
        //    //int id = 0;
        //    //bool isValid = Int32.TryParse(SelectedCentreCode, out id);
        //    var university = GetListOrganisationUniversityMaster(SelectedCentreCode);
        //    var result = (from s in university
        //                  select new
        //                  {
        //                      id = s.ID,
        //                      name = s.UniversityName,
        //                  }).ToList();
        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}

        public ActionResult GetDepartmentByCentreCode(string SelectedCentreCode)
        {
            int AdminRoleMasterID = 0;
            if (Convert.ToString(Session["UserType"]) == "A")
            {
                AdminRoleMasterID = 0;
            }
            else
            {
                if (Session["RoleID"] == null)
                {
                    AdminRoleMasterID = Convert.ToInt32(Session["DefaultRoleID"]);
                }
                else
                {
                    AdminRoleMasterID = Convert.ToInt32(Session["RoleID"]);
                }
            }
            string[] splited = SelectedCentreCode.Split(':');
            if (String.IsNullOrEmpty(SelectedCentreCode))
            {
                throw new ArgumentNullException("SelectedCentreCode");
            }
            int id = 0;
            bool isValid = Int32.TryParse(SelectedCentreCode, out id);
            var department = GetListOrganisationMasterCentreAndRoleWise(splited[0], splited[1], AdminRoleMasterID);
            var result = (from s in department
                          select new
                          {
                              id = s.ID,
                              name = s.DepartmentName,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [NonAction]
        protected List<PurchaseRequirementMaster> GetPurchaseRequirementMasterList(int id)
        {
            PurchaseRequirementMasterSearchRequest searchRequest = new PurchaseRequirementMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.ID = id;
            List<PurchaseRequirementMaster> listPurchaseRequirementMaster = new List<PurchaseRequirementMaster>();
            IBaseEntityCollectionResponse<PurchaseRequirementMaster> baseEntityCollectionResponse = _PurchaseRequirementMasterBA.GetPurchaseRequirementMasterDetailList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listPurchaseRequirementMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listPurchaseRequirementMaster;
        }
        [NonAction]
        protected List<PurchaseRequirementMaster> GetPurchaseRequirementRecord(int personId, int taskNotificationMasterID, int GeneralTaskReportingDetailsID )
        {
            PurchaseRequirementMasterSearchRequest searchRequest = new PurchaseRequirementMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.PersonID = personId;
            searchRequest.TaskNotificationMasterID = taskNotificationMasterID;
            searchRequest.GeneralTaskReportingDetailsID = GeneralTaskReportingDetailsID;
            List<PurchaseRequirementMaster> listDumpAndShrinkDetails = new List<PurchaseRequirementMaster>();
            IBaseEntityCollectionResponse<PurchaseRequirementMaster> baseEntityCollectionResponse = _PurchaseRequirementMasterBA.GetPurchaseRequirementForApproval(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listDumpAndShrinkDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listDumpAndShrinkDetails;
        }
        //Code for Get Policy Applicable status
        protected string GetPolicyApplicableStatus(string PolicyCode)
        {
            try
            {
                IGeneralPolicyRulesViewModel model = new GeneralPolicyRulesViewModel();
                model.GeneralPolicyRulesDTO = new GeneralPolicyRules();
                model.GeneralPolicyRulesDTO.ConnectionString = _connectioString;
                model.GeneralPolicyRulesDTO.PolicyCode = PolicyCode;
                IBaseEntityResponse<GeneralPolicyRules> response = _GeneralPolicyRulesBA.GetPolicyApplicableStatus(model.GeneralPolicyRulesDTO);
                return (response != null && response.Entity != null) ? response.Entity.PolicyApplicableStatus : string.Empty;
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }
        //Code for Get GetPurchase Requirement Number
        protected string GetPurchaseRequirementNumber(string CentreCode, string Description, int FinancialYearID)
        {
            try
            {
                IGeneralRunningNumbersForAccountViewModel model = new GeneralRunningNumbersForAccountViewModel();
                model.GeneralRunningNumbersForAccountDTO = new GeneralRunningNumbersForAccount();
                model.GeneralRunningNumbersForAccountDTO.ConnectionString = _connectioString;
                model.GeneralRunningNumbersForAccountDTO.CentreCode = "SL-101";
                model.GeneralRunningNumbersForAccountDTO.Description = Description;
                model.GeneralRunningNumbersForAccountDTO.FinancialYearID = Convert.ToInt16(FinancialYearID);
                IBaseEntityResponse<GeneralRunningNumbersForAccount> response = _GeneralRunningNumbersForAccountBA.GetAutoGeneratedRequirementNumber(model.GeneralRunningNumbersForAccountDTO);
                return (response != null && response.Entity != null) ? response.Entity.DisplayFormat : string.Empty;
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }
        // get policy answer
        protected List<GeneralPolicyRules> GetPolicyAnswerByPolicyStatus(string CentreCode, string PolicyApplicableStatus, string PolicyCode)
        {
            GeneralPolicyRulesSearchRequest searchRequest = new GeneralPolicyRulesSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.PolicyApplicableStatus = PolicyApplicableStatus;
            searchRequest.centreCode = CentreCode;
            searchRequest.PolicyCode = PolicyCode;
            List<GeneralPolicyRules> listInWardMasterAndInWardDetails = new List<GeneralPolicyRules>();

            IBaseEntityCollectionResponse<GeneralPolicyRules> baseEntityCollectionResponse = _GeneralPolicyRulesBA.GetPolicyAnswerByPolicyStatus(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listInWardMasterAndInWardDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listInWardMasterAndInWardDetails;
        }

        [NonAction]
        protected List<InventoryLocationMaster> GetInventoryIssueLocationMasterList(int balancesheet)
        {
            InventoryLocationMasterSearchRequest searchRequest = new InventoryLocationMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.AccBalanceSheetID = Convert.ToInt16(balancesheet);
            List<InventoryLocationMaster> listLocationMaster = new List<InventoryLocationMaster>();
            IBaseEntityCollectionResponse<InventoryLocationMaster> baseEntityCollectionResponse = _InventoryLocationMasterBA.GetInventoryLocationMasterSearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listLocationMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listLocationMaster;
        }

        [HttpPost]
        public JsonResult GetItemSearchList(string term, string StorageLocationID)
        {
            GeneralItemMasterSearchRequest searchRequest = new GeneralItemMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            //   searchRequest.LocationID = Convert.ToInt32(!string.IsNullOrEmpty(StorageLocationID) ? StorageLocationID : null);
            searchRequest.SearchWord = term;
            List<GeneralItemMaster> listFeeSubType = new List<GeneralItemMaster>();
            IBaseEntityCollectionResponse<GeneralItemMaster> baseEntityCollectionResponse = _generalItemMasterBA.GetGeneralItemDetailsForSupliersDataSearchList(searchRequest);
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
                              itemNumber = r.ItemNumber,
                              //itemDescription = String.Concat(r.ItemDescription, '(', r.UomCode, ')'),
                              itemDescription = r.ItemDescription,
                              barCode = r.BarCode,
                              uomCode = r.UomCode,
                              lastPurchasePrice = r.LastPurchasePrice,
                              genTaxGroupMasterID = r.GenTaxGroupMasterID,
                              generalItemCodeID = r.GeneralItemCodeID,
                              id = r.GeneralItemMasterID,
                              PurchaseGroupCode = r.PurchaseGroupCode,
                              MinimumOrderquantity = r.MinimumOrderquantity,

                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult CheckForBlockForProcurement(int ItemNumber, int StorageLocationID)
        {
            bool _BlockForProcurement = false;
            if (StorageLocationID > 0 && ItemNumber > 0)
            {
                PurchaseRequirementMaster _PurchaseRequirementMaster = new PurchaseRequirementMaster();
                _PurchaseRequirementMaster.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
                _PurchaseRequirementMaster.StorageLocationID = StorageLocationID;
                _PurchaseRequirementMaster.ItemNumber = ItemNumber;
                IBaseEntityResponse<PurchaseRequirementMaster> response = _PurchaseRequirementMasterBA.GetBlockForProcurementByLocationID(_PurchaseRequirementMaster);
                if (response != null && response.Entity != null)
                {
                    _BlockForProcurement = response.Entity.BlockforProcurutment;
                }

            }
            return Json(Convert.ToString(_BlockForProcurement), JsonRequestBehavior.AllowGet);
        }

        #region Methods

        [NonAction]
        protected IEnumerable<PurchaseRequirementMasterViewModel> GetPurchaseRequirement(string CentreCode, string EntityLevel, string AdminRoleMasterID, out int TotalRecords)
        {

            PurchaseRequirementMasterSearchRequest searchRequest = new PurchaseRequirementMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            _actionMode = Convert.ToString(TempData["ActionMode"]);
            if (Enum.TryParse(_actionMode, out actionModeEnum))     // checks actionMode i.e. Insert or Update // 
            {
                if (actionModeEnum == ActionModeEnum.Insert)        // parameters for SelectAll procedures under Insert or Update mode condition
                {
                    searchRequest.SortBy = "DepartmentID,PurchaseRequirementNumber";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                    searchRequest.CentreCode = CentreCode;
                    searchRequest.EntityLevel = EntityLevel;
                    searchRequest.AdminRoleMasterID = Convert.ToInt32(AdminRoleMasterID);
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "ModifiedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                    searchRequest.CentreCode = CentreCode;
                    searchRequest.EntityLevel = EntityLevel;
                    searchRequest.AdminRoleMasterID = Convert.ToInt32(AdminRoleMasterID);
                }
            }
            else
            {
                searchRequest.SortBy = _sortBy;                     // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;
                searchRequest.CentreCode = CentreCode;
                searchRequest.EntityLevel = EntityLevel;
                searchRequest.AdminRoleMasterID = Convert.ToInt32(AdminRoleMasterID);
            }
            List<PurchaseRequirementMasterViewModel> listPurchaseRequirementMasterViewModel = new List<PurchaseRequirementMasterViewModel>();
            List<PurchaseRequirementMaster> listPurchaseRequirementMaster = new List<PurchaseRequirementMaster>();
            IBaseEntityCollectionResponse<PurchaseRequirementMaster> baseEntityCollectionResponse = _PurchaseRequirementMasterBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listPurchaseRequirementMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (PurchaseRequirementMaster item in listPurchaseRequirementMaster)
                    {
                        PurchaseRequirementMasterViewModel PurchaseRequirementMasterViewModel = new PurchaseRequirementMasterViewModel();
                        PurchaseRequirementMasterViewModel.PurchaseRequirementMasterDTO = item;
                        listPurchaseRequirementMasterViewModel.Add(PurchaseRequirementMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listPurchaseRequirementMasterViewModel;
        }

        #endregion


        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param, string SelectedCentreCode, string EntityLevel)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<PurchaseRequirementMasterViewModel> filteredPurchaseRequirementMaster;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    //_sortBy = "DepartmentID,PurchaseRequirementNumber";
                    _sortBy = "DepartmentID,PurchaseRequirementNumber";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        //_searchBy = "cte2.PurchaseRequirementNumber like '%'";
                        _searchBy = string.Empty;
                    }
                    else
                    {

                        _searchBy = "PurchaseRequirementNumber Like '%" + param.sSearch + "%' or TransDate Like '%" + param.sSearch + "%'";
                        //_searchBy = "PurchaseRequirementNumber like '%'";//this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "DepartmentName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "PurchaseRequirementNumber Like '%" + param.sSearch + "%' or TransDate Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 2:
                    _sortBy = "DepartmentID,PurchaseRequirementNumber";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "PurchaseRequirementNumber Like '%" + param.sSearch + "%' or TransDate Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            if (!string.IsNullOrEmpty(SelectedCentreCode))
            {
                string[] splitCentreCode = SelectedCentreCode.Split(':');
                var centreCode = splitCentreCode[0];
                var scopeIdentity = splitCentreCode[1];
                var RoleID = "";
                if (Session["UserType"].ToString() == "A")
                {
                    RoleID = Convert.ToString(0);
                }
                else
                {
                    RoleID = Session["RoleID"].ToString();
                }
                filteredPurchaseRequirementMaster = GetPurchaseRequirement(centreCode, EntityLevel, RoleID, out TotalRecords);
            }
            else
            {
                filteredPurchaseRequirementMaster = new List<PurchaseRequirementMasterViewModel>();
                TotalRecords = 0;
            }
            var records = filteredPurchaseRequirementMaster.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.Quantity), Convert.ToString(c.CreatedDate), Convert.ToString(c.DepartmentName), Convert.ToString(c.ApprovedDate), Convert.ToString(c.PurchaseRequirementNumber), Convert.ToString(c.DepartmentID), Convert.ToString(c.ID), Convert.ToString(c.CentreCode), Convert.ToString(c.ApprovedStatus), Convert.ToString(c.Remark), Convert.ToString(c.StorageLocationID), Convert.ToString(c.TransDate), Convert.ToString(c.PurchaseRequirementMasterDTO), Convert.ToString(c.Status), Convert.ToString(c.ItemCount) };

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion


    }
}