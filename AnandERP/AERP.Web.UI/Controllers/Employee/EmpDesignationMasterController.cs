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
    public class EmpDesignationMasterController : BaseController
    {

        IEmpDesignationMasterBA _empDesignationMasterBA = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public EmpDesignationMasterController()
        {
            _empDesignationMasterBA = new EmpDesignationMasterBA();
        }

        #region Controller Methods

        public ActionResult Index()
        {
            return View("/Views/Employee/EmpDesignationMaster/Index.cshtml");
        }

        public ActionResult List(string actionMode)
        {
            //System.Threading.Thread.Sleep(1000);
            // IEnumerable<EmpDesignationMasterViewModel> model = GetEmpDesignationMaster();
            //return View("/Views/EmpDesignationMaster/List.cshtml");

            try
            {
                EmpDesignationMasterViewModel model = new EmpDesignationMasterViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Employee/EmpDesignationMaster/List.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        public ActionResult Create()
        {
            EmpDesignationMasterViewModel model = new EmpDesignationMasterViewModel();

            List<SelectListItem> li = new List<SelectListItem>();
            // li.Add(new SelectListItem { Text = "--Select--", Value = " " });
            li.Add(new SelectListItem { Text = Resources.DropdownMessage_Employee, Value = "Emp" });
            li.Add(new SelectListItem { Text = Resources.DropdownMessage_BoardOfDirectors, Value = "Bod" });
            ViewData["EmpDesignationType"] = li;

            List<SelectListItem> li1 = new List<SelectListItem>();
            // li1.Add(new SelectListItem { Text = "--Select--", Value = " " });
            li1.Add(new SelectListItem { Text = Resources.DropdownMessage_Teaching, Value = "Teaching" });
            li1.Add(new SelectListItem { Text = Resources.DropdownMessage_NonTeaching, Value = "Non-Teachi" });
            ViewData["RelatedWith"] = li1;

            return PartialView("/Views/Employee/EmpDEsignationMaster/Create.cshtml",model);
        }

        [HttpPost]
        public ActionResult Create(EmpDesignationMasterViewModel model)
        {
            try
            {
                if (model != null && model.EmpDesignationMasterDTO != null)
                {
                    model.EmpDesignationMasterDTO.ConnectionString = _connectioString;
                    model.EmpDesignationMasterDTO.Description = model.Description;
                    model.EmpDesignationMasterDTO.DesignationLevel = model.DesignationLevel;
                    model.EmpDesignationMasterDTO.Grade = model.Grade;
                    model.EmpDesignationMasterDTO.EmpDesigType = model.EmpDesigType;
                    model.EmpDesignationMasterDTO.RelatedWith = model.RelatedWith;
                   //model.EmpDesignationMasterDTO.IsActive = model.IsActive;

                    model.EmpDesignationMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<EmpDesignationMaster> response = _empDesignationMasterBA.InsertEmpDesignationMaster(model.EmpDesignationMasterDTO);
                    model.EmpDesignationMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.EmpDesignationMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
                }

                return Json("Please review your form");

            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }

        public ActionResult Edit(int ID)
        {
            EmpDesignationMasterViewModel model = new EmpDesignationMasterViewModel();

            List<SelectListItem> li = new List<SelectListItem>();
            // li.Add(new SelectListItem { Text = "--Select--", Value = " " });
            li.Add(new SelectListItem { Text = Resources.DropdownMessage_Employee, Value = "Emp" });
            li.Add(new SelectListItem { Text = Resources.DropdownMessage_BoardOfDirectors, Value = "Bod" });
            ViewData["EmpDesignationType"] = li;

            List<SelectListItem> li1 = new List<SelectListItem>();
            // li1.Add(new SelectListItem { Text = "--Select--", Value = " " });
            li1.Add(new SelectListItem { Text = Resources.DropdownMessage_Teaching, Value = "Teaching" });
            li1.Add(new SelectListItem { Text = Resources.DropdownMessage_NonTeaching, Value = "Non-Teachi" });
            ViewData["RelatedWith"] = li1;

            try
            {
                model.EmpDesignationMasterDTO = new EmpDesignationMaster();
                model.EmpDesignationMasterDTO.ID = ID;
                model.EmpDesignationMasterDTO.ConnectionString = _connectioString;


                IBaseEntityResponse<EmpDesignationMaster> response = _empDesignationMasterBA.SelectByID(model.EmpDesignationMasterDTO);

                if (response != null && response.Entity != null)
                {
                    model.EmpDesignationMasterDTO.ID = response.Entity.ID;
                    model.EmpDesignationMasterDTO.Description = response.Entity.Description;
                    model.EmpDesignationMasterDTO.DesignationLevel = response.Entity.DesignationLevel;
                    model.EmpDesignationMasterDTO.Grade = response.Entity.Grade;
                    model.EmpDesignationMasterDTO.ShortCode = response.Entity.ShortCode;
                    model.EmpDesignationMasterDTO.EmpDesigType = response.Entity.EmpDesigType;
                    model.EmpDesignationMasterDTO.RelatedWith = response.Entity.RelatedWith;
                    model.EmpDesignationMasterDTO.IsActive = response.Entity.IsActive;
                    model.EmpDesignationMasterDTO.CreatedBy = response.Entity.CreatedBy;

                }
                ViewData["EmpDesignationType"] = new SelectList(li, "Value", "Text", (model.EmpDesigType).ToString().Trim());
                ViewData["RelatedWith"] = new SelectList(li1, "Value", "Text", (model.RelatedWith).ToString().Trim());
                return PartialView("/Views/Employee/EmpDEsignationMaster/Edit.cshtml", model);
            }

            catch (Exception)
            {
                throw;
            }
        }

        public ActionResult Details(int ID)
        {
            EmpDesignationMasterViewModel model = new EmpDesignationMasterViewModel();

            model.EmpDesignationMasterDTO = new EmpDesignationMaster();
            model.EmpDesignationMasterDTO.ID = ID;
            model.EmpDesignationMasterDTO.ConnectionString = _connectioString;

            IBaseEntityResponse<EmpDesignationMaster> response = _empDesignationMasterBA.SelectByID(model.EmpDesignationMasterDTO);

            if (response != null && response.Entity != null)
            {
                model.EmpDesignationMasterDTO.ID = response.Entity.ID;
                model.EmpDesignationMasterDTO.Description = response.Entity.Description;
                model.EmpDesignationMasterDTO.DesignationLevel = response.Entity.DesignationLevel;
                model.EmpDesignationMasterDTO.Grade = response.Entity.Grade;
                model.EmpDesignationMasterDTO.ShortCode = response.Entity.ShortCode;
                model.EmpDesignationMasterDTO.CollegeID = response.Entity.CollegeID;
                model.EmpDesignationMasterDTO.EmpDesigType = response.Entity.EmpDesigType;
                model.EmpDesignationMasterDTO.RelatedWith = response.Entity.RelatedWith;
            }

            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Edit(EmpDesignationMasterViewModel model)
        {
               
           if (model != null && model.EmpDesignationMasterDTO != null)
                 {
                        model.EmpDesignationMasterDTO.ConnectionString = _connectioString;
                        model.EmpDesignationMasterDTO.Description = model.Description;
                        model.EmpDesignationMasterDTO.DesignationLevel = model.DesignationLevel;
                        model.EmpDesignationMasterDTO.Grade = model.Grade;
                        model.EmpDesignationMasterDTO.EmpDesigType = model.EmpDesigType;
                        model.EmpDesignationMasterDTO.RelatedWith = model.RelatedWith;
                        model.EmpDesignationMasterDTO.IsActive = model.IsActive;
                        model.EmpDesignationMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<EmpDesignationMaster> response = _empDesignationMasterBA.UpdateEmpDesignationMaster(model.EmpDesignationMasterDTO);
                        model.EmpDesignationMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                        return Json(model.EmpDesignationMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
                  }
            else
            {
                return Content("Please review your form");
            }
        }
        
        public ActionResult Delete(int ID)
        {
            EmpDesignationMasterViewModel model = new EmpDesignationMasterViewModel();
            if (ID > 0)
            {
                EmpDesignationMaster empDesignationMasterDTO = new EmpDesignationMaster();
                empDesignationMasterDTO.ConnectionString = _connectioString;
                empDesignationMasterDTO.ID = ID;
                empDesignationMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                IBaseEntityResponse<EmpDesignationMaster> response = _empDesignationMasterBA.DeleteEmpDesignationMaster(empDesignationMasterDTO);
                model.EmpDesignationMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
                return Json(model.EmpDesignationMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Please review your form");
            }

        }


        #endregion

        #region Methods

        [HttpPost]
        public JsonResult GetEmpDesignationMasterSearchList(string term)
        {
            EmpDesignationMasterSearchRequest searchRequest = new EmpDesignationMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            searchRequest.SearchWord = term;
            List<EmpDesignationMaster> listFeeSubType = new List<EmpDesignationMaster>();
            IBaseEntityCollectionResponse<EmpDesignationMaster> baseEntityCollectionResponse = _empDesignationMasterBA.GetBySearchList(searchRequest);
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
                              DesignationMasterID = r.ID,
                              DesignationMasterName = r.Description,

                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public IEnumerable<EmpDesignationMasterViewModel> GetEmpDesignationMaster(out int TotalRecords)
        {
            EmpDesignationMasterSearchRequest searchRequest = new EmpDesignationMasterSearchRequest();
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
            List<EmpDesignationMasterViewModel> listEmpDesignationMasterViewModel = new List<EmpDesignationMasterViewModel>();
            List<EmpDesignationMaster> listEmpDesignationMaster = new List<EmpDesignationMaster>();
            IBaseEntityCollectionResponse<EmpDesignationMaster> baseEntityCollectionResponse = _empDesignationMasterBA.GetBySearch(searchRequest);

            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listEmpDesignationMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (EmpDesignationMaster item in listEmpDesignationMaster)
                    {
                        EmpDesignationMasterViewModel empDesignationMasterViewModel = new EmpDesignationMasterViewModel();
                        empDesignationMasterViewModel.EmpDesignationMasterDTO = item;
                        listEmpDesignationMasterViewModel.Add(empDesignationMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listEmpDesignationMasterViewModel; ;
        }

        #endregion
        #region

        public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        {
            if (Session["UserType"] != null)
            {
                int TotalRecords;
                var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
                string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

                IEnumerable<EmpDesignationMasterViewModel> filteredEmpDesignationMaster;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "Description ";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "Description  Like '%" + param.sSearch + "%' or DesignationLevel  Like '%" + param.sSearch + "%' or Grade  Like '%" + param.sSearch + "%' or ShortCode  Like '%" + param.sSearch + "%' or CollegeID  Like '%" + param.sSearch + "%' or EmpDesigType  Like '%" + param.sSearch + "%' or RelatedWith  Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;
                    case 1:
                        _sortBy = "DesignationLevel ";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "Description  Like '%" + param.sSearch + "%' or DesignationLevel  Like '%" + param.sSearch + "%' or Grade  Like '%" + param.sSearch + "%' or ShortCode  Like '%" + param.sSearch + "%' or CollegeID  Like '%" + param.sSearch + "%' or EmpDesigType  Like '%" + param.sSearch + "%' or RelatedWith  Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality

                        }
                        break;
                    case 2:
                        _sortBy = "Grade ";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "Description  Like '%" + param.sSearch + "%' or DesignationLevel  Like '%" + param.sSearch + "%' or Grade  Like '%" + param.sSearch + "%' or ShortCode  Like '%" + param.sSearch + "%' or CollegeID  Like '%" + param.sSearch + "%' or EmpDesigType  Like '%" + param.sSearch + "%' or RelatedWith  Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality

                        }
                        break;
                    case 3:
                        _sortBy = "ShortCode ";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "Description  Like '%" + param.sSearch + "%' or DesignationLevel  Like '%" + param.sSearch + "%' or Grade  Like '%" + param.sSearch + "%' or ShortCode  Like '%" + param.sSearch + "%' or CollegeID  Like '%" + param.sSearch + "%' or EmpDesigType  Like '%" + param.sSearch + "%' or RelatedWith  Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;

                    case 4:
                        _sortBy = "EmpDesigType ";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "Description  Like '%" + param.sSearch + "%' or DesignationLevel  Like '%" + param.sSearch + "%' or Grade  Like '%" + param.sSearch + "%' or ShortCode  Like '%" + param.sSearch + "%' or CollegeID  Like '%" + param.sSearch + "%' or EmpDesigType  Like '%" + param.sSearch + "%' or RelatedWith  Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;
                    case 5:
                        _sortBy = "RelatedWith ";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "Description  Like '%" + param.sSearch + "%' or DesignationLevel  Like '%" + param.sSearch + "%' or Grade  Like '%" + param.sSearch + "%' or ShortCode  Like '%" + param.sSearch + "%' or CollegeID  Like '%" + param.sSearch + "%' or EmpDesigType  Like '%" + param.sSearch + "%' or RelatedWith  Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;

                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                filteredEmpDesignationMaster = GetEmpDesignationMaster(out TotalRecords);
                var records = filteredEmpDesignationMaster.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { c.Description.ToString(), c.DesignationLevel.ToString(), c.Grade.ToString(), c.ShortCode.ToString(), c.EmpDesigType.ToString(), c.RelatedWith.ToString(), Convert.ToString(c.IsActive), Convert.ToString(c.ID) };

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
