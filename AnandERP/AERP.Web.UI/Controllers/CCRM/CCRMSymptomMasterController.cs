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
    public class CCRMSymptomMasterController : BaseController
    {
        ICCRMSymptomMasterBA _CCRMSymptomMasterBA = null;
        //IEmpEmployeeMasterBA _empEmployeeMasterBA = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public CCRMSymptomMasterController()
        {
            _CCRMSymptomMasterBA = new CCRMSymptomMasterBA();
            //_empEmployeeMasterBA = new EmpEmployeeMasterBA();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
            if (Convert.ToInt32(Session["Store Manager"]) > 0 || Convert.ToString(Session["UserType"]) == "A")
            {
                return View("/Views/CCRM/CCRMSymptomMaster/Index.cshtml");
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
                CCRMSymptomMasterViewModel model = new CCRMSymptomMasterViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/CCRM/CCRMSymptomMaster/List.cshtml", model);
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
            CCRMSymptomMasterViewModel model = new CCRMSymptomMasterViewModel();
            return PartialView("/Views/CCRM/CCRMSymptomMaster/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(CCRMSymptomMasterViewModel model)
        {
            try
            {
                //if (ModelState.IsValid)
                // {
                if (model != null && model.CCRMSymptomMasterDTO != null)
                {
                    model.CCRMSymptomMasterDTO.ConnectionString = _connectioString;
                    model.CCRMSymptomMasterDTO.SymptomTypeTitle = model.SymptomTypeTitle;
                    model.CCRMSymptomMasterDTO.SymptomTypeCode = model.SymptomTypeCode;
                    model.CCRMSymptomMasterDTO.SymptomTypeDescription = model.SymptomTypeDescription;
                    model.CCRMSymptomMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<CCRMSymptomMaster> response = _CCRMSymptomMasterBA.InsertCCRMSymptomType(model.CCRMSymptomMasterDTO);

                    model.CCRMSymptomMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.CCRMSymptomMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public ActionResult CreateCCRMSymptomMaster(string IDs)
        {
            CCRMSymptomMasterViewModel model = new CCRMSymptomMasterViewModel();
            string[] IDsArray = IDs.Split('~');
            model.ID = Convert.ToInt32(IDsArray[0]);
            model.SymptomTypeTitle = IDsArray[1];
            model.SymptomTypeCode = IDsArray[2];
            
            return PartialView("/Views/CCRM/CCRMSymptomMaster/CreateCCRMSymptomMaster.cshtml", model);
        }
        [HttpPost]
        public ActionResult CreateCCRMSymptomMaster(CCRMSymptomMasterViewModel model)
        {
            try
            {
                //if (ModelState.IsValid)
                // {
                if (model != null && model.CCRMSymptomMasterDTO != null)
                {
                    model.CCRMSymptomMasterDTO.ConnectionString = _connectioString;
                    model.CCRMSymptomMasterDTO.SymptomTitle = model.SymptomTitle;
                    model.CCRMSymptomMasterDTO.SymptomCode = model.SymptomCode;
                    model.CCRMSymptomMasterDTO.SymptomDescription = model.SymptomDescription;
                    model.CCRMSymptomMasterDTO.ID = model.ID;
                    model.CCRMSymptomMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<CCRMSymptomMaster> response = _CCRMSymptomMasterBA.InsertCCRMSymptomMaster(model.CCRMSymptomMasterDTO);

                    model.CCRMSymptomMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.CCRMSymptomMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public ActionResult Edit(Int32 id)
        {
            CCRMSymptomMasterViewModel model = new CCRMSymptomMasterViewModel();
            try
            {



                model.CCRMSymptomMasterDTO = new CCRMSymptomMaster();
                model.CCRMSymptomMasterDTO.ID = id;
                model.CCRMSymptomMasterDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<CCRMSymptomMaster> response = _CCRMSymptomMasterBA.SelectByID(model.CCRMSymptomMasterDTO);
                if (response != null && response.Entity != null)
                {
                    model.CCRMSymptomMasterDTO.ID = response.Entity.ID;
                    model.CCRMSymptomMasterDTO.SymptomTypeTitle = response.Entity.SymptomTypeTitle;
                    model.CCRMSymptomMasterDTO.SymptomTypeCode = response.Entity.SymptomTypeCode;
                    model.CCRMSymptomMasterDTO.SymptomTypeDescription = response.Entity.SymptomTypeDescription;
                }

                return PartialView("/Views/CCRM/CCRMSymptomMaster/Edit.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPost]
        public ActionResult Edit(CCRMSymptomMasterViewModel model)
        {
            try
            {
                
                    if (model != null && model.CCRMSymptomMasterDTO != null)
                    {
                        if (model != null && model.CCRMSymptomMasterDTO != null)
                        {
                            model.CCRMSymptomMasterDTO.ConnectionString = _connectioString;
                            model.CCRMSymptomMasterDTO.SymptomTypeTitle = model.SymptomTypeTitle;
                            model.CCRMSymptomMasterDTO.SymptomTypeCode = model.SymptomTypeCode;
                            model.CCRMSymptomMasterDTO.SymptomTypeDescription = model.SymptomTypeDescription;
                            model.CCRMSymptomMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                            IBaseEntityResponse<CCRMSymptomMaster> response = _CCRMSymptomMasterBA.UpdateCCRMSymptomType(model.CCRMSymptomMasterDTO);
                            model.CCRMSymptomMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                        }
                    }
                    return Json(model.CCRMSymptomMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
                }
              
            
            catch (Exception)
            {
                throw;
            }
        }



        public ActionResult Delete(int CCRMSymptomMasterID)
        {
            var errorMessage = string.Empty;
            if (CCRMSymptomMasterID > 0)
            {
                IBaseEntityResponse<CCRMSymptomMaster> response = null;
                CCRMSymptomMaster CCRMSymptomMasterDTO = new CCRMSymptomMaster();
                CCRMSymptomMasterDTO.ConnectionString = _connectioString;
                CCRMSymptomMasterDTO.CCRMSymptomMasterID = Convert.ToInt32(CCRMSymptomMasterID);
                CCRMSymptomMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                response = _CCRMSymptomMasterBA.DeleteCCRMSymptomMaster(CCRMSymptomMasterDTO);
                errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
            }

            return Json(errorMessage, JsonRequestBehavior.AllowGet);
        }


        #endregion

        // Non-Action Method
        #region Methods

       
        public IEnumerable<CCRMSymptomMasterViewModel> GetCCRMSymptomMaster(out int TotalRecords)
        {
            CCRMSymptomMasterSearchRequest searchRequest = new CCRMSymptomMasterSearchRequest();
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
            List<CCRMSymptomMasterViewModel> listCCRMSymptomMasterViewModel = new List<CCRMSymptomMasterViewModel>();
            List<CCRMSymptomMaster> listCCRMSymptomMaster = new List<CCRMSymptomMaster>();
            IBaseEntityCollectionResponse<CCRMSymptomMaster> baseEntityCollectionResponse = _CCRMSymptomMasterBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listCCRMSymptomMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (CCRMSymptomMaster item in listCCRMSymptomMaster)
                    {
                        CCRMSymptomMasterViewModel CCRMSymptomMasterViewModel = new CCRMSymptomMasterViewModel();
                        CCRMSymptomMasterViewModel.CCRMSymptomMasterDTO = item;
                        listCCRMSymptomMasterViewModel.Add(CCRMSymptomMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listCCRMSymptomMasterViewModel;
        }
        public JsonResult GetCCRMSymptomMasterSearchList(string term)
        {
            CCRMSymptomMasterSearchRequest searchRequest = new CCRMSymptomMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            searchRequest.SearchWord = term;
            List<CCRMSymptomMaster> listCCRMSymptomMaster = new List<CCRMSymptomMaster>();
            IBaseEntityCollectionResponse<CCRMSymptomMaster> baseEntityCollectionResponse = _CCRMSymptomMasterBA.GetCCRMSymptomMasterSearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listCCRMSymptomMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            var result = (from r in listCCRMSymptomMaster
                          select new
                          {
                              ID = r.ID,
                              SymptomTitle = r.SymptomTitle,
                              SymptomCode = r.SymptomCode,


                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
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

                IEnumerable<CCRMSymptomMasterViewModel> filteredGroupDescription;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "B.SymptomTitle";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {

                            _searchBy = string.Empty;
                        }
                        else
                        {

                            _searchBy = " B.SymptomTitle Like '%" + param.sSearch + "%' or B.SymptomCode Like '%" + param.sSearch + "%'or B.SymptomDescription Like '%" + param.sSearch + "%'or A.SymptomTypeTitle Like '%" + param.sSearch + "%'or A.SymptomTypeCode Like '%" + param.sSearch + "%'or A.SymptomTypeDescription Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;
                    case 1:
                        _sortBy = "B.SymptomCode";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "B.SymptomTitle Like '%" + param.sSearch + "%' or B.SymptomCode Like '%" + param.sSearch + "%'or B.SymptomDescription Like '%" + param.sSearch + "%'or A.SymptomTypeTitle Like '%" + param.sSearch + "%'or A.SymptomTypeCode Like '%" + param.sSearch + "%'or A.SymptomTypeDescription Like '%" + param.sSearch + "%'";
                        }
                        break;
                    case 2:
                        _sortBy = "B.SymptomDescription";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "B.SymptomTitle Like '%" + param.sSearch + "%' or B.SymptomCode Like '%" + param.sSearch + "%'or B.SymptomDescription Like '%" + param.sSearch + "%'or A.SymptomTypeTitle Like '%" + param.sSearch + "%'or A.SymptomTypeCode Like '%" + param.sSearch + "%'or A.SymptomTypeDescription Like '%" + param.sSearch + "%'";
                        }
                        break;

                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                filteredGroupDescription = GetCCRMSymptomMaster(out TotalRecords);


                var records = filteredGroupDescription.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { Convert.ToString(c.SymptomTitle), Convert.ToString(c.SymptomCode), Convert.ToString(c.SymptomDescription), Convert.ToString(c.ID), Convert.ToString(c.CCRMSymptomMasterID), Convert.ToString(c.SymptomTypeTitle+" - "+c.SymptomTypeCode), Convert.ToString(c.SymptomTypeCode), Convert.ToString(c.SymptomTypeDescription), Convert.ToString(c.SymptomTypeTitle) };

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