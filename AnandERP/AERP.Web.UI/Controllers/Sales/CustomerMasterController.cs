
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
namespace AERP.Web.UI.Controllers
{
    public class CustomerMasterController : BaseController
    {
        ICustomerMasterBA _CustomerMasterBA = null;
        IGeneralCurrencyMasterBA _GeneralCurrencyMasterBA = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public CustomerMasterController()
        {
            _CustomerMasterBA = new CustomerMasterBA();
            _GeneralCurrencyMasterBA = new GeneralCurrencyMasterBA();

        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
            bool IsApplied = CheckMenuApplicableOrNot(ControllerContext.RouteData.Values["Controller"].ToString());
            if (Convert.ToString(Session["UserType"]) == "A" || ((Convert.ToInt32(Session["Sales Manager"]) > 0 || Convert.ToInt32(Session["Sales Manager:Entity"]) > 0 || Convert.ToInt32(Session["Store Manager"]) > 0) && IsApplied == true))
            {
                return View("/Views/Sales/CustomerMaster/Index.cshtml");
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
                CustomerMasterViewModel model = new CustomerMasterViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Sales/CustomerMaster/List.cshtml", model);
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
            CustomerMasterViewModel model = new CustomerMasterViewModel();

            List<GeneralCountryMaster> GeneralCountryMasterList = GetListGeneralCountryMaster();
            List<SelectListItem> genCountryMaster = new List<SelectListItem>();
            foreach (GeneralCountryMaster item in GeneralCountryMasterList)
            {
                genCountryMaster.Add(new SelectListItem { Text = item.CountryName, Value = item.ID.ToString() });
            }
            ViewBag.GeneralCountryMaster = new SelectList(genCountryMaster, "Value", "Text");
            List<SelectListItem> generalRegionMaster = new List<SelectListItem>();
            ViewBag.GeneralRegionMaster = new SelectList(generalRegionMaster, "Value", "Text");
            List<SelectListItem> generalCityMaster = new List<SelectListItem>();
            ViewBag.GeneralCityMaster = new SelectList(generalCityMaster, "Value", "Text");

            List<SelectListItem> li2 = new List<SelectListItem>();
            //li2.Add(new SelectListItem { Text = "--Select--", Value = " " });
            li2.Add(new SelectListItem { Text = "Individual", Value = "1" });
            li2.Add(new SelectListItem { Text = "Company", Value = "2" });
            ViewData["CustomerType"] = li2;

            //*********************Currency List*********************//
            List<GeneralCurrencyMaster> GeneralCurrencyMaster = GetListGeneralCurrencyMaster();
            List<SelectListItem> GeneralCurrencyMasterList = new List<SelectListItem>();
            foreach (GeneralCurrencyMaster item in GeneralCurrencyMaster)
            {
                GeneralCurrencyMasterList.Add(new SelectListItem { Text = item.CurrencyCode, Value = Convert.ToString(item.ID) });
            }
            ViewBag.GeneralCurrencyMasterList = new SelectList(GeneralCurrencyMasterList, "Value", "Text");
            //*********************Currency List*********************//
            //*********************Unit List*********************//
            List<GeneralUnitMaster> GeneralUnitMaster = GetListGeneralUnitMaster();
            List<SelectListItem> GeneralUnitMasterList = new List<SelectListItem>();
            foreach (GeneralUnitMaster item in GeneralUnitMaster)
            {
                GeneralUnitMasterList.Add(new SelectListItem { Text = item.UnitDescription, Value = Convert.ToString(item.ID) });
            }
            ViewBag.GeneralUnitMasterList = new SelectList(GeneralUnitMasterList, "Value", "Text");
            //*********************Unit List*********************//

            List<SelectListItem> li1 = new List<SelectListItem>();
            //li1.Add(new SelectListItem { Text = "--Select--", Value = " " });
            li1.Add(new SelectListItem { Text = "SEZ", Value = "1" });
            li1.Add(new SelectListItem { Text = "OTHER", Value = "2" });
            ViewData["ReasonForExemption"] = li1;

            return PartialView("/Views/Sales/CustomerMaster/CreateCustomer.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(CustomerMasterViewModel model)
        {
            try
            {

                if (model != null && model.CustomerMasterDTO != null)
                {
                    model.CustomerMasterDTO.ConnectionString = _connectioString;
                    model.CustomerMasterDTO.CustomerType = model.CustomerType;
                    model.CustomerMasterDTO.CompanyName = model.CompanyName;
                    model.CustomerMasterDTO.FirstName = model.FirstName;
                    model.CustomerMasterDTO.MiddleName = model.MiddleName;
                    model.CustomerMasterDTO.LastName = model.LastName;
                    model.CustomerMasterDTO.Address1 = model.Address1;
                    model.CustomerMasterDTO.Address2 = model.Address2;
                    model.CustomerMasterDTO.Address3 = model.Address3;
                    model.CustomerMasterDTO.CountryID = model.CountryID;
                    model.CustomerMasterDTO.CityID = model.CityID;
                    model.CustomerMasterDTO.StateID = model.StateID;
                    model.CustomerMasterDTO.MobileNumber = model.MobileNumber;
                    model.CustomerMasterDTO.Email = model.Email;
                    model.CustomerMasterDTO.Currency = model.Currency;
                    model.CustomerMasterDTO.GSTNumber = model.GSTNumber;
                    model.CustomerMasterDTO.IsTaxExempted = model.IsTaxExempted;
                    model.CustomerMasterDTO.ReasonForExemption = model.ReasonForExemption;
                    model.CustomerMasterDTO.BankAccountNumber = model.BankAccountNumber;
                    model.CustomerMasterDTO.BankName = model.BankName;
                    model.CustomerMasterDTO.IFCICODE = model.IFCICODE;
                    model.CustomerMasterDTO.CreditPeriod = model.CreditPeriod;
                    model.CustomerMasterDTO.UnitMasterId = model.UnitMasterId;
                    model.CustomerMasterDTO.Code = model.Code;
                    model.CustomerMasterDTO.IsMainBranch = model.IsMainBranch;
                    model.CustomerMasterDTO.CustomerBranchMasterName = model.CustomerBranchMasterName;
                    model.CustomerMasterDTO.CustomerMasterID = model.CustomerMasterID;
                    model.CustomerMasterDTO.ShortCode = model.ShortCode;
                    model.CustomerMasterDTO.PinCode = model.PinCode;
                    model.CustomerMasterDTO.TaxExemptionRemark = model.TaxExemptionRemark;
                    model.CustomerMasterDTO.IsCentre = model.IsCentre;
                    model.CustomerMasterDTO.CentreCode = model.CentreCode;
                    model.CustomerMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<CustomerMaster> response = _CustomerMasterBA.InsertCustomerMaster(model.CustomerMasterDTO);
                    model.CustomerMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);

                }
                return Json(model.CustomerMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);



            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }

        [HttpGet]
        public ActionResult CreateContactDetails(string IDs)
        {
            CustomerMasterViewModel model = new CustomerMasterViewModel();
            CustomerMasterSearchRequest searchRequest = new CustomerMasterSearchRequest();

            string[] IDsArray = IDs.Split('~');
            model.CustomerMasterID = Convert.ToInt32(IDsArray[0]);
            model.CustomerMasterName = IDsArray[1];
            model.CustomerBranchMasterID = Convert.ToInt32(IDsArray[2]);
            model.CustomerType = Convert.ToByte(IDsArray[3]);
            if (Convert.ToByte(IDsArray[3]) == 1)
            {
                model.CompanyTypeName = "Individual";
            }
            else if (Convert.ToByte(IDsArray[3]) == 2)
            {
                model.CompanyTypeName = "Company";
            }


            searchRequest.ConnectionString = _connectioString;
            searchRequest.CustomerMasterID = Convert.ToInt32(IDsArray[0]);
            searchRequest.CustomerMasterName = IDsArray[1];
            searchRequest.CustomerBranchMasterID = Convert.ToInt32(IDsArray[2]);
            searchRequest.CustomerType = Convert.ToByte(IDsArray[3]);
            IBaseEntityCollectionResponse<CustomerMaster> baseEntityCollectionResponse = _CustomerMasterBA.GetContactDetailsByCustomerMasterID(searchRequest);

            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    model.ContactDetailsByCustomerMasterID = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }

            return PartialView("/Views/Sales/CustomerMaster/CreateContactDetails.cshtml", model);
        }
        [HttpGet]
        public ActionResult CreateContactDetailsByBranch(int CustomerMasterID, string CustomerMasterName, int CustomerBranchMasterID, byte CustomerType)
        {
            CustomerMasterViewModel model = new CustomerMasterViewModel();
            CustomerMasterSearchRequest searchRequest = new CustomerMasterSearchRequest();

            model.CustomerMasterID = Convert.ToInt32(CustomerMasterID);
            model.CustomerMasterName = CustomerMasterName;
            model.CustomerBranchMasterID = Convert.ToInt32(CustomerBranchMasterID);
            model.CustomerType = Convert.ToByte(CustomerType);
            if (Convert.ToByte(CustomerType) == 1)
            {
                model.CompanyTypeName = "Individual";
            }
            else if (Convert.ToByte(CustomerType) == 2)
            {
                model.CompanyTypeName = "Company";
            }


            searchRequest.ConnectionString = _connectioString;
            searchRequest.CustomerMasterID = Convert.ToInt32(CustomerMasterID);
            searchRequest.CustomerMasterName = CustomerMasterName;
            searchRequest.CustomerBranchMasterID = Convert.ToInt32(CustomerBranchMasterID);
            searchRequest.CustomerType = Convert.ToByte(CustomerType);



            IBaseEntityCollectionResponse<CustomerMaster> baseEntityCollectionResponse = _CustomerMasterBA.GetContactDetailsByCustomerMasterID(searchRequest);

            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    model.ContactDetailsByCustomerMasterID = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }

            return PartialView("/Views/Sales/CustomerMaster/CreateContactDetails.cshtml", model);
        }
        [HttpGet]
        public ActionResult CreateBranchDetails(string IDs)
        {
            CustomerMasterViewModel model = new CustomerMasterViewModel();
            string[] IDsArray = IDs.Split('~');
            model.CustomerMasterID = Convert.ToInt32(IDsArray[0]);
            model.CompanyName = IDsArray[1];
            model.CustomerBranchMasterID = Convert.ToInt32(IDsArray[2]);
            model.CustomerType = Convert.ToByte(IDsArray[3]);

            if (Convert.ToByte(IDsArray[3]) == 1)
            {
                model.CompanyTypeName = "Individual";
            }
            else if (Convert.ToByte(IDsArray[3]) == 2)
            {
                model.CompanyTypeName = "Company";
            }


            List<GeneralCountryMaster> GeneralCountryMasterList = GetListGeneralCountryMaster();
            List<SelectListItem> genCountryMaster = new List<SelectListItem>();
            foreach (GeneralCountryMaster item in GeneralCountryMasterList)
            {
                genCountryMaster.Add(new SelectListItem { Text = item.CountryName, Value = item.ID.ToString() });
            }
            ViewBag.GeneralCountryMaster = new SelectList(genCountryMaster, "Value", "Text");
            List<SelectListItem> generalRegionMaster = new List<SelectListItem>();
            ViewBag.GeneralRegionMaster = new SelectList(generalRegionMaster, "Value", "Text");
            List<SelectListItem> generalCityMaster = new List<SelectListItem>();
            ViewBag.GeneralCityMaster = new SelectList(generalCityMaster, "Value", "Text");

            List<SelectListItem> li2 = new List<SelectListItem>();
            li2.Add(new SelectListItem { Text = "--Select--", Value = " " });
            li2.Add(new SelectListItem { Text = "Individual", Value = "1" });
            li2.Add(new SelectListItem { Text = "Company", Value = "2" });
            ViewData["CustomerType"] = li2;

            //*********************Currency List*********************//
            List<GeneralCurrencyMaster> GeneralCurrencyMaster = GetListGeneralCurrencyMaster();
            List<SelectListItem> GeneralCurrencyMasterList = new List<SelectListItem>();
            foreach (GeneralCurrencyMaster item in GeneralCurrencyMaster)
            {
                GeneralCurrencyMasterList.Add(new SelectListItem { Text = item.CurrencyCode, Value = Convert.ToString(item.ID) });
            }
            ViewBag.GeneralCurrencyMasterList = new SelectList(GeneralCurrencyMasterList, "Value", "Text");
            //*********************Currency List*********************//
            //*********************Unit List*********************//
            List<GeneralUnitMaster> GeneralUnitMaster = GetListGeneralUnitMaster();
            List<SelectListItem> GeneralUnitMasterList = new List<SelectListItem>();
            foreach (GeneralUnitMaster item in GeneralUnitMaster)
            {
                GeneralUnitMasterList.Add(new SelectListItem { Text = item.UnitDescription, Value = Convert.ToString(item.ID) });
            }
            ViewBag.GeneralUnitMasterList = new SelectList(GeneralUnitMasterList, "Value", "Text");
            //*********************Unit List*********************//

            List<SelectListItem> li1 = new List<SelectListItem>();
            li1.Add(new SelectListItem { Text = "--Select--", Value = " " });
            li1.Add(new SelectListItem { Text = "SEZ", Value = "1" });
            li1.Add(new SelectListItem { Text = "OTHER", Value = "2" });
            ViewData["ReasonForExemption"] = li1;



            return PartialView("/Views/Sales/CustomerMaster/CreateBranchDetails.cshtml", model);
        }

        [HttpPost]
        public ActionResult CreateBranchDetails(CustomerMasterViewModel model)
        {
            try
            {

                if (model != null && model.CustomerMasterDTO != null)
                {
                    model.CustomerMasterDTO.ConnectionString = _connectioString;
                    model.CustomerMasterDTO.CustomerType = model.CustomerType;
                    model.CustomerMasterDTO.CompanyName = model.CompanyName;
                    model.CustomerMasterDTO.FirstName = model.FirstName;
                    model.CustomerMasterDTO.MiddleName = model.MiddleName;
                    model.CustomerMasterDTO.LastName = model.LastName;
                    model.CustomerMasterDTO.Address1 = model.Address1;
                    model.CustomerMasterDTO.Address2 = model.Address2;
                    model.CustomerMasterDTO.Address3 = model.Address3;
                    model.CustomerMasterDTO.CountryID = model.CountryID;
                    model.CustomerMasterDTO.CityID = model.CityID;
                    model.CustomerMasterDTO.StateID = model.StateID;
                    model.CustomerMasterDTO.GSTNumber = model.GSTNumber;
                    model.CustomerMasterDTO.IsTaxExempted = model.IsTaxExempted;
                    model.CustomerMasterDTO.ReasonForExemption = model.ReasonForExemption;
                    model.CustomerMasterDTO.BankAccountNumber = model.BankAccountNumber;
                    model.CustomerMasterDTO.BankName = model.BankName;
                    model.CustomerMasterDTO.IFCICODE = model.IFCICODE;
                    model.CustomerMasterDTO.CreditPeriod = model.CreditPeriod;
                    model.CustomerMasterDTO.UnitMasterId = model.UnitMasterId;
                    model.CustomerMasterDTO.IsMainBranch = model.IsMainBranch;
                    model.CustomerMasterDTO.CustomerBranchMasterName = model.CustomerBranchMasterName;
                    model.CustomerMasterDTO.CustomerMasterID = model.CustomerMasterID;
                    model.CustomerMasterDTO.ShortCode = model.ShortCode;
                    model.CustomerMasterDTO.PinCode = model.PinCode;
                    model.CustomerMasterDTO.IsBillToSameAsShipTo = model.IsBillToSameAsShipTo;
                    model.CustomerMasterDTO.TaxExemptionRemark = model.TaxExemptionRemark;
                    model.CustomerMasterDTO.IsCentre = model.IsCentre;
                    model.CustomerMasterDTO.CentreCode = model.CentreCode;

                    model.CustomerMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<CustomerMaster> response = _CustomerMasterBA.InsertCustomerMasterBranchDetails(model.CustomerMasterDTO);
                    model.CustomerMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);

                }
                return Json(model.CustomerMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);



            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }

        [HttpPost]
        public ActionResult CreateContactDetails(CustomerMasterViewModel model)
        {
            try
            {
                //if (ModelState.IsValid)
                // {
                if (model != null && model.CustomerMasterDTO != null)
                {
                    model.CustomerMasterDTO.ConnectionString = _connectioString;
                    model.CustomerMasterDTO.XmlString = model.XmlString;
                    model.CustomerMasterDTO.CustomerBranchMasterID = model.CustomerBranchMasterID;
                    model.CustomerMasterDTO.CustomerMasterID = model.CustomerMasterID;
                    model.CustomerMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    model.CustomerMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<CustomerMaster> response = _CustomerMasterBA.InsertCustomerMasterContactDetails(model.CustomerMasterDTO);
                    model.CustomerMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.CustomerMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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


        [HttpGet]
        public ActionResult Edit(int ID, int CustomerMasterID)
        {
            CustomerMasterViewModel model = new CustomerMasterViewModel();
            try
            {
                model.CustomerMasterDTO = new CustomerMaster();
                model.CustomerMasterDTO.CustomerBranchMasterID = ID;
                model.CustomerMasterDTO.CustomerMasterID = CustomerMasterID;
                model.CustomerMasterDTO.ConnectionString = _connectioString;

                List<GeneralCountryMaster> GeneralCountryMasterList = GetListGeneralCountryMaster();
                List<SelectListItem> GeneralCountryMaster = new List<SelectListItem>();
                foreach (GeneralCountryMaster item in GeneralCountryMasterList)
                {
                    GeneralCountryMaster.Add(new SelectListItem { Text = item.CountryName, Value = item.ID.ToString() });
                }

                string SelectedCountryID = string.Empty;
                List<GeneralRegionMaster> generalRegionMasterList = GetListGeneralRegionMaster(SelectedCountryID);
                List<SelectListItem> generalRegionMaster = new List<SelectListItem>();
                foreach (GeneralRegionMaster item in generalRegionMasterList)
                {
                    generalRegionMaster.Add(new SelectListItem { Text = item.RegionName, Value = item.ID.ToString() });
                }

                string SelectedRegionID = string.Empty;
                List<GeneralCityMaster> generalCityMasterList = GetListGeneralCityMaster(SelectedRegionID);
                List<SelectListItem> generalCityMaster = new List<SelectListItem>();
                foreach (GeneralCityMaster item in generalCityMasterList)
                {
                    generalCityMaster.Add(new SelectListItem { Text = item.Description, Value = item.ID.ToString() });
                }


                IBaseEntityResponse<CustomerMaster> response = _CustomerMasterBA.SelectByID(model.CustomerMasterDTO);
                if (response != null && response.Entity != null)
                {
                    model.CustomerMasterDTO.CustomerBranchMasterID = response.Entity.CustomerBranchMasterID;
                    model.CustomerMasterDTO.CustomerMasterID = response.Entity.CustomerMasterID;
                    model.CustomerMasterDTO.IsMainBranch = response.Entity.IsMainBranch;
                    model.CustomerMasterDTO.Address1 = response.Entity.Address1;
                    model.CustomerMasterDTO.Address2 = response.Entity.Address2;
                    model.CustomerMasterDTO.Address3 = response.Entity.Address3;
                    model.CustomerMasterDTO.CityID = response.Entity.CityID;
                    model.CustomerMasterDTO.StateID = response.Entity.StateID;
                    model.CustomerMasterDTO.CountryID = response.Entity.CountryID;
                    model.CustomerMasterDTO.GSTNumber = response.Entity.GSTNumber;
                    model.CustomerMasterDTO.IsTaxExempted = response.Entity.IsTaxExempted;
                    model.CustomerMasterDTO.ReasonForExemption = response.Entity.ReasonForExemption;
                    model.CustomerMasterDTO.CreditPeriod = response.Entity.CreditPeriod;
                    model.CustomerMasterDTO.UnitMasterId = response.Entity.UnitMasterId;
                    model.CustomerMasterDTO.BankName = response.Entity.BankName;
                    model.CustomerMasterDTO.IFCICODE = response.Entity.IFCICODE;
                    model.CustomerMasterDTO.BankAccountNumber = response.Entity.BankAccountNumber;
                    model.CustomerMasterDTO.CustomerBranchMasterName = response.Entity.CustomerBranchMasterName;
                    model.CustomerMasterDTO.ShortCode = response.Entity.ShortCode;
                    model.CustomerMasterDTO.IsBillToSameAsShipTo = response.Entity.IsBillToSameAsShipTo;
                    model.CustomerMasterDTO.PinCode = response.Entity.PinCode;
                    model.CustomerMasterDTO.CustomerBranchCode = response.Entity.CustomerBranchCode;
                    model.CustomerMasterDTO.TaxExemptionRemark = response.Entity.TaxExemptionRemark;
                    model.CustomerMasterDTO.IsCentre = response.Entity.IsCentre;
                    model.CustomerMasterDTO.CentreCode = response.Entity.CentreCode;

                    ViewBag.GeneralCountryMaster = new SelectList(GeneralCountryMaster, "Value", "Text", response.Entity.CountryID.ToString());
                    ViewBag.GeneralRegionMaster = new SelectList(generalRegionMaster, "Value", "Text", response.Entity.StateID.ToString());
                    ViewBag.GeneralCityMaster = new SelectList(generalCityMaster, "Value", "Text", response.Entity.CityID.ToString());

                    model.CustomerMasterDTO.CreatedBy = response.Entity.CreatedBy;
                }


                List<SelectListItem> li2 = new List<SelectListItem>();
                li2.Add(new SelectListItem { Text = "--Select--", Value = " " });
                li2.Add(new SelectListItem { Text = "Individual", Value = "1" });
                li2.Add(new SelectListItem { Text = "Company", Value = "2" });
                ViewData["CustomerType"] = li2;

                //*********************Currency List*********************//
                List<GeneralCurrencyMaster> GeneralCurrencyMaster = GetListGeneralCurrencyMaster();
                List<SelectListItem> GeneralCurrencyMasterList = new List<SelectListItem>();
                foreach (GeneralCurrencyMaster item in GeneralCurrencyMaster)
                {
                    GeneralCurrencyMasterList.Add(new SelectListItem { Text = item.CurrencyCode, Value = Convert.ToString(item.ID) });
                }
                ViewBag.GeneralCurrencyMasterList = new SelectList(GeneralCurrencyMasterList, "Value", "Text");
                //*********************Currency List*********************//
                //*********************Unit List*********************//
                List<GeneralUnitMaster> GeneralUnitMaster = GetListGeneralUnitMaster();
                List<SelectListItem> GeneralUnitMasterList = new List<SelectListItem>();
                foreach (GeneralUnitMaster item in GeneralUnitMaster)
                {
                    GeneralUnitMasterList.Add(new SelectListItem { Text = item.UnitDescription, Value = Convert.ToString(item.ID) });
                }
                ViewBag.GeneralUnitMasterList = new SelectList(GeneralUnitMasterList, "Value", "Text");
                //*********************Unit List*********************//

                if (model.CustomerMasterDTO.ReasonForExemption > 0)
                {
                    List<SelectListItem> li1 = new List<SelectListItem>();
                    //li1.Add(new SelectListItem { Text = "--Select--", Value = "" });
                    li1.Add(new SelectListItem { Text = "SEZ", Value = "1" });
                    li1.Add(new SelectListItem { Text = "OTHER", Value = "2" });
                    ViewData["ReasonForExemption"] = new SelectList(li1, "Value", "Text", (model.CustomerMasterDTO.ReasonForExemption).ToString().Trim());
                }
                else
                {

                    List<SelectListItem> li1 = new List<SelectListItem>();
                    //li1.Add(new SelectListItem { Text = "--Select--", Value = "" });
                    li1.Add(new SelectListItem { Text = "SEZ", Value = "1" });
                    li1.Add(new SelectListItem { Text = "OTHER", Value = "2" });
                    ViewData["ReasonForExemption"] = li1;
                }
                return PartialView("/Views/Sales/CustomerMaster/EditBranchdetails.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(CustomerMasterViewModel model)
        {
            //if (ModelState.IsValid)
            //{
            if (model != null && model.CustomerMasterDTO != null)
            {
                if (model != null && model.CustomerMasterDTO != null)
                {
                    model.CustomerMasterDTO.ConnectionString = _connectioString;
                    model.CustomerMasterDTO.CustomerBranchMasterID = model.CustomerBranchMasterID;
                    model.CustomerMasterDTO.CustomerMasterID = model.CustomerMasterID;
                    model.CustomerMasterDTO.IsMainBranch = model.IsMainBranch;
                    model.CustomerMasterDTO.Address1 = model.Address1;
                    model.CustomerMasterDTO.Address2 = model.Address2;
                    model.CustomerMasterDTO.Address3 = model.Address3;
                    model.CustomerMasterDTO.CityID = model.CityID;
                    model.CustomerMasterDTO.StateID = model.StateID;
                    model.CustomerMasterDTO.CountryID = model.CountryID;
                    model.CustomerMasterDTO.GSTNumber = model.GSTNumber;
                    model.CustomerMasterDTO.IsTaxExempted = model.IsTaxExempted;
                    model.CustomerMasterDTO.ReasonForExemption = model.ReasonForExemption;
                    model.CustomerMasterDTO.CreditPeriod = model.CreditPeriod;
                    model.CustomerMasterDTO.UnitMasterId = model.UnitMasterId;
                    model.CustomerMasterDTO.BankName = model.BankName;
                    model.CustomerMasterDTO.IFCICODE = model.IFCICODE;
                    model.CustomerMasterDTO.BankAccountNumber = model.BankAccountNumber;
                    model.CustomerMasterDTO.CustomerBranchMasterName = model.CustomerBranchMasterName;
                    model.CustomerMasterDTO.ShortCode = model.ShortCode;
                    model.CustomerMasterDTO.IsBillToSameAsShipTo = model.IsBillToSameAsShipTo;
                    model.CustomerMasterDTO.PinCode = model.PinCode;
                    model.CustomerMasterDTO.TaxExemptionRemark = model.TaxExemptionRemark;
                    model.CustomerMasterDTO.IsCentre = model.IsCentre;
                    model.CustomerMasterDTO.CentreCode = model.CentreCode;

                    model.CustomerMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<CustomerMaster> response = _CustomerMasterBA.UpdateCustomerMaster(model.CustomerMasterDTO);
                    model.CustomerMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                }
                //}
                return Json(model.CustomerMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Please review your form");
            }
        }

        public ActionResult Delete(int ID)
        {
            CustomerMasterViewModel model = new CustomerMasterViewModel();
            //if (!ModelState.IsValid)
            //{
            if (ID > 0)
            {
                CustomerMaster CustomerMasterDTO = new CustomerMaster();
                CustomerMasterDTO.ConnectionString = _connectioString;
                // CustomerMasterDTO.ID = ID;
                CustomerMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                IBaseEntityResponse<CustomerMaster> response = _CustomerMasterBA.DeleteCustomerMaster(CustomerMasterDTO);
                model.CustomerMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);

            }
            return Json(model.CustomerMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
            //}
            //else
            //{
            //    return Json("Please review your form");
            //}
        }


        [HttpGet]
        public ActionResult EditCustomerDetails(string IDs)
        {
            try
            {
                CustomerMasterViewModel model = new CustomerMasterViewModel();
                string[] IDsArray = IDs.Split('~');
                model.CustomerMasterID = Convert.ToInt32(IDsArray[0]);
                model.CompanyName = IDsArray[1];
                model.CustomerBranchMasterID = Convert.ToInt32(IDsArray[2]);
                model.CustomerType = Convert.ToByte(IDsArray[3]);

                if (Convert.ToByte(IDsArray[3]) == 1)
                {
                    model.CompanyTypeName = "Individual";
                }
                else if (Convert.ToByte(IDsArray[3]) == 2)
                {
                    model.CompanyTypeName = "Company";
                }
                model.CustomerMasterDTO.ConnectionString = _connectioString;

                List<GeneralCountryMaster> GeneralCountryMasterList = GetListGeneralCountryMaster();
                List<SelectListItem> GeneralCountryMaster = new List<SelectListItem>();
                foreach (GeneralCountryMaster item in GeneralCountryMasterList)
                {
                    GeneralCountryMaster.Add(new SelectListItem { Text = item.CountryName, Value = item.ID.ToString() });
                }

                string SelectedCountryID = string.Empty;
                List<GeneralRegionMaster> generalRegionMasterList = GetListGeneralRegionMaster(SelectedCountryID);
                List<SelectListItem> generalRegionMaster = new List<SelectListItem>();
                foreach (GeneralRegionMaster item in generalRegionMasterList)
                {
                    generalRegionMaster.Add(new SelectListItem { Text = item.RegionName, Value = item.ID.ToString() });
                }

                string SelectedRegionID = string.Empty;
                List<GeneralCityMaster> generalCityMasterList = GetListGeneralCityMaster(SelectedRegionID);
                List<SelectListItem> generalCityMaster = new List<SelectListItem>();
                foreach (GeneralCityMaster item in generalCityMasterList)
                {
                    generalCityMaster.Add(new SelectListItem { Text = item.Description, Value = item.ID.ToString() });
                }


                IBaseEntityResponse<CustomerMaster> response = _CustomerMasterBA.SelectByCustomerMasterID(model.CustomerMasterDTO);
                if (response != null && response.Entity != null)
                {
                    model.CustomerMasterDTO.CustomerBranchMasterID = response.Entity.CustomerBranchMasterID;
                    model.CustomerMasterDTO.CustomerMasterID = response.Entity.CustomerMasterID;
                    model.CustomerMasterDTO.IsMainBranch = response.Entity.IsMainBranch;
                    model.CustomerMasterDTO.FirstName = response.Entity.FirstName;
                    model.CustomerMasterDTO.MiddleName = response.Entity.MiddleName;
                    model.CustomerMasterDTO.LastName = response.Entity.LastName;
                    model.CustomerMasterDTO.Address1 = response.Entity.Address1;
                    model.CustomerMasterDTO.Address2 = response.Entity.Address2;
                    model.CustomerMasterDTO.Address3 = response.Entity.Address3;
                    model.CustomerMasterDTO.CityID = response.Entity.CityID;
                    model.CustomerMasterDTO.StateID = response.Entity.StateID;
                    model.CustomerMasterDTO.CountryID = response.Entity.CountryID;
                    model.CustomerMasterDTO.GSTNumber = response.Entity.GSTNumber;
                    model.CustomerMasterDTO.MobileNumber = response.Entity.MobileNumber;
                    model.CustomerMasterDTO.Email = response.Entity.Email;
                    model.CustomerMasterDTO.IsTaxExempted = response.Entity.IsTaxExempted;
                    model.CustomerMasterDTO.ReasonForExemption = response.Entity.ReasonForExemption;
                    model.CustomerMasterDTO.CreditPeriod = response.Entity.CreditPeriod;
                    model.CustomerMasterDTO.UnitMasterId = response.Entity.UnitMasterId;
                    model.CustomerMasterDTO.BankName = response.Entity.BankName;
                    model.CustomerMasterDTO.IFCICODE = response.Entity.IFCICODE;
                    model.CustomerMasterDTO.BankAccountNumber = response.Entity.BankAccountNumber;
                    model.CustomerMasterDTO.CustomerBranchMasterName = response.Entity.CustomerBranchMasterName;
                    model.CustomerMasterDTO.ShortCode = response.Entity.ShortCode;
                    model.CustomerMasterDTO.IsBillToSameAsShipTo = response.Entity.IsBillToSameAsShipTo;
                    model.CustomerMasterDTO.CustomerBranchCode = response.Entity.CustomerBranchCode;
                    model.CustomerMasterDTO.PinCode = response.Entity.PinCode;
                    model.CustomerMasterDTO.Currency = response.Entity.Currency;
                    model.CustomerMasterDTO.TaxExemptionRemark = response.Entity.TaxExemptionRemark;
                    model.CustomerMasterDTO.IsCentre = response.Entity.IsCentre;
                    model.CustomerMasterDTO.CentreCode= response.Entity.CentreCode;

                    ViewBag.GeneralCountryMaster = new SelectList(GeneralCountryMaster, "Value", "Text", response.Entity.CountryID.ToString());
                    ViewBag.GeneralRegionMaster = new SelectList(generalRegionMaster, "Value", "Text", response.Entity.StateID.ToString());
                    ViewBag.GeneralCityMaster = new SelectList(generalCityMaster, "Value", "Text", response.Entity.CityID.ToString());

                    model.CustomerMasterDTO.CreatedBy = response.Entity.CreatedBy;
                }


                List<SelectListItem> li2 = new List<SelectListItem>();
                li2.Add(new SelectListItem { Text = "--Select--", Value = " " });
                li2.Add(new SelectListItem { Text = "Individual", Value = "1" });
                li2.Add(new SelectListItem { Text = "Company", Value = "2" });
                //ViewData["CustomerType"] = li2;
                ViewData["CustomerType"] = new SelectList(li2, "Value", "Text", (model.CustomerType).ToString().Trim());

                //*********************Currency List*********************//
                List<GeneralCurrencyMaster> GeneralCurrencyMaster = GetListGeneralCurrencyMaster();
                List<SelectListItem> GeneralCurrencyMasterList = new List<SelectListItem>();
                foreach (GeneralCurrencyMaster item in GeneralCurrencyMaster)
                {
                    GeneralCurrencyMasterList.Add(new SelectListItem { Text = item.CurrencyCode, Value = Convert.ToString(item.ID) });
                }
                ViewBag.GeneralCurrencyMasterList = new SelectList(GeneralCurrencyMasterList, "Value", "Text", (model.Currency).ToString());
                //*********************Currency List*********************//
                //*********************Unit List*********************//
                List<GeneralUnitMaster> GeneralUnitMaster = GetListGeneralUnitMaster();
                List<SelectListItem> GeneralUnitMasterList = new List<SelectListItem>();
                foreach (GeneralUnitMaster item in GeneralUnitMaster)
                {
                    GeneralUnitMasterList.Add(new SelectListItem { Text = item.UnitDescription, Value = Convert.ToString(item.ID) });
                }
                ViewBag.GeneralUnitMasterList = new SelectList(GeneralUnitMasterList, "Value", "Text", (model.UnitMasterId).ToString());
                //*********************Unit List*********************//

                List<SelectListItem> li1 = new List<SelectListItem>();
                //li1.Add(new SelectListItem { Text = "--Select--", Value = "" });
                li1.Add(new SelectListItem { Text = "SEZ", Value = "1" });
                li1.Add(new SelectListItem { Text = "OTHER", Value = "2" });
                ViewData["ReasonForExemption"] = new SelectList(li1, "Value", "Text", (model.ReasonForExemption).ToString().Trim());
                return PartialView("/Views/Sales/CustomerMaster/EditCustomer.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult EditCustomerDetails(CustomerMasterViewModel model)
        {
            try
            {

                if (model != null && model.CustomerMasterDTO != null)
                {
                    model.CustomerMasterDTO.ConnectionString = _connectioString;
                    model.CustomerMasterDTO.CustomerType = model.CustomerType;
                    model.CustomerMasterDTO.CompanyName = model.CompanyName;
                    model.CustomerMasterDTO.FirstName = model.FirstName;
                    model.CustomerMasterDTO.MiddleName = model.MiddleName;
                    model.CustomerMasterDTO.LastName = model.LastName;
                    model.CustomerMasterDTO.Address1 = model.Address1;
                    model.CustomerMasterDTO.Address2 = model.Address2;
                    model.CustomerMasterDTO.Address3 = model.Address3;
                    model.CustomerMasterDTO.CountryID = model.CountryID;
                    model.CustomerMasterDTO.CityID = model.CityID;
                    model.CustomerMasterDTO.StateID = model.StateID;
                    model.CustomerMasterDTO.MobileNumber = model.MobileNumber;
                    model.CustomerMasterDTO.Email = model.Email;
                    model.CustomerMasterDTO.Currency = model.Currency;
                    model.CustomerMasterDTO.GSTNumber = model.GSTNumber;
                    model.CustomerMasterDTO.IsTaxExempted = model.IsTaxExempted;
                    model.CustomerMasterDTO.ReasonForExemption = model.ReasonForExemption;
                    model.CustomerMasterDTO.BankAccountNumber = model.BankAccountNumber;
                    model.CustomerMasterDTO.BankName = model.BankName;
                    model.CustomerMasterDTO.IFCICODE = model.IFCICODE;
                    model.CustomerMasterDTO.CreditPeriod = model.CreditPeriod;
                    model.CustomerMasterDTO.UnitMasterId = model.UnitMasterId;
                    model.CustomerMasterDTO.CustomerMasterID = model.CustomerMasterID;
                    model.CustomerMasterDTO.PinCode = model.PinCode;
                    model.CustomerMasterDTO.TaxExemptionRemark = model.TaxExemptionRemark;
                    model.CustomerMasterDTO.IsCentre = model.IsCentre;
                    model.CustomerMasterDTO.CentreCode = model.CentreCode;
                    model.CustomerMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<CustomerMaster> response = _CustomerMasterBA.UpdateCustomerMasterByCustomerMasterID(model.CustomerMasterDTO);
                    model.CustomerMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);

                }
                return Json(model.CustomerMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);



            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }

        #endregion

        // Non-Action Method
        #region Methods

        [HttpPost]
        public JsonResult GetCustomerMasterSearchList(string term)
        {
            CustomerMasterSearchRequest searchRequest = new CustomerMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            searchRequest.SearchWord = term;
            List<CustomerMaster> listCustomerMaster = new List<CustomerMaster>();
            IBaseEntityCollectionResponse<CustomerMaster> baseEntityCollectionResponse = _CustomerMasterBA.GetCustomerMasterSearchList(searchRequest);
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
                              CustomerMasterID = r.CustomerMasterID,
                              CustomerMasterName = r.CustomerMasterName,
                              CustomerType = r.CustomerType,
                              CreditAmount = r.CreditAmount,
                              CustomerAddress=r.CustomerAddress,
                              PinCode=r.PinCode,
                             // MobileNumber = r.MobileNumber

                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetCustomerBranchMasterSearchList(string term, string CustomerMasterID)
        {
            CustomerMasterSearchRequest searchRequest = new CustomerMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            searchRequest.SearchWord = term;
            searchRequest.CustomerMasterID = Convert.ToInt32(CustomerMasterID);
            List<CustomerMaster> listCustomerMaster = new List<CustomerMaster>();
            IBaseEntityCollectionResponse<CustomerMaster> baseEntityCollectionResponse = _CustomerMasterBA.GetCustomerBranchMasterSearchList(searchRequest);
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
                              CustomerBranchMasterID = r.CustomerBranchMasterID,
                              CustomerBranchMasterName = r.CustomerBranchMasterName,
                              CreditAmount = r.CreditAmount

                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetCustomerContactDetailsSearchList(string term, string CustomerMasterID, string CustomerBranchMasterID)
        {
            CustomerMasterSearchRequest searchRequest = new CustomerMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            searchRequest.SearchWord = term;
            searchRequest.CustomerMasterID = Convert.ToInt32(!string.IsNullOrEmpty(CustomerMasterID) ? CustomerMasterID : null);
            searchRequest.CustomerBranchMasterID = Convert.ToInt32(!string.IsNullOrEmpty(CustomerBranchMasterID) ? CustomerBranchMasterID : null);
            List<CustomerMaster> listCustomerMaster = new List<CustomerMaster>();
            IBaseEntityCollectionResponse<CustomerMaster> baseEntityCollectionResponse = _CustomerMasterBA.GetCustomerContactDetailsSearchList(searchRequest);
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
                             
                              CustomerContactDetailsID = r.CustomerContactDetailsID,
                              CustomerContactPersonName = r.CustomerContactPersonName,
                              MobileNumber=r.MobileNumber
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
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

        public IEnumerable<CustomerMasterViewModel> GetCustomerMaster(out int TotalRecords)
        {
            CustomerMasterSearchRequest searchRequest = new CustomerMasterSearchRequest();
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
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "A.ModifiedDate";
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
            List<CustomerMasterViewModel> listCustomerMasterViewModel = new List<CustomerMasterViewModel>();
            List<CustomerMaster> listCustomerMaster = new List<CustomerMaster>();
            IBaseEntityCollectionResponse<CustomerMaster> baseEntityCollectionResponse = _CustomerMasterBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listCustomerMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (CustomerMaster item in listCustomerMaster)
                    {
                        CustomerMasterViewModel CustomerMasterViewModel = new CustomerMasterViewModel();
                        CustomerMasterViewModel.CustomerMasterDTO = item;
                        listCustomerMasterViewModel.Add(CustomerMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listCustomerMasterViewModel;
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

                IEnumerable<CustomerMasterViewModel> filteredCountryMaster;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "A.ID";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "Concat(A.FirstName,' ',A.MiddleName,' ',A.LastName) Like '%" + param.sSearch + "%' or B.BranchName Like '%" + param.sSearch + "%' or CompanyName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;
                    case 1:
                        _sortBy = "CustomerName";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "Concat(A.FirstName,' ',A.MiddleName,' ',A.LastName) Like '%" + param.sSearch + "%' or B.BranchName Like '%" + param.sSearch + "%' or CompanyName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;
                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                filteredCountryMaster = GetCustomerMaster(out TotalRecords);
                var records = filteredCountryMaster.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { Convert.ToString(c.CustomerMasterID), Convert.ToString(c.CustomerMasterName), Convert.ToString(c.CustomerBranchMasterID), Convert.ToString(c.CustomerBranchMasterName).Trim().Replace(",", "#"), Convert.ToString(c.IsMainBranch), Convert.ToString(c.CustomerType), Convert.ToString(c.CustomerBranchCode) };

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