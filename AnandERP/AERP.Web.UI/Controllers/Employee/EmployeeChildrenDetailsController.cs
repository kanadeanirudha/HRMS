using AMS.Base.DTO;
using AMS.DTO;
using AMS.ServiceAccess;
using AMS.ExceptionManager;
using AMS.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using AMS.Common;
using AMS.DataProvider;
namespace AMS.Web.UI.Controllers
{
    public class EmployeeChildrenDetailsController : BaseController
    {
        IEmployeeChildrenDetailsServiceAccess _employeeChildrenDetailsServiceAccess = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public EmployeeChildrenDetailsController()
        {
            _employeeChildrenDetailsServiceAccess = new EmployeeChildrenDetailsServiceAccess();
            
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index(int ID)
        {
            ViewBag.EmployeeID = ID;
            return View("~/Views/Employee/EmployeeChildrenDetails/Index.cshtml");
        }

        public ActionResult List(string actionMode, int EmployeeID)
        {
            try
            {
                EmployeeChildrenDetailsViewModel model = new EmployeeChildrenDetailsViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("~/Views/Employee/EmployeeChildrenDetails/List.cshtml", model);
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
            try
            {

                //--------------------------------------For Title---------------------------------//
                List<GeneralTitleMaster> GeneralTitleMasterList = GetListGeneralTitleMaster();
                List<SelectListItem> ListGeneralTitleMaster = new List<SelectListItem>();
                foreach (GeneralTitleMaster item in GeneralTitleMasterList)
                {
                    ListGeneralTitleMaster.Add(new SelectListItem { Text = item.NameTitle, Value = item.NameTitle.ToString() });
                }
                ViewBag.GeneralTitleMasterList = new SelectList(ListGeneralTitleMaster, "Value", "Text");

                //--------------------------------------For Children Relation---------------------------------//
                EmployeeChildrenDetailsViewModel model = new EmployeeChildrenDetailsViewModel();
                List<SelectListItem> li = new List<SelectListItem>();
                li.Add(new SelectListItem { Text = Resources.ddlHeaders_SelectChildrenRelation, });
                li.Add(new SelectListItem { Text = Resources.DisplayName_Son, Value = "Son" });
                li.Add(new SelectListItem { Text = Resources.DisplayName_Daughter, Value = "Daughter" });
            
                ViewData["ChildrenRelation"] = li;         
                return PartialView("/Views/Employee/EmployeeChildrenDetails/Create.cshtml", model);

            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }

        [HttpPost]
        public ActionResult Create(EmployeeChildrenDetailsViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.EmployeeChildrenDetailsDTO != null)
                    {
                        model.EmployeeChildrenDetailsDTO.ConnectionString = _connectioString;
                        model.EmployeeChildrenDetailsDTO.ID = model.ID;
                        model.EmployeeChildrenDetailsDTO.EmployeeID = model.EmployeeID;
                        model.EmployeeChildrenDetailsDTO.NameTitle = model.NameTitle;
                        model.EmployeeChildrenDetailsDTO.ChildName = model.ChildName;
                        model.EmployeeChildrenDetailsDTO.ChildDateOfBirth = model.ChildDateOfBirth;
                        model.EmployeeChildrenDetailsDTO.GotAnyMedal = model.GotAnyMedal;
                        model.EmployeeChildrenDetailsDTO.MedalReceivedDate = model.MedalReceivedDate;
                        model.EmployeeChildrenDetailsDTO.MedalDescription = model.MedalDescription;
                        model.EmployeeChildrenDetailsDTO.IsScholarshipReceived = model.IsScholarshipReceived;
                        model.EmployeeChildrenDetailsDTO.ScholarshipAmount = model.ScholarshipAmount;
                        model.EmployeeChildrenDetailsDTO.ScholarshipStartDate = model.ScholarshipStartDate;
                        model.EmployeeChildrenDetailsDTO.ScholarshipUptoDate = model.ScholarshipUptoDate;
                        model.EmployeeChildrenDetailsDTO.ScholarshipDescription = model.ScholarshipDescription;
                        model.EmployeeChildrenDetailsDTO.IdentityMarks = model.IdentityMarks;
                        model.EmployeeChildrenDetailsDTO.Profession = model.Profession;
                        model.EmployeeChildrenDetailsDTO.Height = model.Height;
                        model.EmployeeChildrenDetailsDTO.Weight = model.Weight;
                        model.EmployeeChildrenDetailsDTO.Sports = model.Sports;
                        model.EmployeeChildrenDetailsDTO.Hobby = model.Hobby;
                        model.EmployeeChildrenDetailsDTO.CurriculamActivity = model.CurriculamActivity;
                        model.EmployeeChildrenDetailsDTO.ChildrenRelation = model.ChildrenRelation;
                        model.EmployeeChildrenDetailsDTO.ChildQualification = model.ChildQualification;
                        model.EmployeeChildrenDetailsDTO.IsActive = true;
                        model.EmployeeChildrenDetailsDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<EmployeeChildrenDetails> response = _employeeChildrenDetailsServiceAccess.InsertEmployeeChildrenDetails(model.EmployeeChildrenDetailsDTO);
                        model.EmployeeChildrenDetailsDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);

                    }
                    return Json(model.EmployeeChildrenDetailsDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
            EmployeeChildrenDetailsViewModel model = new EmployeeChildrenDetailsViewModel();
            try
            {
                model.EmployeeChildrenDetailsDTO = new EmployeeChildrenDetails();
                model.EmployeeChildrenDetailsDTO.ID = ID;
                model.EmployeeChildrenDetailsDTO.ConnectionString = _connectioString;
                //--------------------------------------For Title---------------------------------//
                List<GeneralTitleMaster> GeneralTitleMasterList = GetListGeneralTitleMaster();
                List<SelectListItem> ListGeneralTitleMaster = new List<SelectListItem>();
                foreach (GeneralTitleMaster item in GeneralTitleMasterList)
                {
                    ListGeneralTitleMaster.Add(new SelectListItem { Text = item.NameTitle, Value = item.NameTitle.ToString() });
                }
                ViewBag.GeneralTitleMasterList = new SelectList(ListGeneralTitleMaster, "Value", "Text");

                //--------------------------------------For Children Relation---------------------------------//

                List<SelectListItem> li = new List<SelectListItem>();
                li.Add(new SelectListItem { Text = Resources.DisplayName_Son, Value = "Son" });
                li.Add(new SelectListItem { Text = Resources.DisplayName_Daughter, Value = "Daughter" });

            



                IBaseEntityResponse<EmployeeChildrenDetails> response = _employeeChildrenDetailsServiceAccess.SelectByID(model.EmployeeChildrenDetailsDTO);
                if (response != null && response.Entity != null)
                {
                    model.EmployeeChildrenDetailsDTO.ConnectionString = _connectioString;
                    model.EmployeeChildrenDetailsDTO.EmployeeID = response.Entity.EmployeeID;
                    model.EmployeeChildrenDetailsDTO.NameTitle = response.Entity.NameTitle;
                    model.EmployeeChildrenDetailsDTO.ChildName = response.Entity.ChildName;
                    model.EmployeeChildrenDetailsDTO.ChildDateOfBirth = response.Entity.ChildDateOfBirth;
                    model.EmployeeChildrenDetailsDTO.GotAnyMedal = response.Entity.GotAnyMedal;
                    model.EmployeeChildrenDetailsDTO.MedalReceivedDate = response.Entity.MedalReceivedDate;
                    model.EmployeeChildrenDetailsDTO.MedalDescription = response.Entity.MedalDescription;
                    model.EmployeeChildrenDetailsDTO.IsScholarshipReceived = response.Entity.IsScholarshipReceived;
                    model.EmployeeChildrenDetailsDTO.ScholarshipAmount = response.Entity.ScholarshipAmount;
                    model.EmployeeChildrenDetailsDTO.ScholarshipStartDate = response.Entity.ScholarshipStartDate;
                    model.EmployeeChildrenDetailsDTO.ScholarshipUptoDate = response.Entity.ScholarshipUptoDate;
                    model.EmployeeChildrenDetailsDTO.ScholarshipDescription = response.Entity.ScholarshipDescription;
                    model.EmployeeChildrenDetailsDTO.IdentityMarks = response.Entity.IdentityMarks;
                    model.EmployeeChildrenDetailsDTO.Profession = response.Entity.Profession;
                    model.EmployeeChildrenDetailsDTO.Height = response.Entity.Height;
                    model.EmployeeChildrenDetailsDTO.Weight = response.Entity.Weight;
                    model.EmployeeChildrenDetailsDTO.Sports = response.Entity.Sports;
                    model.EmployeeChildrenDetailsDTO.Hobby = response.Entity.Hobby;
                    model.EmployeeChildrenDetailsDTO.CurriculamActivity = response.Entity.CurriculamActivity;
                    model.EmployeeChildrenDetailsDTO.ChildrenRelation = response.Entity.ChildrenRelation;
                    model.EmployeeChildrenDetailsDTO.ChildQualification = response.Entity.ChildQualification;
                    model.EmployeeChildrenDetailsDTO.IsActive = true;
                }

                ViewBag.GeneralTitleMasterList = new SelectList(ListGeneralTitleMaster, "Value", "Text");
                ViewData["ChildrenRelation"] = li;  
                return PartialView("/Views/Employee/EmployeeChildrenDetails/Edit.cshtml", model);

            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(EmployeeChildrenDetailsViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.EmployeeChildrenDetailsDTO != null)
                    {

                        model.EmployeeChildrenDetailsDTO.ConnectionString = _connectioString;
                        model.EmployeeChildrenDetailsDTO.ID = model.ID;
                        model.EmployeeChildrenDetailsDTO.EmployeeID = model.EmployeeID;
                        model.EmployeeChildrenDetailsDTO.NameTitle = model.NameTitle;
                        model.EmployeeChildrenDetailsDTO.ChildName = model.ChildName;
                        model.EmployeeChildrenDetailsDTO.ChildDateOfBirth = model.ChildDateOfBirth;
                        model.EmployeeChildrenDetailsDTO.GotAnyMedal = model.GotAnyMedal;
                        model.EmployeeChildrenDetailsDTO.MedalReceivedDate = model.MedalReceivedDate;
                        model.EmployeeChildrenDetailsDTO.MedalDescription = model.MedalDescription;
                        model.EmployeeChildrenDetailsDTO.IsScholarshipReceived = model.IsScholarshipReceived;
                        model.EmployeeChildrenDetailsDTO.ScholarshipAmount = model.ScholarshipAmount;
                        model.EmployeeChildrenDetailsDTO.ScholarshipStartDate = model.ScholarshipStartDate;
                        model.EmployeeChildrenDetailsDTO.ScholarshipUptoDate = model.ScholarshipUptoDate;
                        model.EmployeeChildrenDetailsDTO.ScholarshipDescription = model.ScholarshipDescription;
                        model.EmployeeChildrenDetailsDTO.IdentityMarks = model.IdentityMarks;
                        model.EmployeeChildrenDetailsDTO.Profession = model.Profession;
                        model.EmployeeChildrenDetailsDTO.Height = model.Height;
                        model.EmployeeChildrenDetailsDTO.Weight = model.Weight;
                        model.EmployeeChildrenDetailsDTO.Sports = model.Sports;
                        model.EmployeeChildrenDetailsDTO.Hobby = model.Hobby;
                        model.EmployeeChildrenDetailsDTO.ChildrenRelation = model.ChildrenRelation;
                        model.EmployeeChildrenDetailsDTO.ChildQualification = model.ChildQualification;
                        model.EmployeeChildrenDetailsDTO.IsActive = true;
                        model.EmployeeChildrenDetailsDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<EmployeeChildrenDetails> response = _employeeChildrenDetailsServiceAccess.UpdateEmployeeChildrenDetails(model.EmployeeChildrenDetailsDTO);
                        model.EmployeeChildrenDetailsDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                    }
                    return Json(model.EmployeeChildrenDetailsDTO.errorMessage, JsonRequestBehavior.AllowGet);
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


        //[HttpGet]
        //public ActionResult Delete(int ID)
        //{
        //    EmployeeChildrenDetailsViewModel model = new EmployeeChildrenDetailsViewModel();
        //    model.EmployeeChildrenDetailsDTO = new EmployeeChildrenDetails();
        //    model.EmployeeChildrenDetailsDTO.ID = ID;
        //    return PartialView("~/Views/Employee/EmployeeChildrenDetails/Delete.cshtml", model);
        //}

        //[HttpPost]
        //public ActionResult Delete(EmployeeChildrenDetailsViewModel model)
        //{
        //    try
        //    {

        //        if (model.ID > 0)
        //        {
        //            if (model != null && model.EmployeeChildrenDetailsDTO != null)
        //            {
        //                EmployeeChildrenDetails EmployeeChildrenDetailsDTO = new EmployeeChildrenDetails();
        //                EmployeeChildrenDetailsDTO.ConnectionString = _connectioString;
        //                EmployeeChildrenDetailsDTO.ID = model.ID;
        //                EmployeeChildrenDetailsDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
        //                IBaseEntityResponse<EmployeeChildrenDetails> response = _employeeChildrenDetailsServiceAccess.DeleteEmployeeChildrenDetails(EmployeeChildrenDetailsDTO);
        //                model.EmployeeChildrenDetailsDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
        //            }
        //            return Json(model.EmployeeChildrenDetailsDTO.errorMessage, JsonRequestBehavior.AllowGet);
        //        }
        //        else
        //        {
        //            return Json("Please review your form");
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        _logException.Error(ex.Message);
        //        throw;
        //    }
        //}

        //[HttpPost]
        public ActionResult Delete(int ID)
        {
            EmployeeChildrenDetailsViewModel model = new EmployeeChildrenDetailsViewModel();
            try
            {

                if (ID > 0)
                {
                    
                        EmployeeChildrenDetails EmployeeChildrenDetailsDTO = new EmployeeChildrenDetails();
                        EmployeeChildrenDetailsDTO.ConnectionString = _connectioString;
                        EmployeeChildrenDetailsDTO.ID = ID;
                        EmployeeChildrenDetailsDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<EmployeeChildrenDetails> response = _employeeChildrenDetailsServiceAccess.DeleteEmployeeChildrenDetails(EmployeeChildrenDetailsDTO);
                        model.EmployeeChildrenDetailsDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
                    
                    return Json(model.EmployeeChildrenDetailsDTO.errorMessage, JsonRequestBehavior.AllowGet);
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

        // Non-Action Method
        #region Methods
        public IEnumerable<EmployeeChildrenDetailsViewModel> GetEmployeeChildrenDetails(int EmployeeID, out int TotalRecords)
        {
            EmployeeChildrenDetailsSearchRequest searchRequest = new EmployeeChildrenDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
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
                    searchRequest.EmployeeID = EmployeeID;


                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "ModifiedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                    searchRequest.EmployeeID = EmployeeID;

                }
            }
            else
            {
                searchRequest.SortBy = _sortBy;                     // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;
                searchRequest.EmployeeID = EmployeeID;

            }








            List<EmployeeChildrenDetailsViewModel> listEmployeeChildrenDetailsViewModel = new List<EmployeeChildrenDetailsViewModel>();
            List<EmployeeChildrenDetails> listEmployeeChildrenDetails = new List<EmployeeChildrenDetails>();
            IBaseEntityCollectionResponse<EmployeeChildrenDetails> baseEntityCollectionResponse = _employeeChildrenDetailsServiceAccess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listEmployeeChildrenDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (EmployeeChildrenDetails item in listEmployeeChildrenDetails)
                    {
                        EmployeeChildrenDetailsViewModel EmployeeChildrenDetailsViewModel = new EmployeeChildrenDetailsViewModel();
                        EmployeeChildrenDetailsViewModel.EmployeeChildrenDetailsDTO = item;
                        listEmployeeChildrenDetailsViewModel.Add(EmployeeChildrenDetailsViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listEmployeeChildrenDetailsViewModel;
        }


      


        [HttpGet]
        public ActionResult GetCastByCategoryID(string SelectedCategoryID)
        {

            int id = 0;
            bool isValid = Int32.TryParse(SelectedCategoryID, out id);
            var GeneralCasteDetails = GetListGeneralCasteMaster(Convert.ToInt32(SelectedCategoryID));
            var result = (from s in GeneralCasteDetails
                          select new
                          {
                              id = s.ID,
                              name = s.CasteName,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult GetGeneralRegionDetailByCountryID(string SelectedCountryID)
        {

            int id = 0;
            bool isValid = Int32.TryParse(SelectedCountryID, out id);
            var GeneralRegionDetails = GetListGeneralRegionMaster(SelectedCountryID);
            var result = (from s in GeneralRegionDetails
                          select new
                          {
                              id = s.ID,
                              name = s.RegionName,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        // For CitynDetailByCountry
        [HttpGet]
        public ActionResult GetGeneralCityByRegionID(string SelectedRegionID)
        {
            if (SelectedRegionID == "Other")
            {
                SelectedRegionID = "0";
            }
            int id = 0;
            bool isValid = Int32.TryParse(SelectedRegionID, out id);
            var GeneralCityDetails = GetListGeneralCityMaster(SelectedRegionID);
            var result = (from s in GeneralCityDetails
                          select new
                          {
                              id = s.ID,
                              name = s.Description,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }





        #endregion

        // AjaxHandler Method
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param, int EmployeeID)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<EmployeeChildrenDetailsViewModel> filteredEmployeeChildrenDetails;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "NameTitle";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "NameTitle Like '%" + param.sSearch + "%' or ChildQualification Like '%" + param.sSearch + "%' or ChildrenRelation Like'%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;

                case 1:
                    _sortBy = "ChildQualification";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "NameTitle Like '%" + param.sSearch + "%' or ChildQualification Like '%" + param.sSearch + "%' or ChildrenRelation Like'%" + param.sSearch + "%'";         //this "if" block is added for search functionality
                    }
                    break;

                case 2:
                    _sortBy = "  ChildrenRelation";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "NameTitle Like '%" + param.sSearch + "%' or ChildQualification Like '%" + param.sSearch + "%' or ChildrenRelation Like'%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            filteredEmployeeChildrenDetails = GetEmployeeChildrenDetails(EmployeeID, out TotalRecords);
            var records = filteredEmployeeChildrenDetails.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.NameTitle) + " " + Convert.ToString(c.ChildName), Convert.ToString(c.ChildQualification),Convert.ToString(c.ChildrenRelation), Convert.ToString(c.EmployeeID), Convert.ToString(c.ID) };

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}