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
using System.Net;
using System.Text;
using System.Data;

namespace AERP.Web.UI.Controllers
{
    public class GeneralUnitsController : BaseController
    {
        IGeneralUnitsBA _GeneralUnitsBA = null;
        IGeneralCityMasterBA _generalCityMasterBA = null;
        IInventoryLocationMasterBA _InventoryLocationMasterBA = null;
        IAdminRoleMasterBA _AdminRoleMasterBA = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public GeneralUnitsController()
        {
            _GeneralUnitsBA = new GeneralUnitsBA();
            _generalCityMasterBA = new GeneralCityMasterBA();
            _InventoryLocationMasterBA = new InventoryLocationMasterBA();
            _AdminRoleMasterBA = new AdminRoleMasterBA();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
            if (Convert.ToInt32(Session["Store Manager"]) > 0 || Convert.ToString(Session["UserType"]) == "A")
            {
                return View("/Views/Inventory/GeneralUnits/Index.cshtml");
            }
            else
            {
                return RedirectToAction("UnauthorizedAccess", "Home");
            }
        }

        public ActionResult List(string actionMode, string centerCode)
        //public ActionResult List(string actionMode, string centerCode, string departmentID)
        {
            try
            {
                GeneralUnitsViewModel model = new GeneralUnitsViewModel();
                if (Convert.ToString(Session["UserType"]) == "A")
                {
                    List<OrganisationStudyCentreMaster> listAdminRoleApplicableDetails = GetListOrgStudyCentreMaster();
                    AdminRoleApplicableDetails a = null;
                    foreach (var item in listAdminRoleApplicableDetails)
                    {

                        a = new AdminRoleApplicableDetails();
                        a.CentreCode = item.CentreCode + ":Centre";
                        a.CentreName = item.CentreName;
                        // a.ScopeIdentity = item.ScopeIdentity;
                        model.ListGetAdminRoleApplicableCentre.Add(a);

                    }
                }
                else
                {
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
                        a.CentreCode = item.CentreCode + ":" + item.ScopeIdentity;
                        a.CentreName = item.CentreName;
                        // a.ScopeIdentity = item.ScopeIdentity;
                        model.ListGetAdminRoleApplicableCentre.Add(a);
                    }
                }

                if (!string.IsNullOrEmpty(centerCode))
                {
                    string[] splitCentreCode = centerCode.Split(':');
                    // model.ListGetOrganisationDepartmentCentreAndRoleWise= GetListOrganisationDepartmentMaster(splitCentreCode[0]);
                }
                model.SelectedCentreCode = centerCode;
                //model.SelectedDepartmentID = departmentID;
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Inventory/GeneralUnits/List.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }



        public ActionResult Create(string IDs)
        {

            GeneralUnitsViewModel model = new GeneralUnitsViewModel();
            //  model.GeneralUnitTypeID = Convert.ToInt16(IDs);

            string[] IDsArray = IDs.Split('~', ':');
            model.GeneralUnitTypeID = Convert.ToInt16(IDsArray[0]);
            model.CentreCode = IDsArray[1];
            model.UnitType = IDsArray[3];

            model.GetAdminRoleDomainList = GetListAdminRoleDomain(0);

            // model.DepartmentID = Convert.ToInt32(IDsArray[3]);
            return PartialView("/Views/Inventory/GeneralUnits/Create.cshtml", model);
        }



        [HttpPost]
        public ActionResult Create(GeneralUnitsViewModel model)
        {
            try
            {
                if (model != null && model.GeneralUnitsDTO != null)
                {
                    model.GeneralUnitsDTO.ConnectionString = _connectioString;
                    model.GeneralUnitsDTO.GeneralUnitTypeID = model.GeneralUnitTypeID;
                    model.GeneralUnitsDTO.UnitName = model.UnitName;
                    model.GeneralUnitsDTO.CentreCode = model.CentreCode;
                    model.GeneralUnitsDTO.InventoryLocationMasterID = model.InventoryLocationMasterID;
                    model.GeneralUnitsDTO.IsDefaultUnit = model.IsDefaultUnit;

                    //model.GeneralUnitsDTO.DepartmentID = model.DepartmentID;
                    // model.GeneralUnitsDTO.LocationAddress = model.LocationAddress;
                    model.GeneralUnitsDTO.CityId = model.CityId;
                    model.GeneralUnitsDTO.SelectedDomainIDs = model.SelectedDomainIDs;
                    model.GeneralUnitsDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<GeneralUnits> response = _GeneralUnitsBA.InsertGeneralUnits(model.GeneralUnitsDTO);
                    model.GeneralUnitsDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.GeneralUnitsDTO.errorMessage, JsonRequestBehavior.AllowGet);
                }
                return Json("Please review your form");
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }

