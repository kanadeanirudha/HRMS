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
using System.Web.Hosting;
using System.Data;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Text.RegularExpressions;
using System.Collections;
using DocumentFormat.OpenXml.Validation;

namespace AERP.Web.UI.Controllers
{
    public class VendorMasterController : BaseController
    {
        IVendorMasterBA _VendorMasterBA = null;
        IGeneralCountryMasterBA _GeneralCountryMasterBA = null;
        IGeneralCurrencyMasterBA _GeneralCurrencyMasterBA = null;
        //IVendorMasterBA _IVendorMasterBA = null;
        IGeneralItemCategoryMasterBA _GeneralItemCategoryMasterBA = null;
        IGeneralCityMasterBA _generalCityMasterBA = null;
        IEmpDesignationMasterBA _EmpDesignationMasterBA = null;

        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        static string xmlParameter = null;
        static string xmlParameterForContactPerson1 = null;
        static string xmlParameterForContactPerson2 = null;
        static string xmlParameterForContactPerson3 = null;
        static string xmlParameterForReplenishmentInfo1 = null;
        static string xmlParameterForReplenishmentInfo2 = null;
        static string xmlParameterForReplenishmentInfo3 = null;
        static bool IsExcelValid = true;
        static string errorMessage = null;
        static string Keyvalue = null;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public VendorMasterController()
        {
            _VendorMasterBA = new VendorMasterBA();
            _GeneralCountryMasterBA = new GeneralCountryMasterBA();
            _GeneralCurrencyMasterBA = new GeneralCurrencyMasterBA();
            //_IVendorMasterBA = new VendorMasterBA();
            _GeneralItemCategoryMasterBA = new GeneralItemCategoryMasterBA();
            _generalCityMasterBA = new GeneralCityMasterBA();
            _EmpDesignationMasterBA = new EmpDesignationMasterBA();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
            if (Convert.ToInt32(Session["Purchase Manager"]) > 0 || Convert.ToInt32(Session["Purchase Manager:Entity"]) > 0 || Convert.ToString(Session["UserType"]) == "A")
            {
                VendorMasterViewModel model = new VendorMasterViewModel();
                if (TempData["_errorMsg"] != null)
                {
                    model.errorMessage = Convert.ToString(TempData["_errorMsg"]);
                }
                else
                {
                    model.errorMessage = "NoMessage";
                }

                return View("/Views/Inventory/VendorMaster/Index.cshtml", model);
            }
            else
            {
                return RedirectToAction("UnauthorizedAccess", "Home");
            }
        }

