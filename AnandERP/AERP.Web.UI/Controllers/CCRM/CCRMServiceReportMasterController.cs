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
    public class CCRMServiceReportMasterController : BaseController
    {
        ICCRMServiceReportMasterBA _CCRMServiceReportMasterBA = null;
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

        public CCRMServiceReportMasterController()
        {
            _CCRMServiceReportMasterBA = new CCRMServiceReportMasterBA();
            _CCRMFeedbackMasterBA = new CCRMFeedbackMasterBA();
            _CCRMBrokenCallReasonMasterBA = new CCRMBrokenCallReasonMasterBA();
        }
        #region Controller Methods
        // GET: CCRMServiceReportMaster
        public ActionResult Index()
        {
            if (Convert.ToString(Session["UserType"]) == "A" || Convert.ToInt32(Session["Admin Manager"]) > 0)
            {
                return View("/Views/CCRM/CCRMServiceReportMaster/Index.cshtml");
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
                CCRMServiceReportMasterViewModel model = new CCRMServiceReportMasterViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/CCRM/CCRMServiceReportMaster/List.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }
        [HttpGet]
        public ActionResult Edit(Int32 id,string CCRMServiceReportMasterID)
        {
            CCRMServiceReportMasterViewModel model = new CCRMServiceReportMasterViewModel();
            CCRMServiceReportMasterSearchRequest searchRequest = new CCRMServiceReportMasterSearchRequest();
            //*********************CCRMFeedbackMaster*********************//
            List<CCRMFeedbackMaster> CCRMFeedbackMaster = GetCCRMFeedbackMaster();
            List<SelectListItem> CCRMFeedbackMasterList = new List<SelectListItem>();
            foreach (CCRMFeedbackMaster item in CCRMFeedbackMaster)
            {
                CCRMFeedbackMasterList.Add(new SelectListItem { Text = item.FeedbackName, Value = Convert.ToString(item.ID) });
            }
            ViewBag.CCRMFeedbackMasterList = new SelectList(CCRMFeedbackMasterList, "Value", "Text", model.Feedback);
            //*********************CCRMFeedbackMaster*********************//
            List<SelectListItem> li = new List<SelectListItem>();
            // li1.Add(new SelectListItem { Text = "--Select--", Value = " " });
            li.Add(new SelectListItem { Text = "Complete", Value = "1" });
            li.Add(new SelectListItem { Text = "Broken", Value = "2" });
            ViewData["CallStatus"] = li;

            //List<SelectListItem> CallStatus = new List<SelectListItem>();
            //ViewBag.CallStatus = new SelectList(CallStatus, "Value", "Text");
            //List<SelectListItem> li_CallStatus = new List<SelectListItem>();

            //if (model.CCRMServiceReportMasterDTO.CallStatus > 0)
            //{
            //    li_CallStatus.Add(new SelectListItem { Text = "Complete", Value = "1" });
            //    li_CallStatus.Add(new SelectListItem { Text = "Broken", Value = "2" });
            //    // li_LocationType.Add(new SelectListItem { Text = "None", Value = "3" });
            //    //ViewData["SerialAndBatchManagedBy"] = li_SerialAndBatchManagedBy;
            //    ViewData["CallStatus"] = new SelectList(li_CallStatus, "Value", "Text", (model.CCRMServiceReportMasterDTO.CallStatus).ToString().Trim());
            //}
            //else
            //{

            //    li_CallStatus.Add(new SelectListItem { Text = "Complete", Value = "1" });
            //    li_CallStatus.Add(new SelectListItem { Text = "Broken", Value = "2" });
            //    // li_LocationType.Add(new SelectListItem { Text = "None", Value = "3" });
            //    ViewData["CallStatus"] = li_CallStatus;
            //}

            //******************************************//
            //*********************CCRMBrokenCallReasonMaster*********************//
           
           
            //*********************EmployeeSrviveEngg*********************//
            List<EmpEmployeeMaster> EmpEmployeeMaster = GetEmpEmployeeMasterService();
            List<SelectListItem> EmpEmployeeMasterList = new List<SelectListItem>();
            foreach (EmpEmployeeMaster item in EmpEmployeeMaster)
            {
                EmpEmployeeMasterList.Add(new SelectListItem { Text = item.EmployeeName, Value = Convert.ToString(item.EmployeeID) });
            }
            ViewBag.EmpEmployeeMasterList = new SelectList(EmpEmployeeMasterList, "Value", "Text", model.EngineerID);
            //******************************************//

            List<SelectListItem> li2 = new List<SelectListItem>();
            // li1.Add(new SelectListItem { Text = "--Select--", Value = " " });

            li2.Add(new SelectListItem { Text = "Replaced", Value = "1" });
            li2.Add(new SelectListItem { Text = "Required", Value = "2" });
            li2.Add(new SelectListItem { Text = "Cancel", Value = "3" });
            li2.Add(new SelectListItem { Text = "Provision", Value = "4" });
          
            ViewData["Requierd"] = li2;

            //List<SelectListItem> Requierd = new List<SelectListItem>();
            //ViewBag.Requierd = new SelectList(Requierd, "Value", "Text");
            //List<SelectListItem> li_Requierd = new List<SelectListItem>();

            //if (model.CCRMServiceReportMasterDTO.Requierd > 0)
            //{
            //    li_Requierd.Add(new SelectListItem { Text = "Replaced", Value = "1" });
            //    li_Requierd.Add(new SelectListItem { Text = "Required", Value = "2" });
            //    li_Requierd.Add(new SelectListItem { Text = "Cancel", Value = "3" });
            //    li_Requierd.Add(new SelectListItem { Text = "Provision", Value = "4" });
            //    //ViewData["SerialAndBatchManagedBy"] = li_SerialAndBatchManagedBy;
            //    ViewData["Requierd"] = new SelectList(li_Requierd, "Value", "Text", (model.CCRMServiceReportMasterDTO.Requierd).ToString().Trim());
            //}
            //else
            //{

            //    li_Requierd.Add(new SelectListItem { Text = "Replaced", Value = "1" });
            //    li_Requierd.Add(new SelectListItem { Text = "Required", Value = "2" });
            //    li_Requierd.Add(new SelectListItem { Text = "Cancel", Value = "3" });
            //    li_Requierd.Add(new SelectListItem { Text = "Provision", Value = "4" });
            //    ViewData["Requierd"] = li_Requierd;
            //}
            try
            {



                model.CCRMServiceReportMasterDTO = new CCRMServiceReportMaster();
                model.CCRMServiceReportMasterDTO.ID = id;
                model.CCRMServiceReportMasterDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<CCRMServiceReportMaster> response = _CCRMServiceReportMasterBA.SelectByID(model.CCRMServiceReportMasterDTO);
                if (response != null && response.Entity != null)
                {
                    model.CCRMServiceReportMasterDTO.ID = response.Entity.ID;
                    model.CCRMServiceReportMasterDTO.CallTktNo = response.Entity.CallTktNo;
                    model.CCRMServiceReportMasterDTO.CallDate = response.Entity.CallDate;
                    model.CCRMServiceReportMasterDTO.MIFID = response.Entity.MIFID;
                    model.CCRMServiceReportMasterDTO.MIFName = response.Entity.MIFName;
                    model.CCRMServiceReportMasterDTO.SerialNo = response.Entity.SerialNo;
                    model.CCRMServiceReportMasterDTO.ModelNo = response.Entity.ModelNo;
                    model.CCRMServiceReportMasterDTO.SymptomID = response.Entity.SymptomID;
                    model.CCRMServiceReportMasterDTO.Symptom = response.Entity.Symptom;
                    model.CCRMServiceReportMasterDTO.SymptomCode = response.Entity.SymptomCode;
                    model.CCRMServiceReportMasterDTO.CauseID = response.Entity.CauseID;
                    model.CCRMServiceReportMasterDTO.CauseCode = response.Entity.CauseCode;
                    model.CCRMServiceReportMasterDTO.CauseTitle = response.Entity.CauseTitle;
                    model.CCRMServiceReportMasterDTO.ActionID = response.Entity.ActionID;
                    model.CCRMServiceReportMasterDTO.ActionCode = response.Entity.ActionCode;
                    model.CCRMServiceReportMasterDTO.ActionTitle = response.Entity.ActionTitle;

                    model.CCRMServiceReportMasterDTO.EngineerID = response.Entity.EngineerID;
                    model.CCRMServiceReportMasterDTO.EnggName = response.Entity.EnggName;
                    model.CCRMServiceReportMasterDTO.ComPlaint = response.Entity.ComPlaint;
                  
                    model.CCRMServiceReportMasterDTO.ItemDescription = response.Entity.ItemDescription;
                    model.CCRMServiceReportMasterDTO.ContractCode = response.Entity.ContractCode;
                    model.CCRMServiceReportMasterDTO.AllotDate = response.Entity.AllotDate;
                    model.CCRMServiceReportMasterDTO.AllotPeriod = response.Entity.AllotPeriod;
                    model.CCRMServiceReportMasterDTO.A4Mono = response.Entity.A4Mono;
                    model.CCRMServiceReportMasterDTO.A4Col = response.Entity.A4Col;
                    model.CCRMServiceReportMasterDTO.A3Mono = response.Entity.A3Mono;
                    model.CCRMServiceReportMasterDTO.A3Col = response.Entity.A3Col;
                    model.CCRMServiceReportMasterDTO.CurrentReadA4Mono = response.Entity.CurrentReadA4Mono;
                    model.CCRMServiceReportMasterDTO.CurrentReadA4Col = response.Entity.CurrentReadA4Col;
                    model.CCRMServiceReportMasterDTO.CurrentReadA3Mono = response.Entity.CurrentReadA3Mono;
                    model.CCRMServiceReportMasterDTO.CurrentReadA3Col = response.Entity.CurrentReadA3Col;
                    model.CCRMServiceReportMasterDTO.SymptomDescrip = response.Entity.SymptomDescrip;
                    model.CCRMServiceReportMasterDTO.CauseDescrip = response.Entity.CauseDescrip;
                    model.CCRMServiceReportMasterDTO.ActionDescrip = response.Entity.ActionDescrip;
                    model.CCRMServiceReportMasterDTO.Remarks = response.Entity.Remarks;
                    model.CCRMServiceReportMasterDTO.JobstartDate = response.Entity.JobstartDate;
                    model.CCRMServiceReportMasterDTO.JobEndDate = response.Entity.JobEndDate;
                    model.CCRMServiceReportMasterDTO.JobPeriod = response.Entity.JobPeriod;
                    model.CCRMServiceReportMasterDTO.ArrivalPeriod = response.Entity.ArrivalPeriod;
                    model.CCRMServiceReportMasterDTO.ArrivalDate = response.Entity.ArrivalDate;
                    model.CCRMServiceReportMasterDTO.CompletionDate = response.Entity.CompletionDate;
                    model.CCRMServiceReportMasterDTO.CompletionPeriod = response.Entity.CompletionPeriod;
                    model.CCRMServiceReportMasterDTO.ItemNumber = response.Entity.ItemNumber;
                    model.CCRMServiceReportMasterDTO.ContractTypeID = response.Entity.ContractTypeID;
                    model.CCRMServiceReportMasterDTO.CallStatus = response.Entity.CallStatus;
                    model.CCRMServiceReportMasterDTO.SymptomTitle = response.Entity.SymptomTitle;
                    model.CCRMServiceReportMasterDTO.Feedback = response.Entity.Feedback;
                    model.CCRMServiceReportMasterDTO.FeedbackName = response.Entity.FeedbackName;
                    model.CCRMServiceReportMasterDTO.SignedBy = response.Entity.SignedBy;
                    model.CCRMServiceReportMasterDTO.PhoneNo = response.Entity.PhoneNo;
                    model.CCRMServiceReportMasterDTO.CallerName = response.Entity.CallerName;
                    model.CCRMServiceReportMasterDTO.ReasonCode = response.Entity.ReasonCode;
                }
                ViewData["CallStatus"] = new SelectList(li, "Value", "Text", (model.CallStatus).ToString().Trim());
                ViewData["Requierd"] = new SelectList(li2, "Value", "Text", (model.Requierd).ToString().Trim());
                //*****************************************//
                List<CCRMBrokenCallReasonMaster> CCRMBrokenCallReasonMaster = GetCCRMBrokenCallReasonMaster();
                List<SelectListItem> CCRMBrokenCallReasonMasterList = new List<SelectListItem>();
                foreach (CCRMBrokenCallReasonMaster item in CCRMBrokenCallReasonMaster)
                {
                    CCRMBrokenCallReasonMasterList.Add(new SelectListItem { Text = item.ReasonCode, Value = Convert.ToString(item.ReasonCode) });
                }
                ViewBag.CCRMBrokenCallReasonMasterList = new SelectList(CCRMBrokenCallReasonMasterList, "Value", "Text", model.ReasonCode);
                //*****************************************//
                searchRequest.ConnectionString = _connectioString;
                searchRequest.CCRMServiceReportMasterID = id;

                IBaseEntityCollectionResponse<CCRMServiceReportMaster> baseEntityCollectionResponse = _CCRMServiceReportMasterBA.GetListOfItemsByID(searchRequest);

                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        model.ItemsDetailsCCRMServiceReportMasterID = baseEntityCollectionResponse.CollectionResponse.ToList();

                    }
                }
                //******************************************//

                return PartialView("/Views/CCRM/CCRMServiceReportMaster/Edit.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Editdata(CCRMServiceReportMasterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.CCRMServiceReportMasterDTO != null)
                    {
                        if (model != null && model.CCRMServiceReportMasterDTO != null)
                        {
                            model.CCRMServiceReportMasterDTO.ConnectionString = _connectioString;
                            //model.CCRMServiceReportMasterDTO.SRDate = model.SRDate;
                            // model.CCRMServiceReportMasterDTO.CallCloseDate = model.CallCloseDate;
                            model.CCRMServiceReportMasterDTO.EngineerID = model.EngineerID;

                            model.CCRMServiceReportMasterDTO.EnggName = model.EnggName;
                            // model.CCRMServiceReportMasterDTO.CallId = model.CallId;
                            model.CCRMServiceReportMasterDTO.CallTktNo = model.CallTktNo;
                            //model.CCRMServiceReportMasterDTO.CallDate = model.CallDate;
                            //model.CCRMServiceReportMasterDTO.MIFName = model.MIFName;
                            //model.CCRMServiceReportMasterDTO.MIFID = model.MIFID;
                            //model.CCRMServiceReportMasterDTO.ModelNo = model.ModelNo;
                            //model.CCRMServiceReportMasterDTO.SerialNo = model.SerialNo;
                            //model.CCRMServiceReportMasterDTO.ContractType = model.ContractType;
                            //model.CCRMServiceReportMasterDTO.ContractTypeID = model.ContractTypeID;
                            //model.CCRMServiceReportMasterDTO.ComPlaint = model.ComPlaint;
                            // model.CCRMServiceReportMasterDTO.DispDate = model.DispDate;
                            model.CCRMServiceReportMasterDTO.ArrivalDate = model.ArrivalDate;
                            model.CCRMServiceReportMasterDTO.CompletionDate = model.CompletionDate;
                            model.CCRMServiceReportMasterDTO.ArrivalPeriod = model.ArrivalPeriod;
                            model.CCRMServiceReportMasterDTO.CompletionPeriod = model.CompletionPeriod;
                            model.CCRMServiceReportMasterDTO.CurrentReadA4Mono = model.CurrentReadA4Mono;
                            model.CCRMServiceReportMasterDTO.CurrentReadA4Col = model.CurrentReadA4Col;
                            model.CCRMServiceReportMasterDTO.CurrentReadA3Mono = model.CurrentReadA3Mono;
                            model.CCRMServiceReportMasterDTO.CurrentReadA3Col = model.CurrentReadA3Col;
                            model.CCRMServiceReportMasterDTO.CallStatus = model.CallStatus;
                            model.CCRMServiceReportMasterDTO.ReasonCode = model.ReasonCode;
                            //model.CCRMServiceReportMasterDTO.SymptomID = model.SymptomID;
                            //model.CCRMServiceReportMasterDTO.SymptomCode = model.SymptomCode;
                            //model.CCRMServiceReportMasterDTO.CauseID = model.CauseID;
                            //model.CCRMServiceReportMasterDTO.CauseCode = model.CauseCode;
                            //model.CCRMServiceReportMasterDTO.ActionID = model.ActionID;
                            //model.CCRMServiceReportMasterDTO.ActionCode = model.ActionCode;
                            //model.CCRMServiceReportMasterDTO.Symptom = model.Symptom;
                            //model.CCRMServiceReportMasterDTO.CauseTitle = model.CauseTitle;
                            //model.CCRMServiceReportMasterDTO.ActionTitle = model.ActionTitle;
                            model.CCRMServiceReportMasterDTO.SignedBy = model.SignedBy;
                            model.CCRMServiceReportMasterDTO.PhoneNo = model.PhoneNo;
                            model.CCRMServiceReportMasterDTO.Remarks = model.Remarks;
                            model.CCRMServiceReportMasterDTO.FeedbackID = model.FeedbackID;
                            model.CCRMServiceReportMasterDTO.Feedback = model.Feedback;
                            model.CCRMServiceReportMasterDTO.TimeStamp = model.TimeStamp;
                            // model.CCRMServiceReportMasterDTO.SCNSubmitted = model.SCNSubmitted;
                            //model.CCRMServiceReportMasterDTO.AllotDate = model.AllotDate;
                            //model.CCRMServiceReportMasterDTO.AllotPeriod = model.AllotPeriod;
                            model.CCRMServiceReportMasterDTO.SymptomDescrip = model.SymptomDescrip;
                            model.CCRMServiceReportMasterDTO.CauseDescrip = model.CauseDescrip;
                            model.CCRMServiceReportMasterDTO.ActionDescrip = model.ActionDescrip;
                            model.CCRMServiceReportMasterDTO.JobstartDate = model.JobstartDate;
                            model.CCRMServiceReportMasterDTO.JobEndDate = model.JobEndDate;
                            //  model.CCRMServiceReportMasterDTO.JobPeriod = model.JobPeriod;
                            model.CCRMServiceReportMasterDTO.XmlString = model.XmlString;
                            model.CCRMServiceReportMasterDTO.ID = model.ID;
                            model.CCRMServiceReportMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                            model.CCRMServiceReportMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                            IBaseEntityResponse<CCRMServiceReportMaster> response = _CCRMServiceReportMasterBA.UpdateCCRMServiceReportMaster(model.CCRMServiceReportMasterDTO);
                            model.CCRMServiceReportMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                        }
                    }
                    return Json(model.CCRMServiceReportMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
            CCRMServiceReportMasterViewModel model = new CCRMServiceReportMasterViewModel();
            try
            {
                if (ID > 0)
                {
                    if (ID > 0)
                    {
                        CCRMServiceReportMaster CCRMServiceReportMasterDTO = new CCRMServiceReportMaster();
                        CCRMServiceReportMasterDTO.ConnectionString = _connectioString;
                        CCRMServiceReportMasterDTO.ID = ID;
                        CCRMServiceReportMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<CCRMServiceReportMaster> response = _CCRMServiceReportMasterBA.DeleteCCRMServiceReportMaster(CCRMServiceReportMasterDTO);
                        model.CCRMServiceReportMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
                    }
                    return Json(model.CCRMServiceReportMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public IEnumerable<CCRMServiceReportMasterViewModel> GetCCRMServiceReportMaster(out int TotalRecords)
        {
            CCRMServiceReportMasterSearchRequest searchRequest = new CCRMServiceReportMasterSearchRequest();
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
            List<CCRMServiceReportMasterViewModel> listCCRMServiceReportMasterViewModel = new List<CCRMServiceReportMasterViewModel>();
            List<CCRMServiceReportMaster> listCCRMServiceReportMaster = new List<CCRMServiceReportMaster>();
            IBaseEntityCollectionResponse<CCRMServiceReportMaster> baseEntityCollectionResponse = _CCRMServiceReportMasterBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listCCRMServiceReportMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (CCRMServiceReportMaster item in listCCRMServiceReportMaster)
                    {
                        CCRMServiceReportMasterViewModel CCRMServiceReportMasterViewModel = new CCRMServiceReportMasterViewModel();
                        CCRMServiceReportMasterViewModel.CCRMServiceReportMasterDTO = item;
                        listCCRMServiceReportMasterViewModel.Add(CCRMServiceReportMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listCCRMServiceReportMasterViewModel;
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
            IEnumerable<CCRMServiceReportMasterViewModel> filteredCCRMServiceReportMasterViewModel;

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
            filteredCCRMServiceReportMasterViewModel = GetCCRMServiceReportMaster(out TotalRecords);
            var records = filteredCCRMServiceReportMasterViewModel.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.CallTktNo), Convert.ToString(c.ID), Convert.ToString(c.CallCloseDate), Convert.ToString(c.SerialNo), Convert.ToString(c.ModelNo), Convert.ToString(c.MIFName), Convert.ToString(c.ItemDescription), Convert.ToString(c.CallStatus), Convert.ToString(c.EnggName) };

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}