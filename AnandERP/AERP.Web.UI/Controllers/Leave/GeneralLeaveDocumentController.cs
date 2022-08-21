using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Configuration;
using AERP.ExceptionManager;
using AERP.DTO;
using AERP.ViewModel;
using AERP.Common;
using AERP.Base.DTO;
using AERP.Business.BusinessAction;

namespace AERP.Web.UI.Controllers
{
    public class GeneralLeaveDocumentController : BaseController
    {
        IGeneralLeaveDocumentBA _IGeneralLeaveDocumentBA = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public GeneralLeaveDocumentController()
        {
            _IGeneralLeaveDocumentBA = new GeneralLeaveDocumentBA();
        }

        //  Controller Methods
        #region ------------------Controller Methods------------------

        public ActionResult Index()
        {
            if (Convert.ToString(Session["UserType"]) == "A" || Convert.ToInt32(Session["SuperUser"]) > 0)
            {
                return View("/Views/Leave/GeneralLeaveDocument/Index.cshtml");
            }
            else
            {
                int AdminRoleMasterID = 0;
                if (Session["RoleID"] == null)
                {
                    AdminRoleMasterID = Convert.ToInt32(Session["DefaultRoleID"]);
                }
                else
                {
                    AdminRoleMasterID = Convert.ToInt32(Session["RoleID"]);
                }
                List<AdminRoleApplicableDetails> listAdminRoleApplicableDetails = GetAdminRoleApplicableCentreByHRManager(AdminRoleMasterID);
                if (listAdminRoleApplicableDetails.Count > 0)
                {
                    return View("/Views/Leave/GeneralLeaveDocument/Index.cshtml");
                }
                else
                {
                    return RedirectToAction("UnauthorizedAccess", "Home");
                }
            }
        }

