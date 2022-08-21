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
using System.IO;
using iTextSharp.text.html.simpleparser;
//using iTextSharp.text.pdf.parser;
using System.Web;
using iTextSharp.text.html;
using System.Globalization;


namespace AERP.Web.UI.Controllers
{
    public class PurchaseGRNMasterController : BaseController
    {
        IPurchaseGRNMasterBA _PurchaseGRNMasterBA = null;
        //IInventoryItemMasterBA _inventoryItemMasterBA = null;
        IGeneralSupplierMasterBA _IGeneralSupplierMasterBA = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        static string errorMessage = null;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public PurchaseGRNMasterController()
        {
            _PurchaseGRNMasterBA = new PurchaseGRNMasterBA();
            //_inventoryItemMasterBA = new InventoryItemMasterBA();
            _IGeneralSupplierMasterBA = new GeneralSupplierMasterBA();

        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
            if (Convert.ToString(Session["UserType"]) == "A" || Convert.ToInt32(Session["Purchase Manager"]) > 0 || Convert.ToInt32(Session["Purchase Manager:Entity"]) > 0)
            {
                PurchaseGRNMasterViewModel model = new PurchaseGRNMasterViewModel();

                List<SelectListItem> POStatus = new List<SelectListItem>();
                ViewBag.POStatus = new SelectList(POStatus, "Value", "Text");
                List<SelectListItem> POStatus_li = new List<SelectListItem>();
                POStatus_li.Add(new SelectListItem { Text = "All", Value = "0" });
                POStatus_li.Add(new SelectListItem { Text = "Completed", Value = "1" });
                POStatus_li.Add(new SelectListItem { Text = "Pending", Value = "2" });

                ViewData["POStatus"] = new SelectList(POStatus_li, "Value", "Text");

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

                return View("/Views/Purchase/PurchaseGRNMaster/Index.cshtml", model);
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
                PurchaseGRNMasterViewModel model = new PurchaseGRNMasterViewModel();
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
                return PartialView("/Views/Purchase/PurchaseGRNMaster/List.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }

        [HttpGet]
        public ActionResult Create(string ID)
        {
            try
            {
                PurchaseGRNMasterViewModel model = new PurchaseGRNMasterViewModel();

                model.PurchaseGRNMasterDTO = new PurchaseGRNMaster();

                string[] IDsArray = ID.Split('~');
                model.PurchaseGRNMasterDTO.PurchaseOrderMasterID = Convert.ToInt32(IDsArray[0]);
                model.PurchaseOrderType = Convert.ToInt32(IDsArray[1]);
                model.PurchaseGRNMasterDTO.ConnectionString = _connectioString;
                model.PurchaseGRNMasterListFromPO = GetPurchaseOrderMasterListForGRN(model.PurchaseOrderMasterID);

                for (int i = 0; i < model.PurchaseGRNMasterListFromPO.Count; i++)
                {
                    if (model.PurchaseGRNMasterListFromPO.Count > 0 && model.PurchaseGRNMasterListFromPO != null)
                    {
                        model.GRNTransDate = model.PurchaseGRNMasterListFromPO[0].GRNTransDate;
                        model.TotalTaxAmount = model.PurchaseGRNMasterListFromPO[0].TotalTaxAmount;
                        model.ShippingHandling = model.PurchaseGRNMasterListFromPO[0].ShippingHandling;
                        model.Discount = model.PurchaseGRNMasterListFromPO[0].Discount;
                        model.Freight = model.PurchaseGRNMasterListFromPO[0].Freight;
                        model.PurchaseOrderNumber = model.PurchaseGRNMasterListFromPO[0].PurchaseOrderNumber;
                        model.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        model.GRNTransDate = DateTime.UtcNow.ToString();
                        model.GrossAmount = Math.Round(model.PurchaseGRNMasterListFromPO[i].GrossAmount, 2);
                    }
                }

                return PartialView("/Views/Purchase/PurchaseGRNMaster/Create.cshtml", model);

            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }


        [HttpPost]
        public ActionResult Create(PurchaseGRNMasterViewModel model)
        {
            try
            {
                if (model != null && model.PurchaseGRNMasterDTO != null)
                {
                    model.PurchaseGRNMasterDTO.ConnectionString = _connectioString;
                    model.PurchaseGRNMasterDTO.PurchaseOrderMasterID = model.PurchaseOrderMasterID;
                    model.PurchaseGRNMasterDTO.IsLocked = model.IsLocked;
                    model.PurchaseGRNMasterDTO.XMLstring = model.XMLstring;
                    //model.PurchaseGRNMasterDTO.XMLstringForVouchar = model.XMLstringForVouchar;
                    model.PurchaseGRNMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<PurchaseGRNMaster> response = _PurchaseGRNMasterBA.InsertPurchaseGRNMaster(model.PurchaseGRNMasterDTO);
                    string errorMessageDis = string.Empty;
                    string colorCode = string.Empty;
                    string mode = string.Empty;
                    if (response.Entity.ErrorCode == 22)
                    {
                        errorMessageDis = response.Entity.errorMessage;
                        colorCode = "danger";
                    }

                    else if (response.Entity.ErrorCode == 0)
                    {
                        errorMessageDis = response.Entity.errorMessage;
                        colorCode = "success";
                    }
                    string[] arrayList = { errorMessageDis, colorCode, mode };
                    errorMessage = string.Join(",", arrayList);
                    model.PurchaseGRNMasterDTO.errorMessage = errorMessage;



                    //model.PurchaseGRNMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.PurchaseGRNMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);

                }
                return Json("Please review your form");
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }
        [HttpGet]
        public ActionResult ViewDetails(int id, int PurchaseOrderMaster)
        {
            try
            {
                PurchaseGRNMasterViewModel model = new PurchaseGRNMasterViewModel();
                model.PurchaseGRNMasterDTO.ID = id;
                model.PurchaseGRNMasterDTO.PurchaseOrderMasterID = PurchaseOrderMaster;
                model.PurchaseGRNMasterListFromPO = GetPurchaseGRNDetailsByID(id, PurchaseOrderMaster);
                //model.PurchaseRequisitionMasterList = GetPurchaseRequisitionMasterList(id);
                if (model.PurchaseGRNMasterListFromPO.Count > 0 && model.PurchaseGRNMasterListFromPO != null)
                {
                    model.GRNNumber = model.PurchaseGRNMasterListFromPO[0].GRNNumber;
                    model.GRNTransDate = model.PurchaseGRNMasterListFromPO[0].GRNTransDate;
                }

                return PartialView("/Views/Purchase/PurchaseGRNMaster/View.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }
        public ActionResult Delete(int ID)
        {
            var errorMessage = string.Empty;
            if (ID > 0)
            {
                IBaseEntityResponse<PurchaseGRNMaster> response = null;
                PurchaseGRNMaster PurchaseGRNMasterDTO = new PurchaseGRNMaster();
                PurchaseGRNMasterDTO.ConnectionString = _connectioString;
                PurchaseGRNMasterDTO.ID = ID;
                PurchaseGRNMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                response = _PurchaseGRNMasterBA.DeletePurchaseGRNMaster(PurchaseGRNMasterDTO);
                errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
            }

            return Json(errorMessage, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public FileStreamResult Downloads(int id)
        {
            PurchaseGRNMasterViewModel model = new PurchaseGRNMasterViewModel();
            try
            {


                model.PurchaseGRNMasterDTO = new PurchaseGRNMaster();
                model.PurchaseGRNMasterDTO.ID = id;
                model.PurchaseGRNMasterDTO.ConnectionString = _connectioString;
                decimal amount1 = 0; int itemcount = 0; decimal taxamount1 = 0; decimal RecCount = 0; decimal NotRecCount = 0; decimal TotCount = 0; decimal TotalPOAmount1 = 0; decimal TotalPOAmount2 = 0; decimal TotalPOAmount = 0; decimal discountamount = 0;
                int ItemNumber = 0; decimal RecCount1 = 0; decimal DeliverItem = 0;
                int NOtRecYet = 0;
                List<int> ItemNumberList = new List<int>();
                //Code For Generate PDF
                model.PurchaseGRNMasterListFromPO = GetPurchaseGrnMasterListForPDF(id);
                // model.GRNNumber = model.PurchaseGRNMasterListFromPO[0].GRNNumber;s
                model.GRNNumber = model.PurchaseGRNMasterListFromPO[0].PurchaseOrderNumber;
                model.VendorID = model.PurchaseGRNMasterListFromPO[0].VendorID;

                string PurchasePDF = " ";
                //*********** Code for Logo********
                PurchasePDF = PurchasePDF + "<html><body><span style='text-align:center'><b>Goods Received Note</b><br></body></html>";
                PurchasePDF = PurchasePDF + "<table><tr><td style='text-align:left;'><img src='" + Path.Combine(Server.MapPath("~") + "Content\\UploadedFiles\\Inventory\\Logo\\" + model.PurchaseGRNMasterListFromPO[0].LogoPath) + "' height='70' width='130'></td></tr></table>";
                PurchasePDF = PurchasePDF + "<table style='width:100%; border-collapse:collapse;border-spacing:0;margin: 0;padding: 0;'><tr><td width='40%' valign='top'>";
                PurchasePDF = PurchasePDF + "<table style=' border-collapse:collapse; border-spacing:0;margin: 0;padding: 0;'><tr><th style='padding: 5px;font-size:7pt;text-align:left'><b>Company Name:<b></th></tr><tr><td style='font-size:7pt;text-align:left'>" + model.PurchaseGRNMasterListFromPO[0].PrintingLine1 + "</td></tr> <tr><td style='font-size:7pt;text-align:left'>" + model.PurchaseGRNMasterListFromPO[0].ToLocationAddress + "</td></tr><tr><td style='font-size:7pt;text-align:left'>" + model.PurchaseGRNMasterListFromPO[0].ToCity + " - PO Box - " + model.PurchaseGRNMasterListFromPO[0].Topincode + "</td></tr></table></td style='font-size:7pt'><td style='border: 1px solid black;border-collapse: collapse; padding: 5px; width='50%';'>";
                PurchasePDF = PurchasePDF + "<table border= '1' bgcolor='#fff;' color='black' style=' border-collapse:collapse;font-size:7pt;'><b>PurchaseOrder</b><tr><td bgcolor='#D3D3D3' style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left; '>Purchase Order Number</td><td style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left; '>" + model.PurchaseGRNMasterListFromPO[0].PurchaseOrderNumber + "</td></tr><tr><td bgcolor='#D3D3D3' style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left; '>Purchase Requisition Number</td><td style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left; '>" + model.PurchaseGRNMasterListFromPO[0].PurchaseRequisitionNumber + "</td></tr><tr><td bgcolor='#D3D3D3' style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left;'>Purchase Order Date</td><td style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left; '>" + model.PurchaseGRNMasterListFromPO[0].PurchaseOrderDate + "</td></tr><tr><td bgcolor='#D3D3D3' style='border: 1px solid black;border-collapse: collapse; padding: 5px;text-align:left; '>Location</td><td style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left; '>" + model.PurchaseGRNMasterListFromPO[0].ToLocationName + "</td> </tr><tr><td bgcolor='#D3D3D3' style='border: 1px solid black;border-collapse: collapse; padding: 5px;text-align:left; '>Currency</td><td style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left; '>" + model.PurchaseGRNMasterListFromPO[0].Currency + "</td> </tr></table></td></tr></table>";
                // PurchasePDF = PurchasePDF + "<table border= '1' bgcolor='#fff;' color='black' style=' border-collapse:collapse;font-size:7pt;'><b>PurchaseOrder</b><tr><td bgcolor='#D3D3D3' style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left; '>Purchase Order Number</td><td style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left; '>" + model.PurchaseOrderList[0].PurchaseOrderNumber + "</td></tr><tr><td bgcolor='#D3D3D3' style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left;'> Order Date</td><td style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left; '>" + model.PurchaseOrderList[0].PurchaseOrderDate + "</td></tr><tr><td bgcolor='#D3D3D3' style='border: 1px solid black;border-collapse: collapse; padding: 5px;text-align:left; '>Delivery Date</td><td style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left; '>" + model.PurchaseOrderList[0].ExpectedDeliveryDate + "</td> </tr><tr><td bgcolor='#D3D3D3' style='border: 1px solid black;border-collapse: collapse; padding: 5px;text-align:left; '>Currency</td><td style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left; '>" + model.PurchaseOrderList[0].Currency + "</td> </tr><tr><td bgcolor='#D3D3D3' style='border: 1px solid black;border-collapse: collapse; padding: 5px;text-align:left; '>Ship To</td><td style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left; '>" + model.PurchaseOrderList[0].UnitName + "</td> </tr><tr><td bgcolor='#D3D3D3' style='border: 1px solid black;border-collapse: collapse; padding: 5px;text-align:left; '>Address</td><td style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left; '>" + model.PurchaseOrderList[0].LocationAddress + "," + model.PurchaseOrderList[0].City + "</td></tr></table></td></tr></table>";
                if (model.PurchaseGRNMasterListFromPO[0].PurchaseOrderType == 3)
                {

                    PurchasePDF = PurchasePDF + "<table style='width:100%;'><tr><td valign='top'>";
                    PurchasePDF = PurchasePDF + "<table style='border-collapse: collapse;border-spacing:0;margin: 0;padding: 0;'><tr><td style='padding-top: 0;font-size:7pt;text-align:left'>From Location: " + model.PurchaseGRNMasterListFromPO[0].FromLocationName + "</td></tr><tr><td style='padding-top: 0;font-size:7pt;text-align:left'>" + model.PurchaseGRNMasterListFromPO[0].FromLocationAddress + "</td></tr><tr><td style='padding-top: 0;font-size:7pt;text-align:left'>" + model.PurchaseGRNMasterListFromPO[0].FromCity + " - PO Box - " + model.PurchaseGRNMasterListFromPO[0].Frompincode + "</td></tr></table></td><td>";
                    PurchasePDF = PurchasePDF + "</td></tr></table>";
                }
                else
                {
                    PurchasePDF = PurchasePDF + "<table style='width:100%;'><tr><td valign='top'>";
                    PurchasePDF = PurchasePDF + "<table style='border-collapse: collapse;border-spacing:0;margin: 0;padding: 0;'><tr><td style='padding-top: 0;font-size:7pt;text-align:left'>Vendor: " + model.PurchaseGRNMasterListFromPO[0].VendorName + "</td></tr><tr><td style='padding-top: 0;font-size:7pt;text-align:left'>" + model.PurchaseGRNMasterListFromPO[0].VendorAddress + "</td></tr><tr><td style='padding-top: 0;font-size:7pt;text-align:left'>" + model.PurchaseGRNMasterListFromPO[0].VendorPinCode + "</td></tr><tr><td style='padding-top: 0;font-size:7pt;text-align:left'>" + model.PurchaseGRNMasterListFromPO[0].VendorPhoneNumber + "</td></tr></table></td><td>";
                    PurchasePDF = PurchasePDF + "</td></tr></table>";
                }


                string GRNNumber = "";
                if (model.PurchaseGRNMasterListFromPO.Count > 0 && model.PurchaseGRNMasterListFromPO != null)
                {
                    foreach (var item in model.PurchaseGRNMasterListFromPO)
                    {
                        if (item.Received == true)
                        {
                            if (GRNNumber == item.GRNNumber)
                            {

                                PurchasePDF = PurchasePDF + "<tr><td  bgcolor='#F7F2F2' width='27%' color='black' style='border-collapse: collapse; text-align: left; padding: 5px;font-size:7pt;'>" + item.ItemName + "</td><td  bgcolor='#F7F2F2' width='5%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt;'>" + item.ItemNumber + "</td><td  bgcolor='#F7F2F2' width='7%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt;'>" + Math.Round(item.OrderQuantity, 3) + "</td><td  bgcolor='#F7F2F2' width='7%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt;'>" + item.OrderUomCode + "</td><td  bgcolor='#F7F2F2' width='7%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt;'>" + Math.Round(item.Rate, 2) + "</td><td  bgcolor='#F7F2F2'  width='8%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt;text-align:right '>" + Math.Round(item.POAmount, 3) + "</td><td  bgcolor='#F7F2F2'  width='8%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt;text-align:right '>" + Math.Round(item.Quantity, 3) + "</td><td  bgcolor='#F7F2F2'  width='8%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt;text-align:right '>" + Math.Round(item.FOCReceivedQuantity, 3) + "</td><td  bgcolor='#F7F2F2'  width='8%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt; text-align:right'>" + Math.Round(item.GRNAmount, 2) + "</td></tr>";
                            }
                            else
                            {
                                if (GRNNumber != "")
                                {
                                    PurchasePDF = PurchasePDF + "</table>";

                                }
                                //grnnumber transaction date

                                PurchasePDF = PurchasePDF + "<br/><table border= '1' bgcolor='#fff;' color='black'><tr><td bgcolor='#D3D3D3' style='border: 1px;font-size:8pt; solid black;border-collapse: collapse; padding: 5px;text-align:Left;'> GRN No. : " + item.GRNNumber + "</td><td style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:Left; '> Transaction Date : " + item.GRNTransDate + "</td></tr></tr></table>";
                                //PurchasePDF = PurchasePDF + "</br><span>" + item.ItemName + "</span><span>" + item.ItemName + "</span>";

                                PurchasePDF = PurchasePDF + "<table border= '1' bgcolor='#fff;' color='black'><tr><th  bgcolor='#D3D3D3' color='black' style='border: 1px solid black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt'>Item Name</th><th  bgcolor='#D3D3D3' color='black' style='border: 1px solid black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt'>Item Number</th><th  bgcolor='#D3D3D3' color='black' style='border: 1px solid black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt'>Order Quantity</th><th  bgcolor='#D3D3D3' color='black' style='border: 1px solid black; border-collapse: collapse; text-align: center; padding: 0px;font-size:7pt'>Order UOM</th><th  bgcolor='#D3D3D3' color='black' style='border: 1px solid black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt'>Rate</th><th  bgcolor='#D3D3D3' color='black' style='border: 1px solid black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt'>PO Amount</th><th  bgcolor='#D3D3D3' color='black' style='border: 1px solid black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt'> Received Quantity</th><th  bgcolor='#D3D3D3' color='black' style='border: 1px solid black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt'> FOC Quantity</th><th  bgcolor='#D3D3D3' color='black' style='border: 1px solid black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt'>GRN Amount</th></tr>";

                                PurchasePDF = PurchasePDF + "<tr><td  bgcolor='#F7F2F2' width='27%' color='black' style='border-collapse: collapse; text-align: left; padding: 5px;font-size:7pt;'>" + item.ItemName + "</td><td  bgcolor='#F7F2F2' width='5%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt;'>" + item.ItemNumber + "</td><td  bgcolor='#F7F2F2' width='7%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt;'>" + Math.Round(item.OrderQuantity, 3) + "</td><td  bgcolor='#F7F2F2' width='7%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt;'>" + item.OrderUomCode + "</td><td  bgcolor='#F7F2F2' width='7%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt;'>" + Math.Round(item.Rate, 2) + "</td><td  bgcolor='#F7F2F2'  width='8%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt;text-align:right '>" + Math.Round(item.POAmount, 3) + "</td><td  bgcolor='#F7F2F2'  width='8%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt;text-align:right '>" + Math.Round(item.Quantity, 3) + "</td><td  bgcolor='#F7F2F2'  width='8%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt;text-align:right '>" + Math.Round(item.FOCReceivedQuantity, 3) + "</td><td  bgcolor='#F7F2F2'  width='8%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt; text-align:right'>" + Math.Round(item.GRNAmount, 2) + "</td></tr>";
                            }

                            GRNNumber = item.GRNNumber;
                            amount1 = Math.Round((amount1 + item.GRNAmount), 2);
                            taxamount1 = Math.Round((taxamount1 + item.TotalTaxAmount), 2);

                            if (!ItemNumberList.Contains(item.ItemNumber))
                            {
                                RecCount = RecCount + 1;
                                TotalPOAmount = Math.Round((TotalPOAmount + item.POAmount), 2);
                                ItemNumberList.Add(item.ItemNumber);
                            }
                        }
                    }

                    if (GRNNumber != "")
                    {
                        PurchasePDF = PurchasePDF + "</table>";
                    }

                    foreach (var item in model.PurchaseGRNMasterListFromPO)
                    {

                        if (item.Received == false)
                        {

                            if (NOtRecYet != 0)
                            {

                                PurchasePDF = PurchasePDF + "<tr><td  bgcolor='#F7F2F2' width='27%' color='black' style='border-collapse: collapse; text-align: left; padding: 5px;font-size:7pt;'>" + item.ItemName + "</td><td  bgcolor='#F7F2F2' width='5%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt;'>" + item.ItemNumber + "</td><td  bgcolor='#F7F2F2' width='7%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt;'>" + Math.Round(item.OrderQuantity, 3) + "</td><td  bgcolor='#F7F2F2' width='7%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt;'>" + item.OrderUomCode + "</td><td  bgcolor='#F7F2F2' width='7%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt;'>" + Math.Round(item.Rate, 2) + "</td><td  bgcolor='#F7F2F2'  width='8%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt;text-align:right '>" + Math.Round(item.POAmount, 3) + "</td><td  bgcolor='#F7F2F2'  width='8%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt;text-align:right '>" + Math.Round(item.Quantity, 3) + "</td><td  bgcolor='#F7F2F2'  width='8%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt;text-align:right '>" + Math.Round(item.FOCReceivedQuantity, 3) + "</td><td  bgcolor='#F7F2F2'  width='8%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt; text-align:right'>" + Math.Round(item.GRNAmount, 2) + "</td></tr>";

                            }
                            else
                            {

                                //grnnumber transaction date

                                PurchasePDF = PurchasePDF + "<br/><table border= '1' bgcolor='#fff;' color='black'><tr><td bgcolor='#D3D3D3' style='border: 1px;font-size:8pt; solid black;border-collapse: collapse; padding: 5px;text-align:left;'>GRN not yet received</td></tr></tr></table>";
                                //PurchasePDF = PurchasePDF + "</br><span>" + item.ItemName + "</span><span>" + item.ItemName + "</span>";

                                PurchasePDF = PurchasePDF + "<table border= '1' bgcolor='#fff;' color='black'><tr><th  bgcolor='#D3D3D3' color='black' style='border: 1px solid black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt'>Item Name</th><th  bgcolor='#D3D3D3' color='black' style='border: 1px solid black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt'>Item Number</th><th  bgcolor='#D3D3D3' color='black' style='border: 1px solid black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt'>Order Quantity</th><th  bgcolor='#D3D3D3' color='black' style='border: 1px solid black; border-collapse: collapse; text-align: center; padding: 0px;font-size:7pt'>Order UOM</th><th  bgcolor='#D3D3D3' color='black' style='border: 1px solid black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt'>Rate</th><th  bgcolor='#D3D3D3' color='black' style='border: 1px solid black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt'>PO Amount</th><th  bgcolor='#D3D3D3' color='black' style='border: 1px solid black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt'> Received Quantity</th><th  bgcolor='#D3D3D3' color='black' style='border: 1px solid black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt'> FOC Quantity</th><th  bgcolor='#D3D3D3' color='black' style='border: 1px solid black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt'>GRN Amount</th></tr>";


                                PurchasePDF = PurchasePDF + "<tr><td  bgcolor='#F7F2F2' width='27%' color='black' style='border-collapse: collapse; text-align: left; padding: 5px;font-size:7pt;'>" + item.ItemName + "</td><td  bgcolor='#F7F2F2' width='5%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt;'>" + item.ItemNumber + "</td><td  bgcolor='#F7F2F2' width='7%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt;'>" + Math.Round(item.OrderQuantity, 3) + "</td><td  bgcolor='#F7F2F2' width='7%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt;'>" + item.OrderUomCode + "</td><td  bgcolor='#F7F2F2' width='7%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt;'>" + Math.Round(item.Rate, 2) + "</td><td  bgcolor='#F7F2F2'  width='8%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt;text-align:right '>" + Math.Round(item.POAmount, 3) + "</td><td  bgcolor='#F7F2F2'  width='8%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt;text-align:right '>" + Math.Round(item.Quantity, 3) + "</td><td  bgcolor='#F7F2F2'  width='8%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt;text-align:right '>" + Math.Round(item.FOCReceivedQuantity, 3) + "</td><td  bgcolor='#F7F2F2'  width='8%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt; text-align:right'>" + Math.Round(item.GRNAmount, 2) + "</td></tr>";

                            }
                            NOtRecYet++;
                            TotalPOAmount = Math.Round((TotalPOAmount + item.POAmount), 2);

                        }

                    }

                    if (NOtRecYet != 0)
                    {
                        PurchasePDF = PurchasePDF + "</table>";
                    }

                    TotCount = NOtRecYet + RecCount;
                    DeliverItem = TotCount - NOtRecYet;
                }
                //   TotCount = NotRecCount + RecCount;
                PurchasePDF = PurchasePDF + "<br><table border= '1' bgcolor='#fff;' color='black'><tr><td bgcolor='#D3D3D3' style='border: 1px;font-size:8pt; solid black;border-collapse: collapse; padding: 5px;text-align:right;'>No. Of PO Items</td><td style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:right; '>" + TotCount + "</td></tr><tr><td bgcolor='#D3D3D3' style='border: 1px;font-size:8pt; solid black;border-collapse: collapse; padding: 5px;text-align:right;'>No. Of Delivered Items</td><td style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:right; '>" + DeliverItem + "</td></tr></table>";
                PurchasePDF = PurchasePDF + "<br><table style='width:100%;'><tr><td width='40%'>";
                PurchasePDF = PurchasePDF + "<table border= '1' bgcolor='#fff;' color='black'><tr><td bgcolor='#D3D3D3' style='border: 1px;font-size:8pt; solid black;border-collapse: collapse; padding: 5px;text-align:right;'>Sub Total</td><td style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:right; '>" + amount1 + "</td></tr><tr><td bgcolor='#D3D3D3' style='border: 1px;font-size:8pt; solid black;border-collapse: collapse; padding: 5px;text-align:right;'>Tax</td><td style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:right; '>" + taxamount1 + "</td></tr><tr><td bgcolor='#D3D3D3' style='border: 1px;font-size:8pt; solid black;border-collapse: collapse; padding: 5px;text-align:right;'>Total PO Amount</td><td style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:right; '>" + TotalPOAmount + "</td></tr><tr><td bgcolor='#D3D3D3' style='border: 1px;font-size:8pt; solid black;border-collapse: collapse; padding: 5px;text-align:right;'>Total GRN Amount</td><td style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:right; '>" + amount1 + "</td></tr></tr></table></td></tr></table>";

                PurchasePDF = PurchasePDF + "<table><tr><td width='38%'>";
                PurchasePDF = PurchasePDF + "<table style='width:38%' ><tr><th style='font-size:8pt;text-align:left'>Prepared By</th></tr><tr><td style='text-align:left'> ___________________</td></tr></table><td width='38%'>";
                PurchasePDF = PurchasePDF + "<table style='width:38%' ><tr><th style='font-size:8pt;text-align:left'>Checked By</th></tr><tr><td style='text-align:left'> ___________________</td></tr></table><td width='37%'>";
                PurchasePDF = PurchasePDF + "<table style='width:38%' ><tr><th style='font-size:8pt;text-align:left'>Authorised Signatory</th></tr><tr><td style='text-align:left'> ___________________</td></tr></table></td></tr></table>";



                DownloadPDF1(PurchasePDF, model.GRNNumber);
                MemoryStream workStream = new MemoryStream();
                return new FileStreamResult(workStream, "application/pdf");


            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DownloadPDF1(string PurchasePDF, string GRNNumber)
        {
            //string HTMLContent = "Hello <b>World</b>";

            Response.Clear();
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=" + GRNNumber + "_GRN.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.BinaryWrite(GetPDF(PurchasePDF));
            Response.End();
        }
        //Code For  Download PDF
        public byte[] GetPDF(string pHTML)
        {
            byte[] bPDF = null;

            MemoryStream ms = new MemoryStream();
            TextReader txtReader = new StringReader(pHTML);

            // 1: create object of a itextsharp document class
            Document doc = new Document(PageSize.A4, 25, 25, 25, 25);

            // 2: we create a itextsharp pdfwriter that listens to the document and directs a XML-stream to a file
            PdfWriter oPdfWriter = PdfWriter.GetInstance(doc, ms);

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


        #endregion

        // Non-Action Method
        #region Methods
        public IEnumerable<PurchaseGRNMasterViewModel> GetPurchaseGRNMaster(out int TotalRecords, Byte POStatus, int VendorID, int AdminRoleID,string MonthName,string MonthYear)
        {
            PurchaseGRNMasterSearchRequest searchRequest = new PurchaseGRNMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.POStatus = POStatus;
            searchRequest.VendorID = VendorID;
            searchRequest.AdminRoleID = AdminRoleID;
            searchRequest.MonthName = MonthName;
            searchRequest.MonthYear = MonthYear;

            _actionMode = Convert.ToString(TempData["ActionMode"]);
            if (Enum.TryParse(_actionMode, out actionModeEnum))     // checks actionMode i.e. Insert or Update // 
            {
                if (actionModeEnum == ActionModeEnum.Insert)        // parameters for SelectAll procedures under Insert or Update mode condition
                {
                    searchRequest.SortBy = "A.CreatedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = String.Empty;
                    searchRequest.SortDirection = "Desc";
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "A.ModifiedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = String.Empty;
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
            List<PurchaseGRNMasterViewModel> listPurchaseGRNMasterViewModel = new List<PurchaseGRNMasterViewModel>();
            List<PurchaseGRNMaster> listPurchaseGRNMaster = new List<PurchaseGRNMaster>();
            IBaseEntityCollectionResponse<PurchaseGRNMaster> baseEntityCollectionResponse = _PurchaseGRNMasterBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listPurchaseGRNMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (PurchaseGRNMaster item in listPurchaseGRNMaster)
                    {
                        PurchaseGRNMasterViewModel PurchaseGRNMasterViewModel = new PurchaseGRNMasterViewModel();
                        PurchaseGRNMasterViewModel.PurchaseGRNMasterDTO = item;
                        listPurchaseGRNMasterViewModel.Add(PurchaseGRNMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listPurchaseGRNMasterViewModel;
        }





        [NonAction]
        protected List<PurchaseGRNMaster> GetPurchaseOrderMasterListForGRN(int id)
        {
            PurchaseGRNMasterSearchRequest searchRequest = new PurchaseGRNMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.ID = id;
            List<PurchaseGRNMaster> listPurchaseGRNMaster = new List<PurchaseGRNMaster>();
            IBaseEntityCollectionResponse<PurchaseGRNMaster> baseEntityCollectionResponse = _PurchaseGRNMasterBA.GetPurchaseOrderMasterListForGRN(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listPurchaseGRNMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listPurchaseGRNMaster;
        }
        //Code For PDF
        [NonAction]
        protected List<PurchaseGRNMaster> GetPurchaseGrnMasterListForPDF(int PurchaseOrderMasterID)
        {
            PurchaseGRNMasterSearchRequest searchRequest = new PurchaseGRNMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.PurchaseOrderMasterID = PurchaseOrderMasterID;
            List<PurchaseGRNMaster> listPurchaseGRNMaster = new List<PurchaseGRNMaster>();
            IBaseEntityCollectionResponse<PurchaseGRNMaster> baseEntityCollectionResponse = _PurchaseGRNMasterBA.GetPurchaseGrnMasterListForPDF(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listPurchaseGRNMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listPurchaseGRNMaster;
        }
        [NonAction]
        protected List<PurchaseGRNMaster> GetPurchaseGRNDetailsByID(int id, int PurchaseOrderMaster)
        {
            PurchaseGRNMasterSearchRequest searchRequest = new PurchaseGRNMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.ID = id;
            searchRequest.PurchaseOrderMasterID = PurchaseOrderMaster;
            List<PurchaseGRNMaster> listPurchaseGRNMaster = new List<PurchaseGRNMaster>();
            IBaseEntityCollectionResponse<PurchaseGRNMaster> baseEntityCollectionResponse = _PurchaseGRNMasterBA.GetPurchaseGRNDetailsByID(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listPurchaseGRNMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listPurchaseGRNMaster;
        }

        ////Non-Action method to fetch list of batch
        [HttpPost]
        public JsonResult GetBatchNumberOfItem(string term, string ItemNumber)
        {
            var data = GetBatchList(term, Convert.ToInt32(ItemNumber));
            var result = (from r in data
                          select new
                          {
                              id = r.BatchID,
                              name = r.BatchNumber,
                              batchQuantity = r.BatchQuantity,
                              expiryDate = r.ExpiryDate,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        protected List<PurchaseGRNMaster> GetBatchList(string term, int ItemNumber)
        {
            PurchaseGRNMasterSearchRequest searchRequest = new PurchaseGRNMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.ItemNumber = ItemNumber;
            searchRequest.SearchWord = term;
            List<PurchaseGRNMaster> listFeeSubType = new List<PurchaseGRNMaster>();
            IBaseEntityCollectionResponse<PurchaseGRNMaster> baseEntityCollectionResponse = _PurchaseGRNMasterBA.GetBatchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listFeeSubType = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listFeeSubType;
        }
        [HttpPost]
        public JsonResult GetVendorSearchList(string term)
        {
            GeneralSupplierMasterSearchRequest searchRequest = new GeneralSupplierMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.SearchWord = term;
            List<GeneralSupplierMaster> listFeeSubType = new List<GeneralSupplierMaster>();
            IBaseEntityCollectionResponse<GeneralSupplierMaster> baseEntityCollectionResponse = _IGeneralSupplierMasterBA.GetBySearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listFeeSubType = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            var result = (from r in listFeeSubType
                          select new
                          {
                              id = r.ID,
                              name = r.Vender,
                              VendorNumber = r.VendorNumber,

                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }



        #endregion

        // AjaxHandler Method
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param, Byte POStatus, int VendorID, int AdminRoleID,string MonthName,string MonthYear)
        {
            if (Session["UserType"] != null)
            {
                int TotalRecords;
                var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
                string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

                IEnumerable<PurchaseGRNMasterViewModel> filteredCountryMaster;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "A.PurchaseOrderDate";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = "A.PurchaseOrderDate like '%'";
                        }
                        else
                        {
                            //_searchBy = "A.PurchaseOrderNumber Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                            _searchBy = "A.PurchaseOrderNumber Like '%" + param.sSearch + "%' or A.GRNNumber Like '%" + param.sSearch + "%'";
                        }
                        break;
                    case 1:
                        _sortBy = "A.PurchaseOrderNumber";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = "A.PurchaseOrderNumber like '%'";
                        }
                        else
                        {
                            //_searchBy = "A.PurchaseOrderNumber Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                            _searchBy = "A.PurchaseOrderNumber Like '%" + param.sSearch + "%' or A.GRNNumber Like '%" + param.sSearch + "%'";
                        }
                        break;

                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                filteredCountryMaster = GetPurchaseGRNMaster(out TotalRecords, POStatus, VendorID, AdminRoleID,MonthName,MonthYear);

                if ((filteredCountryMaster.Count()) == 0)
                {
                    filteredCountryMaster = new List<PurchaseGRNMasterViewModel>();
                    TotalRecords = 0;
                }

                var records = filteredCountryMaster.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { Convert.ToString(c.PurchaseOrderNumber), Convert.ToString(c.IsLocked), Convert.ToString(c.PurchaseOrderMasterID), Convert.ToString(c.PurchaseOrderDate), Convert.ToString(c.ID), Convert.ToString(c.GRNNumber), Convert.ToString(c.GRNIsLockedStatusFlag), Convert.ToString(c.PurchaseOrderType) };

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