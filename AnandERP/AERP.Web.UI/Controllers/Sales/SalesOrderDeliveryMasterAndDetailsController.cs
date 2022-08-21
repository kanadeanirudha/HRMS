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
using System.Web.Hosting;
using System.Data;
using iTextSharp.text;
using iTextSharp.text.pdf;
//using System.IO;
using iTextSharp.text.html.simpleparser;
//using iTextSharp.text.pdf.parser;
using System.Web;
using iTextSharp.text.html;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
namespace AERP.Web.UI.Controllers
{
    public class SalesOrderDeliveryMasterAndDetailsController : BaseController
    {
        ISalesOrderDeliveryMasterAndDetailsBA _SalesOrderDeliveryMasterAndDetailsBA = null;
        IGeneralUnitsBA _GeneralUnitsBA = null;
        IGeneralShipperMasterBA _GeneralShipperMasterBA = null;

        IGeneralTaxGroupMasterBA _GeneralTaxGroupMasterBA = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public SalesOrderDeliveryMasterAndDetailsController()
        {
            _SalesOrderDeliveryMasterAndDetailsBA = new SalesOrderDeliveryMasterAndDetailsBA();
            _GeneralUnitsBA = new GeneralUnitsBA();
            _GeneralShipperMasterBA = new GeneralShipperMasterBA();
            _GeneralTaxGroupMasterBA = new GeneralTaxGroupMasterBA();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
            bool IsApplied = CheckMenuApplicableOrNot(ControllerContext.RouteData.Values["Controller"].ToString());
            if (Convert.ToString(Session["UserType"]) == "A" || ((Convert.ToInt32(Session["Sales Manager"]) > 0 || Convert.ToInt32(Session["Sales Manager:Entity"]) > 0 || Convert.ToInt32(Session["Store Manager"]) > 0) && IsApplied == true))
            {
                SalesOrderDeliveryMasterAndDetailsViewModel model = new SalesOrderDeliveryMasterAndDetailsViewModel();
                List<SelectListItem> SOStatus = new List<SelectListItem>();
                ViewBag.SOStatus = new SelectList(SOStatus, "Value", "Text");
                List<SelectListItem> SOStatus_li = new List<SelectListItem>();
                SOStatus_li.Add(new SelectListItem { Text = "All", Value = "0" });
                SOStatus_li.Add(new SelectListItem { Text = "Completed", Value = "1" });
                SOStatus_li.Add(new SelectListItem { Text = "Pending", Value = "2" });

                ViewData["SOStatus"] = new SelectList(SOStatus_li, "Value", "Text");

                List<SelectListItem> MonthList = new List<SelectListItem>();
                DateTimeFormatInfo info = DateTimeFormatInfo.GetInstance(null);
                ViewBag.MonthList = new SelectList(MonthList, "Value", "Text");
                List<SelectListItem> li_MonthList = new List<SelectListItem>();
                li_MonthList.Add(new SelectListItem { Text = "--Select month -- ", Value = "0" });
                for (int i = 1; i < 13; i++)
                {
                    ViewBag.MonthList = new SelectList(info.GetMonthName(i), i.ToString());
                    li_MonthList.Add(new SelectListItem { Text = info.GetMonthName(i), Value = (i).ToString() });
                }
                ViewData["MonthName"] = new SelectList(li_MonthList, "Value", "Text");
                //For Year
                int year = DateTime.Now.Year - 65;
                List<SelectListItem> li_YearList = new List<SelectListItem>();
                ViewBag.YearList = new SelectList(li_YearList, "Value", "Text");
                li_YearList.Add(new SelectListItem { Text = "-- Select Year --", Value = "0" });
                for (int i = DateTime.Now.Year; year <= i; i--)
                {
                    li_YearList.Add(new SelectListItem { Text = Convert.ToString(i), Value = Convert.ToString(i) });
                }
                ViewData["MonthYear"] = new SelectList(li_YearList, "Value", "Text");

                return View("/Views/Sales/SalesOrderDeliveryMasterAndDetails/Index.cshtml", model);
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
                SalesOrderDeliveryMasterAndDetailsViewModel model = new SalesOrderDeliveryMasterAndDetailsViewModel();
                int AdminRoleID = 0;
                if (Session["RoleID"] == null)
                {
                    AdminRoleID = !string.IsNullOrEmpty(Convert.ToString(Session["DefaultRoleID"])) ? Convert.ToInt32(Session["DefaultRoleID"]) : 0;
                }

                else
                {
                    AdminRoleID = !string.IsNullOrEmpty(Convert.ToString(Session["RoleID"])) ? Convert.ToInt32(Session["RoleID"]) : 0;
                }
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                model.AdminRoleID = AdminRoleID;
                return PartialView("/Views/Sales/SalesOrderDeliveryMasterAndDetails/List.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }


        [HttpGet]
        public ActionResult Create(string id)
        {
            SalesOrderDeliveryMasterAndDetailsViewModel model = new SalesOrderDeliveryMasterAndDetailsViewModel();
            try
            {

                model.SalesOrderDeliveryMasterAndDetailsDTO = new SalesOrderDeliveryMasterAndDetails();

                string[] IDsArray = id.Split('~');
                model.SalesOrderDeliveryMasterAndDetailsDTO.SalesOrderMasterID = Convert.ToInt32(IDsArray[0]);
                model.SalesOrderDeliveryMasterAndDetailsDTO.ConnectionString = _connectioString;
                model.SalesOrderDeliveryMasterAndDetailsListFromPO = GetDeliveryMemoListBySalesOrder(model.SalesOrderMasterID);

                for (int i = 0; i < model.SalesOrderDeliveryMasterAndDetailsListFromPO.Count; i++)
                {
                    if (model.SalesOrderDeliveryMasterAndDetailsListFromPO.Count > 0 && model.SalesOrderDeliveryMasterAndDetailsListFromPO != null)
                    {
                        model.SalesOrderDate = model.SalesOrderDeliveryMasterAndDetailsListFromPO[0].SalesOrderDate;
                        model.TotalTaxAmount = model.SalesOrderDeliveryMasterAndDetailsListFromPO[0].TotalTaxAmount;
                        model.ShippingHandling = model.SalesOrderDeliveryMasterAndDetailsListFromPO[0].ShippingHandling;
                        model.Discount = model.SalesOrderDeliveryMasterAndDetailsListFromPO[0].Discount;
                        model.Freight = model.SalesOrderDeliveryMasterAndDetailsListFromPO[0].Freight;
                        model.GeneralUnitsID = model.SalesOrderDeliveryMasterAndDetailsListFromPO[0].GeneralUnitsID;
                        model.SalesOrderNumber = model.SalesOrderDeliveryMasterAndDetailsListFromPO[0].SalesOrderNumber;
                        model.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        model.DeliveryTransDate = DateTime.UtcNow.ToString();
                        model.TotalBillAmount = Math.Round(model.SalesOrderDeliveryMasterAndDetailsListFromPO[i].TotalBillAmount, 2);
                        model.TotalAmount = Math.Round(model.TotalAmount + model.SalesOrderDeliveryMasterAndDetailsListFromPO[i].TaxableAmount, 2);


                    }
                }
                string CentreCode = string.Empty;
                model.ListGeneralUnits = GetGeneralUnitsForItemmaster(CentreCode);
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


                List<GeneralShipperMaster> GeneralItemShipperMaster = GetDropDownListForShipperMaster();
                List<SelectListItem> GeneralItemShipperName = new List<SelectListItem>();
                foreach (GeneralShipperMaster item in GeneralItemShipperMaster)
                {
                    GeneralItemShipperName.Add(new SelectListItem { Text = item.CompanyName, Value = Convert.ToString(item.ID) });
                }
                ViewBag.GeneralItemShipperName = new SelectList(GeneralItemShipperName, "Value", "Text", model.GeneralShipperID);


                return PartialView("/Views/Sales/SalesOrderDeliveryMasterAndDetails/Create.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpGet]
        public ActionResult CreateDeliveryMemo()
        {
            SalesOrderDeliveryMasterAndDetailsViewModel model = new SalesOrderDeliveryMasterAndDetailsViewModel();
            try
            {

                model.SalesOrderDeliveryMasterAndDetailsDTO = new SalesOrderDeliveryMasterAndDetails();

                string CentreCode = string.Empty;
                model.ListGeneralUnits = GetGeneralUnitsForItemmaster(CentreCode);
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


                List<GeneralShipperMaster> GeneralItemShipperMaster = GetDropDownListForShipperMaster();
                List<SelectListItem> GeneralItemShipperName = new List<SelectListItem>();
                foreach (GeneralShipperMaster item in GeneralItemShipperMaster)
                {
                    GeneralItemShipperName.Add(new SelectListItem { Text = item.CompanyName, Value = Convert.ToString(item.ID) });
                }
                ViewBag.GeneralItemShipperName = new SelectList(GeneralItemShipperName, "Value", "Text", model.GeneralShipperID);


                return PartialView("/Views/Sales/SalesOrderDeliveryMasterAndDetails/CreateDeliveryMemo.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }


        [HttpPost]
        public ActionResult Create(SalesOrderDeliveryMasterAndDetailsViewModel model)
        {
            try
            {
                //if (ModelState.IsValid)
                // {
                if (model != null && model.SalesOrderDeliveryMasterAndDetailsDTO != null)
                {
                    model.SalesOrderDeliveryMasterAndDetailsDTO.ConnectionString = _connectioString;
                    model.SalesOrderDeliveryMasterAndDetailsDTO.VehicalNumber = model.VehicalNumber;
                    model.SalesOrderDeliveryMasterAndDetailsDTO.GeneralShipperID = model.GeneralShipperID;
                    model.SalesOrderDeliveryMasterAndDetailsDTO.DeliveryTransDate = model.DeliveryTransDate;
                    model.SalesOrderDeliveryMasterAndDetailsDTO.ShipToCityID = model.ShipToCityID;
                    model.SalesOrderDeliveryMasterAndDetailsDTO.ShipToCountryID = model.ShipToCountryID;
                    model.SalesOrderDeliveryMasterAndDetailsDTO.ShipToStateID = model.ShipToStateID;
                    model.SalesOrderDeliveryMasterAndDetailsDTO.ShipToAddress = model.ShipToAddress;
                    model.SalesOrderDeliveryMasterAndDetailsDTO.GeneralUnitsID = model.GeneralUnitsID;
                    model.SalesOrderDeliveryMasterAndDetailsDTO.SalesOrderMasterID = model.SalesOrderMasterID;
                    model.SalesOrderDeliveryMasterAndDetailsDTO.FrieghtCharges = model.Freight;
                    model.SalesOrderDeliveryMasterAndDetailsDTO.TransportationMode = model.TransportationMode;
                    model.SalesOrderDeliveryMasterAndDetailsDTO.XmlString = model.XmlString;


                    model.SalesOrderDeliveryMasterAndDetailsDTO.IsLocked = model.IsLocked;
                    model.SalesOrderDeliveryMasterAndDetailsDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<SalesOrderDeliveryMasterAndDetails> response = _SalesOrderDeliveryMasterAndDetailsBA.InsertSalesOrderDeliveryMasterAndDetails(model.SalesOrderDeliveryMasterAndDetailsDTO);

                    model.SalesOrderDeliveryMasterAndDetailsDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.SalesOrderDeliveryMasterAndDetailsDTO.errorMessage, JsonRequestBehavior.AllowGet);
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

        [HttpPost]
        public ActionResult CreateDirectDM(SalesOrderDeliveryMasterAndDetailsViewModel model)
        {
            try
            {
                //if (ModelState.IsValid)
                // {
                if (model != null && model.SalesOrderDeliveryMasterAndDetailsDTO != null)
                {
                    model.SalesOrderDeliveryMasterAndDetailsDTO.ConnectionString = _connectioString;
                    model.SalesOrderDeliveryMasterAndDetailsDTO.VehicalNumber = model.VehicalNumber;
                    model.SalesOrderDeliveryMasterAndDetailsDTO.GeneralShipperID = model.GeneralShipperID;
                    model.SalesOrderDeliveryMasterAndDetailsDTO.DeliveryTransDate = model.DeliveryTransDate;
                    model.SalesOrderDeliveryMasterAndDetailsDTO.ShipToCityID = model.ShipToCityID;
                    model.SalesOrderDeliveryMasterAndDetailsDTO.ShipToCountryID = model.ShipToCountryID;
                    model.SalesOrderDeliveryMasterAndDetailsDTO.ShipToStateID = model.ShipToStateID;
                    model.SalesOrderDeliveryMasterAndDetailsDTO.ShipToAddress = model.ShipToAddress;
                    model.SalesOrderDeliveryMasterAndDetailsDTO.GeneralUnitsID = model.GeneralUnitsID;
                    model.SalesOrderDeliveryMasterAndDetailsDTO.SalesOrderMasterID = model.SalesOrderMasterID;
                    model.SalesOrderDeliveryMasterAndDetailsDTO.CustomerBranchMasterID = model.CustomerBranchMasterID;
                    model.SalesOrderDeliveryMasterAndDetailsDTO.CustomerMasterID = model.CustomerMasterID;
                    model.SalesOrderDeliveryMasterAndDetailsDTO.ContactPersonID = model.ContactPersonID;
                    model.SalesOrderDeliveryMasterAndDetailsDTO.FrieghtCharges = model.Freight;
                    model.SalesOrderDeliveryMasterAndDetailsDTO.XmlString = model.XmlString;
                    model.SalesOrderDeliveryMasterAndDetailsDTO.TotalTaxAmount = model.TotalTaxAmount;
                    model.SalesOrderDeliveryMasterAndDetailsDTO.TotalAmount = model.TotalAmount;
                    model.SalesOrderDeliveryMasterAndDetailsDTO.TotalBillAmount = model.TotalBillAmount;

                    model.SalesOrderDeliveryMasterAndDetailsDTO.IsLocked = model.IsLocked;
                    model.SalesOrderDeliveryMasterAndDetailsDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<SalesOrderDeliveryMasterAndDetails> response = _SalesOrderDeliveryMasterAndDetailsBA.InsertSalesOrderDeliveryMasterAndDetailsForDirectDM(model.SalesOrderDeliveryMasterAndDetailsDTO);

                    model.SalesOrderDeliveryMasterAndDetailsDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.SalesOrderDeliveryMasterAndDetailsDTO.errorMessage, JsonRequestBehavior.AllowGet);
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



        [HttpPost]
        public ActionResult Edit(SalesOrderDeliveryMasterAndDetailsViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model != null && model.SalesOrderDeliveryMasterAndDetailsDTO != null)
                {
                    if (model != null && model.SalesOrderDeliveryMasterAndDetailsDTO != null)
                    {
                        model.SalesOrderDeliveryMasterAndDetailsDTO.ConnectionString = _connectioString;
                        //  model.SalesOrderDeliveryMasterAndDetailsDTO.CompanyName = model.CompanyName;

                        model.SalesOrderDeliveryMasterAndDetailsDTO.IsActive = model.IsActive;

                        model.SalesOrderDeliveryMasterAndDetailsDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<SalesOrderDeliveryMasterAndDetails> response = _SalesOrderDeliveryMasterAndDetailsBA.UpdateSalesOrderDeliveryMasterAndDetails(model.SalesOrderDeliveryMasterAndDetailsDTO);
                        model.SalesOrderDeliveryMasterAndDetailsDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                    }
                }
                return Json(model.SalesOrderDeliveryMasterAndDetailsDTO.errorMessage, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Please review your form");
            }
        }
        [HttpGet]
        public ActionResult ViewDetails(int id, int SaleOrderMasterID)
        {
            try
            {
                SalesOrderDeliveryMasterAndDetailsViewModel model = new SalesOrderDeliveryMasterAndDetailsViewModel();
                model.SalesOrderDeliveryMasterAndDetailsDTO.SalesOrderDeliveryMasterID = id;
                model.SalesOrderDeliveryMasterAndDetailsDTO.SalesOrderMasterID = SaleOrderMasterID;
                model.SalesOrderDeliveryMasterAndDetailsList = GetDeliveryMemoDetailsByID(id, SaleOrderMasterID);
                //model.PurchaseRequisitionMasterList = GetPurchaseRequisitionMasterList(id);
                if (model.SalesOrderDeliveryMasterAndDetailsList.Count > 0 && model.SalesOrderDeliveryMasterAndDetailsList != null)
                {
                    model.DeliveryNumber = model.SalesOrderDeliveryMasterAndDetailsList[0].DeliveryNumber;
                    model.DeliveryTransDate = model.SalesOrderDeliveryMasterAndDetailsList[0].DeliveryTransDate;
                    model.IsInvoiced = model.SalesOrderDeliveryMasterAndDetailsList[0].IsInvoiced;
                    model.IsDeleted = model.SalesOrderDeliveryMasterAndDetailsList[0].IsDeleted;
                    model.IsCancelled = model.SalesOrderDeliveryMasterAndDetailsList[0].IsCancelled;
                }

                return PartialView("/Views/Sales/SalesOrderDeliveryMasterAndDetails/View.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }
        [HttpGet]
        public ActionResult ErorMessage(int id, int SaleMstID)
        {
            try
            {
                SalesOrderDeliveryMasterAndDetailsViewModel model = new SalesOrderDeliveryMasterAndDetailsViewModel();
                model.SalesOrderDeliveryMasterAndDetailsDTO.SalesOrderDeliveryMasterID = id;
                model.SalesOrderDeliveryMasterAndDetailsDTO.SalesOrderMasterID = SaleMstID;
                return PartialView("/Views/Sales/SalesOrderDeliveryMasterAndDetails/ErrorMessage.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }
        [HttpPost]
        public FileStreamResult Download(SalesOrderDeliveryMasterAndDetailsViewModel _model)
        {
            SalesOrderDeliveryMasterAndDetailsViewModel model = new SalesOrderDeliveryMasterAndDetailsViewModel();
            try
            {


                model.SalesOrderDeliveryMasterAndDetailsDTO = new SalesOrderDeliveryMasterAndDetails();
                model.SalesOrderDeliveryMasterAndDetailsDTO.SalesOrderDeliveryMasterID = _model.SalesOrderDeliveryMasterID;
                model.SalesOrderDeliveryMasterAndDetailsDTO.SalesOrderMasterID = _model.SalesOrderMasterID;
                model.SalesOrderDeliveryMasterAndDetailsDTO.ConnectionString = _connectioString;
                decimal TotalAmount = 0; decimal TotalBillAmount = 0;
                //Code For Generate PDF
                model.SalesOrderDMList = GetRecordForSalesOrderDeliveryMemoPDF(_model.SalesOrderDeliveryMasterID, _model.SalesOrderMasterID);
                model.SalesOrderNumber = model.SalesOrderDMList[0].SalesOrderNumber;
                model.DeliveryNumber = model.SalesOrderDMList[0].DeliveryNumber;
                model.IsOther = model.SalesOrderDMList[0].IsOther;


                string FromDetailTable = "SalesOrderDeliveryMemoDetails";
                model.TaxSummaryList = GetTaxSummaryForDisplay(model.IsOther, _model.SalesOrderDeliveryMasterID, FromDetailTable);
                string SalesOrderPDF = " ";


                SalesOrderPDF = SalesOrderPDF + "<table width='650'><tr><td style='text-align:left;'><img src='" + Path.Combine(Server.MapPath("~") + "Content\\UploadedFiles\\Inventory\\Logo\\" + model.SalesOrderDMList[0].LogoPath) + "' height='70' width='70'><br><br><span style='font-size:7pt;text-align:left;'>" + model.SalesOrderDMList[0].PrintingLineBelowLogo + "<span></td>";

                SalesOrderPDF = SalesOrderPDF + " <td><table width='300' bgcolor='#fff;' color='black' style='font-size:7pt;'><tr><td style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:10pt;text-align:left;font-family:'Century Gothic'><b>" + model.SalesOrderDMList[0].CentreName + ":</b></td></tr></hr><tr><td style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:9pt;text-align:left;'><b><u>" + model.SalesOrderDMList[0].CentreSpecialization + "</u></b></td></tr><tr><td style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left;'>" + model.SalesOrderDMList[0].CentreAddress1 + "</td></tr><tr><td style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left;'>" + model.SalesOrderDMList[0].CentreAddress2 + "</td></tr><tr><td style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left;'>Ph:" + model.SalesOrderDMList[0].PhoneNumberOffice + "</td></tr><tr><td style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left;'>Cell :" + model.SalesOrderDMList[0].CellPhone + "</td></tr><tr><td style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left;'>E-mail :" + model.SalesOrderDMList[0].EmailID + "</td>< tr><td style = 'border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left;' >Website :" + model.SalesOrderDMList[0].Website + " </td ></tr></tr>";

                SalesOrderPDF = SalesOrderPDF + "</table></td></tr></table>";

                SalesOrderPDF = SalesOrderPDF + "<table border= '1' bgcolor='#fff;' color='black' style=' border-collapse:collapse;font-size:7pt;'><b>PurchaseOrder</b><tr><td colspan='2'  bgcolor='#F7F2F2' style='padding:0 5px 5px;font-size:10pt;text-align:center;'><b><u>Sales Order Delivery Memo</u><b></td></tr><tr><td bgcolor='#F7F2F2' style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left; '><b>GSTIN Number</b>: " + model.SalesOrderDMList[0].GSTINNumber + "</td><td  bgcolor='#F7F2F2' style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left;'><b>Transportation Mode <b>: " + model.SalesOrderDMList[0].TransportationMode + " </td></tr><tr><td bgcolor='#F7F2F2' style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left; '><b>PAN Number</b>: " + model.SalesOrderDMList[0].PanNumber + "</td><td bgcolor='#F7F2F2' style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left; '><b>Vehical Number </b>: " + model.SalesOrderDMList[0].VehicalNumber + "</td></tr><tr><td bgcolor='#F7F2F2' style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left;'><b>CIN Number</b>: " + model.SalesOrderDMList[0].CINNumber + "</td><td bgcolor='#F7F2F2' style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left; '>Date and Time :" + model.SalesOrderDMList[0].DeliveryTransDate + "</td></tr><tr><td bgcolor='#F7F2F2' style='border: 1px solid black;border-collapse: collapse; padding: 5px;text-align:left; '><b>Tax is payable on Reverse Charge</b> :(No)</td><td  bgcolor='#F7F2F2' style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left; '><b>Place of Supply</b> : " + model.SalesOrderDMList[0].ShipToAddress + "</td> </tr><tr><td bgcolor='#F7F2F2' style='border: 1px solid black;border-collapse: collapse; padding: 5px;text-align:left; '><b>Delivery Number</b> :" + model.SalesOrderDMList[0].DeliveryNumber + "</td><td bgcolor='#F7F2F2' style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left; '><b>Shipper Name </b>:" + model.SalesOrderDMList[0].ShipperName + "</td> </tr><tr><td bgcolor='#F7F2F2' style='border: 1px solid black;border-collapse: collapse; padding: 5px;text-align:left; '><b>Delivery Date</b> :" + model.SalesOrderDMList[0].DeliveryTransDate + "</td><td bgcolor='#F7F2F2' style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left; '><b>Purchase Order Number</b> :" + model.SalesOrderDMList[0].PurchaseOrderNumberClient + "</td> </tr></table>";

                SalesOrderPDF = SalesOrderPDF + "<br><table border= '1' bgcolor='#fff;' color='black' style=' border-collapse:collapse;font-size:11pt;'><b>Sales Order</b><tr><td bgcolor='#D3D3D3' color='black' style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:11pt;text-align:Center;'><b>Details of Receiver(Billed)</b></td><td  bgcolor='#D3D3D3' color='black' style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:11pt;text-align:Center;'><b>Details of Consignee(Shipped to)</b></td></tr>";

                SalesOrderPDF = SalesOrderPDF + " <tr><td style = 'border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left;' > <b>Customer Name :</b> " + model.SalesOrderDMList[0].CustomerName + "</td ><td style = 'border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left; ' ><b>Branch Name: </b>" + model.SalesOrderDMList[0].BranchName + " </td ></tr>";

                SalesOrderPDF = SalesOrderPDF + " <tr><td style = 'border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left;' > <b>Address:</b> " + model.SalesOrderDMList[0].CustomerAddress + "</td ><td style = 'border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left; ' ><b>Address:</b> " + model.SalesOrderDMList[0].CustomerBranchAddress + " </td ></tr>";

                SalesOrderPDF = SalesOrderPDF + " <tr><td style = 'border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left;' > <b>Country:</b> " + model.SalesOrderDMList[0].CountryName + " &nbsp;&nbsp;<b> State:</b> " + model.SalesOrderDMList[0].StateName + " &nbsp; &nbsp;<b> State Code:</b> " + model.SalesOrderDMList[0].StateCode + " </td ><td style = 'border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left; ' > <b>Country: </b>" + model.SalesOrderDMList[0].BranchCountryName + " &nbsp;&nbsp;<b> State: </b>" + model.SalesOrderDMList[0].BranchStateName + " &nbsp; &nbsp;<b> State Code:</b> " + model.SalesOrderDMList[0].BranchStateCode + " </td ></tr>";

                SalesOrderPDF = SalesOrderPDF + " <tr><td style = 'border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left;' > <b>City:</b> " + model.SalesOrderDMList[0].CityName + "<b>  Pin Code:</b> " + model.SalesOrderDMList[0].CustomerPinCode + "</td ><td style = 'border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left; ' ><b>City:</b> " + model.SalesOrderDMList[0].BranchCityName + " <b> Pin Code:</b> " + model.SalesOrderDMList[0].CustomerBranchPinCode + "</td ></tr><tr><td style = 'border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left;' > <b>GSTIN Number:</b> " + model.SalesOrderDMList[0].CustomerGSTNumber + "</td ><td style = 'border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left; ' ><b>GSTIN Number:</b> " + model.SalesOrderDMList[0].BranchGSTNumber + " </td ></tr></table>";

                SalesOrderPDF = SalesOrderPDF + "<br><table border= '1' bgcolor='#fff;' color='black'><tr><th  bgcolor='#D3D3D3' color='black' style='border: 1px solid black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt'>Sr.No</th><th  bgcolor='#D3D3D3' color='black' style='border: 1px solid black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt'>Description of goods/Services</th><th  bgcolor='#D3D3D3' color='black' style='border: 1px solid black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt'>HSN /SAC Code</th><th  bgcolor='#D3D3D3' color='black' style='border: 1px solid black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt'>Qty</th><th  bgcolor='#D3D3D3' color='black' style='border: 1px solid black; border-collapse: collapse; text-align: center; padding: 0px;font-size:7pt'>UOM</th>";
                if (_model.WithDMRate == 1)
                {
                    SalesOrderPDF = SalesOrderPDF + "<th  bgcolor='#D3D3D3' color='black' style='border: 1px solid black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt'>Rate</th><th  bgcolor='#D3D3D3' color='black' style='border: 1px solid black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt'>Total</th><th  bgcolor='#D3D3D3' color='black' style='border: 1px solid black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt'>Tax</th><th  bgcolor='#D3D3D3' color='black' style='border: 1px solid black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt'>Tax Amount</th><th  bgcolor='#D3D3D3' color='black' style='border: 1px solid black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt'>Amount</th>";
                }
                if (_model.WithDMRate == 3)
                {
                    SalesOrderPDF = SalesOrderPDF + "<th  bgcolor='#D3D3D3' color='black' style='border: 1px solid black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt'>Rate</th><th  bgcolor='#D3D3D3' color='black' style='border: 1px solid black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt'>Total</th>";
                }


                SalesOrderPDF = SalesOrderPDF + "</tr>";
                if (model.SalesOrderDMList.Count > 0 && model.SalesOrderDMList != null)
                {
                    int i = 1;
                    foreach (var item in model.SalesOrderDMList)
                    {

                        TotalAmount = TotalAmount + Math.Round(item.NetAmount, 2);
                        TotalBillAmount = TotalBillAmount + Math.Round(item.NetAmount, 2) + Math.Round(item.TaxAmount, 2);

                        SalesOrderPDF = SalesOrderPDF + "<tr><td  bgcolor='#F7F2F2' width='4%' color='black' style='border-collapse: collapse; text-align: left; padding: 5px;font-size:7pt;'>" + i + "</td><td  bgcolor='#F7F2F2' width='25%' color='black' style='border-collapse: collapse; text-align: left; padding: 5px;font-size:7pt;'>" + item.ItemDescription + "</td><td  bgcolor='#F7F2F2' width='7%' color='black' style='border-collapse: collapse; text-align: left; padding: 5px;font-size:7pt;'>" + item.HSNCode + "</td><td  bgcolor='#F7F2F2' width='5%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt;'>" + Math.Round(item.DispatchedQuantity, 3) + "</td><td  bgcolor='#F7F2F2' width='6%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt;'>" + item.SalesUomCode + "</td>";

                        if (_model.WithDMRate == 1)
                        {
                            SalesOrderPDF = SalesOrderPDF + "<td  bgcolor='#F7F2F2'  width='6%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt;text-align:right '>" + Math.Round(item.Rate, 2) + "</td><td  bgcolor='#F7F2F2'  width='5%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt; text-align:right'>" + Math.Round(item.NetAmount, 2) + "</td><td  bgcolor='#F7F2F2'  width='6%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt; text-align:right'>" + item.TaxGroupName + "</td><td  bgcolor='#F7F2F2'  width='5%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt; text-align:right'>" + Math.Round(item.TaxAmount, 2) + "</td><td  bgcolor='#F7F2F2'  width='5%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt; text-align:right'>" + (Math.Round(item.TaxAmount, 2) + Math.Round(item.NetAmount, 2)) + "</td>";
                        }
                        if (_model.WithDMRate == 3)
                        {
                            SalesOrderPDF = SalesOrderPDF + "<td  bgcolor='#F7F2F2'  width='6%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt;text-align:right '>" + Math.Round(item.Rate, 2) + "</td><td  bgcolor='#F7F2F2'  width='5%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt; text-align:right'>" + Math.Round(item.NetAmount, 2) + "</td>";
                        }

                        SalesOrderPDF = SalesOrderPDF + "</tr>";
                        i++;
                    }
                }

                SalesOrderPDF = SalesOrderPDF + "</table>";
                if (_model.WithDMRate == 1)
                {
                    SalesOrderPDF = SalesOrderPDF + "<br><table style='width:100%;'><tr><td width='40%'>";
                    SalesOrderPDF = SalesOrderPDF + "<table border= '1' bgcolor='#fff;' color='black'><tr><td bgcolor='#D3D3D3' style='border: 1px;font-size:8pt; solid black;border-collapse: collapse; padding: 5px;text-align:right;'>Net Amount</td><td style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:right; '>" + TotalAmount + "</td></tr></tr>";

                    if (model.TaxSummaryList.Count > 0 && model.TaxSummaryList != null)
                    {
                        foreach (var itemList in model.TaxSummaryList)
                        {
                            String[] TaxList = itemList.TaxList.Replace(", ", ",").Split(new char[] { ',' });
                            String[] TaxAmount = itemList.TaxAmountList.Replace(", ", ",").Split(new char[] { ',' });
                            for (int i = 0; i < TaxList.Count(); i++)
                            {
                                SalesOrderPDF = SalesOrderPDF + "<tr><td bgcolor='#D3D3D3' style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:right;'>" + TaxList[i] + "%</td><td style='border: 1px black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:right;'>" + TaxAmount[i] + "</td></tr>";
                            }
                        }
                    }
                    string Amountt = Convert.ToString(TotalBillAmount);
                    var AmountInWords = ConvertToWords(Amountt);
                    SalesOrderPDF = SalesOrderPDF + "<tr><td bgcolor='#D3D3D3' style='border: 1px;font-size:8pt; solid black;border-collapse: collapse; padding: 5px;text-align:right; '> Total Amount</td><td style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:right; '>" + TotalBillAmount + "</td> </tr></tr></table></td></tr></table>";

                    SalesOrderPDF = SalesOrderPDF + "<table border= '1' bgcolor='#fff;' color='black'><tr><td bgcolor='#D3D3D3' style='border: 1px;font-size:8pt; solid black;border-collapse: collapse; padding: 5px;text-align:left;'><b>Amount Value (In Words) Rs. :</b>" + AmountInWords + " </td></tr></table>";
                }
                if (_model.WithDMRate == 3)
                {
                    SalesOrderPDF = SalesOrderPDF + "<br><table style='width:100%;'><tr><td width='40%'>";
                    SalesOrderPDF = SalesOrderPDF + "<table border= '1' bgcolor='#fff;' color='black'><tr><td bgcolor='#D3D3D3' style='border: 1px;font-size:8pt; solid black;border-collapse: collapse; padding: 5px;text-align:right;'>Net Amount</td><td style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:right; '>" + TotalAmount + "</td></tr></tr>";


                    string Amountt = Convert.ToString(TotalAmount);
                    var AmountInWords = ConvertToWords(Amountt);
                    SalesOrderPDF = SalesOrderPDF + "</tr></table></td></tr></table>";

                    SalesOrderPDF = SalesOrderPDF + "<table border= '1' bgcolor='#fff;' color='black'><tr><td bgcolor='#D3D3D3' style='border: 1px;font-size:8pt; solid black;border-collapse: collapse; padding: 5px;text-align:left;'><b>Amount Value (In Words) Rs. :</b>" + AmountInWords + " </td></tr></table>";
                }

                SalesOrderPDF = SalesOrderPDF + "<table><tr><td width='38%'>";
                SalesOrderPDF = SalesOrderPDF + "<table style='width:38%' ><tr><th style='font-size:8pt;text-align:left'>Prepared By</th></tr><tr><td style='text-align:left'> ___________________</td></tr></table><td width='38%'>";
                SalesOrderPDF = SalesOrderPDF + "<table style='width:38%' ><tr><th style='font-size:8pt;text-align:left'>Checked By</th></tr><tr><td style='text-align:left'> ___________________</td></tr></table><td width='37%'>";
                SalesOrderPDF = SalesOrderPDF + "<table style='width:38%' ><tr><th style='font-size:8pt;text-align:left'>Authorised Signatory</th></tr><tr><td style='text-align:left'> ___________________</td></tr></table></td></tr></table>";
                //SalesOrderPDF = SalesOrderPDF + "</table>";
                DownloadPDF1(SalesOrderPDF, model.DeliveryNumber, model.SalesOrderDMList[0].CustomerMasterID, model.SalesOrderDMList[0].IsDeleted, _model.WithDMRate);
                MemoryStream workStream = new MemoryStream();
                return new FileStreamResult(workStream, "application/pdf");


            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public FileStreamResult DownloadAnnexure(SalesOrderDeliveryMasterAndDetailsViewModel _model)
        {
            SalesOrderDeliveryMasterAndDetailsViewModel model = new SalesOrderDeliveryMasterAndDetailsViewModel();
            try
            {
                model.SalesOrderDeliveryMasterAndDetailsDTO = new SalesOrderDeliveryMasterAndDetails();
                model.SalesOrderDeliveryMasterAndDetailsDTO.SalesOrderDeliveryMasterID = _model.SalesOrderDeliveryMasterID;
                model.SalesOrderDeliveryMasterAndDetailsDTO.SalesOrderMasterID = _model.SalesOrderMasterID;
                model.SalesOrderDeliveryMasterAndDetailsDTO.ConnectionString = _connectioString;
                decimal TotalAmount = 0; decimal TotalBillAmount = 0;
                //Code For Generate PDF
                model.SalesOrderDMList = GetRecordForSalesOrderDeliveryMemoPDF(_model.SalesOrderDeliveryMasterID, _model.SalesOrderMasterID);
                model.SalesOrderNumber = model.SalesOrderDMList[0].SalesOrderNumber;
                model.DeliveryNumber = model.SalesOrderDMList[0].DeliveryNumber;
                model.IsOther = model.SalesOrderDMList[0].IsOther;


                string FromDetailTable = "SalesOrderDeliveryMemoDetails";
                model.TaxSummaryList = GetTaxSummaryForDisplay(model.IsOther, _model.SalesOrderDeliveryMasterID, FromDetailTable);
                string SalesOrderPDF = " ";


                SalesOrderPDF = SalesOrderPDF + "<table width='650'><tr><td style='text-align:left;'><img src='" + Path.Combine(Server.MapPath("~") + "Content\\UploadedFiles\\Inventory\\Logo\\" + model.SalesOrderDMList[0].LogoPath) + "' height='70' width='70'><br><br><span style='font-size:7pt;text-align:left;'>" + model.SalesOrderDMList[0].PrintingLineBelowLogo + "<span></td>";

                SalesOrderPDF = SalesOrderPDF + " <td><table width='300' bgcolor='#fff;' color='black' style='font-size:7pt;'><tr><td style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:10pt;text-align:left;font-family:'Century Gothic'><b>" + model.SalesOrderDMList[0].CentreName + ":</b></td></tr></hr><tr><td style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:9pt;text-align:left;'><b><u>" + model.SalesOrderDMList[0].CentreSpecialization + "</u></b></td></tr><tr><td style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left;'>" + model.SalesOrderDMList[0].CentreAddress1 + "</td></tr><tr><td style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left;'>" + model.SalesOrderDMList[0].CentreAddress2 + "</td></tr><tr><td style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left;'>Ph:" + model.SalesOrderDMList[0].PhoneNumberOffice + "</td></tr><tr><td style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left;'>Cell :" + model.SalesOrderDMList[0].CellPhone + "</td></tr><tr><td style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left;'>E-mail :" + model.SalesOrderDMList[0].EmailID + "</td>< tr><td style = 'border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left;' >Website :" + model.SalesOrderDMList[0].Website + " </td ></tr></tr>";

                SalesOrderPDF = SalesOrderPDF + "</table></td></tr></table>";

                SalesOrderPDF = SalesOrderPDF + "<table border= '1' bgcolor='#fff;' color='black' style=' border-collapse:collapse;font-size:7pt;'><tr><td colspan='2'  bgcolor='#F7F2F2' style='padding:0 5px 5px;font-size:10pt;text-align:center;'><b><u>Annexure</u><b></td></tr></table>";

                SalesOrderPDF = SalesOrderPDF + "<br><table border= '1' bgcolor='#fff;' color='black' style=' border-collapse:collapse;font-size:11pt;'><tr><td bgcolor='#D3D3D3' color='black' style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:11pt;text-align:Center;'><b>Details of Receiver(Billed)</b></td><td  bgcolor='#D3D3D3' color='black' style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:11pt;text-align:Center;'><b>Details of Consignee(Shipped to)</b></td></tr>";

                SalesOrderPDF = SalesOrderPDF + " <tr><td style = 'border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left;' > <b>Customer Name :</b> " + model.SalesOrderDMList[0].CustomerName + "</td ><td style = 'border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left; ' ><b>Branch Name: </b>" + model.SalesOrderDMList[0].BranchName + " </td ></tr>";

                SalesOrderPDF = SalesOrderPDF + " <tr><td style = 'border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left;' > <b>Address:</b> " + model.SalesOrderDMList[0].CustomerAddress + "</td ><td style = 'border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left; ' ><b>Address:</b> " + model.SalesOrderDMList[0].CustomerBranchAddress + " </td ></tr>";

                SalesOrderPDF = SalesOrderPDF + " <tr><td style = 'border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left;' > <b>Country:</b> " + model.SalesOrderDMList[0].CountryName + " &nbsp;&nbsp;<b> State:</b> " + model.SalesOrderDMList[0].StateName + " &nbsp; &nbsp;<b> State Code:</b> " + model.SalesOrderDMList[0].StateCode + " </td ><td style = 'border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left; ' > <b>Country: </b>" + model.SalesOrderDMList[0].BranchCountryName + " &nbsp;&nbsp;<b> State: </b>" + model.SalesOrderDMList[0].BranchStateName + " &nbsp; &nbsp;<b> State Code:</b> " + model.SalesOrderDMList[0].BranchStateCode + " </td ></tr>";

                SalesOrderPDF = SalesOrderPDF + " <tr><td style = 'border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left;' > <b>City:</b> " + model.SalesOrderDMList[0].CityName + "<b>  Pin Code:</b> " + model.SalesOrderDMList[0].CustomerPinCode + "</td ><td style = 'border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left; ' ><b>City:</b> " + model.SalesOrderDMList[0].BranchCityName + " <b> Pin Code:</b> " + model.SalesOrderDMList[0].CustomerBranchPinCode + "</td ></tr><tr><td style = 'border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left;' > <b>GSTIN Number:</b> " + model.SalesOrderDMList[0].CustomerGSTNumber + "</td ><td style = 'border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left; ' ><b>GSTIN Number:</b> " + model.SalesOrderDMList[0].BranchGSTNumber + " </td ></tr></table>";

                SalesOrderPDF = SalesOrderPDF + "<br><table border= '1' bgcolor='#fff;' color='black'><tr><th  bgcolor='#D3D3D3' color='black' style='border: 1px solid black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt'>Sr.No</th><th  bgcolor='#D3D3D3' color='black' style='border: 1px solid black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt'>Description of goods/Services</th><th  bgcolor='#D3D3D3' color='black' style='border: 1px solid black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt'>HSN /SAC Code</th><th  bgcolor='#D3D3D3' color='black' style='border: 1px solid black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt'>Qty</th><th  bgcolor='#D3D3D3' color='black' style='border: 1px solid black; border-collapse: collapse; text-align: center; padding: 0px;font-size:7pt'>UOM</th>";

                SalesOrderPDF = SalesOrderPDF + "<th  bgcolor='#D3D3D3' color='black' style='border: 1px solid black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt'>Rate</th><th  bgcolor='#D3D3D3' color='black' style='border: 1px solid black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt'>Total</th>";

                SalesOrderPDF = SalesOrderPDF + "</tr>";
                if (model.SalesOrderDMList.Count > 0 && model.SalesOrderDMList != null)
                {
                    int i = 1;
                    foreach (var item in model.SalesOrderDMList)
                    {
                        TotalAmount = TotalAmount + Math.Round(item.NetAmount, 2);
                        TotalBillAmount = TotalBillAmount + Math.Round(item.NetAmount, 2) + Math.Round(item.TaxAmount, 2);

                        SalesOrderPDF = SalesOrderPDF + "<tr><td  bgcolor='#F7F2F2' width='4%' color='black' style='border-collapse: collapse; text-align: left; padding: 5px;font-size:7pt;'>" + i + "</td><td  bgcolor='#F7F2F2' width='25%' color='black' style='border-collapse: collapse; text-align: left; padding: 5px;font-size:7pt;'>" + item.ItemDescription + "</td><td  bgcolor='#F7F2F2' width='7%' color='black' style='border-collapse: collapse; text-align: left; padding: 5px;font-size:7pt;'>" + item.HSNCode + "</td><td  bgcolor='#F7F2F2' width='5%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt;'>" + Math.Round(item.DispatchedQuantity, 3) + "</td><td  bgcolor='#F7F2F2' width='6%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt;'>" + item.SalesUomCode + "</td>";


                        SalesOrderPDF = SalesOrderPDF + "<td  bgcolor='#F7F2F2'  width='6%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt;text-align:right '>" + Math.Round(item.Rate, 2) + "</td><td  bgcolor='#F7F2F2'  width='5%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt; text-align:right'>" + Math.Round(item.NetAmount, 2) + "</td>";

                        SalesOrderPDF = SalesOrderPDF + "</tr>";
                        i++;
                    }
                }

                SalesOrderPDF = SalesOrderPDF + "</table>";
                SalesOrderPDF = SalesOrderPDF + "<br><table style='width:100%;'><tr><td width='40%'>";
                SalesOrderPDF = SalesOrderPDF + "<table border= '1' bgcolor='#fff;' color='black'><tr><td bgcolor='#D3D3D3' style='border: 1px;font-size:8pt; solid black;border-collapse: collapse; padding: 5px;text-align:right;'>Net Amount</td><td style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:right; '>" + TotalAmount + "</td></tr></tr>";

                //if (model.TaxSummaryList.Count > 0 && model.TaxSummaryList != null)
                //{
                //    foreach (var itemList in model.TaxSummaryList)
                //    {
                //        String[] TaxList = itemList.TaxList.Replace(", ", ",").Split(new char[] { ',' });
                //        String[] TaxAmount = itemList.TaxAmountList.Replace(", ", ",").Split(new char[] { ',' });
                //        for (int i = 0; i < TaxList.Count(); i++)
                //        {
                //            SalesOrderPDF = SalesOrderPDF + "<tr><td bgcolor='#D3D3D3' style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:right;'>" + TaxList[i] + "%</td><td style='border: 1px black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:right;'>" + TaxAmount[i] + "</td></tr>";
                //        }
                //    }
                //}
                string Amountt = Convert.ToString(TotalAmount);
                var AmountInWords = ConvertToWords(Amountt);
                //SalesOrderPDF = SalesOrderPDF + "<tr><td bgcolor='#D3D3D3' style='border: 1px;font-size:8pt; solid black;border-collapse: collapse; padding: 5px;text-align:right; '> Total Amount</td><td style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:right; '>" + TotalBillAmount + "</td> </tr></tr></table></td></tr></table>";
                SalesOrderPDF = SalesOrderPDF + "</table></td></tr></table>";

                SalesOrderPDF = SalesOrderPDF + "<table border= '1' bgcolor='#fff;' color='black'><tr><td bgcolor='#D3D3D3' style='border: 1px;font-size:8pt; solid black;border-collapse: collapse; padding: 5px;text-align:left;'><b>Amount Value (In Words) Rs. :</b>" + AmountInWords + " </td></tr></table>";


                SalesOrderPDF = SalesOrderPDF + "<table><tr><td width='38%'>";
                SalesOrderPDF = SalesOrderPDF + "<table style='width:38%' ><tr><th style='font-size:8pt;text-align:left'>Prepared By</th></tr><tr><td style='text-align:left'> ___________________</td></tr></table><td width='38%'>";
                SalesOrderPDF = SalesOrderPDF + "<table style='width:38%' ><tr><th style='font-size:8pt;text-align:left'>Checked By</th></tr><tr><td style='text-align:left'> ___________________</td></tr></table><td width='37%'>";
                SalesOrderPDF = SalesOrderPDF + "<table style='width:38%' ><tr><th style='font-size:8pt;text-align:left'>Authorised Signatory</th></tr><tr><td style='text-align:left'> ___________________</td></tr></table></td></tr></table>";
                //SalesOrderPDF = SalesOrderPDF + "</table>";
                DownloadPDFAnn(SalesOrderPDF, model.DeliveryNumber, model.SalesOrderDMList[0].CustomerMasterID, model.SalesOrderDMList[0].IsDeleted);
                MemoryStream workStream = new MemoryStream();
                return new FileStreamResult(workStream, "application/pdf");


            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DownloadPDF1(string SalesOrderPDF, string DeliveryNumber, int CustomerMasterID, bool IsDeleted, byte WithDMRate)
        {
            //string HTMLContent = "Hello <b>World</b>";

            Response.Clear();
            Response.ContentType = "application/pdf";
            if (WithDMRate == 1)
            {
                Response.AddHeader("content-disposition", "attachment;filename=DeliveryMemo(WithRate)_" + DeliveryNumber + ".pdf");
            }
            else if (WithDMRate == 2)
            {
                Response.AddHeader("content-disposition", "attachment;filename=DeliveryMemo(WithoutRate)_" + DeliveryNumber + ".pdf");
            }
            else if (WithDMRate == 3)
            {
                Response.AddHeader("content-disposition", "attachment;filename=DeliveryMemo(WithoutTaxes)_" + DeliveryNumber + ".pdf");
            }
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.BinaryWrite(GetPDF(SalesOrderPDF, IsDeleted));
            Response.End();
        }
        public void DownloadPDFAnn(string SalesOrderPDF, string DeliveryNumber, int CustomerMasterID, bool IsDeleted)
        {
            //string HTMLContent = "Hello <b>World</b>";

            Response.Clear();
            Response.ContentType = "application/pdf";

            Response.AddHeader("content-disposition", "attachment;filename=Annexure_" + DeliveryNumber + ".pdf");

            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.BinaryWrite(GetPDF(SalesOrderPDF, IsDeleted));
            Response.End();
        }
        //Code For  Download PDF
        public byte[] GetPDF(string pHTML, bool IsDeleted)
        {
            byte[] bPDF = null;

            MemoryStream ms = new MemoryStream();
            TextReader txtReader = new StringReader(pHTML);

            // 1: create object of a itextsharp document class
            Document doc = new Document(PageSize.A4, 25, 25, 25, 25);

            // 2: we create a itextsharp pdfwriter that listens to the document and directs a XML-stream to a file
            PdfWriter oPdfWriter = PdfWriter.GetInstance(doc, ms);
            if (IsDeleted == true)
            {
                PdfWriterEvents writerEvent = new PdfWriterEvents("DELETED");
                oPdfWriter.PageEvent = writerEvent;
            }
            // 3: we create a worker parse the document
            HTMLWorker htmlWorker = new HTMLWorker(doc);


            // 4: we open document and start the worker on the document
            doc.Open();
            //var logo = iTextSharp.text.Image.GetInstance(Server.MapPath("~/Content/images/logo-2.png"));
            //logo.SetAbsolutePosition(440, 800);
            //doc.Add(logo);

            htmlWorker.StartDocument();

            // 5: parse the html into the document
            htmlWorker.Parse(txtReader);

            // 6: close the document and the worker
            htmlWorker.EndDocument();
            htmlWorker.Close();

            doc.Close();

            bPDF = ms.ToArray();

            return bPDF;
        }



        public ActionResult Delete(SalesOrderDeliveryMasterAndDetailsViewModel model)
        {
            var errorMessage = string.Empty;
            if (model.SalesOrderDeliveryMasterID > 0)
            {
                IBaseEntityResponse<SalesOrderDeliveryMasterAndDetails> response = null;
                SalesOrderDeliveryMasterAndDetails SalesOrderDeliveryMasterAndDetailsDTO = new SalesOrderDeliveryMasterAndDetails();
                SalesOrderDeliveryMasterAndDetailsDTO.ConnectionString = _connectioString;
                SalesOrderDeliveryMasterAndDetailsDTO.SalesOrderDeliveryMasterID = Convert.ToInt32(model.SalesOrderDeliveryMasterID);
                SalesOrderDeliveryMasterAndDetailsDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                response = _SalesOrderDeliveryMasterAndDetailsBA.DeleteSalesOrderDeliveryMasterAndDetails(SalesOrderDeliveryMasterAndDetailsDTO);
                errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
            }

            return Json(errorMessage, JsonRequestBehavior.AllowGet);
        }


        #endregion

        // Non-Action Method
        #region Methods
        public IEnumerable<SalesOrderDeliveryMasterAndDetailsViewModel> GetSalesOrderDeliveryMasterAndDetails(out int TotalRecords, Byte SOStatus, int CustomerMasterID, int AdminRoleID, string MonthName, string MonthYear)
        {
            SalesOrderDeliveryMasterAndDetailsSearchRequest searchRequest = new SalesOrderDeliveryMasterAndDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.SOStatus = SOStatus;
            searchRequest.CustomerMasterID = CustomerMasterID;
            searchRequest.AdminRoleID = AdminRoleID;
            searchRequest.MonthName = MonthName;
            searchRequest.MonthYear = MonthYear;

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
            List<SalesOrderDeliveryMasterAndDetailsViewModel> listSalesOrderDeliveryMasterAndDetailsViewModel = new List<SalesOrderDeliveryMasterAndDetailsViewModel>();
            List<SalesOrderDeliveryMasterAndDetails> listSalesOrderDeliveryMasterAndDetails = new List<SalesOrderDeliveryMasterAndDetails>();
            IBaseEntityCollectionResponse<SalesOrderDeliveryMasterAndDetails> baseEntityCollectionResponse = _SalesOrderDeliveryMasterAndDetailsBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listSalesOrderDeliveryMasterAndDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (SalesOrderDeliveryMasterAndDetails item in listSalesOrderDeliveryMasterAndDetails)
                    {
                        SalesOrderDeliveryMasterAndDetailsViewModel SalesOrderDeliveryMasterAndDetailsViewModel = new SalesOrderDeliveryMasterAndDetailsViewModel();
                        SalesOrderDeliveryMasterAndDetailsViewModel.SalesOrderDeliveryMasterAndDetailsDTO = item;
                        listSalesOrderDeliveryMasterAndDetailsViewModel.Add(SalesOrderDeliveryMasterAndDetailsViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listSalesOrderDeliveryMasterAndDetailsViewModel;
        }
        [NonAction]
        protected List<SalesOrderDeliveryMasterAndDetails> GetRecordForSalesOrderDeliveryMemoPDF(int id, int SaleMstID)
        {
            SalesOrderDeliveryMasterAndDetailsSearchRequest searchRequest = new SalesOrderDeliveryMasterAndDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.SalesOrderMasterID = SaleMstID;
            searchRequest.ID = id;
            List<SalesOrderDeliveryMasterAndDetails> listSalesOrderMasterAndDetails = new List<SalesOrderDeliveryMasterAndDetails>();

            IBaseEntityCollectionResponse<SalesOrderDeliveryMasterAndDetails> baseEntityCollectionResponse = _SalesOrderDeliveryMasterAndDetailsBA.GetRecordForSaleseOrderDeliveryMemoPDF(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listSalesOrderMasterAndDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listSalesOrderMasterAndDetails;
        }

        [NonAction]
        protected List<GeneralTaxGroupMaster> GetTaxSummaryForDisplay(bool IsOtherState, int FromMasterID, string FromDetailTable)
        {
            GeneralTaxGroupMasterSearchRequest searchRequest = new GeneralTaxGroupMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.IsOtherState = IsOtherState;
            searchRequest.FromMasterID = FromMasterID;
            searchRequest.FromDetailTable = FromDetailTable;

            List<GeneralTaxGroupMaster> listGeneralTaxMaster = new List<GeneralTaxGroupMaster>();
            IBaseEntityCollectionResponse<GeneralTaxGroupMaster> baseEntityCollectionResponse = _GeneralTaxGroupMasterBA.GetTaxSummaryForDisplay(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralTaxMaster = baseEntityCollectionResponse.CollectionResponse.OrderBy(x => x.TaxName).ToList();
                }
            }
            return listGeneralTaxMaster;
        }


        [NonAction]
        protected List<SalesOrderDeliveryMasterAndDetails> GetDeliveryMemoListBySalesOrder(int id)
        {
            SalesOrderDeliveryMasterAndDetailsSearchRequest searchRequest = new SalesOrderDeliveryMasterAndDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.SalesOrderMasterID = id;
            List<SalesOrderDeliveryMasterAndDetails> listSalesOrderDeliveryMasterAndDetails = new List<SalesOrderDeliveryMasterAndDetails>();
            IBaseEntityCollectionResponse<SalesOrderDeliveryMasterAndDetails> baseEntityCollectionResponse = _SalesOrderDeliveryMasterAndDetailsBA.GetDeliveryMemoListBySalesOrder(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listSalesOrderDeliveryMasterAndDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listSalesOrderDeliveryMasterAndDetails;
        }
        [NonAction]
        protected List<SalesOrderDeliveryMasterAndDetails> GetDeliveryMemoDetailsByID(int id, int SalesOrderMasterID)
        {
            SalesOrderDeliveryMasterAndDetailsSearchRequest searchRequest = new SalesOrderDeliveryMasterAndDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.ID = id;
            searchRequest.SalesOrderMasterID = SalesOrderMasterID;
            List<SalesOrderDeliveryMasterAndDetails> listPurchaseGRNMaster = new List<SalesOrderDeliveryMasterAndDetails>();
            IBaseEntityCollectionResponse<SalesOrderDeliveryMasterAndDetails> baseEntityCollectionResponse = _SalesOrderDeliveryMasterAndDetailsBA.GetDeliveryMemoDetailsByID(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listPurchaseGRNMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listPurchaseGRNMaster;
        }
        [HttpPost]
        public JsonResult GetDeliveryMemoNumberSearchList_ForSaleContract(string term, string SaleContractMasterID, string SaleContractBillingSpanID)
        {
            SalesOrderDeliveryMasterAndDetailsSearchRequest searchRequest = new SalesOrderDeliveryMasterAndDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.SearchWord = term;
            searchRequest.SaleContractMasterID = Convert.ToInt64(SaleContractMasterID);
            searchRequest.SaleContractBillingSpanID = Convert.ToInt64(SaleContractBillingSpanID);
            List<SalesOrderDeliveryMasterAndDetails> listDeliveryMemoNumber = new List<SalesOrderDeliveryMasterAndDetails>();
            IBaseEntityCollectionResponse<SalesOrderDeliveryMasterAndDetails> baseEntityCollectionResponse = _SalesOrderDeliveryMasterAndDetailsBA.GetDeliveryMemoNumberSearchList_ForSaleContract(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listDeliveryMemoNumber = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            var result = (from r in listDeliveryMemoNumber
                          select new
                          {
                              DeliveryMemoID = r.SalesOrderDeliveryMasterID,
                              DeliveryMemoNumber = r.DeliveryNumber,
                              IsInvoiced = r.IsInvoiced,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult GetDeliveryMemoDetailsByID_ForSaleContract(int DeliveryMemoID)
        {
            SalesOrderDeliveryMasterAndDetailsSearchRequest searchRequest = new SalesOrderDeliveryMasterAndDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.ID = DeliveryMemoID;
            List<SalesOrderDeliveryMasterAndDetails> listDeliveryMemoNumber = new List<SalesOrderDeliveryMasterAndDetails>();
            IBaseEntityCollectionResponse<SalesOrderDeliveryMasterAndDetails> baseEntityCollectionResponse = _SalesOrderDeliveryMasterAndDetailsBA.GetRecordForSaleseOrderDeliveryMemoPDF(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listDeliveryMemoNumber = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            var result = (from r in listDeliveryMemoNumber
                          select new
                          {
                              DeliveryMemoID = r.SalesOrderDeliveryMasterID,
                              DeliveryMemoNumber = r.DeliveryNumber,
                              ItemNumber = r.ItemNumber,
                              ItemDescription = r.ItemDescription,
                              SalesUomCode = r.SalesUomCode,
                              DispatchedQuantity = r.DispatchedQuantity,
                              GenTaxGroupMasterID = r.GenTaxGroupMasterID,
                              HSNCode = r.HSNCode,
                              Rate = r.Rate,
                              TaxRate = r.TaxRate,
                              TaxGroupName = r.TaxGroupName,
                              TaxAmount = r.TaxAmount,
                              NetAmount = r.NetAmount,
                              TaxList = r.TaxList,
                              TaxRateList = r.TaxRateList
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        protected List<GeneralShipperMaster> GetDropDownListForShipperMaster()
        {
            GeneralShipperMasterSearchRequest searchRequest = new GeneralShipperMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<GeneralShipperMaster> listShipperName = new List<GeneralShipperMaster>();
            IBaseEntityCollectionResponse<GeneralShipperMaster> baseEntityCollectionResponse = _GeneralShipperMasterBA.GetDropDownListforGeneralShipperMaster(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listShipperName = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listShipperName;
        }
        protected List<GeneralUnits> GetGeneralUnitsForItemmaster(string CentreCode)
        {
            GeneralUnitsSearchRequest searchRequest = new GeneralUnitsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.CentreCode = CentreCode;

            List<GeneralUnits> ListGeneralUnits = new List<GeneralUnits>();
            IBaseEntityCollectionResponse<GeneralUnits> baseEntityCollectionResponse = new BaseEntityCollectionResponse<GeneralUnits>();
            if (Convert.ToInt32(Session["Store Manager"]) > 0 || Convert.ToString(Session["UserType"]) == "A")
            {
                baseEntityCollectionResponse = _GeneralUnitsBA.GetGeneralUnitsSearchList(searchRequest);
            }
            else if (Convert.ToInt32(Session["Store Manager:Entity"]) > 0)
            {
                if (Session["RoleID"] == null)
                {
                    searchRequest.AdminRoleMasterID = !string.IsNullOrEmpty(Convert.ToString(Session["DefaultRoleID"])) ? Convert.ToInt32(Session["DefaultRoleID"]) : 0;
                }

                else
                {
                    searchRequest.AdminRoleMasterID = !string.IsNullOrEmpty(Convert.ToString(Session["RoleID"])) ? Convert.ToInt32(Session["RoleID"]) : 0;
                }

                baseEntityCollectionResponse = _GeneralUnitsBA.GetGeneralUnitsSearchListByAdminRoleIDAndCentre(searchRequest);
            }
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    ListGeneralUnits = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return ListGeneralUnits;
        }
        #endregion

        // AjaxHandler Method
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param, Byte SOStatus, int CustomerMasterID, int AdminRoleID, string MonthName, string MonthYear)
        {
            if (Session["UserType"] != null)
            {
                int TotalRecords;
                var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
                string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

                IEnumerable<SalesOrderDeliveryMasterAndDetailsViewModel> filteredGroupDescription;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "A.SalesOrderDate";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = "A.SalesOrderDate like '%'";
                        }
                        else
                        {
                            _searchBy = "A.SalesOrderNumber Like '%" + param.sSearch + "%' or A.DeliveryNumber Like '%" + param.sSearch + "%'";
                        }
                        break;
                    case 1:
                        _sortBy = "A.SalesOrderNumber";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = "A.SalesOrderNumber like '%'";
                        }
                        else
                        {
                            _searchBy = "A.SalesOrderNumber Like '%" + param.sSearch + "%' or A.DeliveryNumber Like '%" + param.sSearch + "%'";
                        }
                        break;
                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                filteredGroupDescription = GetSalesOrderDeliveryMasterAndDetails(out TotalRecords, SOStatus, CustomerMasterID, AdminRoleID,MonthName, MonthYear);


                var records = filteredGroupDescription.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { Convert.ToString(c.SalesOrderNumber), Convert.ToString(c.IsLocked), Convert.ToString(c.SalesOrderMasterID), Convert.ToString(c.DeliveryTransDate), Convert.ToString(c.SalesOrderMasterID), Convert.ToString(c.DeliveryNumber), Convert.ToString(c.SalesOrderDeliveryMasterID), Convert.ToString(c.IsInvoiced) };

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