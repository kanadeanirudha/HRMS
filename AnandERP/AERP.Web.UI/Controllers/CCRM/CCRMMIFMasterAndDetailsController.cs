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
    public class CCRMMIFMasterAndDetailsController : BaseController
    {
        ICCRMMIFMasterAndDetailsBA _CCRMMIFMasterAndDetailsBA = null;
        ICCRMCustomerSegementBA _CCRMCustomerSegementBA = null;
        ICCRMMachineFamilyMasterBA _CCRMMachineFamilyMasterBA = null;
        ICCRMLocationTypeMasterBA _CCRMLocationTypeMasterBA = null;
        ICCRMEngineersGroupMasterBA _CCRMEngineersGroupMasterBA = null;
        IEmpEmployeeMasterBA _EmpEmployeeMasterBA = null;

        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public CCRMMIFMasterAndDetailsController()
        {
            _CCRMMIFMasterAndDetailsBA = new CCRMMIFMasterAndDetailsBA();
            _CCRMCustomerSegementBA = new CCRMCustomerSegementBA();
            _CCRMMachineFamilyMasterBA = new CCRMMachineFamilyMasterBA();
            _CCRMLocationTypeMasterBA = new CCRMLocationTypeMasterBA();
            _CCRMEngineersGroupMasterBA = new CCRMEngineersGroupMasterBA();
            _EmpEmployeeMasterBA = new EmpEmployeeMasterBA();
        }
        #region Controller Methods
        // GET: CCRMMIFMasterAndDetails
        public ActionResult Index()
        {

            if (Convert.ToString(Session["UserType"]) == "A" || Convert.ToInt32(Session["Admin Manager"]) > 0)
            {
                return View("/Views/CCRM/CCRMMIFMasterAndDetails/Index.cshtml");
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
                CCRMMIFMasterAndDetailsViewModel model = new CCRMMIFMasterAndDetailsViewModel();

                List<SelectListItem> MIFType = new List<SelectListItem>();
                ViewBag.MIFType = new SelectList(MIFType, "Value", "Text");
                List<SelectListItem> li_MIFType = new List<SelectListItem>();

                if (model.CCRMMIFMasterAndDetailsDTO.MIFType > 0)
                {
                    li_MIFType.Add(new SelectListItem { Text = "Dealer", Value = "1" });
                    li_MIFType.Add(new SelectListItem { Text = "Company", Value = "2" });
                    // li_LocationType.Add(new SelectListItem { Text = "None", Value = "3" });
                    //ViewData["SerialAndBatchManagedBy"] = li_SerialAndBatchManagedBy;
                    ViewData["MIFType"] = new SelectList(li_MIFType, "Value", "Text", (model.CCRMMIFMasterAndDetailsDTO.MIFType).ToString().Trim());
                }
                else
                {

                    li_MIFType.Add(new SelectListItem { Text = "Dealer", Value = "1" });
                    li_MIFType.Add(new SelectListItem { Text = "Company", Value = "2" });
                    // li_LocationType.Add(new SelectListItem { Text = "None", Value = "3" });
                    ViewData["MIFType"] = li_MIFType;
                }
                List<SelectListItem> Priority = new List<SelectListItem>();
                ViewBag.Priority = new SelectList(Priority, "Value", "Text");
                List<SelectListItem> li_Priority = new List<SelectListItem>();

                if (model.CCRMMIFMasterAndDetailsDTO.Priority > 0)
                {
                    li_Priority.Add(new SelectListItem { Text = "High", Value = "1" });
                    li_Priority.Add(new SelectListItem { Text = "Medium", Value = "2" });
                    li_Priority.Add(new SelectListItem { Text = "Low", Value = "3" });
                    //ViewData["SerialAndBatchManagedBy"] = li_SerialAndBatchManagedBy;
                    ViewData["Priority"] = new SelectList(li_Priority, "Value", "Text", (model.CCRMMIFMasterAndDetailsDTO.Priority).ToString().Trim());
                }
                else
                {

                    li_Priority.Add(new SelectListItem { Text = "High", Value = "1" });
                    li_Priority.Add(new SelectListItem { Text = "Medium", Value = "2" });
                    li_Priority.Add(new SelectListItem { Text = "Low", Value = "3" });
                    ViewData["Priority"] = li_Priority;
                }
                //*********************Category*********************//
                List<SelectListItem> Category = new List<SelectListItem>();
                ViewBag.Category = new SelectList(Category, "Value", "Text");
                List<SelectListItem> li_Category = new List<SelectListItem>();

                if (model.CCRMMIFMasterAndDetailsDTO.Category > 0)
                {
                    li_Category.Add(new SelectListItem { Text = "Copier", Value = "1" });
                    li_Category.Add(new SelectListItem { Text = "NonCopier", Value = "2" });
                    li_Category.Add(new SelectListItem { Text = "Other", Value = "3" });
                    //ViewData["SerialAndBatchManagedBy"] = li_SerialAndBatchManagedBy;
                    ViewData["Category"] = new SelectList(li_Category, "Value", "Text", (model.CCRMMIFMasterAndDetailsDTO.Category).ToString().Trim());
                }
                else
                {

                    li_Category.Add(new SelectListItem { Text = "Copier", Value = "1" });
                    li_Category.Add(new SelectListItem { Text = "NonCopier", Value = "2" });
                    li_Category.Add(new SelectListItem { Text = "Other", Value = "3" });
                    ViewData["Category"] = li_Category;
                }
                //*********************Printer*********************//
                List<SelectListItem> ISPrinter = new List<SelectListItem>();
                ViewBag.ISPrinter = new SelectList(ISPrinter, "Value", "Text");
                List<SelectListItem> li_ISPrinter = new List<SelectListItem>();

                if (model.CCRMMIFMasterAndDetailsDTO.ISPrinter > 0)
                {
                    li_ISPrinter.Add(new SelectListItem { Text = "Yes", Value = "1" });
                    li_ISPrinter.Add(new SelectListItem { Text = "No", Value = "2" });
                    // li_Printer.Add(new SelectListItem { Text = "Low", Value = "3" });
                    //ViewData["SerialAndBatchManagedBy"] = li_SerialAndBatchManagedBy;
                    ViewData["ISPrinter"] = new SelectList(li_ISPrinter, "Value", "Text", (model.CCRMMIFMasterAndDetailsDTO.ISPrinter).ToString().Trim());
                }
                else
                {

                    li_ISPrinter.Add(new SelectListItem { Text = "Yes", Value = "1" });
                    li_ISPrinter.Add(new SelectListItem { Text = "No", Value = "2" });
                    // li_Priority.Add(new SelectListItem { Text = "Low", Value = "3" });
                    ViewData["ISPrinter"] = li_ISPrinter;
                }
                //*********************Scanner*********************//
                List<SelectListItem> ISScanner = new List<SelectListItem>();
                ViewBag.ISScanner = new SelectList(ISScanner, "Value", "Text");
                List<SelectListItem> li_ISScanner = new List<SelectListItem>();

                if (model.CCRMMIFMasterAndDetailsDTO.ISScanner > 0)
                {
                    li_ISScanner.Add(new SelectListItem { Text = "Yes", Value = "1" });
                    li_ISScanner.Add(new SelectListItem { Text = "No", Value = "2" });
                    // li_Printer.Add(new SelectListItem { Text = "Low", Value = "3" });
                    //ViewData["SerialAndBatchManagedBy"] = li_SerialAndBatchManagedBy;
                    ViewData["ISScanner"] = new SelectList(li_ISScanner, "Value", "Text", (model.CCRMMIFMasterAndDetailsDTO.ISScanner).ToString().Trim());
                }
                else
                {

                    li_ISScanner.Add(new SelectListItem { Text = "Yes", Value = "1" });
                    li_ISScanner.Add(new SelectListItem { Text = "No", Value = "2" });
                    // li_Priority.Add(new SelectListItem { Text = "Low", Value = "3" });
                    ViewData["ISScanner"] = li_ISScanner;
                }
                //*********************Fax*********************//
                List<SelectListItem> ISFax = new List<SelectListItem>();
                ViewBag.ISFax = new SelectList(ISFax, "Value", "Text");
                List<SelectListItem> li_ISFax = new List<SelectListItem>();

                if (model.CCRMMIFMasterAndDetailsDTO.ISFax > 0)
                {
                    li_ISFax.Add(new SelectListItem { Text = "Yes", Value = "1" });
                    li_ISFax.Add(new SelectListItem { Text = "No", Value = "2" });
                    // li_Printer.Add(new SelectListItem { Text = "Low", Value = "3" });
                    //ViewData["SerialAndBatchManagedBy"] = li_SerialAndBatchManagedBy;
                    ViewData["ISFax"] = new SelectList(li_ISFax, "Value", "Text", (model.CCRMMIFMasterAndDetailsDTO.ISFax).ToString().Trim());
                }
                else
                {

                    li_ISFax.Add(new SelectListItem { Text = "Yes", Value = "1" });
                    li_ISFax.Add(new SelectListItem { Text = "No", Value = "2" });
                    // li_Priority.Add(new SelectListItem { Text = "Low", Value = "3" });
                    ViewData["ISFax"] = li_ISFax;
                }
                //*********************status*********************//
                List<SelectListItem> Status = new List<SelectListItem>();
                ViewBag.Status = new SelectList(Status, "Value", "Text");
                List<SelectListItem> li_Status = new List<SelectListItem>();

                if (model.CCRMMIFMasterAndDetailsDTO.Status > 0)
                {
                    li_Status.Add(new SelectListItem { Text = "Active", Value = "1" });
                    li_Status.Add(new SelectListItem { Text = "InActive", Value = "2" });
                    // li_Printer.Add(new SelectListItem { Text = "Low", Value = "3" });
                    //ViewData["SerialAndBatchManagedBy"] = li_SerialAndBatchManagedBy;
                    ViewData["Status"] = new SelectList(li_Status, "Value", "Text", (model.CCRMMIFMasterAndDetailsDTO.Status).ToString().Trim());
                }
                else
                {

                    li_Status.Add(new SelectListItem { Text = "Active", Value = "1" });
                    li_Status.Add(new SelectListItem { Text = "InActive", Value = "2" });
                    // li_Priority.Add(new SelectListItem { Text = "Low", Value = "3" });
                    ViewData["Status"] = li_Status;
                }

                //*********************CustomerSegement*********************//
                List<CCRMCustomerSegement> CCRMCustomerSegement = GetCCRMCustomerSegement();
                List<SelectListItem> CCRMCustomerSegementList = new List<SelectListItem>();
                foreach (CCRMCustomerSegement item in CCRMCustomerSegement)
                {
                    CCRMCustomerSegementList.Add(new SelectListItem { Text = item.SegementName, Value = Convert.ToString(item.ID) });
                }
                ViewBag.CCRMCustomerSegementList = new SelectList(CCRMCustomerSegementList, "Value", "Text", model.CutomerSegementMasterID);

                //*********************MachineFamily*********************//
                List<CCRMMachineFamilyMaster> CCRMMachineFamilyMaster = GetCCRMMachineFamilyMaster();
                List<SelectListItem> CCRMMachineFamilyMasterList = new List<SelectListItem>();
                foreach (CCRMMachineFamilyMaster item in CCRMMachineFamilyMaster)
                {
                    CCRMMachineFamilyMasterList.Add(new SelectListItem { Text = item.MachineFamilyName, Value = Convert.ToString(item.ID) });
                }
                ViewBag.CCRMMachineFamilyMasterList = new SelectList(CCRMMachineFamilyMasterList, "Value", "Text", model.MachineFamilyID);

                //*********************Location*********************//
                List<CCRMLocationTypeMaster> CCRMLocationTypeMaster = GetCCRMLocationTypeMaster();
                List<SelectListItem> CCRMLocationTypeMasterList = new List<SelectListItem>();
                foreach (CCRMLocationTypeMaster item in CCRMLocationTypeMaster)
                {
                    CCRMLocationTypeMasterList.Add(new SelectListItem { Text = item.LocationTypeCode, Value = Convert.ToString(item.ID) });
                }
                ViewBag.CCRMLocationTypeMasterList = new SelectList(CCRMLocationTypeMasterList, "Value", "Text", model.CCRMLocationTypeID);
                //*********************country*********************//
                List<GeneralCountryMaster> GeneralCountryMasterList = GetListGeneralCountryMaster();
                List<SelectListItem> genCountryMaster = new List<SelectListItem>();
                foreach (GeneralCountryMaster item in GeneralCountryMasterList)
                {
                    genCountryMaster.Add(new SelectListItem { Text = item.CountryName, Value = item.ID.ToString() });
                }
                ViewBag.GeneralCountryMaster = new SelectList(genCountryMaster, "Value", "Text");
                List<SelectListItem> generalRegionMaster = new List<SelectListItem>();
                ViewBag.GeneralRegionMaster = new SelectList(generalRegionMaster, "Value", "Text");
                List<SelectListItem> generalCityMaster = new List<SelectListItem>();
                ViewBag.GeneralCityMaster = new SelectList(generalCityMaster, "Value", "Text");
                //*********************Group*********************//
                List<CCRMEngineersGroupMaster> CCRMEngineersGroupMaster = GetCCRMEngineersGroupMaster();
                List<SelectListItem> CCRMEngineersGroupMasterList = new List<SelectListItem>();
                foreach (CCRMEngineersGroupMaster item in CCRMEngineersGroupMaster)
                {
                    CCRMEngineersGroupMasterList.Add(new SelectListItem { Text = item.GroupName, Value = Convert.ToString(item.ID) });
                }
                ViewBag.CCRMEngineersGroupMasterList = new SelectList(CCRMEngineersGroupMasterList, "Value", "Text", model.Group);

                //*********************EmployeeSrviveEngg*********************//
                List<EmpEmployeeMaster> EmpEmployeeMaster = GetEmpEmployeeMasterService();
                List<SelectListItem> EmpEmployeeMasterList = new List<SelectListItem>();
                foreach (EmpEmployeeMaster item in EmpEmployeeMaster)
                {
                    EmpEmployeeMasterList.Add(new SelectListItem { Text = item.EmployeeName, Value = Convert.ToString(item.EmployeeID) });
                }
                ViewBag.EmpEmployeeMasterList = new SelectList(EmpEmployeeMasterList, "Value", "Text", model.InstalledById);
                //*********************EmployeeExecutive*********************//

                List<EmpEmployeeMaster> EmpEmployeeMaster1 = GetEmpEmployeeMasterExecutive();
                List<SelectListItem> EmpEmployeeMasterList1 = new List<SelectListItem>();
                foreach (EmpEmployeeMaster item in EmpEmployeeMaster1)
                {
                    EmpEmployeeMasterList1.Add(new SelectListItem { Text = item.EmployeeName, Value = Convert.ToString(item.ID) });
                }
                ViewBag.EmpEmployeeMasterList1 = new SelectList(EmpEmployeeMasterList1, "Value", "Text", model.CollExecId);


                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/CCRM/CCRMMIFMasterAndDetails/List.cshtml", model);
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
            CCRMMIFMasterAndDetailsViewModel model = new CCRMMIFMasterAndDetailsViewModel();

            List<SelectListItem> MIFType = new List<SelectListItem>();
            ViewBag.MIFType = new SelectList(MIFType, "Value", "Text");
            List<SelectListItem> li_MIFType = new List<SelectListItem>();

            if (model.CCRMMIFMasterAndDetailsDTO.MIFType > 0)
            {
                li_MIFType.Add(new SelectListItem { Text = "Dealer", Value = "1" });
                li_MIFType.Add(new SelectListItem { Text = "Company", Value = "2" });
                // li_LocationType.Add(new SelectListItem { Text = "None", Value = "3" });
                //ViewData["SerialAndBatchManagedBy"] = li_SerialAndBatchManagedBy;
                ViewData["MIFType"] = new SelectList(li_MIFType, "Value", "Text", (model.CCRMMIFMasterAndDetailsDTO.MIFType).ToString().Trim());
            }
            else
            {

                li_MIFType.Add(new SelectListItem { Text = "Dealer", Value = "1" });
                li_MIFType.Add(new SelectListItem { Text = "Company", Value = "2" });
                // li_LocationType.Add(new SelectListItem { Text = "None", Value = "3" });
                ViewData["MIFType"] = li_MIFType;
            }
            List<SelectListItem> Priority = new List<SelectListItem>();
            ViewBag.Priority = new SelectList(Priority, "Value", "Text");
            List<SelectListItem> li_Priority = new List<SelectListItem>();

            if (model.CCRMMIFMasterAndDetailsDTO.Priority > 0)
            {
                li_Priority.Add(new SelectListItem { Text = "High", Value = "1" });
                li_Priority.Add(new SelectListItem { Text = "Medium", Value = "2" });
                li_Priority.Add(new SelectListItem { Text = "Low", Value = "3" });
                //ViewData["SerialAndBatchManagedBy"] = li_SerialAndBatchManagedBy;
                ViewData["Priority"] = new SelectList(li_Priority, "Value", "Text", (model.CCRMMIFMasterAndDetailsDTO.Priority).ToString().Trim());
            }
            else
            {

                li_Priority.Add(new SelectListItem { Text = "High", Value = "1" });
                li_Priority.Add(new SelectListItem { Text = "Medium", Value = "2" });
                li_Priority.Add(new SelectListItem { Text = "Low", Value = "3" });
                ViewData["Priority"] = li_Priority;
            }
            //*********************Printer*********************//
            List<SelectListItem> ISPrinter = new List<SelectListItem>();
            ViewBag.ISPrinter = new SelectList(ISPrinter, "Value", "Text");
            List<SelectListItem> li_ISPrinter = new List<SelectListItem>();

            if (model.CCRMMIFMasterAndDetailsDTO.ISPrinter > 0)
            {
                li_ISPrinter.Add(new SelectListItem { Text = "Yes", Value = "1" });
                li_ISPrinter.Add(new SelectListItem { Text = "No", Value = "2" });
               // li_Printer.Add(new SelectListItem { Text = "Low", Value = "3" });
                //ViewData["SerialAndBatchManagedBy"] = li_SerialAndBatchManagedBy;
                ViewData["ISPrinter"] = new SelectList(li_ISPrinter, "Value", "Text", (model.CCRMMIFMasterAndDetailsDTO.ISPrinter).ToString().Trim());
            }
            else
            {

                li_ISPrinter.Add(new SelectListItem { Text = "Yes", Value = "1" });
                li_ISPrinter.Add(new SelectListItem { Text = "No", Value = "2" });
               // li_Priority.Add(new SelectListItem { Text = "Low", Value = "3" });
                ViewData["ISPrinter"] = li_ISPrinter;
            }
            //*********************Scanner*********************//
            List<SelectListItem> ISScanner = new List<SelectListItem>();
            ViewBag.ISScanner = new SelectList(ISScanner, "Value", "Text");
            List<SelectListItem> li_ISScanner = new List<SelectListItem>();

            if (model.CCRMMIFMasterAndDetailsDTO.ISScanner > 0)
            {
                li_ISScanner.Add(new SelectListItem { Text = "Yes", Value = "1" });
                li_ISScanner.Add(new SelectListItem { Text = "No", Value = "2" });
                // li_Printer.Add(new SelectListItem { Text = "Low", Value = "3" });
                //ViewData["SerialAndBatchManagedBy"] = li_SerialAndBatchManagedBy;
                ViewData["ISScanner"] = new SelectList(li_ISScanner, "Value", "Text", (model.CCRMMIFMasterAndDetailsDTO.ISScanner).ToString().Trim());
            }
            else
            {

                li_ISScanner.Add(new SelectListItem { Text = "Yes", Value = "1" });
                li_ISScanner.Add(new SelectListItem { Text = "No", Value = "2" });
                // li_Priority.Add(new SelectListItem { Text = "Low", Value = "3" });
                ViewData["ISScanner"] = li_ISScanner;
            }
            //*********************Fax*********************//
            List<SelectListItem> ISFax = new List<SelectListItem>();
            ViewBag.ISFax = new SelectList(ISFax, "Value", "Text");
            List<SelectListItem> li_ISFax = new List<SelectListItem>();

            if (model.CCRMMIFMasterAndDetailsDTO.ISFax > 0)
            {
                li_ISFax.Add(new SelectListItem { Text = "Yes", Value = "1" });
                li_ISFax.Add(new SelectListItem { Text = "No", Value = "2" });
                // li_Printer.Add(new SelectListItem { Text = "Low", Value = "3" });
                //ViewData["SerialAndBatchManagedBy"] = li_SerialAndBatchManagedBy;
                ViewData["ISFax"] = new SelectList(li_ISFax, "Value", "Text", (model.CCRMMIFMasterAndDetailsDTO.ISFax).ToString().Trim());
            }
            else
            {

                li_ISFax.Add(new SelectListItem { Text = "Yes", Value = "1" });
                li_ISFax.Add(new SelectListItem { Text = "No", Value = "2" });
                // li_Priority.Add(new SelectListItem { Text = "Low", Value = "3" });
                ViewData["ISFax"] = li_ISFax;
            }
            //*********************status*********************//
            List<SelectListItem> Status = new List<SelectListItem>();
            ViewBag.Status = new SelectList(Status, "Value", "Text");
            List<SelectListItem> li_Status = new List<SelectListItem>();

            if (model.CCRMMIFMasterAndDetailsDTO.Status > 0)
            {
                li_Status.Add(new SelectListItem { Text = "Active", Value = "1" });
                li_Status.Add(new SelectListItem { Text = "InActive", Value = "2" });
                // li_Printer.Add(new SelectListItem { Text = "Low", Value = "3" });
                //ViewData["SerialAndBatchManagedBy"] = li_SerialAndBatchManagedBy;
                ViewData["Status"] = new SelectList(li_Status, "Value", "Text", (model.CCRMMIFMasterAndDetailsDTO.Status).ToString().Trim());
            }
            else
            {

                li_Status.Add(new SelectListItem { Text = "Active", Value = "1" });
                li_Status.Add(new SelectListItem { Text = "InActive", Value = "2" });
                // li_Priority.Add(new SelectListItem { Text = "Low", Value = "3" });
                ViewData["Status"] = li_Status;
            }

            //*********************CustomerSegement*********************//
            List<CCRMCustomerSegement> CCRMCustomerSegement = GetCCRMCustomerSegement();
            List<SelectListItem> CCRMCustomerSegementList = new List<SelectListItem>();
            foreach (CCRMCustomerSegement item in CCRMCustomerSegement)
            {
                CCRMCustomerSegementList.Add(new SelectListItem { Text = item.SegementName, Value = Convert.ToString(item.ID) });
            }
            ViewBag.CCRMCustomerSegementList = new SelectList(CCRMCustomerSegementList, "Value", "Text", model.CutomerSegementMasterID);

            //*********************MachineFamily*********************//
            List<CCRMMachineFamilyMaster> CCRMMachineFamilyMaster = GetCCRMMachineFamilyMaster();
            List<SelectListItem> CCRMMachineFamilyMasterList = new List<SelectListItem>();
            foreach (CCRMMachineFamilyMaster item in CCRMMachineFamilyMaster)
            {
                CCRMMachineFamilyMasterList.Add(new SelectListItem { Text = item.MachineFamilyName, Value = Convert.ToString(item.ID) });
            }
            ViewBag.CCRMMachineFamilyMasterList = new SelectList(CCRMMachineFamilyMasterList, "Value", "Text", model.MachineFamilyID);

            //*********************Location*********************//
            List<CCRMLocationTypeMaster> CCRMLocationTypeMaster = GetCCRMLocationTypeMaster();
            List<SelectListItem> CCRMLocationTypeMasterList = new List<SelectListItem>();
            foreach (CCRMLocationTypeMaster item in CCRMLocationTypeMaster)
            {
                CCRMLocationTypeMasterList.Add(new SelectListItem { Text = item.LocationTypeCode, Value = Convert.ToString(item.ID) });
            }
            ViewBag.CCRMLocationTypeMasterList = new SelectList(CCRMLocationTypeMasterList, "Value", "Text", model.CCRMLocationTypeID);
            //*********************country*********************//
            List<GeneralCountryMaster> GeneralCountryMasterList = GetListGeneralCountryMaster();
            List<SelectListItem> genCountryMaster = new List<SelectListItem>();
            foreach (GeneralCountryMaster item in GeneralCountryMasterList)
            {
                genCountryMaster.Add(new SelectListItem { Text = item.CountryName, Value = item.ID.ToString() });
            }
            ViewBag.GeneralCountryMaster = new SelectList(genCountryMaster, "Value", "Text");
            List<SelectListItem> generalRegionMaster = new List<SelectListItem>();
            ViewBag.GeneralRegionMaster = new SelectList(generalRegionMaster, "Value", "Text");
            List<SelectListItem> generalCityMaster = new List<SelectListItem>();
            ViewBag.GeneralCityMaster = new SelectList(generalCityMaster, "Value", "Text");
            //*********************Group*********************//
            List<CCRMEngineersGroupMaster> CCRMEngineersGroupMaster = GetCCRMEngineersGroupMaster();
            List<SelectListItem> CCRMEngineersGroupMasterList = new List<SelectListItem>();
            foreach (CCRMEngineersGroupMaster item in CCRMEngineersGroupMaster)
            {
                CCRMEngineersGroupMasterList.Add(new SelectListItem { Text = item.GroupName, Value = Convert.ToString(item.ID) });
            }
            ViewBag.CCRMEngineersGroupMasterList = new SelectList(CCRMEngineersGroupMasterList, "Value", "Text", model.Group);
            //*********************EmployeeSrviveEngg*********************//
            List<EmpEmployeeMaster> EmpEmployeeMaster = GetEmpEmployeeMasterService();
            List<SelectListItem> EmpEmployeeMasterList = new List<SelectListItem>();
            foreach (EmpEmployeeMaster item in EmpEmployeeMaster)
            {
                EmpEmployeeMasterList.Add(new SelectListItem { Text = item.EmployeeName, Value = Convert.ToString(item.EmployeeID) });
            }
            ViewBag.EmpEmployeeMasterList = new SelectList(EmpEmployeeMasterList, "Value", "Text", model.InstalledById);
            //*********************EmployeeExecutive*********************//

            List<EmpEmployeeMaster> EmpEmployeeMaster1 = GetEmpEmployeeMasterExecutive();
            List<SelectListItem> EmpEmployeeMasterList1 = new List<SelectListItem>();
            foreach (EmpEmployeeMaster item in EmpEmployeeMaster1)
            {
                EmpEmployeeMasterList1.Add(new SelectListItem { Text = item.EmployeeName, Value = Convert.ToString(item.EmployeeID) });
            }
            ViewBag.EmpEmployeeMasterList1 = new SelectList(EmpEmployeeMasterList1, "Value", "Text", model.CollExecId);

            return PartialView("/Views/CCRM/CCRMMIFMasterAndDetails/Create.cshtml", model);


        }
        [HttpPost]
        public ActionResult Create(CCRMMIFMasterAndDetailsViewModel model)
        {
            try
            {
               
                    if (model != null && model.CCRMMIFMasterAndDetailsDTO != null)
                {
                    model.CCRMMIFMasterAndDetailsDTO.ConnectionString = _connectioString;

                 
                    model.CCRMMIFMasterAndDetailsDTO.InstallationDate = model.InstallationDate;
                    model.CCRMMIFMasterAndDetailsDTO.CustomerCode = model.CustomerCode;
                    model.CCRMMIFMasterAndDetailsDTO.CustomerMasterID = model.CustomerMasterID;
                    model.CCRMMIFMasterAndDetailsDTO.CustomerAddress = model.CustomerAddress;
                    model.CCRMMIFMasterAndDetailsDTO.CustomerPinCode = model.CustomerPinCode;
                    model.CCRMMIFMasterAndDetailsDTO.CutomerSegementMasterID = model.CutomerSegementMasterID;
                    model.CCRMMIFMasterAndDetailsDTO.MIFTitle = model.MIFTitle;
                    model.CCRMMIFMasterAndDetailsDTO.MIFAddress = model.MIFAddress;
                  
                    model.CCRMMIFMasterAndDetailsDTO.MIFPinCode = model.MIFPinCode;
                    model.CCRMMIFMasterAndDetailsDTO.FolioNo = model.FolioNo;
                    model.CCRMMIFMasterAndDetailsDTO.BillTitle = model.BillTitle;
                    model.CCRMMIFMasterAndDetailsDTO.BillAddress = model.BillAddress;
                    model.CCRMMIFMasterAndDetailsDTO.ModelNo = model.ModelNo;
                    model.CCRMMIFMasterAndDetailsDTO.SerialNo = model.SerialNo;
                    model.CCRMMIFMasterAndDetailsDTO.MIFType = model.MIFType;
                    model.CCRMMIFMasterAndDetailsDTO.MachineFamilyID = model.MachineFamilyID;
                    model.CCRMMIFMasterAndDetailsDTO.CCRMEngineersGroupMasterID = model.CCRMEngineersGroupMasterID;
                    model.CCRMMIFMasterAndDetailsDTO.CCRMAreaPatchMasterID = model.CCRMAreaPatchMasterID;
                    model.CCRMMIFMasterAndDetailsDTO.CountryID = model.CountryID;
                    model.CCRMMIFMasterAndDetailsDTO.StateID = model.StateID;
                    model.CCRMMIFMasterAndDetailsDTO.CityID = model.CityID;
                    model.CCRMMIFMasterAndDetailsDTO.Category = model.Category;
                    model.CCRMMIFMasterAndDetailsDTO.CCRMLocationTypeID = model.CCRMLocationTypeID;
                    model.CCRMMIFMasterAndDetailsDTO.Priority = model.Priority;
                    model.CCRMMIFMasterAndDetailsDTO.InstalledById = model.InstalledById;
                    model.CCRMMIFMasterAndDetailsDTO.ServiceEngID = model.ServiceEngID;
                    model.CCRMMIFMasterAndDetailsDTO.CollExecId = model.CollExecId;
                    model.CCRMMIFMasterAndDetailsDTO.ISPrinter = model.ISPrinter;
                    model.CCRMMIFMasterAndDetailsDTO.ISScanner = model.ISScanner;
                    model.CCRMMIFMasterAndDetailsDTO.ISFax = model.ISFax;
                    model.CCRMMIFMasterAndDetailsDTO.Others = model.Others;
                    model.CCRMMIFMasterAndDetailsDTO.WarantyInDays = model.WarantyInDays;
                    model.CCRMMIFMasterAndDetailsDTO.WarantyExpiryDate = model.WarantyExpiryDate;
                    model.CCRMMIFMasterAndDetailsDTO.Status = model.Status;
                    model.CCRMMIFMasterAndDetailsDTO.InactiveDate = model.InactiveDate;
                    model.CCRMMIFMasterAndDetailsDTO.Remarks = model.Remarks;
                    model.CCRMMIFMasterAndDetailsDTO.EmailCorporate = model.EmailCorporate;
                    model.CCRMMIFMasterAndDetailsDTO.EmailAccounts = model.EmailAccounts;
                    model.CCRMMIFMasterAndDetailsDTO.Emailservices = model.Emailservices;
                    model.CCRMMIFMasterAndDetailsDTO.KeyOperatorName = model.KeyOperatorName;
                    model.CCRMMIFMasterAndDetailsDTO.PhoneNo = model.PhoneNo;
                    model.CCRMMIFMasterAndDetailsDTO.MobileNo = model.MobileNo;
                    
                    model.CCRMMIFMasterAndDetailsDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<CCRMMIFMasterAndDetails> response = _CCRMMIFMasterAndDetailsBA.InsertCCRMMIFMasterAndDetails(model.CCRMMIFMasterAndDetailsDTO);
                    model.CCRMMIFMasterAndDetailsDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);

                }
                return Json(model.CCRMMIFMasterAndDetailsDTO.errorMessage, JsonRequestBehavior.AllowGet);

                
               

            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }
        [HttpGet]
        public ActionResult Edit(Int32 id )
        {
            CCRMMIFMasterAndDetailsViewModel model = new CCRMMIFMasterAndDetailsViewModel();
            CCRMMIFMasterAndDetailsSearchRequest searchRequest = new CCRMMIFMasterAndDetailsSearchRequest();
            List<SelectListItem> li = new List<SelectListItem>();
            // li1.Add(new SelectListItem { Text = "--Select--", Value = " " });
            li.Add(new SelectListItem { Text = "Dealer", Value = "1" });
            li.Add(new SelectListItem { Text = "Company", Value = "2" });
            ViewData["MIFType"] = li;
            //*********************Priority*********************//
            List<SelectListItem> li1 = new List<SelectListItem>();
            // li1.Add(new SelectListItem { Text = "--Select--", Value = " " });
            li1.Add(new SelectListItem { Text = "High", Value = "1" });
            li1.Add(new SelectListItem { Text = "Medium", Value = "2" });
            li1.Add(new SelectListItem { Text = "Low", Value = "3" });
            ViewData["Priority"] = li1;
            //*********************Category*********************//
            List<SelectListItem> li6 = new List<SelectListItem>();
            // li1.Add(new SelectListItem { Text = "--Select--", Value = " " });
            li6.Add(new SelectListItem { Text = "Copier", Value = "1" });
            li6.Add(new SelectListItem { Text = "NonCopier", Value = "2" });
            li6.Add(new SelectListItem { Text = "Other", Value = "3" });
            ViewData["Category"] = li6;
            //*********************Printer*********************//
            List<SelectListItem> li2 = new List<SelectListItem>();
            // li1.Add(new SelectListItem { Text = "--Select--", Value = " " });
            li2.Add(new SelectListItem { Text = "Yes", Value = "1" });
            li2.Add(new SelectListItem { Text = "No", Value = "2" });
            ViewData["ISPrinter"] = li2;
            //*********************Scanner*********************//
            List<SelectListItem> li3 = new List<SelectListItem>();
            // li1.Add(new SelectListItem { Text = "--Select--", Value = " " });
            li3.Add(new SelectListItem { Text = "Yes", Value = "1" });
            li3.Add(new SelectListItem { Text = "No", Value = "2" });
            ViewData["ISScanner"] = li3;
            //*********************ISFax*********************//
            List<SelectListItem> li4 = new List<SelectListItem>();
            // li1.Add(new SelectListItem { Text = "--Select--", Value = " " });
            li4.Add(new SelectListItem { Text = "Yes", Value = "1" });
            li4.Add(new SelectListItem { Text = "No", Value = "2" });
            ViewData["ISFax"] = li4;
            //*********************Status*********************//
            List<SelectListItem> li5 = new List<SelectListItem>();
            // li1.Add(new SelectListItem { Text = "--Select--", Value = " " });
            li5.Add(new SelectListItem { Text = "Active", Value = "1" });
            li5.Add(new SelectListItem { Text = "InActive", Value = "2" });
            ViewData["Status"] = li5;
            //*********************CustomerSegement*********************//
            List<CCRMCustomerSegement> CCRMCustomerSegement = GetCCRMCustomerSegement();
            List<SelectListItem> CCRMCustomerSegementList = new List<SelectListItem>();
            foreach (CCRMCustomerSegement item in CCRMCustomerSegement)
            {
                CCRMCustomerSegementList.Add(new SelectListItem { Text = item.SegementName, Value = Convert.ToString(item.ID) });
            }
            ViewBag.CCRMCustomerSegementList = new SelectList(CCRMCustomerSegementList, "Value", "Text", model.CutomerSegementMasterID);

            //*********************MachineFamily*********************//
            List<CCRMMachineFamilyMaster> CCRMMachineFamilyMaster = GetCCRMMachineFamilyMaster();
            List<SelectListItem> CCRMMachineFamilyMasterList = new List<SelectListItem>();
            foreach (CCRMMachineFamilyMaster item in CCRMMachineFamilyMaster)
            {
                CCRMMachineFamilyMasterList.Add(new SelectListItem { Text = item.MachineFamilyName, Value = Convert.ToString(item.ID) });
            }
            ViewBag.CCRMMachineFamilyMasterList = new SelectList(CCRMMachineFamilyMasterList, "Value", "Text", model.MachineFamilyID);

            //*********************Location*********************//
            List<CCRMLocationTypeMaster> CCRMLocationTypeMaster = GetCCRMLocationTypeMaster();
            List<SelectListItem> CCRMLocationTypeMasterList = new List<SelectListItem>();
            foreach (CCRMLocationTypeMaster item in CCRMLocationTypeMaster)
            {
                CCRMLocationTypeMasterList.Add(new SelectListItem { Text = item.LocationTypeCode, Value = Convert.ToString(item.ID) });
            }
            ViewBag.CCRMLocationTypeMasterList = new SelectList(CCRMLocationTypeMasterList, "Value", "Text", model.CCRMLocationTypeID);
            //*********************country*********************//
            List<GeneralCountryMaster> GeneralCountryMasterList = GetListGeneralCountryMaster();
            List<SelectListItem> GeneralCountryMaster = new List<SelectListItem>();
            foreach (GeneralCountryMaster item in GeneralCountryMasterList)
            {
                GeneralCountryMaster.Add(new SelectListItem { Text = item.CountryName, Value = item.ID.ToString() });
            }

            string SelectedCountryID = string.Empty;
            List<GeneralRegionMaster> generalRegionMasterList = GetListGeneralRegionMaster(SelectedCountryID);
            List<SelectListItem> generalRegionMaster = new List<SelectListItem>();
            foreach (GeneralRegionMaster item in generalRegionMasterList)
            {
                generalRegionMaster.Add(new SelectListItem { Text = item.RegionName, Value = item.ID.ToString() });
            }

            string SelectedRegionID = string.Empty;
            List<GeneralCityMaster> generalCityMasterList = GetListGeneralCityMaster(SelectedRegionID);
            List<SelectListItem> generalCityMaster = new List<SelectListItem>();
            foreach (GeneralCityMaster item in generalCityMasterList)
            {
                generalCityMaster.Add(new SelectListItem { Text = item.Description, Value = item.ID.ToString() });
            }
            //*********************Group*********************//
            List<CCRMEngineersGroupMaster> CCRMEngineersGroupMaster = GetCCRMEngineersGroupMaster();
            List<SelectListItem> CCRMEngineersGroupMasterList = new List<SelectListItem>();
            foreach (CCRMEngineersGroupMaster item in CCRMEngineersGroupMaster)
            {
                CCRMEngineersGroupMasterList.Add(new SelectListItem { Text = item.GroupName, Value = Convert.ToString(item.ID) });
            }
            ViewBag.CCRMEngineersGroupMasterList = new SelectList(CCRMEngineersGroupMasterList, "Value", "Text", model.Group);
            //*********************EmployeeSrviveEngg*********************//
            List<EmpEmployeeMaster> EmpEmployeeMaster = GetEmpEmployeeMasterService();
            List<SelectListItem> EmpEmployeeMasterList = new List<SelectListItem>();
            foreach (EmpEmployeeMaster item in EmpEmployeeMaster)
            {
                EmpEmployeeMasterList.Add(new SelectListItem { Text = item.EmployeeName, Value = Convert.ToString(item.EmployeeID) });
            }
            ViewBag.EmpEmployeeMasterList = new SelectList(EmpEmployeeMasterList, "Value", "Text", model.InstalledById);
            //*********************EmployeeExecutive*********************//

            List<EmpEmployeeMaster> EmpEmployeeMaster1 = GetEmpEmployeeMasterExecutive();
            List<SelectListItem> EmpEmployeeMasterList1 = new List<SelectListItem>();
            foreach (EmpEmployeeMaster item in EmpEmployeeMaster1)
            {
                EmpEmployeeMasterList1.Add(new SelectListItem { Text = item.EmployeeName, Value = Convert.ToString(item.ID) });
            }
            ViewBag.EmpEmployeeMasterList1 = new SelectList(EmpEmployeeMasterList1, "Value", "Text", model.CollExecId);

            try
            {



                model.CCRMMIFMasterAndDetailsDTO = new CCRMMIFMasterAndDetails();
                model.CCRMMIFMasterAndDetailsDTO.ID = id;
                model.CCRMMIFMasterAndDetailsDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<CCRMMIFMasterAndDetails> response = _CCRMMIFMasterAndDetailsBA.SelectByID(model.CCRMMIFMasterAndDetailsDTO);
                if (response != null && response.Entity != null)
                {
                    model.CCRMMIFMasterAndDetailsDTO.ID = response.Entity.ID;
                    model.CCRMMIFMasterAndDetailsDTO.InstallationDate = response.Entity.InstallationDate;
                    model.CCRMMIFMasterAndDetailsDTO.CustomerCode = response.Entity.CustomerCode;
                    model.CCRMMIFMasterAndDetailsDTO.CustomerMasterID = response.Entity.CustomerMasterID;
                    model.CCRMMIFMasterAndDetailsDTO.CustomerMasterName = response.Entity.CustomerMasterName;
                   
                    model.CCRMMIFMasterAndDetailsDTO.CustomerAddress = response.Entity.CustomerAddress;
                    model.CCRMMIFMasterAndDetailsDTO.CustomerPinCode = response.Entity.CustomerPinCode;
                    model.CCRMMIFMasterAndDetailsDTO.CutomerSegementMasterID = response.Entity.CutomerSegementMasterID;
                    model.CCRMMIFMasterAndDetailsDTO.MIFTitle = response.Entity.MIFTitle;
                    model.CCRMMIFMasterAndDetailsDTO.MIFAddress = response.Entity.MIFAddress;
                    model.CCRMMIFMasterAndDetailsDTO.MIFPinCode = response.Entity.MIFPinCode;
                    model.CCRMMIFMasterAndDetailsDTO.FolioNo = response.Entity.FolioNo;
                    model.CCRMMIFMasterAndDetailsDTO.BillTitle = response.Entity.BillTitle;
                    model.CCRMMIFMasterAndDetailsDTO.BillAddress = response.Entity.BillAddress;
                    model.CCRMMIFMasterAndDetailsDTO.ModelNo = response.Entity.ModelNo;

                    model.CCRMMIFMasterAndDetailsDTO.SerialNo = response.Entity.SerialNo;
                    model.CCRMMIFMasterAndDetailsDTO.MIFType = response.Entity.MIFType;
                    model.CCRMMIFMasterAndDetailsDTO.MachineFamilyID = response.Entity.MachineFamilyID;
                    model.CCRMMIFMasterAndDetailsDTO.CCRMEngineersGroupMasterID =response.Entity.CCRMEngineersGroupMasterID;
                    model.CCRMMIFMasterAndDetailsDTO.CCRMAreaPatchMasterID = response.Entity.CCRMAreaPatchMasterID;
                    model.CCRMMIFMasterAndDetailsDTO.CountryID = response.Entity.CountryID;
                    model.CCRMMIFMasterAndDetailsDTO.StateID = response.Entity.StateID;
                    model.CCRMMIFMasterAndDetailsDTO.CityID = response.Entity.CityID;
                    model.CCRMMIFMasterAndDetailsDTO.Category = response.Entity.Category;
                    model.CCRMMIFMasterAndDetailsDTO.CCRMLocationTypeID = response.Entity.CCRMLocationTypeID;
                    model.CCRMMIFMasterAndDetailsDTO.Priority = response.Entity.Priority;
                    model.CCRMMIFMasterAndDetailsDTO.InstalledById = response.Entity.InstalledById;
                    model.CCRMMIFMasterAndDetailsDTO.ServiceEngID = response.Entity.ServiceEngID;
                    model.CCRMMIFMasterAndDetailsDTO.CollExecId = response.Entity.CollExecId;
                    model.CCRMMIFMasterAndDetailsDTO.ISPrinter = response.Entity.ISPrinter;
                    model.CCRMMIFMasterAndDetailsDTO.ISScanner = response.Entity.ISScanner;
                    model.CCRMMIFMasterAndDetailsDTO.ISFax = response.Entity.ISFax;
                    model.CCRMMIFMasterAndDetailsDTO.Others = response.Entity.Others;
                    model.CCRMMIFMasterAndDetailsDTO.WarantyInDays = response.Entity.WarantyInDays;
                    model.CCRMMIFMasterAndDetailsDTO.WarantyExpiryDate = response.Entity.WarantyExpiryDate;
                    model.CCRMMIFMasterAndDetailsDTO.Status = response.Entity.Status;
                    model.CCRMMIFMasterAndDetailsDTO.InactiveDate = response.Entity.InactiveDate;
                    model.CCRMMIFMasterAndDetailsDTO.Remarks = response.Entity.Remarks;
                    model.CCRMMIFMasterAndDetailsDTO.EmailCorporate = response.Entity.EmailCorporate;
                    model.CCRMMIFMasterAndDetailsDTO.EmailAccounts = response.Entity.EmailAccounts;
                    model.CCRMMIFMasterAndDetailsDTO.Emailservices = response.Entity.Emailservices;
                    model.CCRMMIFMasterAndDetailsDTO.KeyOperatorName = response.Entity.KeyOperatorName;
                    model.CCRMMIFMasterAndDetailsDTO.PhoneNo = response.Entity.PhoneNo;
                    model.CCRMMIFMasterAndDetailsDTO.MobileNo = response.Entity.MobileNo;

                    model.CCRMMIFMasterAndDetailsDTO.AreaPatchName = response.Entity.AreaPatchName;
                    model.CCRMMIFMasterAndDetailsDTO.ItemDescription = response.Entity.ItemDescription;
                    model.CCRMMIFMasterAndDetailsDTO.ItemNumber = response.Entity.ItemNumber;
                    model.CCRMMIFMasterAndDetailsDTO.CentreCode = response.Entity.CentreCode;
                    model.CCRMMIFMasterAndDetailsDTO.AdminRoleMasterID = response.Entity.AdminRoleMasterID;
                    model.CCRMMIFMasterAndDetailsDTO.RightName = response.Entity.RightName;
                    model.CCRMMIFMasterAndDetailsDTO.EmployeeID = response.Entity.EmployeeID;
                    model.CCRMMIFMasterAndDetailsDTO.EmployeeCode = response.Entity.EmployeeCode;
                    model.CCRMMIFMasterAndDetailsDTO.EmployeeName = response.Entity.EmployeeName;

                    ViewBag.GeneralCountryMaster = new SelectList(GeneralCountryMaster, "Value", "Text", response.Entity.CountryID.ToString());
                    ViewBag.GeneralRegionMaster = new SelectList(generalRegionMaster, "Value", "Text", response.Entity.StateID.ToString());
                    ViewBag.GeneralCityMaster = new SelectList(generalCityMaster, "Value", "Text", response.Entity.CityID.ToString());

                }
                ViewData["MIFType"] = new SelectList(li, "Value", "Text", (model.MIFType).ToString().Trim());
                ViewData["Priority"] = new SelectList(li1, "Value", "Text", (model.Priority).ToString().Trim());
                ViewData["ISPrinter"] = new SelectList(li2, "Value", "Text", (model.ISPrinter).ToString().Trim());
                ViewData["ISScanner"] = new SelectList(li3, "Value", "Text", (model.ISScanner).ToString().Trim());
                ViewData["ISFax"] = new SelectList(li4, "Value", "Text", (model.ISFax).ToString().Trim());
                ViewData["Status"] = new SelectList(li5, "Value", "Text", (model.Status).ToString().Trim());
                ViewData["Category"] = new SelectList(li6, "Value", "Text", (model.Category).ToString().Trim());
                //searchRequest.ConnectionString = _connectioString;
                //searchRequest.CCRMMIFMasterAndDetailsID = id;

                //IBaseEntityCollectionResponse<CCRMMIFMasterAndDetails> baseEntityCollectionResponse = _CCRMMIFMasterAndDetailsBA.GetListOfOperatorByID(searchRequest);

                //if (baseEntityCollectionResponse != null)
                //{
                //    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                //    {
                //        model.KeyOperatorByCCRMMIFMasterAndDetailsID = baseEntityCollectionResponse.CollectionResponse.ToList();

                //    }
                //}

                return PartialView("/Views/CCRM/CCRMMIFMasterAndDetails/Edit.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPost]
        public ActionResult Edit(CCRMMIFMasterAndDetailsViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.CCRMMIFMasterAndDetailsDTO != null)
                    {
                        if (model != null && model.CCRMMIFMasterAndDetailsDTO != null)
                        {
                            model.CCRMMIFMasterAndDetailsDTO.ConnectionString = _connectioString;
                            model.CCRMMIFMasterAndDetailsDTO.ID = model.ID;
                            model.CCRMMIFMasterAndDetailsDTO.InstallationDate = model.InstallationDate;
                            model.CCRMMIFMasterAndDetailsDTO.CustomerCode = model.CustomerCode;
                            model.CCRMMIFMasterAndDetailsDTO.CustomerMasterID = model.CustomerMasterID;
                          
                            model.CCRMMIFMasterAndDetailsDTO.CustomerAddress = model.CustomerAddress;
                            model.CCRMMIFMasterAndDetailsDTO.CustomerPinCode = model.CustomerPinCode;
                            model.CCRMMIFMasterAndDetailsDTO.CutomerSegementMasterID = model.CutomerSegementMasterID;
                            model.CCRMMIFMasterAndDetailsDTO.MIFTitle = model.MIFTitle;
                            model.CCRMMIFMasterAndDetailsDTO.MIFAddress = model.MIFAddress;

                            model.CCRMMIFMasterAndDetailsDTO.MIFPinCode = model.MIFPinCode;
                            model.CCRMMIFMasterAndDetailsDTO.FolioNo = model.FolioNo;
                            model.CCRMMIFMasterAndDetailsDTO.BillTitle = model.BillTitle;
                            model.CCRMMIFMasterAndDetailsDTO.BillAddress = model.BillAddress;
                            model.CCRMMIFMasterAndDetailsDTO.ModelNo = model.ModelNo;
                            model.CCRMMIFMasterAndDetailsDTO.SerialNo = model.SerialNo;
                            model.CCRMMIFMasterAndDetailsDTO.MIFType = model.MIFType;
                            model.CCRMMIFMasterAndDetailsDTO.MachineFamilyID = model.MachineFamilyID;
                            model.CCRMMIFMasterAndDetailsDTO.CCRMEngineersGroupMasterID = model.CCRMEngineersGroupMasterID;
                            model.CCRMMIFMasterAndDetailsDTO.CCRMAreaPatchMasterID = model.CCRMAreaPatchMasterID;
                            model.CCRMMIFMasterAndDetailsDTO.CountryID = model.CountryID;
                            model.CCRMMIFMasterAndDetailsDTO.StateID = model.StateID;
                            model.CCRMMIFMasterAndDetailsDTO.CityID = model.CityID;
                            model.CCRMMIFMasterAndDetailsDTO.Category = model.Category;
                            model.CCRMMIFMasterAndDetailsDTO.CCRMLocationTypeID = model.CCRMLocationTypeID;
                            model.CCRMMIFMasterAndDetailsDTO.Priority = model.Priority;
                            model.CCRMMIFMasterAndDetailsDTO.InstalledById = model.InstalledById;
                            model.CCRMMIFMasterAndDetailsDTO.ServiceEngID = model.ServiceEngID;
                            model.CCRMMIFMasterAndDetailsDTO.CollExecId = model.CollExecId;
                            model.CCRMMIFMasterAndDetailsDTO.ISPrinter = model.ISPrinter;
                            model.CCRMMIFMasterAndDetailsDTO.ISScanner = model.ISScanner;
                            model.CCRMMIFMasterAndDetailsDTO.ISFax = model.ISFax;
                            model.CCRMMIFMasterAndDetailsDTO.Others = model.Others;
                            model.CCRMMIFMasterAndDetailsDTO.WarantyInDays = model.WarantyInDays;
                            model.CCRMMIFMasterAndDetailsDTO.WarantyExpiryDate = model.WarantyExpiryDate;
                            model.CCRMMIFMasterAndDetailsDTO.Status = model.Status;
                            model.CCRMMIFMasterAndDetailsDTO.InactiveDate = model.InactiveDate;
                            model.CCRMMIFMasterAndDetailsDTO.Remarks = model.Remarks;
                            model.CCRMMIFMasterAndDetailsDTO.EmailCorporate = model.EmailCorporate;
                            model.CCRMMIFMasterAndDetailsDTO.EmailAccounts = model.EmailAccounts;
                            model.CCRMMIFMasterAndDetailsDTO.Emailservices = model.Emailservices;
                            model.CCRMMIFMasterAndDetailsDTO.KeyOperatorName = model.KeyOperatorName;
                            model.CCRMMIFMasterAndDetailsDTO.PhoneNo = model.PhoneNo;
                            model.CCRMMIFMasterAndDetailsDTO.MobileNo = model.MobileNo;
                            //model.CCRMMIFMasterAndDetailsDTO.SelectedContactDetailsIDs = model.SelectedContactDetailsIDs;

                            model.CCRMMIFMasterAndDetailsDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                            IBaseEntityResponse<CCRMMIFMasterAndDetails> response = _CCRMMIFMasterAndDetailsBA.UpdateCCRMMIFMasterAndDetails(model.CCRMMIFMasterAndDetailsDTO);
                            model.CCRMMIFMasterAndDetailsDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                        }
                    }
                    return Json(model.CCRMMIFMasterAndDetailsDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public ActionResult Delete(int ID)
        {
            CCRMMIFMasterAndDetailsViewModel model = new CCRMMIFMasterAndDetailsViewModel();
            //if (!ModelState.IsValid)
            //{
            if (ID > 0)
            {
                CCRMMIFMasterAndDetails CCRMMIFMasterAndDetailsDTO = new CCRMMIFMasterAndDetails();
                CCRMMIFMasterAndDetailsDTO.ConnectionString = _connectioString;
                // CCRMMIFMasterAndDetailsDTO.ID = ID;
                CCRMMIFMasterAndDetailsDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                IBaseEntityResponse<CCRMMIFMasterAndDetails> response = _CCRMMIFMasterAndDetailsBA.DeleteCCRMMIFMasterAndDetails(CCRMMIFMasterAndDetailsDTO);
                model.CCRMMIFMasterAndDetailsDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);

            }
            return Json(model.CCRMMIFMasterAndDetailsDTO.errorMessage, JsonRequestBehavior.AllowGet);
            //}
            //else
            //{
            //    return Json("Please review your form");
            //}
        }
        #endregion
        // Non-Action Method
        #region Methods
       
        public IEnumerable<CCRMMIFMasterAndDetailsViewModel> GetCCRMMIFMasterAndDetails(out int TotalRecords)
        {
            CCRMMIFMasterAndDetailsSearchRequest searchRequest = new CCRMMIFMasterAndDetailsSearchRequest();
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
            List<CCRMMIFMasterAndDetailsViewModel> listCCRMMIFMasterAndDetailsViewModel = new List<CCRMMIFMasterAndDetailsViewModel>();
            List<CCRMMIFMasterAndDetails> listCCRMMIFMasterAndDetails = new List<CCRMMIFMasterAndDetails>();
            IBaseEntityCollectionResponse<CCRMMIFMasterAndDetails> baseEntityCollectionResponse = _CCRMMIFMasterAndDetailsBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listCCRMMIFMasterAndDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (CCRMMIFMasterAndDetails item in listCCRMMIFMasterAndDetails)
                    {
                        CCRMMIFMasterAndDetailsViewModel CCRMMIFMasterAndDetailsViewModel = new CCRMMIFMasterAndDetailsViewModel();
                        CCRMMIFMasterAndDetailsViewModel.CCRMMIFMasterAndDetailsDTO = item;
                        listCCRMMIFMasterAndDetailsViewModel.Add(CCRMMIFMasterAndDetailsViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listCCRMMIFMasterAndDetailsViewModel;
        }
        protected List<CCRMCustomerSegement> GetCCRMCustomerSegement()
        {
            CCRMCustomerSegementSearchRequest searchRequest = new CCRMCustomerSegementSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<CCRMCustomerSegement> listCCRMCustomerSegement = new List<CCRMCustomerSegement>();
            IBaseEntityCollectionResponse<CCRMCustomerSegement> baseEntityCollectionResponse = _CCRMCustomerSegementBA.GetCCRMCustomerSegementList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listCCRMCustomerSegement = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listCCRMCustomerSegement;
        }
        protected List<CCRMMachineFamilyMaster> GetCCRMMachineFamilyMaster()
        {
            CCRMMachineFamilyMasterSearchRequest searchRequest = new CCRMMachineFamilyMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<CCRMMachineFamilyMaster> listCCRMMachineFamilyMaster = new List<CCRMMachineFamilyMaster>();
            IBaseEntityCollectionResponse<CCRMMachineFamilyMaster> baseEntityCollectionResponse = _CCRMMachineFamilyMasterBA.GetCCRMMachineFamilyMasterList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listCCRMMachineFamilyMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listCCRMMachineFamilyMaster;
        }
        protected List<CCRMLocationTypeMaster> GetCCRMLocationTypeMaster()
        {
            CCRMLocationTypeMasterSearchRequest searchRequest = new CCRMLocationTypeMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<CCRMLocationTypeMaster> listCCRMLocationTypeMaster = new List<CCRMLocationTypeMaster>();
            IBaseEntityCollectionResponse<CCRMLocationTypeMaster> baseEntityCollectionResponse = _CCRMLocationTypeMasterBA.GetCCRMLocationTypeMasterList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listCCRMLocationTypeMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listCCRMLocationTypeMaster;
        }
        //*********************EmployeeSrviveEngg*********************//
        //protected List<EmpEmployeeMaster> GetEmpEmployeeMasterService()
        //{
        //    EmpEmployeeMasterSearchRequest searchRequest = new EmpEmployeeMasterSearchRequest();
        //    searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        //    List<EmpEmployeeMaster> listEmpEmployeeMaster = new List<EmpEmployeeMaster>();
        //    IBaseEntityCollectionResponse<EmpEmployeeMaster> baseEntityCollectionResponse = _EmpEmployeeMasterBA.GetEmpEmployeeMasterServiceList(searchRequest);
        //    if (baseEntityCollectionResponse != null)
        //    {
        //        if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
        //        {
        //            listEmpEmployeeMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
        //        }
        //    }
        //    return listEmpEmployeeMaster;
        //}
        //*********************EmployeeExecutive*********************//
        protected List<EmpEmployeeMaster> GetEmpEmployeeMasterExecutive()
        {
            EmpEmployeeMasterSearchRequest searchRequest = new EmpEmployeeMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<EmpEmployeeMaster> listEmpEmployeeMaster = new List<EmpEmployeeMaster>();
            IBaseEntityCollectionResponse<EmpEmployeeMaster> baseEntityCollectionResponse = _EmpEmployeeMasterBA.GetEmpEmployeeMasterExecutive(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listEmpEmployeeMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listEmpEmployeeMaster;
        }
        //******************************************//
        protected List<CCRMEngineersGroupMaster> GetCCRMEngineersGroupMaster()
        {
            CCRMEngineersGroupMasterSearchRequest searchRequest = new CCRMEngineersGroupMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<CCRMEngineersGroupMaster> listCCRMEngineersGroupMaster = new List<CCRMEngineersGroupMaster>();
            IBaseEntityCollectionResponse<CCRMEngineersGroupMaster> baseEntityCollectionResponse = _CCRMEngineersGroupMasterBA.GetCCRMEngineersGroupMasterList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listCCRMEngineersGroupMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listCCRMEngineersGroupMaster;
        }
        [HttpPost]
        public JsonResult GetCCRMMIFSerialNoSearchList(string term)
        {
            CCRMMIFMasterAndDetailsSearchRequest searchRequest = new CCRMMIFMasterAndDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            searchRequest.SearchWord = term;
            List<CCRMMIFMasterAndDetails> listCCRMMIFMasterAndDetails = new List<CCRMMIFMasterAndDetails>();
            IBaseEntityCollectionResponse<CCRMMIFMasterAndDetails> baseEntityCollectionResponse = _CCRMMIFMasterAndDetailsBA.GetCCRMMIFSerialNoSearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listCCRMMIFMasterAndDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            var result = (from r in listCCRMMIFMasterAndDetails
                          select new
                          {
                              ID=r.ID,
                              CustomerMasterID = r.CustomerMasterID,
                              SerialNo = r.SerialNo,
                              CustomerMasterName = r.CustomerMasterName,
                              //CustomerType = r.CustomerType,
                              CustomerAddress = r.CustomerAddress,
                              MIFTitle = r.MIFTitle,
                              MIFAddress = r.MIFAddress,
                              ModelNo = r.ModelNo,
                              ItemDescription = r.ItemDescription,
                              ColorMono = r.ColorMono,
                              PaperSize = r.PaperSize,
                              KeyOperatorName = r.KeyOperatorName,
                              MifcallID = r.ID,
                              PhoneNo = r.Phone,
                              ContractTypeId = r.ContractTypeId,
                              ContractNo = r.ContractNo,
                              ContractName = r.ContractName,
                              ContractOpDate = r.ContractOpDate,
                              ContractClosingDate = r.ContractClosingDate,
                              MobileNo = r.MobileNo,
                              EmailServices = r.EmailServices,
                              CallCharges = r.CallCharges,
                              ContractCode=r.ContractCode,
                              MachineFamilyID=r.MachineFamilyID,
                              MachineFamilyName=r.MachineFamilyName,

                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetCCRMContractMasterSerialNoSearchList(string term)
        {
            CCRMMIFMasterAndDetailsSearchRequest searchRequest = new CCRMMIFMasterAndDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            searchRequest.SearchWord = term;
            List<CCRMMIFMasterAndDetails> listCCRMMIFMasterAndDetails = new List<CCRMMIFMasterAndDetails>();
            IBaseEntityCollectionResponse<CCRMMIFMasterAndDetails> baseEntityCollectionResponse = _CCRMMIFMasterAndDetailsBA.GetCCRMContractMasterSerialNoSearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listCCRMMIFMasterAndDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            var result = (from r in listCCRMMIFMasterAndDetails
                          select new
                          {
                              ID = r.ID,
                              CustomerMasterID = r.CustomerMasterID,
                              SerialNo = r.SerialNo,
                              CustomerMasterName = r.CustomerMasterName,
                              //CustomerType = r.CustomerType,
                              CustomerAddress = r.CustomerAddress,
                              MIFTitle = r.MIFTitle,
                              MIFAddress = r.MIFAddress,
                              ModelNo = r.ModelNo,
                              ItemDescription = r.ItemDescription,
                              ColorMono = r.ColorMono,
                              PaperSize = r.PaperSize,
                              KeyOperatorName = r.KeyOperatorName,
                              MifcallID = r.ID,
                              PhoneNo = r.Phone,
                              //ContractTypeId = r.ContractTypeId,
                              //ContractNo = r.ContractNo,
                              //ContractName = r.ContractName,
                              //ContractOpDate = r.ContractOpDate,
                              //ContractClosingDate = r.ContractClosingDate,
                              MobileNo = r.MobileNo,
                              EmailServices = r.EmailServices,
                              CallCharges = r.CallCharges,
                             // ContractCode = r.ContractCode,
                              MachineFamilyID = r.MachineFamilyID,
                              MachineFamilyName = r.MachineFamilyName,

                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult GetCCRMMIFCallerNameSearchList(string term)
        {
            CCRMMIFMasterAndDetailsSearchRequest searchRequest = new CCRMMIFMasterAndDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            searchRequest.SearchWord = term;
            List<CCRMMIFMasterAndDetails> listCCRMMIFMasterAndDetails = new List<CCRMMIFMasterAndDetails>();
            IBaseEntityCollectionResponse<CCRMMIFMasterAndDetails> baseEntityCollectionResponse = _CCRMMIFMasterAndDetailsBA.GetCCRMMIFCallerNameSearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listCCRMMIFMasterAndDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            var result = (from r in listCCRMMIFMasterAndDetails
                          select new
                          {
                              ID = r.ID,
                              KeyOperatorName=r.KeyOperatorName,
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
            IEnumerable<CCRMMIFMasterAndDetailsViewModel> filteredCCRMMIFMasterAndDetailsViewModel;

            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "MIFTitle";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "MIFTitle Like '%" + param.sSearch + "%' or MIFAddress Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "MIFAddress";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "MIFTitle Like '%" + param.sSearch + "%' or MIFAddress Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;

            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            filteredCCRMMIFMasterAndDetailsViewModel = GetCCRMMIFMasterAndDetails(out TotalRecords);
            var records = filteredCCRMMIFMasterAndDetailsViewModel.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.InstallationDate),  Convert.ToString(c.ID), Convert.ToString(c.CustomerCode), Convert.ToString(c.CustomerMasterID), Convert.ToString(c.CustomerAddress), Convert.ToString(c.CustomerPinCode), Convert.ToString(c.CutomerSegementMasterID), Convert.ToString(c.MIFTitle), Convert.ToString(c.MIFAddress), Convert.ToString(c.MIFPinCode), Convert.ToString(c.FolioNo), Convert.ToString(c.BillTitle), Convert.ToString(c.BillAddress), Convert.ToString(c.ModelNo), Convert.ToString(c.SerialNo), Convert.ToString(c.MIFType), Convert.ToString(c.MachineFamilyID),Convert.ToString(c.CountryID), Convert.ToString(c.StateID), Convert.ToString(c.CityID), Convert.ToString(c.AreaPatchName), Convert.ToString(c.Group), Convert.ToString(c.CCRMLocationTypeID), Convert.ToString(c.Priority) };

                return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
            }

        #endregion
    }

}
