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
    public class SalesOrderMasterAndDetailsController : BaseController
    {
        ISalesOrderMasterAndDetailsBA _SalesOrderMasterAndDetailsBA = null;
        IGeneralTaxGroupMasterBA _GeneralTaxGroupMasterBA = null;
        IGeneralUnitsBA _GeneralUnitsBA = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public SalesOrderMasterAndDetailsController()
        {
            _SalesOrderMasterAndDetailsBA = new SalesOrderMasterAndDetailsBA();
            _GeneralTaxGroupMasterBA = new GeneralTaxGroupMasterBA();
            _GeneralUnitsBA = new GeneralUnitsBA();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
            bool IsApplied = CheckMenuApplicableOrNot(ControllerContext.RouteData.Values["Controller"].ToString());
            if (Convert.ToString(Session["UserType"]) == "A" || ((Convert.ToInt32(Session["Sales Manager"]) > 0 || Convert.ToInt32(Session["Sales Manager:Entity"]) > 0 || Convert.ToInt32(Session["Store Manager"]) > 0) && IsApplied == true))
            {

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

                return View("/Views/Sales/SalesOrderMasterAndDetails/Index.cshtml");
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
                SalesOrderMasterAndDetailsViewModel model = new SalesOrderMasterAndDetailsViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Sales/SalesOrderMasterAndDetails/List.cshtml", model);
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
            SalesOrderMasterAndDetailsViewModel model = new SalesOrderMasterAndDetailsViewModel();
            string CentreCode = string.Empty;
            model.ListGeneralUnitswithCentreCode = GetGeneralUnitsForItemmaster(CentreCode);

            
            //*********************Unit List*********************//
            List<GeneralUnitMaster> GeneralUnitMaster = GetListGeneralUnitMaster();
            List<SelectListItem> GeneralUnitMasterList = new List<SelectListItem>();
            foreach (GeneralUnitMaster item in GeneralUnitMaster)
            {
                GeneralUnitMasterList.Add(new SelectListItem { Text = item.UnitDescription, Value = Convert.ToString(item.ID) });
            }
            ViewBag.GeneralUnitMasterList = new SelectList(GeneralUnitMasterList, "Value", "Text");
            int AdminRoleMasterID = 0;
            if (Session["RoleID"] == null)
            {
                AdminRoleMasterID = Convert.ToInt32(Session["DefaultRoleID"]);
            }
            else
            {
                AdminRoleMasterID = Convert.ToInt32(Session["RoleID"]);
            }
            if (!string.IsNullOrEmpty(CentreCode))
            {
                string[] splitCentreCode = CentreCode.Split(':');
                model.ListGetOrganisationDepartmentCentreAndRoleWise = GetListOrganisationMasterCentreAndRoleWise(splitCentreCode[0], "Centre", AdminRoleMasterID);
            }

            return PartialView("/Views/Sales/SalesOrderMasterAndDetails/Create.cshtml", model);
        }


        [HttpPost]
        public ActionResult Create(SalesOrderMasterAndDetailsViewModel model)
        {
            try
            {
                //if (ModelState.IsValid)
                // {
                if (model != null && model.SalesOrderMasterAndDetailsDTO != null)
                {
                    model.SalesOrderMasterAndDetailsDTO.ConnectionString = _connectioString;

                    model.SalesOrderMasterAndDetailsDTO.ConnectionString = _connectioString;
                    model.SalesOrderMasterAndDetailsDTO.CustomerMasterID = model.CustomerMasterID;
                    model.SalesOrderMasterAndDetailsDTO.CustomerBranchMasterID = model.CustomerBranchMasterID;
                    model.SalesOrderMasterAndDetailsDTO.ContactPersonID = model.ContactPersonID;


                    model.SalesOrderMasterAndDetailsDTO.CreditPeriod = model.CreditPeriod;
                    model.SalesOrderMasterAndDetailsDTO.TitleTo = model.TitleTo;
                    model.SalesOrderMasterAndDetailsDTO.TotalAmount = model.TotalAmount;
                    model.SalesOrderMasterAndDetailsDTO.TotalTaxAmount = model.TotalTaxAmount;
                    model.SalesOrderMasterAndDetailsDTO.TotalBillAmount = model.TotalBillAmount;
                    model.SalesOrderMasterAndDetailsDTO.GeneralUnitsID = model.GeneralUnitsID;
                    model.SalesOrderMasterAndDetailsDTO.SelectedDepartmentID = model.SelectedDepartmentID;
                    model.SalesOrderMasterAndDetailsDTO.SalesQuotationMasterID = model.SalesQuotationMasterID;
                    model.SalesOrderMasterAndDetailsDTO.XmlString = model.XmlString;

                    //Addition to Sales Order
                    model.SalesOrderMasterAndDetailsDTO.PurchaseOrderNumberClient = model.PurchaseOrderNumberClient;
                    model.SalesOrderMasterAndDetailsDTO.ShippingHandling = model.ShippingHandling;
                    model.SalesOrderMasterAndDetailsDTO.Flag = model.Flag;
                    model.SalesOrderMasterAndDetailsDTO.Discount = model.Discount;
                    model.SalesOrderMasterAndDetailsDTO.Freight = model.Freight;
                    model.SalesOrderMasterAndDetailsDTO.Tradein = model.Tradein;
                    model.SalesOrderMasterAndDetailsDTO.CreatePR = model.CreatePR;



                    model.SalesOrderMasterAndDetailsDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    model.SalesOrderMasterAndDetailsDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<SalesOrderMasterAndDetails> response = _SalesOrderMasterAndDetailsBA.InsertSalesOrderMasterAndDetails(model.SalesOrderMasterAndDetailsDTO);

                    model.SalesOrderMasterAndDetailsDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.SalesOrderMasterAndDetailsDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public ActionResult ViewSalesOrderDetails(string ID, string CustomerMasterID, string CustomerBranchID, string UnitsD)
        {
            SalesOrderMasterAndDetailsViewModel model = new SalesOrderMasterAndDetailsViewModel();

            model.CustomerBranchMasterID = Convert.ToInt32(!string.IsNullOrEmpty(CustomerBranchID) ? CustomerBranchID : null);
            model.CustomerMasterID = Convert.ToInt32(!string.IsNullOrEmpty(CustomerMasterID) ? CustomerMasterID : null);
            model.SalesOrderMasterID = Convert.ToInt32(!string.IsNullOrEmpty(ID) ? ID : null);


            SalesOrderMasterAndDetailsSearchRequest searchRequest = new SalesOrderMasterAndDetailsSearchRequest();
            searchRequest.ConnectionString = _connectioString;
            searchRequest.SalesOrderMasterID = Convert.ToInt32(!string.IsNullOrEmpty(ID) ? ID : null);
            searchRequest.CustomerMasterID = Convert.ToInt32(!string.IsNullOrEmpty(CustomerMasterID) ? CustomerMasterID : null);
            searchRequest.CustomerBranchMasterID = Convert.ToInt32(!string.IsNullOrEmpty(CustomerBranchID) ? CustomerBranchID : null);
            searchRequest.GeneralUnitsID = Convert.ToInt32(!string.IsNullOrEmpty(UnitsD) ? UnitsD : null);


            //*********************Unit List*********************//
            IBaseEntityCollectionResponse<SalesOrderMasterAndDetails> baseEntityCollectionResponse = _SalesOrderMasterAndDetailsBA.ViewSalesOrderMasterDetailsListBySalesOrderMasterID(searchRequest);

            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    model.QuotationDetailsByEnquiryMasterID = baseEntityCollectionResponse.CollectionResponse.ToList();
                    model.CustomerName = model.QuotationDetailsByEnquiryMasterID[0].CustomerName;
                    model.CustomerBranchMasterName = model.QuotationDetailsByEnquiryMasterID[0].CustomerBranchMasterName;
                    model.ContactPersonName = model.QuotationDetailsByEnquiryMasterID[0].ContactPersonName;
                    model.TotalTaxAmount = model.QuotationDetailsByEnquiryMasterID[0].TotalTaxAmount;
                    model.CustomerBranchMasterID = model.QuotationDetailsByEnquiryMasterID[0].CustomerBranchMasterID;
                    model.Freight = model.QuotationDetailsByEnquiryMasterID[0].Freight;
                    model.ShippingHandling= model.QuotationDetailsByEnquiryMasterID[0].ShippingHandling;
                    model.Discount = model.QuotationDetailsByEnquiryMasterID[0].Discount;
                    model.Tradein = model.QuotationDetailsByEnquiryMasterID[0].Tradein;
                    model.PurchaseOrderNumberClient = model.QuotationDetailsByEnquiryMasterID[0].PurchaseOrderNumberClient;
                }
            }
            string CentreCode = string.Empty;
            model.ListGeneralUnits = GetGeneralUnitsForItemmaster(CentreCode);
            model.GeneralUnitsID = Convert.ToInt32(!string.IsNullOrEmpty(UnitsD) ? UnitsD : null);
            List<GeneralUnitMaster> GeneralUnitMaster = GetListGeneralUnitMaster();
            List<SelectListItem> GeneralUnitMasterList = new List<SelectListItem>();
            foreach (GeneralUnitMaster item in GeneralUnitMaster)
            {
                GeneralUnitMasterList.Add(new SelectListItem { Text = item.UnitDescription, Value = Convert.ToString(item.ID) });
            }
            ViewBag.GeneralUnitMasterList = new SelectList(GeneralUnitMasterList, "Value", "Text", model.UnitMasterId);



            return PartialView("/Views/Sales/SalesOrderMasterAndDetails/ViewDetails.cshtml", model);

        }

        [HttpGet]
        public FileStreamResult Download(int id)
        {
            SalesOrderMasterAndDetailsViewModel model = new SalesOrderMasterAndDetailsViewModel();
            try
            {


                model.SalesOrderMasterAndDetailsDTO = new SalesOrderMasterAndDetails();
                model.SalesOrderMasterAndDetailsDTO.SalesOrderMasterID = id;
                model.SalesOrderMasterAndDetailsDTO.ConnectionString = _connectioString;
                //Code For Generate PDF
                decimal TotalAmount = 0;
                model.SalesOrderList = GetRecordForSalesOrderPDF(id);
                model.SalesOrderNumber = model.SalesOrderList[0].SalesOrderNumber;
                model.IsOther = model.SalesOrderList[0].IsOther;


                string FromDetailTable = "SalesOrderDetails";
                model.TaxSummaryList = GetTaxSummaryForDisplay(model.IsOther, id, FromDetailTable);



                string SalesOrderPDF = " ";
                SalesOrderPDF = SalesOrderPDF + "<table width='650'><tr><td style='text-align:left;'><img src='" + Path.Combine(Server.MapPath("~") + "Content\\UploadedFiles\\Inventory\\Logo\\" + model.SalesOrderList[0].LogoPath) + "' height='70' width='70'><br><br><span style='font-size:7pt;text-align:left;'>" + model.SalesOrderList[0].PrintingLineBelowLogo + "<span></td>";


                SalesOrderPDF = SalesOrderPDF + " <td><table width='300' bgcolor='#fff;' color='black' style='font-size:7pt;'><tr><td style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:10pt;text-align:left;font-family:'Century Gothic'><b>" + model.SalesOrderList[0].CentreName + ":</b></td></tr></hr><tr><td style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:9pt;text-align:left;'><b><u>" + model.SalesOrderList[0].CentreSpecialization + "</u></b></td></tr><tr><td style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left;'>" + model.SalesOrderList[0].CentreAddress1 + "</td></tr><tr><td style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left;'>" + model.SalesOrderList[0].CentreAddress2 + "</td></tr><tr><td style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left;'>Ph:" + model.SalesOrderList[0].PhoneNumberOffice + "</td></tr><tr><td style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left;'>Cell :" + model.SalesOrderList[0].CellPhone + "</td></tr><tr><td style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left;'>E-mail :" + model.SalesOrderList[0].EmailID + "</td>< tr><td style = 'border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left;' >Website :" + model.SalesOrderList[0].Website + " </td ></tr></tr>";


                SalesOrderPDF = SalesOrderPDF + "</table></td></tr></table>";
                SalesOrderPDF = SalesOrderPDF + "<table border= '1' bgcolor='#fff;' color='black' style=' border-collapse:collapse;font-size:7pt;'><b>PurchaseOrder</b><tr><td colspan='2'  bgcolor='#F7F2F2' style='padding:0 5px 5px;font-size:10pt;text-align:center;'><b><u>Sales Order</u><b></td></tr><tr><td bgcolor='#F7F2F2' style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left; '><b>GSTIN Number</b>: " + model.SalesOrderList[0].GSTINNumber + "</td><td  bgcolor='#F7F2F2' style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left;'><b>Transportation Mode <b>: </td></tr><tr><td bgcolor='#F7F2F2' style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left; '><b>PAN Number</b>: " + model.SalesOrderList[0].PanNumber + "</td><td bgcolor='#F7F2F2' style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left; '><b>Vehical Number </b>: </td></tr><tr><td bgcolor='#F7F2F2' style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left;'><b>CIN Number</b>: " + model.SalesOrderList[0].CINNumber + "</td><td bgcolor='#F7F2F2' style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left; '>Date and Time : - </td></tr><tr><td bgcolor='#F7F2F2' style='border: 1px solid black;border-collapse: collapse; padding: 5px;text-align:left; '><b>Tax is payable on Reverse Charge</b> :(No)</td><td  bgcolor='#F7F2F2' style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left; '><b>Place of Supply</b> : - </td> </tr><tr><td bgcolor='#F7F2F2' style='border: 1px solid black;border-collapse: collapse; padding: 5px;text-align:left; '><b>Sales Order Number</b> :" + model.SalesOrderList[0].SalesOrderNumber + "</td><td bgcolor='#F7F2F2' style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left; '><b>Purchase Order Number</b> :" + model.SalesOrderList[0].PurchaseOrderNumberClient + "</td> </tr><tr><td bgcolor='#F7F2F2' style='border: 1px solid black;border-collapse: collapse; padding: 5px;text-align:left; '><b>Order Date</b> :" + model.SalesOrderList[0].SalesOrderDate + "</td><td bgcolor='#F7F2F2' style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left; '></td> </tr></table>";

                SalesOrderPDF = SalesOrderPDF + "<br><table border= '1' bgcolor='#fff;' color='black' style=' border-collapse:collapse;font-size:11pt;'><b>Sales Order</b><tr><td bgcolor='#D3D3D3' color='black' style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:11pt;text-align:Center;'><b>Details of Receiver(Billed)</b></td><td  bgcolor='#D3D3D3' color='black' style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:11pt;text-align:Center;'><b>Details of Consignee(Shipped to)</b></td></tr>";

                SalesOrderPDF = SalesOrderPDF + " <tr><td style = 'border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left;' > <b>Customer Name :</b> " + model.SalesOrderList[0].CustomerName + "</td ><td style = 'border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left; ' ><b>Branch Name: </b>" + model.SalesOrderList[0].CustomerBranchMasterName + " </td ></tr>";

                SalesOrderPDF = SalesOrderPDF + " <tr><td style = 'border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left;' > <b>Address:</b> " + model.SalesOrderList[0].CustomerAddress + "</td ><td style = 'border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left; ' ><b>Address:</b> " + model.SalesOrderList[0].CustomerBranchAddress + " </td ></tr>";

                SalesOrderPDF = SalesOrderPDF + " <tr><td style = 'border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left;' > <b>Country:</b> " + model.SalesOrderList[0].CountryName + " &nbsp;&nbsp;<b> State:</b> " + model.SalesOrderList[0].StateName + "&nbsp; &nbsp;<b> State Code:</b> " + model.SalesOrderList[0].StateCode + " </td ><td style = 'border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left; ' > <b>Country: </b>" + model.SalesOrderList[0].BranchCountryName + " &nbsp;&nbsp;<b> State: </b>" + model.SalesOrderList[0].BranchStateName + "&nbsp; &nbsp;<b> State Code:</b> " + model.SalesOrderList[0].BranchStateCode + " </td ></tr>";

                SalesOrderPDF = SalesOrderPDF + " <tr><td style = 'border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left;' > <b>City:</b> " + model.SalesOrderList[0].CityName + " &nbsp; &nbsp;<b>Pin Code:</b> " + model.SalesOrderList[0].CustomerPinCode + "</td ><td style = 'border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left; ' ><b>City:</b> " + model.SalesOrderList[0].BranchCityName + "&nbsp; &nbsp;<b>Pin Code:</b> " + model.SalesOrderList[0].CustomerBranchPinCode + " </td ></tr><tr><td style = 'border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left;' > <b>GSTIN Number:</b> " + model.SalesOrderList[0].CustomerGSTNumber + "</td ><td style = 'border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left; ' ><b>GSTIN Number:</b> " + model.SalesOrderList[0].BranchGSTNumber + " </td ></tr></table>";

                SalesOrderPDF = SalesOrderPDF + "<br><table border= '1' bgcolor='#fff;' color='black'><tr><th  bgcolor='#D3D3D3' color='black' style='border: 1px solid black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt'>Description of goods/services</th><th  bgcolor='#D3D3D3' color='black' style='border: 1px solid black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt'>HSN/SAC Code</th><th  bgcolor='#D3D3D3' color='black' style='border: 1px solid black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt'>Quantity</th><th  bgcolor='#D3D3D3' color='black' style='border: 1px solid black; border-collapse: collapse; text-align: center; padding: 0px;font-size:7pt'>UOM</th><th  bgcolor='#D3D3D3' color='black' style='border: 1px solid black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt'>Rate</th><th  bgcolor='#D3D3D3' color='black' style='border: 1px solid black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt'>Total</th><th  bgcolor='#D3D3D3' color='black' style='border: 1px solid black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt'>Tax</th><th  bgcolor='#D3D3D3' color='black' style='border: 1px solid black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt'>Tax Amount</th><th  bgcolor='#D3D3D3' color='black' style='border: 1px solid black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt'>Amount</th></tr>";
                if (model.SalesOrderList.Count > 0 && model.SalesOrderList != null)
                {
                    foreach (var item in model.SalesOrderList)
                    {
                        TotalAmount = TotalAmount + Math.Round(item.NetAmount, 2);

                        SalesOrderPDF = SalesOrderPDF + "<tr><td  bgcolor='#F7F2F2' width='27%' color='black' style='border-collapse: collapse; text-align: left; padding: 5px;font-size:7pt;'>" + item.ItemDescription + "</td><td  bgcolor='#F7F2F2' width='7%' color='black' style='border-collapse: collapse; text-align: left; padding: 5px;font-size:7pt;'>" + item.HSNCode + "</td><td  bgcolor='#F7F2F2' width='5%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt;'>" + Math.Round(item.Quantity, 3) + "</td><td  bgcolor='#F7F2F2' width='7%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt;'>" + item.UOM + "</td><td  bgcolor='#F7F2F2'  width='8%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt;text-align:right '>" + Math.Round(item.Rate, 2) + "</td><td  bgcolor='#F7F2F2'  width='8%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt; text-align:right'>" + Math.Round(item.NetAmount, 2) + "</td><td  bgcolor='#F7F2F2'  width='8%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt; text-align:right'>" + item.TaxGroupName + "</td><td  bgcolor='#F7F2F2'  width='8%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt; text-align:right'>" + Math.Round(item.TaxAmount, 2) + "</td><td  bgcolor='#F7F2F2'  width='8%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt; text-align:right'>" + (Math.Round(item.TaxAmount, 2) + Math.Round(item.NetAmount, 2)) + "</td></tr>";
                    }
                }

                SalesOrderPDF = SalesOrderPDF + "</table>";
                SalesOrderPDF = SalesOrderPDF + "<br><table style='width:100%;'><tr><td width='40%'>";
                SalesOrderPDF = SalesOrderPDF + "<table border= '1' bgcolor='#fff;' color='black'><tr><td bgcolor='#D3D3D3' style='border: 1px;font-size:8pt; solid black;border-collapse: collapse; padding: 5px;text-align:right;'>Net Amount</td><td style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:right; '>" + TotalAmount + "</td></tr></tr>";

                if (model.TaxSummaryList.Count > 0 && model.TaxSummaryList != null)
                {
                    foreach (var itemList in model.TaxSummaryList)
                    {
                        String[] TaxList = itemList.TaxList.Replace(", ", ",").Split(new char[] { ',' });
                        String[] TaxAmount = itemList.TaxAmountList.Replace(", ", ",").Split(new char[] { ',' });
                        for (int i = 0; i < TaxAmount.Count(); i++)
                        {
                            SalesOrderPDF = SalesOrderPDF + "<tr><td bgcolor='#D3D3D3' style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:right;'>" + TaxList[i] + "%</td><td style='border: 1px black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:right;'>" +Math.Round(Convert.ToDecimal(TaxAmount[i])) + "</td></tr>";
                        }
                    }
                }
                string Amountt = Convert.ToString(Math.Round(TotalAmount, 2) + Math.Round(model.SalesOrderList[0].TotalTaxAmount, 2));
                SalesOrderPDF = SalesOrderPDF + "<tr><td bgcolor='#D3D3D3' style='border: 1px;font-size:8pt; solid black;border-collapse: collapse; padding: 5px;text-align:right; '> Total Amount</td><td style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:right; '>" + Amountt + "</td> </tr></table></td></tr></table>";

               
                var AmountInWords = ConvertToWords(Amountt);

                SalesOrderPDF = SalesOrderPDF + "<table border= '1' bgcolor='#fff;' color='black'><tr><td bgcolor='#D3D3D3' style='border: 1px;font-size:8pt; solid black;border-collapse: collapse; padding: 5px;text-align:left;'><b>Amount Value (In Words) Rs. :</b>" + AmountInWords + " </td></tr></table>";


                SalesOrderPDF = SalesOrderPDF + "<table><tr><td width='38%'>";
                SalesOrderPDF = SalesOrderPDF + "<table style='width:38%' ><tr><th style='font-size:8pt;text-align:left'>Prepared By</th></tr><tr><td style='text-align:left'> ___________________</td></tr></table><td width='38%'>";
                SalesOrderPDF = SalesOrderPDF + "<table style='width:38%' ><tr><th style='font-size:8pt;text-align:left'>Checked By</th></tr><tr><td style='text-align:left'> ___________________</td></tr></table><td width='37%'>";
                SalesOrderPDF = SalesOrderPDF + "<table style='width:38%' ><tr><th style='font-size:8pt;text-align:left'>Authorised Signatory</th></tr><tr><td style='text-align:left'> ___________________</td></tr></table></td></tr></table>";
                
                Document document = new Document(PageSize.A4, 50, 50, 25, 25);
                document.Open();
               
                document.Add(new Paragraph(document.BottomMargin, "footer text"));
                document.Close();
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Write(document);
                
                //SalesOrderPDF = SalesOrderPDF + "</table>";
                DownloadPDF1(SalesOrderPDF, model.SalesOrderNumber, model.SalesOrderList[0].CustomerMasterID, model.SalesOrderList[0].IsDeleted);
                MemoryStream workStream = new MemoryStream();
                return new FileStreamResult(workStream, "application/pdf");


            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DownloadPDF1(string SalesOrderPDF, string SalesOrderNumber, int CustomerMasterID, bool IsDeleted)
        {
            //string HTMLContent = "Hello <b>World</b>";

            Response.Clear();
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=sales Order"+ CustomerMasterID + "_" + SalesOrderNumber + ".pdf");
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
        public ActionResult Delete(int ID)
        {
            var errorMessage = string.Empty;
            if (ID > 0)
            {
                IBaseEntityResponse<SalesOrderMasterAndDetails> response = null;
                SalesOrderMasterAndDetails SalesOrderMasterAndDetailsDTO = new SalesOrderMasterAndDetails();
                SalesOrderMasterAndDetailsDTO.ConnectionString = _connectioString;
                // SalesOrderMasterAndDetailsDTO.ID = Convert.ToInt16(ID);
                SalesOrderMasterAndDetailsDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                response = _SalesOrderMasterAndDetailsBA.DeleteSalesOrderMasterAndDetails(SalesOrderMasterAndDetailsDTO);
                errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
            }

            return Json(errorMessage, JsonRequestBehavior.AllowGet);
        }


        #endregion

        // Non-Action Method
        #region Methods
        public IEnumerable<SalesOrderMasterAndDetailsViewModel> GetSalesOrderMasterAndDetails(out int TotalRecords, string TransactionDate,string MonthName,string MonthYear)
        {
            SalesOrderMasterAndDetailsSearchRequest searchRequest = new SalesOrderMasterAndDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.SalesOrderDate = TransactionDate;
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
            List<SalesOrderMasterAndDetailsViewModel> listSalesOrderMasterAndDetailsViewModel = new List<SalesOrderMasterAndDetailsViewModel>();
            List<SalesOrderMasterAndDetails> listSalesOrderMasterAndDetails = new List<SalesOrderMasterAndDetails>();
            IBaseEntityCollectionResponse<SalesOrderMasterAndDetails> baseEntityCollectionResponse = _SalesOrderMasterAndDetailsBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listSalesOrderMasterAndDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (SalesOrderMasterAndDetails item in listSalesOrderMasterAndDetails)
                    {
                        SalesOrderMasterAndDetailsViewModel SalesOrderMasterAndDetailsViewModel = new SalesOrderMasterAndDetailsViewModel();
                        SalesOrderMasterAndDetailsViewModel.SalesOrderMasterAndDetailsDTO = item;
                        listSalesOrderMasterAndDetailsViewModel.Add(SalesOrderMasterAndDetailsViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listSalesOrderMasterAndDetailsViewModel;
        }

        [NonAction]
        protected List<SalesOrderMasterAndDetails> GetRecordForSalesOrderPDF(int id)
        {
            SalesOrderMasterAndDetailsSearchRequest searchRequest = new SalesOrderMasterAndDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.SalesOrderMasterID = id;
            List<SalesOrderMasterAndDetails> listSalesOrderMasterAndDetails = new List<SalesOrderMasterAndDetails>();

            IBaseEntityCollectionResponse<SalesOrderMasterAndDetails> baseEntityCollectionResponse = _SalesOrderMasterAndDetailsBA.GetRecordForSaleseOrderPDF(searchRequest);
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
        public ActionResult GetDepartmentByCentreCodeForSO(string SelectedCentreCode)
        {
            int AdminRoleMasterID = 0;
            if (Convert.ToString(Session["UserType"]) == "A")
            {
                AdminRoleMasterID = 0;
            }
            else
            {
                if (Session["RoleID"] == null)
                {
                    AdminRoleMasterID = Convert.ToInt32(Session["DefaultRoleID"]);
                }
                else
                {
                    AdminRoleMasterID = Convert.ToInt32(Session["RoleID"]);
                }
            }
          
            int id = 0;
            bool isValid = Int32.TryParse(SelectedCentreCode, out id);
            var department = GetListOrganisationMasterCentreAndRoleWise(SelectedCentreCode, "Centre", AdminRoleMasterID);
            var result = (from s in department
                          select new
                          {
                              id = s.ID,
                              name = s.DepartmentName,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        #endregion

        // AjaxHandler Method
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param, string TransactionDate,string MonthName, string MonthYear)
        {
            if (Session["UserType"] != null)
            {
                int TotalRecords;
                var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
                string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

                IEnumerable<SalesOrderMasterAndDetailsViewModel> filteredGroupDescription;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "A.CustomerMasterID";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "A.QuotationNumber Like '%" + param.sSearch + "%' or A.SalesOrderNumber Like '%" + param.sSearch + "%' or B.CompanyName Like '%" + param.sSearch + "%'or Concat(B.FirstName,' ',B.MiddleName,' ',B.LastName) Like '%" + param.sSearch + "%'";
                        }
                        break;
                    case 1:
                        _sortBy = "A.SalesQuotationMasterID";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "A.QuotationNumber Like '%" + param.sSearch + "%' or A.SalesOrderNumber Like '%" + param.sSearch + "%' or B.CompanyName Like '%" + param.sSearch + "%'or Concat(B.FirstName,' ',B.MiddleName,' ',B.LastName) Like '%" + param.sSearch + "%'";
                        }
                        break;
                    case 2:
                        _sortBy = "A.SalesOrderNumber ";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "A.QuotationNumber Like '%" + param.sSearch + "%' or A.SalesOrderNumber Like '%" + param.sSearch + "%' or B.CompanyName Like '%" + param.sSearch + "%'or Concat(B.FirstName,' ',B.MiddleName,' ',B.LastName) Like '%" + param.sSearch + "%'";
                        }
                        break;
                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                filteredGroupDescription = GetSalesOrderMasterAndDetails(out TotalRecords, TransactionDate, MonthName, MonthYear);


                var records = filteredGroupDescription.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { Convert.ToString(c.CustomerMasterID), Convert.ToString(c.CustomerBranchMasterID), Convert.ToString(c.ContactPersonID), Convert.ToString(c.QuotationNumber), Convert.ToString(c.SalesOrderMasterID), Convert.ToString(c.CustomerName), Convert.ToString(c.SalesOrderNumber), Convert.ToString(c.Status), Convert.ToString(c.SalesQuotationMasterID), Convert.ToString(c.GeneralUnitsID) };
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