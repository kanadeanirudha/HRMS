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
using System.Data;
using System.Threading;

namespace AERP.Web.UI.Controllers
{
    public class CCRMComplaintLoggingMasterController : BaseController
    {
        ICCRMComplaintLoggingMasterBA _CCRMComplaintLoggingMasterBA = null;
        ICCRMServiceCallTypesBA _CCRMServiceCallTypesBA = null;
        ICCRMAreaPatchMasterBA _CCRMAreaPatchMasterBA = null;
        ICCRMMIFMasterAndDetailsBA _CCRMMIFMasterAndDetailsBA = null;
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

        public CCRMComplaintLoggingMasterController()
        {
            _CCRMComplaintLoggingMasterBA = new CCRMComplaintLoggingMasterBA();
            _CCRMServiceCallTypesBA = new CCRMServiceCallTypesBA();
            _CCRMAreaPatchMasterBA = new CCRMAreaPatchMasterBA();
            _CCRMMIFMasterAndDetailsBA = new CCRMMIFMasterAndDetailsBA();
        }
        #region Controller Methods
        // GET: CCRMComplaintLoggingMaster
        public ActionResult Index()
        {
           
            if (Convert.ToString(Session["UserType"]) == "A" || Convert.ToInt32(Session["Admin Manager"]) > 0)
            {
                return View("/Views/CCRM/CCRMComplaintLoggingMaster/Index.cshtml");
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
                CCRMComplaintLoggingMasterViewModel model = new CCRMComplaintLoggingMasterViewModel();
                CCRMComplaintLoggingMasterSearchRequest searchRequest = new CCRMComplaintLoggingMasterSearchRequest();
                //*********************MCStatus*********************//
                List<SelectListItem> MachineStatus = new List<SelectListItem>();
                ViewBag.MachineStatus = new SelectList(MachineStatus, "Value", "Text");
                List<SelectListItem> li_MachineStatus = new List<SelectListItem>();

                if (model.CCRMComplaintLoggingMasterDTO.MachineStatus > 0)
                {
                    li_MachineStatus.Add(new SelectListItem { Text = "BreakDown", Value = "1" });
                    li_MachineStatus.Add(new SelectListItem { Text = "Running", Value = "2" });
                    // li_LocationType.Add(new SelectListItem { Text = "None", Value = "3" });
                    //ViewData["SerialAndBatchManagedBy"] = li_SerialAndBatchManagedBy;
                    ViewData["MachineStatus"] = new SelectList(li_MachineStatus, "Value", "Text", (model.CCRMComplaintLoggingMasterDTO.MachineStatus).ToString().Trim());
                }
                else
                {

                    li_MachineStatus.Add(new SelectListItem { Text = "BreakDown", Value = "1" });
                    li_MachineStatus.Add(new SelectListItem { Text = "Running", Value = "2" });
                    // li_LocationType.Add(new SelectListItem { Text = "None", Value = "3" });
                    ViewData["MachineStatus"] = li_MachineStatus;
                }
                //*********************CallStatus*********************//
                List<SelectListItem> CallStatus = new List<SelectListItem>();
                ViewBag.CallStatus = new SelectList(CallStatus, "Value", "Text");
                List<SelectListItem> li_CallStatus = new List<SelectListItem>();

                if (model.CCRMComplaintLoggingMasterDTO.CallStatus > 0)
                {
                    li_CallStatus.Add(new SelectListItem { Text = "Pending", Value = "1" });
                    li_CallStatus.Add(new SelectListItem { Text = "Complete", Value = "2" });
                    li_CallStatus.Add(new SelectListItem { Text = "BreakDown", Value = "3" });
                    //ViewData["SerialAndBatchManagedBy"] = li_SerialAndBatchManagedBy;
                    ViewData["CallStatus"] = new SelectList(li_CallStatus, "Value", "Text", (model.CCRMComplaintLoggingMasterDTO.CallStatus).ToString().Trim());
                }
                else
                {

                    li_CallStatus.Add(new SelectListItem { Text = "Pending", Value = "1" });
                    li_CallStatus.Add(new SelectListItem { Text = "Complete", Value = "2" });
                    li_CallStatus.Add(new SelectListItem { Text = "BreakDown", Value = "3" });
                    ViewData["CallStatus"] = li_CallStatus;
                }

                //*********************Priority*********************//
                List<SelectListItem> Priority = new List<SelectListItem>();
                ViewBag.Priority = new SelectList(Priority, "Value", "Text");
                List<SelectListItem> li_Priority = new List<SelectListItem>();

                if (model.CCRMComplaintLoggingMasterDTO.Priority > 0)
                {
                    li_Priority.Add(new SelectListItem { Text = "Emergency", Value = "1" });
                    li_Priority.Add(new SelectListItem { Text = "High", Value = "2" });
                    li_Priority.Add(new SelectListItem { Text = "Medium", Value = "3" });
                    li_Priority.Add(new SelectListItem { Text = "Low", Value = "4" });
                    //ViewData["SerialAndBatchManagedBy"] = li_SerialAndBatchManagedBy;
                    ViewData["Priority"] = new SelectList(li_Priority, "Value", "Text", (model.CCRMComplaintLoggingMasterDTO.Priority).ToString().Trim());
                }
                else
                {

                    li_Priority.Add(new SelectListItem { Text = "Emergency", Value = "1" });
                    li_Priority.Add(new SelectListItem { Text = "High", Value = "2" });
                    li_Priority.Add(new SelectListItem { Text = "Medium", Value = "3" });
                    li_Priority.Add(new SelectListItem { Text = "Low", Value = "4" });
                    ViewData["Priority"] = li_Priority;
                }
                //*********************CCRMServiceCallTypes*********************//
                List<CCRMServiceCallTypes> CCRMServiceCallTypes = GetCCRMServiceCallTypes();
                List<SelectListItem> CCRMServiceCallTypesList = new List<SelectListItem>();
                foreach (CCRMServiceCallTypes item in CCRMServiceCallTypes)
                {
                    CCRMServiceCallTypesList.Add(new SelectListItem { Text = item.CallTypeCode, Value = Convert.ToString(item.ID) });
                }
                ViewBag.CCRMServiceCallTypesList = new SelectList(CCRMServiceCallTypesList, "Value", "Text", model.CallTypeID);
                //*********************CCRMAreaPatchMaster*********************//
                List<CCRMAreaPatchMaster> CCRMAreaPatchMaster = GetCCRMAreaPatchMaster();
                List<SelectListItem> CCRMAreaPatchMasterList = new List<SelectListItem>();
                foreach (CCRMAreaPatchMaster item in CCRMAreaPatchMaster)
                {
                    CCRMAreaPatchMasterList.Add(new SelectListItem { Text = item.AreaPatchName, Value = Convert.ToString(item.ID) });
                }
                ViewBag.CCRMAreaPatchMasterList = new SelectList(CCRMAreaPatchMasterList, "Value", "Text", model.EngineerID);
                //*********************EmployeeSrviveEngg*********************//
                List<EmpEmployeeMaster> EmpEmployeeMaster = GetEmpEmployeeMasterService();
                List<SelectListItem> EmpEmployeeMasterList = new List<SelectListItem>();
                foreach (EmpEmployeeMaster item in EmpEmployeeMaster)
                {
                    EmpEmployeeMasterList.Add(new SelectListItem { Text = item.EmployeeName, Value = Convert.ToString(item.EmployeeID) });
                }
                ViewBag.EmpEmployeeMasterList = new SelectList(EmpEmployeeMasterList, "Value", "Text", model.EngineerID);
                //*********************CCRMMIFMasterAndDetails*********************//
                //List<CCRMMIFMasterAndDetails> CCRMMIFMasterAndDetails = GetCCRMMIFMasterAndDetailsCallerName();
                //List<SelectListItem> CCRMMIFMasterAndDetailsList = new List<SelectListItem>();
                //foreach (CCRMMIFMasterAndDetails item in CCRMMIFMasterAndDetails)
                //{
                //    CCRMMIFMasterAndDetailsList.Add(new SelectListItem { Text = item.KeyOperatorName, Value = Convert.ToString(item.ID) });
                //}
                //ViewBag.CCRMMIFMasterAndDetailsList = new SelectList(CCRMMIFMasterAndDetailsList, "Value", "Text", model.CallerName);
                //*****************************************//
                searchRequest.ConnectionString = _connectioString;
                searchRequest.CCRMComplaintLoggingMasterID = Convert.ToInt32(!string.IsNullOrEmpty(actionMode) ? actionMode : null);

                IBaseEntityCollectionResponse<CCRMComplaintLoggingMaster> baseEntityCollectionResponse = _CCRMComplaintLoggingMasterBA.GetListOfPriviousCallByID(searchRequest);

                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        model.PriviousCallByCCRMComplaintLoggingMasterID = baseEntityCollectionResponse.CollectionResponse.ToList();

                    }
                }
                //******************************************//
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/CCRM/CCRMComplaintLoggingMaster/List.cshtml", model);
               // return PartialView(objuser);
            
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
            CCRMComplaintLoggingMasterViewModel model = new CCRMComplaintLoggingMasterViewModel();
            //*********************MCStatus*********************//
            List<SelectListItem> MachineStatus = new List<SelectListItem>();
            ViewBag.MachineStatus = new SelectList(MachineStatus, "Value", "Text");
            List<SelectListItem> li_MachineStatus = new List<SelectListItem>();

