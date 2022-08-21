using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AERP.Base.DTO;
using AERP.DTO;
using AERP.Business.BusinessAction;
using AERP.ExceptionManager;
using AERP.ViewModel;
using System.Web.Mvc;
using System.Configuration;
namespace AERP.Web.UI.Controllers
{
    public class CCRMCallClosureController : BaseController
    {
        ICCRMCallClosureBA _CCRMCallClosureBA = null;
        ICCRMFeedbackMasterBA _CCRMFeedbackMasterBA = null;
        ICCRMBrokenCallReasonMasterBA _CCRMBrokenCallReasonMasterBA = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortOrder = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public CCRMCallClosureController()
        {
            _CCRMCallClosureBA = new CCRMCallClosureBA();
            _CCRMFeedbackMasterBA = new CCRMFeedbackMasterBA();
            _CCRMBrokenCallReasonMasterBA = new CCRMBrokenCallReasonMasterBA();
        }
        #region Controller Methods
        // GET: CCRMCallClosure
        public ActionResult Index()
        {
            if (Convert.ToString(Session["UserType"]) == "A" || Convert.ToInt32(Session["Admin Manager"]) > 0)
            {
                return View("/Views/CCRM/CCRMCallClosure/Index.cshtml");
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
                CCRMCallClosureViewModel model = new CCRMCallClosureViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/CCRM/CCRMCallClosure/List.cshtml", model);
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
            CCRMCallClosureViewModel model = new CCRMCallClosureViewModel();
            //*********************CCRMFeedbackMaster*********************//
            List<CCRMFeedbackMaster> CCRMFeedbackMaster = GetCCRMFeedbackMaster();
            List<SelectListItem> CCRMFeedbackMasterList = new List<SelectListItem>();
            foreach (CCRMFeedbackMaster item in CCRMFeedbackMaster)
            {
                CCRMFeedbackMasterList.Add(new SelectListItem { Text = item.FeedbackName, Value = Convert.ToString(item.ID) });
            }
            ViewBag.CCRMFeedbackMasterList = new SelectList(CCRMFeedbackMasterList, "Value", "Text", model.Feedback);
            //*********************CCRMFeedbackMaster*********************//

            
            List<SelectListItem> CallStatus = new List<SelectListItem>();
            ViewBag.CallStatus = new SelectList(CallStatus, "Value", "Text");
            List<SelectListItem> li_CallStatus = new List<SelectListItem>();

            if (model.CCRMCallClosureDTO.CallStatus > 0)
            {
                li_CallStatus.Add(new SelectListItem { Text = "Complete", Value = "1" });
                li_CallStatus.Add(new SelectListItem { Text = "Broken", Value = "2" });
                // li_LocationType.Add(new SelectListItem { Text = "None", Value = "3" });
                //ViewData["SerialAndBatchManagedBy"] = li_SerialAndBatchManagedBy;
                ViewData["CallStatus"] = new SelectList(li_CallStatus, "Value", "Text", (model.CCRMCallClosureDTO.CallStatus).ToString().Trim());
            }
            else
            {

                li_CallStatus.Add(new SelectListItem { Text = "Complete", Value = "1" });
                li_CallStatus.Add(new SelectListItem { Text = "Broken", Value = "2" });
                // li_LocationType.Add(new SelectListItem { Text = "None", Value = "3" });
                ViewData["CallStatus"] = li_CallStatus;
            }

            //******************************************//
            //*********************CCRMBrokenCallReasonMaster*********************//
            List<CCRMBrokenCallReasonMaster> CCRMBrokenCallReasonMaster = GetCCRMBrokenCallReasonMaster();
            List<SelectListItem> CCRMBrokenCallReasonMasterList = new List<SelectListItem>();
            foreach (CCRMBrokenCallReasonMaster item in CCRMBrokenCallReasonMaster)
            {
                CCRMBrokenCallReasonMasterList.Add(new SelectListItem { Text = item.ReasonCode, Value = Convert.ToString(item.ID) });
            }
            ViewBag.CCRMBrokenCallReasonMasterList = new SelectList(CCRMBrokenCallReasonMasterList, "Value", "Text", model.ReasonCode);
            //******************************************//
            List<SelectListItem> Requierd = new List<SelectListItem>();
            ViewBag.Requierd = new SelectList(Requierd, "Value", "Text");
            List<SelectListItem> li_Requierd = new List<SelectListItem>();

            if (model.CCRMCallClosureDTO.Requierd > 0)
            {
                li_Requierd.Add(new SelectListItem { Text = "Replaced", Value = "1" });
                li_Requierd.Add(new SelectListItem { Text = "Required", Value = "2" });
                li_Requierd.Add(new SelectListItem { Text = "Cancel", Value = "3" });
                li_Requierd.Add(new SelectListItem { Text = "Provision", Value = "4" });
                //ViewData["SerialAndBatchManagedBy"] = li_SerialAndBatchManagedBy;
                ViewData["Requierd"] = new SelectList(li_Requierd, "Value", "Text", (model.CCRMCallClosureDTO.Requierd).ToString().Trim());
            }
            else
            {

                li_Requierd.Add(new SelectListItem { Text = "Replaced", Value = "1" });
                li_Requierd.Add(new SelectListItem { Text = "Required", Value = "2" });
                li_Requierd.Add(new SelectListItem { Text = "Cancel", Value = "3" });
                li_Requierd.Add(new SelectListItem { Text = "Provision", Value = "4" });
                ViewData["Requierd"] = li_Requierd;
            }
            try
            {



                model.CCRMCallClosureDTO = new CCRMCallClosure();
                model.CCRMCallClosureDTO.ID = id;
                model.CCRMCallClosureDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<CCRMCallClosure> response = _CCRMCallClosureBA.SelectByID(model.CCRMCallClosureDTO);
                if (response != null && response.Entity != null)
                {
                    model.CCRMCallClosureDTO.ID = response.Entity.ID;
                    model.CCRMCallClosureDTO.CallTktNo = response.Entity.CallTktNo;
                    model.CCRMCallClosureDTO.CallDate = response.Entity.CallDate;
                    model.CCRMCallClosureDTO.MIFID = response.Entity.MIFID;
                    model.CCRMCallClosureDTO.MIFName = response.Entity.MIFName;
                    model.CCRMCallClosureDTO.SerialNo = response.Entity.SerialNo;
                    model.CCRMCallClosureDTO.ModelNo = response.Entity.ModelNo;
                    model.CCRMCallClosureDTO.SymptomID = response.Entity.SymptomID;
                    model.CCRMCallClosureDTO.SymptomTitle = response.Entity.SymptomTitle;
                    model.CCRMCallClosureDTO.CallerName = response.Entity.CallerName;
                    model.CCRMCallClosureDTO.CallerPh = response.Entity.CallerPh;
                    model.CCRMCallClosureDTO.EngineerID = response.Entity.EngineerID;
                    model.CCRMCallClosureDTO.ComPlaint = response.Entity.ComPlaint;
                    model.CCRMCallClosureDTO.CentreCode = response.Entity.CentreCode;
                    model.CCRMCallClosureDTO.AdminRoleMasterID = response.Entity.AdminRoleMasterID;
                    model.CCRMCallClosureDTO.RightName = response.Entity.RightName;
                    model.CCRMCallClosureDTO.EmployeeID = response.Entity.EmployeeID;
                    model.CCRMCallClosureDTO.EmployeeCode = response.Entity.EmployeeCode;
                    model.CCRMCallClosureDTO.EmployeeName = response.Entity.EmployeeName;
                    model.CCRMCallClosureDTO.ItemDescription = response.Entity.ItemDescription;
                    model.CCRMCallClosureDTO.ContractCode = response.Entity.ContractCode;
                    model.CCRMCallClosureDTO.AllotDate = response.Entity.AllotDate;
                    model.CCRMCallClosureDTO.AllotPeriod = response.Entity.AllotPeriod;
                    model.CCRMCallClosureDTO.A4Mono = response.Entity.A4Mono;
                    model.CCRMCallClosureDTO.A4Col = response.Entity.A4Col;
                    model.CCRMCallClosureDTO.A3Mono = response.Entity.A3Mono;
                    model.CCRMCallClosureDTO.A3Col = response.Entity.A3Col;
                    model.CCRMCallClosureDTO.ArrivalPeriod = response.Entity.ArrivalPeriod;
                    model.CCRMCallClosureDTO.CompletionPeriod = response.Entity.CompletionPeriod;
                    model.CCRMCallClosureDTO.ItemNumber = response.Entity.ItemNumber;
                    model.CCRMCallClosureDTO.ContractTypeID = response.Entity.ContractTypeID;
                }

                return PartialView("/Views/CCRM/CCRMCallClosure/Edit.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Editdata(CCRMCallClosureViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.CCRMCallClosureDTO != null)
                    {
                        if (model != null && model.CCRMCallClosureDTO != null)
                        {
                            model.CCRMCallClosureDTO.ConnectionString = _connectioString;
                            //model.CCRMCallClosureDTO.SRDate = model.SRDate;
                           // model.CCRMCallClosureDTO.CallCloseDate = model.CallCloseDate;
                            //model.CCRMCallClosureDTO.EngineerID = model.EngineerID;

                            //model.CCRMCallClosureDTO.EnggName = model.EnggName;
                           // model.CCRMCallClosureDTO.CallId = model.CallId;
                            model.CCRMCallClosureDTO.CallTktNo = model.CallTktNo;
                            //model.CCRMCallClosureDTO.CallDate = model.CallDate;
                            //model.CCRMCallClosureDTO.MIFName = model.MIFName;
                            //model.CCRMCallClosureDTO.MIFID = model.MIFID;
                            //model.CCRMCallClosureDTO.ModelNo = model.ModelNo;
                            //model.CCRMCallClosureDTO.SerialNo = model.SerialNo;
                            //model.CCRMCallClosureDTO.ContractType = model.ContractType;
                            //model.CCRMCallClosureDTO.ContractTypeID = model.ContractTypeID;
                            //model.CCRMCallClosureDTO.ComPlaint = model.ComPlaint;
                            // model.CCRMCallClosureDTO.DispDate = model.DispDate;
                            //model.CCRMCallClosureDTO.ArrivalDate = model.ArrivalDate;
                            //model.CCRMCallClosureDTO.CompletionDate = model.CompletionDate;
                            model.CCRMCallClosureDTO.ArrivalPeriod = model.ArrivalPeriod;
                            model.CCRMCallClosureDTO.CompletionPeriod = model.CompletionPeriod;
                            model.CCRMCallClosureDTO.CurrentReadA4Mono = model.CurrentReadA4Mono;
                            model.CCRMCallClosureDTO.CurrentReadA4Col = model.CurrentReadA4Col;
                            model.CCRMCallClosureDTO.CurrentReadA3Mono = model.CurrentReadA3Mono;
                            model.CCRMCallClosureDTO.CurrentReadA3Col = model.CurrentReadA3Col;
                            model.CCRMCallClosureDTO.CallStatus = model.CallStatus;
                          //  model.CCRMCallClosureDTO.ReasonID = model.ReasonID;
                            model.CCRMCallClosureDTO.ReasonCode = model.ReasonCode;
                            model.CCRMCallClosureDTO.SymptomID = model.SymptomID;
                            model.CCRMCallClosureDTO.SymptomCode = model.SymptomCode;
                            model.CCRMCallClosureDTO.CauseID = model.CauseID;
                            model.CCRMCallClosureDTO.CauseCode = model.CauseCode;
                            model.CCRMCallClosureDTO.ActionID = model.ActionID;
                            model.CCRMCallClosureDTO.ActionCode = model.ActionCode;
                            model.CCRMCallClosureDTO.Symptom = model.Symptom;
                            model.CCRMCallClosureDTO.CauseTitle = model.CauseTitle;
                            model.CCRMCallClosureDTO.ActionTitle = model.ActionTitle;
                            model.CCRMCallClosureDTO.SignedBy = model.SignedBy;
                            model.CCRMCallClosureDTO.PhoneNo = model.PhoneNo;
                            model.CCRMCallClosureDTO.Remarks = model.Remarks;
                            model.CCRMCallClosureDTO.FeedbackID = model.FeedbackID;
                            model.CCRMCallClosureDTO.Feedback = model.Feedback;
                            model.CCRMCallClosureDTO.SCNSubmitted = model.SCNSubmitted;
                            //model.CCRMCallClosureDTO.AllotDate = model.AllotDate;
                            //model.CCRMCallClosureDTO.AllotPeriod = model.AllotPeriod;
                            model.CCRMCallClosureDTO.SymptomDescrip = model.SymptomDescrip;
                            model.CCRMCallClosureDTO.CauseDescrip = model.CauseDescrip;
                            model.CCRMCallClosureDTO.ActionDescrip = model.ActionDescrip;
                            model.CCRMCallClosureDTO.JobstartDate = model.JobstartDate;
                            model.CCRMCallClosureDTO.JobEndDate = model.JobEndDate;
                          //  model.CCRMCallClosureDTO.JobPeriod = model.JobPeriod;
                            model.CCRMCallClosureDTO.XmlString = model.XmlString;
                            model.CCRMCallClosureDTO.ID = model.ID;
                            model.CCRMCallClosureDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                            IBaseEntityResponse<CCRMCallClosure> response = _CCRMCallClosureBA.UpdateCCRMCallClosure(model.CCRMCallClosureDTO);
                            model.CCRMCallClosureDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                        }
                    }
                    return Json(model.CCRMCallClosureDTO.errorMessage, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json("Please review your form");
                }

            }
            catch (Exception)
            {
                throw;
            }
        }
        public ActionResult Delete(Int32 ID)
        {
            CCRMCallClosureViewModel model = new CCRMCallClosureViewModel();
            try
            {
                if (ID > 0)
                {
                    if (ID > 0)
                    {
                        CCRMCallClosure CCRMCallClosureDTO = new CCRMCallClosure();
                        CCRMCallClosureDTO.ConnectionString = _connectioString;
                        CCRMCallClosureDTO.ID = ID;
                        CCRMCallClosureDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<CCRMCallClosure> response = _CCRMCallClosureBA.DeleteCCRMCallClosure(CCRMCallClosureDTO);
                        model.CCRMCallClosureDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
                    }
                    return Json(model.CCRMCallClosureDTO.errorMessage, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json("Please review your form");
                }

            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
        // Non-Action Method
        #region Methods
        public IEnumerable<CCRMCallClosureViewModel> GetCCRMCallClosure(out int TotalRecords)
        {
            CCRMCallClosureSearchRequest searchRequest = new CCRMCallClosureSearchRequest();
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
            List<CCRMCallClosureViewModel> listCCRMCallClosureViewModel = new List<CCRMCallClosureViewModel>();
            List<CCRMCallClosure> listCCRMCallClosure = new List<CCRMCallClosure>();
            IBaseEntityCollectionResponse<CCRMCallClosure> baseEntityCollectionResponse = _CCRMCallClosureBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listCCRMCallClosure = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (CCRMCallClosure item in listCCRMCallClosure)
                    {
                        CCRMCallClosureViewModel CCRMCallClosureViewModel = new CCRMCallClosureViewModel();
                        CCRMCallClosureViewModel.CCRMCallClosureDTO = item;
                        listCCRMCallClosureViewModel.Add(CCRMCallClosureViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listCCRMCallClosureViewModel;
        }
        protected List<CCRMFeedbackMaster> GetCCRMFeedbackMaster()
        {
            CCRMFeedbackMasterSearchRequest searchRequest = new CCRMFeedbackMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<CCRMFeedbackMaster> listCCRMFeedbackMaster = new List<CCRMFeedbackMaster>();
            IBaseEntityCollectionResponse<CCRMFeedbackMaster> baseEntityCollectionResponse = _CCRMFeedbackMasterBA.GetCCRMFeedbackMasterList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listCCRMFeedbackMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listCCRMFeedbackMaster;
        }
        protected List<CCRMBrokenCallReasonMaster> GetCCRMBrokenCallReasonMaster()
        {
            CCRMBrokenCallReasonMasterSearchRequest searchRequest = new CCRMBrokenCallReasonMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<CCRMBrokenCallReasonMaster> listCCRMBrokenCallReasonMaster = new List<CCRMBrokenCallReasonMaster>();
            IBaseEntityCollectionResponse<CCRMBrokenCallReasonMaster> baseEntityCollectionResponse = _CCRMBrokenCallReasonMasterBA.GetCCRMBrokenCallReasonMasterList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listCCRMBrokenCallReasonMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listCCRMBrokenCallReasonMaster;
        }
        #endregion
        // AjaxHandler Method
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc
            IEnumerable<CCRMCallClosureViewModel> filteredCCRMCallClosureViewModel;

            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "CallTktNo";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "CallTktNo Like '%" + param.sSearch + "%' or SerialNo Like '%" + param.sSearch + "%' or MIFName Like '%" + param.sSearch + "%'";
                        //_searchBy = "ID Like '%" + param.sSearch + "%' or FeedbackPoints Like '%" + param.sSearch + "%'";
                        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "SerialNo";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "CallTktNo Like '%" + param.sSearch + "%' or SerialNo Like '%" + param.sSearch + "%' or MIFName Like '%" + param.sSearch + "%'";
                        // _searchBy = "ID Like '%" + param.sSearch + "%' or FeedbackPoints Like '%" + param.sSearch + "%'";
                        //this "if" block is added for search functionality
                    }
                    break;
                case 2:
                    _sortBy = "MIFName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "CallTktNo Like '%" + param.sSearch + "%' or SerialNo Like '%" + param.sSearch + "%' or MIFName Like '%" + param.sSearch + "%'";
                        //_searchBy = "ID Like '%" + param.sSearch + "%' or FeedbackPoints Like '%" + param.sSearch + "%'";
                        //this "if" block is added for search functionality
                    }
                    break;


            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            filteredCCRMCallClosureViewModel = GetCCRMCallClosure(out TotalRecords);
            var records = filteredCCRMCallClosureViewModel.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.CallTktNo), Convert.ToString(c.ID), Convert.ToString(c.CallDate), Convert.ToString(c.SerialNo), Convert.ToString(c.ModelNo), Convert.ToString(c.MIFName), Convert.ToString(c.ItemDescription), Convert.ToString(c.CallTypeName), Convert.ToString(c.EmployeeName) };

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}