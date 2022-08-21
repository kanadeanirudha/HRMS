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
using System.Web;
using System.Data;
using System.Web.Hosting;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Text.RegularExpressions;
using System.Collections;
using DocumentFormat.OpenXml.Validation;
using System.Web.Helpers;

namespace AERP.Web.UI.Controllers
{
    public class SaleContractEmployeeMasterController : BaseController
    {
        ISaleContractEmployeeMasterBA _SaleContractEmployeeMasterBA = null;
        IESICZoneMasterBA _ESICZoneMasterBA = null;

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
        static string xmlParameter = null;
        static bool IsExcelValid = true;
        static string errorMessage = null;
        int EmpCodeFlag;
        int FirstNameFlag;
        int LastNameFlag; int CentreCodeFlag;

        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public SaleContractEmployeeMasterController()
        {
            _SaleContractEmployeeMasterBA = new SaleContractEmployeeMasterBA();
            _ESICZoneMasterBA = new ESICZoneMasterBA();

        }

        #region Controller Methods

        /// <summary>
        /// First Load When controller call List Method
        /// </summary>
        /// <returns>view</returns>
        [HttpGet]
        public ActionResult Index(string centerCode)
        {
            bool IsApplied = CheckMenuApplicableOrNot(ControllerContext.RouteData.Values["Controller"].ToString());
            if (Convert.ToString(Session["UserType"]) == "A" || (Convert.ToInt32(Session["Sales Manager"]) > 0 && IsApplied == true))
            {
                SaleContractEmployeeMasterViewModel model = new SaleContractEmployeeMasterViewModel();
                if (!string.IsNullOrEmpty(centerCode))
                {
                    string[] splitCentreCode = centerCode.Split(':');
                    model.CentreCode = splitCentreCode[0];
                    //centerCode = splitCentreCode[0];
                }
                else
                {
                    model.CentreCode = centerCode;

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
                    model.CentreCode = centerCode;
                    foreach (var b in model.ListGetAdminRoleApplicableCentre)
                    {
                        b.CentreCode = b.CentreCode;
                    }
                }
                else
                {
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
                    if (Convert.ToInt32(Session["Admin Manager"]) > 0)
                    {
                        listAdminRoleApplicableDetails = GetAdminRoleApplicableCentreByAcademicManager(AdminRoleMasterID);
                    }
                    else
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
                        model.ListGetAdminRoleApplicableCentre.Add(a);
                    }
                    foreach (var b in model.ListGetAdminRoleApplicableCentre)
                    {
                        b.CentreCode = b.CentreCode;
                    }
                }
                if (TempData["_errorMsg"] != null)
                {
                    model.errorMessage = Convert.ToString(TempData["_errorMsg"]);
                }
                else
                {
                    model.errorMessage = "NoMessage";
                }


                return View("/Views/Contract/SaleContractEmployeeMaster/Index.cshtml", model);
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
                SaleContractEmployeeMasterViewModel _SaleContractEmployeeMasterViewModel = new SaleContractEmployeeMasterViewModel();
                _SaleContractEmployeeMasterViewModel.CentreCode = centerCode;


                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Contract/SaleContractEmployeeMaster/List.cshtml", _SaleContractEmployeeMasterViewModel);

            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpGet]
        public ActionResult Create(string CentreCode)
        {
            SaleContractEmployeeMasterViewModel model = new SaleContractEmployeeMasterViewModel();
            try
            {
                List<GeneralTitleMaster> GeneralTitleMasterList = GetListGeneralTitleMaster();
                List<SelectListItem> ListGeneralTitleMaster = new List<SelectListItem>();
                foreach (GeneralTitleMaster item in GeneralTitleMasterList)
                {
                    ListGeneralTitleMaster.Add(new SelectListItem { Text = item.NameTitle, Value = item.NameTitle.ToString() });
                }
                ViewBag.GeneralTitleMasterList = new SelectList(ListGeneralTitleMaster, "Value", "Text");
                model.CentreCode = CentreCode;

                return PartialView("/Views/Contract/SaleContractEmployeeMaster/Create.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public ActionResult Create(SaleContractEmployeeMasterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.SaleContractEmployeeMasterDTO != null)
                    {
                        model.SaleContractEmployeeMasterDTO.ConnectionString = _connectioString;
                        model.SaleContractEmployeeMasterDTO.Title = model.Title;
                        model.SaleContractEmployeeMasterDTO.FirstName = model.FirstName;
                        model.SaleContractEmployeeMasterDTO.MiddleName = model.MiddleName;
                        model.SaleContractEmployeeMasterDTO.LastName = model.LastName;
                        model.SaleContractEmployeeMasterDTO.FirstJoiningDate = model.FirstJoiningDate;
                        model.SaleContractEmployeeMasterDTO.LeftDate = model.LeftDate;
                        model.SaleContractEmployeeMasterDTO.IsLeft = model.IsLeft;
                        model.SaleContractEmployeeMasterDTO.CentreCode = model.CentreCode;
                        model.SaleContractEmployeeMasterDTO.EmployeeCode = model.EmployeeCode;

                        model.SaleContractEmployeeMasterDTO.CreatedBy = Convert.ToInt32(Session["UserId"]);

                        IBaseEntityResponse<SaleContractEmployeeMaster> response = _SaleContractEmployeeMasterBA.InsertSaleContractEmployeeMaster(model.SaleContractEmployeeMasterDTO);

                        if (response.Entity.ErrorCode == 111)
                        {
                            string errorMessage = "Employee Code is already created and assigned to other Employee";// "Record already exists";
                            string colorCode = "warning";
                            string mode = string.Empty;
                            string[] arrayList = { errorMessage, colorCode, mode };
                            model.SaleContractEmployeeMasterDTO.errorMessage = string.Join(",", arrayList);
                        }
                        else
                        {
                            model.SaleContractEmployeeMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                        }
                    }
                    return Json(model.SaleContractEmployeeMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public ActionResult Edit(int id)
        {
            SaleContractEmployeeMasterViewModel model = new SaleContractEmployeeMasterViewModel();
            try
            {
                model.SaleContractEmployeeMasterDTO = new SaleContractEmployeeMaster();
                model.SaleContractEmployeeMasterDTO.ID = id;
                model.SaleContractEmployeeMasterDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<SaleContractEmployeeMaster> response = _SaleContractEmployeeMasterBA.SelectByID(model.SaleContractEmployeeMasterDTO);
                if (response != null && response.Entity != null)
                {
                    model.SaleContractEmployeeMasterDTO.ID = response.Entity.ID;
                    model.SaleContractEmployeeMasterDTO.Title = response.Entity.Title;
                    model.SaleContractEmployeeMasterDTO.EmployeeCode = response.Entity.EmployeeCode;
                    model.SaleContractEmployeeMasterDTO.FirstName = response.Entity.FirstName;
                    model.SaleContractEmployeeMasterDTO.MiddleName = response.Entity.MiddleName;
                    model.SaleContractEmployeeMasterDTO.LastName = response.Entity.LastName;
                    model.SaleContractEmployeeMasterDTO.FirstJoiningDate = response.Entity.FirstJoiningDate;
                    model.SaleContractEmployeeMasterDTO.IsLeft = response.Entity.IsLeft;
                    model.SaleContractEmployeeMasterDTO.LastLeftDate = response.Entity.LastLeftDate;
                    model.SaleContractEmployeeMasterDTO.BirthDate = response.Entity.BirthDate;
                    model.SaleContractEmployeeMasterDTO.NationalityID = response.Entity.NationalityID;
                    model.SaleContractEmployeeMasterDTO.Nationality = response.Entity.Nationality;
                    model.SaleContractEmployeeMasterDTO.GenderCode = response.Entity.GenderCode;
                    model.SaleContractEmployeeMasterDTO.MarritalStaus = response.Entity.MarritalStaus;
                    model.SaleContractEmployeeMasterDTO.MobileNumber = response.Entity.MobileNumber;
                    model.SaleContractEmployeeMasterDTO.EmailID = response.Entity.EmailID;
                    model.SaleContractEmployeeMasterDTO.OtherEmailID = response.Entity.OtherEmailID;
                    model.SaleContractEmployeeMasterDTO.EmergencyContactNumber1 = response.Entity.EmergencyContactNumber1;
                    model.SaleContractEmployeeMasterDTO.EmergencyContactNumber2 = response.Entity.EmergencyContactNumber2;
                    model.SaleContractEmployeeMasterDTO.Address1 = response.Entity.Address1;
                    model.SaleContractEmployeeMasterDTO.Address2 = response.Entity.Address2;
                    model.SaleContractEmployeeMasterDTO.CityID = response.Entity.CityID;
                    model.SaleContractEmployeeMasterDTO.RegionID = response.Entity.RegionID;
                    model.SaleContractEmployeeMasterDTO.CountryID = response.Entity.CountryID;
                    model.SaleContractEmployeeMasterDTO.CityName = response.Entity.CityName;
                    model.SaleContractEmployeeMasterDTO.Pincode = response.Entity.Pincode;
                    model.SaleContractEmployeeMasterDTO.SSNNumber = response.Entity.SSNNumber;
                    model.SaleContractEmployeeMasterDTO.SINNumber = response.Entity.SINNumber;
                    model.SaleContractEmployeeMasterDTO.DrivingLicenceNumber = response.Entity.DrivingLicenceNumber;
                    model.SaleContractEmployeeMasterDTO.DrivingLicenceExpireDate = response.Entity.DrivingLicenceExpireDate;
                    model.SaleContractEmployeeMasterDTO.PanNumber = response.Entity.PanNumber;
                    model.SaleContractEmployeeMasterDTO.ESINumber = response.Entity.ESINumber;
                    model.SaleContractEmployeeMasterDTO.ProvidentFundNumber = response.Entity.ProvidentFundNumber;
                    model.SaleContractEmployeeMasterDTO.ProvidentFundApplicableDate = response.Entity.ProvidentFundApplicableDate;
                    model.SaleContractEmployeeMasterDTO.BankMasterID = response.Entity.BankMasterID;
                    model.SaleContractEmployeeMasterDTO.BankName = response.Entity.BankName;
                    model.SaleContractEmployeeMasterDTO.BankACNumber = response.Entity.BankACNumber;
                    model.SaleContractEmployeeMasterDTO.BankIFSICode = response.Entity.BankIFSICode;
                    model.SaleContractEmployeeMasterDTO.UANNumber = response.Entity.UANNumber;
                    model.SaleContractEmployeeMasterDTO.MiddleFullName = response.Entity.MiddleFullName;
                    model.SaleContractEmployeeMasterDTO.CurrentESICZoneID = response.Entity.CurrentESICZoneID;
                    model.SaleContractEmployeeMasterDTO.IsPoliceVerificationComplete = response.Entity.IsPoliceVerificationComplete;
                    model.SaleContractEmployeeMasterDTO.IsESICCardIssued = response.Entity.IsESICCardIssued;
                    model.SaleContractEmployeeMasterDTO.BloodGroup = response.Entity.BloodGroup;
                    model.SaleContractEmployeeMasterDTO.CroppedImagePath = response.Entity.CroppedImagePath;
                    model.SaleContractEmployeeMasterDTO.CentreCode = response.Entity.CentreCode;
                    model.SaleContractEmployeeMasterDTO.ReasonForLeft = response.Entity.ReasonForLeft;

                    model.SaleContractEmployeeMasterDTO.CreatedBy = response.Entity.CreatedBy;
                }

                List<GeneralTitleMaster> GeneralTitleMasterList = GetListGeneralTitleMaster();
                List<SelectListItem> ListGeneralTitleMaster = new List<SelectListItem>();
                foreach (GeneralTitleMaster item in GeneralTitleMasterList)
                {
                    ListGeneralTitleMaster.Add(new SelectListItem { Text = item.NameTitle, Value = item.NameTitle.ToString() });
                }
                ViewBag.GeneralTitleMasterList = new SelectList(ListGeneralTitleMaster, "Value", "Text");

                List<BankMaster> BankMasterList = GetListBankMaster();
                List<SelectListItem> ListBankMaster = new List<SelectListItem>();
                foreach (BankMaster item in BankMasterList)
                {
                    ListBankMaster.Add(new SelectListItem { Text = item.BankName, Value = item.ID.ToString() });
                }
                ViewBag.BankMasterList = new SelectList(ListBankMaster, "Value", "Text");

                //List<SelectListItem> EmployeeMarritalStaus = new List<SelectListItem>();
                //ViewBag.EmployeeMarritalStaus = new SelectList(EmployeeMarritalStaus, "Value", "Text");
                List<SelectListItem> li_EmployeeMarritalStaus = new List<SelectListItem>();
                li_EmployeeMarritalStaus.Add(new SelectListItem { Text = Resources.DisplayName_UNMARRIED, Value = "U" });
                li_EmployeeMarritalStaus.Add(new SelectListItem { Text = Resources.DisplayName_MARRIED, Value = "M" });
                li_EmployeeMarritalStaus.Add(new SelectListItem { Text = Resources.DisplayName_DIVORCED, Value = "D" });
                //ViewData["EmployeeMarritalStaus"] = li_EmployeeMarritalStaus;
                ViewBag.EmployeeMarritalStaus = new SelectList(li_EmployeeMarritalStaus, "Value", "Text");

                List<SelectListItem> li_EmployeeReasonForLeft = new List<SelectListItem>();
                li_EmployeeReasonForLeft.Add(new SelectListItem { Text = "RETIREMENT", Value = "RETIREMENT" });
                li_EmployeeReasonForLeft.Add(new SelectListItem { Text = "DEATH IN SERVICE", Value = "DEATH IN SERVICE" });
                li_EmployeeReasonForLeft.Add(new SelectListItem { Text = "RESIGN(SHORT SERVICE)", Value = "RESIGN(SHORT SERVICE)" });
                li_EmployeeReasonForLeft.Add(new SelectListItem { Text = "TEMPORARY RESIGN", Value = "TEMPORARY RESIGN" });
                ViewBag.EmployeeReasonForLeft = new SelectList(li_EmployeeReasonForLeft, "Value", "Text");

                List<GeneralNationalityMaster> generalNationalityMasterList = GetListGeneralNationalityMaster();
                List<SelectListItem> generalNationalityMaster = new List<SelectListItem>();
                foreach (GeneralNationalityMaster item in generalNationalityMasterList)
                {
                    generalNationalityMaster.Add(new SelectListItem { Text = item.Description, Value = item.ID.ToString() });
                }
                ViewBag.GeneralNationalityMaster = new SelectList(generalNationalityMaster, "Value", "Text");

                List<GeneralCountryMaster> genCountryMasterList = GetListGeneralCountryMaster();
                List<SelectListItem> genCountryMaster = new List<SelectListItem>();
                foreach (GeneralCountryMaster item in genCountryMasterList)
                {
                    genCountryMaster.Add(new SelectListItem { Text = item.CountryName, Value = item.ID.ToString() });
                }
                ViewBag.GenCountryMaster = new SelectList(genCountryMaster, "Value", "Text");

                List<SelectListItem> generalRegionMaster = new List<SelectListItem>();
                if (model.SaleContractEmployeeMasterDTO.CountryID != 0)
                {
                    List<GeneralRegionMaster> generalRegionMasterList = GetListGeneralRegionMaster(Convert.ToString(model.SaleContractEmployeeMasterDTO.CountryID));
                    foreach (GeneralRegionMaster item in generalRegionMasterList)
                    {
                        generalRegionMaster.Add(new SelectListItem { Text = item.RegionName, Value = item.ID.ToString() });
                    }
                }
                ViewBag.GeneralRegionMaster = new SelectList(generalRegionMaster, "Value", "Text");

                List<SelectListItem> generalCityMaster = new List<SelectListItem>();
                if (model.SaleContractEmployeeMasterDTO.RegionID != 0)
                {
                    List<GeneralCityMaster> generalCityMasterList = GetListGeneralCityMaster(Convert.ToString(model.SaleContractEmployeeMasterDTO.RegionID));
                    foreach (GeneralCityMaster item in generalCityMasterList)
                    {
                        generalCityMaster.Add(new SelectListItem { Text = item.Description, Value = item.ID.ToString() });
                    }
                }
                ViewBag.GeneralCityMaster = new SelectList(generalCityMaster, "Value", "Text");

                List<ESICZoneMaster> ESICZoneMasterList = GetListESICZoneMaster();
                List<SelectListItem> ESICZoneMaster = new List<SelectListItem>();
                foreach (ESICZoneMaster item in ESICZoneMasterList)
                {
                    ESICZoneMaster.Add(new SelectListItem { Text = item.ZoneName, Value = item.ID.ToString() });
                }
                ViewBag.ESICZoneMaster = new SelectList(ESICZoneMaster, "Value", "Text");

                //For Blood Group
                List<SelectListItem> EmployeeBloodGroup = new List<SelectListItem>();
                ViewBag.EmployeeBloodGroup = new SelectList(EmployeeBloodGroup, "Value", "Text");
                List<SelectListItem> li_EmployeeBloodGroup = new List<SelectListItem>();
                li_EmployeeBloodGroup.Add(new SelectListItem { Text = "-- Select Blood Group -- ", Value = "" });
                li_EmployeeBloodGroup.Add(new SelectListItem { Text = "O-", Value = "O-" });
                li_EmployeeBloodGroup.Add(new SelectListItem { Text = "O+", Value = "O+" });
                li_EmployeeBloodGroup.Add(new SelectListItem { Text = "A-", Value = "A-" });
                li_EmployeeBloodGroup.Add(new SelectListItem { Text = "A+", Value = "A+" });
                li_EmployeeBloodGroup.Add(new SelectListItem { Text = "B-", Value = "B-" });
                li_EmployeeBloodGroup.Add(new SelectListItem { Text = "B+", Value = "B+" });
                li_EmployeeBloodGroup.Add(new SelectListItem { Text = "AB-", Value = "AB-" });
                li_EmployeeBloodGroup.Add(new SelectListItem { Text = "AB+", Value = "AB+" });
                ViewData["BloodGroup"] = new SelectList(li_EmployeeBloodGroup, "Value", "Text", model.SaleContractEmployeeMasterDTO.BloodGroup);

                return PartialView("/Views/Contract/SaleContractEmployeeMaster/Edit.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(SaleContractEmployeeMasterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model != null && model.SaleContractEmployeeMasterDTO != null)
                {
                    if (model != null && model.SaleContractEmployeeMasterDTO != null)
                    {
                        model.SaleContractEmployeeMasterDTO.ConnectionString = _connectioString;
                        model.SaleContractEmployeeMasterDTO.ID = model.ID;
                        model.SaleContractEmployeeMasterDTO.Title = model.Title;
                        model.SaleContractEmployeeMasterDTO.FirstName = model.FirstName;
                        model.SaleContractEmployeeMasterDTO.MiddleName = model.MiddleName;
                        model.SaleContractEmployeeMasterDTO.LastName = model.LastName;
                        model.SaleContractEmployeeMasterDTO.FirstJoiningDate = model.FirstJoiningDate;
                        model.SaleContractEmployeeMasterDTO.IsLeft = model.IsLeft;
                        model.SaleContractEmployeeMasterDTO.LastLeftDate = model.LastLeftDate;
                        model.SaleContractEmployeeMasterDTO.BirthDate = model.BirthDate;
                        model.SaleContractEmployeeMasterDTO.NationalityID = model.NationalityID;
                        model.SaleContractEmployeeMasterDTO.Nationality = model.Nationality;
                        model.SaleContractEmployeeMasterDTO.GenderCode = model.GenderCode;
                        model.SaleContractEmployeeMasterDTO.MarritalStaus = model.MarritalStaus;
                        model.SaleContractEmployeeMasterDTO.MobileNumber = model.MobileNumber;
                        model.SaleContractEmployeeMasterDTO.EmailID = model.EmailID;
                        model.SaleContractEmployeeMasterDTO.OtherEmailID = model.OtherEmailID;
                        model.SaleContractEmployeeMasterDTO.EmergencyContactNumber1 = model.EmergencyContactNumber1;
                        model.SaleContractEmployeeMasterDTO.EmergencyContactNumber2 = model.EmergencyContactNumber2;
                        model.SaleContractEmployeeMasterDTO.Address1 = model.Address1;
                        model.SaleContractEmployeeMasterDTO.Address2 = model.Address2;
                        model.SaleContractEmployeeMasterDTO.CityID = model.CityID;
                        model.SaleContractEmployeeMasterDTO.CityName = model.CityName;
                        model.SaleContractEmployeeMasterDTO.Pincode = model.Pincode;
                        model.SaleContractEmployeeMasterDTO.SSNNumber = model.SSNNumber;
                        model.SaleContractEmployeeMasterDTO.SINNumber = model.SINNumber;
                        model.SaleContractEmployeeMasterDTO.DrivingLicenceNumber = model.DrivingLicenceNumber;
                        model.SaleContractEmployeeMasterDTO.DrivingLicenceExpireDate = model.DrivingLicenceExpireDate;
                        model.SaleContractEmployeeMasterDTO.PanNumber = model.PanNumber;
                        model.SaleContractEmployeeMasterDTO.ESINumber = model.ESINumber;
                        model.SaleContractEmployeeMasterDTO.ProvidentFundNumber = model.ProvidentFundNumber;
                        model.SaleContractEmployeeMasterDTO.ProvidentFundApplicableDate = model.ProvidentFundApplicableDate;
                        model.SaleContractEmployeeMasterDTO.BankMasterID = model.BankMasterID;
                        model.SaleContractEmployeeMasterDTO.BankName = model.BankName;
                        model.SaleContractEmployeeMasterDTO.BankACNumber = model.BankACNumber;
                        model.SaleContractEmployeeMasterDTO.BankIFSICode = model.BankIFSICode;
                        model.SaleContractEmployeeMasterDTO.UANNumber = model.UANNumber;
                        model.SaleContractEmployeeMasterDTO.MiddleFullName = model.MiddleFullName;
                        model.SaleContractEmployeeMasterDTO.CurrentESICZoneID = model.CurrentESICZoneID;
                        model.SaleContractEmployeeMasterDTO.IsPoliceVerificationComplete = model.IsPoliceVerificationComplete;
                        model.SaleContractEmployeeMasterDTO.IsESICCardIssued = model.IsESICCardIssued;
                        model.SaleContractEmployeeMasterDTO.BloodGroup = model.BloodGroup;
                        model.SaleContractEmployeeMasterDTO.CentreCode = model.CentreCode;
                        model.SaleContractEmployeeMasterDTO.ReasonForLeft = model.ReasonForLeft;
                        model.SaleContractEmployeeMasterDTO.CroppedImagePath = model.CroppedImagePath;

                        model.SaleContractEmployeeMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<SaleContractEmployeeMaster> response = _SaleContractEmployeeMasterBA.UpdateSaleContractEmployeeMaster(model.SaleContractEmployeeMasterDTO);
                        model.SaleContractEmployeeMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                    }
                }
                return Json(model.SaleContractEmployeeMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Please review your form");
            }
        }

        public ActionResult Delete(int ID)
        {
            SaleContractEmployeeMasterViewModel model = new SaleContractEmployeeMasterViewModel();
            //if (!ModelState.IsValid)
            //{
            if (ID > 0)
            {
                SaleContractEmployeeMaster SaleContractEmployeeMasterDTO = new SaleContractEmployeeMaster();
                SaleContractEmployeeMasterDTO.ConnectionString = _connectioString;
                SaleContractEmployeeMasterDTO.ID = ID;
                SaleContractEmployeeMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                IBaseEntityResponse<SaleContractEmployeeMaster> response = _SaleContractEmployeeMasterBA.DeleteSaleContractEmployeeMaster(SaleContractEmployeeMasterDTO);
                model.SaleContractEmployeeMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);

            }
            return Json(model.SaleContractEmployeeMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
            //}
            //else
            //{
            //    return Json("Please review your form");
            //}
        }

        [HttpGet]
        public ActionResult UploadExcel()
        {
            SaleContractEmployeeMasterViewModel model = new SaleContractEmployeeMasterViewModel();
            return PartialView("/Views/Contract/SaleContractEmployeeMaster/UploadExcel.cshtml", model);
        }
        public FileResult Download()
        {

            string FileName = "SaleContractEmployeeExcel.xlsx";
            string filePath = Path.Combine(Server.MapPath("~") + "Content\\DownloadFiles\\", FileName);
            System.IO.File.Delete(filePath);
            CreateSaleContractEmployeeExcel(filePath);
            InsertSaleContractEmployeeExcel(filePath);
            string contentType = "application/vnd.ms-excel";
            return File(filePath, contentType, FileName);
        }

        public void CreateSaleContractEmployeeExcel(string fileName)
        {
            using (SpreadsheetDocument document = SpreadsheetDocument.Create(fileName, SpreadsheetDocumentType.Workbook))
            {
                WorkbookPart workbookPart = document.AddWorkbookPart();
                workbookPart.Workbook = new Workbook();

                WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                worksheetPart.Worksheet = new Worksheet(new SheetData());

                Sheets sheets = workbookPart.Workbook.AppendChild(new Sheets());

                Sheet sheet = new Sheet() { Id = workbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = "Sale Contract Employee Excel" };

                SaleContractEmployeeMasterViewModel model = new SaleContractEmployeeMasterViewModel();
                model.SaleContractEmployeeMasterDTO.ConnectionString = _connectioString;
                model.SaleContractEmployeeMasterDTO.ExcelSheetName = "SaleContractEmployeeExcel";

                IBaseEntityResponse<SaleContractEmployeeMaster> response = _SaleContractEmployeeMasterBA.GetDataValidationListsForEmployeeMasterExcel(model.SaleContractEmployeeMasterDTO);
                if (response != null && response.Entity != null)
                {
                    model.SaleContractEmployeeMasterDTO.Title = response.Entity.Title;
                    model.SaleContractEmployeeMasterDTO.ESICZoneCode = response.Entity.ESICZoneCode;
                    model.SaleContractEmployeeMasterDTO.CentreCode = response.Entity.CentreCode;
                    model.SaleContractEmployeeMasterDTO.BankName = response.Entity.BankName;

                }
                DataValidation dataValidation = new DataValidation
                {
                    Type = DataValidationValues.List,
                    AllowBlank = true,
                    SequenceOfReferences = new ListValue<StringValue>() { InnerText = "A3:A100" },
                    Formula1 = new Formula1(string.Concat("\"", model.SaleContractEmployeeMasterDTO.Title, "\"")),
                    ShowErrorMessage = true,
                    ErrorStyle = DataValidationErrorStyleValues.Stop,
                    ErrorTitle = new StringValue("Incorrect Value"),
                    Error = new StringValue("Please select value from list.")
                };

                DataValidations dvs = worksheetPart.Worksheet.GetFirstChild<DataValidations>(); //worksheet type => Worksheet
                if (dvs != null)
                {
                    dvs.Count = dvs.Count + 1;
                    dvs.Append(dataValidation);
                }
                else
                {
                    DataValidations newDVs = new DataValidations();
                    newDVs.Append(dataValidation);
                    newDVs.Count = 1;
                    worksheetPart.Worksheet.Append(newDVs);
                }

                DataValidation dataValidation1 = new DataValidation
                {
                    Type = DataValidationValues.List,
                    AllowBlank = true,
                    SequenceOfReferences = new ListValue<StringValue>() { InnerText = "L3:L100" },
                    Formula1 = new Formula1(string.Concat("\"", model.SaleContractEmployeeMasterDTO.ESICZoneCode, "\"")),
                    ShowErrorMessage = true,
                    ErrorStyle = DataValidationErrorStyleValues.Stop,
                    ErrorTitle = new StringValue("Incorrect Value"),
                    Error = new StringValue("Please select value from list."),
                    
                };
                DataValidations dvs1 = worksheetPart.Worksheet.GetFirstChild<DataValidations>(); //worksheet type => Worksheet
                if (dvs1 != null)
                {
                    dvs1.Count = dvs1.Count + 1;
                    dvs1.Append(dataValidation1);
                }
                else
                {
                    DataValidations newDVs1 = new DataValidations();
                    newDVs1.Append(dataValidation1);
                    newDVs1.Count = 1;
                    worksheetPart.Worksheet.Append(newDVs1);
                }
                DataValidation dataValidation2 = new DataValidation
                {
                    Type = DataValidationValues.List,
                    AllowBlank = true,
                    SequenceOfReferences = new ListValue<StringValue>() { InnerText = "P3:P500" },
                    Formula1 = new Formula1(string.Concat("\"", model.SaleContractEmployeeMasterDTO.CentreCode, "\"")),
                    ShowErrorMessage = true,
                    ErrorStyle = DataValidationErrorStyleValues.Stop,
                    ErrorTitle = new StringValue("Incorrect Value"),
                    Error = new StringValue("Please select value from list.")
                };
                DataValidations dvs2 = worksheetPart.Worksheet.GetFirstChild<DataValidations>(); //worksheet type => Worksheet
                if (dvs2 != null)
                {
                    dvs2.Count = dvs2.Count + 1;
                    dvs2.Append(dataValidation2);
                }
                else
                {
                    DataValidations newDVs2 = new DataValidations();
                    newDVs2.Append(dataValidation2);
                    newDVs2.Count = 1;
                    worksheetPart.Worksheet.Append(newDVs2);
                }
                DataValidation dataValidation3 = new DataValidation
                {
                    Type = DataValidationValues.List,
                    AllowBlank = true,
                    SequenceOfReferences = new ListValue<StringValue>() { InnerText = "Q3:Q500" },
                    Formula1 = new Formula1(string.Concat("\"M,F\"")),
                    ShowErrorMessage = true,
                    ErrorStyle = DataValidationErrorStyleValues.Stop,
                    ErrorTitle = new StringValue("Incorrect Value"),
                    Error = new StringValue("Please select value from list.")
                };
                DataValidations dvs3 = worksheetPart.Worksheet.GetFirstChild<DataValidations>(); //worksheet type => Worksheet
                if (dvs3 != null)
                {
                    dvs3.Count = dvs3.Count + 1;
                    dvs3.Append(dataValidation3);
                }
                else
                {
                    DataValidations newDVs3 = new DataValidations();
                    newDVs3.Append(dataValidation3);
                    newDVs3.Count = 1;
                    worksheetPart.Worksheet.Append(newDVs3);
                }
                DataValidation dataValidation4 = new DataValidation
                {
                    Type = DataValidationValues.List,
                    AllowBlank = true,
                    SequenceOfReferences = new ListValue<StringValue>() { InnerText = "G3:G500" },
                    Formula1 = new Formula1(string.Concat("\"", model.SaleContractEmployeeMasterDTO.BankName, "\"")),
                    ShowErrorMessage = true,
                    ErrorStyle = DataValidationErrorStyleValues.Stop,
                    ErrorTitle = new StringValue("Incorrect Value"),
                    Error = new StringValue("Please select value from list.")
                };
                DataValidations dvs4 = worksheetPart.Worksheet.GetFirstChild<DataValidations>(); //worksheet type => Worksheet
                if (dvs4 != null)
                {
                    dvs4.Count = dvs4.Count + 1;
                    dvs4.Append(dataValidation4);
                }
                else
                {
                    DataValidations newDVs4 = new DataValidations();
                    newDVs4.Append(dataValidation4);
                    newDVs4.Count = 1;
                    worksheetPart.Worksheet.Append(newDVs4);
                }
                DataValidation dataValidation5 = new DataValidation
                {
                    Type = DataValidationValues.List,
                    AllowBlank = true,
                    SequenceOfReferences = new ListValue<StringValue>() { InnerText = "O3:O500" },
                    Formula1 = new Formula1(string.Concat("\"RETIREMENT,DEATH IN SERVICE,RESIGN(SHORT SERVICE),TEMPORARY RESIGN\"")),
                    ShowErrorMessage = true,
                    ErrorStyle = DataValidationErrorStyleValues.Stop,
                    ErrorTitle = new StringValue("Incorrect Value"),
                    Error = new StringValue("Please select value from list.")
                };
                DataValidations dvs5 = worksheetPart.Worksheet.GetFirstChild<DataValidations>(); //worksheet type => Worksheet
                if (dvs5 != null)
                {
                    dvs5.Count = dvs5.Count + 1;
                    dvs5.Append(dataValidation5);
                }
                else
                {
                    DataValidations newDVs5 = new DataValidations();
                    newDVs5.Append(dataValidation5);
                    newDVs5.Count = 1;
                    worksheetPart.Worksheet.Append(newDVs5);
                }

                sheets.Append(sheet);

                WorkbookStylesPart stylesPart = workbookPart.AddNewPart<WorkbookStylesPart>();
                stylesPart.Stylesheet = GenerateStyleSheet();
                stylesPart.Stylesheet.Save();

                workbookPart.Workbook.Save();
                document.Close();
            }
        }

        public void InsertSaleContractEmployeeExcel(string fileName)
        {
            string[] HeaderData = new string[] { "Title", "First Name", "Middle Name", "Last Name", "Joining Date", "Employee Code", "Bank Name", "Bank AC Number", "UAN No", "Provident Fund Number", "ESIC Number", "ESIC Zone", "Is Left", "Last Left Date","Reason For Left", "Centre Code", "Gender", "BirthDate" };

            string[] ColumnsData = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q","R" };
            InsertTextInExcel(fileName, "", "A", 1);
            for (uint i = 0; i < HeaderData.Length; i++)
            {
                InsertTextInExcel(fileName, HeaderData[i], ColumnsData[i], 1);

            }
        }
        public static void InsertTextInExcel(string docName, string text, string Columns, uint rowID)
        {
            // Open the document for editing.
            using (SpreadsheetDocument spreadSheet = SpreadsheetDocument.Open(docName, true))
            {
                // Get the SharedStringTablePart. If it does not exist, create a new one.
                SharedStringTablePart shareStringPart;
                if (spreadSheet.WorkbookPart.GetPartsOfType<SharedStringTablePart>().Count() > 0)
                {
                    shareStringPart = spreadSheet.WorkbookPart.GetPartsOfType<SharedStringTablePart>().First();
                }
                else
                {
                    shareStringPart = spreadSheet.WorkbookPart.AddNewPart<SharedStringTablePart>();
                }

                // Insert the text into the SharedStringTablePart.
                int index = InsertSharedStringItem(text, shareStringPart);

                // Insert a new worksheet.
                //WorksheetPart worksheetPart = InsertWorksheet(spreadSheet.WorkbookPart);

                Sheet sheet = spreadSheet.WorkbookPart.Workbook.Sheets.GetFirstChild<Sheet>();

                //Get the Worksheet instance.
                WorksheetPart worksheetPart = spreadSheet.WorkbookPart.GetPartById(sheet.Id.Value) as WorksheetPart;

                // Insert cell A1 into the new worksheet.
                Cell cell = InsertCellInWorksheet(Columns, rowID, worksheetPart);

                // Set the value of cell A1.
                cell.CellValue = new CellValue(index.ToString());
                cell.DataType = new EnumValue<CellValues>(CellValues.SharedString);

                if (cell.CellReference.Value == "A1" || cell.CellReference.Value == "B1" || cell.CellReference.Value == "C1" || cell.CellReference.Value == "D1" || cell.CellReference.Value == "E1" || cell.CellReference.Value == "F1" || cell.CellReference.Value == "G1" || cell.CellReference.Value == "H1" || cell.CellReference.Value == "I1" || cell.CellReference.Value == "J1" || cell.CellReference.Value == "K1" || cell.CellReference.Value == "L1" || cell.CellReference.Value == "M1" || cell.CellReference.Value == "N1" || cell.CellReference.Value == "O1" || cell.CellReference.Value == "P1" || cell.CellReference.Value == "Q1" || cell.CellReference.Value == "R1")
                {
                    cell.StyleIndex = 5;
                }

                // Save the new worksheet.
                worksheetPart.Worksheet.Save();
            }
        }

        private Stylesheet GenerateStyleSheet()
        {
            return new Stylesheet(
                new Fonts(
                    new Font(                                                               // Index 0 – The default font.
                        new FontSize() { Val = 11 },
                        new Color() { Rgb = new HexBinaryValue() { Value = "000000" } },
                        new FontName() { Val = "Calibri" }),

                    new Font(                                                               // Index 1 – The bold font.
                        new Bold(),
                        new FontSize() { Val = 11 },
                        new Color() { Rgb = new HexBinaryValue() { Value = "ffffff" } },
                        new FontName() { Val = "Calibri" }),
                    new Font(                                                               // Index 2 – The Italic font.
                        new Italic(),
                        new FontSize() { Val = 11 },
                        new Color() { Rgb = new HexBinaryValue() { Value = "000000" } },
                        new FontName() { Val = "Calibri" }),
                    new Font(                                                               // Index 2 – The Times Roman font. with 16 size
                        new FontSize() { Val = 16 },
                        new Color() { Rgb = new HexBinaryValue() { Value = "000000" } },
                        new FontName() { Val = "Times New Roman" })
                ),
                new Fills(
                    new Fill(                                                           // Index 0 – The default fill.
                        new PatternFill() { PatternType = PatternValues.None }),
                    new Fill(                                                           // Index 1 – The default fill of gray 125 (required)
                        new PatternFill() { PatternType = PatternValues.Gray125 }),
                    new Fill(                                                           // Index 2 – The yellow fill.
                        new PatternFill(
                            new ForegroundColor() { Rgb = new HexBinaryValue() { Value = "00B050" } }
                        )
                        { PatternType = PatternValues.Solid })
                ),
                new Borders(
                    new Border(                                                         // Index 0 – The default border.
                        new LeftBorder(),
                        new RightBorder(),
                        new TopBorder(),
                        new BottomBorder(),
                        new DiagonalBorder()),
                    new Border(                                                         // Index 1 – Applies a Left, Right, Top, Bottom border to a cell
                        new LeftBorder(
                            new Color() { Auto = true }
                        )
                        { Style = BorderStyleValues.Thin },
                        new RightBorder(
                            new Color() { Auto = true }
                        )
                        { Style = BorderStyleValues.Thin },
                        new TopBorder(
                            new Color() { Auto = true }
                        )
                        { Style = BorderStyleValues.Thin },
                        new BottomBorder(
                            new Color() { Auto = true }
                        )
                        { Style = BorderStyleValues.Thin },
                        new DiagonalBorder())
                ),
                new CellFormats(
                    new CellFormat() { FontId = 0, FillId = 0, BorderId = 0 },                          // Index 0 – The default cell style.  If a cell does not have a style index applied it will use this style combination instead
                    new CellFormat() { FontId = 1, FillId = 0, BorderId = 0, ApplyFont = true },       // Index 1 – Bold 
                    new CellFormat() { FontId = 2, FillId = 0, BorderId = 0, ApplyFont = true },       // Index 2 – Italic
                    new CellFormat() { FontId = 3, FillId = 0, BorderId = 0, ApplyFont = true },       // Index 3 – Times Roman
                    new CellFormat() { FontId = 0, FillId = 2, BorderId = 0, ApplyFill = true },       // Index 4 – Yellow Fill
                    new CellFormat(                                                                   // Index 5 – Alignment
                        new Alignment() { Horizontal = HorizontalAlignmentValues.Center, Vertical = VerticalAlignmentValues.Center, WrapText = true }
                    )
                    { FontId = 0, FillId = 2, BorderId = 1, ApplyAlignment = true },
                    new CellFormat() { FontId = 0, FillId = 0, BorderId = 1, ApplyBorder = true }      // Index 6 – Border
                )
            ); // return
        }

        public static string GetColumnName(string cellReference)
        {
            // Create a regular expression to match the column name portion of the cell name.

            Regex regex = new Regex("[A-Za-z]+");
            Match match = regex.Match(cellReference);
            return match.Value;
        }

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
        public static string GetCellValueDates(SpreadsheetDocument document, Cell cell)
        {
            SharedStringTablePart stringTablePart = document.WorkbookPart.SharedStringTablePart;
            if (cell.CellValue == null)
            {
                return "";
            }
            string value = cell.CellValue.InnerXml;
            if (cell.DataType != null && cell.DataType.Value == CellValues.SharedString)
            {
                return stringTablePart.SharedStringTable.ChildElements[Int32.Parse(value)].InnerText.ToString();
            }
            else
            {
                return value;
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
                if (hTable.Contains(drow[colName]))
                    duplicateList.Add(drow);
                else
                    hTable.Add(drow[colName], string.Empty);
            }

            //Removing a list of duplicate items from datatable.
            foreach (DataRow dRow in duplicateList)
                //dTable.Rows.Remove(dRow);
                errorMessage = "Do not add same Data twice,#FFCC80";

            //Datatable which contains unique records will be return as output.

            return dTable;
        }


        //Excel insert
        [HttpPost]
        public ActionResult UploadExcel(SaleContractEmployeeMasterViewModel model)
        {
            try
            {
                //if (ModelState.IsValid)
                // {
                if (model != null && model.SaleContractEmployeeMasterDTO != null)
                {
                    UploadExcelForContractEmployee();
                    model.SaleContractEmployeeMasterDTO.ConnectionString = _connectioString;
                    //model.SaleContractEmployeeMasterDTO.ID = model.ID;
                    model.SaleContractEmployeeMasterDTO.XMLString = xmlParameter;
                    model.SaleContractEmployeeMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    if (xmlParameter != string.Empty && xmlParameter != null && IsExcelValid == true)
                    {
                        IBaseEntityResponse<SaleContractEmployeeMaster> response = _SaleContractEmployeeMasterBA.InsertSaleContractEmployeeMasterExcelUpload(model.SaleContractEmployeeMasterDTO);
                        string errorMessageDis = string.Empty;
                        string colorCode = string.Empty;
                        string mode = string.Empty;
                        if (response.Entity.ErrorCode == 77)
                        {
                            errorMessageDis = response.Entity.errorMessage;
                            colorCode = "danger";
                        }
                        else if (response.Entity.ErrorCode == 0)
                        {
                            errorMessageDis = response.Entity.errorMessage;
                            colorCode = "success";
                        }
                        string[] arrayList = { errorMessageDis, colorCode, mode };
                        errorMessage = string.Join(",", arrayList);
                        model.SaleContractEmployeeMasterDTO.errorMessage = errorMessage;
                    }
                    else if (IsExcelValid == false)
                    {
                        model.SaleContractEmployeeMasterDTO.errorMessage = errorMessage;// "Invalide excel column,#FFCC80";
                    }
                    else if (xmlParameter == string.Empty || xmlParameter != null)
                    {
                        model.SaleContractEmployeeMasterDTO.errorMessage = errorMessage;// "No data found in excel,#FFCC80";
                    }

                    TempData["_errorMsg"] = model.SaleContractEmployeeMasterDTO.errorMessage;
                    xmlParameter = null;
                    IsExcelValid = true;
                    errorMessage = null;
                    return RedirectToAction("Index", "SaleContractEmployeeMaster");
                    //return Json(model.VendorMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
                }


                //  }
                else
                {
                    return Json("Please review your form");
                }

            }
            catch (Exception ex)
            {
                string[] arrayList = { ex.Message, "danger", null };
                TempData["_errorMsg"] = string.Join(",", arrayList);
                errorMessage = null;
                return RedirectToAction("Index", "SaleContractEmployeeMaster");
            }

        }

        public void UploadExcelForContractEmployee()
        {
            string _ExcelFileXML = string.Empty;
            //   string XMLstring = string.Empty;
            var _comPath = "";
            if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
            {
                var ExcelFile = System.Web.HttpContext.Current.Request.Files["ExcelFile"];

                if (ExcelFile.ContentLength > 0)
                {
                    string extension = System.IO.Path.GetExtension(ExcelFile.FileName);
                    if (extension == ".xlsx")
                    {
                        _comPath = Server.MapPath("~") + "Content\\UploadedFiles\\UplodedExcel\\";
                        var myUniqueFileName = Guid.NewGuid();
                        string filePath = String.Concat(myUniqueFileName, ExcelFile.FileName);
                        filePath = string.Format("{0}{1}", _comPath, filePath);
                        if (!Directory.Exists(_comPath))
                        {
                            Directory.CreateDirectory(_comPath);
                        }
                        if (System.IO.File.Exists(filePath))
                            System.IO.File.Delete(filePath);

                        ExcelFile.SaveAs(filePath);
                        OpenXmlValidator validator = new OpenXmlValidator();

                        int count = 0;
                        //foreach (ValidationErrorInfo error in validator.Validate(SpreadsheetDocument.Open(filePath, false)))
                        //{
                        //    count++;
                        //}
                        if (count <= 0)
                        {
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
                                    if (
                                        // (GetCellValue(doc, cell)) == "" ||

                                        (GetCellValue(doc, cell)) == "Title" ||
                                        (GetCellValue(doc, cell)) == "First Name" ||
                                        (GetCellValue(doc, cell)) == "Middle Name" ||
                                        (GetCellValue(doc, cell)) == "Last Name" ||
                                        (GetCellValue(doc, cell)) == "Joining Date" ||
                                        (GetCellValue(doc, cell)) == "Employee Code" ||
                                        (GetCellValue(doc, cell)) == "Bank Name" ||
                                        (GetCellValue(doc, cell)) == "Bank AC Number" ||
                                        (GetCellValue(doc, cell)) == "UAN No" ||
                                        (GetCellValue(doc, cell)) == "Provident Fund Number" ||
                                        (GetCellValue(doc, cell)) == "ESIC Number" ||
                                        (GetCellValue(doc, cell)) == "ESIC Zone" ||
                                        (GetCellValue(doc, cell)) == "Is Left" ||
                                        (GetCellValue(doc, cell)) == "Last Left Date" ||
                                        (GetCellValue(doc, cell)) == "Reason For Left" ||
                                        (GetCellValue(doc, cell)) == "Centre Code" ||
                                        (GetCellValue(doc, cell)) == "Gender" ||
                                        (GetCellValue(doc, cell)) == "BirthDate")
                                    {
                                        dt.Columns.Add(GetCellValue(doc, cell));
                                    }
                                    else
                                    {
                                        IsExcelValid = false;
                                        errorMessage = "Invalid excel column,warning";
                                        break;

                                    }

                                }

                                if ((IsExcelValid == true))
                                {

                                    //foreach (Cell cell in rows.ElementAt(1))
                                    //{
                                    //    dt.Columns.Add(GetCellValue(doc, cell));
                                    //}
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
                                            if ((columnIndex == 4 || columnIndex == 13 || columnIndex == 16) && row.RowIndex > 1)
                                            {
                                                tempRow[columnIndex] = GetCellValueDates(doc, cell);
                                            }
                                            else { tempRow[columnIndex] = GetCellValue(doc, cell); }



                                            columnIndex++;
                                        }
                                        dt.Rows.Add(tempRow);
                                    }
                                    dt.Rows.RemoveAt(0); //...so i'm taking it out here.

                                    RemoveDuplicateRows(dt, "Employee Code");




                                    if (extension == ".xls" || extension == ".xlsx")
                                    {
                                        if (
                                        //dt.Columns[0].ColumnName != " " ||

                                        dt.Columns[0].ColumnName != "Title" ||
                                        dt.Columns[1].ColumnName != "First Name" ||
                                        dt.Columns[2].ColumnName != "Middle Name" ||
                                        dt.Columns[3].ColumnName != "Last Name" ||
                                        dt.Columns[4].ColumnName != "Joining Date" ||
                                        dt.Columns[5].ColumnName != "Employee Code" ||
                                        dt.Columns[6].ColumnName != "Bank Name" ||
                                        dt.Columns[7].ColumnName != "Bank AC Number" ||
                                        dt.Columns[8].ColumnName != "UAN No" ||
                                        dt.Columns[9].ColumnName != "Provident Fund Number" ||
                                        dt.Columns[10].ColumnName != "ESIC Number" ||
                                        dt.Columns[11].ColumnName != "ESIC Zone" ||
                                        dt.Columns[12].ColumnName != "Is Left" ||
                                        dt.Columns[13].ColumnName != "Last Left Date" ||
                                        dt.Columns[14].ColumnName != "Reason For Left" ||
                                        dt.Columns[15].ColumnName != "Centre Code" ||
                                        dt.Columns[16].ColumnName != "Gender" ||
                                        dt.Columns[17].ColumnName != "BirthDate")

                                        {
                                            IsExcelValid = false;
                                            errorMessage = "Invalid excel column,warning";
                                        }
                                    }
                                    if (IsExcelValid == true)
                                    {
                                        long result;


                                        //while (dReader.Read())
                                        for (int i = 0; i < (dt.Rows.Count); i++)
                                        {

                                            if (dt.Rows[i]["First Name"].ToString().Trim().Length >= 1 || dt.Rows[i]["Last Name"].ToString().Trim().Length >= 1 || dt.Rows[i]["Middle Name"].ToString().Trim().Length >= 1 || dt.Rows[i]["Joining Date"].ToString().Trim().Length >= 1 || dt.Rows[i]["Employee Code"].ToString().Trim().Length >= 1 || dt.Rows[i]["Bank Name"].ToString().Trim().Length >= 1 || dt.Rows[i]["Bank AC Number"].ToString().Trim().Length >= 1 || dt.Rows[i]["UAN No"].ToString().Trim().Length >= 1 || dt.Rows[i]["Provident Fund Number"].ToString().Trim().Length >= 1 || dt.Rows[i]["ESIC Number"].ToString().Trim().Length >= 1)

                                            {

                                                string date1 = string.Empty; string date = string.Empty; string date3 = string.Empty;
                                                if (dt.Rows[i]["First Name"].ToString().Trim().Length >= 1 && dt.Rows[i]["Last Name"].ToString().Trim().Length >= 1)
                                                {
                                                    if (dt.Rows[i]["Joining Date"].ToString().Trim().Length >= 1)
                                                    {
                                                        DateTime ad;
                                                        //date = ad.ToString("yyyy-MM-dd");

                                                        if (DateTime.TryParse(dt.Rows[i]["Joining Date"].ToString(), out ad))
                                                        {
                                                            date = ad.ToString("yyyy-MM-dd");
                                                        }
                                                        else
                                                        {
                                                            double d = double.Parse(dt.Rows[i]["Joining Date"].ToString());
                                                            DateTime conv = DateTime.FromOADate(d);
                                                            date = conv.ToString("yyyy-MM-dd");
                                                        }
                                                        //double d = double.Parse(adb);
                                                        //DateTime conv = DateTime.FromOADate(d);
                                                        //date = conv.ToString("yyyy-MM-dd");

                                                        //double d = double.Parse(dt.Rows[i]["Joining Date"].ToString());
                                                        //DateTime conv = DateTime.FromOADate(d);
                                                        //date = conv.ToString("yyyy-MM-dd");

                                                        if (!ValidateDate(date))
                                                        {
                                                            int RowNo = i + 2;
                                                            TempData["Message"] = "You are not authorized.";
                                                            return;
                                                        }
                                                    }
                                                    if (dt.Rows[i]["Last Left Date"].ToString().Trim().Length >= 1)
                                                    {

                                                        DateTime ad1;

                                                        if (DateTime.TryParse(dt.Rows[i]["Last Left Date"].ToString(), out ad1))
                                                        {
                                                            date1 = ad1.ToString("yyyy-MM-dd");
                                                        }
                                                        else
                                                        {
                                                            double d = double.Parse(dt.Rows[i]["Last Left Date"].ToString());
                                                            DateTime conv = DateTime.FromOADate(d);
                                                            date1 = conv.ToString("yyyy-MM-dd");
                                                        }

                                                        //dt.Rows[i]["Last Left Date"] = dt.Rows[i]["Last Left Date"] + " ";
                                                        //double d1 = double.Parse(dt.Rows[i]["Last Left Date"].ToString());
                                                        //DateTime conv1 = DateTime.FromOADate(d1);
                                                        //date1 = conv1.ToString("yyyy-MM-dd");

                                                        if (!ValidateDate(date1))
                                                        {
                                                            int RowNo = i + 2;
                                                            TempData["Message"] = "You are not authorized.";
                                                            return;
                                                        }
                                                    }
                                                    if (dt.Rows[i]["BirthDate"].ToString().Trim().Length >= 1)
                                                    {
                                                        DateTime ad2;

                                                        if (DateTime.TryParse(dt.Rows[i]["BirthDate"].ToString(), out ad2))
                                                        {
                                                            date3 = ad2.ToString("yyyy-MM-dd");
                                                        }
                                                        else
                                                        {
                                                            double d = double.Parse(dt.Rows[i]["BirthDate"].ToString());
                                                            DateTime conv = DateTime.FromOADate(d);
                                                            date3 = conv.ToString("yyyy-MM-dd");
                                                        }

                                                        //dt.Rows[i]["BirthDate"] = dt.Rows[i]["BirthDate"] + " ";
                                                        //double d2 = double.Parse(dt.Rows[i]["BirthDate"].ToString());
                                                        //DateTime conv2 = DateTime.FromOADate(d2);
                                                        //date3 = conv2.ToString("yyyy-MM-dd");

                                                        if (!ValidateDate(date3))
                                                        {
                                                            int RowNo = i + 2;
                                                            TempData["Message"] = "You are not authorized.";
                                                            return;
                                                        }
                                                    }


                                                    xmlParameter = xmlParameter + "<row><Title>" + dt.Rows[i]["Title"] + "</Title><FirstName>" + dt.Rows[i]["First Name"].ToString().Trim() + "</FirstName><MiddleName>" + dt.Rows[i]["Middle Name"].ToString().Trim() + "</MiddleName><LastName>" + dt.Rows[i]["Last Name"].ToString().Trim() + "</LastName><JoiningDate>" + date + "</JoiningDate><EmployeeCode>" + dt.Rows[i]["Employee Code"].ToString().Trim() + "</EmployeeCode><BankName>" + dt.Rows[i]["Bank Name"].ToString().Trim() + "</BankName><BankACNumber>" + dt.Rows[i]["Bank AC Number"].ToString().Trim() + "</BankACNumber><UANNo>" + dt.Rows[i]["UAN No"].ToString().Trim() + "</UANNo><ProvidentFundNumber>" + dt.Rows[i]["Provident Fund Number"].ToString().Trim() + "</ProvidentFundNumber><ESICNumber>" + dt.Rows[i]["ESIC Number"].ToString().Trim() + "</ESICNumber><ESICZone>" + dt.Rows[i]["ESIC Zone"].ToString().Trim() + "</ESICZone><IsLeft>" + dt.Rows[i]["Is Left"].ToString().Trim() + "</IsLeft><LastLeftDate>" + date1 + "</LastLeftDate><ReasonForLeft>" + dt.Rows[i]["Reason For Left"].ToString().Trim() + "</ReasonForLeft><CentreCode>" + dt.Rows[i]["Centre Code"].ToString().Trim() + "</CentreCode><Gender>" + dt.Rows[i]["Gender"].ToString().Trim() + "</Gender><BirthDate>" + date3 + "</BirthDate></row>";

                                                }
                                                //else if (dt.Rows[i]["Employee Code"].ToString().Trim().Length < 1 || dt.Rows[i]["Employee Code"].ToString().Trim().Length == 0)
                                                //{
                                                //    xmlParameter = string.Empty;
                                                //    EmpCodeFlag = 1;
                                                //    break;
                                                //}
                                                else if ((dt.Rows[i]["First Name"].ToString().Trim().Length < 1 || dt.Rows[i]["First Name"].ToString().Trim().Length == 0) && (dt.Rows[i]["Is Left"].ToString() == "0" || dt.Rows[i]["Is Left"].ToString() == ""))
                                                {
                                                    xmlParameter = string.Empty;
                                                    FirstNameFlag = 1;
                                                    break;
                                                }
                                                else if ((dt.Rows[i]["Last Name"].ToString().Trim().Length < 1 || dt.Rows[i]["Last Name"].ToString().Trim().Length == 0) && (dt.Rows[i]["Is Left"].ToString() == "0" || dt.Rows[i]["Is Left"].ToString() == ""))
                                                {
                                                    xmlParameter = string.Empty;
                                                    LastNameFlag = 1;
                                                    errorMessage = "Please Enter Last Name,warning";
                                                    break;
                                                }
                                                else if ((dt.Rows[i]["Centre Code"].ToString().Trim().Length < 1 || dt.Rows[i]["Centre Code"].ToString().Trim().Length == 0) && (dt.Rows[i]["Is Left"].ToString() == "0" || dt.Rows[i]["Is Left"].ToString() == ""))
                                                {
                                                    xmlParameter = string.Empty;
                                                    CentreCodeFlag = 1;
                                                    errorMessage = "Please Select Centre Code,warning";
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                    if (xmlParameter.Length > 9)
                                    {
                                        xmlParameter = xmlParameter + "</rows>";
                                    }
                                    else
                                    {
                                        //if (EmpCodeFlag == 1)
                                        //{
                                        //    xmlParameter = string.Empty;
                                        //    errorMessage = "Please enter Emp Code,warning";
                                        //}
                                        //else
                                        if (FirstNameFlag == 1)
                                        {
                                            xmlParameter = string.Empty;
                                            errorMessage = "Please enter First Name,warning";
                                        }

                                        else if (LastNameFlag == 1)
                                        {
                                            xmlParameter = string.Empty;
                                            errorMessage = "Please enter Last Name,warning";
                                        }
                                        else if (CentreCodeFlag == 1)
                                        {
                                            xmlParameter = string.Empty;
                                            errorMessage = "Please Select Centre Code,warning";
                                        }

                                        else
                                        {
                                            xmlParameter = string.Empty;
                                            errorMessage = "No data found in excel,warning";
                                        }

                                    }
                                }

                                else
                                {
                                    errorMessage = "The selected file does not appear to be an excel file,warning";
                                }
                                dt.Dispose();
                            }
                        }
                        else
                        {
                            errorMessage = "Excel file not selected,warning";
                        }
                    }
                    else
                    {
                        IsExcelValid = false;
                        errorMessage = "Please Upload Downloaded File,warning";
                    }

                    // excelConnection.Close();

                    // SQL Server Connection String

                }
                else
                {
                    IsExcelValid = false;
                    errorMessage = "Excel file not selected,warning";
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


        //For uploading logo.
        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult UploadFile()
        {
            string _imgname = string.Empty;
            if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
            {
                var pic = System.Web.HttpContext.Current.Request.Files["MyImages"];
                if (pic.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(pic.FileName);
                    var _ext = Path.GetExtension(pic.FileName);

                    _imgname = Guid.NewGuid().ToString();
                    var _comPath = Server.MapPath("~") + "\\Content\\UploadedFiles\\Contract\\Logo\\";
                    //_imgname = "option_" + fileName + _ext;
                    _imgname = pic.FileName;

                    if (!Directory.Exists(_comPath))
                    {
                        Directory.CreateDirectory(_comPath);
                    }
                    pic.SaveAs(_comPath + "\\" + Path.GetFileName(_imgname));

                    ViewBag.Msg = _comPath;
                    var path = _comPath;
                    MemoryStream ms = new MemoryStream();
                }
            }
            return Json(Convert.ToString(_imgname), JsonRequestBehavior.AllowGet);
        }



        #endregion

        #region Methods

        [HttpPost]
        public JsonResult GetSaleContractEmployeeSearchList(string term, string GenderCode, string CentreCode)
        {
            SaleContractEmployeeMasterSearchRequest searchRequest = new SaleContractEmployeeMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            searchRequest.SearchWord = term;
            searchRequest.GenderCode = GenderCode;
            searchRequest.CentreCode = CentreCode;

            List<SaleContractEmployeeMaster> listFeeSubType = new List<SaleContractEmployeeMaster>();
            IBaseEntityCollectionResponse<SaleContractEmployeeMaster> baseEntityCollectionResponse = _SaleContractEmployeeMasterBA.GetSaleContractEmployeeMasterBySearchWord(searchRequest);
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
                              SaleContractEmployeeMasterID = r.ID,
                              SaleContractEmployeeMasterName = r.EmployeeName,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult GetSaleContractEmployeeSearchListForReports(string term)
        {
            SaleContractEmployeeMasterSearchRequest searchRequest = new SaleContractEmployeeMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            searchRequest.SearchWord = term;

            List<SaleContractEmployeeMaster> listFeeSubType = new List<SaleContractEmployeeMaster>();
            IBaseEntityCollectionResponse<SaleContractEmployeeMaster> baseEntityCollectionResponse = _SaleContractEmployeeMasterBA.GetSaleContractEmployeeMasterBySearchWordForReports(searchRequest);
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
                              SaleContractEmployeeMasterID = r.ID,
                              SaleContractEmployeeMasterName = r.EmployeeName,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        protected List<ESICZoneMaster> GetListESICZoneMaster()
        {
            ESICZoneMasterSearchRequest searchRequest = new ESICZoneMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<ESICZoneMaster> listESICZoneMaster = new List<ESICZoneMaster>();
            IBaseEntityCollectionResponse<ESICZoneMaster> baseEntityCollectionResponse = _ESICZoneMasterBA.GetDropDownListforESICZoneMaster(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listESICZoneMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listESICZoneMaster;
        }

        [NonAction]
        public IEnumerable<SaleContractEmployeeMasterViewModel> GetSaleContractEmployeeMaster(out int TotalRecords, string CentreCode)
        {
            try
            {
                SaleContractEmployeeMasterSearchRequest searchRequest = new SaleContractEmployeeMasterSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
                _actionMode = Convert.ToString(TempData["ActionMode"]);
                searchRequest.CentreCode = CentreCode;
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

                List<SaleContractEmployeeMasterViewModel> listSaleContractEmployeeMasterViewModel = new List<SaleContractEmployeeMasterViewModel>();
                List<SaleContractEmployeeMaster> listSaleContractEmployeeMaster = new List<SaleContractEmployeeMaster>();
                IBaseEntityCollectionResponse<SaleContractEmployeeMaster> baseEntityCollectionResponse = _SaleContractEmployeeMasterBA.GetBySearch(searchRequest);
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        listSaleContractEmployeeMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                        foreach (SaleContractEmployeeMaster item in listSaleContractEmployeeMaster)
                        {
                            SaleContractEmployeeMasterViewModel SaleContractEmployeeMasterViewModel = new SaleContractEmployeeMasterViewModel();
                            SaleContractEmployeeMasterViewModel.SaleContractEmployeeMasterDTO = item;
                            listSaleContractEmployeeMasterViewModel.Add(SaleContractEmployeeMasterViewModel);
                        }
                    }
                }
                TotalRecords = baseEntityCollectionResponse.TotalRecords;

                return listSaleContractEmployeeMasterViewModel;
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }
        #endregion

        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param, string CentreCode)
        {
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc
            int TotalRecords;
            IEnumerable<SaleContractEmployeeMasterViewModel> filteredSaleContractEmployeeMaster;

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
                        _sortBy = "LEN(A.EmployeeCode),A.EmployeeCode";
                        _searchBy = "EmployeeName Like '%" + param.sSearch + "%' or EmployeeCode Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "LEN(A.EmployeeCode) " + sortDirection + ",A.EmployeeCode";
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

            filteredSaleContractEmployeeMaster = GetSaleContractEmployeeMaster(out TotalRecords, CentreCode);

            var records = filteredSaleContractEmployeeMaster.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.ID), Convert.ToString(c.EmployeeName), Convert.ToString(c.EmployeeCode) };
            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);

        }
        #endregion
    }
}