            if (model.CCRMComplaintLoggingMasterDTO.MachineStatus > 0)
            {
                li_MachineStatus.Add(new SelectListItem { Text = "BreakDown", Value = "1" });
                li_MachineStatus.Add(new SelectListItem { Text = "Running", Value = "2" });
                // li_LocationType.Add(new SelectListItem { Text = "None", Value = "3" });
                //ViewData["SerialAndBatchManagedBy"] = li_SerialAndBatchManagedBy;
                ViewData["MachineStatus"] = new SelectList(li_MachineStatus, "Value", "Text", (model.CCRMComplaintLoggingMasterDTO.MachineStatus).ToString().Trim());
            }
            else
            {

                li_MachineStatus.Add(new SelectListItem { Text = "BreakDown", Value = "1" });
                li_MachineStatus.Add(new SelectListItem { Text = "Running", Value = "2" });
                // li_LocationType.Add(new SelectListItem { Text = "None", Value = "3" });
                ViewData["MachineStatus"] = li_MachineStatus;
            }
            //*********************CallStatus*********************//
            List<SelectListItem> CallStatus = new List<SelectListItem>();
            ViewBag.CallStatus = new SelectList(CallStatus, "Value", "Text");
            List<SelectListItem> li_CallStatus = new List<SelectListItem>();

            if (model.CCRMComplaintLoggingMasterDTO.CallStatus > 0)
            {
                li_CallStatus.Add(new SelectListItem { Text = "Pending", Value = "1" });
                li_CallStatus.Add(new SelectListItem { Text = "Complete", Value = "2" });
                li_CallStatus.Add(new SelectListItem { Text = "BreakDown", Value = "3" });
                //ViewData["SerialAndBatchManagedBy"] = li_SerialAndBatchManagedBy;
                ViewData["CallStatus"] = new SelectList(li_CallStatus, "Value", "Text", (model.CCRMComplaintLoggingMasterDTO.CallStatus).ToString().Trim());
            }
            else
            {

                li_CallStatus.Add(new SelectListItem { Text = "Pending", Value = "1" });
                li_CallStatus.Add(new SelectListItem { Text = "Complete", Value = "2" });
                li_CallStatus.Add(new SelectListItem { Text = "BreakDown", Value = "3" });
                ViewData["CallStatus"] = li_CallStatus;
            }
            //*********************Priority*********************//
            List<SelectListItem> Priority = new List<SelectListItem>();
            ViewBag.Priority = new SelectList(Priority, "Value", "Text");
            List<SelectListItem> li_Priority = new List<SelectListItem>();

