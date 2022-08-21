using AERP.Base.DTO;
using AERP.DTO;
using AERP.ExceptionManager;
using AERP.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using AERP.Common;
using AERP.Business.BusinessActions;

namespace AERP.Web.UI.Controllers
{
    public class GeneralGroupMasterController : BaseController
    {
        IGeneralGroupMasterBA _IGeneralGroupMasterBA = null;
        IGeneralGroupMasterViewModel model = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public GeneralGroupMasterController()
        {
            _IGeneralGroupMasterBA = new GeneralGroupMasterBA();
            model = new GeneralGroupMasterViewModel();
        }

        //  Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
            return View("/Views/GeneralMaster/GeneralGroupMaster/Index.cshtml");
        }

        public ActionResult List(string actionMode)
        {
            try
            {
                //GeneralGroupMasterViewModel model = new GeneralGroupMasterViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/GeneralMaster/GeneralGroupMaster/List.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetDepartmentByCentreCode(string SelectedCentreCode)
        {
          //  string[] splited;
            //splited = SelectedCentreCode.Split(':');
            //model.SelectedCentreName = splited[1];
            //SelectedCentreCode = splited[0];
            if (String.IsNullOrEmpty(SelectedCentreCode))
            {
                throw new ArgumentNullException("SelectedCentreCode");
            }
            int id = 0;
            bool isValid = Int32.TryParse(SelectedCentreCode, out id);
            var departments = GetListOrganisationDepartmentMaster(SelectedCentreCode);
            var result = (from s in departments
                          select new
                          {
                              id = s.ID,
                              name = s.DepartmentName,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            //GeneralGroupMasterViewModel model = new GeneralGroupMasterViewModel();
            List<SelectListItem> GeneralGroupMaster_GroupDependentObject = new List<SelectListItem>();
            ViewBag.GeneralGroupMaster_GroupDependentObject = new SelectList(GeneralGroupMaster_GroupDependentObject, "Value", "Text");
            List<SelectListItem> li_GeneralGroupMaster_GroupDependentObject = new List<SelectListItem>();
            li_GeneralGroupMaster_GroupDependentObject.Add(new SelectListItem { Text = Resources.ddlHeaders_Dependent });
            li_GeneralGroupMaster_GroupDependentObject.Add(new SelectListItem { Text = Resources.DropdownMessage_Department, Value = "Department" });
            li_GeneralGroupMaster_GroupDependentObject.Add(new SelectListItem { Text = Resources.DropdownMessage_Designation, Value = "Designation" });
            li_GeneralGroupMaster_GroupDependentObject.Add(new SelectListItem { Text = Resources.DropdownMessage_PayScale, Value = "PayScale" });
            ViewData["GroupDependentObject"] = li_GeneralGroupMaster_GroupDependentObject;

            List<GeneralJobProfile> generalJobProfileList = GetListGeneralJobProfile();
            List<SelectListItem> generalJobProfile = new List<SelectListItem>();
            foreach (GeneralJobProfile item in generalJobProfileList)
            {
                generalJobProfile.Add(new SelectListItem { Text = item.JobProfileDescription, Value = item.ID.ToString() });
            }
            ViewBag.generalJobProfileList = new SelectList(generalJobProfile, "Value", "Text");

            return PartialView("/Views/GeneralMaster/GeneralGroupMaster/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(GeneralGroupMasterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.GeneralGroupMasterDTO != null)
                    {
                        model.GeneralGroupMasterDTO.ConnectionString = _connectioString;
                        model.GeneralGroupMasterDTO.JobProfileID = model.JobProfileID;
                        model.GeneralGroupMasterDTO.GroupName = model.GroupName;
                        model.GeneralGroupMasterDTO.GroupDependentObject = model.GroupDependentObject;
                        model.GeneralGroupMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]); ;
                        IBaseEntityResponse<GeneralGroupMaster> response = _IGeneralGroupMasterBA.InsertGeneralGroupMaster(model.GeneralGroupMasterDTO);
                        model.GeneralGroupMasterDTO.ErrorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    }
                    return Json(model.GeneralGroupMasterDTO.ErrorMessage, JsonRequestBehavior.AllowGet);
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
            //GeneralGroupMasterViewModel model = new GeneralGroupMasterViewModel();

            List<SelectListItem> GeneralGroupMaster_GroupDependentObject = new List<SelectListItem>();
            ViewBag.GeneralGroupMaster_GroupDependentObject = new SelectList(GeneralGroupMaster_GroupDependentObject, "Value", "Text");
            List<SelectListItem> li_GeneralGroupMaster_GroupDependentObject = new List<SelectListItem>();
            li_GeneralGroupMaster_GroupDependentObject.Add(new SelectListItem { Text = Resources.ddlHeaders_Dependent });
            li_GeneralGroupMaster_GroupDependentObject.Add(new SelectListItem { Text = Resources.DropdownMessage_Department, Value = "Department" });
            li_GeneralGroupMaster_GroupDependentObject.Add(new SelectListItem { Text = Resources.DropdownMessage_Designation, Value = "Designation" });
            li_GeneralGroupMaster_GroupDependentObject.Add(new SelectListItem { Text = Resources.DropdownMessage_PayScale, Value = "PayScale" });
           

            List<GeneralJobProfile> generalJobProfileList = GetListGeneralJobProfile();
            List<SelectListItem> generalJobProfile = new List<SelectListItem>();
            foreach (GeneralJobProfile item in generalJobProfileList)
            {
                generalJobProfile.Add(new SelectListItem { Text = item.JobProfileDescription, Value = item.ID.ToString() });
            }
          

            model.GeneralGroupMasterDTO = new GeneralGroupMaster();
            model.GeneralGroupMasterDTO.ID = ID;
            model.GeneralGroupMasterDTO.ConnectionString = _connectioString;

            IBaseEntityResponse<GeneralGroupMaster> response = _IGeneralGroupMasterBA.SelectByID(model.GeneralGroupMasterDTO);

            if (response != null && response.Entity != null)
            {
                model.GeneralGroupMasterDTO.ID = response.Entity.ID;
                model.GeneralGroupMasterDTO.JobProfileID = response.Entity.JobProfileID;
                model.GeneralGroupMasterDTO.GroupName = response.Entity.GroupName;
                model.GeneralGroupMasterDTO.GroupDependentObject = response.Entity.GroupDependentObject;
            }
            ViewData["GroupDependentObject"] = new SelectList(li_GeneralGroupMaster_GroupDependentObject, "Value", "Text", model.GroupDependentObject);
            ViewBag.generalJobProfileList = new SelectList(generalJobProfile, "Value", "Text");
           
            return PartialView("/Views/GeneralMaster/GeneralGroupMaster/Edit.cshtml", model);
        }

        [HttpPost]
        public ActionResult Edit(GeneralGroupMasterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.GeneralGroupMasterDTO != null)
                    {
                        if (model != null && model.GeneralGroupMasterDTO != null)
                        {
                            model.GeneralGroupMasterDTO.ConnectionString = _connectioString;
                            model.GeneralGroupMasterDTO.JobProfileID = model.JobProfileID;
                            model.GeneralGroupMasterDTO.GroupName = model.GroupName;
                            model.GeneralGroupMasterDTO.GroupDependentObject = model.GroupDependentObject;
                            model.GeneralGroupMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                            IBaseEntityResponse<GeneralGroupMaster> response = _IGeneralGroupMasterBA.UpdateGeneralGroupMaster(model.GeneralGroupMasterDTO);
                            model.GeneralGroupMasterDTO.ErrorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                        }
                    }
                    return Json(model.GeneralGroupMasterDTO.ErrorMessage, JsonRequestBehavior.AllowGet);
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
        public ActionResult CreateGroupDetails(int ID)
        {
            //GeneralGroupMasterViewModel model = new GeneralGroupMasterViewModel();

            List<SelectListItem> GeneralGroupMaster_GroupDependentObject = new List<SelectListItem>();
            ViewBag.GeneralGroupMaster_GroupDependentObject = new SelectList(GeneralGroupMaster_GroupDependentObject, "Value", "Text");
            List<SelectListItem> li_GeneralGroupMaster_GroupDependentObject = new List<SelectListItem>();
            li_GeneralGroupMaster_GroupDependentObject.Add(new SelectListItem { Text = "-- Select Dependent Object -- ", });
            li_GeneralGroupMaster_GroupDependentObject.Add(new SelectListItem { Text = "Department", Value = "Department" });
            li_GeneralGroupMaster_GroupDependentObject.Add(new SelectListItem { Text = "Designation", Value = "Designation" });
            li_GeneralGroupMaster_GroupDependentObject.Add(new SelectListItem { Text = "PayScale", Value = "PayScale" });
           

            List<GeneralJobProfile> generalJobProfileList = GetListGeneralJobProfile();
            List<SelectListItem> generalJobProfile = new List<SelectListItem>();
            foreach (GeneralJobProfile item in generalJobProfileList)
            {
                generalJobProfile.Add(new SelectListItem { Text = item.JobProfileDescription, Value = item.ID.ToString() });
            }
          

            model.GeneralGroupMasterDTO = new GeneralGroupMaster();
            model.GeneralGroupMasterDTO.ID = ID;
            model.GeneralGroupMasterDTO.ConnectionString = _connectioString;

            IBaseEntityResponse<GeneralGroupMaster> response = _IGeneralGroupMasterBA.SelectByID(model.GeneralGroupMasterDTO);

            if (response != null && response.Entity != null)
            {
                model.GeneralGroupMasterDTO.ID = response.Entity.ID;             
                model.GeneralGroupMasterDTO.GroupName = response.Entity.GroupName;
                model.GeneralGroupMasterDTO.GroupDependentObject = response.Entity.GroupDependentObject;
            }

            List<SelectListItem> organisationStudyCentreMaster = new List<SelectListItem>();
            List<SelectListItem> organisationDepartmentMaster = new List<SelectListItem>();
            List<SelectListItem> empDesignationMaster = new List<SelectListItem>();           
            List<SelectListItem> payScaleMaster = new List<SelectListItem>();
             if (model.GeneralGroupMasterDTO.GroupDependentObject == "Department")                             
            {
                List<OrganisationStudyCentreMaster> centreList = GetListOrgStudyCentreMaster();                                      //-------------Centre List-----------//
                foreach (OrganisationStudyCentreMaster item in centreList)
                {
                    organisationStudyCentreMaster.Add(new SelectListItem { Text = item.CentreName, Value = item.CentreCode.ToString() });
                }

                List<OrganisationDepartmentMaster> departmentList = GetListOrganisationDepartmentMaster(string.Empty);               //-------------Department List-------------//
                foreach (OrganisationDepartmentMaster item in departmentList)
                {
                    organisationDepartmentMaster.Add(new SelectListItem { Text = item.DepartmentName, Value = item.ID.ToString() });
                }
            }
             else if (model.GeneralGroupMasterDTO.GroupDependentObject == "Designation")                                             //-------------Designation List-------------//
            {
                List<EmpDesignationMaster> designationList = GetListEmpDesignationMaster();             
                foreach (EmpDesignationMaster item in designationList)
                {
                    empDesignationMaster.Add(new SelectListItem { Text = item.Description, Value = item.ID.ToString() });
                }
            }

             else if (model.GeneralGroupMasterDTO.GroupDependentObject == "PayScale")                                                //-------------Department List-------------//
            {
                List<OrganisationDepartmentMaster> payScaleList = GetOrganisationDepartmentList();
                foreach (OrganisationDepartmentMaster item in payScaleList)
                {
                    payScaleMaster.Add(new SelectListItem { Text = item.DepartmentName, Value = item.ID.ToString() });
                }
            }

            ViewData["GroupDependentObject"] = new SelectList(li_GeneralGroupMaster_GroupDependentObject, "Value", "Text", model.GroupDependentObject);
            ViewBag.generalJobProfileList = new SelectList(generalJobProfile, "Value", "Text");
            ViewBag.centreList = new SelectList(organisationStudyCentreMaster, "Value", "Text"); 
            ViewBag.departmentList = new SelectList(organisationDepartmentMaster, "Value", "Text");
            ViewBag.designationList = new SelectList(empDesignationMaster, "Value", "Text");          
            ViewBag.payScaleList = new SelectList(organisationDepartmentMaster, "Value", "Text");
            
            return PartialView("/Views/GeneralMaster/GeneralGroupMaster/CreateGroupDetails.cshtml", model);
        }
        
        [HttpPost]
        public ActionResult CreateGroupDetails(GeneralGroupMasterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.GeneralGroupMasterDTO != null)
                    {
                        model.GeneralGroupMasterDTO.ConnectionString = _connectioString;
                        model.GeneralGroupMasterDTO.DependentObjectID = model.DependentObjectID;
                        model.GeneralGroupMasterDTO.ID = model.ID;                       
                        model.GeneralGroupMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]); ;
                        IBaseEntityResponse<GeneralGroupMaster> response = _IGeneralGroupMasterBA.InsertGroupDetails(model.GeneralGroupMasterDTO);
                        model.GeneralGroupMasterDTO.ErrorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    }
                    return Json(model.GeneralGroupMasterDTO.ErrorMessage, JsonRequestBehavior.AllowGet);
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
        public ActionResult DropdownList(int ID, int DependentObjectID, string EmployeeGroupDetailsID, string mode)
        {
            //GeneralGroupMasterViewModel model = new GeneralGroupMasterViewModel();

            model.GeneralGroupMasterDTO = new GeneralGroupMaster();
            model.GeneralGroupMasterDTO.ID = Convert.ToInt32(ID);            
            model.GeneralGroupMasterDTO.ConnectionString = _connectioString;

            IBaseEntityResponse<GeneralGroupMaster> response = _IGeneralGroupMasterBA.SelectEmployeeGroupDetailsByID(model.GeneralGroupMasterDTO);

            if (response != null && response.Entity != null)
            {
                model.GeneralGroupMasterDTO.ID = response.Entity.ID;
                model.GeneralGroupMasterDTO.GroupName = response.Entity.GroupName;
                model.GeneralGroupMasterDTO.IsActive = response.Entity.IsActive;
                model.GeneralGroupMasterDTO.GroupDependentObject = response.Entity.GroupDependentObject;
            }

            List<SelectListItem> organisationStudyCentreMaster = new List<SelectListItem>();
            List<SelectListItem> organisationDepartmentMaster = new List<SelectListItem>();
            List<SelectListItem> empDesignationMaster = new List<SelectListItem>();
            List<SelectListItem> payScaleMaster = new List<SelectListItem>();
            if (model.GeneralGroupMasterDTO.GroupDependentObject == "Department")
            {
                List<OrganisationStudyCentreMaster> centreList = GetListOrgStudyCentreMaster();                                      //-------------Centre List-----------//
                foreach (OrganisationStudyCentreMaster item in centreList)
                {
                    organisationStudyCentreMaster.Add(new SelectListItem { Text = item.CentreName, Value = item.CentreCode.ToString() });
                }

                List<OrganisationDepartmentMaster> departmentList = GetListOrganisationDepartmentMaster(string.Empty);               //-------------Department List-------------//
                foreach (OrganisationDepartmentMaster item in departmentList)
                {
                    organisationDepartmentMaster.Add(new SelectListItem { Text = item.DepartmentName, Value = item.CentrewiseDepartmentID.ToString() });
                }
            }
            else if (model.GeneralGroupMasterDTO.GroupDependentObject == "Designation")                                             //-------------Designation List-------------//
            {
                List<EmpDesignationMaster> designationList = GetListEmpDesignationMaster();
                foreach (EmpDesignationMaster item in designationList)
                {
                    empDesignationMaster.Add(new SelectListItem { Text = item.Description, Value = item.ID.ToString() });
                }
            }

            else if (model.GeneralGroupMasterDTO.GroupDependentObject == "PayScale")                                                //-------------Department List-------------//
            {
                List<OrganisationDepartmentMaster> payScaleList = GetOrganisationDepartmentList();
                foreach (OrganisationDepartmentMaster item in payScaleList)
                {
                    payScaleMaster.Add(new SelectListItem { Text = item.DepartmentName, Value = item.ID.ToString() });
                }
            }
            ViewBag.centreList = new SelectList(organisationStudyCentreMaster, "Value", "Text");
            ViewBag.departmentList = new SelectList(organisationDepartmentMaster, "Value", "Text", DependentObjectID);
            ViewBag.designationList = new SelectList(empDesignationMaster, "Value", "Text", DependentObjectID);
            ViewBag.payScaleList = new SelectList(organisationDepartmentMaster, "Value", "Text", DependentObjectID);
            model.GeneralGroupMasterDTO.DependentObjectID = DependentObjectID;
            model.GeneralGroupMasterDTO.EmployeeGroupDetailsID = Convert.ToInt32(EmployeeGroupDetailsID);
         
            ViewBag.mode = mode;
            return View("/Views/GeneralMaster/GeneralGroupMaster/DropdownList.cshtml", model);
            
        }

        [HttpPost]
        public ActionResult EditGroupDetails(GeneralGroupMasterViewModel model)
        {
            //GeneralGroupMasterViewModel model = new GeneralGroupMasterViewModel();
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.GeneralGroupMasterDTO != null)
                    {
                        model.GeneralGroupMasterDTO.ConnectionString = _connectioString;                        
                        model.GeneralGroupMasterDTO.ID = model.ID;                          //ID as GroupMasterID
                        model.GeneralGroupMasterDTO.DependentObjectID = model.DependentObjectID;
                        model.GeneralGroupMasterDTO.IsActive = model.IsActive;
                        model.GeneralGroupMasterDTO.EmployeeGroupDetailsID = model.EmployeeGroupDetailsID;
                        model.GeneralGroupMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]); ;
                        IBaseEntityResponse<GeneralGroupMaster> response = _IGeneralGroupMasterBA.UpdateGroupDetails(model.GeneralGroupMasterDTO);
                        model.GeneralGroupMasterDTO.ErrorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                    }
                    return Json(model.GeneralGroupMasterDTO.ErrorMessage, JsonRequestBehavior.AllowGet);
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
        public ActionResult Delete(int ID)
        {
            //GeneralGroupMasterViewModel model = new GeneralGroupMasterViewModel();
            model.GeneralGroupMasterDTO = new GeneralGroupMaster();
            model.GeneralGroupMasterDTO.ID = ID;
            return PartialView("/Views/GeneralMaster/GeneralGroupMaster/Delete.cshtml",model);
        }

        [HttpPost]
        public ActionResult Delete(GeneralGroupMasterViewModel model)
        {
            try
            {

                if (model.ID > 0)
                {
                    if (model != null && model.GeneralGroupMasterDTO != null)
                    {
                        GeneralGroupMaster GeneralGroupMasterDTO = new GeneralGroupMaster();
                        GeneralGroupMasterDTO.ConnectionString = _connectioString;
                        GeneralGroupMasterDTO.ID = model.ID;
                        GeneralGroupMasterDTO.JobProfileID = model.JobProfileID;
                        GeneralGroupMasterDTO.DeletedBy = model.DeletedBy;
                        GeneralGroupMasterDTO.GroupName = model.GroupName;
                        GeneralGroupMasterDTO.GroupDependentObject = model.GroupDependentObject;
                        GeneralGroupMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<GeneralGroupMaster> response = _IGeneralGroupMasterBA.DeleteGeneralGroupMaster(GeneralGroupMasterDTO);
                        model.GeneralGroupMasterDTO.ErrorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
                    }
                    return Json(model.GeneralGroupMasterDTO.ErrorMessage, JsonRequestBehavior.AllowGet);
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

        // Non-Action Methods
        #region Methods
        public IEnumerable<GeneralGroupMasterViewModel> GetGeneralGroupMasterDetails(out int TotalRecords)
        {
            GeneralGroupMasterSearchRequest searchRequest = new GeneralGroupMasterSearchRequest();
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
                searchRequest.SortBy = _sortBy;                        // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;
            }
            List<GeneralGroupMasterViewModel> listGeneralGroupMasterViewModel = new List<GeneralGroupMasterViewModel>();
            List<GeneralGroupMaster> listGeneralGroupMaster = new List<GeneralGroupMaster>();
            IBaseEntityCollectionResponse<GeneralGroupMaster> baseEntityCollectionResponse = _IGeneralGroupMasterBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralGroupMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (GeneralGroupMaster item in listGeneralGroupMaster)
                    {
                        GeneralGroupMasterViewModel _GeneralGroupMasterViewModel = new GeneralGroupMasterViewModel();
                        _GeneralGroupMasterViewModel.GeneralGroupMasterDTO = item;
                        listGeneralGroupMasterViewModel.Add(_GeneralGroupMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listGeneralGroupMasterViewModel;
        }

        public IEnumerable<GeneralGroupMasterViewModel> GetEmployeeGroupDetails(out int TotalRecords, string GroupID, string GroupDependentObject)
        {
            GeneralGroupMasterSearchRequest searchRequest = new GeneralGroupMasterSearchRequest();
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
                    searchRequest.ID = Convert.ToInt32(GroupID);
                    searchRequest.GroupDependentObject = GroupDependentObject;
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "A.ModifiedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                    searchRequest.ID = Convert.ToInt32(GroupID);
                    searchRequest.GroupDependentObject = GroupDependentObject;
                }
            }
            else
            {
                searchRequest.SortBy = _sortBy;                        // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;
                searchRequest.ID = Convert.ToInt32(GroupID);
                searchRequest.GroupDependentObject = GroupDependentObject;
            }
            List<GeneralGroupMasterViewModel> listGroupDetailsViewModel = new List<GeneralGroupMasterViewModel>();
            List<GeneralGroupMaster> listGroupDetails = new List<GeneralGroupMaster>();
            IBaseEntityCollectionResponse<GeneralGroupMaster> baseEntityCollectionResponse = _IGeneralGroupMasterBA.EmployeeGroupDetailsGetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGroupDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (GeneralGroupMaster item in listGroupDetails)
                    {
                        GeneralGroupMasterViewModel _GeneralGroupMasterViewModel = new GeneralGroupMasterViewModel();
                        _GeneralGroupMasterViewModel.GeneralGroupMasterDTO = item;
                        listGroupDetailsViewModel.Add(_GeneralGroupMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listGroupDetailsViewModel;
        }
        #endregion

        // AjaxHandler Methods
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<GeneralGroupMasterViewModel> filteredGeneralGroupMaster;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "GroupName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "GroupName Like '%" + param.sSearch + "%' or GroupDependentObject Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "GroupDependentObject";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "GroupName Like '%" + param.sSearch + "%' or GroupDependentObject Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            filteredGeneralGroupMaster = GetGeneralGroupMasterDetails(out TotalRecords);
            var records = filteredGeneralGroupMaster.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.GroupName), Convert.ToString(c.GroupDependentObject), Convert.ToString(c.JobProfileDescription), Convert.ToString(c.ID) };

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region AjaxHandlerEmployeeGroupDetails
        public ActionResult AjaxHandlerEmployeeGroupDetails(JQueryDataTableParamModel param, string GroupID, string GroupDependentObject)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<GeneralGroupMasterViewModel> filteredEmployeeGroupDetails;
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
                        _searchBy = "DepartmentName Like '%" + param.sSearch + "%' or Designation Like '%" + param.sSearch + "%' or PayScale Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "A.ID";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "DepartmentName Like '%" + param.sSearch + "%' or Designation Like '%" + param.sSearch + "%' or PayScale Like '%" + param.sSearch + "%'";    //this "if" block is added for search functionality
                    }
                    break;
                case 2:
                    _sortBy = "A.ID";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "DepartmentName Like '%" + param.sSearch + "%' or Designation Like '%" + param.sSearch + "%' or PayScale Like '%" + param.sSearch + "%'";     //this "if" block is added for search functionality
                    }
                    break;
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            filteredEmployeeGroupDetails = GetEmployeeGroupDetails(out TotalRecords, GroupID, GroupDependentObject);
            var records = filteredEmployeeGroupDetails.Skip(0).Take(param.iDisplayLength);
          
            if (GroupDependentObject == "Department")
            {
                var result = from c in records select new[] { Convert.ToString(c.Department), Convert.ToString(c.DependentObjectID), Convert.ToString(c.EmployeeGroupDetailsID), Convert.ToString(c.ID),Convert.ToString(c.IsActive) };
                return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
            }
            else if (GroupDependentObject == "Designation")
            {
                var result = from c in records select new[] { Convert.ToString(c.Designation), Convert.ToString(c.DependentObjectID), Convert.ToString(c.EmployeeGroupDetailsID), Convert.ToString(c.ID), Convert.ToString(c.IsActive) };
                 return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
            }
            else if (GroupDependentObject == "PayScale")
            {
                var result = from c in records select new[] { Convert.ToString(c.PayScale), Convert.ToString(c.DependentObjectID), Convert.ToString(c.EmployeeGroupDetailsID), Convert.ToString(c.ID), Convert.ToString(c.IsActive) };
                return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var result = from c in records select new[] { Convert.ToString(c.Department), Convert.ToString(c.Designation), Convert.ToString(c.PayScale), Convert.ToString(c.EmployeeGroupDetailsID), Convert.ToString(c.ID), Convert.ToString(c.IsActive) };
                return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
            }
           
        }
        #endregion

    }
}


