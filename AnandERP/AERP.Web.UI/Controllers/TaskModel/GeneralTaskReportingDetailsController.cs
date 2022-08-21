using AERP.Base.DTO;
using AERP.DTO;
using AERP.Business.BusinessAction;
using AERP.ViewModel;
using System;
using AERP.ExceptionManager;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using AERP.Common;

namespace AERP.Web.UI.Controllers
{
    public class GeneralTaskReportingDetailsController : BaseController
    {
        #region ------------CONTROLLER CLASS VARIABLE------------
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        IGeneralTaskReportingDetailsBA _generalTaskReportingDetailsBA = null;
        IEmpEmployeeMasterBA _empEmployeeMasterBA = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        #endregion

        #region ------------CONTROLLER CLASS CONSTRUCTOR------------
        public GeneralTaskReportingDetailsController()
        {
            _generalTaskReportingDetailsBA = new GeneralTaskReportingDetailsBA();
            _empEmployeeMasterBA = new EmpEmployeeMasterBA();
        }
        #endregion

        #region ------------CONTROLLER ACTION METHODS------------
        public ActionResult Index()
        {
            try
            {
                if (Convert.ToString(Session["UserType"]) == "A" || Convert.ToInt32(Session["Admin Manager"]) > 0)
                {
                    return View("/Views/TaskModel/GeneralTaskReportingDetails/Index.cshtml");
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
                        return View("/Views/TaskModel/GeneralTaskReportingDetails/Index.cshtml");
                    }
                    else
                    {
                        return RedirectToAction("UnauthorizedAccess", "Home");
                    }
                }
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        public ActionResult List(string actionMode, string centerCode)
        {
            try
            {
                IGeneralTaskReportingDetailsViewModel model = new GeneralTaskReportingDetailsViewModel();
                if (Convert.ToString(Session["UserType"]) == "A")
                {
                    //--------------------------------------For Centre Code list---------------------------------//
                    List<OrganisationStudyCentreMaster> listAdminRoleApplicableDetails = GetListOrgStudyCentreMaster();
                    AdminRoleApplicableDetails a = null;
                    foreach (var item in listAdminRoleApplicableDetails)
                    {
                        a = new AdminRoleApplicableDetails();
                        a.CentreCode = item.CentreCode;
                        a.CentreName = item.CentreName;
                        a.ScopeIdentity = item.ScopeIdentity;
                        model.ListGetAdminRoleApplicableCentre.Add(a);
                    }
                    model.EntityLevel = "Centre";

                    foreach (var b in model.ListGetAdminRoleApplicableCentre)
                    {
                        b.CentreCode = b.CentreCode + ":" + "Centre";
                    }
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
                    List<AdminRoleApplicableDetails> listAdminRoleApplicableDetails = GetAdminRoleApplicableCentreByAcademicManager(AdminRoleMasterID);
                    AdminRoleApplicableDetails a = null;
                    foreach (var item in listAdminRoleApplicableDetails)
                    {
                        a = new AdminRoleApplicableDetails();
                        a.CentreCode = item.CentreCode;
                        a.CentreName = item.CentreName;
                        // a.ScopeIdentity = item.ScopeIdentity;
                        model.ListGetAdminRoleApplicableCentre.Add(a);
                    }
                    foreach (var b in model.ListGetAdminRoleApplicableCentre)
                    {
                        b.CentreCode = b.CentreCode;
                    }
                }

                model.CentreCode = centerCode;
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/TaskModel/GeneralTaskReportingDetails/List.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }



        public ActionResult ApprovalStages(string Ids)
        {
            try
            {
                IGeneralTaskReportingDetailsViewModel model = new GeneralTaskReportingDetailsViewModel();
                var splitData = Ids.Split('~') ;
                model.ID =Convert.ToInt32(splitData[0]);
                model.NumberOfApprovalStages = Convert.ToInt32(splitData[1]);
                model.TaskApprovalTableDisplayFieldValue = splitData[2];
                return PartialView("/Views/TaskModel/GeneralTaskReportingDetails/ApprovalStages.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        public ActionResult ApprovalStageDetails(string Ids,string centreCode)
        {
            try
            {
                IGeneralTaskReportingDetailsViewModel model = new GeneralTaskReportingDetailsViewModel();
                var splitData = Ids.Split('~');
                model.GeneralTaskReportingMasterID = Convert.ToInt32(splitData[0]);
                model.StageSequenceNumber = Convert.ToInt32(splitData[1]);
                model.TaskApprovalTableDisplayFieldValue = splitData[2].Replace(':', ' ');
                model.CentreCode = centreCode;
                return PartialView("/Views/TaskModel/GeneralTaskReportingDetails/ApprovalStageDetails.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpGet]
        public ActionResult CreateApprovalStageDetails(int id, int stageSequenceNumber,string centreCode)
        {
            try
            {
                IGeneralTaskReportingDetailsViewModel model = new GeneralTaskReportingDetailsViewModel();
                model.GeneralTaskReportingMasterID = id;
                model.StageSequenceNumber = stageSequenceNumber;
                model.CentreCode = centreCode;
                model.OrganisationDepartmentList = GetDepartmentList(centreCode, 0 ,true);
                return PartialView("/Views/TaskModel/GeneralTaskReportingDetails/CreateApprovalStageDetails.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public ActionResult CreateApprovalStageDetails(GeneralTaskReportingDetailsViewModel model)
        {
            try
            {
                model.GeneralTaskReportingDetailsDTO.ConnectionString = _connectioString;
                model.GeneralTaskReportingDetailsDTO.GeneralTaskReportingMasterID = model.GeneralTaskReportingMasterID;
                model.GeneralTaskReportingDetailsDTO.CentreCode = !model.CentreCode.Contains(":") ? model.CentreCode : model.CentreCode.Split(':')[0];
                model.GeneralTaskReportingDetailsDTO.StageSequenceNumber = model.StageSequenceNumber;
                model.GeneralTaskReportingDetailsDTO.RangeFrom = model.RangeFrom;
                model.GeneralTaskReportingDetailsDTO.RangeUpto = model.RangeUpto;
                model.GeneralTaskReportingDetailsDTO.IsParallel = model.IsParallel;
                model.GeneralTaskReportingDetailsDTO.SelectedApprovalStageDetailsXMLstring = model.SelectedApprovalStageDetailsXMLstring;
                model.GeneralTaskReportingDetailsDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                IBaseEntityResponse<GeneralTaskReportingDetails> response = _generalTaskReportingDetailsBA.InsertGeneralTaskApprovalStageDetails(model.GeneralTaskReportingDetailsDTO);
                model.GeneralTaskReportingDetailsDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                return Json(model.GeneralTaskReportingDetailsDTO.errorMessage, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpGet]
        public ActionResult EditApprovalStageDetails(string ids)
        {
            try
            {
                GeneralTaskReportingDetailsViewModel model = new GeneralTaskReportingDetailsViewModel();
                 model.GeneralTaskReportingDetailsDTO = new GeneralTaskReportingDetails();
                 model.GeneralTaskReportingDetailsDTO.GeneralTaskReportingDetailsID = !string.IsNullOrEmpty(ids) ? Convert.ToInt32(ids.Split('~')[0]) : 0;
                 model.GeneralTaskReportingDetailsDTO.ConnectionString = _connectioString;

                 IBaseEntityResponse<GeneralTaskReportingDetails> response = _generalTaskReportingDetailsBA.SelectByID(model.GeneralTaskReportingDetailsDTO);
                 if (response != null && response.Entity != null)
                 {
                     model.GeneralTaskReportingDetailsDTO.GeneralTaskReportingDetailsID = response.Entity.GeneralTaskReportingDetailsID;
                     model.RangeFrom = response.Entity.RangeFrom;
                     model.RangeUpto = response.Entity.RangeUpto;
                     model.EmployeeName = response.Entity.EmployeeName;
                     model.CentreCode= response.Entity.CentreCode;
                     model.RoleID = response.Entity.TaskReportingRoleID;
                    model.HODAuthorizedEmployeeID = response.Entity.HODAuthorizedEmployeeID;
                    model.HODAuthorizedEmployeeName = response.Entity.HODAuthorizedEmployeeName;

                }
                 model.OrganisationDepartmentList = GetDepartmentList(model.CentreCode, model.GeneralTaskReportingDetailsID, false);
                return PartialView("/Views/TaskModel/GeneralTaskReportingDetails/EditApprovalStageDetails.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public ActionResult EditApprovalStageDetails(GeneralTaskReportingDetailsViewModel model)
        {
            try
            {
                model.GeneralTaskReportingDetailsDTO.ConnectionString = _connectioString;
                model.GeneralTaskReportingDetailsDTO.GeneralTaskReportingDetailsID = model.GeneralTaskReportingDetailsID;
                model.GeneralTaskReportingDetailsDTO.CentreCode = !model.CentreCode.Contains(":") ? model.CentreCode : model.CentreCode.Split(':')[0];
                model.GeneralTaskReportingDetailsDTO.TaskReportingRoleID = model.RoleID;
                model.GeneralTaskReportingDetailsDTO.RangeFrom = model.RangeFrom;
                model.GeneralTaskReportingDetailsDTO.RangeUpto = model.RangeUpto;
                model.GeneralTaskReportingDetailsDTO.SelectedApprovalStageDetailsXMLstring = model.SelectedApprovalStageDetailsXMLstring;
                model.GeneralTaskReportingDetailsDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                IBaseEntityResponse<GeneralTaskReportingDetails> response = _generalTaskReportingDetailsBA.UpdateGeneralTaskReportingDetails(model.GeneralTaskReportingDetailsDTO);
                model.GeneralTaskReportingDetailsDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                return Json(model.GeneralTaskReportingDetailsDTO.errorMessage, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        //[HttpGet]
        //public ActionResult ViewTaskReportingDetails(string IDs)
        //{
        //    try
        //    {
        //        IGeneralTaskReportingDetailsViewModel model = new GeneralTaskReportingDetailsViewModel();
        //        var splitData = IDs.Split('~');
        //        model.GeneralTaskReportingDetailsDTO.ID = Convert.ToInt32(splitData[0]);
        //        model.GeneralTaskReportingDetailsDTO.StageSequenceNumber = Convert.ToInt32(splitData[1]);
        //        model.GeneralTaskReportingDetailsDTO.ConnectionString = _connectioString;
        //        model.TaskReportingRoleIDsList = GetReportingRoleIDsList(model.GeneralTaskReportingDetailsDTO.ID, model.GeneralTaskReportingDetailsDTO.StageSequenceNumber);
        //        model.OrganisationDepartmentList = GetDepartmentList(model.GeneralTaskReportingDetailsDTO.ID, model.GeneralTaskReportingDetailsDTO.StageSequenceNumber);
        //        model.RangeFrom = model.TaskReportingRoleIDsList[0].RangeFrom;
        //        model.RangeUpto = model.TaskReportingRoleIDsList[0].RangeUpto;
        //        return PartialView("/Views/TaskModel/GeneralTaskReportingDetails/ViewTaskReportingDetails.cshtml", model);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logException.Error(ex.Message);
        //        throw;
        //    }
        //}

        ////[HttpPost]
        ////public ActionResult ViewTaskReportingDetails(GeneralTaskReportingDetailsViewModel model)
        ////{
        ////    try
        ////    {
        ////        model.GeneralTaskReportingDetailsDTO.ConnectionString = _connectioString;
        ////        model.GeneralTaskReportingDetailsDTO.ID = model.ID;
        ////        //model.GeneralTaskReportingDetailsDTO.FeeSubTypeDesc = model.FeeSubTypeDesc;
        ////        //model.GeneralTaskReportingDetailsDTO.FeeSubShortDesc = model.FeeSubShortDesc;
        ////        //model.GeneralTaskReportingDetailsDTO.AccountID = model.AccountID;
        ////        //model.GeneralTaskReportingDetailsDTO.SubTypeIdentification = model.SubTypeIdentification;
        ////        //model.GeneralTaskReportingDetailsDTO.CarryForwardFeeSubtypeID = model.CarryForwardFeeSubtypeID;
        ////        //model.GeneralTaskReportingDetailsDTO.FeeSource = model.FeeSource;
        ////        //model.GeneralTaskReportingDetailsDTO.IsFeeTypeTransaction = false;
        ////        model.GeneralTaskReportingDetailsDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
        ////        IBaseEntityResponse<GeneralTaskReportingDetails> response = _generalTaskReportingDetailsBA.InsertGeneralTaskReportingDetails(model.GeneralTaskReportingDetailsDTO);
        ////        model.GeneralTaskReportingDetailsDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
        ////        return Json(model.GeneralTaskReportingDetailsDTO.errorMessage, JsonRequestBehavior.AllowGet);
        ////    }
        ////    catch (Exception ex)
        ////    {
        ////        _logException.Error(ex.Message);
        ////        throw;
        ////    }
        ////}


        [HttpGet]
        public ActionResult CreateTaskReportingMaster(string centreName) {
            try {
                IGeneralTaskReportingDetailsViewModel model = new GeneralTaskReportingDetailsViewModel();
                model.CentreName = centreName;
                model.GeneralTaskModelList = GetGeneralTaskModelList();
                model.TaskApprovalBasedTableList = GetTaskApprovalBasedTableList();
                ViewBag.TaskApprovalParamPrimaryKeyList = new List<SelectListItem>();
                ViewBag.TaskApprovalKeyValueList = new List<SelectListItem>();
                ViewBag.TaskApprovalTableDisplayFieldList = new List<SelectListItem>();
                List<SelectListItem> li = new List<SelectListItem>();
                li.Add(new SelectListItem { Text = "Simple", Value = "Simple" });
                li.Add(new SelectListItem { Text = "Value Range Base", Value = "ValueRangeBase" });
                ViewData["ApprovalType"] = li;
                return PartialView("/Views/TaskModel/GeneralTaskReportingDetails/CreateTaskReportingMaster.cshtml", model);
            }
            catch (Exception ex) {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public ActionResult CreateTaskReportingMaster(GeneralTaskReportingDetailsViewModel model)
        {
            try
            {
                model.GeneralTaskReportingDetailsDTO.ConnectionString = _connectioString;
                model.GeneralTaskReportingDetailsDTO.TaskCode = model.TaskCode;
                model.GeneralTaskReportingDetailsDTO.CentreCode = !model.CentreCode.Contains(":") ? model.CentreCode : model.CentreCode.Split(':')[0];
                model.GeneralTaskReportingDetailsDTO.ApprovalType = model.ApprovalType;
                model.GeneralTaskReportingDetailsDTO.NumberOfApprovalStages = model.NumberOfApprovalStages;
                model.GeneralTaskReportingDetailsDTO.TaskApprovalBasedTable = model.TaskApprovalBasedTable;
                model.GeneralTaskReportingDetailsDTO.TaskApprovalParamPrimaryKey= model.TaskApprovalParamPrimaryKey;
                model.GeneralTaskReportingDetailsDTO.TaskApprovalTableDisplayField = model.TaskApprovalTableDisplayField;
                model.GeneralTaskReportingDetailsDTO.KeyValueXmlString = model.KeyValueXmlString;
                model.GeneralTaskReportingDetailsDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                IBaseEntityResponse<GeneralTaskReportingDetails> response = _generalTaskReportingDetailsBA.InsertGeneralTaskReportingMaster(model.GeneralTaskReportingDetailsDTO);
                model.GeneralTaskReportingDetailsDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                return Json(model.GeneralTaskReportingDetailsDTO.errorMessage, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }
        #endregion

        #region ------------CONTROLLER NON ACTION METHODS------------
        //Non-Action method to fetch list of Balancesheet
        [HttpPost]
        public JsonResult GetEmployeeRoleCentrewise(string term, string centreCode)
        {
            var data = GetEmployeeRoleCentrewiseSearchList(term, !centreCode.Contains(':') ? centreCode : centreCode.Split(':')[0]);
            var result = (from r in data
                          select new
                          {
                              id = r.ID,
                              name = r.EmployeeFullName + " [" + r.AdminRoleCode.Replace('-', ' ') + "]",
                              roleId = r.AdminRoleMasterID
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        protected List<GeneralTaskReportingDetails> GetTaskApprovalBasedTableList() {
            GeneralTaskReportingDetailsSearchRequest searchRequest = new GeneralTaskReportingDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<GeneralTaskReportingDetails> taskApprovalBasedTableList = new List<GeneralTaskReportingDetails>();
            IBaseEntityCollectionResponse<GeneralTaskReportingDetails> baseEntityCollectionResponse = _generalTaskReportingDetailsBA.GetTaskApprovalBasedTableList(searchRequest);
            if (baseEntityCollectionResponse != null) {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0) {
                    taskApprovalBasedTableList = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return taskApprovalBasedTableList;
        }
        protected List<EmpEmployeeMaster> GetEmployeeRoleCentrewiseSearchList(string SearchWord, string CentreCode)
        {
            EmpEmployeeMasterSearchRequest searchRequest = new EmpEmployeeMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.CentreCode = CentreCode;
            searchRequest.SearchWord = SearchWord;
            List<EmpEmployeeMaster> listEmpEmployeeMaster = new List<EmpEmployeeMaster>();
            IBaseEntityCollectionResponse<EmpEmployeeMaster> baseEntityCollectionResponse = _empEmployeeMasterBA.GetEmployeeRoleCentrewiseSearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listEmpEmployeeMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listEmpEmployeeMaster;
        }

        protected List<GeneralTaskReportingDetails> GetGeneralTaskModelList()
        {
            GeneralTaskReportingDetailsSearchRequest searchRequest = new GeneralTaskReportingDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<GeneralTaskReportingDetails> generalTaskModelList = new List<GeneralTaskReportingDetails>();
            IBaseEntityCollectionResponse<GeneralTaskReportingDetails> baseEntityCollectionResponse = _generalTaskReportingDetailsBA.GetGeneralTaskModelList(searchRequest);
            if (baseEntityCollectionResponse != null) {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0) {
                    generalTaskModelList = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return generalTaskModelList;
        } 

        protected List<GeneralTaskReportingDetails> GetTaskApprovalParamPrimaryKeyList(string tableName) {
            GeneralTaskReportingDetailsSearchRequest searchRequest = new GeneralTaskReportingDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.TableName = tableName;
            List<GeneralTaskReportingDetails> taskApprovalPrimaryKeyList = new List<GeneralTaskReportingDetails>();
            IBaseEntityCollectionResponse<GeneralTaskReportingDetails> baseEntityCollectionResponse = _generalTaskReportingDetailsBA.GetTaskApprovalParamPrimaryKeyList(searchRequest);
            if (baseEntityCollectionResponse != null) {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0) {
                    taskApprovalPrimaryKeyList = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return taskApprovalPrimaryKeyList;
        }
        //Get Record from TableName, Primary Key and table fields.
        protected List<GeneralTaskReportingDetails> GetTaskApprovalKeyValueList(string tableName, string primaryKey, string displayField)
        {
            GeneralTaskReportingDetailsSearchRequest searchRequest = new GeneralTaskReportingDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.TableName = !string.IsNullOrEmpty(tableName) ? tableName : string.Empty;
            searchRequest.PrimaryKey = !string.IsNullOrEmpty(primaryKey) ? primaryKey : string.Empty;
            searchRequest.DisplayField = !string.IsNullOrEmpty(displayField) ? displayField : string.Empty;
            List<GeneralTaskReportingDetails> taskApprovalPrimaryKeyList = new List<GeneralTaskReportingDetails>();
            IBaseEntityCollectionResponse<GeneralTaskReportingDetails> baseEntityCollectionResponse = _generalTaskReportingDetailsBA.GetTaskApprovalKeyValueList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    taskApprovalPrimaryKeyList = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return taskApprovalPrimaryKeyList;
        }

        protected List<GeneralTaskReportingDetails> GetTaskApprovalBaseTableDisplayFieldList(string tableName)
        {
            GeneralTaskReportingDetailsSearchRequest searchRequest = new GeneralTaskReportingDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.TableName = tableName;
            List<GeneralTaskReportingDetails> taskApprovalPrimaryKeyList = new List<GeneralTaskReportingDetails>();
            IBaseEntityCollectionResponse<GeneralTaskReportingDetails> baseEntityCollectionResponse = _generalTaskReportingDetailsBA.GetTaskApprovalBaseTableDisplayFieldList(searchRequest);
            if (baseEntityCollectionResponse != null) {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0) {
                    taskApprovalPrimaryKeyList = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return taskApprovalPrimaryKeyList;
        }

        //protected List<GeneralTaskReportingDetails> GetTaskApprovalKeyValueList(string tableName, string primaryKey, string displayField)
        //{
        //    GeneralTaskReportingDetailsSearchRequest searchRequest = new GeneralTaskReportingDetailsSearchRequest();
        //    searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        //    searchRequest.TableName = !string.IsNullOrEmpty(tableName) ? tableName : string.Empty;
        //    searchRequest.PrimaryKey = !string.IsNullOrEmpty(primaryKey) ? primaryKey : string.Empty;
        //    searchRequest.DisplayField = !string.IsNullOrEmpty(displayField) ? displayField : string.Empty;
        //    List<GeneralTaskReportingDetails> taskApprovalPrimaryKeyList = new List<GeneralTaskReportingDetails>();
        //    IBaseEntityCollectionResponse<GeneralTaskReportingDetails> baseEntityCollectionResponse = _generalTaskReportingDetailsBA.GetTaskApprovalKeyValueList(searchRequest);
        //    if (baseEntityCollectionResponse != null) {
        //        if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0) {
        //            taskApprovalPrimaryKeyList = baseEntityCollectionResponse.CollectionResponse.ToList();
        //        }
        //    }
        //    return taskApprovalPrimaryKeyList;
        //}
        
        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult GetPrimaryKeyList(string tableName) {
            try {
                var dataList1 = GetTaskApprovalParamPrimaryKeyList(!string.IsNullOrEmpty(tableName) ? tableName : string.Empty);
                var result1 = (from s in dataList1 select new { id = s.TaskApprovalParamPrimaryKey, name = s.TaskApprovalParamPrimaryKey }).ToList();
                var dataList2 = GetTaskApprovalBaseTableDisplayFieldList(!string.IsNullOrEmpty(tableName) ? tableName : string.Empty);
                var result2 = (from s in dataList2 select new { id = s.TaskApprovalTableDisplayField, name = s.TaskApprovalTableDisplayField }).ToList();
                var objList = new{Result1 = result1, Result2 = result2 };
                return Json(objList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex) {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult GetPrimaryKeyValueList(string tableName, string primaryKey, string displayField)
        {
            try
            {
                var dataList = GetTaskApprovalKeyValueList(tableName, primaryKey, displayField);
                var result = (from s in dataList select new { id = s.PrimaryKey, name = s.DisplayField, }).ToList();
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        protected List<GeneralTaskReportingDetails> GetReportingRoleIDsList(int GeneralTaskReportingMstID,int StageSequenceNumber) {
            GeneralTaskReportingDetailsSearchRequest searchRequest = new GeneralTaskReportingDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<GeneralTaskReportingDetails> listAdminRoleApplicableDetails = new List<GeneralTaskReportingDetails>();
            searchRequest.ID = GeneralTaskReportingMstID;
            searchRequest.StageSequenceNumber = StageSequenceNumber;
            IBaseEntityCollectionResponse<GeneralTaskReportingDetails> baseEntityCollectionResponse = _generalTaskReportingDetailsBA.ReportingRoleIDsSearchList(searchRequest);
            if (baseEntityCollectionResponse != null) {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0) {
                    listAdminRoleApplicableDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listAdminRoleApplicableDetails;
        }

        protected List<GeneralTaskReportingDetails> GetDepartmentList(string centreCode, int generalTaskReportingDetailsID , bool isCreateStageDetails)
        {
            GeneralTaskReportingDetailsSearchRequest searchRequest = new GeneralTaskReportingDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<GeneralTaskReportingDetails> DepartmentList = new List<GeneralTaskReportingDetails>();
            searchRequest.GeneralTaskReportingDetailsID = generalTaskReportingDetailsID;
            searchRequest.CentreCode = !centreCode.Contains(":") ? centreCode : centreCode.Split(':')[0];
            searchRequest.IsCreateStageDetails = isCreateStageDetails;
            IBaseEntityCollectionResponse<GeneralTaskReportingDetails> baseEntityCollectionResponse = _generalTaskReportingDetailsBA.DepartmentList(searchRequest);
            if (baseEntityCollectionResponse != null) {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0) {
                    DepartmentList = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return DepartmentList;
        }

        // Non-Action method to fetch all records from table.
        [NonAction]
        public List<GeneralTaskReportingDetails> GetListGeneralTaskReportingMaster(out int TotalRecords, string centreCode, bool reloadStatus)
        {
            List<GeneralTaskReportingDetails> listGeneralTaskReportingDetails = new List<GeneralTaskReportingDetails>();
            GeneralTaskReportingDetailsSearchRequest searchRequest = new GeneralTaskReportingDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            if (reloadStatus)     
            {
                searchRequest.SortBy = "A.CreatedDate";
                searchRequest.StartRow = 0;
                searchRequest.EndRow = 10;
                searchRequest.SearchBy = string.Empty;
                searchRequest.SortDirection = "Desc";
                searchRequest.CentreCode = centreCode;
            }
            else
            {
                searchRequest.SortBy = _sortBy;                     
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;
                searchRequest.CentreCode = centreCode;
            }
            IBaseEntityCollectionResponse<GeneralTaskReportingDetails> baseEntityCollectionResponse = _generalTaskReportingDetailsBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralTaskReportingDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listGeneralTaskReportingDetails;
        }
        
        [NonAction]
        public List<GeneralTaskReportingDetails> GetListGeneralTaskReportingDetailsApprovalStages(out int TotalRecords, int ID, int NumberOfApprovalStages)
        {
            List<GeneralTaskReportingDetails> listGeneralTaskReportingDetails = new List<GeneralTaskReportingDetails>();
            GeneralTaskReportingDetailsSearchRequest searchRequest = new GeneralTaskReportingDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.ID = ID;
            searchRequest.NumberOfApprovalStages = NumberOfApprovalStages;
            IBaseEntityCollectionResponse<GeneralTaskReportingDetails> baseEntityCollectionResponse = _generalTaskReportingDetailsBA.GetTaskReportingDetailsApprovalStages(searchRequest);
            if (baseEntityCollectionResponse != null) {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0) {
                    listGeneralTaskReportingDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listGeneralTaskReportingDetails;
        }

        [NonAction]
        public List<GeneralTaskReportingDetails> GetListGeneralTaskReportingDetailsApprovalStageDetails(out int TotalRecords, int GeneralTaskReportingMasterID, int StageSequenceNumber, string reloadStatus)
        {
            List<GeneralTaskReportingDetails> listGeneralTaskReportingDetails = new List<GeneralTaskReportingDetails>();
            GeneralTaskReportingDetailsSearchRequest searchRequest = new GeneralTaskReportingDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            switch (! string.IsNullOrEmpty(reloadStatus)? Convert.ToInt32(reloadStatus):0)
            {
                case 0:
                    searchRequest.SortBy = _sortBy;
                    searchRequest.StartRow = _startRow;
                    searchRequest.EndRow = _startRow + _rowLength;
                    searchRequest.SearchBy = _searchBy;
                    searchRequest.SortDirection = _sortDirection;
                    searchRequest.ID = GeneralTaskReportingMasterID;
                    searchRequest.StageSequenceNumber = StageSequenceNumber;
                    break;
                case 1:
                    searchRequest.SortBy = "A.CreatedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                    searchRequest.ID = GeneralTaskReportingMasterID;
                    searchRequest.StageSequenceNumber = StageSequenceNumber;
                    break;
                case 2:
                    searchRequest.SortBy = "A.ModifiedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                    searchRequest.ID = GeneralTaskReportingMasterID;
                    searchRequest.StageSequenceNumber = StageSequenceNumber;
                    break;
            }
            IBaseEntityCollectionResponse<GeneralTaskReportingDetails> baseEntityCollectionResponse = _generalTaskReportingDetailsBA.GetTaskReportingDetailsApprovalStageDetails(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralTaskReportingDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listGeneralTaskReportingDetails;
        }
        
        [NonAction]
        public List<GeneralTaskReportingDetails> GetListGeneralTaskReportingDetails(out int TotalRecords, string centreCode) {
            List<GeneralTaskReportingDetails> listGeneralTaskReportingDetails = new List<GeneralTaskReportingDetails>();
            GeneralTaskReportingDetailsSearchRequest searchRequest = new GeneralTaskReportingDetailsSearchRequest();
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
                    searchRequest.CentreCode = centreCode;
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "A.ModifiedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                    searchRequest.CentreCode = centreCode;
                }
            }
            else
            {
                searchRequest.SortBy = _sortBy;                     // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;
                searchRequest.CentreCode = centreCode;
            }
            IBaseEntityCollectionResponse<GeneralTaskReportingDetails> baseEntityCollectionResponse = _generalTaskReportingDetailsBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralTaskReportingDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listGeneralTaskReportingDetails;
        }
        #endregion

        #region ------------CONTROLLER AJAX HANDLER METHODS------------
        /// <summary>
        /// AJAX Method for binding List GeneralTaskReportingDetails
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public ActionResult AjaxHandler(JQueryDataTableParamModel param, string centreCode, bool reloadStatus)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<GeneralTaskReportingDetails> filteredGeneralTaskReportingDetails;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "TaskDescription";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "(TaskDescription Like '%" + param.sSearch + "%'or A.TaskCode Like '%" + param.sSearch + "%'  or NumberOfApprovalStages Like '%" + param.sSearch + "%' or ApprovalType  Like '%" + param.sSearch + "%' or A.TaskApprovalDisplayKeyValue Like '%" + param.sSearch + "%')";         //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "A.TaskCode";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "(TaskDescription Like '%" + param.sSearch + "%'or A.TaskCode Like '%" + param.sSearch + "%'  or NumberOfApprovalStages Like '%" + param.sSearch + "%' or ApprovalType  Like '%" + param.sSearch + "%' or A.TaskApprovalDisplayKeyValue Like '%" + param.sSearch + "%' )";         //this "if" block is added for search functionality
                    }
                    break;
                case 2:
                    _sortBy = "NumberOfApprovalStages";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "(TaskDescription Like '%" + param.sSearch + "%'or A.TaskCode Like '%" + param.sSearch + "%'  or NumberOfApprovalStages Like '%" + param.sSearch + "%' or ApprovalType  Like '%" + param.sSearch + "%'or A.TaskApprovalDisplayKeyValue Like '%" + param.sSearch + "%' )";         //this "if" block is added for search functionality
                    }
                    break;
                case 3:
                    _sortBy = "ApprovalType";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "(TaskDescription Like '%" + param.sSearch + "%'or A.TaskCode Like '%" + param.sSearch + "%'  or NumberOfApprovalStages Like '%" + param.sSearch + "%' or ApprovalType  Like '%" + param.sSearch + "%'or A.TaskApprovalDisplayKeyValue Like '%" + param.sSearch + "%' )";         //this "if" block is added for search functionality
                    }
                    break;
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            if (!string.IsNullOrEmpty(centreCode))
            {
                filteredGeneralTaskReportingDetails = GetListGeneralTaskReportingMaster(out TotalRecords, !centreCode.Contains(":") ? centreCode : centreCode.Split(':')[0], reloadStatus);    
            }
            else
            {
                filteredGeneralTaskReportingDetails = new List<GeneralTaskReportingDetails>();
                TotalRecords = 0;
            }
            var records = filteredGeneralTaskReportingDetails.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.TaskDescription), Convert.ToString(c.TaskCode), Convert.ToString(c.TaskApprovalTableDisplayFieldValue), Convert.ToString(c.NumberOfApprovalStages), Convert.ToString(c.ApprovalType), Convert.ToString(c.ID) };
            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// AJAX Method for binding List GeneralTaskReportingDetails
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public ActionResult AjaxHandlerApprovalStages(JQueryDataTableParamModel param, string ID, string NumberOfApprovalStages, bool reloadStatus)
        {
            int TotalRecords;
            IEnumerable<GeneralTaskReportingDetails> filteredGeneralTaskReportingDetails;
            if (!string.IsNullOrEmpty(ID) && !string.IsNullOrEmpty(NumberOfApprovalStages))
            {
                filteredGeneralTaskReportingDetails = GetListGeneralTaskReportingDetailsApprovalStages(out TotalRecords, Convert.ToInt32(ID), Convert.ToInt32(NumberOfApprovalStages));    
            }
            else
            {
                filteredGeneralTaskReportingDetails = new List<GeneralTaskReportingDetails>();
                TotalRecords = 0;
            }
            var records = filteredGeneralTaskReportingDetails.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.ID), Convert.ToString(c.StageSequenceNumber), Convert.ToString(c.StatusFlag)};
            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// AJAX Method for binding List GeneralTaskReportingDetails
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public ActionResult AjaxHandlerApprovalStageDetails(JQueryDataTableParamModel param, string GeneralTaskReportingMasterID, string StageSequenceNumber, string reloadStatus)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc
            IEnumerable<GeneralTaskReportingDetails> filteredGeneralTaskReportingDetails;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "EmployeeFirstName,EmployeeMiddleName,EmployeeLastName,DepartmentName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "(EmployeeFirstName Like '%" + param.sSearch + "%' or EmployeeMiddleName Like '%" + param.sSearch + "%' or EmployeeLastName  Like '%" + param.sSearch + "%' or DepartmentName Like '%" + param.sSearch + "%' )";         //this "if" block is added for search functionality
                    }
                    break;
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            if (!string.IsNullOrEmpty(GeneralTaskReportingMasterID) && !string.IsNullOrEmpty(StageSequenceNumber))
            {
                filteredGeneralTaskReportingDetails = GetListGeneralTaskReportingDetailsApprovalStageDetails(out TotalRecords, Convert.ToInt32(GeneralTaskReportingMasterID), Convert.ToInt32(StageSequenceNumber), reloadStatus);
            }
            else
            {
                filteredGeneralTaskReportingDetails = new List<GeneralTaskReportingDetails>();
                TotalRecords = 0;
            }
            var records = filteredGeneralTaskReportingDetails.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.EmployeeName), Convert.ToString(c.DepartmentName), Convert.ToString(c.DepartmentID), Convert.ToString(c.EmployeeID), Convert.ToString(c.TaskReportingRoleID), Convert.ToString(c.GeneralTaskReportingMasterID), Convert.ToString(c.GeneralTaskReportingDetailsID) };
            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}
