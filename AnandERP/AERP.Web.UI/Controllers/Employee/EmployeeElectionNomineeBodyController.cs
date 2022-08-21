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
    public class EmployeeElectionNomineeBodyController : BaseController
    {
        IEmployeeElectionNomineeBodyServiceAccess _EmployeeElectionNomineeBodyServiceAcess = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public EmployeeElectionNomineeBodyController()
        {
            _EmployeeElectionNomineeBodyServiceAcess = new EmployeeElectionNomineeBodyServiceAccess();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index(int ID)
        {
            EmployeeElectionNomineeBodyViewModel model = new EmployeeElectionNomineeBodyViewModel();

            model.EmployeeID = ID;
            ViewBag.EmployeeID = ID;
            //ViewBag.EmpID = ID;
            return View("~/Views/Employee/EmployeeElectionNomineeBody/Index.cshtml");

        }

        public ActionResult List(string EmployeeID,string actionMode)
        {
            try
            {
                EmployeeElectionNomineeBodyViewModel model = new EmployeeElectionNomineeBodyViewModel();

                model.EmployeeID = Convert.ToInt32(EmployeeID);
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return View("~/Views/Employee/EmployeeElectionNomineeBody/List.cshtml", model);
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
            EmployeeElectionNomineeBodyViewModel model = new EmployeeElectionNomineeBodyViewModel();

            model.EmployeeID = Convert.ToInt32(Id);
            List<GeneralBoardUniversityMaster> GeneralBoardUniversityMasterList = GetListGeneralBoardUniversityMaster();
            List<SelectListItem> GeneralBoardUniversityMaster = new List<SelectListItem>();
            foreach (GeneralBoardUniversityMaster item in GeneralBoardUniversityMasterList)
            {
                GeneralBoardUniversityMaster.Add(new SelectListItem { Text = item.UniversityName, Value = item.ID.ToString() });
            }
            ViewBag.GeneralBoardUniversityMaster = new SelectList(GeneralBoardUniversityMaster, "Value", "Text");

            return PartialView("~/Views/Employee/EmployeeElectionNomineeBody/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(EmployeeElectionNomineeBodyViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.EmployeeElectionNomineeBodyDTO != null)
                    {
                        model.EmployeeElectionNomineeBodyDTO.ConnectionString = _connectioString;
                        model.EmployeeElectionNomineeBodyDTO.GeneralBoardUniversityID = model.GeneralBoardUniversityID;
                        model.EmployeeElectionNomineeBodyDTO.EmployeeID = model.EmployeeID;
                        model.EmployeeElectionNomineeBodyDTO.NameOfBoardBody = model.NameOfBoardBody;
                        model.EmployeeElectionNomineeBodyDTO.PostHeld = model.PostHeld;
                        model.EmployeeElectionNomineeBodyDTO.Remarks = model.Remarks;
                        model.EmployeeElectionNomineeBodyDTO.FromDate = model.FromDate;
                        model.EmployeeElectionNomineeBodyDTO.ToDate = model.ToDate;
                        //model.EmployeeElectionNomineeBodyDTO.InActiveReason = model.InActiveReason;
                        //model.EmployeeElectionNomineeBodyDTO.InActiveDate = model.InActiveDate;
                        model.EmployeeElectionNomineeBodyDTO.IsActive = model.IsActive;
                        model.EmployeeElectionNomineeBodyDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<EmployeeElectionNomineeBody> response = _EmployeeElectionNomineeBodyServiceAcess.InsertEmployeeElectionNomineeBody(model.EmployeeElectionNomineeBodyDTO);
                        model.EmployeeElectionNomineeBodyDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);

                    }
                    return Json(model.EmployeeElectionNomineeBodyDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
            EmployeeElectionNomineeBodyViewModel model = new EmployeeElectionNomineeBodyViewModel();
            try
            {
                model.EmployeeElectionNomineeBodyDTO = new EmployeeElectionNomineeBody();
                model.EmployeeElectionNomineeBodyDTO.ID = id;
                model.EmployeeElectionNomineeBodyDTO.ConnectionString = _connectioString;
                List<GeneralBoardUniversityMaster> GeneralBoardUniversityMasterList = GetListGeneralBoardUniversityMaster();
                List<SelectListItem> GeneralBoardUniversityMaster = new List<SelectListItem>();
                foreach (GeneralBoardUniversityMaster item in GeneralBoardUniversityMasterList)
                {
                    GeneralBoardUniversityMaster.Add(new SelectListItem { Text = item.UniversityName, Value = item.ID.ToString() });
                }


                IBaseEntityResponse<EmployeeElectionNomineeBody> response = _EmployeeElectionNomineeBodyServiceAcess.SelectByID(model.EmployeeElectionNomineeBodyDTO);
                if (response != null && response.Entity != null)
                {
                    model.EmployeeElectionNomineeBodyDTO.ID = response.Entity.ID;
                    model.EmployeeElectionNomineeBodyDTO.EmployeeID = response.Entity.EmployeeID;
                    model.EmployeeElectionNomineeBodyDTO.GeneralBoardUniversityID = response.Entity.GeneralBoardUniversityID;
                    model.EmployeeElectionNomineeBodyDTO.NameOfBoardBody = response.Entity.NameOfBoardBody;
                    model.EmployeeElectionNomineeBodyDTO.PostHeld = response.Entity.PostHeld;
                    model.EmployeeElectionNomineeBodyDTO.Remarks = response.Entity.Remarks;
                    model.EmployeeElectionNomineeBodyDTO.FromDate = response.Entity.FromDate;
                    model.EmployeeElectionNomineeBodyDTO.ToDate = response.Entity.ToDate;
                    //model.EmployeeElectionNomineeBodyDTO.InActiveReason = model.InActiveReason;
                    //model.EmployeeElectionNomineeBodyDTO.InActiveDate = model.InActiveDate;
                    model.EmployeeElectionNomineeBodyDTO.IsActive = response.Entity.IsActive;
                    //model.EmployeeElectionNomineeBodyDTO.CreatedBy = response.Entity.CreatedBy;
                }

                ViewBag.GeneralBoardUniversityMaster = new SelectList(GeneralBoardUniversityMaster, "Value", "Text");
                return PartialView("~/Views/Employee/EmployeeElectionNomineeBody/Edit.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(EmployeeElectionNomineeBodyViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model != null && model.EmployeeElectionNomineeBodyDTO != null)
                {
                    if (model != null && model.EmployeeElectionNomineeBodyDTO != null)
                    {
                        model.EmployeeElectionNomineeBodyDTO.ConnectionString = _connectioString;
                        model.EmployeeElectionNomineeBodyDTO.GeneralBoardUniversityID = model.GeneralBoardUniversityID;
                        model.EmployeeElectionNomineeBodyDTO.NameOfBoardBody = model.NameOfBoardBody;
                        model.EmployeeElectionNomineeBodyDTO.EmployeeID = model.EmployeeID;
                        model.EmployeeElectionNomineeBodyDTO.PostHeld = model.PostHeld;
                        model.EmployeeElectionNomineeBodyDTO.Remarks = model.Remarks;
                        model.EmployeeElectionNomineeBodyDTO.FromDate = model.FromDate;
                        model.EmployeeElectionNomineeBodyDTO.ToDate = model.ToDate;
                        //model.EmployeeElectionNomineeBodyDTO.InActiveReason = model.InActiveReason;
                        //model.EmployeeElectionNomineeBodyDTO.InActiveDate = model.InActiveDate;
                        model.EmployeeElectionNomineeBodyDTO.IsActive = model.IsActive;
                        model.EmployeeElectionNomineeBodyDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<EmployeeElectionNomineeBody> response = _EmployeeElectionNomineeBodyServiceAcess.UpdateEmployeeElectionNomineeBody(model.EmployeeElectionNomineeBodyDTO);
                        model.EmployeeElectionNomineeBodyDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                    }
                }
                return Json(model.EmployeeElectionNomineeBodyDTO.errorMessage, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Please review your form");
            }
        }

        //[HttpGet]
        //public ActionResult Delete(int ID)
        //{
        //    EmployeeElectionNomineeBodyViewModel model = new EmployeeElectionNomineeBodyViewModel();
        //    model.EmployeeElectionNomineeBodyDTO = new EmployeeElectionNomineeBody();
        //    model.EmployeeElectionNomineeBodyDTO.ID = ID;
        //    return PartialView("~/Views/Employee/EmployeeElectionNomineeBody/Delete.cshtml", model);
        //}

        //[HttpPost]
        //public ActionResult Delete(EmployeeElectionNomineeBodyViewModel model)
        //{
        //    //if (ModelState.IsValid)
        //    //{
        //        if (model.ID > 0)
        //        {
        //            EmployeeElectionNomineeBody EmployeeElectionNomineeBodyDTO = new EmployeeElectionNomineeBody();
        //            EmployeeElectionNomineeBodyDTO.ConnectionString = _connectioString;
        //            EmployeeElectionNomineeBodyDTO.ID = model.ID;
        //            EmployeeElectionNomineeBodyDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
        //            IBaseEntityResponse<EmployeeElectionNomineeBody> response = _EmployeeElectionNomineeBodyServiceAcess.DeleteEmployeeElectionNomineeBody(EmployeeElectionNomineeBodyDTO);
        //            model.EmployeeElectionNomineeBodyDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);

        //        }
        //        return Json(model.EmployeeElectionNomineeBodyDTO.errorMessage, JsonRequestBehavior.AllowGet);
        //    //}
        //    //else
        //    //{
        //    //    return Json("Please review your form");
        //    //}
        //}

        [HttpPost]
        public ActionResult Delete(int ID)
        {

            EmployeeElectionNomineeBodyViewModel model = new EmployeeElectionNomineeBodyViewModel();
            
            if (ID > 0)
            {
                EmployeeElectionNomineeBody EmployeeElectionNomineeBodyDTO = new EmployeeElectionNomineeBody();
                EmployeeElectionNomineeBodyDTO.ConnectionString = _connectioString;
                EmployeeElectionNomineeBodyDTO.ID = ID;
                EmployeeElectionNomineeBodyDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                IBaseEntityResponse<EmployeeElectionNomineeBody> response = _EmployeeElectionNomineeBodyServiceAcess.DeleteEmployeeElectionNomineeBody(EmployeeElectionNomineeBodyDTO);
                model.EmployeeElectionNomineeBodyDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);

            }
            return Json(model.EmployeeElectionNomineeBodyDTO.errorMessage, JsonRequestBehavior.AllowGet);
            
        }
        #endregion

        // Non-Action Method
        #region Methods
        public IEnumerable<EmployeeElectionNomineeBodyViewModel> GetEmployeeElectionNomineeBody(int EmployeeID, out int TotalRecords)
        {
            EmployeeElectionNomineeBodySearchRequest searchRequest = new EmployeeElectionNomineeBodySearchRequest();
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
            List<EmployeeElectionNomineeBodyViewModel> listEmployeeElectionNomineeBodyViewModel = new List<EmployeeElectionNomineeBodyViewModel>();
            List<EmployeeElectionNomineeBody> listEmployeeElectionNomineeBody = new List<EmployeeElectionNomineeBody>();
            IBaseEntityCollectionResponse<EmployeeElectionNomineeBody> baseEntityCollectionResponse = _EmployeeElectionNomineeBodyServiceAcess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listEmployeeElectionNomineeBody = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (EmployeeElectionNomineeBody item in listEmployeeElectionNomineeBody)
                    {
                        EmployeeElectionNomineeBodyViewModel EmployeeElectionNomineeBodyViewModel = new EmployeeElectionNomineeBodyViewModel();
                        EmployeeElectionNomineeBodyViewModel.EmployeeElectionNomineeBodyDTO = item;
                        listEmployeeElectionNomineeBodyViewModel.Add(EmployeeElectionNomineeBodyViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listEmployeeElectionNomineeBodyViewModel;
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

                IEnumerable<EmployeeElectionNomineeBodyViewModel> filteredCountryMaster;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "NameOfBoardBody";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "NameOfBoardBody Like '%" + param.sSearch + "%' or PostHeld Like '%" + param.sSearch + "%' or FromDate Like '%" + param.sSearch + "%' or ToDate Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;
                    case 1:
                        _sortBy = "PostHeld";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "NameOfBoardBody Like '%" + param.sSearch + "%' or PostHeld Like '%" + param.sSearch + "%' or FromDate Like '%" + param.sSearch + "%' or ToDate Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;
                    case 2:
                        _sortBy = "FromDate";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "NameOfBoardBody Like '%" + param.sSearch + "%' or PostHeld Like '%" + param.sSearch + "%' or FromDate Like '%" + param.sSearch + "%' or ToDate Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;
                    case 3:
                        _sortBy = "ToDate";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "NameOfBoardBody Like '%" + param.sSearch + "%' or PostHeld Like '%" + param.sSearch + "%' or FromDate Like '%" + param.sSearch + "%' or ToDate Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;
                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                filteredCountryMaster = GetEmployeeElectionNomineeBody(Convert.ToInt32(EmployeeID), out TotalRecords);
                var records = filteredCountryMaster.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { c.NameOfBoardBody.ToString(), c.PostHeld.ToString(), c.FromDate.ToString(), c.ToDate.ToString(), Convert.ToString(c.ID) };

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