        public ActionResult List(string actionMode, string TaskCode, string VendorNumber)
        {
            try
            {

                VendorMasterViewModel model = new VendorMasterViewModel();
                return PartialView("/Views/Inventory/VendorMaster/List.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }


        [HttpGet]
        public ActionResult ReplenishmentData(string TaskCode, string VendorName, string VendorID, string VendorNumber, string Currency)
        {
            VendorMasterViewModel model = new VendorMasterViewModel();

            model.TaskCode = TaskCode;
            model.VendorMasterDTO.ConnectionString = _connectioString;
            model.VendorMasterDTO.VendorName = (!string.IsNullOrEmpty(VendorName) ? VendorName : null);
            model.VendorMasterDTO.Currency = (!string.IsNullOrEmpty(Currency) ? Currency : null);
            model.VendorMasterDTO.VendorID = Convert.ToInt32(!string.IsNullOrEmpty(VendorID) ? VendorID : null);
            model.VendorMasterDTO.VendorNumber = Convert.ToInt32(!string.IsNullOrEmpty(VendorNumber) ? VendorNumber : null);
            //if (model.VendorMasterDTO.VendorNumber > 0)
            //{
            //    IBaseEntityResponse<VendorMaster> response = _VendorMasterBA.GetReplenishmentDataByVendorNumber(model.VendorMasterDTO);
            //    if (response != null && response.Entity != null)
            //    {
            //        model.VendorMasterDTO.MerchandiseCategory = response.Entity.MerchandiseCategory;
            //        model.VendorMasterDTO.LeadTime = response.Entity.LeadTime; 
            //    }
            //}
            List<GeneralItemCategoryMaster> GeneralItemCategoryMaster = GetListGeneralItemCategoryMaster();
            List<SelectListItem> GeneralItemCategoryMasterList = new List<SelectListItem>();
            foreach (GeneralItemCategoryMaster item in GeneralItemCategoryMaster)
            {
                //GeneralItemCategoryMasterList.Add(new SelectListItem { Text = item.ItemCategoryCode, Value = Convert.ToString(item.ItemCategoryCode) });
                GeneralItemCategoryMasterList.Add(new SelectListItem { Text = item.ItemCategoryCode + " - " + item.ItemCategoryDescription, Value = Convert.ToString(item.ItemCategoryCode) });
            }
            ViewBag.GeneralItemCategoryMasterList = new SelectList(GeneralItemCategoryMasterList, "Value", "Text");
            //********************************************************************************************

            model.VendorMasterListForPersonDetails = GetVendorMasterListForPersonalDetails(VendorID);
            if (model.VendorMasterDTO.VendorID > 0)
            {
                if (model.VendorMasterListForPersonDetails.Count > 0 && model.VendorMasterListForPersonDetails != null)
                {
                    model.VendorID = model.VendorMasterListForPersonDetails[0].VendorID;
                    model.VendorRestriction = model.VendorMasterListForPersonDetails[0].VendorRestriction;
                    model.ReturnGoods = model.VendorMasterListForPersonDetails[0].ReturnGoods;
                    model.Currency = model.VendorMasterListForPersonDetails[0].Currency;

                }
            }

            return PartialView("/Views/Inventory/VendorMaster/ReplenishmentData.cshtml", model);
        }
        [HttpGet]
        public ActionResult UploadExcel(string TaskCode, string VendorName, string VendorID, string VendorNumber, string Currency)
        {
            VendorMasterViewModel model = new VendorMasterViewModel();

            return PartialView("/Views/Inventory/VendorMaster/UploadExcel.cshtml", model);
        }
        [HttpGet]
        public ActionResult FinanceData(string TaskCode, string VendorName, string VendorID, string VendorNumber)
        {
            VendorMasterViewModel model = new VendorMasterViewModel();

            model.TaskCode = TaskCode;
            model.VendorMasterDTO.ConnectionString = _connectioString;
            model.VendorMasterDTO.VendorName = (!string.IsNullOrEmpty(VendorName) ? VendorName : null);
            model.VendorMasterDTO.VendorID = Convert.ToInt32(!string.IsNullOrEmpty(VendorID) ? VendorID : null);
            model.VendorMasterDTO.VendorNumber = Convert.ToInt32(!string.IsNullOrEmpty(VendorNumber) ? VendorNumber : null);

            if (model.VendorMasterDTO.VendorID > 0)
            {
                IBaseEntityResponse<VendorMaster> response = _VendorMasterBA.GetFinanceDataByVendorNumber(model.VendorMasterDTO);
                if (response != null && response.Entity != null)
                {
                    model.VendorMasterDTO.VendorID = response.Entity.VendorID;
                    model.VendorMasterDTO.VendorFinanceDetailsID = response.Entity.VendorFinanceDetailsID;
                    model.VendorMasterDTO.CreditLimit = response.Entity.CreditLimit;
                    model.VendorMasterDTO.Incoterms = response.Entity.Incoterms;
                    model.VendorMasterDTO.AccountNo = response.Entity.AccountNo;
                    model.VendorMasterDTO.BranchName = response.Entity.BranchName;
                    model.VendorMasterDTO.BankName = response.Entity.BankName;
                    model.VendorMasterDTO.BankAddress = response.Entity.BankAddress;
                    model.VendorMasterDTO.IFSCCode = response.Entity.IFSCCode;
                    model.VendorMasterDTO.CashDiscount = response.Entity.CashDiscount;
                    model.VendorMasterDTO.Rebate = response.Entity.Rebate;
                    model.VendorMasterDTO.Credit = response.Entity.Credit;
                    model.VendorMasterDTO.CashOnDelivery = response.Entity.CashOnDelivery;
                    model.VendorMasterDTO.CurrentDatedCheque = response.Entity.CurrentDatedCheque;

                }
            }

            return PartialView("/Views/Inventory/VendorMaster/FinanceData.cshtml", model);
        }
        public ActionResult GeneralData(string TaskCode, string VendorID, string VendorNumber)
        {
            VendorMasterViewModel model = new VendorMasterViewModel();

            model.TaskCode = TaskCode;
            model.VendorMasterDTO.ConnectionString = _connectioString;
            model.VendorMasterDTO.VendorID = Convert.ToInt32(!string.IsNullOrEmpty(VendorID) ? VendorID : null);
            model.VendorMasterDTO.VendorNumber = Convert.ToInt32(!string.IsNullOrEmpty(VendorNumber) ? VendorNumber : null);
            if (model.VendorMasterDTO.VendorID > 0)
            {
                IBaseEntityResponse<VendorMaster> response = _VendorMasterBA.GetGeneralDataByVendorNumber(model.VendorMasterDTO);
                if (response != null && response.Entity != null)
                {
                    model.VendorMasterDTO.VendorName = response.Entity.VendorName;
                    model.VendorMasterDTO.FirstName = response.Entity.FirstName;
                    model.VendorMasterDTO.MiddleName = response.Entity.MiddleName;
                    model.VendorMasterDTO.LastName = response.Entity.LastName;
                    model.VendorMasterDTO.Address1 = response.Entity.Address1;
                    model.VendorMasterDTO.Address2 = response.Entity.Address2;
                    model.VendorMasterDTO.Address3 = response.Entity.Address3;
                    model.VendorMasterDTO.Country = response.Entity.Country;
                    model.VendorMasterDTO.Currency = response.Entity.Currency;
                    model.VendorMasterDTO.PhoneNumber = response.Entity.PhoneNumber;
                    model.VendorMasterDTO.MobileNumber = response.Entity.MobileNumber;
                    model.VendorMasterDTO.Country = response.Entity.Country;
                    model.VendorMasterDTO.Currency = response.Entity.Currency;
                    model.VendorMasterDTO.CityId = response.Entity.CityId;
                    model.VendorMasterDTO.City = Convert.ToString(response.Entity.CityId);
                    model.VendorMasterDTO.State = response.Entity.State;
                    model.VendorMasterDTO.PinCode = response.Entity.PinCode;
                    model.VendorMasterDTO.CPFirstName = response.Entity.CPFirstName;
                    model.VendorMasterDTO.CPMiddleName = response.Entity.CPMiddleName;
                    model.VendorMasterDTO.CPLastName = response.Entity.CPLastName;
                    model.VendorMasterDTO.VendorCode = response.Entity.VendorCode;
                    model.VendorMasterDTO.IsCentre = response.Entity.IsCentre;
                    model.VendorMasterDTO.CentreCode = response.Entity.CentreCode;

                    //model.VendorMasterDTO.ReturnGoods = response.Entity.ReturnGoods;



                }
            }

            model.VendorMasterListForGeneralData = GetVendorMasterListForGeneralData(VendorID);
            if (model.VendorMasterDTO.VendorID > 0)
            {
                if (model.VendorMasterListForGeneralData.Count > 0 && model.VendorMasterListForGeneralData != null)
                {
                    model.VendorID = model.VendorMasterListForGeneralData[0].VendorID;


                }
            }

            List<GeneralCountryMaster> GeneralCountryMaster = GetListGeneralCountryMaster();
            List<SelectListItem> GeneralCountryMasterList = new List<SelectListItem>();
            foreach (GeneralCountryMaster item in GeneralCountryMaster)
            {
                GeneralCountryMasterList.Add(new SelectListItem { Text = item.CountryName, Value = Convert.ToString(item.ID) });
            }
            ViewBag.GeneralCountryMasterList = new SelectList(GeneralCountryMasterList, "Value", "Text");

            //---new code--
            List<SelectListItem> generalRegionMaster = new List<SelectListItem>();
            if (Convert.ToInt32(model.VendorMasterDTO.Country) != 0)
            {
                List<GeneralRegionMaster> generalRegionMasterList = GetListGeneralRegionMaster(Convert.ToString(model.VendorMasterDTO.Country));
                foreach (GeneralRegionMaster item in generalRegionMasterList)
                {
                    generalRegionMaster.Add(new SelectListItem { Text = item.RegionName, Value = item.ID.ToString() });
                }
            }
            ViewBag.GeneralRegionMaster = new SelectList(generalRegionMaster, "Value", "Text");

            List<SelectListItem> generalCityMaster = new List<SelectListItem>();

            if (Convert.ToInt32(model.VendorMasterDTO.State) != 0)
            {
                List<GeneralCityMaster> generalCityMasterList = GetListGeneralCityMaster(Convert.ToString(model.VendorMasterDTO.State));
                foreach (GeneralCityMaster item in generalCityMasterList)
                {
                    generalCityMaster.Add(new SelectListItem { Text = item.Description, Value = item.ID.ToString() });
                }
            }
            ViewBag.GeneralCityMaster = new SelectList(generalCityMaster, "Value", "Text");


            //**************************************************************************************************************//
            List<GeneralCurrencyMaster> GeneralCurrencyMaster = GetListGeneralCurrencyMaster();
            List<SelectListItem> GeneralCurrencyMasterList = new List<SelectListItem>();
            foreach (GeneralCurrencyMaster item in GeneralCurrencyMaster)
            {
                GeneralCurrencyMasterList.Add(new SelectListItem { Text = item.CurrencyCode, Value = item.CurrencyCode });
            }
            ViewBag.GeneralCurrencyMasterList = new SelectList(GeneralCurrencyMasterList, "Value", "Text");

            //**************************************************************************************************************//
            //List<EmpDesignationMaster> EMPDesignationMaster = GetListDesignationMaster();
            //List<SelectListItem> EMPDesignationMasterList = new List<SelectListItem>();
            //foreach (EmpDesignationMaster item in EMPDesignationMaster)
            //{
            //    EMPDesignationMasterList.Add(new SelectListItem { Text = item.Description, Value = Convert.ToString(item.ID) });
            //}
            //ViewBag.EMPDesignationMasterList = new SelectList(EMPDesignationMasterList, "Value", "Text");



            return PartialView("/Views/Inventory/VendorMaster/GeneralData.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(VendorMasterViewModel model)
        {
            try
            {
                //if (ModelState.IsValid)
                // {
                if (model != null && model.VendorMasterDTO != null)
                {
                    model.VendorMasterDTO.ConnectionString = _connectioString;
                    model.VendorMasterDTO.VendorName = model.VendorName;
                    model.VendorMasterDTO.TaskCode = model.TaskCode;
                    model.VendorMasterDTO.VendorID = model.VendorID;
                    model.VendorMasterDTO.VendorNumber = model.VendorNumber;
                    model.VendorMasterDTO.FirstName = model.FirstName;
                    model.VendorMasterDTO.MiddleName = model.MiddleName;
                    model.VendorMasterDTO.LastName = model.LastName;
                    model.VendorMasterDTO.Address1 = model.Address1;
                    model.VendorMasterDTO.Address2 = model.Address2;
                    model.VendorMasterDTO.Address3 = model.Address3;
                    model.VendorMasterDTO.PhoneNumber = model.PhoneNumber;
                    model.VendorMasterDTO.MobileNumber = model.MobileNumber;
                    model.VendorMasterDTO.Currency = model.Currency;
                    model.VendorMasterDTO.Country = model.Country;
                    model.VendorMasterDTO.CityId = model.CityId;
                    model.VendorMasterDTO.State = model.State;
                    model.VendorMasterDTO.ReturnGoods = model.ReturnGoods;
                    model.VendorMasterDTO.PinCode = model.PinCode;
                    model.VendorMasterDTO.XMLstring = model.XMLstring;
                    model.VendorMasterDTO.XMLstring1 = model.XMLstring1;
                    model.VendorMasterDTO.CreditLimit = model.CreditLimit;
                    model.VendorMasterDTO.AccountNo = model.AccountNo;
                    model.VendorMasterDTO.BankAddress = model.BankAddress;
                    model.VendorMasterDTO.BankName = model.BankName;
                    model.VendorMasterDTO.IFSCCode = model.IFSCCode;
                    model.VendorMasterDTO.Incoterms = model.Incoterms;
                    model.VendorMasterDTO.BranchName = model.BranchName;
                    model.VendorMasterDTO.CashDiscount = model.CashDiscount;
                    model.VendorMasterDTO.Rebate = model.Rebate;
                    model.VendorMasterDTO.VendorFinanceDetailsID = model.VendorFinanceDetailsID;
                    model.VendorMasterDTO.Credit = model.Credit;
                    model.VendorMasterDTO.CashOnDelivery = model.CashOnDelivery;
                    model.VendorMasterDTO.CurrentDatedCheque = model.CurrentDatedCheque;
                    model.VendorMasterDTO.IsCentre = model.IsCentre;
                    model.VendorMasterDTO.CentreCode = model.CentreCode;

                    model.VendorMasterDTO.VendorRestriction = model.VendorRestriction;
                    model.VendorMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    model.VendorMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<VendorMaster> response = _VendorMasterBA.InsertVendorMaster(model.VendorMasterDTO);
                    model.VendorMasterDTO.VendorNumber = response.Entity.VendorNumber;
                    model.VendorMasterDTO.VendorID = model.VendorID;

                    model.VendorMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.VendorMasterDTO, JsonRequestBehavior.AllowGet);
                }


                //  }
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
        public ActionResult UploadExcel(VendorMasterViewModel model)
        {
            try
            {
                //if (ModelState.IsValid)
                // {
                if (model != null && model.VendorMasterDTO != null)
                {
                    UploadExcelFile();
                    model.VendorMasterDTO.ConnectionString = _connectioString;
                    model.VendorMasterDTO.ID = model.ID;
                    model.VendorMasterDTO.XMLstring = xmlParameter;

                    model.VendorMasterDTO.XMLstringForReplenishmentInfo1 = xmlParameterForReplenishmentInfo1;
                    model.VendorMasterDTO.XMLstringForReplenishmentInfo2 = xmlParameterForReplenishmentInfo2;
                    model.VendorMasterDTO.XMLstringForReplenishmentInfo3 = xmlParameterForReplenishmentInfo3;
                    model.VendorMasterDTO.XMLstringForContactPerson1 = xmlParameterForContactPerson1;
                    model.VendorMasterDTO.XMLstringForContactPerson2 = xmlParameterForContactPerson2;
                    model.VendorMasterDTO.XMLstringForContactPerson3 = xmlParameterForContactPerson3;

                    model.VendorMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    if (xmlParameter != string.Empty && xmlParameter != null && IsExcelValid == true)
                    {
                        IBaseEntityResponse<VendorMaster> response = _VendorMasterBA.InsertVendorMasterExcel(model.VendorMasterDTO);
                        //  model.VendorMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);

                        string errorMessageDis = string.Empty;
                        string colorCode = string.Empty;
                        string mode = string.Empty;
                        if (response.Entity.ErrorCode == 18)
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
                        model.VendorMasterDTO.errorMessage = errorMessage;

                    }
                    else if (IsExcelValid == false)
                    {
                        model.VendorMasterDTO.errorMessage = errorMessage;// "Invalide excel column,#FFCC80";
                    }
                    else if (xmlParameter == string.Empty || xmlParameter != null)
                    {
                        model.VendorMasterDTO.errorMessage = errorMessage;// "No data found in excel,#FFCC80";
                    }

                    TempData["_errorMsg"] = model.VendorMasterDTO.errorMessage;
                    xmlParameter = null;
                    IsExcelValid = true;
                    errorMessage = null;
                    return RedirectToAction("Index", "VendorMaster", new { _VendorID = model.VendorID });
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
                //_logException.Error(ex.Message);
                //throw;
                string[] arrayList = { ex.Message, "danger", null };
                TempData["_errorMsg"] = string.Join(",", arrayList);
                errorMessage = null;
                return RedirectToAction("Index", "VendorMaster", new { _VendorID = model.VendorID });
            }

        }

        //[HttpGet]
        //public ActionResult Edit(int id)
        //{
        //    VendorMasterViewModel model = new VendorMasterViewModel();
        //    try
        //    {
        //        model.VendorMasterDTO = new VendorMaster();
        //        model.VendorMasterDTO.ID = id;
        //        model.VendorMasterDTO.ConnectionString = _connectioString;

        //        IBaseEntityResponse<VendorMaster> response = _VendorMasterBA.SelectByID(model.VendorMasterDTO);
        //        if (response != null && response.Entity != null)
        //        {
        //            model.VendorMasterDTO.ID = response.Entity.ID;
        //            model.VendorMasterDTO.GroupDescription = response.Entity.GroupDescription;
        //            model.VendorMasterDTO.GroupCode = response.Entity.GroupCode;
        //            model.VendorMasterDTO.CreatedBy = response.Entity.CreatedBy;
        //        }
        //        return PartialView(model);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        [HttpPost]
        public ActionResult Edit(VendorMasterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model != null && model.VendorMasterDTO != null)
                {
                    if (model != null && model.VendorMasterDTO != null)
                    {
                        model.VendorMasterDTO.ConnectionString = _connectioString;
                        //model.VendorMasterDTO.MovementType = model.MovementType;
                        //model.VendorMasterDTO.MovementCode = model.MovementCode;
                        //model.VendorMasterDTO.IsActive = model.IsActive;

                        model.VendorMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<VendorMaster> response = _VendorMasterBA.UpdateVendorMaster(model.VendorMasterDTO);
                        model.VendorMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                    }
                }
                return Json(model.VendorMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Please review your form");
            }
        }

        //[HttpGet]
        //public ActionResult ViewDetails(string ID)
        //{
        //    try
        //    {
        //        VendorMasterViewModel model = new VendorMasterViewModel();
        //        model.VendorMasterDTO = new VendorMaster();
        //        model.VendorMasterDTO.ID = Convert.ToInt16(ID);
        //        model.VendorMasterDTO.ConnectionString = _connectioString;

        //        IBaseEntityResponse<VendorMaster> response = _VendorMasterBA.SelectByID(model.VendorMasterDTO);
        //        if (response != null && response.Entity != null)
        //        {
        //            model.VendorMasterDTO.GroupDescription = response.Entity.GroupDescription;
        //            model.VendorMasterDTO.MarchandiseGroupCode = response.Entity.MarchandiseGroupCode;
        //        }

        //        List<SelectListItem> GroupCode = new List<SelectListItem>();
        //        ViewBag.GroupCode = new SelectList(GroupCode, "Value", "Text");
        //        List<SelectListItem> GroupCode_li = new List<SelectListItem>();
        //        GroupCode_li.Add(new SelectListItem { Text = "Manufacturing", Value = "1" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Sales", Value = "2" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Purchase", Value = "3" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Warehouse", Value = "4" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Processing", Value = "5" });
        //        ViewData["GroupCode"] = new SelectList(GroupCode_li, "Value", "Text", model.VendorMasterDTO.GroupCode);


        //        //    foreach (GeneralServiceMaster item in GeneralServiceMaster)
        //        //    {
        //        //        GeneralServiceMasterList.Add(new SelectListItem { Text = item.ServiceName, Value = Convert.ToString(item.ID) });
        //        //    }
        //        //    ViewBag.GeneralServiceMasterList = new SelectList(GeneralServiceMasterList, "Value", "Text", model.VendorMasterDTO.GenServiceRequiredID);

        //        return PartialView("/Views/VendorMaster/ViewDetails.cshtml", model);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logException.Error(ex.Message);
        //        throw;
        //    }

        //}

        public ActionResult Delete(int VendorID)
        {
            var errorMessage = string.Empty;
            if (VendorID > 0)
            {
                IBaseEntityResponse<VendorMaster> response = null;
                VendorMasterViewModel model = new VendorMasterViewModel();
                model.VendorMasterDTO.ConnectionString = _connectioString;
                model.VendorMasterDTO.VendorID = Convert.ToInt32(VendorID);
                model.VendorMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                response = _VendorMasterBA.DeleteVendorMaster(model.VendorMasterDTO);
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
            }
            return Json(errorMessage, JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]

        public void UploadExcelFile()
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

                        foreach (ValidationErrorInfo error in validator.Validate(SpreadsheetDocument.Open(filePath, false)))
                        {
                            count++;
                        }

                        if (count <= 0)
                        {

                            xmlParameter = "<rows>";
                            xmlParameterForContactPerson1 = "<rows>";
                            xmlParameterForContactPerson2 = "<rows>";
                            xmlParameterForContactPerson3 = "<rows>";
                            xmlParameterForReplenishmentInfo1 = "<rows>";
                            xmlParameterForReplenishmentInfo2 = "<rows>";
                            xmlParameterForReplenishmentInfo3 = "<rows>";
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
                                foreach (Cell cell in rows.ElementAt(1))
                                {
                                    if (
                                        (GetCellValue(doc, cell)) == "Vendor Name" ||
                                        (GetCellValue(doc, cell)) == "Address 1" ||
                                        (GetCellValue(doc, cell)) == "Address 2" ||
                                        (GetCellValue(doc, cell)) == "Address 3" ||
                                        (GetCellValue(doc, cell)) == "City" ||
                                        (GetCellValue(doc, cell)) == "State" ||
                                        (GetCellValue(doc, cell)) == "Country" ||
                                        (GetCellValue(doc, cell)) == "PIN Code" ||
                                        (GetCellValue(doc, cell)) == "Phone No" ||
                                        (GetCellValue(doc, cell)) == "Mobile No" ||
                                        (GetCellValue(doc, cell)) == "Minimum PO value (Restriction)" ||
                                        (GetCellValue(doc, cell)) == "Currency" ||
                                        //(GetCellValue(doc, cell)) == "Lead Time" ||
                                        (GetCellValue(doc, cell)) == "Credit Limit" ||
                                        (GetCellValue(doc, cell)) == "Incoterms" ||
                                        (GetCellValue(doc, cell)) == "Merchandise Category 1" ||
                                        (GetCellValue(doc, cell)) == "Lead time 1" ||
                                        (GetCellValue(doc, cell)) == "Merchandise Category 2" ||
                                        (GetCellValue(doc, cell)) == "Lead time 2" ||
                                        (GetCellValue(doc, cell)) == "Merchandise Category 3" ||
                                        (GetCellValue(doc, cell)) == "Lead time 3" ||

                                        (GetCellValue(doc, cell)) == "Account No" ||
                                        (GetCellValue(doc, cell)) == "Bank Name" ||
                                        (GetCellValue(doc, cell)) == "Branch Name" ||
                                        (GetCellValue(doc, cell)) == "Address" ||
                                        (GetCellValue(doc, cell)) == "IFSC Code/ IBAN" ||
                                        (GetCellValue(doc, cell)) == "First Name 1" ||
                                        (GetCellValue(doc, cell)) == "Middle Name 1" ||
                                        (GetCellValue(doc, cell)) == "Last Name 1" ||
                                        (GetCellValue(doc, cell)) == "Mobile No 1" ||
                                        (GetCellValue(doc, cell)) == "Email ID 1" ||
                                        (GetCellValue(doc, cell)) == "Designation 1" ||
                                        (GetCellValue(doc, cell)) == "First Name 2" ||
                                        (GetCellValue(doc, cell)) == "Middle Name 2" ||
                                        (GetCellValue(doc, cell)) == "Last Name 2" ||
                                        (GetCellValue(doc, cell)) == "Mobile No 2" ||
                                        (GetCellValue(doc, cell)) == "Email ID 2" ||
                                        (GetCellValue(doc, cell)) == "Designation 2" ||
                                        (GetCellValue(doc, cell)) == "First Name 3" ||
                                        (GetCellValue(doc, cell)) == "Middle Name 3" ||
                                        (GetCellValue(doc, cell)) == "Last Name 3" ||
                                        (GetCellValue(doc, cell)) == "Mobile No 3" ||
                                        (GetCellValue(doc, cell)) == "Email ID 3" ||
                                        (GetCellValue(doc, cell)) == "Designation 3")
                                    {
                                        dt.Columns.Add(GetCellValue(doc, cell));
                                    }
                                    else
                                    {
                                        IsExcelValid = false;
                                        errorMessage = "Invalid excel column,warning";


                                    }

                                }
                                if (dt.Columns.Count > 0)
                                {
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
                                                tempRow[columnIndex] = GetCellValue(doc, cell);

                                                columnIndex++;
                                            }
                                            dt.Rows.Add(tempRow);
                                        }
                                        dt.Rows.RemoveAt(1); //...so i'm taking it out here.

                                        RemoveDuplicateRows(dt, "Vendor Name");




                                        if (extension == ".xls" || extension == ".xlsx")
                                        {
                                            if (
                                                dt.Columns[0].ColumnName != "Vendor Name" ||
                                                dt.Columns[1].ColumnName != "Address 1" ||
                                                dt.Columns[2].ColumnName != "Address 2" ||
                                                dt.Columns[3].ColumnName != "Address 3" ||
                                                dt.Columns[4].ColumnName != "City" ||
                                                dt.Columns[5].ColumnName != "State" ||
                                                dt.Columns[6].ColumnName != "Country" ||
                                                dt.Columns[7].ColumnName != "PIN Code" ||
                                                dt.Columns[8].ColumnName != "Phone No" ||
                                                dt.Columns[9].ColumnName != "Mobile No" ||
                                                dt.Columns[10].ColumnName != "Minimum PO value (Restriction)" ||
                                                dt.Columns[11].ColumnName != "Currency" ||
                                                //dt.Columns[12].ColumnName != "Lead Time" ||
                                                dt.Columns[12].ColumnName != "Credit Limit" ||
                                                dt.Columns[13].ColumnName != "Incoterms" ||
                                                dt.Columns[14].ColumnName != "Merchandise Category 1" ||
                                                dt.Columns[15].ColumnName != "Lead time 1" ||
                                                dt.Columns[16].ColumnName != "Merchandise Category 2" ||
                                                dt.Columns[17].ColumnName != "Lead time 2" ||
                                                dt.Columns[18].ColumnName != "Merchandise Category 3" ||
                                                dt.Columns[19].ColumnName != "Lead time 3" ||
                                                dt.Columns[20].ColumnName != "Account No" ||
                                                dt.Columns[21].ColumnName != "Bank Name" ||
                                                dt.Columns[22].ColumnName != "Branch Name" ||
                                                dt.Columns[23].ColumnName != "Address" ||
                                                dt.Columns[24].ColumnName != "IFSC Code/ IBAN" ||
                                                dt.Columns[25].ColumnName != "First Name 1" ||
                                                dt.Columns[26].ColumnName != "Middle Name 1" ||
                                                dt.Columns[27].ColumnName != "Last Name 1" ||
                                                dt.Columns[28].ColumnName != "Mobile No 1" ||
                                                dt.Columns[29].ColumnName != "Email ID 1" ||
                                                dt.Columns[30].ColumnName != "Designation 1" ||
                                                dt.Columns[31].ColumnName != "First Name 2" ||
                                                dt.Columns[32].ColumnName != "Middle Name 2" ||
                                                dt.Columns[33].ColumnName != "Last Name 2" ||
                                                dt.Columns[34].ColumnName != "Mobile No 2" ||
                                                dt.Columns[35].ColumnName != "Email ID 2" ||
                                                dt.Columns[36].ColumnName != "Designation 2" ||
                                                dt.Columns[37].ColumnName != "First Name 3" ||
                                                dt.Columns[38].ColumnName != "Middle Name 3" ||
                                                dt.Columns[39].ColumnName != "Last Name 3" ||
                                                dt.Columns[40].ColumnName != "Mobile No 3" ||
                                                dt.Columns[41].ColumnName != "Email ID 3" ||
                                                dt.Columns[42].ColumnName != "Designation 3"

                                                )
                                            {
                                                IsExcelValid = false;
                                                errorMessage = "Invalid excel column,warning";
                                            }
                                        }
                                        if (IsExcelValid == true)
                                        {
                                            long result;
                                            //while (dReader.Read())
                                            for (int i = 1; i < (dt.Rows.Count); i++)
                                            {

                                                if (dt.Rows[i]["Vendor Name"].ToString().Trim().Length > 0)
                                                {
                                                    xmlParameter = xmlParameter + "<row><GenSupplierMasterID>0</GenSupplierMasterID><Vender>" + dt.Rows[i]["Vendor Name"].ToString().Trim().Replace("&", "[and]") + "</Vender><AddressFirst>" + dt.Rows[i]["Address 1"].ToString().Trim() + "</AddressFirst><AddressSecond>" + dt.Rows[i]["Address 2"].ToString().Trim() + "</AddressSecond><AddressThird>" + dt.Rows[i]["Address 3"].ToString().Trim() + "</AddressThird><City>" + dt.Rows[i]["City"].ToString().Trim() + "</City><State>" + dt.Rows[i]["State"].ToString().Trim() + "</State><Country>" + dt.Rows[i]["Country"].ToString().Trim() + "</Country><PinCode>" + dt.Rows[i]["PIN Code"].ToString().Trim() + "</PinCode><PhoneNumber>" + dt.Rows[i]["Phone No"].ToString().Trim() + "</PhoneNumber><MobileNo>" + dt.Rows[i]["Mobile No"].ToString().Trim() + "</MobileNo><Currency>" + dt.Rows[i]["Currency"].ToString().Trim() + "</Currency><LeadTime>0</LeadTime><VendorRestriction>" + dt.Rows[i]["Minimum PO value (Restriction)"].ToString().Trim() + "</VendorRestriction><CreditLimit>" + dt.Rows[i]["Credit Limit"].ToString().Trim() + "</CreditLimit><Incoterms>" + dt.Rows[i]["Incoterms"].ToString().Trim() + "</Incoterms><AccountNo>" + dt.Rows[i]["Account No"].ToString().Trim() + "</AccountNo><BankName>" + dt.Rows[i]["Bank Name"].ToString().Trim() + "</BankName><BranchName>" + dt.Rows[i]["Branch Name"].ToString().Trim() + "</BranchName><BankAddress>" + dt.Rows[i]["Address"].ToString().Trim() + "</BankAddress><IFSCCode>" + dt.Rows[i]["IFSC Code/ IBAN"].ToString().Trim() + "</IFSCCode><CityID>" + 0 + "</CityID><CountryID>" + 0 + "</CountryID></row>";

                                                    if ((dt.Rows[i]["Merchandise Category 1"].ToString().Trim().Length > 0) || (dt.Rows[i]["Lead time 1"].ToString().Trim().Length > 0))
                                                        if ((dt.Rows[i]["Merchandise Category 1"].ToString().Trim().Length == 0) || (dt.Rows[i]["Lead time 1"].ToString().Trim().Length == 0))
                                                        {
                                                            IsExcelValid = false;
                                                            errorMessage = "Please Add Category Details,warning";
                                                        }
                                                        else
                                                        {
                                                            xmlParameterForReplenishmentInfo1 = xmlParameterForReplenishmentInfo1 + "<row><ID>" + 0 + "</ID><Vender>" + dt.Rows[i]["Vendor Name"].ToString().Trim().Replace("&", "[and]") + "</Vender><VendorID>" + 0 + "</VendorID><CategoryCode>" + dt.Rows[i]["Merchandise Category 1"].ToString().Trim() + "</CategoryCode><LeadTime>" + dt.Rows[i]["Lead time 1"].ToString().Trim() + "</LeadTime></row>";
                                                        }
                                                    if ((dt.Rows[i]["Merchandise Category 2"].ToString().Trim().Length > 1) || (dt.Rows[i]["Lead time 2"].ToString().Trim().Length > 1))
                                                    {
                                                        xmlParameterForReplenishmentInfo2 = xmlParameterForReplenishmentInfo2 + "<row><ID>" + 0 + "</ID><Vender>" + dt.Rows[i]["Vendor Name"].ToString().Trim().Replace("&", "[and]") + "</Vender><VendorID>" + 0 + "</VendorID><CategoryCode>" + dt.Rows[i]["Merchandise Category 2"].ToString().Trim() + "</CategoryCode><LeadTime>" + dt.Rows[i]["Lead time 2"].ToString().Trim() + "</LeadTime></row>";
                                                    }
                                                    if ((dt.Rows[i]["Merchandise Category 3"].ToString().Trim().Length > 1) || (dt.Rows[i]["Lead time 3"].ToString().Trim().Length > 1))
                                                    {
                                                        xmlParameterForReplenishmentInfo3 = xmlParameterForReplenishmentInfo3 + "<row><ID>" + 0 + "</ID><Vender>" + dt.Rows[i]["Vendor Name"].ToString().Trim().Replace("&", "[and]") + "</Vender><VendorID>" + 0 + "</VendorID><CategoryCode>" + dt.Rows[i]["Merchandise Category 3"].ToString().Trim() + "</CategoryCode><LeadTime>" + dt.Rows[i]["Lead time 3"].ToString().Trim() + "</LeadTime></row>";
                                                    }
                                                    if ((dt.Rows[i]["First Name 1"].ToString().Trim().Length > 0) || (dt.Rows[i]["Last Name 1"].ToString().Trim().Length > 0) || (dt.Rows[i]["Mobile No 1"].ToString().Trim().Length > 0) || (dt.Rows[i]["Email ID 1"].ToString().Trim().Length > 0))
                                                    {
                                                        if ((dt.Rows[i]["First Name 1"].ToString().Trim().Length == 0) || (dt.Rows[i]["Last Name 1"].ToString().Trim().Length == 0) || (dt.Rows[i]["Mobile No 1"].ToString().Trim().Length == 0) || (dt.Rows[i]["Email ID 1"].ToString().Trim().Length == 0))
                                                        {
                                                            IsExcelValid = false;
                                                            errorMessage = "Please Add Contact Person Details,warning";
                                                        }
                                                        else
                                                        {
                                                            xmlParameterForContactPerson1 = xmlParameterForContactPerson1 + "<row><ID>" + 0 + "</ID><Vender>" + dt.Rows[i]["Vendor Name"].ToString().Trim().Replace("&", "[and]") + "</Vender><ContactPersonFirstName1>" + dt.Rows[i]["First Name 1"].ToString().Trim() + "</ContactPersonFirstName1><ContactPersonMiddleName1>" + dt.Rows[i]["Middle Name 1"].ToString().Trim() + "</ContactPersonMiddleName1><ContactPersonLastName1>" + dt.Rows[i]["Last Name 1"].ToString().Trim() + "</ContactPersonLastName1><ContactPersonMobNo1>" + dt.Rows[i]["Mobile No 1"].ToString().Trim() + "</ContactPersonMobNo1><ContactPersonEmailID1>" + dt.Rows[i]["Email ID 1"].ToString().Trim() + "</ContactPersonEmailID1><Designation1>" + dt.Rows[i]["Designation 1"].ToString().Trim().Replace("&", "[and]") + "</Designation1></row>";
                                                        }
                                                    }

                                                    if ((dt.Rows[i]["First Name 2"].ToString().Trim().Length > 1) || (dt.Rows[i]["Last Name 2"].ToString().Trim().Length > 1) || (dt.Rows[i]["Mobile No 2"].ToString().Trim().Length > 1) || (dt.Rows[i]["Email ID 2"].ToString().Trim().Length > 1))
                                                    {
                                                        xmlParameterForContactPerson2 = xmlParameterForContactPerson2 + "<row><ID>" + 0 + "</ID><Vender>" + dt.Rows[i]["Vendor Name"].ToString().Trim().Replace("&", "[and]") + "</Vender><ContactPersonFirstName2>" + dt.Rows[i]["First Name 2"].ToString().Trim() + "</ContactPersonFirstName2><ContactPersonMiddleName2>" + dt.Rows[i]["Middle Name 2"].ToString().Trim() + "</ContactPersonMiddleName2><ContactPersonLastName2>" + dt.Rows[i]["Last Name 2"].ToString().Trim() + "</ContactPersonLastName2><ContactPersonMobNo2>" + dt.Rows[i]["Mobile No 2"].ToString().Trim() + "</ContactPersonMobNo2><ContactPersonEmailID2>" + dt.Rows[i]["Email ID 2"].ToString().Trim() + "</ContactPersonEmailID2><Designation2>" + dt.Rows[i]["Designation 2"].ToString().Trim().Replace("&", "[and]") + "</Designation2></row>";
                                                    }

                                                    if ((dt.Rows[i]["First Name 3"].ToString().Trim().Length > 1) || (dt.Rows[i]["Last Name 3"].ToString().Trim().Length > 1) || (dt.Rows[i]["Mobile No 3"].ToString().Trim().Length > 1) || (dt.Rows[i]["Email ID 3"].ToString().Trim().Length > 1))
                                                    {
                                                        xmlParameterForContactPerson3 = xmlParameterForContactPerson3 + "<row><ID>" + 0 + "</ID><Vender>" + dt.Rows[i]["Vendor Name"].ToString().Trim().Replace("&", "[and]") + "</Vender><ContactPersonFirstName3>" + dt.Rows[i]["First Name 3"].ToString().Trim() + "</ContactPersonFirstName3><ContactPersonMiddleName3>" + dt.Rows[i]["Middle Name 3"].ToString().Trim() + "</ContactPersonMiddleName3><ContactPersonLastName3>" + dt.Rows[i]["Last Name 3"].ToString().Trim() + "</ContactPersonLastName3><ContactPersonMobNo3>" + dt.Rows[i]["Mobile No 3"].ToString().Trim() + "</ContactPersonMobNo3><ContactPersonEmailID3>" + dt.Rows[i]["Email ID 3"].ToString().Trim() + "</ContactPersonEmailID3><Designation3>" + dt.Rows[i]["Designation 3"].ToString().Trim().Replace("&", "[and]") + "</Designation3></row>";
                                                    }

                                                }
                                                //}
                                            }
                                            if (xmlParameter.Length > 9)
                                            {
                                                xmlParameter = xmlParameter + "</rows>";
                                                if (xmlParameterForReplenishmentInfo1.Length > 9)
                                                {
                                                    xmlParameterForReplenishmentInfo1 = xmlParameterForReplenishmentInfo1 + "</rows>";
                                                }
                                                else
                                                {
                                                    xmlParameterForReplenishmentInfo1 = null;
                                                }
                                                if (xmlParameterForReplenishmentInfo2.Length > 9)
                                                {
                                                    xmlParameterForReplenishmentInfo2 = xmlParameterForReplenishmentInfo2 + "</rows>";
                                                }
                                                else
                                                {
                                                    xmlParameterForReplenishmentInfo2 = null;
                                                }
                                                if (xmlParameterForReplenishmentInfo3.Length > 9)
                                                {
                                                    xmlParameterForReplenishmentInfo3 = xmlParameterForReplenishmentInfo3 + "</rows>";
                                                }
                                                else
                                                {
                                                    xmlParameterForReplenishmentInfo3 = null;
                                                }
                                                if (xmlParameterForContactPerson1.Length > 9)
                                                {
                                                    xmlParameterForContactPerson1 = xmlParameterForContactPerson1 + "</rows>";
                                                }
                                                else
                                                {
                                                    xmlParameterForContactPerson1 = null;
                                                }
                                                if (xmlParameterForContactPerson2.Length > 9)
                                                {
                                                    xmlParameterForContactPerson2 = xmlParameterForContactPerson2 + "</rows>";
                                                }
                                                else
                                                {
                                                    xmlParameterForContactPerson2 = null;
                                                }
                                                if (xmlParameterForContactPerson3.Length > 9)
                                                {
                                                    xmlParameterForContactPerson3 = xmlParameterForContactPerson3 + "</rows>";
                                                }
                                                else
                                                {
                                                    xmlParameterForContactPerson3 = null;
                                                }
                                            }
                                            else
                                            {
                                                xmlParameter = string.Empty;
                                                errorMessage = "No data found in excel,warning";
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    IsExcelValid = false;
                                    //errorMessage = "The selected file does not appear to be an excel file,warning";
                                    errorMessage = "Invalid excel file,warning";
                                }
                                dt.Dispose();
                            }

                            // excelConnection.Close();

                            // SQL Server Connection String
                        }
                        else
                        {
                            IsExcelValid = false;
                            errorMessage = "Invalid excel file,warning";
                        }
                    }
                    else
                    {
                        IsExcelValid = false;
                        errorMessage = "Please Upload Downloaded File,warning";
                    }
                }
                else
                {
                    IsExcelValid = false;
                    errorMessage = "Excel file not selected,warning";
                }
            }

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
                errorMessage = "Do not add same vendor name twice,#FFCC80";

            //Datatable which contains unique records will be return as output.

            return dTable;
        }

        #endregion

        // Non-Action Method
        #region Methods

        //public JsonResult GetCityList(string term)
        //{
        //    var data = GetCityListDetails(term);
        //    var result = (from r in data
        //                  select new
        //                  {
        //                      id = r.ID,
        //                      name = r.Description,
        //                  }).ToList();
        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetRegionByCountryID(string Country)
        {
            if (String.IsNullOrEmpty(Country))
            {
                throw new ArgumentNullException("SelectedCountryID");
            }
            int id = 0;
            bool isValid = Int32.TryParse(Country, out id);
            var Region = GetListGeneralRegionMaster(Country);
            var result = (from s in Region select new { id = s.ID, name = s.RegionName, }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetCityByRegionID(string State)
        {
            if (String.IsNullOrEmpty(State))
            {
                throw new ArgumentNullException("State");
            }
            int id = 0;
            bool isValid = Int32.TryParse(State, out id);
            var City = GetListGeneralCityMaster(State);
            var result = (from s in City select new { id = s.ID, name = s.Description, }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public List<GeneralCityMaster> GetCityListDetails(string SearchKeyWord)
        {
            GeneralCityMasterSearchRequest searchRequest = new GeneralCityMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.SearchWord = SearchKeyWord;

            List<GeneralCityMaster> listAccount = new List<GeneralCityMaster>();
            IBaseEntityCollectionResponse<GeneralCityMaster> baseEntityCollectionResponse = _generalCityMasterBA.GetBySearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listAccount = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listAccount;
        }
        protected List<GeneralCountryMaster> GetListGeneralCountryMaster()
        {
            GeneralCountryMasterSearchRequest searchRequest = new GeneralCountryMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<GeneralCountryMaster> ListGeneralCountryMaster = new List<GeneralCountryMaster>();
            IBaseEntityCollectionResponse<GeneralCountryMaster> baseEntityCollectionResponse = _GeneralCountryMasterBA.GetBySearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    ListGeneralCountryMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return ListGeneralCountryMaster;
        }

        protected List<GeneralCurrencyMaster> GetListGeneralCurrencyMaster()
        {
            GeneralCurrencyMasterSearchRequest searchRequest = new GeneralCurrencyMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<GeneralCurrencyMaster> ListGeneralCurrencyMaster = new List<GeneralCurrencyMaster>();
            IBaseEntityCollectionResponse<GeneralCurrencyMaster> baseEntityCollectionResponse = _GeneralCurrencyMasterBA.GetBySearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    ListGeneralCurrencyMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return ListGeneralCurrencyMaster;
        }

        protected List<GeneralItemCategoryMaster> GetListGeneralItemCategoryMaster()
        {
            GeneralItemCategoryMasterSearchRequest searchRequest = new GeneralItemCategoryMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<GeneralItemCategoryMaster> listtGeneralPriceGroup = new List<GeneralItemCategoryMaster>();
            IBaseEntityCollectionResponse<GeneralItemCategoryMaster> baseEntityCollectionResponse = _GeneralItemCategoryMasterBA.GetGeneralItemCategoryMasterSearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listtGeneralPriceGroup = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listtGeneralPriceGroup;
        }

        protected List<EmpDesignationMaster> GetListDesignationMaster()
        {
            EmpDesignationMasterSearchRequest searchRequest = new EmpDesignationMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<EmpDesignationMaster> listtGeneralPriceGroup = new List<EmpDesignationMaster>();
            IBaseEntityCollectionResponse<EmpDesignationMaster> baseEntityCollectionResponse = _EmpDesignationMasterBA.GetBySearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listtGeneralPriceGroup = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listtGeneralPriceGroup;
        }

        //Model method to access data for contact person
        protected List<VendorMaster> GetVendorMasterListForGeneralData(string VendorID)
        {
            VendorMasterSearchRequest searchRequest = new VendorMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.VendorID = Convert.ToInt32(!string.IsNullOrEmpty(VendorID) ? VendorID : null);
            List<VendorMaster> listVendorMaster = new List<VendorMaster>();
            IBaseEntityCollectionResponse<VendorMaster> baseEntityCollectionResponse = _VendorMasterBA.GetContactPersonDetailsForVendorMaster(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listVendorMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listVendorMaster;
        }
        protected List<VendorMaster> GetVendorMasterListForPersonalDetails(string VendorID)
        {
            VendorMasterSearchRequest searchRequest = new VendorMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.VendorID = Convert.ToInt32(!string.IsNullOrEmpty(VendorID) ? VendorID : null);
            List<VendorMaster> listVendorMaster = new List<VendorMaster>();
            IBaseEntityCollectionResponse<VendorMaster> baseEntityCollectionResponse = _VendorMasterBA.GetReplenishmentDataByVendorNumber(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listVendorMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listVendorMaster;
        }
        //Json Method to access data for contact person
        public JsonResult GetVendorMasterListGeneralData(string VendorID)
        {
            VendorMasterSearchRequest searchRequest = new VendorMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.VendorID = Convert.ToInt32(!string.IsNullOrEmpty(VendorID) ? VendorID : null);
            List<VendorMaster> listVendorMaster = new List<VendorMaster>();
            IBaseEntityCollectionResponse<VendorMaster> baseEntityCollectionResponse = _VendorMasterBA.GetContactPersonDetailsForVendorMaster(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listVendorMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            var result = listVendorMaster;
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        //Json Method to access data for replenishment tab
        public JsonResult GetVendorMasterListPersonalDetails(string VendorID)
        {
            VendorMasterSearchRequest searchRequest = new VendorMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.VendorID = Convert.ToInt32(!string.IsNullOrEmpty(VendorID) ? VendorID : null);
            List<VendorMaster> listVendorMaster = new List<VendorMaster>();
            IBaseEntityCollectionResponse<VendorMaster> baseEntityCollectionResponse = _VendorMasterBA.GetReplenishmentDataByVendorNumber(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listVendorMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            var result = listVendorMaster;
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult GetVendorSearchList(string term)
        {
            VendorMasterSearchRequest searchRequest = new VendorMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.SearchWord = term;
            List<VendorMaster> listFeeSubType = new List<VendorMaster>();
            IBaseEntityCollectionResponse<VendorMaster> baseEntityCollectionResponse = _VendorMasterBA.GetVendorMasterSearchList(searchRequest);
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
                              id = r.ID,
                              name = r.VendorName,
                              VendorName = r.VendorName,
                              VendorNumber = r.VendorNumber,
                              Address1 = r.Address1,
                              Address2 = r.Address2,
                              Address3 = r.Address3,
                              Name = r.Name,
                              ContactPersonMobNumber = r.ContactPersonMobNumber,
                              EmailID = r.EmailID,
                              MerchandiseCategory = r.MerchandiseCategory,
                              LeadTime = r.LeadTime,
                              PhoneNumber = r.PhoneNumber,
                              MobileNumber = r.MobileNumber,
                              Country = r.Country,
                              Currency = r.Currency,
                              FirstName = r.FirstName,
                              MiddleName = r.MiddleName,
                              LastName = r.LastName,
                              CityId = r.CityId,
                              City = r.City,
                              PinCode = r.PinCode,
                              ReturnGoods = r.ReturnGoods,
                              CreditLimit = r.CreditLimit,
                              IFSCCode = r.IFSCCode,
                              Incoterms = r.Incoterms,
                              BankAddress = r.BankAddress,
                              BranchName = r.BranchName,
                              AccountNo = r.AccountNo,
                              BankName = r.BankName,
                              State = r.State,
                              PersonDesgDesc = r.PersonDesgDesc,
                              CashDiscount = r.CashDiscount,
                              Rebate = r.Rebate,
                              CPFirstName = r.CPFirstName,
                              CPMiddleName = r.CPMiddleName,
                              CPLastName = r.CPLastName,
                              CashOnDelivery = r.CashOnDelivery,
                              Credit = r.Credit,
                              CurrentDatedCheque = r.CurrentDatedCheque,
                              VendorCode = r.VendorCode

                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public IEnumerable<VendorMasterViewModel> GetVendorMaster(out int TotalRecords)
        {
            VendorMasterSearchRequest searchRequest = new VendorMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            _actionMode = Convert.ToString(TempData["ActionMode"]);
            if (Enum.TryParse(_actionMode, out actionModeEnum))     // checks actionMode i.e. Insert or Update // 
            {
                if (actionModeEnum == ActionModeEnum.Insert)        // parameters for SelectAll procedures under Insert or Update mode condition
                {
                    searchRequest.SortBy = "A.ID,B.ID";
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
            List<VendorMasterViewModel> listVendorMasterViewModel = new List<VendorMasterViewModel>();
            List<VendorMaster> listVendorMaster = new List<VendorMaster>();
            IBaseEntityCollectionResponse<VendorMaster> baseEntityCollectionResponse = _VendorMasterBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listVendorMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (VendorMaster item in listVendorMaster)
                    {
                        VendorMasterViewModel VendorMasterViewModel = new VendorMasterViewModel();
                        VendorMasterViewModel.VendorMasterDTO = item;
                        listVendorMasterViewModel.Add(VendorMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listVendorMasterViewModel;
        }

        public FileResult Download()
        {

            string FileName = "VendorMaster.xlsx";
            string filePath = Path.Combine(Server.MapPath("~") + "Content\\DownloadFiles\\", FileName);
            System.IO.File.Delete(filePath);
            CreateExcelDoc(filePath);
            InsertVendorDataInExcel(filePath);
            string contentType = "application/vnd.ms-excel";
            return File(filePath, contentType, FileName);
        }

        public void CreateExcelDoc(string fileName)
        {
            using (SpreadsheetDocument document = SpreadsheetDocument.Create(fileName, SpreadsheetDocumentType.Workbook))
            {
                WorkbookPart workbookPart = document.AddWorkbookPart();
                workbookPart.Workbook = new Workbook();

                WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                worksheetPart.Worksheet = new Worksheet(new SheetData());

                Sheets sheets = workbookPart.Workbook.AppendChild(new Sheets());

                Sheet sheet = new Sheet() { Id = workbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = "Vendor Master" };

                MergeCells mergeCells = new MergeCells();
                mergeCells.Append(new MergeCell() { Reference = new StringValue("B1:J1") });
                mergeCells.Append(new MergeCell() { Reference = new StringValue("K1:T1") });
                mergeCells.Append(new MergeCell() { Reference = new StringValue("U1:Y1") });
                mergeCells.Append(new MergeCell() { Reference = new StringValue("Z1:AE1") });
                mergeCells.Append(new MergeCell() { Reference = new StringValue("AF1:AK1") });
                mergeCells.Append(new MergeCell() { Reference = new StringValue("AL1:AQ1") });

                worksheetPart.Worksheet.InsertAfter(mergeCells, worksheetPart.Worksheet.Elements<SheetData>().First());

                VendorMasterViewModel model = new VendorMasterViewModel();
                model.VendorMasterDTO.ConnectionString = _connectioString;
                IBaseEntityResponse<VendorMaster> response = _VendorMasterBA.GetDataValidationListsForExcel(model.VendorMasterDTO);
                if (response != null && response.Entity != null)
                {
                    model.VendorMasterDTO.CountryList = response.Entity.CountryList;
                    model.VendorMasterDTO.CityList = response.Entity.CityList;
                    model.VendorMasterDTO.CurrencyList = response.Entity.CurrencyList;
                    model.VendorMasterDTO.CategoryList = response.Entity.CategoryList;
                }

                DataValidation dataValidation = new DataValidation
                {
                    Type = DataValidationValues.List,
                    AllowBlank = true,
                    SequenceOfReferences = new ListValue<StringValue>() { InnerText = "G4:G100" },
                    Formula1 = new Formula1(string.Concat("\"", model.VendorMasterDTO.CountryList, "\"")),
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

                //DataValidation dataValidation1 = new DataValidation
                //{
                //    Type = DataValidationValues.List,
                //    AllowBlank = true,
                //    SequenceOfReferences = new ListValue<StringValue>() { InnerText = "E4:E100" },
                //    Formula1 = new Formula1(string.Concat("\"", model.VendorMasterDTO.CityList, "\""))
                //};
                //DataValidations dvs1 = worksheetPart.Worksheet.GetFirstChild<DataValidations>();
                //dvs1.Count = dvs1.Count + 1;
                //dvs1.Append(dataValidation1);

                DataValidation dataValidation2 = new DataValidation
                {
                    Type = DataValidationValues.List,
                    AllowBlank = true,
                    SequenceOfReferences = new ListValue<StringValue>() { InnerText = "L4:L100" },
                    Formula1 = new Formula1(string.Concat("\"", model.VendorMasterDTO.CurrencyList, "\"")),
                    ShowErrorMessage = true,
                    ErrorStyle = DataValidationErrorStyleValues.Stop,
                    ErrorTitle = new StringValue("Incorrect Value"),
                    Error = new StringValue("Please select value from list.")
                };
                DataValidations dvs2 = worksheetPart.Worksheet.GetFirstChild<DataValidations>();
                dvs2.Count = dvs2.Count + 1;
                dvs2.Append(dataValidation2);

                DataValidation dataValidation3 = new DataValidation
                {
                    Type = DataValidationValues.Whole,
                    AllowBlank = true,
                    SequenceOfReferences = new ListValue<StringValue>() { InnerText = "K4:K100" },
                    Formula1 = new Formula1("1"),
                    Formula2 = new Formula2("99999"),
                    ShowErrorMessage = true,
                    ErrorStyle = DataValidationErrorStyleValues.Stop,
                    ErrorTitle = new StringValue("Incorrect Value"),
                    Error = new StringValue("Please enter numeric value.")
                };
                DataValidations dvs3 = worksheetPart.Worksheet.GetFirstChild<DataValidations>();
                dvs3.Count = dvs3.Count + 1;
                dvs3.Append(dataValidation3);

                DataValidation dataValidation4 = new DataValidation
                {
                    Type = DataValidationValues.Whole,
                    AllowBlank = true,
                    SequenceOfReferences = new ListValue<StringValue>() { InnerText = "M4:M100" },
                    Formula1 = new Formula1("1"),
                    Formula2 = new Formula2("99999"),
                    ShowErrorMessage = true,
                    ErrorStyle = DataValidationErrorStyleValues.Stop,
                    ErrorTitle = new StringValue("Incorrect Value"),
                    Error = new StringValue("Please enter numeric value.")
                };
                DataValidations dvs4 = worksheetPart.Worksheet.GetFirstChild<DataValidations>();
                dvs4.Count = dvs4.Count + 1;
                dvs4.Append(dataValidation4);

                DataValidation dataValidation5 = new DataValidation
                {
                    Type = DataValidationValues.List,
                    AllowBlank = true,
                    SequenceOfReferences = new ListValue<StringValue>() { InnerText = "O4:O100" },
                    Formula1 = new Formula1(string.Concat("\"", model.VendorMasterDTO.CategoryList, "\"")),
                    ShowErrorMessage = true,
                    ErrorStyle = DataValidationErrorStyleValues.Stop,
                    ErrorTitle = new StringValue("Incorrect Value"),
                    Error = new StringValue("Please select value from list.")
                };
                DataValidations dvs5 = worksheetPart.Worksheet.GetFirstChild<DataValidations>();
                dvs5.Count = dvs5.Count + 1;
                dvs5.Append(dataValidation5);

                DataValidation dataValidation6 = new DataValidation
                {
                    Type = DataValidationValues.List,
                    AllowBlank = true,
                    SequenceOfReferences = new ListValue<StringValue>() { InnerText = "Q4:Q100" },
                    Formula1 = new Formula1(string.Concat("\"", model.VendorMasterDTO.CategoryList, "\"")),
                    ShowErrorMessage = true,
                    ErrorStyle = DataValidationErrorStyleValues.Stop,
                    ErrorTitle = new StringValue("Incorrect Value"),
                    Error = new StringValue("Please select value from list.")
                };
                DataValidations dvs6 = worksheetPart.Worksheet.GetFirstChild<DataValidations>();
                dvs6.Count = dvs6.Count + 1;
                dvs6.Append(dataValidation6);

                DataValidation dataValidation7 = new DataValidation
                {
                    Type = DataValidationValues.List,
                    AllowBlank = true,
                    SequenceOfReferences = new ListValue<StringValue>() { InnerText = "S4:S100" },
                    Formula1 = new Formula1(string.Concat("\"", model.VendorMasterDTO.CategoryList, "\"")),
                    ShowErrorMessage = true,
                    ErrorStyle = DataValidationErrorStyleValues.Stop,
                    ErrorTitle = new StringValue("Incorrect Value"),
                    Error = new StringValue("Please select value from list.")
                };
                DataValidations dvs7 = worksheetPart.Worksheet.GetFirstChild<DataValidations>();
                dvs7.Count = dvs7.Count + 1;
                dvs7.Append(dataValidation7);

                sheets.Append(sheet);

                WorkbookStylesPart stylesPart = workbookPart.AddNewPart<WorkbookStylesPart>();
                stylesPart.Stylesheet = GenerateStyleSheet();
                stylesPart.Stylesheet.Save();

                workbookPart.Workbook.Save();
                document.Close();
            }
        }

        public void InsertVendorDataInExcel(string fileName)
        {
            string[] HeaderData = new string[] { "Vendor Name", "Address 1", "Address 2", "Address 3", "City", "State", "Country", "PIN Code", "Phone No", "Mobile No", "Minimum PO value (Restriction)", "Currency", "Credit Limit", "Incoterms", "Merchandise Category 1", "Lead time 1", "Merchandise Category 2", "Lead time 2", "Merchandise Category 3", "Lead time 3", "Account No", "Bank Name", "Branch Name", "Address", "IFSC Code/ IBAN", "First Name 1", "Middle Name 1", "Last Name 1", "Mobile No 1", "Email ID 1", "Designation 1", "First Name 2", "Middle Name 2", "Last Name 2", "Mobile No 2", "Email ID 2", "Designation 2", "First Name 3", "Middle Name 3", "Last Name 3", "Mobile No 3", "Email ID 3", "Designation 3" };

            string[] ColumnsData = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "AA", "AB", "AC", "AD", "AE", "AF", "AG", "AH", "AI", "AJ", "AK", "AL", "AM", "AN", "AO", "AP", "AQ" };

            InsertTextInExcel(fileName, "", "A", 1);
            InsertTextInExcel(fileName, "General Information", "B", 1);
            InsertTextInExcel(fileName, "Category Details", "K", 1);
            InsertTextInExcel(fileName, "Bank Details", "U", 1);
            InsertTextInExcel(fileName, "Contact Person 1", "Z", 1);
            InsertTextInExcel(fileName, "Contact Person 2", "AF", 1);
            InsertTextInExcel(fileName, "Contact Person 3", "AL", 1);

            for (uint i = 0; i < HeaderData.Length; i++)
            {
                InsertTextInExcel(fileName, HeaderData[i], ColumnsData[i], 2);
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
                if (cell.CellReference.Value == "A1" || cell.CellReference.Value == "A2")
                {
                    cell.StyleIndex = 5;
                }
                else if (cell.CellReference.Value == "B1")
                {
                    cell.StyleIndex = 6;
                }
                else if (cell.CellReference.Value == "K1")
                {
                    cell.StyleIndex = 7;
                }
                if (cell.CellReference.Value == "U1")
                {
                    cell.StyleIndex = 8;
                }
                if (cell.CellReference.Value == "Z1" || cell.CellReference.Value == "AF1" || cell.CellReference.Value == "AL1")
                {
                    cell.StyleIndex = 9;
                }
                else if (cell.CellReference.Value == "B2" || cell.CellReference.Value == "C2" || cell.CellReference.Value == "D2" || cell.CellReference.Value == "E2" || cell.CellReference.Value == "F2" || cell.CellReference.Value == "G2" || cell.CellReference.Value == "H2" || cell.CellReference.Value == "I2" || cell.CellReference.Value == "J2")
                {
                    cell.StyleIndex = 10;
                }
                else if (cell.CellReference.Value == "K2" || cell.CellReference.Value == "L2" || cell.CellReference.Value == "M2" || cell.CellReference.Value == "N2" || cell.CellReference.Value == "O2" || cell.CellReference.Value == "P2" || cell.CellReference.Value == "Q2" || cell.CellReference.Value == "R2" || cell.CellReference.Value == "S2" || cell.CellReference.Value == "T2")
                {
                    cell.StyleIndex = 11;
                }
                else if (cell.CellReference.Value == "U2" || cell.CellReference.Value == "V2" || cell.CellReference.Value == "W2" || cell.CellReference.Value == "X2" || cell.CellReference.Value == "Y2")
                {
                    cell.StyleIndex = 12;
                }
                else if (cell.CellReference.Value == "Z2" || cell.CellReference.Value == "AA2" || cell.CellReference.Value == "AB2" || cell.CellReference.Value == "AC2" || cell.CellReference.Value == "AD2" || cell.CellReference.Value == "AE2" || cell.CellReference.Value == "AL2" || cell.CellReference.Value == "AM2" || cell.CellReference.Value == "AN2" || cell.CellReference.Value == "AO2" || cell.CellReference.Value == "AP2" || cell.CellReference.Value == "AQ2")
                {
                    cell.StyleIndex = 13;
                }
                else if (cell.CellReference.Value == "AF2" || cell.CellReference.Value == "AG2" || cell.CellReference.Value == "AH2" || cell.CellReference.Value == "AI2" || cell.CellReference.Value == "AJ2" || cell.CellReference.Value == "AK2")
                {
                    cell.StyleIndex = 14;
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
                            new ForegroundColor() { Rgb = new HexBinaryValue() { Value = "4F6228" } }
                        )
                        { PatternType = PatternValues.Solid }),
                    new Fill(                                                           // Index 3 – The yellow fill.
                        new PatternFill(
                            new ForegroundColor() { Rgb = new HexBinaryValue() { Value = "75923C" } }
                        )
                        { PatternType = PatternValues.Solid }),
                    new Fill(                                                           // Index 4 – The yellow fill.
                        new PatternFill(
                            new ForegroundColor() { Rgb = new HexBinaryValue() { Value = "000000" } }
                        )
                        { PatternType = PatternValues.Solid }),
                    new Fill(                                                           // Index 5 – The yellow fill.
                        new PatternFill(
                            new ForegroundColor() { Rgb = new HexBinaryValue() { Value = "C0504D" } }
                        )
                        { PatternType = PatternValues.Solid }),
                    new Fill(                                                           // Index 6 – The yellow fill.
                        new PatternFill(
                            new ForegroundColor() { Rgb = new HexBinaryValue() { Value = "948B54" } }
                        )
                        { PatternType = PatternValues.Solid }),
                    new Fill(                                                           // Index 7 – The yellow fill.
                        new PatternFill(
                            new ForegroundColor() { Rgb = new HexBinaryValue() { Value = "EAF1DD" } }
                        )
                        { PatternType = PatternValues.Solid }),
                    new Fill(                                                           // Index 8 – The yellow fill.
                        new PatternFill(
                            new ForegroundColor() { Rgb = new HexBinaryValue() { Value = "DBE5F1" } }
                        )
                        { PatternType = PatternValues.Solid }),
                    new Fill(                                                           // Index 9 – The yellow fill.
                        new PatternFill(
                            new ForegroundColor() { Rgb = new HexBinaryValue() { Value = "F2DDDC" } }
                        )
                        { PatternType = PatternValues.Solid }),
                    new Fill(                                                           // Index 10 – The yellow fill.
                        new PatternFill(
                            new ForegroundColor() { Rgb = new HexBinaryValue() { Value = "DDD9C3" } }
                        )
                        { PatternType = PatternValues.Solid }),
                    new Fill(                                                           // Index 10 – The yellow fill.
                        new PatternFill(
                            new ForegroundColor() { Rgb = new HexBinaryValue() { Value = "EEECE1" } }
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
                    { FontId = 1, FillId = 2, BorderId = 1, ApplyAlignment = true },
                    new CellFormat(                                                                   // Index 6 – Alignment
                        new Alignment() { Horizontal = HorizontalAlignmentValues.Center, Vertical = VerticalAlignmentValues.Center, WrapText = true }
                    )
                    { FontId = 1, FillId = 3, BorderId = 1, ApplyAlignment = true },
                    new CellFormat(                                                                   // Index 7 – Alignment
                        new Alignment() { Horizontal = HorizontalAlignmentValues.Center, Vertical = VerticalAlignmentValues.Center, WrapText = true }
                    )
                    { FontId = 1, FillId = 4, BorderId = 1, ApplyAlignment = true },
                    new CellFormat(                                                                   // Index 8 – Alignment
                        new Alignment() { Horizontal = HorizontalAlignmentValues.Center, Vertical = VerticalAlignmentValues.Center, WrapText = true }
                    )
                    { FontId = 1, FillId = 5, BorderId = 1, ApplyAlignment = true },
                    new CellFormat(                                                                   // Index 9 – Alignment
                        new Alignment() { Horizontal = HorizontalAlignmentValues.Center, Vertical = VerticalAlignmentValues.Center, WrapText = true }
                    )
                    { FontId = 0, FillId = 6, BorderId = 1, ApplyAlignment = true },
                    new CellFormat(                                                                   // Index 10 – Alignment
                        new Alignment() { Horizontal = HorizontalAlignmentValues.Center, Vertical = VerticalAlignmentValues.Center, WrapText = true }
                    )
                    { FontId = 0, FillId = 7, BorderId = 1, ApplyAlignment = true },
                    new CellFormat(                                                                   // Index 11 – Alignment
                        new Alignment() { Horizontal = HorizontalAlignmentValues.Center, Vertical = VerticalAlignmentValues.Center, WrapText = true }
                    )
                    { FontId = 0, FillId = 8, BorderId = 1, ApplyAlignment = true },
                    new CellFormat(                                                                   // Index 12 – Alignment
                        new Alignment() { Horizontal = HorizontalAlignmentValues.Center, Vertical = VerticalAlignmentValues.Center, WrapText = true }
                    )
                    { FontId = 0, FillId = 9, BorderId = 1, ApplyAlignment = true },
                    new CellFormat(                                                                   // Index 13 – Alignment
                        new Alignment() { Horizontal = HorizontalAlignmentValues.Center, Vertical = VerticalAlignmentValues.Center, WrapText = true }
                    )
                    { FontId = 0, FillId = 10, BorderId = 1, ApplyAlignment = true },
                    new CellFormat(                                                                   // Index 14 – Alignment
                        new Alignment() { Horizontal = HorizontalAlignmentValues.Center, Vertical = VerticalAlignmentValues.Center, WrapText = true }
                    )
                    { FontId = 0, FillId = 11, BorderId = 1, ApplyAlignment = true },
                    new CellFormat() { FontId = 0, FillId = 0, BorderId = 1, ApplyBorder = true }      // Index 15 – Border
                )
            ); // return
        }

        #endregion

        // AjaxHandler Method
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        {
            if (Session["UserType"] != null)
            {
                int TotalRecords;
                var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
                string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

                IEnumerable<VendorMasterViewModel> filteredGroupDescription;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "A.ID,B.ID";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = "A.MovementType Like '%" + param.sSearch + "%'";
                        }
                        else
                        {
                            _searchBy = "A.ID Like '%" + param.sSearch + "%' or B.Direction Like '%" + param.sSearch + "%' or B.RequisitionBehaviour Like '%" + param.sSearch + "%'";
                        }
                        break;
                    case 1:
                        _sortBy = "A.ID,B.ID";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            //_searchBy = string.Empty;
                            _searchBy = "A.ID Like '%" + param.sSearch + "%'";

                        }
                        else
                        {
                            _searchBy = "A.ID Like '%" + param.sSearch + "%' or B.Direction Like '%" + param.sSearch + "%' or B.RequisitionBehaviour Like '%" + param.sSearch + "%'";
                        }
                        break;
                    case 2:
                        _sortBy = "A.ID,B.ID";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "A.MovementType Like '%" + param.sSearch + "%' or B.Direction Like '%" + param.sSearch + "%' or B.RequisitionBehaviour Like '%" + param.sSearch + "%'";
                        }
                        break;
                    case 3:
                        _sortBy = "A.ID,B.ID";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = "A.ID Like '%" + param.sSearch + "%' or B.ID Like '%" + param.sSearch + "%'";
                        }
                        else
                        {
                            _searchBy = "A.MovementType Like '%" + param.sSearch + "%' or B.Direction Like '%" + param.sSearch + "%' or B.RequisitionBehaviour Like '%" + param.sSearch + "%'";
                        }
                        break;
                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                filteredGroupDescription = GetVendorMaster(out TotalRecords);


                var records = filteredGroupDescription.Skip(0).Take(param.iDisplayLength);
                //var result = from c in records select new[] { Convert.ToString(c.MovementType), Convert.ToString(c.MovementCode), Convert.ToString(c.IsActive), Convert.ToString(c.ID) };
                var result = from c in records select new[] { Convert.ToString(c.ID) };
                return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
            }
            else
            {

                //return View("Login","Account");
                //return RedirectToAction("Login", "Account");
                var result = 0;
                return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
                // return PartialView("Login");
            }
        }
        #endregion
    }
}