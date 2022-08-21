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
    public class EmployeePersonalDetailsController : BaseController
    {
        IEmployeePersonalDetailsBA _employeePersonalDetailsBA = null;
        IGeneralLocationMasterBA _generalLocationMasterBA = null;
        IEmployeeContactDetailsBA _employeeContactDetailsBA = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public EmployeePersonalDetailsController()
        {
            _employeePersonalDetailsBA = new EmployeePersonalDetailsBA();
            _generalLocationMasterBA = new GeneralLocationMasterBA();
            _employeeContactDetailsBA = new EmployeeContactDetailsBA();
        }

        // Controller Methods
        public ActionResult Index(int EmployeeID, string EmployeeDetailsType)
        {
            ViewBag.EmployeeID = EmployeeID;
            ViewBag.EmployeeDetailsType = EmployeeDetailsType;
            
           return View("/Views/Employee/EmployeePersonalDetails/Index.cshtml");
           
        }


        public ActionResult EmployeeContactList(string EmployeeID, string actionMode)
        {
            try
            {
                EmployeeContactDetailsViewModel model = new EmployeeContactDetailsViewModel();
                model.EmployeeID = Convert.ToInt32(EmployeeID);
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Employee/EmployeePersonalDetails/EmployeeContactList.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }

          [HttpGet]
        public ActionResult EmployeeContactDetailsCreate(int EmployeeID)
        {
            EmployeeContactDetailsViewModel model = new EmployeeContactDetailsViewModel();
            model.EmployeeID = EmployeeID;


            List<GeneralCountryMaster> genCountryMasterList = GetListGeneralCountryMaster();
            List<SelectListItem> genCountryMaster = new List<SelectListItem>();
            foreach (GeneralCountryMaster item in genCountryMasterList)
            {
                genCountryMaster.Add(new SelectListItem { Text = item.CountryName, Value = item.ID.ToString() });
            }
            ViewBag.GenCountryMaster = new SelectList(genCountryMaster, "Value", "Text");

            List<SelectListItem> generalRegionMaster = new List<SelectListItem>();
            ViewBag.GeneralRegionMaster = new SelectList(generalRegionMaster, "Value", "Text");

            List<SelectListItem> generalCityMaster = new List<SelectListItem>();
            ViewBag.GeneralCityMaster = new SelectList(generalCityMaster, "Value", "Text");

            List<SelectListItem> generalLocationMaster = new List<SelectListItem>();
            ViewBag.GeneralLocationMaster = new SelectList(generalLocationMaster, "Value", "Text");

            //--------------------------------------For Address type list---------------------------------//
            List<SelectListItem> EmployeeContactDetails_AddressType = new List<SelectListItem>();
            ViewBag.EmployeeContactDetails_AddressType = new SelectList(EmployeeContactDetails_AddressType, "Value", "Text");
            List<SelectListItem> li_EmployeeContactDetails_AddressType = new List<SelectListItem>();
        //    li_EmployeeContactDetails_AddressType.Add(new SelectListItem { Text = "-- Select-- ", });
            li_EmployeeContactDetails_AddressType.Add(new SelectListItem { Text = "Correspondence", Value = "CORRESPONDENCE" });
            li_EmployeeContactDetails_AddressType.Add(new SelectListItem { Text = Resources.DisplayName_PERMANANT, Value = "PERMANANT" });
            ViewData["AddressType"] = li_EmployeeContactDetails_AddressType;
            return PartialView("/Views/Employee/EmployeePersonalDetails/EmployeeContactDetailsCreate.cshtml", model);
        }

          [HttpPost]
          public ActionResult EmployeeContactDetailsCreate(EmployeeContactDetailsViewModel employeeContactDetailsViewModel)
          {           
            try
            {
                employeeContactDetailsViewModel.EmployeeContactDetailsDTO.EmployeeID = employeeContactDetailsViewModel.EmployeeID;
                employeeContactDetailsViewModel.EmployeeContactDetailsDTO.AddressType = employeeContactDetailsViewModel.AddressType;
                employeeContactDetailsViewModel.EmployeeContactDetailsDTO.EmployeeAddress1 = employeeContactDetailsViewModel.EmployeeAddress1;
                employeeContactDetailsViewModel.EmployeeContactDetailsDTO.EmployeeAddress2 = employeeContactDetailsViewModel.EmployeeAddress2;
                employeeContactDetailsViewModel.EmployeeContactDetailsDTO.PlotNumber = employeeContactDetailsViewModel.PlotNumber;
                employeeContactDetailsViewModel.EmployeeContactDetailsDTO.StreetName = employeeContactDetailsViewModel.StreetName;
                employeeContactDetailsViewModel.EmployeeContactDetailsDTO.CountryID = employeeContactDetailsViewModel.CountryID;
                employeeContactDetailsViewModel.EmployeeContactDetailsDTO.RegionID = employeeContactDetailsViewModel.RegionID;
                employeeContactDetailsViewModel.EmployeeContactDetailsDTO.CityID = employeeContactDetailsViewModel.CityID;
                employeeContactDetailsViewModel.EmployeeContactDetailsDTO.ContactLocationID = employeeContactDetailsViewModel.ContactLocationID;
                employeeContactDetailsViewModel.EmployeeContactDetailsDTO.Pincode = employeeContactDetailsViewModel.Pincode;
                employeeContactDetailsViewModel.EmployeeContactDetailsDTO.TelephoneNumber = employeeContactDetailsViewModel.TelephoneNumber;
                employeeContactDetailsViewModel.EmployeeContactDetailsDTO.MobileNumber = employeeContactDetailsViewModel.MobileNumber;               
                employeeContactDetailsViewModel.EmployeeContactDetailsDTO.CreatedBy = Convert.ToInt32(Session["UserId"]);
                employeeContactDetailsViewModel.EmployeeContactDetailsDTO.ID = employeeContactDetailsViewModel.ID;
                employeeContactDetailsViewModel.EmployeeContactDetailsDTO.ConnectionString = _connectioString;
                IBaseEntityResponse<EmployeeContactDetails> response = _employeeContactDetailsBA.InsertEmployeeContactDetails(employeeContactDetailsViewModel.EmployeeContactDetailsDTO);
                employeeContactDetailsViewModel.EmployeeContactDetailsDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                return Json(employeeContactDetailsViewModel.EmployeeContactDetailsDTO.errorMessage, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
            //return Redirect("/EmployeeInformation/PersonalInformationHome/" + employeeContactDetailsViewModel);
        }

          [HttpGet]
          public ActionResult EmployeeContactDetailsEdit(int ID, string Mode)
          {

              List<GeneralCountryMaster> genCountryMasterList = GetListGeneralCountryMaster();
              List<SelectListItem> genCountryMaster = new List<SelectListItem>();
              foreach (GeneralCountryMaster item in genCountryMasterList)
              {
                  genCountryMaster.Add(new SelectListItem { Text = item.CountryName, Value = item.ID.ToString() });
              }
            //  ViewBag.GenCountryMaster = new SelectList(genCountryMaster, "Value", "Text");


             

              //--------------------------------------For Address type list---------------------------------//
              List<SelectListItem> EmployeeContactDetails_AddressType = new List<SelectListItem>();
             
              List<SelectListItem> li_EmployeeContactDetails_AddressType = new List<SelectListItem>();
             // li_EmployeeContactDetails_AddressType.Add(new SelectListItem { Text = "-- Select-- ", });
              li_EmployeeContactDetails_AddressType.Add(new SelectListItem { Text = "Correspondence", Value = "CORRESPONDENCE" });
              li_EmployeeContactDetails_AddressType.Add(new SelectListItem { Text = Resources.DisplayName_PERMANANT, Value = "PERMANANT" });
            
            //  ViewBag.EmployeeContactDetails_AddressType = new SelectList(li_EmployeeContactDetails_AddressType, "Value", "Text");

              EmployeeContactDetailsViewModel model = new EmployeeContactDetailsViewModel();
              EmployeeContactDetails EmployeeContactDetailsDTO = new EmployeeContactDetails();            
              model.EmployeeContactDetailsDTO.ConnectionString = _connectioString;
              model.EmployeeContactDetailsDTO.ID = ID;
              IBaseEntityResponse<EmployeeContactDetails> response = _employeeContactDetailsBA.SelectByID(model.EmployeeContactDetailsDTO);
              if (response.Entity != null)
              {
                  model.ID = response.Entity.ID;
                  model.EmployeeID = response.Entity.EmployeeID;
                  model.AddressType = response.Entity.AddressType;
                  model.EmployeeAddress1 = response.Entity.EmployeeAddress1;
                  model.EmployeeAddress2 = response.Entity.EmployeeAddress2;
                  model.PlotNumber = response.Entity.PlotNumber;
                  model.StreetName = response.Entity.StreetName;
                  model.CountryID = response.Entity.CountryID;
                  model.RegionID = response.Entity.RegionID;
                  model.CityID = response.Entity.CityID;
                  model.ContactLocationID = response.Entity.ContactLocationID;
                  model.Location = response.Entity.ContactLocationID + "~" + response.Entity.Pincode;
                  model.Pincode = response.Entity.Pincode;
                  model.TelephoneNumber = response.Entity.TelephoneNumber;
                  model.MobileNumber = response.Entity.MobileNumber;
                  model.CurrentAddressFlag = response.Entity.CurrentAddressFlag;

                  string CountryID = response.Entity.CountryID.ToString();
                  List<GeneralRegionMaster> generalRegionMasterList = GetListGeneralRegionMaster(CountryID);
                  List<SelectListItem> generalRegionMaster = new List<SelectListItem>();
                  foreach (GeneralRegionMaster item in generalRegionMasterList)
                  {
                      generalRegionMaster.Add(new SelectListItem { Text = item.RegionName, Value = item.ID.ToString() });
                  }


                  string RegionID = response.Entity.RegionID.ToString();
                  List<GeneralCityMaster> generalCityMasterList = GetListGeneralCityMaster(RegionID);
                  List<SelectListItem> generalCityMaster = new List<SelectListItem>();
                  foreach (GeneralCityMaster item in generalCityMasterList)
                  {
                      generalCityMaster.Add(new SelectListItem { Text = item.Description, Value = item.ID.ToString() });
                  }

                  string CityID = response.Entity.CityID.ToString();
                  List<GeneralLocationMaster> generalLocationMasterList = GetListGeneralLocationMaster(CityID);            
                  List<SelectListItem> generalLocationMaster = new List<SelectListItem>();
                  foreach (GeneralLocationMaster item in generalLocationMasterList)
                  {
                      generalLocationMaster.Add(new SelectListItem { Text = item.LocationAddress, Value = item.ID.ToString()+"~"+item.PostCode.Trim() });
                  }           
             

                  ViewBag.GeneralCountryMaster = new SelectList(genCountryMaster, "Value", "Text", response.Entity.CountryID.ToString());
                  ViewBag.GeneralRegionMaster = new SelectList(generalRegionMaster, "Value", "Text", response.Entity.RegionID.ToString());
                  ViewBag.GeneralCityMaster = new SelectList(generalCityMaster, "Value", "Text", response.Entity.CityID.ToString());
                  ViewBag.GeneralLocationMaster = new SelectList(generalLocationMaster, "Value", "Text");
                  ViewData["AddressType"] = new SelectList(li_EmployeeContactDetails_AddressType, "Value", "Text", response.Entity.AddressType.ToString());
              }
              if (Mode == "Edit")
              {
                  return PartialView("/Views/Employee/EmployeePersonalDetails/EmployeeContactDetailsEdit.cshtml", model);
              }
              else
              {
                  return PartialView("/Views/Employee/EmployeePersonalDetails/EmployeeContactDetailsInfo.cshtml", model);
              }
          }

         [HttpPost]
          public ActionResult EmployeeContactDetailsEdit(EmployeeContactDetailsViewModel employeeContactDetailsViewModel)
          {           
            try
            {
                employeeContactDetailsViewModel.EmployeeContactDetailsDTO.EmployeeID = employeeContactDetailsViewModel.EmployeeID;
                employeeContactDetailsViewModel.EmployeeContactDetailsDTO.AddressType = employeeContactDetailsViewModel.AddressType;
                employeeContactDetailsViewModel.EmployeeContactDetailsDTO.EmployeeAddress1 = employeeContactDetailsViewModel.EmployeeAddress1;
                employeeContactDetailsViewModel.EmployeeContactDetailsDTO.EmployeeAddress2 = employeeContactDetailsViewModel.EmployeeAddress2;
                employeeContactDetailsViewModel.EmployeeContactDetailsDTO.PlotNumber = employeeContactDetailsViewModel.PlotNumber;
                employeeContactDetailsViewModel.EmployeeContactDetailsDTO.StreetName = employeeContactDetailsViewModel.StreetName;
                employeeContactDetailsViewModel.EmployeeContactDetailsDTO.CountryID = employeeContactDetailsViewModel.CountryID;
                employeeContactDetailsViewModel.EmployeeContactDetailsDTO.RegionID = employeeContactDetailsViewModel.RegionID;
                employeeContactDetailsViewModel.EmployeeContactDetailsDTO.CityID = employeeContactDetailsViewModel.CityID;
                employeeContactDetailsViewModel.EmployeeContactDetailsDTO.ContactLocationID = employeeContactDetailsViewModel.ContactLocationID;
                employeeContactDetailsViewModel.EmployeeContactDetailsDTO.Pincode = employeeContactDetailsViewModel.Pincode;
                employeeContactDetailsViewModel.EmployeeContactDetailsDTO.TelephoneNumber = employeeContactDetailsViewModel.TelephoneNumber;
                employeeContactDetailsViewModel.EmployeeContactDetailsDTO.MobileNumber = employeeContactDetailsViewModel.MobileNumber;               
                employeeContactDetailsViewModel.EmployeeContactDetailsDTO.ModifiedBy = Convert.ToInt32(Session["UserId"]);
                employeeContactDetailsViewModel.EmployeeContactDetailsDTO.ID = employeeContactDetailsViewModel.ID;
                employeeContactDetailsViewModel.EmployeeContactDetailsDTO.ConnectionString = _connectioString;
                IBaseEntityResponse<EmployeeContactDetails> response = _employeeContactDetailsBA.UpdateEmployeeContactDetails(employeeContactDetailsViewModel.EmployeeContactDetailsDTO);
                employeeContactDetailsViewModel.EmployeeContactDetailsDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                return Json(employeeContactDetailsViewModel.EmployeeContactDetailsDTO.errorMessage, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
            //return Redirect("/EmployeeInformation/PersonalInformationHome/" + employeeContactDetailsViewModel);
        }
        

        public ActionResult EmployeePersonalList(string EmployeeID, string actionMode)
        {
            try
            {
                EmployeePersonalDetailsViewModel model = new EmployeePersonalDetailsViewModel();
                model.EmployeeID = Convert.ToInt32(EmployeeID);
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Employee/EmployeePersonalDetails/PersonalList.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }

        // Non-Action Method
        #region Methods

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetRegionByCountryID(string SelectedCountryID)
        {
            if (String.IsNullOrEmpty(SelectedCountryID))
            {
                throw new ArgumentNullException("SelectedCountryID");
            }
            int id = 0;
            bool isValid = Int32.TryParse(SelectedCountryID, out id);
            var Region = GetListGeneralRegionMaster(SelectedCountryID);
            var result = (from s in Region select new { id = s.ID, name = s.RegionName, }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetCityByRegionID(string SelectedRegionID)
        {
            if (String.IsNullOrEmpty(SelectedRegionID))
            {
                throw new ArgumentNullException("SelectedRegionID");
            }
            int id = 0;
            bool isValid = Int32.TryParse(SelectedRegionID, out id);
            var City = GetListGeneralCityMaster(SelectedRegionID);
            var result = (from s in City select new { id = s.ID, name = s.Description, }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetLocationByCityID(string SelectedCityID)
        {
            if (String.IsNullOrEmpty(SelectedCityID))
            {
                throw new ArgumentNullException("SelectedCityID");
            }
            int id = 0;
            bool isValid = Int32.TryParse(SelectedCityID, out id);
            var City = GetListGeneralLocationMaster(SelectedCityID);
            var result = (from s in City select new { id = s.ID+"~"+s.PostCode.Trim(), name = s.LocationAddress, }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        protected List<GeneralLocationMaster> GetListGeneralLocationMaster(string CityID)
        {
            GeneralLocationMasterSearchRequest searchRequest = new GeneralLocationMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            int SelectedCityID = 0;
            bool isValid = Int32.TryParse(CityID, out SelectedCityID);
            searchRequest.CityID = Convert.ToInt32(CityID);
            //searchRequest.SearchType = 1;
            List<GeneralLocationMaster> listGeneralLocationMaster = new List<GeneralLocationMaster>();
            IBaseEntityCollectionResponse<GeneralLocationMaster> baseEntityCollectionResponse = _generalLocationMasterBA.GetByCityID(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralLocationMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listGeneralLocationMaster;
        }

        public IEnumerable<EmployeeContactDetailsViewModel> GetEmployeeContactDetails(int EmployeeID, out int TotalRecords)
        {
            EmployeeContactDetailsSearchRequest searchRequest = new EmployeeContactDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.EmployeeID = EmployeeID;
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
                searchRequest.SortBy = _sortBy;                     // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;
            }
            List<EmployeeContactDetailsViewModel> listEmployeeContactDetailsViewModel = new List<EmployeeContactDetailsViewModel>();
            List<EmployeeContactDetails> listEmployeeContactDetails = new List<EmployeeContactDetails>();
            IBaseEntityCollectionResponse<EmployeeContactDetails> baseEntityCollectionResponse = _employeeContactDetailsBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listEmployeeContactDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (EmployeeContactDetails item in listEmployeeContactDetails)
                    {
                        EmployeeContactDetailsViewModel EmployeeContactDetailsViewModel = new EmployeeContactDetailsViewModel();
                        EmployeeContactDetailsViewModel.EmployeeContactDetailsDTO = item;
                        listEmployeeContactDetailsViewModel.Add(EmployeeContactDetailsViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listEmployeeContactDetailsViewModel;
        }
        #endregion

        // AjaxHandler Method
        #region AjaxHandler
        public ActionResult AjaxHandlerEmployeeContactDetails(JQueryDataTableParamModel param, int EmployeeID)
        {
             int TotalRecords;
                var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
                string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

                IEnumerable<EmployeeContactDetailsViewModel> filteredEmployeePersonalDetails;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "ID";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "AddressType Like '%" + param.sSearch + "%' or CityName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;
                    case 1:
                        _sortBy = "ID";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "AddressType Like '%" + param.sSearch + "%' or CityName Like '%" + param.sSearch + "%'";      //this "if" block is added for search functionality
                        }
                        break;
                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                filteredEmployeePersonalDetails = GetEmployeeContactDetails(EmployeeID,out TotalRecords);
                var records = filteredEmployeePersonalDetails.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { Convert.ToString(c.AddressType), Convert.ToString(c.CityName), Convert.ToString(c.TelephoneNumber), Convert.ToString(c.MobileNumber), Convert.ToString(c.CurrentAddressFlag), Convert.ToString(c.ID),Convert.ToString(c.EmployeeID) };

                return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
            
        }
        #endregion
    }
}