        public ActionResult List(string actionMode)
        {
            try
            {
                IGeneralLeaveDocumentViewModel _generalLeaveDocumentViewModel = new GeneralLeaveDocumentViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Leave/GeneralLeaveDocument/List.cshtml", _generalLeaveDocumentViewModel);
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
                IGeneralLeaveDocumentViewModel _generalLeaveDocumentViewModel = new GeneralLeaveDocumentViewModel();

                //For Document Type
                List<SelectListItem> GeneralLeaveDocument_DocumentType = new List<SelectListItem>();
                ViewBag.GeneralLeaveDocument_DocumentType = new SelectList(GeneralLeaveDocument_DocumentType, "Value", "Text");
                List<SelectListItem> li_GeneralLeaveDocument_DocumentType = new List<SelectListItem>();
                //li_GeneralLeaveDocument_DocumentType.Add(new SelectListItem { Text = "-- Select Document Type -- ", Value = "" });
                li_GeneralLeaveDocument_DocumentType.Add(new SelectListItem { Text = Resources.DropdownMessage_Application      , Value = "Application" });
                li_GeneralLeaveDocument_DocumentType.Add(new SelectListItem { Text = Resources.DropdownMessage_Certificate    , Value = "Certificate" });
                li_GeneralLeaveDocument_DocumentType.Add(new SelectListItem { Text = Resources.DropdownMessage_Document      , Value = "Document" });
                li_GeneralLeaveDocument_DocumentType.Add(new SelectListItem { Text = Resources.DropdownMessage_ExamSchedule     , Value = "ExamSchedule" });
                li_GeneralLeaveDocument_DocumentType.Add(new SelectListItem { Text = Resources.DropdownMessage_Letter        , Value = "Letter" });
                li_GeneralLeaveDocument_DocumentType.Add(new SelectListItem { Text = Resources.DropdownMessage_Undertaking   , Value = "Undertaking" });

                ViewData["DocumentType"] = li_GeneralLeaveDocument_DocumentType;

                return View("/Views/Leave/GeneralLeaveDocument/Create.cshtml", _generalLeaveDocumentViewModel);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public ActionResult Create(GeneralLeaveDocumentViewModel _generalLeaveDocumentViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _generalLeaveDocumentViewModel.GeneralLeaveDocumentDTO.DocumentName = _generalLeaveDocumentViewModel.DocumentName;
                    _generalLeaveDocumentViewModel.GeneralLeaveDocumentDTO.DocumentType = _generalLeaveDocumentViewModel.DocumentType;
                    _generalLeaveDocumentViewModel.GeneralLeaveDocumentDTO.DocumentDescription = _generalLeaveDocumentViewModel.DocumentDescription;
                    _generalLeaveDocumentViewModel.GeneralLeaveDocumentDTO.CreatedBy = Convert.ToInt32(Session["UserId"]);
                    _generalLeaveDocumentViewModel.GeneralLeaveDocumentDTO.ConnectionString = _connectioString;
                    IBaseEntityResponse<GeneralLeaveDocument> response = _IGeneralLeaveDocumentBA.InsertGeneralLeaveDocument(_generalLeaveDocumentViewModel.GeneralLeaveDocumentDTO);
                    _generalLeaveDocumentViewModel.GeneralLeaveDocumentDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(_generalLeaveDocumentViewModel.GeneralLeaveDocumentDTO.errorMessage, JsonRequestBehavior.AllowGet);

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
            //return Redirect("/EmployeeInformation/PersonalInformationHome/" + _GeneralLeaveDocumentViewModel);
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            IGeneralLeaveDocumentViewModel _generalLeaveDocumentViewModel = new GeneralLeaveDocumentViewModel();
            try
            {

                //For Document Type
                List<SelectListItem> GeneralLeaveDocument_DocumentType = new List<SelectListItem>();
                ViewBag.GeneralLeaveDocument_DocumentType = new SelectList(GeneralLeaveDocument_DocumentType, "Value", "Text");
                List<SelectListItem> li_GeneralLeaveDocument_DocumentType = new List<SelectListItem>();
                //li_GeneralLeaveDocument_DocumentType.Add(new SelectListItem { Text = "-- Select Document Type -- ", Value = " " });
                li_GeneralLeaveDocument_DocumentType.Add(new SelectListItem { Text = Resources.DropdownMessage_Application, Value = "Application" });
                li_GeneralLeaveDocument_DocumentType.Add(new SelectListItem { Text = Resources.DropdownMessage_Certificate, Value = "Certificate" });
                li_GeneralLeaveDocument_DocumentType.Add(new SelectListItem { Text = Resources.DropdownMessage_Document, Value = "Document" });
                li_GeneralLeaveDocument_DocumentType.Add(new SelectListItem { Text = Resources.DropdownMessage_ExamSchedule, Value = "ExamSchedule" });
                li_GeneralLeaveDocument_DocumentType.Add(new SelectListItem { Text = Resources.DropdownMessage_Letter, Value = "Letter" });
                li_GeneralLeaveDocument_DocumentType.Add(new SelectListItem { Text = Resources.DropdownMessage_Undertaking, Value = "Undertaking" });


                _generalLeaveDocumentViewModel.GeneralLeaveDocumentDTO = new GeneralLeaveDocument();
                _generalLeaveDocumentViewModel.GeneralLeaveDocumentDTO.ID = id;
                _generalLeaveDocumentViewModel.GeneralLeaveDocumentDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<GeneralLeaveDocument> response = _IGeneralLeaveDocumentBA.SelectByID(_generalLeaveDocumentViewModel.GeneralLeaveDocumentDTO);
                if (response != null && response.Entity != null)
                {
                    _generalLeaveDocumentViewModel.GeneralLeaveDocumentDTO.ID = response.Entity.ID;
                    _generalLeaveDocumentViewModel.GeneralLeaveDocumentDTO.DocumentName = response.Entity.DocumentName;
                    _generalLeaveDocumentViewModel.GeneralLeaveDocumentDTO.DocumentType = response.Entity.DocumentType;
                    _generalLeaveDocumentViewModel.GeneralLeaveDocumentDTO.DocumentDescription = response.Entity.DocumentDescription;

                    ViewData["DocumentType"] = new SelectList(li_GeneralLeaveDocument_DocumentType, "Value", "Text", response.Entity.DocumentType);

                }
                return View("/Views/Leave/GeneralLeaveDocument/Edit.cshtml", _generalLeaveDocumentViewModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(GeneralLeaveDocumentViewModel _generalLeaveDocumentViewModel)
        {
            if (ModelState.IsValid)
            {
                if (_generalLeaveDocumentViewModel != null && _generalLeaveDocumentViewModel.GeneralLeaveDocumentDTO != null)
                {
                    _generalLeaveDocumentViewModel.GeneralLeaveDocumentDTO.DocumentName = _generalLeaveDocumentViewModel.DocumentName;
                    _generalLeaveDocumentViewModel.GeneralLeaveDocumentDTO.DocumentType = _generalLeaveDocumentViewModel.DocumentType;
                    _generalLeaveDocumentViewModel.GeneralLeaveDocumentDTO.DocumentDescription = _generalLeaveDocumentViewModel.DocumentDescription;
                    _generalLeaveDocumentViewModel.GeneralLeaveDocumentDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                    _generalLeaveDocumentViewModel.GeneralLeaveDocumentDTO.ConnectionString = _connectioString;

                    IBaseEntityResponse<GeneralLeaveDocument> response = _IGeneralLeaveDocumentBA.UpdateGeneralLeaveDocument(_generalLeaveDocumentViewModel.GeneralLeaveDocumentDTO);
                    _generalLeaveDocumentViewModel.GeneralLeaveDocumentDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                }
                return Json(_generalLeaveDocumentViewModel.GeneralLeaveDocumentDTO.errorMessage, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Please review your form");
            }
        }


        //[HttpGet]
        //public ActionResult Delete(int ID)
        //{
        //    IGeneralLeaveDocumentViewModel _generalLeaveDocumentViewModel = new GeneralLeaveDocumentViewModel();
        //    _generalLeaveDocumentViewModel.GeneralLeaveDocumentDTO = new GeneralLeaveDocument();
        //    _generalLeaveDocumentViewModel.GeneralLeaveDocumentDTO.ID = ID;
        //    return PartialView("/Views/Leave/GeneralLeaveDocument/Delete.cshtml", _generalLeaveDocumentViewModel);
        //}

        //[HttpPost]
        //public ActionResult Delete(GeneralLeaveDocumentViewModel _generalLeaveDocumentViewModel)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        if (_generalLeaveDocumentViewModel.ID > 0)
        //        {
        //            GeneralLeaveDocument GeneralLeaveDocumentDTO = new GeneralLeaveDocument();
        //            GeneralLeaveDocumentDTO.ConnectionString = _connectioString;
        //            GeneralLeaveDocumentDTO.ID = _generalLeaveDocumentViewModel.ID;
        //            GeneralLeaveDocumentDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
        //            IBaseEntityResponse<GeneralLeaveDocument> response = _generalLeaveDocumentServiceAccess.DeleteGeneralLeaveDocument(GeneralLeaveDocumentDTO);
        //            _generalLeaveDocumentViewModel.GeneralLeaveDocumentDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);

        //        }
        //        return Json(_generalLeaveDocumentViewModel.GeneralLeaveDocumentDTO.errorMessage, JsonRequestBehavior.AllowGet);
        //    }
        //    else
        //    {
        //        return Json("Please review your form");
        //    }
        //}

        public ActionResult Delete(int ID) {

            try { 
            
            
                    GeneralLeaveDocumentViewModel model = new GeneralLeaveDocumentViewModel();
                    GeneralLeaveDocument GeneralLeaveDocumentDTO = new GeneralLeaveDocument();
                    GeneralLeaveDocumentDTO.ConnectionString = _connectioString;
                    GeneralLeaveDocumentDTO.ID = ID;
                    GeneralLeaveDocumentDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<GeneralLeaveDocument> response = _IGeneralLeaveDocumentBA.DeleteGeneralLeaveDocument(GeneralLeaveDocumentDTO);
                    //_generalLeaveDocumentViewModel.GeneralLeaveDocumentDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
                    
                    model.GeneralLeaveDocumentDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
                    return Json(model.GeneralLeaveDocumentDTO.errorMessage, JsonRequestBehavior.AllowGet);
               
                //return Json(_generalLeaveDocumentViewModel.GeneralLeaveDocumentDTO.errorMessage, JsonRequestBehavior.AllowGet);
            }catch(Exception ex){
                _logException.Error(ex.Message);
                throw;
            }
            
        
        }
        #endregion

        // Non-Action Method
        #region ---------------------Methods-ddd----------------------

        public IEnumerable<GeneralLeaveDocumentViewModel> GetGeneralLeaveDocument(out int TotalRecords)
        {
            GeneralLeaveDocumentSearchRequest searchRequest = new GeneralLeaveDocumentSearchRequest();
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
            List<GeneralLeaveDocumentViewModel> listGeneralLeaveDocumentViewModel = new List<GeneralLeaveDocumentViewModel>();
            List<GeneralLeaveDocument> listGeneralLeaveDocument = new List<GeneralLeaveDocument>();
            IBaseEntityCollectionResponse<GeneralLeaveDocument> baseEntityCollectionResponse = _IGeneralLeaveDocumentBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralLeaveDocument = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (GeneralLeaveDocument item in listGeneralLeaveDocument)
                    {
                        GeneralLeaveDocumentViewModel GeneralLeaveDocumentViewModel = new GeneralLeaveDocumentViewModel();
                        GeneralLeaveDocumentViewModel.GeneralLeaveDocumentDTO = item;
                        listGeneralLeaveDocumentViewModel.Add(GeneralLeaveDocumentViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listGeneralLeaveDocumentViewModel;
        }
        #endregion

        // AjaxHandler Method
        #region ----------------------AjaxHandler---------------------
        public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<GeneralLeaveDocumentViewModel> filteredGeneralLeaveDocument;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "DocumentName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "DocumentType Like '%" + param.sSearch + "%' or DocumentName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "DocumentType";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "DocumentType Like '%" + param.sSearch + "%' or DocumentName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;


            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            filteredGeneralLeaveDocument = GetGeneralLeaveDocument(out TotalRecords);
            var records = filteredGeneralLeaveDocument.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.DocumentName), Convert.ToString(c.DocumentType), Convert.ToString(c.ID) };

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);

        }
        #endregion
    }
}
