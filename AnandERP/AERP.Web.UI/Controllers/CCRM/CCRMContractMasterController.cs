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
using System.IO;
//using System.Data.OleDb;
//using System.Data.SqlClient;
using System.Web.Hosting;
using System.Data;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Text.RegularExpressions;
using System.Collections;
using AERP.Web.UI.HtmlHelperExtensions;
using System.Threading;

namespace AERP.Web.UI.Controllers
{
    public class CCRMContractMasterController : BaseController
    {
        ICCRMContractMasterBA _CCRMContractMasterBA = null;
      
        ICCRMContractTypesMasterBA _CCRMContractTypesMasterBA = null;
        ICCRMBillTypeMasterBA _CCRMBillTypeMasterBA = null;
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

        public CCRMContractMasterController()
        {
            _CCRMContractMasterBA = new CCRMContractMasterBA();
            _CCRMContractTypesMasterBA = new CCRMContractTypesMasterBA();
            _CCRMBillTypeMasterBA = new CCRMBillTypeMasterBA();
        }
        #region Controller Methods
        // GET: CCRMContractMaster
        public ActionResult Index()
        {
            if (Convert.ToString(Session["UserType"]) == "A" || Convert.ToInt32(Session["Admin Manager"]) > 0)
            {
                return View("/Views/CCRM/CCRMContractMaster/Index.cshtml");
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
                CCRMContractMasterViewModel model = new CCRMContractMasterViewModel();
                //*************** Drop down list for account session************//
                List<AccountSessionMaster> AccountSessionMasterList = GetAllAccountSession();
                List<SelectListItem> AccountSessionList = new List<SelectListItem>();
                foreach (AccountSessionMaster item in AccountSessionMasterList)
                {
                    AccountSessionList.Add(new SelectListItem { Text = item.SessionName, Value = Convert.ToString(item.ID) });
                }
                ViewBag.AccountSessionList = new SelectList(AccountSessionList, "Value", "Text", model.FinancialyearID);
                //*********************CCRMContractTypeMaster*********************//
                List<CCRMContractTypesMaster> CCRMContractTypesMaster = GetCCRMContractTypesMaster();
                List<SelectListItem> CCRMContractTypesMasterList = new List<SelectListItem>();
                foreach (CCRMContractTypesMaster item in CCRMContractTypesMaster)
                {
                    CCRMContractTypesMasterList.Add(new SelectListItem { Text = item.ContractCode, Value = Convert.ToString(item.ContractTypeId) });
                }
                ViewBag.CCRMContractTypesMasterList = new SelectList(CCRMContractTypesMasterList, "Value", "Text", model.ContractTypeId);
                //*********************CCRMBillTypeMaster*********************//
                List<CCRMBillTypeMaster> CCRMBillTypeMaster = GetCCRMBillTypeMaster();
                List<SelectListItem> CCRMBillTypeMasterList = new List<SelectListItem>();
                foreach (CCRMBillTypeMaster item in CCRMBillTypeMaster)
                {
                    CCRMBillTypeMasterList.Add(new SelectListItem { Text = item.BillTypeName, Value = Convert.ToString(item.ID) });
                }
                ViewBag.CCRMBillTypeMasterList = new SelectList(CCRMBillTypeMasterList, "Value", "Text", model.BillTypeId);
                //*********************ContractStatus*********************//
                List<SelectListItem> ContractStatus = new List<SelectListItem>();
                ViewBag.ContractStatus = new SelectList(ContractStatus, "Value", "Text");
                List<SelectListItem> li_ContractStatus = new List<SelectListItem>();

                if (model.CCRMContractMasterDTO.ContractStatus > 0)
                {
                    li_ContractStatus.Add(new SelectListItem { Text = "Open", Value = "1" });
                    li_ContractStatus.Add(new SelectListItem { Text = "Close", Value = "2" });
                    // li_LocationType.Add(new SelectListItem { Text = "None", Value = "3" });
                    //ViewData["SerialAndBatchManagedBy"] = li_SerialAndBatchManagedBy;
                    ViewData["ContractStatus"] = new SelectList(li_ContractStatus, "Value", "Text", (model.CCRMContractMasterDTO.ContractStatus).ToString().Trim());
                }
                else
                {

                    li_ContractStatus.Add(new SelectListItem { Text = "Open", Value = "1" });
                    li_ContractStatus.Add(new SelectListItem { Text = "Close", Value = "2" });
                    // li_LocationType.Add(new SelectListItem { Text = "None", Value = "3" });
                    ViewData["ContractStatus"] = li_ContractStatus;
                }
                //*********************ApplicableMonth*********************//
                List<SelectListItem> ApplicableMonth = new List<SelectListItem>();
                ViewBag.ApplicableMonth = new SelectList(ApplicableMonth, "Value", "Text");
                List<SelectListItem> li_ApplicableMonth = new List<SelectListItem>();

                if (model.CCRMContractMasterDTO.ApplicableMonth > 0)
                {
                    li_ApplicableMonth.Add(new SelectListItem { Text = "Jan", Value = "1" });
                    li_ApplicableMonth.Add(new SelectListItem { Text = "Feb", Value = "2" });
                    li_ApplicableMonth.Add(new SelectListItem { Text = "March", Value = "3" });
                    li_ApplicableMonth.Add(new SelectListItem { Text = "April", Value = "4" });
                    li_ApplicableMonth.Add(new SelectListItem { Text = "May", Value = "5" });
                    li_ApplicableMonth.Add(new SelectListItem { Text = "June", Value = "6" });
                    li_ApplicableMonth.Add(new SelectListItem { Text = "July", Value = "7" });
                    li_ApplicableMonth.Add(new SelectListItem { Text = "Aug", Value = "8" });
                    li_ApplicableMonth.Add(new SelectListItem { Text = "Sept", Value = "9" });
                    li_ApplicableMonth.Add(new SelectListItem { Text = "Octom", Value = "10" });
                    li_ApplicableMonth.Add(new SelectListItem { Text = "Nov", Value = "11" });
                    li_ApplicableMonth.Add(new SelectListItem { Text = "Decem", Value = "12" });
                    //ViewData["SerialAndBatchManagedBy"] = li_SerialAndBatchManagedBy;
                    ViewData["ApplicableMonth"] = new SelectList(li_ApplicableMonth, "Value", "Text", (model.CCRMContractMasterDTO.ApplicableMonth).ToString().Trim());
                }
                else
                {

                    li_ApplicableMonth.Add(new SelectListItem { Text = "Jan", Value = "1" });
                    li_ApplicableMonth.Add(new SelectListItem { Text = "Feb", Value = "2" });
                    li_ApplicableMonth.Add(new SelectListItem { Text = "March", Value = "3" });
                    li_ApplicableMonth.Add(new SelectListItem { Text = "April", Value = "4" });
                    li_ApplicableMonth.Add(new SelectListItem { Text = "May", Value = "5" });
                    li_ApplicableMonth.Add(new SelectListItem { Text = "June", Value = "6" });
                    li_ApplicableMonth.Add(new SelectListItem { Text = "July", Value = "7" });
                    li_ApplicableMonth.Add(new SelectListItem { Text = "Aug", Value = "8" });
                    li_ApplicableMonth.Add(new SelectListItem { Text = "Sept", Value = "9" });
                    li_ApplicableMonth.Add(new SelectListItem { Text = "Octom", Value = "10" });
                    li_ApplicableMonth.Add(new SelectListItem { Text = "Nov", Value = "11" });
                    li_ApplicableMonth.Add(new SelectListItem { Text = "Decem", Value = "12" });
                    ViewData["ApplicableMonth"] = li_ApplicableMonth;
                }
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/CCRM/CCRMContractMaster/List.cshtml", model);
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
            CCRMContractMasterViewModel model = new CCRMContractMasterViewModel();
            //*************** Drop down list for account session************//
            List<AccountSessionMaster> AccountSessionMasterList = GetAllAccountSession();
            List<SelectListItem> AccountSessionList = new List<SelectListItem>();
            foreach (AccountSessionMaster item in AccountSessionMasterList)
            {
                AccountSessionList.Add(new SelectListItem { Text = item.SessionName, Value = Convert.ToString(item.ID) });
            }
            ViewBag.AccountSessionList = new SelectList(AccountSessionList, "Value", "Text", model.FinancialyearID);
            //*********************CCRMContractTypeMaster*********************//
            List<CCRMContractTypesMaster> CCRMContractTypesMaster = GetCCRMContractTypesMaster();
            List<SelectListItem> CCRMContractTypesMasterList = new List<SelectListItem>();
            foreach (CCRMContractTypesMaster item in CCRMContractTypesMaster)
            {
                CCRMContractTypesMasterList.Add(new SelectListItem { Text = item.ContractName, Value = Convert.ToString(item.ContractTypeId) });
            }
            ViewBag.CCRMContractTypesMasterList = new SelectList(CCRMContractTypesMasterList, "Value", "Text", model.ContractTypeId);
            //*********************CCRMBillTypeMaster*********************//
            List<CCRMBillTypeMaster> CCRMBillTypeMaster = GetCCRMBillTypeMaster();
            List<SelectListItem> CCRMBillTypeMasterList = new List<SelectListItem>();
            foreach (CCRMBillTypeMaster item in CCRMBillTypeMaster)
            {
                CCRMBillTypeMasterList.Add(new SelectListItem { Text = item.BillTypeName, Value = Convert.ToString(item.ID) });
            }
            ViewBag.CCRMBillTypeMasterList = new SelectList(CCRMBillTypeMasterList, "Value", "Text", model.BillTypeId);
            //*********************ContractStatus*********************//
            List<SelectListItem> ContractStatus = new List<SelectListItem>();
            ViewBag.ContractStatus = new SelectList(ContractStatus, "Value", "Text");
            List<SelectListItem> li_ContractStatus = new List<SelectListItem>();
           
            if (model.CCRMContractMasterDTO.ContractStatus > 0)
            {
                li_ContractStatus.Add(new SelectListItem { Text = "Open", Value = "1" });
                li_ContractStatus.Add(new SelectListItem { Text = "Close", Value = "2" });
                // li_LocationType.Add(new SelectListItem { Text = "None", Value = "3" });
                //ViewData["SerialAndBatchManagedBy"] = li_SerialAndBatchManagedBy;
                ViewData["ContractStatus"] = new SelectList(li_ContractStatus, "Value", "Text", (model.CCRMContractMasterDTO.ContractStatus).ToString().Trim());
            }
            else
            {

                li_ContractStatus.Add(new SelectListItem { Text = "Open", Value = "1" });
                li_ContractStatus.Add(new SelectListItem { Text = "Close", Value = "2" });
                // li_LocationType.Add(new SelectListItem { Text = "None", Value = "3" });
                ViewData["ContractStatus"] = li_ContractStatus;
            }
            //*********************ApplicableMonth*********************//
            List<SelectListItem> ApplicableMonth = new List<SelectListItem>();
            ViewBag.ApplicableMonth = new SelectList(ApplicableMonth, "Value", "Text");
            List<SelectListItem> li_ApplicableMonth = new List<SelectListItem>();

            if (model.CCRMContractMasterDTO.ApplicableMonth > 0)
            {
                li_ApplicableMonth.Add(new SelectListItem { Text = "Jan", Value = "1" });
                li_ApplicableMonth.Add(new SelectListItem { Text = "Feb", Value = "2" });
                li_ApplicableMonth.Add(new SelectListItem { Text = "March", Value = "3" });
                li_ApplicableMonth.Add(new SelectListItem { Text = "April", Value = "4" });
                li_ApplicableMonth.Add(new SelectListItem { Text = "May", Value = "5" });
                li_ApplicableMonth.Add(new SelectListItem { Text = "June", Value = "6" });
                li_ApplicableMonth.Add(new SelectListItem { Text = "July", Value = "7" });
                li_ApplicableMonth.Add(new SelectListItem { Text = "Aug", Value = "8" });
                li_ApplicableMonth.Add(new SelectListItem { Text = "Sept", Value = "9" });
                li_ApplicableMonth.Add(new SelectListItem { Text = "Octom", Value = "10" });
                li_ApplicableMonth.Add(new SelectListItem { Text = "Nov", Value = "11" });
                li_ApplicableMonth.Add(new SelectListItem { Text = "Decem", Value = "12" });
                //ViewData["SerialAndBatchManagedBy"] = li_SerialAndBatchManagedBy;
                ViewData["ApplicableMonth"] = new SelectList(li_ApplicableMonth, "Value", "Text", (model.CCRMContractMasterDTO.ApplicableMonth).ToString().Trim());
            }
            else
            {

                li_ApplicableMonth.Add(new SelectListItem { Text = "Jan", Value = "1" });
                li_ApplicableMonth.Add(new SelectListItem { Text = "Feb", Value = "2" });
                li_ApplicableMonth.Add(new SelectListItem { Text = "March", Value = "3" });
                li_ApplicableMonth.Add(new SelectListItem { Text = "April", Value = "4" });
                li_ApplicableMonth.Add(new SelectListItem { Text = "May", Value = "5" });
                li_ApplicableMonth.Add(new SelectListItem { Text = "June", Value = "6" });
                li_ApplicableMonth.Add(new SelectListItem { Text = "July", Value = "7" });
                li_ApplicableMonth.Add(new SelectListItem { Text = "Aug", Value = "8" });
                li_ApplicableMonth.Add(new SelectListItem { Text = "Sept", Value = "9" });
                li_ApplicableMonth.Add(new SelectListItem { Text = "Octom", Value = "10" });
                li_ApplicableMonth.Add(new SelectListItem { Text = "Nov", Value = "11" });
                li_ApplicableMonth.Add(new SelectListItem { Text = "Decem", Value = "12" });
                ViewData["ApplicableMonth"] = li_ApplicableMonth;
            }

            return PartialView("/Views/CCRM/CCRMContractMaster/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(CCRMContractMasterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.CCRMContractMasterDTO != null)
                    {
                        model.CCRMContractMasterDTO.ConnectionString = _connectioString;

                        model.CCRMContractMasterDTO.FinancialyearID = model.FinancialyearID;
                        model.CCRMContractMasterDTO.ContractDate = model.ContractDate;
                        model.CCRMContractMasterDTO.ContractTypeId = model.ContractTypeId;
                        model.CCRMContractMasterDTO.ContractNo = model.ContractNo;
                        model.CCRMContractMasterDTO.SerialNo = model.SerialNo;
                        model.CCRMContractMasterDTO.ModelNo = model.ModelNo;
                        model.CCRMContractMasterDTO.MIFName = model.MIFName;
                        model.CCRMContractMasterDTO.MIFAddress = model.MIFAddress;
                       // model.CCRMContractMasterDTO.CustomerCode = model.CustomerCode;
                        model.CCRMContractMasterDTO.CustomerMasterID = model.CustomerMasterID;
                        model.CCRMContractMasterDTO.CustomerAddress = model.CustomerAddress;
                        model.CCRMContractMasterDTO.Colour = model.Colour;
                        model.CCRMContractMasterDTO.PaperSize = model.PaperSize;
                        model.CCRMContractMasterDTO.ContractOpDate = model.ContractOpDate;
                        model.CCRMContractMasterDTO.ContractClosingDate = model.ContractClosingDate;
                        model.CCRMContractMasterDTO.CustOrderNo = model.CustOrderNo;
                        model.CCRMContractMasterDTO.CustOrderDate = model.CustOrderDate;
                        model.CCRMContractMasterDTO.BillTypeId = model.BillTypeId;
                        //model.CCRMContractMasterDTO.BillType = model.BillType;
                        model.CCRMContractMasterDTO.ContractStatus = model.ContractStatus;
                        model.CCRMContractMasterDTO.StartReadA4Mono = model.StartReadA4Mono;
                        model.CCRMContractMasterDTO.StartReadA4Col = model.StartReadA4Col;
                        model.CCRMContractMasterDTO.StartReadA3Mono = model.StartReadA3Mono;
                        model.CCRMContractMasterDTO.StartReadA3Col = model.StartReadA3Col;
                        model.CCRMContractMasterDTO.RentPerCopyA4Mono = model.RentPerCopyA4Mono;
                        model.CCRMContractMasterDTO.RentPerCopyA4Col = model.RentPerCopyA4Col;
                        model.CCRMContractMasterDTO.RentPerCopyA3Mono = model.RentPerCopyA3Mono;
                        model.CCRMContractMasterDTO.RentPerCopyA3Col = model.RentPerCopyA3Col;
                        model.CCRMContractMasterDTO.FreeCopiesA4Mono = model.FreeCopiesA4Mono;
                        model.CCRMContractMasterDTO.FreeCopiesA4Col = model.FreeCopiesA4Col;
                        model.CCRMContractMasterDTO.FreeCopiesA3Mono = model.FreeCopiesA3Mono;
                        model.CCRMContractMasterDTO.FreeCopiesA3Col = model.FreeCopiesA3Col;
                        model.CCRMContractMasterDTO.MinCopiesA4Mono = model.MinCopiesA4Mono;
                        model.CCRMContractMasterDTO.MinCopiesA4Col = model.MinCopiesA4Col;
                        model.CCRMContractMasterDTO.MinCopiesA3Mono = model.MinCopiesA3Mono;
                        model.CCRMContractMasterDTO.MinCopiesA3Col = model.MinCopiesA3Col;
                        model.CCRMContractMasterDTO.TotalFreeA4Mono = model.TotalFreeA4Mono;
                        model.CCRMContractMasterDTO.TotalFreeA4Col = model.TotalFreeA4Col;
                        model.CCRMContractMasterDTO.TotalFreeA3Mono = model.TotalFreeA3Mono;
                        model.CCRMContractMasterDTO.TotalFreeA3Col = model.TotalFreeA3Col;
                        model.CCRMContractMasterDTO.InitFreeCopiesA4Mono = model.InitFreeCopiesA4Mono;
                        model.CCRMContractMasterDTO.InitFreeCopiesA4Col = model.InitFreeCopiesA4Col;
                        model.CCRMContractMasterDTO.InitFreeCopiesA3Mono = model.InitFreeCopiesA3Mono;
                        model.CCRMContractMasterDTO.InitFreeCopiesA3Col = model.InitFreeCopiesA3Col;
                        model.CCRMContractMasterDTO.ContractValue = model.ContractValue;
                        model.CCRMContractMasterDTO.BilledValue = model.BilledValue;
                        model.CCRMContractMasterDTO.RentalAmt = model.RentalAmt;
                        model.CCRMContractMasterDTO.WastePerc = model.WastePerc;
                        model.CCRMContractMasterDTO.AnnualCharges = model.AnnualCharges;
                        model.CCRMContractMasterDTO.ApplicableMonth = model.ApplicableMonth;
                        model.CCRMContractMasterDTO.BasicCharges = model.BasicCharges;
                        model.CCRMContractMasterDTO.PMPeriod = model.PMPeriod;
                        model.CCRMContractMasterDTO.CallsAllowed = model.CallsAllowed;
                        model.CCRMContractMasterDTO.Remarks = model.Remarks;
                        model.CCRMContractMasterDTO.CustomerName = model.CustomerName;
                        model.CCRMContractMasterDTO.ItemDescription = model.ItemDescription;
                        model.CCRMContractMasterDTO.ContractName = model.ContractName;
                        model.CCRMContractMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<CCRMContractMaster> response = _CCRMContractMasterBA.InsertCCRMContractMaster(model.CCRMContractMasterDTO);
                        model.CCRMContractMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);

                    }
                    return Json(model.CCRMContractMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        [HttpGet]
        public ActionResult Edit(Int32 id)
        {
            CCRMContractMasterViewModel model = new CCRMContractMasterViewModel();
            //*************** Drop down list for account session************//
            List<AccountSessionMaster> AccountSessionMasterList = GetAllAccountSession();
            List<SelectListItem> AccountSessionList = new List<SelectListItem>();
            foreach (AccountSessionMaster item in AccountSessionMasterList)
            {
                AccountSessionList.Add(new SelectListItem { Text = item.SessionName, Value = Convert.ToString(item.ID) });
            }
            ViewBag.AccountSessionList = new SelectList(AccountSessionList, "Value", "Text", model.FinancialyearID);
            //*********************CCRMContractTypeMaster*********************//
            List<CCRMContractTypesMaster> CCRMContractTypesMaster = GetCCRMContractTypesMaster();
            List<SelectListItem> CCRMContractTypesMasterList = new List<SelectListItem>();
            foreach (CCRMContractTypesMaster item in CCRMContractTypesMaster)
            {
                CCRMContractTypesMasterList.Add(new SelectListItem { Text = item.ContractName, Value = Convert.ToString(item.ContractTypeId) });
            }
            ViewBag.CCRMContractTypesMasterList = new SelectList(CCRMContractTypesMasterList, "Value", "Text", model.ContractTypeId);
            //*********************CCRMBillTypeMaster*********************//
            List<CCRMBillTypeMaster> CCRMBillTypeMaster = GetCCRMBillTypeMaster();
            List<SelectListItem> CCRMBillTypeMasterList = new List<SelectListItem>();
            foreach (CCRMBillTypeMaster item in CCRMBillTypeMaster)
            {
                CCRMBillTypeMasterList.Add(new SelectListItem { Text = item.BillTypeName, Value = Convert.ToString(item.ID) });
            }
            ViewBag.CCRMBillTypeMasterList = new SelectList(CCRMBillTypeMasterList, "Value", "Text", model.BillTypeId);
            //*********************ApplicableMonth*********************//
            List<SelectListItem> li = new List<SelectListItem>();
            // li1.Add(new SelectListItem { Text = "--Select--", Value = " " });
            li.Add(new SelectListItem { Text = "Jan", Value = "1" });
            li.Add(new SelectListItem { Text = "Feb", Value = "2" });
            li.Add(new SelectListItem { Text = "March", Value = "3" });
            li.Add(new SelectListItem { Text = "April", Value = "4" });
            li.Add(new SelectListItem { Text = "May", Value = "5" });
            li.Add(new SelectListItem { Text = "June", Value = "6" });
            li.Add(new SelectListItem { Text = "July", Value = "7" });
            li.Add(new SelectListItem { Text = "Aug", Value = "8" });
            li.Add(new SelectListItem { Text = "Sept", Value = "9" });
            li.Add(new SelectListItem { Text = "Octom", Value = "10" });
            li.Add(new SelectListItem { Text = "Nov", Value = "11" });
            li.Add(new SelectListItem { Text = "Decem", Value = "12" });
          
            ViewData["ApplicableMonth"] = li;
            //*********************ContractStatus*********************//
            List<SelectListItem> li1 = new List<SelectListItem>();
            // li1.Add(new SelectListItem { Text = "--Select--", Value = " " });
            li1.Add(new SelectListItem { Text = "Open", Value = "1" });
            li1.Add(new SelectListItem { Text = "Close", Value = "2" });
           
            ViewData["ContractStatus"] = li1;
            try
            {



                model.CCRMContractMasterDTO = new CCRMContractMaster();
                model.CCRMContractMasterDTO.ID = id;
                model.CCRMContractMasterDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<CCRMContractMaster> response = _CCRMContractMasterBA.SelectByID(model.CCRMContractMasterDTO);
                if (response != null && response.Entity != null)
                {
                    model.CCRMContractMasterDTO.ID = response.Entity.ID;
                    model.CCRMContractMasterDTO.FinancialyearID = response.Entity.FinancialyearID;
                    model.CCRMContractMasterDTO.ContractDate = response.Entity.ContractDate;
                    model.CCRMContractMasterDTO.ContractTypeId = response.Entity.ContractTypeId;
                    model.CCRMContractMasterDTO.ContractNo = response.Entity.ContractNo;
                    model.CCRMContractMasterDTO.SerialNo = response.Entity.SerialNo;
                    model.CCRMContractMasterDTO.ModelNo = response.Entity.ModelNo;
                    model.CCRMContractMasterDTO.MIFName = response.Entity.MIFName;
                    model.CCRMContractMasterDTO.MIFAddress = response.Entity.MIFAddress;
                    model.CCRMContractMasterDTO.CustomerMasterID = response.Entity.CustomerMasterID;
                    model.CCRMContractMasterDTO.CustomerAddress = response.Entity.CustomerAddress;
                    model.CCRMContractMasterDTO.Colour = response.Entity.Colour;
                    model.CCRMContractMasterDTO.PaperSize = response.Entity.PaperSize;
                    model.CCRMContractMasterDTO.ContractOpDate = response.Entity.ContractOpDate;
                    model.CCRMContractMasterDTO.ContractClosingDate = response.Entity.ContractClosingDate;
                    model.CCRMContractMasterDTO.CustOrderNo = response.Entity.CustOrderNo;
                    model.CCRMContractMasterDTO.CustOrderDate = response.Entity.CustOrderDate;
                    model.CCRMContractMasterDTO.BillTypeId = response.Entity.BillTypeId;
                    model.CCRMContractMasterDTO.ContractStatus = response.Entity.ContractStatus;
                    model.CCRMContractMasterDTO.StartReadA4Mono = response.Entity.StartReadA4Mono;
                    model.CCRMContractMasterDTO.StartReadA4Col = response.Entity.StartReadA4Col;
                    model.CCRMContractMasterDTO.StartReadA3Mono = response.Entity.StartReadA3Mono;
                    model.CCRMContractMasterDTO.StartReadA3Col = response.Entity.StartReadA3Col;
                    model.CCRMContractMasterDTO.RentPerCopyA4Mono = response.Entity.RentPerCopyA4Mono;
                    model.CCRMContractMasterDTO.RentPerCopyA4Col = response.Entity.RentPerCopyA4Col;
                    model.CCRMContractMasterDTO.RentPerCopyA3Mono = response.Entity.RentPerCopyA3Mono;
                    model.CCRMContractMasterDTO.RentPerCopyA3Col = response.Entity.RentPerCopyA3Col;
                    model.CCRMContractMasterDTO.FreeCopiesA4Mono = response.Entity.FreeCopiesA4Mono;
                    model.CCRMContractMasterDTO.FreeCopiesA4Col = response.Entity.FreeCopiesA4Col;
                    model.CCRMContractMasterDTO.FreeCopiesA3Mono = response.Entity.FreeCopiesA3Mono;
                    model.CCRMContractMasterDTO.FreeCopiesA3Col = response.Entity.FreeCopiesA3Col;
                    model.CCRMContractMasterDTO.MinCopiesA4Mono = response.Entity.MinCopiesA4Mono;
                    model.CCRMContractMasterDTO.MinCopiesA4Col = response.Entity.MinCopiesA4Col;
                    model.CCRMContractMasterDTO.MinCopiesA3Mono = response.Entity.MinCopiesA3Mono;
                    model.CCRMContractMasterDTO.MinCopiesA3Col = response.Entity.MinCopiesA3Col;
                    model.CCRMContractMasterDTO.TotalFreeA4Mono = response.Entity.TotalFreeA4Mono;
                    model.CCRMContractMasterDTO.TotalFreeA4Col = response.Entity.TotalFreeA4Col;
                    model.CCRMContractMasterDTO.TotalFreeA3Mono = response.Entity.TotalFreeA3Mono;
                    model.CCRMContractMasterDTO.TotalFreeA3Col = response.Entity.TotalFreeA3Col;
                    model.CCRMContractMasterDTO.InitFreeCopiesA4Mono = response.Entity.InitFreeCopiesA4Mono;
                    model.CCRMContractMasterDTO.InitFreeCopiesA4Col = response.Entity.InitFreeCopiesA4Col;
                    model.CCRMContractMasterDTO.InitFreeCopiesA3Mono = response.Entity.InitFreeCopiesA3Mono;
                    model.CCRMContractMasterDTO.InitFreeCopiesA3Col = response.Entity.InitFreeCopiesA3Col;
                    model.CCRMContractMasterDTO.ContractValue = response.Entity.ContractValue;
                    model.CCRMContractMasterDTO.BilledValue = response.Entity.BilledValue;
                    model.CCRMContractMasterDTO.RentalAmt = response.Entity.RentalAmt;
                    model.CCRMContractMasterDTO.WastePerc = response.Entity.WastePerc;
                    model.CCRMContractMasterDTO.AnnualCharges = response.Entity.AnnualCharges;
                    model.CCRMContractMasterDTO.ApplicableMonth = response.Entity.ApplicableMonth;
                    model.CCRMContractMasterDTO.BasicCharges = response.Entity.BasicCharges;
                    model.CCRMContractMasterDTO.PMPeriod = response.Entity.PMPeriod;
                    model.CCRMContractMasterDTO.CallsAllowed = response.Entity.CallsAllowed;
                    model.CCRMContractMasterDTO.Remarks = response.Entity.Remarks;
                    model.CCRMContractMasterDTO.CustomerName = response.Entity.CustomerName;
                    model.CCRMContractMasterDTO.ItemDescription = response.Entity.ItemDescription;

                }
                ViewData["ApplicableMonth"] = new SelectList(li, "Value", "Text", (model.ApplicableMonth).ToString().Trim());
                ViewData["ContractStatus"] = new SelectList(li1, "Value", "Text", (model.ContractStatus).ToString().Trim());
                return PartialView("/Views/CCRM/CCRMContractMaster/Edit.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(CCRMContractMasterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.CCRMContractMasterDTO != null)
                    {
                        if (model != null && model.CCRMContractMasterDTO != null)
                        {
                            model.CCRMContractMasterDTO.ConnectionString = _connectioString;
                            model.CCRMContractMasterDTO.FinancialyearID = model.FinancialyearID;
                            model.CCRMContractMasterDTO.ContractDate = model.ContractDate;
                            model.CCRMContractMasterDTO.ContractTypeId = model.ContractTypeId;
                           // model.CCRMContractMasterDTO.ContractNo = model.ContractNo;
                            model.CCRMContractMasterDTO.SerialNo = model.SerialNo;
                            model.CCRMContractMasterDTO.ModelNo = model.ModelNo;
                            model.CCRMContractMasterDTO.MIFName = model.MIFName;
                            model.CCRMContractMasterDTO.MIFAddress = model.MIFAddress;
                            // model.CCRMContractMasterDTO.CustomerCode = model.CustomerCode;
                            model.CCRMContractMasterDTO.CustomerMasterID = model.CustomerMasterID;
                            model.CCRMContractMasterDTO.CustomerAddress = model.CustomerAddress;
                            model.CCRMContractMasterDTO.Colour = model.Colour;
                            model.CCRMContractMasterDTO.PaperSize = model.PaperSize;
                            model.CCRMContractMasterDTO.ContractOpDate = model.ContractOpDate;
                            model.CCRMContractMasterDTO.ContractClosingDate = model.ContractClosingDate;
                            model.CCRMContractMasterDTO.CustOrderNo = model.CustOrderNo;
                            model.CCRMContractMasterDTO.CustOrderDate = model.CustOrderDate;
                            model.CCRMContractMasterDTO.BillTypeId = model.BillTypeId;
                            //model.CCRMContractMasterDTO.BillType = model.BillType;
                            model.CCRMContractMasterDTO.ContractStatus = model.ContractStatus;
                            model.CCRMContractMasterDTO.StartReadA4Mono = model.StartReadA4Mono;
                            model.CCRMContractMasterDTO.StartReadA4Col = model.StartReadA4Col;
                            model.CCRMContractMasterDTO.StartReadA3Mono = model.StartReadA3Mono;
                            model.CCRMContractMasterDTO.StartReadA3Col = model.StartReadA3Col;
                            model.CCRMContractMasterDTO.RentPerCopyA4Mono = model.RentPerCopyA4Mono;
                            model.CCRMContractMasterDTO.RentPerCopyA4Col = model.RentPerCopyA4Col;
                            model.CCRMContractMasterDTO.RentPerCopyA3Mono = model.RentPerCopyA3Mono;
                            model.CCRMContractMasterDTO.RentPerCopyA3Col = model.RentPerCopyA3Col;
                            model.CCRMContractMasterDTO.FreeCopiesA4Mono = model.FreeCopiesA4Mono;
                            model.CCRMContractMasterDTO.FreeCopiesA4Col = model.FreeCopiesA4Col;
                            model.CCRMContractMasterDTO.FreeCopiesA3Mono = model.FreeCopiesA3Mono;
                            model.CCRMContractMasterDTO.FreeCopiesA3Col = model.FreeCopiesA3Col;
                            model.CCRMContractMasterDTO.MinCopiesA4Mono = model.MinCopiesA4Mono;
                            model.CCRMContractMasterDTO.MinCopiesA4Col = model.MinCopiesA4Col;
                            model.CCRMContractMasterDTO.MinCopiesA3Mono = model.MinCopiesA3Mono;
                            model.CCRMContractMasterDTO.MinCopiesA3Col = model.MinCopiesA3Col;
                            model.CCRMContractMasterDTO.TotalFreeA4Mono = model.TotalFreeA4Mono;
                            model.CCRMContractMasterDTO.TotalFreeA4Col = model.TotalFreeA4Col;
                            model.CCRMContractMasterDTO.TotalFreeA3Mono = model.TotalFreeA3Mono;
                            model.CCRMContractMasterDTO.TotalFreeA3Col = model.TotalFreeA3Col;
                            model.CCRMContractMasterDTO.InitFreeCopiesA4Mono = model.InitFreeCopiesA4Mono;
                            model.CCRMContractMasterDTO.InitFreeCopiesA4Col = model.InitFreeCopiesA4Col;
                            model.CCRMContractMasterDTO.InitFreeCopiesA3Mono = model.InitFreeCopiesA3Mono;
                            model.CCRMContractMasterDTO.InitFreeCopiesA3Col = model.InitFreeCopiesA3Col;
                            model.CCRMContractMasterDTO.ContractValue = model.ContractValue;
                            model.CCRMContractMasterDTO.BilledValue = model.BilledValue;
                            model.CCRMContractMasterDTO.RentalAmt = model.RentalAmt;
                            model.CCRMContractMasterDTO.WastePerc = model.WastePerc;
                            model.CCRMContractMasterDTO.AnnualCharges = model.AnnualCharges;
                            model.CCRMContractMasterDTO.ApplicableMonth = model.ApplicableMonth;
                            model.CCRMContractMasterDTO.BasicCharges = model.BasicCharges;
                            model.CCRMContractMasterDTO.PMPeriod = model.PMPeriod;
                            model.CCRMContractMasterDTO.CallsAllowed = model.CallsAllowed;
                            model.CCRMContractMasterDTO.Remarks = model.Remarks;
                            model.CCRMContractMasterDTO.CustomerName = model.CustomerName;
                            model.CCRMContractMasterDTO.ItemDescription = model.ItemDescription;
                            model.CCRMContractMasterDTO.ContractName = model.ContractName;

                            model.CCRMContractMasterDTO.ID = model.ID;
                            model.CCRMContractMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                            IBaseEntityResponse<CCRMContractMaster> response = _CCRMContractMasterBA.UpdateCCRMContractMaster(model.CCRMContractMasterDTO);
                            model.CCRMContractMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                        }
                    }
                    return Json(model.CCRMContractMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
            CCRMContractMasterViewModel model = new CCRMContractMasterViewModel();
            try
            {
                if (ID > 0)
                {
                    if (ID > 0)
                    {
                        CCRMContractMaster CCRMContractMasterDTO = new CCRMContractMaster();
                        CCRMContractMasterDTO.ConnectionString = _connectioString;
                        CCRMContractMasterDTO.ID = ID;
                        CCRMContractMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<CCRMContractMaster> response = _CCRMContractMasterBA.DeleteCCRMContractMaster(CCRMContractMasterDTO);
                        model.CCRMContractMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
                    }
                    return Json(model.CCRMContractMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public IEnumerable<CCRMContractMasterViewModel> GetCCRMContractMaster(out int TotalRecords)
        {
            CCRMContractMasterSearchRequest searchRequest = new CCRMContractMasterSearchRequest();
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
            List<CCRMContractMasterViewModel> listCCRMContractMasterViewModel = new List<CCRMContractMasterViewModel>();
            List<CCRMContractMaster> listCCRMContractMaster = new List<CCRMContractMaster>();
            IBaseEntityCollectionResponse<CCRMContractMaster> baseEntityCollectionResponse = _CCRMContractMasterBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listCCRMContractMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (CCRMContractMaster item in listCCRMContractMaster)
                    {
                        CCRMContractMasterViewModel CCRMContractMasterViewModel = new CCRMContractMasterViewModel();
                        CCRMContractMasterViewModel.CCRMContractMasterDTO = item;
                        listCCRMContractMasterViewModel.Add(CCRMContractMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listCCRMContractMasterViewModel;
        }
        protected List<CCRMContractTypesMaster> GetCCRMContractTypesMaster()
        {
            CCRMContractTypesMasterSearchRequest searchRequest = new CCRMContractTypesMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<CCRMContractTypesMaster> listCCRMContractTypesMaster = new List<CCRMContractTypesMaster>();
            IBaseEntityCollectionResponse<CCRMContractTypesMaster> baseEntityCollectionResponse = _CCRMContractTypesMasterBA.GetCCRMContractTypesMasterList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listCCRMContractTypesMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listCCRMContractTypesMaster;
        }
        protected List<CCRMBillTypeMaster> GetCCRMBillTypeMaster()
        {
            CCRMBillTypeMasterSearchRequest searchRequest = new CCRMBillTypeMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<CCRMBillTypeMaster> listCCRMBillTypeMaster = new List<CCRMBillTypeMaster>();
            IBaseEntityCollectionResponse<CCRMBillTypeMaster> baseEntityCollectionResponse = _CCRMBillTypeMasterBA.GetCCRMBillTypeMasterList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listCCRMBillTypeMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listCCRMBillTypeMaster;
        }
        #endregion
        // AjaxHandler Method
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc
            IEnumerable<CCRMContractMasterViewModel> filteredCCRMContractMasterViewModel;

            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "A.SerialNo";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "A.SerialNo Like '%" + param.sSearch + "%' or A.ContractNo Like '%" + param.sSearch + "%'or B.ContractName Like '%" + param.sSearch + "%'";
                        //_searchBy = "ID Like '%" + param.sSearch + "%' or FeedbackPoints Like '%" + param.sSearch + "%'";
                        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "A.ContractNo";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "A.SerialNo Like '%" + param.sSearch + "%' or A.ContractNo Like '%" + param.sSearch + "%'or B.ContractName Like '%" + param.sSearch + "%' ";
                        // _searchBy = "ID Like '%" + param.sSearch + "%' or FeedbackPoints Like '%" + param.sSearch + "%'";
                        //this "if" block is added for search functionality
                    }
                    break;
                case 2:
                    _sortBy = "B.ContractName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "A.SerialNo Like '%" + param.sSearch + "%' or A.ContractNo Like '%" + param.sSearch + "%'or B.ContractName Like '%" + param.sSearch + "%' ";
                        //_searchBy = "ID Like '%" + param.sSearch + "%' or FeedbackPoints Like '%" + param.sSearch + "%'";
                        //this "if" block is added for search functionality
                    }
                    break;


            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            filteredCCRMContractMasterViewModel = GetCCRMContractMaster(out TotalRecords);
            var records = filteredCCRMContractMasterViewModel.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { c.ContractTypeId.ToString(), Convert.ToString(c.ID), Convert.ToString(c.ContractNo), Convert.ToString(c.SerialNo), Convert.ToString(c.ContractName), Convert.ToString(c.ContractType) };

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}