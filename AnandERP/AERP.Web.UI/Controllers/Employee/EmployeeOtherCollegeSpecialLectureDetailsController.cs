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
    public class EmployeeOtherCollegeSpecialLectureDetailsController : BaseController
    {
        IEmployeeOtherCollegeSpecialLectureDetailsServiceAccess _EmployeeOtherCollegeSpecialLectureDetailsServiceAcess = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public EmployeeOtherCollegeSpecialLectureDetailsController()
        {
            _EmployeeOtherCollegeSpecialLectureDetailsServiceAcess = new EmployeeOtherCollegeSpecialLectureDetailsServiceAccess();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index(int ID)
        {
            EmployeeOtherCollegeSpecialLectureDetailsViewModel model = new EmployeeOtherCollegeSpecialLectureDetailsViewModel();

            model.EmployeeID = ID;
            ViewBag.EmployeeID = ID;
            //ViewBag.EmpID = ID;
            return View("~/Views/Employee/EmployeeOtherCollegeSpecialLectureDetails/Index.cshtml");

        }

        public ActionResult List(string EmployeeID, string actionMode)
        {
            try
            {
                EmployeeOtherCollegeSpecialLectureDetailsViewModel model = new EmployeeOtherCollegeSpecialLectureDetailsViewModel();

                model.EmployeeID = Convert.ToInt32(EmployeeID);
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return View("~/Views/Employee/EmployeeOtherCollegeSpecialLectureDetails/List.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }


        [HttpGet]
        public ActionResult Create(string Id)
        {
            EmployeeOtherCollegeSpecialLectureDetailsViewModel model = new EmployeeOtherCollegeSpecialLectureDetailsViewModel();

            model.EmployeeID = Convert.ToInt32(Id);
           
            return PartialView("~/Views/Employee/EmployeeOtherCollegeSpecialLectureDetails/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(EmployeeOtherCollegeSpecialLectureDetailsViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.EmployeeOtherCollegeSpecialLectureDetailsDTO != null)
                    {
                        model.EmployeeOtherCollegeSpecialLectureDetailsDTO.ConnectionString = _connectioString;
                        model.EmployeeOtherCollegeSpecialLectureDetailsDTO.InstituteName = model.InstituteName;
                        model.EmployeeOtherCollegeSpecialLectureDetailsDTO.EmployeeID = model.EmployeeID;
                        model.EmployeeOtherCollegeSpecialLectureDetailsDTO.TopicOfLecture = model.TopicOfLecture;
                        model.EmployeeOtherCollegeSpecialLectureDetailsDTO.DateOfLectureDelivered = model.DateOfLectureDelivered;
                        model.EmployeeOtherCollegeSpecialLectureDetailsDTO.Remarks = model.Remarks;
                        model.EmployeeOtherCollegeSpecialLectureDetailsDTO.InstituteAddress = model.InstituteAddress;
                       // model.EmployeeOtherCollegeSpecialLectureDetailsDTO.IsActive = model.IsActive;
                        model.EmployeeOtherCollegeSpecialLectureDetailsDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<EmployeeOtherCollegeSpecialLectureDetails> response = _EmployeeOtherCollegeSpecialLectureDetailsServiceAcess.InsertEmployeeOtherCollegeSpecialLectureDetails(model.EmployeeOtherCollegeSpecialLectureDetailsDTO);
                        model.EmployeeOtherCollegeSpecialLectureDetailsDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);

                    }
                    return Json(model.EmployeeOtherCollegeSpecialLectureDetailsDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
            EmployeeOtherCollegeSpecialLectureDetailsViewModel model = new EmployeeOtherCollegeSpecialLectureDetailsViewModel();
            try
            {
                model.EmployeeOtherCollegeSpecialLectureDetailsDTO = new EmployeeOtherCollegeSpecialLectureDetails();
                model.EmployeeOtherCollegeSpecialLectureDetailsDTO.ID = id;
                model.EmployeeOtherCollegeSpecialLectureDetailsDTO.ConnectionString = _connectioString;
              

                IBaseEntityResponse<EmployeeOtherCollegeSpecialLectureDetails> response = _EmployeeOtherCollegeSpecialLectureDetailsServiceAcess.SelectByID(model.EmployeeOtherCollegeSpecialLectureDetailsDTO);
                if (response != null && response.Entity != null)
                {
                    model.EmployeeOtherCollegeSpecialLectureDetailsDTO.ID = response.Entity.ID;
                    model.EmployeeOtherCollegeSpecialLectureDetailsDTO.EmployeeID = response.Entity.EmployeeID;
                    model.EmployeeOtherCollegeSpecialLectureDetailsDTO.InstituteName = response.Entity.InstituteName;
                    model.EmployeeOtherCollegeSpecialLectureDetailsDTO.TopicOfLecture = response.Entity.TopicOfLecture;
                    model.EmployeeOtherCollegeSpecialLectureDetailsDTO.DateOfLectureDelivered = response.Entity.DateOfLectureDelivered;
                    model.EmployeeOtherCollegeSpecialLectureDetailsDTO.Remarks = response.Entity.Remarks;
                    model.EmployeeOtherCollegeSpecialLectureDetailsDTO.InstituteAddress = response.Entity.InstituteAddress;

                 //   model.EmployeeOtherCollegeSpecialLectureDetailsDTO.IsActive = response.Entity.IsActive;

                }

              
                return PartialView("~/Views/Employee/EmployeeOtherCollegeSpecialLectureDetails/Edit.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(EmployeeOtherCollegeSpecialLectureDetailsViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model != null && model.EmployeeOtherCollegeSpecialLectureDetailsDTO != null)
                {
                    if (model != null && model.EmployeeOtherCollegeSpecialLectureDetailsDTO != null)
                    {
                        model.EmployeeOtherCollegeSpecialLectureDetailsDTO.ConnectionString = _connectioString;
                        model.EmployeeOtherCollegeSpecialLectureDetailsDTO.InstituteName = model.InstituteName;
                        model.EmployeeOtherCollegeSpecialLectureDetailsDTO.TopicOfLecture = model.TopicOfLecture;
                        model.EmployeeOtherCollegeSpecialLectureDetailsDTO.EmployeeID = model.EmployeeID;
                        model.EmployeeOtherCollegeSpecialLectureDetailsDTO.DateOfLectureDelivered = model.DateOfLectureDelivered;
                        model.EmployeeOtherCollegeSpecialLectureDetailsDTO.Remarks = model.Remarks;
                        model.EmployeeOtherCollegeSpecialLectureDetailsDTO.InstituteAddress = model.InstituteAddress;
                      //  model.EmployeeOtherCollegeSpecialLectureDetailsDTO.IsActive = model.IsActive;
                        model.EmployeeOtherCollegeSpecialLectureDetailsDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<EmployeeOtherCollegeSpecialLectureDetails> response = _EmployeeOtherCollegeSpecialLectureDetailsServiceAcess.UpdateEmployeeOtherCollegeSpecialLectureDetails(model.EmployeeOtherCollegeSpecialLectureDetailsDTO);
                        model.EmployeeOtherCollegeSpecialLectureDetailsDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                    }
                }
                return Json(model.EmployeeOtherCollegeSpecialLectureDetailsDTO.errorMessage, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Please review your form");
            }
        }

        //[HttpGet]
        //public ActionResult Delete(int ID)
        //{
        //    EmployeeOtherCollegeSpecialLectureDetailsViewModel model = new EmployeeOtherCollegeSpecialLectureDetailsViewModel();
        //    model.EmployeeOtherCollegeSpecialLectureDetailsDTO = new EmployeeOtherCollegeSpecialLectureDetails();
        //    model.EmployeeOtherCollegeSpecialLectureDetailsDTO.ID = ID;
        //    return PartialView("~/Views/Employee/EmployeeOtherCollegeSpecialLectureDetails/Delete.cshtml", model);
        //}

        //[HttpPost]
        //public ActionResult Delete(EmployeeOtherCollegeSpecialLectureDetailsViewModel model)
        //{
        //    //if (ModelState.IsValid)
        //    //{
        //    if (model.ID > 0)
        //    {
        //        EmployeeOtherCollegeSpecialLectureDetails EmployeeOtherCollegeSpecialLectureDetailsDTO = new EmployeeOtherCollegeSpecialLectureDetails();
        //        EmployeeOtherCollegeSpecialLectureDetailsDTO.ConnectionString = _connectioString;
        //        EmployeeOtherCollegeSpecialLectureDetailsDTO.ID = model.ID;
        //        EmployeeOtherCollegeSpecialLectureDetailsDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
        //        IBaseEntityResponse<EmployeeOtherCollegeSpecialLectureDetails> response = _EmployeeOtherCollegeSpecialLectureDetailsServiceAcess.DeleteEmployeeOtherCollegeSpecialLectureDetails(EmployeeOtherCollegeSpecialLectureDetailsDTO);
        //        model.EmployeeOtherCollegeSpecialLectureDetailsDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);

        //    }
        //    return Json(model.EmployeeOtherCollegeSpecialLectureDetailsDTO.errorMessage, JsonRequestBehavior.AllowGet);
        //    //}
        //    //else
        //    //{
        //    //    return Json("Please review your form");
        //    //}
        //}

        [HttpPost]
        public ActionResult Delete(int ID)
        {

            EmployeeOtherCollegeSpecialLectureDetailsViewModel model = new EmployeeOtherCollegeSpecialLectureDetailsViewModel();
            
            if (ID > 0)
            {
                EmployeeOtherCollegeSpecialLectureDetails EmployeeOtherCollegeSpecialLectureDetailsDTO = new EmployeeOtherCollegeSpecialLectureDetails();
                EmployeeOtherCollegeSpecialLectureDetailsDTO.ConnectionString = _connectioString;
                EmployeeOtherCollegeSpecialLectureDetailsDTO.ID = ID;
                EmployeeOtherCollegeSpecialLectureDetailsDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                IBaseEntityResponse<EmployeeOtherCollegeSpecialLectureDetails> response = _EmployeeOtherCollegeSpecialLectureDetailsServiceAcess.DeleteEmployeeOtherCollegeSpecialLectureDetails(EmployeeOtherCollegeSpecialLectureDetailsDTO);
                model.EmployeeOtherCollegeSpecialLectureDetailsDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);

            }
            return Json(model.EmployeeOtherCollegeSpecialLectureDetailsDTO.errorMessage, JsonRequestBehavior.AllowGet);
            
        }
        #endregion

        // Non-Action Method
        #region Methods
        public IEnumerable<EmployeeOtherCollegeSpecialLectureDetailsViewModel> GetEmployeeOtherCollegeSpecialLectureDetails(int EmployeeID, out int TotalRecords)
        {
            EmployeeOtherCollegeSpecialLectureDetailsSearchRequest searchRequest = new EmployeeOtherCollegeSpecialLectureDetailsSearchRequest();
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
            List<EmployeeOtherCollegeSpecialLectureDetailsViewModel> listEmployeeOtherCollegeSpecialLectureDetailsViewModel = new List<EmployeeOtherCollegeSpecialLectureDetailsViewModel>();
            List<EmployeeOtherCollegeSpecialLectureDetails> listEmployeeOtherCollegeSpecialLectureDetails = new List<EmployeeOtherCollegeSpecialLectureDetails>();
            IBaseEntityCollectionResponse<EmployeeOtherCollegeSpecialLectureDetails> baseEntityCollectionResponse = _EmployeeOtherCollegeSpecialLectureDetailsServiceAcess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listEmployeeOtherCollegeSpecialLectureDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (EmployeeOtherCollegeSpecialLectureDetails item in listEmployeeOtherCollegeSpecialLectureDetails)
                    {
                        EmployeeOtherCollegeSpecialLectureDetailsViewModel EmployeeOtherCollegeSpecialLectureDetailsViewModel = new EmployeeOtherCollegeSpecialLectureDetailsViewModel();
                        EmployeeOtherCollegeSpecialLectureDetailsViewModel.EmployeeOtherCollegeSpecialLectureDetailsDTO = item;
                        listEmployeeOtherCollegeSpecialLectureDetailsViewModel.Add(EmployeeOtherCollegeSpecialLectureDetailsViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listEmployeeOtherCollegeSpecialLectureDetailsViewModel;
        }
        #endregion

        // AjaxHandler Method
        #region AjaxHandler
        public ActionResult AjaxHandler(string EmployeeID, JQueryDataTableParamModel param)
        {
            //if (Session["UserType"] != null)
            //{
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<EmployeeOtherCollegeSpecialLectureDetailsViewModel> filteredCountryMaster;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "InstituteName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "TopicOfLecture Like '%" + param.sSearch + "%' or DateOfLectureDelivered Like '%" + param.sSearch + "%' or InstituteAddress Like '%" + param.sSearch + "%' or InstituteName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "InstituteAddress";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "TopicOfLecture Like '%" + param.sSearch + "%' or DateOfLectureDelivered Like '%" + param.sSearch + "%' or InstituteAddress Like '%" + param.sSearch + "%' or InstituteName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 2:
                    _sortBy = "TopicOfLecture";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "TopicOfLecture Like '%" + param.sSearch + "%' or DateOfLectureDelivered Like '%" + param.sSearch + "%' or InstituteAddress Like '%" + param.sSearch + "%' or InstituteName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 3:
                    _sortBy = "DateOfLectureDelivered";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "TopicOfLecture Like '%" + param.sSearch + "%' or DateOfLectureDelivered Like '%" + param.sSearch + "%' or InstituteAddress Like '%" + param.sSearch + "%' or InstituteName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;


            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            filteredCountryMaster = GetEmployeeOtherCollegeSpecialLectureDetails(Convert.ToInt32(EmployeeID), out TotalRecords);
            var records = filteredCountryMaster.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { c.InstituteName.ToString(), c.InstituteAddress.ToString(), c.TopicOfLecture.ToString(), c.DateOfLectureDelivered.ToString(), Convert.ToString(c.ID) };

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
            //}
            //else
            //{

            //    //return View("Login","Account");
            //    //return RedirectToAction("Login", "Account");
            //    var result = 0;
            //    return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
            //    // return PartialView("Login");
            //}
        }
        #endregion
    }
}