        [HttpGet]
        public ActionResult UnitDetails(Int16 id)
        {
            GeneralUnitsViewModel model = new GeneralUnitsViewModel();
            try
            {
                model.GeneralUnitsDTO = new GeneralUnits();
                model.GeneralUnitsDTO.ID = id;
                model.GeneralUnitsDTO.ConnectionString = _connectioString;


                IBaseEntityResponse<GeneralUnits> response = _GeneralUnitsBA.SelectByID(model.GeneralUnitsDTO);
                if (response != null && response.Entity != null)
                {
                    model.GeneralUnitsDTO.ID = response.Entity.ID;
                    model.GeneralUnitsDTO.Footer = response.Entity.Footer;
                    model.GeneralUnitsDTO.FaxNumber = response.Entity.FaxNumber;
                    model.GeneralUnitsDTO.LogoName = response.Entity.LogoName;
                    model.GeneralUnitsDTO.Pincode = response.Entity.Pincode;
                    model.GeneralUnitsDTO.TelephoneNumber = response.Entity.TelephoneNumber;
                    model.GeneralUnitsDTO.DisplayIcon = response.Entity.DisplayIcon;
                    model.GeneralUnitsDTO.EmailID = response.Entity.EmailID;
                    model.GeneralUnitsDTO.Greeting = response.Entity.Greeting;
                    model.GeneralUnitsDTO.Url = response.Entity.Url;
                    model.GeneralUnitsDTO.CityName = response.Entity.CityName;
                    model.GeneralUnitsDTO.CityId = response.Entity.CityId;
                    model.GeneralUnitsDTO.LocationAddress = response.Entity.LocationAddress;

                    model.GeneralUnitsDTO.IsEmailID = response.Entity.IsEmailID;
                    model.GeneralUnitsDTO.IsFaxNumber = response.Entity.IsFaxNumber;
                    model.GeneralUnitsDTO.isGreeting = response.Entity.isGreeting;
                    model.GeneralUnitsDTO.IsFooter = response.Entity.IsFooter;
                    model.GeneralUnitsDTO.IsLogoPath = response.Entity.IsLogoPath;
                    model.GeneralUnitsDTO.IsPincode = response.Entity.IsPincode;
                    model.GeneralUnitsDTO.IsTelephoneNumber = response.Entity.IsTelephoneNumber;
                    model.GeneralUnitsDTO.IsUrl = response.Entity.IsUrl;
                    model.GeneralUnitsDTO.IsAddress = response.Entity.IsAddress;
                    model.GeneralUnitsDTO.IsCityName = response.Entity.IsCityName;

                }

                return PartialView("/Views/Inventory/GeneralUnits/UnitDetails.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult UnitDetails(GeneralUnitsViewModel model)
        {
            try
            {
                if (model != null && model.GeneralUnitsDTO != null)
                {
                    model.GeneralUnitsDTO.ConnectionString = _connectioString;
                    model.GeneralUnitsDTO.ID = model.ID;
                    model.GeneralUnitsDTO.LocationAddress = model.LocationAddress;
                    model.GeneralUnitsDTO.IsAddress = model.IsAddress;
                    model.GeneralUnitsDTO.CityId = model.CityId;
                    model.GeneralUnitsDTO.IsCityName = model.IsCityName;
                    model.GeneralUnitsDTO.Footer = model.Footer;
                    model.GeneralUnitsDTO.IsFooter = model.IsFooter;
                    model.GeneralUnitsDTO.FaxNumber = model.FaxNumber;
                    model.GeneralUnitsDTO.IsFaxNumber = model.IsFaxNumber;
                    model.GeneralUnitsDTO.Greeting = model.Greeting;
                    model.GeneralUnitsDTO.isGreeting = model.isGreeting;
                    model.GeneralUnitsDTO.LogoPathName = model.LogoPathName;
                    model.GeneralUnitsDTO.IsLogoPath = model.IsLogoPath;
                    model.GeneralUnitsDTO.TelephoneNumber = model.TelephoneNumber;
                    model.GeneralUnitsDTO.IsTelephoneNumber = model.IsTelephoneNumber;
                    model.GeneralUnitsDTO.Url = model.Url;
                    model.GeneralUnitsDTO.IsUrl = model.IsUrl;
                    model.GeneralUnitsDTO.Pincode = model.Pincode;
                    model.GeneralUnitsDTO.IsPincode = model.IsPincode;
                    model.GeneralUnitsDTO.DisplayIcon = model.DisplayIcon;
                    model.GeneralUnitsDTO.EmailID = model.EmailID;
                    model.GeneralUnitsDTO.IsEmailID = model.IsEmailID;

                    model.GeneralUnitsDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<GeneralUnits> response = _GeneralUnitsBA.UpdateGeneralUnits(model.GeneralUnitsDTO);
                    model.GeneralUnitsDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                    return Json(model.GeneralUnitsDTO.errorMessage, JsonRequestBehavior.AllowGet);
                }
                return Json("Please review your form");
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }

        [HttpGet]
        public ActionResult ViewDetails(Int16 id)
        {
            GeneralUnitsViewModel model = new GeneralUnitsViewModel();
            try
            {
                model.GeneralUnitsDTO = new GeneralUnits();
                model.GeneralUnitsDTO.ID = id;
                model.GeneralUnitsDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<GeneralUnits> response = _GeneralUnitsBA.SelectByID(model.GeneralUnitsDTO);
                if (response != null && response.Entity != null)
                {
                    model.GeneralUnitsDTO.ID = response.Entity.ID;
                    model.GeneralUnitsDTO.CityName = response.Entity.CityName;
                    model.GeneralUnitsDTO.UnitName = response.Entity.UnitName;
                    model.GeneralUnitsDTO.GeneralUnitTypeID = response.Entity.GeneralUnitTypeID;
                    model.GeneralUnitsDTO.CentreName = response.Entity.CentreName;
                    model.GeneralUnitsDTO.DepartmentID = response.Entity.DepartmentID;
                    model.GeneralUnitsDTO.LocationAddress = response.Entity.LocationAddress;
                    model.GeneralUnitsDTO.CityId = response.Entity.CityId;
                    model.GeneralUnitsDTO.UnitType = response.Entity.UnitType;
                    model.GeneralUnitsDTO.RelatedwithUnitType = response.Entity.RelatedwithUnitType;
                    model.GeneralUnitsDTO.CentreName = response.Entity.CentreName;
                    model.GeneralUnitsDTO.LocationName = response.Entity.LocationName;
                    model.GeneralUnitsDTO.DepartmentName = response.Entity.DepartmentName;

                    model.GeneralUnitsDTO.CreatedBy = response.Entity.CreatedBy;
                }
                return PartialView("/Views/Inventory/GeneralUnits/View.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public ActionResult Delete(Int16 ID)
        {
            var errorMessage = string.Empty;
            if (ID > 0)
            {
                IBaseEntityResponse<GeneralUnits> response = null;
                GeneralUnits GeneralUnitsDTO = new GeneralUnits();
                GeneralUnitsDTO.ConnectionString = _connectioString;
                GeneralUnitsDTO.ID = ID;
                GeneralUnitsDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                response = _GeneralUnitsBA.DeleteGeneralUnits(GeneralUnitsDTO);
                errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
            }

            return Json(errorMessage, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetLocationList(string term, string GeneralUnitsID, string CentreCode)
        {
            var data = GetLocationListDetails(term, GeneralUnitsID, CentreCode);
            var result = (from r in data
                          select new
                          {
                              id = r.ID,
                              name = r.LocationName,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public List<InventoryLocationMaster> GetLocationListDetails(string SearchKeyWord, string GeneralUnitsID, string CentreCode)
        {
            InventoryLocationMasterSearchRequest searchRequest = new InventoryLocationMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.GeneralUnitsID = Convert.ToInt32(GeneralUnitsID);
            searchRequest.SearchWord = SearchKeyWord;
            searchRequest.CentreCode = CentreCode;

            List<InventoryLocationMaster> listLocation = new List<InventoryLocationMaster>();
            IBaseEntityCollectionResponse<InventoryLocationMaster> baseEntityCollectionResponse = _InventoryLocationMasterBA.GetInventoryLocationMasterList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listLocation = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listLocation;
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
        #endregion

        // Non-Action Method
        #region Methods

        protected List<AdminRoleMaster> GetListAdminRoleDomain(int GeneralUnitsID)
        {
            AdminRoleMasterSearchRequest searchRequest = new AdminRoleMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.AdminRoleDomainForID = GeneralUnitsID;
            searchRequest.AdminRoleDomainFor = "STORE";
            List<AdminRoleMaster> listAdminRoleDomain = new List<AdminRoleMaster>();
            IBaseEntityCollectionResponse<AdminRoleMaster> baseEntityCollectionResponse = _AdminRoleMasterBA.GetAdminRoleDomainList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listAdminRoleDomain = baseEntityCollectionResponse.CollectionResponse.OrderBy(x => x.AdminRoleDomainName).ToList();
                }
            }
            return listAdminRoleDomain;
        }

        [HttpPost]
        public JsonResult GetCityList(string term)
        {
            var data = GetCityListDetails(term);
            var result = (from r in data
                          select new
                          {
                              id = r.ID,
                              name = r.Description,
                          }).ToList();
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
        public IEnumerable<GeneralUnitsViewModel> GetGeneralUnits(out int TotalRecords, string centreCode)
        //public IEnumerable<GeneralUnitsViewModel> GetGeneralUnits(out int TotalRecords,string centreCode,string DepartmentID)
        {
            GeneralUnitsSearchRequest searchRequest = new GeneralUnitsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            _actionMode = Convert.ToString(TempData["ActionMode"]);
            if (Enum.TryParse(_actionMode, out actionModeEnum))     // checks actionMode i.e. Insert or Update // 
            {
                if (actionModeEnum == ActionModeEnum.Insert)        // parameters for SelectAll procedures under Insert or Update mode condition
                {
                    searchRequest.SortBy = "A.CreatedDate,B.UnitType,B.ID";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    //searchRequest.SearchBy = "B.UnitType";
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                    string[] Centre_code = centreCode.Split(':');
                    searchRequest.CentreCode = Centre_code[0];
                    //searchRequest.DepartmentID = Convert.ToInt32(!string.IsNullOrEmpty(DepartmentID) ? DepartmentID : null); ;
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "A.ModifiedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = String.Empty;
                    searchRequest.SortDirection = "Desc";
                    string[] Centre_code = centreCode.Split(':');
                    searchRequest.CentreCode = Centre_code[0];
                }
            }
            else
            {
                searchRequest.SortBy = _sortBy;                     // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;
                string[] Centre_code = centreCode.Split(':');
                searchRequest.CentreCode = Centre_code[0];
                //searchRequest.DepartmentID = Convert.ToInt32(!string.IsNullOrEmpty(DepartmentID) ? DepartmentID : null); ;
            }
            List<GeneralUnitsViewModel> listGeneralUnitsViewModel = new List<GeneralUnitsViewModel>();
            List<GeneralUnits> listGeneralUnits = new List<GeneralUnits>();
            IBaseEntityCollectionResponse<GeneralUnits> baseEntityCollectionResponse = _GeneralUnitsBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralUnits = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (GeneralUnits item in listGeneralUnits)
                    {
                        GeneralUnitsViewModel GeneralUnitsViewModel = new GeneralUnitsViewModel();
                        GeneralUnitsViewModel.GeneralUnitsDTO = item;
                        listGeneralUnitsViewModel.Add(GeneralUnitsViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listGeneralUnitsViewModel;
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
                    var _comPath = Server.MapPath("~") + "\\Content\\UploadedFiles\\Inventory\\Logo\\";
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

        // AjaxHandler Method
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param, string SelectedCentreCode)
        // public ActionResult AjaxHandler(JQueryDataTableParamModel param, string SelectedCentreCode, string SelectedDepartmentID)
        {
            if (Session["UserType"] != null)
            {
                int TotalRecords;
                var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
                string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

                IEnumerable<GeneralUnitsViewModel> filteredCountryMaster;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "B.UnitType,B.ID";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "A.UnitName Like '%" + param.sSearch + "%' or B.UnitType Like '%" + param.sSearch + "%' or D.LocationName Like '%" + param.sSearch + "%'";
                        }
                        break;
                    case 1:
                        _sortBy = "GeneralUnitTypeID,B.UnitType,B.ID";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                            // _searchBy = "A.UnitName like '%'";
                        }
                        else
                        {
                            _searchBy = "A.UnitName Like '%" + param.sSearch + "%' or B.UnitType Like '%" + param.sSearch + "%' or D.LocationName Like '%" + param.sSearch + "%'";
                            //_searchBy = "A.UnitName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;
                    case 2:
                        _sortBy = "B.UnitType";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                            //_searchBy = "B.UnitType like '%'";
                        }
                        else
                        {
                            _searchBy = "A.UnitName Like '%" + param.sSearch + "%' or B.UnitType Like '%" + param.sSearch + "%' or D.LocationName Like '%" + param.sSearch + "%'";
                            //_searchBy = "B.UnitType Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;
                    case 3:
                        _sortBy = "D.LocationName";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                            //_searchBy = "D.LocationName like '%'";
                        }
                        else
                        {
                            _searchBy = "A.UnitName Like '%" + param.sSearch + "%' or B.UnitType Like '%" + param.sSearch + "%' or D.LocationName Like '%" + param.sSearch + "%'";
                            // _searchBy = "D.LocationName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;

                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;

                if (!string.IsNullOrEmpty(SelectedCentreCode))
                //if (!string.IsNullOrEmpty(SelectedCentreCode) && !string.IsNullOrEmpty(SelectedDepartmentID))
                {
                    filteredCountryMaster = GetGeneralUnits(out TotalRecords, SelectedCentreCode);
                    // filteredCountryMaster = GetGeneralUnits(out TotalRecords, SelectedCentreCode, SelectedDepartmentID);
                }
                else
                {
                    filteredCountryMaster = new List<GeneralUnitsViewModel>();
                    TotalRecords = 0;
                }
                if ((filteredCountryMaster.Count()) == 0)
                {
                    filteredCountryMaster = new List<GeneralUnitsViewModel>();
                    TotalRecords = 0;
                }

                var records = filteredCountryMaster.Skip(0).Take(param.iDisplayLength);
                // var result = from c in records select new[] {Convert.ToString(c.GeneralUnitTypeID), Convert.ToString(c.UnitType) + " (" + Convert.ToString(c.RelatedwithUnitType) + ")", Convert.ToString(c.UnitName), Convert.ToString(c.LocationAddress), Convert.ToString(c.CityName), Convert.ToString(c.ID) };

                var result = from c in records select new[] { Convert.ToString(c.GeneralUnitTypeID), Convert.ToString(c.UnitType) + " (" + Convert.ToString(c.RelatedwithUnitType) + ")", Convert.ToString(c.UnitName), Convert.ToString(c.LocationName), Convert.ToString(c.ID), Convert.ToString(c.UnitType) };
                //var result = from c in records select new[] { Convert.ToString(c.GeneralUnitsID), Convert.ToString(c.UnitName), Convert.ToString(c.ProcessUnitName), Convert.ToString(c.ID), Convert.ToString(c.AllocatedFromDate), Convert.ToString(c.AllocatedUptoDate) };
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