            if (model.CCRMComplaintLoggingMasterDTO.Priority > 0)
            {
                li_Priority.Add(new SelectListItem { Text = "Emergency", Value = "1" });
                li_Priority.Add(new SelectListItem { Text = "High", Value = "2" });
                li_Priority.Add(new SelectListItem { Text = "Medium", Value = "3" });
                li_Priority.Add(new SelectListItem { Text = "Low", Value = "4" });
                //ViewData["SerialAndBatchManagedBy"] = li_SerialAndBatchManagedBy;
                ViewData["Priority"] = new SelectList(li_Priority, "Value", "Text", (model.CCRMComplaintLoggingMasterDTO.Priority).ToString().Trim());
            }
            else
            {

                li_Priority.Add(new SelectListItem { Text = "Emergency", Value = "1" });
                li_Priority.Add(new SelectListItem { Text = "High", Value = "2" });
                li_Priority.Add(new SelectListItem { Text = "Medium", Value = "3" });
                li_Priority.Add(new SelectListItem { Text = "Low", Value = "4" });
                ViewData["Priority"] = li_Priority;
            }
            //*********************CCRMServiceCallTypes*********************//
            List<CCRMServiceCallTypes> CCRMServiceCallTypes = GetCCRMServiceCallTypes();
            List<SelectListItem> CCRMServiceCallTypesList = new List<SelectListItem>();
            foreach (CCRMServiceCallTypes item in CCRMServiceCallTypes)
            {
                CCRMServiceCallTypesList.Add(new SelectListItem { Text = item.CallTypeCode, Value = Convert.ToString(item.ID) });
            }
            ViewBag.CCRMServiceCallTypesList = new SelectList(CCRMServiceCallTypesList, "Value", "Text", model.CallTypeID);
            //*********************CCRMAreaPatchMaster*********************//
            List<CCRMAreaPatchMaster> CCRMAreaPatchMaster = GetCCRMAreaPatchMaster();
            List<SelectListItem> CCRMAreaPatchMasterList = new List<SelectListItem>();
            foreach (CCRMAreaPatchMaster item in CCRMAreaPatchMaster)
            {
                CCRMAreaPatchMasterList.Add(new SelectListItem { Text = item.AreaPatchName, Value = Convert.ToString(item.ID) });
            }
            ViewBag.CCRMAreaPatchMasterList = new SelectList(CCRMAreaPatchMasterList, "Value", "Text", model.EngineerID);
            //*********************CCRMMIFMasterAndDetails*********************//
            //List<CCRMMIFMasterAndDetails> CCRMMIFMasterAndDetails = GetCCRMMIFMasterAndDetailsCallerName();
            //List<SelectListItem> CCRMMIFMasterAndDetailsList = new List<SelectListItem>();
            //foreach (CCRMMIFMasterAndDetails item in CCRMMIFMasterAndDetails)
            //{
            //    CCRMMIFMasterAndDetailsList.Add(new SelectListItem { Text = item.KeyOperatorName, Value = Convert.ToString(item.ID) });
            //}
            //ViewBag.CCRMMIFMasterAndDetailsList = new SelectList(CCRMMIFMasterAndDetailsList, "Value", "Text", model.CallerName);


            return PartialView("/Views/CCRM/CCRMComplaintLoggingMaster/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(CCRMComplaintLoggingMasterViewModel model)
        {
            try
            {
                //if (ModelState.IsValid)
                //{
                    if (model != null && model.CCRMComplaintLoggingMasterDTO != null)
                    {
                        model.CCRMComplaintLoggingMasterDTO.ConnectionString = _connectioString;

                        model.CCRMComplaintLoggingMasterDTO.CallDate = model.CallDate;
                        model.CCRMComplaintLoggingMasterDTO.CallTktNo = model.CallTktNo;
                        model.CCRMComplaintLoggingMasterDTO.CallTypeID = model.CallTypeID;
                        model.CCRMComplaintLoggingMasterDTO.SerialNo = model.SerialNo;
                        model.CCRMComplaintLoggingMasterDTO.MIFName = model.MIFName;
                        model.CCRMComplaintLoggingMasterDTO.CompanyCallDate = model.CompanyCallDate;
                        model.CCRMComplaintLoggingMasterDTO.CompanyCallNo = model.CompanyCallNo;
                        model.CCRMComplaintLoggingMasterDTO.CallerName = model.CallerName;
                        model.CCRMComplaintLoggingMasterDTO.CallerPh = model.CallerPh;
                        model.CCRMComplaintLoggingMasterDTO.EmailID = model.EmailID;
                        model.CCRMComplaintLoggingMasterDTO.SymptomID = model.SymptomID;
                        model.CCRMComplaintLoggingMasterDTO.SymptomCode = model.SymptomCode;
                        model.CCRMComplaintLoggingMasterDTO.SymptomTitle = model.SymptomTitle;
                        model.CCRMComplaintLoggingMasterDTO.ComPlaint = model.ComPlaint;
                        model.CCRMComplaintLoggingMasterDTO.MachineStatus = model.MachineStatus;
                        model.CCRMComplaintLoggingMasterDTO.Priority = model.Priority;
                        model.CCRMComplaintLoggingMasterDTO.A4Mono = model.A4Mono;
                        model.CCRMComplaintLoggingMasterDTO.A4Col = model.A4Col;
                        model.CCRMComplaintLoggingMasterDTO.A3Mono = model.A3Mono;
                        model.CCRMComplaintLoggingMasterDTO.A3Col = model.A3Col;
                        model.CCRMComplaintLoggingMasterDTO.CallCharges = model.CallCharges;
                        model.CCRMComplaintLoggingMasterDTO.CustApproval = model.CustApproval;
                        model.CCRMComplaintLoggingMasterDTO.TeleSolution = model.TeleSolution;
                        model.CCRMComplaintLoggingMasterDTO.Solution = model.Solution;
                        model.CCRMComplaintLoggingMasterDTO.SSSApproval = model.SSSApproval;
                        model.CCRMComplaintLoggingMasterDTO.SplRemarks= model.SplRemarks;
                        model.CCRMComplaintLoggingMasterDTO.SplInstructions = model.SplInstructions;
                        model.CCRMComplaintLoggingMasterDTO.MCAddress = model.MCAddress;
                        model.CCRMComplaintLoggingMasterDTO.CustomertID = model.CustomertID;
                        model.CCRMComplaintLoggingMasterDTO.CustomerName = model.CustomerName;
                        model.CCRMComplaintLoggingMasterDTO.KeyOperatorID = model.KeyOperatorID;
                        model.CCRMComplaintLoggingMasterDTO.KeyOperator = model.KeyOperator;

                        model.CCRMComplaintLoggingMasterDTO.Phoneno = model.Phoneno;
                        model.CCRMComplaintLoggingMasterDTO.ModelNo = model.ModelNo;
                        model.CCRMComplaintLoggingMasterDTO.ContractTypeId = model.ContractTypeId;
                        model.CCRMComplaintLoggingMasterDTO.ContractType = model.ContractType;
                        model.CCRMComplaintLoggingMasterDTO.ContractNo = model.ContractNo;
                        model.CCRMComplaintLoggingMasterDTO.ContOpDate = model.ContOpDate;
                        model.CCRMComplaintLoggingMasterDTO.ContClDate = model.ContClDate;
                        model.CCRMComplaintLoggingMasterDTO.EngineerID = model.EngineerID;
                        model.CCRMComplaintLoggingMasterDTO.EnggMobNo = model.EnggMobNo;
                        model.CCRMComplaintLoggingMasterDTO.ItemDescription = model.ItemDescription;
                        model.CCRMComplaintLoggingMasterDTO.ComplaintSrNo = model.ComplaintSrNo;
                        // model.CCRMComplaintLoggingMasterDTO.ID = model.ID;
                        model.CCRMComplaintLoggingMasterDTO.MIFID = model.MIFID;
                        model.CCRMComplaintLoggingMasterDTO.CallerFlag = model.CallerFlag;
                        model.CCRMComplaintLoggingMasterDTO.Allotment = model.Allotment;
                        model.CCRMComplaintLoggingMasterDTO.CallStatus = model.CallStatus;
                        model.CCRMComplaintLoggingMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                   
                        IBaseEntityResponse<CCRMComplaintLoggingMaster> response = _CCRMComplaintLoggingMasterBA.InsertCCRMComplaintLoggingMaster(model.CCRMComplaintLoggingMasterDTO);
                        model.CCRMComplaintLoggingMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);

                    if (response.Entity != null)
                    {
                        if (response.Entity.ErrorCode == 0)
                        {
                            List<CCRMComplaintLoggingMaster> list = getDeviceToken();
                           // Dictionary<string, Double> MachineAddress = getLatLongFromAddress(model.MCAddress);
                            foreach (CCRMComplaintLoggingMaster ComplaintMaster in list)
                            {
                             /*   Dictionary<string, Double> latlongs = new Dictionary<string, double>
                            {
                                { "DestinationLatitude",MachineAddress["Latitude"] },
                                { "DestinationLongitude",MachineAddress["Longitude"] },
                                { "CurrentLatitude",Convert.ToDouble(ComplaintMaster.Latitude) },
                                { "CurrentLongitude",Convert.ToDouble(ComplaintMaster.Longitude) }
                            };*/
                             
                               // if (getDistanceBetweenTwoLatLong(latlongs) < 50)
                                {
                                    if (ComplaintMaster.DeviceToken != string.Empty)
                                    {
                                        RunningBackgroundThread(ComplaintMaster.DeviceToken);
                                    }
                                }
                            }
                        }
                    }
                    

                }
                   return Json(model.CCRMComplaintLoggingMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
                //}
                //else
                //{
                //    return Json("Please review your form");
                //}
            }
            catch (Exception)
            {
                throw;
            }
        }

        void SendNotification(string DeviceToken)
        {
            SendGCMNotification(DeviceToken);
        }

         void RunningBackgroundThread(string DeviceToken)
        {
            Thread background = new Thread(() => SendNotification(DeviceToken));
            background.IsBackground = true;
            background.Start();
        }

        private List<CCRMComplaintLoggingMaster> getDeviceToken()
        {
            CCRMComplaintLoggingMasterSearchRequest searchRequest = new CCRMComplaintLoggingMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            List<CCRMComplaintLoggingMaster> listCCRMComplaintLoggingMaster = new List<CCRMComplaintLoggingMaster>();
            IBaseEntityCollectionResponse<CCRMComplaintLoggingMaster> baseEntityCollectionResponse = _CCRMComplaintLoggingMasterBA.GetDeviceToken(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listCCRMComplaintLoggingMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listCCRMComplaintLoggingMaster;
        }

        [HttpGet]
        public ActionResult Edit(Int32 id)
        {
            CCRMComplaintLoggingMasterViewModel model = new CCRMComplaintLoggingMasterViewModel();
            //*********************CCRMServiceCallTypes*********************//
            List<CCRMServiceCallTypes> CCRMServiceCallTypes = GetCCRMServiceCallTypes();
            List<SelectListItem> CCRMServiceCallTypesList = new List<SelectListItem>();
            foreach (CCRMServiceCallTypes item in CCRMServiceCallTypes)
            {
                CCRMServiceCallTypesList.Add(new SelectListItem { Text = item.CallTypeCode, Value = Convert.ToString(item.ID) });
            }
            ViewBag.CCRMServiceCallTypesList = new SelectList(CCRMServiceCallTypesList, "Value", "Text", model.CallTypeID);
            //*********************CCRMAreaPatchMaster*********************//
            List<CCRMAreaPatchMaster> CCRMAreaPatchMaster = GetCCRMAreaPatchMaster();
            List<SelectListItem> CCRMAreaPatchMasterList = new List<SelectListItem>();
            foreach (CCRMAreaPatchMaster item in CCRMAreaPatchMaster)
            {
                CCRMAreaPatchMasterList.Add(new SelectListItem { Text = item.AreaPatchName, Value = Convert.ToString(item.ID) });
            }
            ViewBag.CCRMAreaPatchMasterList = new SelectList(CCRMAreaPatchMasterList, "Value", "Text", model.EngineerID);
            //*********************EmployeeSrviveEngg*********************//
            List<EmpEmployeeMaster> EmpEmployeeMaster = GetEmpEmployeeMasterService();
            List<SelectListItem> EmpEmployeeMasterList = new List<SelectListItem>();
            foreach (EmpEmployeeMaster item in EmpEmployeeMaster)
            {
                EmpEmployeeMasterList.Add(new SelectListItem { Text = item.EmployeeName, Value = Convert.ToString(item.EmployeeID) });
            }
            ViewBag.EmpEmployeeMasterList = new SelectList(EmpEmployeeMasterList, "Value", "Text", model.EngineerID);
            //*********************Priority*********************//
            List<SelectListItem> li = new List<SelectListItem>();
            // li1.Add(new SelectListItem { Text = "--Select--", Value = " " });
            li.Add(new SelectListItem { Text = "Emergency", Value = "1" });
            li.Add(new SelectListItem { Text = "High", Value = "2" });
            li.Add(new SelectListItem { Text = "Medium", Value = "3" });
            li.Add(new SelectListItem { Text = "Low", Value = "4" });
            ViewData["Priority"] = li;
            //*********************MCStatus*********************//
            List<SelectListItem> li1 = new List<SelectListItem>();
            // li1.Add(new SelectListItem { Text = "--Select--", Value = " " });
            li1.Add(new SelectListItem { Text = "BreakDown", Value = "1" });
            li1.Add(new SelectListItem { Text = "Running", Value = "2" });
       
            ViewData["MachineStatus"] = li1;
            //*********************CallStatus*********************//
            List<SelectListItem> li2 = new List<SelectListItem>();
            // li1.Add(new SelectListItem { Text = "--Select--", Value = " " });
            li2.Add(new SelectListItem { Text = "Pending", Value = "1" });
            li2.Add(new SelectListItem { Text = "Complete", Value = "2" });
            li2.Add(new SelectListItem { Text = "BreakDown", Value = "3" });
            ViewData["CallStatus"] = li2;
            try
            {



                model.CCRMComplaintLoggingMasterDTO = new CCRMComplaintLoggingMaster();
                model.CCRMComplaintLoggingMasterDTO.ID = id;
                model.CCRMComplaintLoggingMasterDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<CCRMComplaintLoggingMaster> response = _CCRMComplaintLoggingMasterBA.SelectByID(model.CCRMComplaintLoggingMasterDTO);
                if (response != null && response.Entity != null)
                {
                    model.CCRMComplaintLoggingMasterDTO.ID = response.Entity.ID;
                    model.CCRMComplaintLoggingMasterDTO.CallDate = response.Entity.CallDate;
                    model.CCRMComplaintLoggingMasterDTO.CallTktNo = response.Entity.CallTktNo;
                    model.CCRMComplaintLoggingMasterDTO.CallTypeID = response.Entity.CallTypeID;
                    model.CCRMComplaintLoggingMasterDTO.SerialNo = response.Entity.SerialNo;
                    model.CCRMComplaintLoggingMasterDTO.MIFName = response.Entity.MIFName;
                    model.CCRMComplaintLoggingMasterDTO.CompanyCallDate = response.Entity.CompanyCallDate;
                    model.CCRMComplaintLoggingMasterDTO.CompanyCallNo = response.Entity.CompanyCallNo;
                    model.CCRMComplaintLoggingMasterDTO.CallerName = response.Entity.CallerName;
                    model.CCRMComplaintLoggingMasterDTO.CallerPh = response.Entity.CallerPh;
                    model.CCRMComplaintLoggingMasterDTO.EmailID = response.Entity.EmailID;
                    model.CCRMComplaintLoggingMasterDTO.SymptomID = response.Entity.SymptomID;
                    model.CCRMComplaintLoggingMasterDTO.SymptomCode = response.Entity.SymptomCode;
                    model.CCRMComplaintLoggingMasterDTO.SymptomTitle = response.Entity.SymptomTitle;
                    model.CCRMComplaintLoggingMasterDTO.ComPlaint = response.Entity.ComPlaint;
                    model.CCRMComplaintLoggingMasterDTO.MachineStatus = response.Entity.MachineStatus;
                    model.CCRMComplaintLoggingMasterDTO.Priority = response.Entity.Priority;
                    model.CCRMComplaintLoggingMasterDTO.A4Mono = response.Entity.A4Mono;
                    model.CCRMComplaintLoggingMasterDTO.A4Col = response.Entity.A4Col;
                    model.CCRMComplaintLoggingMasterDTO.A3Mono = response.Entity.A3Mono;
                    model.CCRMComplaintLoggingMasterDTO.A3Col = response.Entity.A3Col;
                    model.CCRMComplaintLoggingMasterDTO.CallCharges = response.Entity.CallCharges;
                    model.CCRMComplaintLoggingMasterDTO.CustApproval = response.Entity.CustApproval;
                    model.CCRMComplaintLoggingMasterDTO.TeleSolution = response.Entity.TeleSolution;
                    model.CCRMComplaintLoggingMasterDTO.Solution = response.Entity.Solution;
                    model.CCRMComplaintLoggingMasterDTO.SSSApproval = response.Entity.SSSApproval;
                    model.CCRMComplaintLoggingMasterDTO.SplRemarks = response.Entity.SplRemarks;
                    model.CCRMComplaintLoggingMasterDTO.SplInstructions = response.Entity.SplInstructions;
                    model.CCRMComplaintLoggingMasterDTO.MCAddress = response.Entity.MCAddress;
                    model.CCRMComplaintLoggingMasterDTO.CustomertID = response.Entity.CustomertID;
                    model.CCRMComplaintLoggingMasterDTO.CustomerName = response.Entity.CustomerName;
                    model.CCRMComplaintLoggingMasterDTO.KeyOperatorID = response.Entity.KeyOperatorID;
                    model.CCRMComplaintLoggingMasterDTO.KeyOperator = response.Entity.KeyOperator;
                    model.CCRMComplaintLoggingMasterDTO.Phoneno = response.Entity.Phoneno;
                    model.CCRMComplaintLoggingMasterDTO.ModelNo = response.Entity.ModelNo;
                   // model.CCRMComplaintLoggingMasterDTO.ContractTypeId = response.Entity.ContractTypeId;
                    model.CCRMComplaintLoggingMasterDTO.ContractType = response.Entity.ContractType;
                    model.CCRMComplaintLoggingMasterDTO.ContractNo = response.Entity.ContractNo;
                    model.CCRMComplaintLoggingMasterDTO.ContOpDate = response.Entity.ContOpDate;
                    model.CCRMComplaintLoggingMasterDTO.ContClDate = response.Entity.ContClDate;
                    model.CCRMComplaintLoggingMasterDTO.EngineerID = response.Entity.EngineerID;
                    model.CCRMComplaintLoggingMasterDTO.EnggMobNo = response.Entity.EnggMobNo;
                    model.CCRMComplaintLoggingMasterDTO.ItemDescription = response.Entity.ItemDescription;
                    model.CCRMComplaintLoggingMasterDTO.CentreCode = response.Entity.CentreCode;
                    model.CCRMComplaintLoggingMasterDTO.AdminRoleMasterID = response.Entity.AdminRoleMasterID;
                    model.CCRMComplaintLoggingMasterDTO.RightName = response.Entity.RightName;
                    model.CCRMComplaintLoggingMasterDTO.EmployeeID = response.Entity.EmployeeID;
                    model.CCRMComplaintLoggingMasterDTO.EmployeeCode = response.Entity.EmployeeCode;
                    model.CCRMComplaintLoggingMasterDTO.EmployeeName = response.Entity.EmployeeName;
                    model.CCRMComplaintLoggingMasterDTO.ComplaintSrNo = response.Entity.ComplaintSrNo;
                    model.CCRMComplaintLoggingMasterDTO.MIFID = response.Entity.MIFID;
                    model.CCRMComplaintLoggingMasterDTO.Allotment = response.Entity.Allotment;
                    model.CCRMComplaintLoggingMasterDTO.CallStatus = response.Entity.CallStatus;
                }
                ViewData["Priority"] = new SelectList(li, "Value", "Text", (model.Priority).ToString().Trim());
                ViewData["MachineStatus"] = new SelectList(li1, "Value", "Text", (model.MachineStatus).ToString().Trim());
                ViewData["CallStatus"] = new SelectList(li2, "Value", "Text", (model.CallStatus).ToString().Trim());

                return PartialView("/Views/CCRM/CCRMComplaintLoggingMaster/Edit.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(CCRMComplaintLoggingMasterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.CCRMComplaintLoggingMasterDTO != null)
                    {
                        if (model != null && model.CCRMComplaintLoggingMasterDTO != null)
                        {
                            model.CCRMComplaintLoggingMasterDTO.ConnectionString = _connectioString;

                            model.CCRMComplaintLoggingMasterDTO.CallDate = model.CallDate;
                            model.CCRMComplaintLoggingMasterDTO.CallTktNo = model.CallTktNo;
                            model.CCRMComplaintLoggingMasterDTO.CallTypeID = model.CallTypeID;
                            model.CCRMComplaintLoggingMasterDTO.SerialNo = model.SerialNo;
                            model.CCRMComplaintLoggingMasterDTO.MIFName = model.MIFName;
                            model.CCRMComplaintLoggingMasterDTO.CompanyCallDate = model.CompanyCallDate;
                            model.CCRMComplaintLoggingMasterDTO.CompanyCallNo = model.CompanyCallNo;
                            model.CCRMComplaintLoggingMasterDTO.CallerName = model.CallerName;
                            model.CCRMComplaintLoggingMasterDTO.CallerPh = model.CallerPh;
                            model.CCRMComplaintLoggingMasterDTO.EmailID = model.EmailID;
                            model.CCRMComplaintLoggingMasterDTO.SymptomID = model.SymptomID;
                            model.CCRMComplaintLoggingMasterDTO.SymptomCode = model.SymptomCode;
                            model.CCRMComplaintLoggingMasterDTO.SymptomTitle = model.SymptomTitle;
                            model.CCRMComplaintLoggingMasterDTO.ComPlaint = model.ComPlaint;
                            model.CCRMComplaintLoggingMasterDTO.MachineStatus = model.MachineStatus;
                            model.CCRMComplaintLoggingMasterDTO.Priority = model.Priority;
                            model.CCRMComplaintLoggingMasterDTO.A4Mono = model.A4Mono;
                            model.CCRMComplaintLoggingMasterDTO.A4Col = model.A4Col;
                            model.CCRMComplaintLoggingMasterDTO.A3Mono = model.A3Mono;
                            model.CCRMComplaintLoggingMasterDTO.A3Col = model.A3Col;
                            model.CCRMComplaintLoggingMasterDTO.CallCharges = model.CallCharges;
                            model.CCRMComplaintLoggingMasterDTO.CustApproval = model.CustApproval;
                            model.CCRMComplaintLoggingMasterDTO.TeleSolution = model.TeleSolution;
                            model.CCRMComplaintLoggingMasterDTO.Solution = model.Solution;
                            model.CCRMComplaintLoggingMasterDTO.SSSApproval = model.SSSApproval;
                            model.CCRMComplaintLoggingMasterDTO.SplRemarks = model.SplRemarks;
                            model.CCRMComplaintLoggingMasterDTO.SplInstructions = model.SplInstructions;
                            model.CCRMComplaintLoggingMasterDTO.MCAddress = model.MCAddress;
                            model.CCRMComplaintLoggingMasterDTO.CustomertID = model.CustomertID;
                            model.CCRMComplaintLoggingMasterDTO.CustomerName = model.CustomerName;
                            model.CCRMComplaintLoggingMasterDTO.KeyOperatorID = model.KeyOperatorID;
                            model.CCRMComplaintLoggingMasterDTO.KeyOperator = model.KeyOperator;
                            model.CCRMComplaintLoggingMasterDTO.Phoneno = model.Phoneno;
                            model.CCRMComplaintLoggingMasterDTO.ModelNo = model.ModelNo;
                           // model.CCRMComplaintLoggingMasterDTO.ContractTypeId = model.ContractTypeId;
                            model.CCRMComplaintLoggingMasterDTO.ContractType = model.ContractType;
                            model.CCRMComplaintLoggingMasterDTO.ContractNo = model.ContractNo;
                            model.CCRMComplaintLoggingMasterDTO.ContOpDate = model.ContOpDate;
                            model.CCRMComplaintLoggingMasterDTO.ContClDate = model.ContClDate;
                            model.CCRMComplaintLoggingMasterDTO.EngineerID = model.EngineerID;
                            model.CCRMComplaintLoggingMasterDTO.EnggMobNo = model.EnggMobNo;
                            model.CCRMComplaintLoggingMasterDTO.ItemDescription = model.ItemDescription;
                            model.CCRMComplaintLoggingMasterDTO.ComplaintSrNo = model.ComplaintSrNo;
                            model.CCRMComplaintLoggingMasterDTO.MIFID = model.MIFID;
                            model.CCRMComplaintLoggingMasterDTO.Allotment = model.Allotment;
                            model.CCRMComplaintLoggingMasterDTO.CallStatus = model.CallStatus;
                            model.CCRMComplaintLoggingMasterDTO.ID = model.ID;
                            model.CCRMComplaintLoggingMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                            IBaseEntityResponse<CCRMComplaintLoggingMaster> response = _CCRMComplaintLoggingMasterBA.UpdateCCRMComplaintLoggingMaster(model.CCRMComplaintLoggingMasterDTO);
                            model.CCRMComplaintLoggingMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                        }
                    }
                    return Json(model.CCRMComplaintLoggingMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
            CCRMComplaintLoggingMasterViewModel model = new CCRMComplaintLoggingMasterViewModel();
            try
            {
                if (ID > 0)
                {
                    if (ID > 0)
                    {
                        CCRMComplaintLoggingMaster CCRMComplaintLoggingMasterDTO = new CCRMComplaintLoggingMaster();
                        CCRMComplaintLoggingMasterDTO.ConnectionString = _connectioString;
                        CCRMComplaintLoggingMasterDTO.ID = ID;
                        CCRMComplaintLoggingMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<CCRMComplaintLoggingMaster> response = _CCRMComplaintLoggingMasterBA.DeleteCCRMComplaintLoggingMaster(CCRMComplaintLoggingMasterDTO);
                        model.CCRMComplaintLoggingMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
                    }
                    return Json(model.CCRMComplaintLoggingMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public IEnumerable<CCRMComplaintLoggingMasterViewModel> GetCCRMComplaintLoggingMaster(out int TotalRecords)
        {
            CCRMComplaintLoggingMasterSearchRequest searchRequest = new CCRMComplaintLoggingMasterSearchRequest();
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
            List<CCRMComplaintLoggingMasterViewModel> listCCRMComplaintLoggingMasterViewModel = new List<CCRMComplaintLoggingMasterViewModel>();
            List<CCRMComplaintLoggingMaster> listCCRMComplaintLoggingMaster = new List<CCRMComplaintLoggingMaster>();
            IBaseEntityCollectionResponse<CCRMComplaintLoggingMaster> baseEntityCollectionResponse = _CCRMComplaintLoggingMasterBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listCCRMComplaintLoggingMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (CCRMComplaintLoggingMaster item in listCCRMComplaintLoggingMaster)
                    {
                        CCRMComplaintLoggingMasterViewModel CCRMComplaintLoggingMasterViewModel = new CCRMComplaintLoggingMasterViewModel();
                        CCRMComplaintLoggingMasterViewModel.CCRMComplaintLoggingMasterDTO = item;
                        listCCRMComplaintLoggingMasterViewModel.Add(CCRMComplaintLoggingMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listCCRMComplaintLoggingMasterViewModel;
        }
        protected List<CCRMServiceCallTypes> GetCCRMServiceCallTypes()
        {
            CCRMServiceCallTypesSearchRequest searchRequest = new CCRMServiceCallTypesSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<CCRMServiceCallTypes> listCCRMServiceCallTypes = new List<CCRMServiceCallTypes>();
            IBaseEntityCollectionResponse<CCRMServiceCallTypes> baseEntityCollectionResponse = _CCRMServiceCallTypesBA.GetCCRMServiceCallTypesList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listCCRMServiceCallTypes = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listCCRMServiceCallTypes;
        }
        protected List<CCRMAreaPatchMaster> GetCCRMAreaPatchMaster()
        {
            CCRMAreaPatchMasterSearchRequest searchRequest = new CCRMAreaPatchMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<CCRMAreaPatchMaster> listCCRMAreaPatchMaster = new List<CCRMAreaPatchMaster>();
            IBaseEntityCollectionResponse<CCRMAreaPatchMaster> baseEntityCollectionResponse = _CCRMAreaPatchMasterBA.GetCCRMAreaPatchMasterList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listCCRMAreaPatchMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listCCRMAreaPatchMaster;
        }
        [HttpPost]
        public JsonResult GetCCRMCallerSearchList(string term)
        {
            CCRMComplaintLoggingMasterSearchRequest searchRequest = new CCRMComplaintLoggingMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            searchRequest.SearchWord = term;
            List<CCRMComplaintLoggingMaster> listCCRMComplaintLoggingMaster = new List<CCRMComplaintLoggingMaster>();
            IBaseEntityCollectionResponse<CCRMComplaintLoggingMaster> baseEntityCollectionResponse = _CCRMComplaintLoggingMasterBA.GetCCRMCallerSearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listCCRMComplaintLoggingMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            var result = (from r in listCCRMComplaintLoggingMaster
                          select new
                          {
                              CallerID = r.CallerID,
                              CallerName = r.CallerName,
                              CallerPh = r.CallerPh,
                              EmailID = r.EmailID,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        //protected List<CCRMMIFMasterAndDetails> GetCCRMMIFMasterAndDetailsCallerName()
        //{
        //    CCRMMIFMasterAndDetailsSearchRequest searchRequest = new CCRMMIFMasterAndDetailsSearchRequest();
        //    searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        //    List<CCRMMIFMasterAndDetails> listCCRMMIFMasterAndDetails = new List<CCRMMIFMasterAndDetails>();
        //    IBaseEntityCollectionResponse<CCRMMIFMasterAndDetails> baseEntityCollectionResponse = _CCRMMIFMasterAndDetailsBA.GetCCRMMIFMasterAndDetailsCallerName(searchRequest);
        //    if (baseEntityCollectionResponse != null)
        //    {
        //        if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
        //        {
        //            listCCRMMIFMasterAndDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
        //        }
        //    }
        //    return listCCRMMIFMasterAndDetails;
        //}

        public JsonResult GetCCRMComplaintLoggingMasterSearchList(string term,string CallTktNo)
        {
            CCRMComplaintLoggingMasterSearchRequest searchRequest = new CCRMComplaintLoggingMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            searchRequest.SearchWord = term;
            searchRequest.CallTktNo = CallTktNo;
            List<CCRMComplaintLoggingMaster> listCCRMComplaintLoggingMaster = new List<CCRMComplaintLoggingMaster>();
            IBaseEntityCollectionResponse<CCRMComplaintLoggingMaster> baseEntityCollectionResponse = _CCRMComplaintLoggingMasterBA.GetCCRMComplaintLoggingMasterSearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listCCRMComplaintLoggingMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            var result = (from r in listCCRMComplaintLoggingMaster
                          select new
                          {
                              ID = r.ID,
                              CallerName = r.CallerName,
                              CallerPh = r.CallerPh,
                              //CallTktNo=r.CallTktNo,

                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion
        // AjaxHandler Method
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc
            IEnumerable<CCRMComplaintLoggingMasterViewModel> filteredCCRMComplaintLoggingMasterViewModel;

            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "CallDate";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "CallDate Like '%" + param.sSearch + "%' or MIFName Like '%" + param.sSearch + "%'or CallTypeName Like '%" + param.sSearch + "%'";
                        //_searchBy = "ID Like '%" + param.sSearch + "%' or FeedbackPoints Like '%" + param.sSearch + "%'";
                        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "MIFName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "CallDate Like '%" + param.sSearch + "%' or MIFName Like '%" + param.sSearch + "%'or CallTypeName Like '%" + param.sSearch + "%'";
                        // _searchBy = "ID Like '%" + param.sSearch + "%' or FeedbackPoints Like '%" + param.sSearch + "%'";
                        //this "if" block is added for search functionality
                    }
                    break;
                case 2:
                    _sortBy = "CallTypeName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "CallDate Like '%" + param.sSearch + "%' or MIFName Like '%" + param.sSearch + "%'or CallTypeName Like '%" + param.sSearch + "%'";
                        //_searchBy = "ID Like '%" + param.sSearch + "%' or FeedbackPoints Like '%" + param.sSearch + "%'";
                        //this "if" block is added for search functionality
                    }
                    break;
                    

            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            filteredCCRMComplaintLoggingMasterViewModel = GetCCRMComplaintLoggingMaster(out TotalRecords);
            var records = filteredCCRMComplaintLoggingMasterViewModel.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.CallDate), Convert.ToString(c.ID), Convert.ToString(c.MIFName), Convert.ToString(c.CallTypeName) };

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}