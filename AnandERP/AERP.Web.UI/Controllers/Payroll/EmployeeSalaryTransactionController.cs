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
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using iTextSharp.text.html.simpleparser;
//using iTextSharp.text.pdf.parser;
using System.Web;
using iTextSharp.text.html;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml;

namespace AERP.Web.UI.Controllers
{
    public class EmployeeSalaryTransactionController : BaseController
    {
        IEmployeeSalaryTransactionBA _EmployeeSalaryTransactionBA = null;
        IEmployeeSalarySpanBA _EmployeeSalarySpanBA = null;
        ISaleContractSalaryTransactionBA _SaleContractSalaryTransactionBA = null;


        string _centreCode = string.Empty;
        string _designationId = string.Empty;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public EmployeeSalaryTransactionController()
        {
            _EmployeeSalaryTransactionBA = new EmployeeSalaryTransactionBA();
            _EmployeeSalarySpanBA = new EmployeeSalarySpanBA();
            _SaleContractSalaryTransactionBA = new SaleContractSalaryTransactionBA();
        }

        #region Controller Methods

        /// <summary>
        /// First Load When controller call List Method
        /// </summary>
        /// <returns>view</returns>
        [HttpGet]
        public ActionResult Index()
        {
            bool IsApplied = CheckMenuApplicableOrNot(ControllerContext.RouteData.Values["Controller"].ToString());
            if (Convert.ToString(Session["UserType"]) == "A" || (Convert.ToInt32(Session["HR Manager"]) > 0 && IsApplied == true))
            {
                EmployeeSalaryTransactionViewModel _EmployeeSalaryTransactionViewModel = new EmployeeSalaryTransactionViewModel();

                if (TempData["_errorMsg"] != null)
                {
                    _EmployeeSalaryTransactionViewModel.errorMessage = Convert.ToString(TempData["_errorMsg"]);
                }
                else
                {
                    _EmployeeSalaryTransactionViewModel.errorMessage = "NoMessage";
                }

                int AdminRoleMasterID = 0;
                if (Session["RoleID"] == null)
                {
                    AdminRoleMasterID = Convert.ToInt32(Session["DefaultRoleID"]);
                }
                else
                {
                    AdminRoleMasterID = Convert.ToInt32(Session["RoleID"]);
                }
                List<AdminRoleApplicableDetails> listAdminRoleApplicableDetails = null;
                if (Convert.ToInt32(Session["HR Manager"]) > 0 || Convert.ToString(Session["UserType"]) == "A")
                {
                    listAdminRoleApplicableDetails = GetAdminRoleApplicableCentreByHRManager(AdminRoleMasterID);
                }
                AdminRoleApplicableDetails a = null;
                foreach (var item in listAdminRoleApplicableDetails)
                {
                    a = new AdminRoleApplicableDetails();
                    a.CentreCode = item.CentreCode;
                    a.CentreName = item.CentreName;
                    a.ScopeIdentity = item.ScopeIdentity;
                    _EmployeeSalaryTransactionViewModel.ListGetAdminRoleApplicableCentre.Add(a);
                }
                foreach (var b in _EmployeeSalaryTransactionViewModel.ListGetAdminRoleApplicableCentre)
                {
                    b.CentreCode = b.CentreCode + ":" + b.ScopeIdentity;
                }

                _EmployeeSalaryTransactionViewModel.EmployeeSalarySpanList = GetEmployeeSalarySpanList();

                return View("/Views/Payroll/EmployeeSalaryTransaction/Index.cshtml", _EmployeeSalaryTransactionViewModel);
            }
            else
            {
                return RedirectToAction("UnauthorizedAccess", "Home");
            }
        }

        public ActionResult List(string actionMode, string SelectedCentreCode, string SelectedDepartmentID, string EmployeeSalarySpanID)
        {
            try
            {
                EmployeeSalaryTransactionViewModel model = new EmployeeSalaryTransactionViewModel();

                string[] splitCentreCode = SelectedCentreCode.Split(':');
                var centreCode = splitCentreCode[0];

                model.SelectedCentreCode = Convert.ToString(centreCode);
                model.DepartmentMasterID = Convert.ToInt32(SelectedDepartmentID);
                model.EmployeeSalarySpanID = Convert.ToInt16(EmployeeSalarySpanID);

                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Payroll/EmployeeSalaryTransaction/List.cshtml", model);

            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpGet]
        public ActionResult GenerateSalary(string EmployeeMasterID, string EmployeeSalarySpanID, string EmployeeSalaryRulesID)
        {
            EmployeeSalaryTransactionViewModel model = new EmployeeSalaryTransactionViewModel();

            model.EmployeeMasterID = Convert.ToInt32(EmployeeMasterID);
            model.EmployeeSalarySpanID = Convert.ToInt16(EmployeeSalarySpanID);
            model.EmployeeSalaryRulesID = Convert.ToInt64(EmployeeSalaryRulesID);
            model.CreatedBy = Convert.ToInt32(Session["UserID"]);
            model.EmployeeSalaryTransactionList = GetSalaryTransactionForGeneration(EmployeeMasterID, EmployeeSalarySpanID, EmployeeSalaryRulesID);

            return PartialView("/Views/Payroll/EmployeeSalaryTransaction/GenerateSalary.cshtml", model);
        }

        [HttpGet]
        public ActionResult GenerateBulkSalary(string SelectedCentreCode, string DepartmentMasterID, string EmployeeSalarySpanID)
        {
            EmployeeSalaryTransactionViewModel model = new EmployeeSalaryTransactionViewModel();

            model.SelectedCentreCode = Convert.ToString(SelectedCentreCode);
            model.DepartmentMasterID = Convert.ToInt32(DepartmentMasterID);
            model.EmployeeSalarySpanID = Convert.ToInt16(EmployeeSalarySpanID);
            model.CreatedBy = Convert.ToInt32(Session["UserID"]);
            model.EmployeeSalaryTransactionList = GetSalaryTransactionForBulkGeneration(SelectedCentreCode, DepartmentMasterID, EmployeeSalarySpanID);

            return PartialView("/Views/Payroll/EmployeeSalaryTransaction/GenerateBulkSalary.cshtml", model);
        }

        [HttpPost]
        public ActionResult GenerateSalary(EmployeeSalaryTransactionViewModel model)
        {
            try
            {
                if (model != null && model.EmployeeSalaryTransactionDTO != null)
                {
                    model.EmployeeSalaryTransactionDTO.ConnectionString = _connectioString;

                    model.EmployeeSalaryTransactionDTO.EmployeeSalarySpanID = model.EmployeeSalarySpanID;
                    model.EmployeeSalaryTransactionDTO.EmployeeMasterID = model.EmployeeMasterID;
                    model.EmployeeSalaryTransactionDTO.EmployeeSalaryRulesID = model.EmployeeSalaryRulesID;
                    model.EmployeeSalaryTransactionDTO.BasicAmount = model.BasicAmount;
                    model.EmployeeSalaryTransactionDTO.AdjustedBasicAmount = model.AdjustedBasicAmount;
                    model.EmployeeSalaryTransactionDTO.TotalAmount = model.TotalAmount;
                    model.EmployeeSalaryTransactionDTO.GrossAmount = model.GrossAmount;
                    model.EmployeeSalaryTransactionDTO.TotalEarnings = model.TotalEarnings;
                    model.EmployeeSalaryTransactionDTO.TotalDeduction = model.TotalDeduction;
                    model.EmployeeSalaryTransactionDTO.NetPayable = model.NetPayable;
                    model.EmployeeSalaryTransactionDTO.EmployerContributionTotal = model.EmployerContributionTotal;
                    model.EmployeeSalaryTransactionDTO.TotalSalary = model.TotalSalary;
                    model.EmployeeSalaryTransactionDTO.AdjustedTotalSalary = model.AdjustedTotalSalary;
                    model.EmployeeSalaryTransactionDTO.AdjustedTotalDays = model.AdjustedTotalDays;
                    model.EmployeeSalaryTransactionDTO.XMLStringSalaryTransaction = model.XMLStringSalaryTransaction;
                    model.EmployeeSalaryTransactionDTO.IsRemoveForAdjustment = model.IsRemoveForAdjustment;
                    model.EmployeeSalaryTransactionDTO.XMLstringForVouchar = model.XMLstringForVouchar;

                    model.EmployeeSalaryTransactionDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<EmployeeSalaryTransaction> response = _EmployeeSalaryTransactionBA.GenerateEmployeeSalaryTransaction(model.EmployeeSalaryTransactionDTO);

                    model.EmployeeSalaryTransactionDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);

                    return Json(model.EmployeeSalaryTransactionDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        }

        [HttpPost]
        public ActionResult GenerateBulkSalary(EmployeeSalaryTransactionViewModel model)
        {
            try
            {
                if (model != null && model.EmployeeSalaryTransactionDTO != null)
                {
                    model.EmployeeSalaryTransactionDTO.ConnectionString = _connectioString;
                    model.EmployeeSalaryTransactionDTO.CentreCode = model.SelectedCentreCode;
                    model.EmployeeSalaryTransactionDTO.EmployeeSalarySpanID = model.EmployeeSalarySpanID;
                    model.EmployeeSalaryTransactionDTO.DepartmentMasterID = model.DepartmentMasterID;
                    model.EmployeeSalaryTransactionDTO.XMLStringBulkSalaryTransactionEmployee = model.XMLStringBulkSalaryTransactionEmployee;
                    model.EmployeeSalaryTransactionDTO.XMLStringBulkSalaryTransaction = model.XMLStringBulkSalaryTransaction;
                    model.EmployeeSalaryTransactionDTO.XMLstringForVouchar = model.XMLstringForVouchar;

                    model.EmployeeSalaryTransactionDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<EmployeeSalaryTransaction> response = _EmployeeSalaryTransactionBA.GenerateSaleContractBulkSalaryTransaction(model.EmployeeSalaryTransactionDTO);

                    model.EmployeeSalaryTransactionDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);

                    return Json(model.EmployeeSalaryTransactionDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        }

        [HttpGet]
        public ActionResult ViewSalaryDetails(string ID)
        {
            EmployeeSalaryTransactionViewModel model = new EmployeeSalaryTransactionViewModel();

            model.ID = Convert.ToInt64(ID);
            model.EmployeeSalaryTransactionList = GetSalaryTransactionDetailsByID(ID);

            return PartialView("/Views/Payroll/EmployeeSalaryTransaction/ViewSalaryDetails.cshtml", model);
        }

        [HttpGet]
        public ActionResult AddDeduction(string EmployeeMasterID, string EmployeeSalaryRulesID)
        {
            EmployeeSalaryTransactionViewModel model = new EmployeeSalaryTransactionViewModel();

            model.EmployeeMasterID = Convert.ToInt32(EmployeeMasterID);
            model.EmployeeSalaryRulesID = Convert.ToInt64(EmployeeSalaryRulesID);

            List<SaleContractSalaryTransaction> SaleContractSalaryTransaction = GetListSaleContractSalaryTransactionDeduction();
            List<SelectListItem> SaleContractSalaryTransactionDeductionList = new List<SelectListItem>();
            foreach (SaleContractSalaryTransaction item in SaleContractSalaryTransaction)
            {
                SaleContractSalaryTransactionDeductionList.Add(new SelectListItem { Text = item.HeadName, Value = Convert.ToString(item.HeadID) + "~" + Convert.ToString(item.SaleContractManPowerDeductionID) });
            }
            ViewBag.SaleContractSalaryTransactionDeductionList = new SelectList(SaleContractSalaryTransactionDeductionList, "Value", "Text");

            return PartialView("/Views/Payroll/EmployeeSalaryTransaction/AddDeduction.cshtml", model);
        }

        [HttpPost]
        public ActionResult AddDeduction(EmployeeSalaryTransactionViewModel model)
        {
            try
            {
                if (model != null && model.EmployeeSalaryTransactionDTO != null)
                {
                    model.EmployeeSalaryTransactionDTO.ConnectionString = _connectioString;
                    model.EmployeeSalaryTransactionDTO.EmployeeMasterID = model.EmployeeMasterID;
                    model.EmployeeSalaryTransactionDTO.EmployeeSalaryRulesID = model.EmployeeSalaryRulesID;
                    string[] splitHeadName = model.HeadName.Split('~');
                    model.EmployeeSalaryTransactionDTO.HeadID = Convert.ToByte(splitHeadName[0]);
                    model.EmployeeSalaryTransactionDTO.SaleContractManPowerDeductionID = Convert.ToInt32(splitHeadName[1]);

                    model.EmployeeSalaryTransactionDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<EmployeeSalaryTransaction> response = _EmployeeSalaryTransactionBA.AddSaleContractSalaryTransactionDeduction(model.EmployeeSalaryTransactionDTO);

                    model.EmployeeSalaryTransactionDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);

                    return Json(model.EmployeeSalaryTransactionDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        }

        protected List<SaleContractSalaryTransaction> GetListSaleContractSalaryTransactionDeduction()
        {

            SaleContractSalaryTransactionSearchRequest searchRequest = new SaleContractSalaryTransactionSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            List<SaleContractSalaryTransaction> listSaleContractSalaryTransaction = new List<SaleContractSalaryTransaction>();
            IBaseEntityCollectionResponse<SaleContractSalaryTransaction> baseEntityCollectionResponse = _SaleContractSalaryTransactionBA.GetListSaleContractSalaryTransactionDeduction(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listSaleContractSalaryTransaction = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listSaleContractSalaryTransaction;
        }
        /*  public ActionResult AddDeduction(string SaleContractMasterID, string SaleContractBillingSpanID)
          {
              EmployeeSalaryTransactionViewModel model = new EmployeeSalaryTransactionViewModel();

              model.SaleContractMasterID = Convert.ToInt64(SaleContractMasterID);
              model.SaleContractBillingSpanID = Convert.ToInt64(SaleContractBillingSpanID);

              List<EmployeeSalaryTransaction> EmployeeSalaryTransaction = GetListEmployeeSalaryTransactionDeduction();
              List<SelectListItem> EmployeeSalaryTransactionDeductionList = new List<SelectListItem>();
              foreach (EmployeeSalaryTransaction item in EmployeeSalaryTransaction)
              {
                  EmployeeSalaryTransactionDeductionList.Add(new SelectListItem { Text = item.HeadName, Value = Convert.ToString(item.HeadID) + "~" + Convert.ToString(item.SaleContractManPowerDeductionID) });
              }
              ViewBag.EmployeeSalaryTransactionDeductionList = new SelectList(EmployeeSalaryTransactionDeductionList, "Value", "Text");

              return PartialView("/Views/Payroll/EmployeeSalaryTransaction/AddDeduction.cshtml", model);
          }

        [HttpPost]
        public ActionResult AddDeduction(EmployeeSalaryTransactionViewModel model)
        {
            try
            {
                if (model != null && model.EmployeeSalaryTransactionDTO != null)
                {
                    model.EmployeeSalaryTransactionDTO.ConnectionString = _connectioString;
                    model.EmployeeSalaryTransactionDTO.SaleContractMasterID = model.SaleContractMasterID;
                    model.EmployeeSalaryTransactionDTO.SaleContractBillingSpanID = model.SaleContractBillingSpanID;
                    string[] splitHeadName = model.HeadName.Split('~');
                    model.EmployeeSalaryTransactionDTO.HeadID = Convert.ToByte(splitHeadName[0]);
                    model.EmployeeSalaryTransactionDTO.SaleContractManPowerDeductionID = Convert.ToInt32(splitHeadName[1]);

                    model.EmployeeSalaryTransactionDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<EmployeeSalaryTransaction> response = _EmployeeSalaryTransactionBA.AddEmployeeSalaryTransactionDeduction(model.EmployeeSalaryTransactionDTO);

                    model.EmployeeSalaryTransactionDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);

                    return Json(model.EmployeeSalaryTransactionDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        }
        */
        public void Download(string ID)
        {
            // MemoryStream workStream = new MemoryStream();

            StringBuilder status = new StringBuilder("");
            DateTime dTime = DateTime.Now;
            //file name to be created   
            Document doc = new Document();
            doc.SetMargins(0f, 0f, 0f, 0f);

            //Create PDF Table with 5 columns  
            PdfPTable tableLayoutHeader = new PdfPTable(3);
            doc.SetMargins(20f, 20f, 20f, 20f);

            //Create PDF Table with 4 columns  for Employee Information
            PdfPTable tableLayoutEmpDetails = new PdfPTable(4);
            doc.SetMargins(20f, 20f, 20f, 20f);

            //Create PDF Table with 3 columns for Employee Allowance
            PdfPTable tableLayoutAllowance = new PdfPTable(3);
            doc.SetMargins(20f, 20f, 20f, 20f);

            //Create PDF Table with 2 columns for Employee Allowance
            PdfPTable tableLayoutDeduction = new PdfPTable(2);
            doc.SetMargins(20f, 20f, 20f, 20f);
            //Create PDF Table with 4 columns for Employee Take Home Salary
            PdfPTable tableLayoutTakeHomeSal = new PdfPTable(4);
            doc.SetMargins(20f, 20f, 20f, 20f);
            //Create PDF Table with 1 columns for Company Signiture
            PdfPTable tableLayoutSigniture = new PdfPTable(1);
            doc.SetMargins(20f, 20f, 20f, 20f);


            //Create PDF Table  

            PdfWriter writer = PdfWriter.GetInstance(doc, Response.OutputStream);
            doc.Open();

            //Add Title to the PDF file at the top  
            EmployeeSalaryTransactionViewModel model = new EmployeeSalaryTransactionViewModel();

            model.EmployeeSalaryTransactionDTO = new EmployeeSalaryTransaction();
            model.EmployeeSalaryTransactionDTO.ID = Convert.ToInt64(ID);
            model.EmployeeSalaryTransactionDTO.ConnectionString = _connectioString;
            model.EmployeeSalaryTransactionList = GetSalaryTransactionDetailsByID(ID);

            //Add Content to PDF 
            //doc.Add(Add_Content_To_PDF(tableLayout,ID));
            float[] headers = { 50, 30, 50 }; //Header Widths  
            tableLayoutHeader.SetWidths(headers); //Set the pdf headers  
            tableLayoutHeader.TotalWidth = 555f; //Set the PDF File witdh percentage  
            tableLayoutHeader.HorizontalAlignment = Element.ALIGN_CENTER;
            tableLayoutHeader.HeaderRows = 1;


            //doc.Add(Add_Content_To_PDF(tableLayout,ID));
            float[] headersEmpDetails = { 30, 70, 30, 70 }; //Header Widths  
            tableLayoutEmpDetails.SetWidths(headersEmpDetails); //Set the pdf headers  
            tableLayoutEmpDetails.TotalWidth = 555f; //Set the PDF File witdh percentage  
            tableLayoutEmpDetails.HorizontalAlignment = Element.ALIGN_CENTER;
            tableLayoutEmpDetails.HeaderRows = 1;

            //doc.Add(Add_Content_To_PDF(tableLayout,ID));
            float[] headersAllowance = { 70, 40, 40 }; //Header Widths  
            tableLayoutAllowance.SetWidths(headersAllowance); //Set the pdf headers  
            tableLayoutAllowance.TotalWidth = 340f; //Set the PDF File witdh percentage  
            tableLayoutAllowance.HorizontalAlignment = Element.ALIGN_LEFT;
            tableLayoutAllowance.HeaderRows = 1;


            //doc.Add(Add_Content_To_PDF(tableLayout,ID));
            float[] headersDeduction = { 70, 40 }; //Header Widths  
            tableLayoutDeduction.SetWidths(headersDeduction); //Set the pdf headers  
            tableLayoutDeduction.TotalWidth = 215f; //Set the PDF File witdh percentage  
            tableLayoutDeduction.HorizontalAlignment = Element.ALIGN_RIGHT;
            tableLayoutDeduction.HeaderRows = 1;

            //doc.Add(Add_Content_To_PDF(tableLayout,ID));
            float[] headersTakeHomeSal = { 69, 50, 50, 70 }; //Header Widths  
            tableLayoutTakeHomeSal.SetWidths(headersTakeHomeSal); //Set the pdf headers  
            tableLayoutTakeHomeSal.TotalWidth = 555f; //Set the PDF File witdh percentage  
            tableLayoutTakeHomeSal.HorizontalAlignment = Element.ALIGN_CENTER;
            tableLayoutTakeHomeSal.HeaderRows = 1;

            //doc.Add(Add_Content_To_PDF(tableLayout,ID));
            float[] headersSigniture = { 100 }; //Header Widths  
            tableLayoutSigniture.SetWidths(headersSigniture); //Set the pdf headers  
            tableLayoutSigniture.TotalWidth = 555f; //Set the PDF File witdh percentage  
            tableLayoutSigniture.HorizontalAlignment = Element.ALIGN_CENTER;
            tableLayoutSigniture.HeaderRows = 1;

            ////Add body  

            //FontFactory.Register("D:\\Project\\AnandERP\\AnandERP\\AERP.Web.UI\\Content\\Theme\\fonts\\Bahamas Bold.ttf", "Bahamas");
            //var titleFont = FontFactory.GetFont("Bahamas", 20f);

            //tableLayoutHeader.AddCell(new PdfPCell(new Phrase(model.EmployeeSalaryTransactionList[0].CentreName, titleFont))
            tableLayoutHeader.AddCell(new PdfPCell(new Phrase(model.EmployeeSalaryTransactionList[0].CentreName, new Font(Font.FontFamily.HELVETICA, 8, 1, iTextSharp.text.BaseColor.BLACK)))
            {
                HorizontalAlignment = Element.ALIGN_LEFT,
                Padding = 5,
                BackgroundColor = new iTextSharp.text.BaseColor(255, 255, 255),
                UseVariableBorders = true,
                BorderColorRight = BaseColor.WHITE,
                VerticalAlignment = Element.ALIGN_MIDDLE

            });
            iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(Path.Combine(Server.MapPath("~") + "Content\\UploadedFiles\\Inventory\\Logo\\" + model.EmployeeSalaryTransactionList[0].LogoPath));
            jpg.ScaleAbsolute(50f, 50f);
            tableLayoutHeader.AddCell(new PdfPCell(jpg) { PaddingTop = 5, PaddingBottom = 5, HorizontalAlignment = Element.ALIGN_CENTER, UseVariableBorders = true, BorderColorLeft = BaseColor.WHITE, BorderColorRight = BaseColor.WHITE });

            tableLayoutHeader.AddCell(new PdfPCell(new Phrase("Pay Slip For Span" + model.EmployeeSalaryTransactionList[0].SaleContractBillingSpanName, new Font(Font.FontFamily.HELVETICA, 8, 1, iTextSharp.text.BaseColor.BLACK)))
            {
                HorizontalAlignment = Element.ALIGN_LEFT,
                Padding = 5,
                BackgroundColor = new iTextSharp.text.BaseColor(255, 255, 255),
                UseVariableBorders = true,
                BorderColorLeft = BaseColor.WHITE,
                VerticalAlignment = Element.ALIGN_MIDDLE

            });

            tableLayoutHeader.WriteSelectedRows(0, -1, doc.Left, doc.Top, writer.DirectContent);
            // doc.Add(tableLayoutHeader);

            //For First Row
            AddCellToBodyWithLeftBorder(tableLayoutEmpDetails, "Employee Code");
            AddCellToBodyWithNoBorder(tableLayoutEmpDetails, ":" + model.EmployeeSalaryTransactionList[0].EmployeeCode);
            AddCellToBodyWithNoBorder(tableLayoutEmpDetails, "Bank Name");
            AddCellToBodyWithRightBorder(tableLayoutEmpDetails, ":" + "SBI");
            //For Second Row
            AddCellToBodyWithLeftBorder(tableLayoutEmpDetails, "Name");
            AddCellToBodyWithNoBorder(tableLayoutEmpDetails, ":" + model.EmployeeSalaryTransactionList[0].EmployeeName);
            AddCellToBodyWithNoBorder(tableLayoutEmpDetails, "Account No");
            AddCellToBodyWithRightBorder(tableLayoutEmpDetails, ":" + model.EmployeeSalaryTransactionList[0].BankACNumber);

            //For Third Row
            AddCellToBodyWithLeftBorder(tableLayoutEmpDetails, "Designation");
            AddCellToBodyWithNoBorder(tableLayoutEmpDetails, ":" + model.EmployeeSalaryTransactionList[0].DesignationName);
            AddCellToBodyWithNoBorder(tableLayoutEmpDetails, "PF No");
            AddCellToBodyWithRightBorder(tableLayoutEmpDetails, ":" + model.EmployeeSalaryTransactionList[0].ProvidentFundNumber);

            //For Fourth Row
            AddCellToBodyWithLeftBorder(tableLayoutEmpDetails, "Location");
            AddCellToBodyWithNoBorder(tableLayoutEmpDetails, ":" + model.EmployeeSalaryTransactionList[0].City);
            AddCellToBodyWithNoBorder(tableLayoutEmpDetails, "UAN No.");
            AddCellToBodyWithRightBorder(tableLayoutEmpDetails, ":" + model.EmployeeSalaryTransactionList[0].UANNumber);

            //For Fifth Row
            AddCellToBodyWithLeftBorder(tableLayoutEmpDetails, "Working Days");
            AddCellToBodyWithNoBorder(tableLayoutEmpDetails, ":" + Convert.ToString(model.EmployeeSalaryTransactionList[0].TotalDays));
            AddCellToBodyWithNoBorder(tableLayoutEmpDetails, "Paid Days");
            AddCellToBodyWithRightBorder(tableLayoutEmpDetails, ":" + Convert.ToString(model.EmployeeSalaryTransactionList[0].TotalAttendance));

            tableLayoutEmpDetails.WriteSelectedRows(0, -1, doc.Left, doc.Top - tableLayoutHeader.CalculateHeights(), writer.DirectContent);

            ///For Allowance
            tableLayoutAllowance.AddCell(new PdfPCell(new Phrase("Earnings", new Font(Font.FontFamily.HELVETICA, 8, 1, iTextSharp.text.BaseColor.BLACK)))
            {
                HorizontalAlignment = Element.ALIGN_LEFT,
                Padding = 5,
                BackgroundColor = new iTextSharp.text.BaseColor(212, 212, 212),
                UseVariableBorders = true,
                BorderColorRight = BaseColor.WHITE,
                VerticalAlignment = Element.ALIGN_MIDDLE

            });
            tableLayoutAllowance.AddCell(new PdfPCell(new Phrase("Monthly Pay", new Font(Font.FontFamily.HELVETICA, 8, 1, iTextSharp.text.BaseColor.BLACK)))
            {
                HorizontalAlignment = Element.ALIGN_LEFT,
                Padding = 5,
                BackgroundColor = new iTextSharp.text.BaseColor(212, 212, 212),
                UseVariableBorders = true,
                BorderColorRight = BaseColor.WHITE,
                BorderColorLeft = BaseColor.WHITE,
                VerticalAlignment = Element.ALIGN_MIDDLE

            });
            tableLayoutAllowance.AddCell(new PdfPCell(new Phrase("Actual", new Font(Font.FontFamily.HELVETICA, 8, 1, iTextSharp.text.BaseColor.BLACK)))
            {
                HorizontalAlignment = Element.ALIGN_LEFT,
                Padding = 5,
                BackgroundColor = new iTextSharp.text.BaseColor(212, 212, 212),
                UseVariableBorders = true,
                BorderColorLeft = BaseColor.WHITE,
                VerticalAlignment = Element.ALIGN_MIDDLE

            });

            decimal BasicAmount = Math.Round(model.EmployeeSalaryTransactionList[0].BasicAmount);
            decimal TotalAttendance = model.EmployeeSalaryTransactionList[0].TotalAttendance;
            byte TotalDays = model.EmployeeSalaryTransactionList[0].TotalDays;
            decimal AdjustedTotalDays = model.EmployeeSalaryTransactionList[0].AdjustedTotalDays;
            decimal ActualBasicAmount = Math.Round((BasicAmount / TotalDays) * TotalAttendance);

            AddCellToBodyWithLeftBorder(tableLayoutAllowance, "Basic");
            AddCellToBodyWithNoBorder(tableLayoutAllowance, Convert.ToString(BasicAmount));
            AddCellToBodyWithRightBorder(tableLayoutAllowance, Convert.ToString(ActualBasicAmount));

            decimal TotalEarning = BasicAmount, ActualTotalEarning = ActualBasicAmount;
            decimal TotalDeduction = 0, ActualTotalDeduction = 0;

            foreach (var emp in model.EmployeeSalaryTransactionList)
            {
                if (emp.HeadType == "DA")
                {
                    decimal amount = 0;
                    if (emp.FixedAmount > 0)
                    {
                        amount = Math.Round(emp.FixedAmount);
                    }
                    else
                    {
                        var CalculateOnValue = emp.CalculateOnString.Replace(", ", ",").Split(',');
                        decimal CalculateOnAmount = 0;
                        foreach (var CalOn in CalculateOnValue)
                        {
                            var ReferenceID = CalOn.Split('~');
                            if (Convert.ToByte(ReferenceID[0]) == 0)
                            {
                                CalculateOnAmount = CalculateOnAmount + BasicAmount;
                            }
                            else
                            {
                                foreach (var itemSub in model.EmployeeSalaryTransactionList)
                                {
                                    if (itemSub.HeadID == Convert.ToByte(ReferenceID[0]) && ((itemSub.RuleType == "Allowance" && Convert.ToByte(ReferenceID[1]) == 2) || (itemSub.RuleType == "Deduction" && Convert.ToByte(ReferenceID[1]) == 3)))
                                    {
                                        CalculateOnAmount = CalculateOnAmount + itemSub.Amount;
                                    }
                                }
                            }
                        }
                        amount = Math.Round(CalculateOnAmount * emp.Percentage / 100);

                    }
                    emp.Amount = amount;
                    AddCellToBodyWithLeftBorder(tableLayoutAllowance, emp.HeadName);
                    AddCellToBodyWithNoBorder(tableLayoutAllowance, Convert.ToString(amount));
                    AddCellToBodyWithRightBorder(tableLayoutAllowance, Convert.ToString(emp.ActualAmount));

                    TotalEarning = TotalEarning + amount;
                    ActualTotalEarning = ActualTotalEarning + emp.ActualAmount;
                }
            }

            foreach (var emp in model.EmployeeSalaryTransactionList)
            {
                if (emp.RuleType == "Allowance" && emp.HeadType != "DA")
                {
                    decimal amount = 0;
                    if (emp.FixedAmount > 0)
                    {
                        amount = Math.Round(emp.FixedAmount);
                        emp.Amount = amount;
                        AddCellToBodyWithLeftBorder(tableLayoutAllowance, emp.HeadName);
                        AddCellToBodyWithNoBorder(tableLayoutAllowance, Convert.ToString(amount));
                        AddCellToBodyWithRightBorder(tableLayoutAllowance, Convert.ToString(emp.ActualAmount));

                        TotalEarning = TotalEarning + amount;
                        ActualTotalEarning = ActualTotalEarning + emp.ActualAmount;

                    }
                    else if (emp.Percentage > 0)
                    {
                        var CalculateOnValue = emp.CalculateOnString.Replace(", ", ",").Split(',');
                        decimal CalculateOnAmount = 0;
                        foreach (var CalOn in CalculateOnValue)
                        {
                            var ReferenceID = CalOn.Split('~');
                            if (Convert.ToByte(ReferenceID[0]) == 0)
                            {
                                CalculateOnAmount = CalculateOnAmount + BasicAmount;
                            }
                            else
                            {
                                foreach (var itemSub in model.EmployeeSalaryTransactionList)
                                {
                                    if (itemSub.HeadID == Convert.ToByte(ReferenceID[0]) && ((itemSub.RuleType == "Allowance" && Convert.ToByte(ReferenceID[1]) == 2) || (itemSub.RuleType == "Deduction" && Convert.ToByte(ReferenceID[1]) == 3)))
                                    {
                                        CalculateOnAmount = CalculateOnAmount + itemSub.Amount;
                                    }
                                }
                            }
                        }
                        amount = Math.Round(CalculateOnAmount * emp.Percentage / 100);
                        emp.Amount = amount;
                        AddCellToBodyWithLeftBorder(tableLayoutAllowance, emp.HeadName);
                        AddCellToBodyWithNoBorder(tableLayoutAllowance, Convert.ToString(amount));
                        AddCellToBodyWithRightBorder(tableLayoutAllowance, Convert.ToString(emp.ActualAmount));

                        TotalEarning = TotalEarning + amount;
                        ActualTotalEarning = ActualTotalEarning + emp.ActualAmount;
                    }
                    else if (emp.ComplianceType == 2)
                    {
                        AddCellToBodyWithLeftBorder(tableLayoutAllowance, emp.HeadName);
                        AddCellToBodyWithNoBorder(tableLayoutAllowance, Convert.ToString(amount));
                        AddCellToBodyWithRightBorder(tableLayoutAllowance, Convert.ToString(emp.ActualAmount));

                        TotalEarning = TotalEarning + amount;
                        ActualTotalEarning = ActualTotalEarning + emp.ActualAmount;
                    }

                }
            }

            ///For Deduction
            tableLayoutDeduction.AddCell(new PdfPCell(new Phrase("Deduction", new Font(Font.FontFamily.HELVETICA, 8, 1, iTextSharp.text.BaseColor.BLACK)))
            {
                HorizontalAlignment = Element.ALIGN_LEFT,
                Padding = 5,
                BackgroundColor = new iTextSharp.text.BaseColor(212, 212, 212),
                UseVariableBorders = true,
                BorderColorRight = BaseColor.WHITE,
                VerticalAlignment = Element.ALIGN_MIDDLE

            });
            tableLayoutDeduction.AddCell(new PdfPCell(new Phrase("Actual", new Font(Font.FontFamily.HELVETICA, 8, 1, iTextSharp.text.BaseColor.BLACK)))
            {
                HorizontalAlignment = Element.ALIGN_LEFT,
                Padding = 5,
                BackgroundColor = new iTextSharp.text.BaseColor(212, 212, 212),
                UseVariableBorders = true,
                BorderColorLeft = BaseColor.WHITE,
                VerticalAlignment = Element.ALIGN_MIDDLE

            });

            bool IsPTAdded = false;
            foreach (var emp in model.EmployeeSalaryTransactionList)
            {
                if (emp.RuleType == "Deduction" && emp.ContributionType == 1 && emp.HeadType == "PT" && IsPTAdded == false)
                {
                    decimal amount = 0;
                    IsPTAdded = true;
                    if (emp.FixedAmount == 0 && emp.Percentage == 0)
                    {
                        amount = 0;
                    }
                    else if (emp.FixedAmount > 0)
                    {
                        amount = Math.Round(emp.FixedAmount);
                    }
                    else
                    {
                        var CalculateOnValue = emp.CalculateOnString.Replace(", ", ",").Split(',');
                        decimal CalculateOnAmount = 0;
                        foreach (var CalOn in CalculateOnValue)
                        {
                            var ReferenceID = CalOn.Split('~');

                            if (Convert.ToByte(ReferenceID[0]) == 0 && Convert.ToByte(ReferenceID[1]) == 1)
                            {
                                CalculateOnAmount = CalculateOnAmount + BasicAmount;
                            }
                            else if (Convert.ToByte(ReferenceID[0]) == 0 && Convert.ToByte(ReferenceID[1]) == 4)
                            {
                                CalculateOnAmount = CalculateOnAmount + emp.CalculateOnFixedAmount;
                            }
                            else
                            {
                                foreach (var itemSub in model.EmployeeSalaryTransactionList)
                                {
                                    if (itemSub.HeadID == Convert.ToByte(ReferenceID[0]) && ((itemSub.RuleType == "Allowance" && Convert.ToByte(ReferenceID[1]) == 2) || (itemSub.RuleType == "Deduction" && Convert.ToByte(ReferenceID[1]) == 3)))
                                    {
                                        CalculateOnAmount = CalculateOnAmount + itemSub.Amount;
                                    }
                                }
                            }
                        }
                        amount = Math.Round(CalculateOnAmount * emp.Percentage / 100);

                    }
                    emp.Amount = amount;
                    AddCellToBodyWithLeftBorder(tableLayoutDeduction, emp.HeadName);
                    AddCellToBodyWithRightBorder(tableLayoutDeduction, Convert.ToString(emp.ActualAmount));

                    TotalDeduction = TotalDeduction + amount;
                    ActualTotalDeduction = ActualTotalDeduction + emp.ActualAmount;
                }
            }

            foreach (var emp in model.EmployeeSalaryTransactionList)
            {
                if (emp.RuleType == "Deduction" && emp.ContributionType == 1 && emp.HeadType != "PT")
                {
                    decimal amount = 0;

                    if (emp.FixedAmount == 0 && emp.Percentage == 0)
                    {
                        amount = 0;
                    }
                    else if (emp.FixedAmount > 0)
                    {
                        amount = Math.Round(emp.FixedAmount);
                    }
                    else
                    {
                        var CalculateOnValue = emp.CalculateOnString.Replace(", ", ",").Split(',');
                        decimal CalculateOnAmount = 0;
                        foreach (var CalOn in CalculateOnValue)
                        {
                            var ReferenceID = CalOn.Split('~');

                            if (Convert.ToByte(ReferenceID[0]) == 0 && Convert.ToByte(ReferenceID[1]) == 1)
                            {
                                CalculateOnAmount = CalculateOnAmount + BasicAmount;
                            }
                            else if (Convert.ToByte(ReferenceID[0]) == 0 && Convert.ToByte(ReferenceID[1]) == 4)
                            {
                                CalculateOnAmount = CalculateOnAmount + emp.CalculateOnFixedAmount;
                            }
                            else
                            {
                                foreach (var itemSub in model.EmployeeSalaryTransactionList)
                                {
                                    if (itemSub.HeadID == Convert.ToByte(ReferenceID[0]) && ((itemSub.RuleType == "Allowance" && Convert.ToByte(ReferenceID[1]) == 2) || (itemSub.RuleType == "Deduction" && Convert.ToByte(ReferenceID[1]) == 3)))
                                    {
                                        CalculateOnAmount = CalculateOnAmount + itemSub.Amount;
                                    }
                                }
                            }
                        }
                        amount = Math.Round(CalculateOnAmount * emp.Percentage / 100);

                    }
                    emp.Amount = amount;
                    AddCellToBodyWithLeftBorder(tableLayoutDeduction, emp.HeadName);
                    AddCellToBodyWithRightBorder(tableLayoutDeduction, Convert.ToString(emp.ActualAmount));

                    TotalDeduction = TotalDeduction + amount;
                    ActualTotalDeduction = ActualTotalDeduction + emp.ActualAmount;
                }
            }

            if (tableLayoutAllowance.Rows.Count > tableLayoutDeduction.Rows.Count)
            {
                var count = tableLayoutAllowance.Rows.Count - tableLayoutDeduction.Rows.Count;
                for (int i = 0; i < count; i++)
                {

                    tableLayoutDeduction.AddCell(new PdfPCell(new Phrase(" ", new Font(Font.FontFamily.HELVETICA, 8, 1, iTextSharp.text.BaseColor.BLACK)))
                    {
                        HorizontalAlignment = Element.ALIGN_LEFT,
                        Padding = 5,
                        //  BackgroundColor = new iTextSharp.text.BaseColor(212, 212, 212),
                        UseVariableBorders = true,
                        BorderColorRight = BaseColor.WHITE,
                        BorderColorTop = BaseColor.WHITE,
                        BorderColorBottom = BaseColor.WHITE,
                        VerticalAlignment = Element.ALIGN_MIDDLE
                    });
                    tableLayoutDeduction.AddCell(new PdfPCell(new Phrase(" ", new Font(Font.FontFamily.HELVETICA, 8, 1, iTextSharp.text.BaseColor.BLACK)))
                    {
                        HorizontalAlignment = Element.ALIGN_LEFT,
                        Padding = 5,
                        //  BackgroundColor = new iTextSharp.text.BaseColor(212, 212, 212),
                        UseVariableBorders = true,
                        BorderColorLeft = BaseColor.WHITE,
                        BorderColorTop = BaseColor.WHITE,
                        BorderColorBottom = BaseColor.WHITE,
                        VerticalAlignment = Element.ALIGN_MIDDLE
                    });



                }

            }
            else
            {
                var count = tableLayoutDeduction.Rows.Count - tableLayoutAllowance.Rows.Count;
                for (int i = 0; i < count; i++)
                {
                    tableLayoutAllowance.AddCell(new PdfPCell(new Phrase(" ", new Font(Font.FontFamily.HELVETICA, 8, 1, iTextSharp.text.BaseColor.BLACK)))
                    {
                        HorizontalAlignment = Element.ALIGN_LEFT,
                        Padding = 5,
                        //  BackgroundColor = new iTextSharp.text.BaseColor(212, 212, 212),
                        UseVariableBorders = true,
                        BorderColorRight = BaseColor.WHITE,
                        BorderColorTop = BaseColor.WHITE,
                        BorderColorBottom = BaseColor.WHITE,
                        VerticalAlignment = Element.ALIGN_MIDDLE
                    });
                    tableLayoutAllowance.AddCell(new PdfPCell(new Phrase(" ", new Font(Font.FontFamily.HELVETICA, 8, 1, iTextSharp.text.BaseColor.BLACK)))
                    {
                        HorizontalAlignment = Element.ALIGN_LEFT,
                        Padding = 5,
                        //  BackgroundColor = new iTextSharp.text.BaseColor(212, 212, 212),
                        UseVariableBorders = true,
                        BorderColorLeft = BaseColor.WHITE,
                        BorderColorRight = BaseColor.WHITE,
                        BorderColorTop = BaseColor.WHITE,
                        BorderColorBottom = BaseColor.WHITE,
                        VerticalAlignment = Element.ALIGN_MIDDLE
                    });


                    tableLayoutAllowance.AddCell(new PdfPCell(new Phrase(" ", new Font(Font.FontFamily.HELVETICA, 8, 1, iTextSharp.text.BaseColor.BLACK)))
                    {
                        HorizontalAlignment = Element.ALIGN_LEFT,
                        Padding = 5,
                        //  BackgroundColor = new iTextSharp.text.BaseColor(212, 212, 212),
                        UseVariableBorders = true,
                        BorderColorLeft = BaseColor.WHITE,
                        BorderColorTop = BaseColor.WHITE,
                        BorderColorBottom = BaseColor.WHITE,
                        VerticalAlignment = Element.ALIGN_MIDDLE
                    });


                    //AddCellToBodyWithLeftBorder(tableLayoutAllowance, "");
                    //AddCellToBodyWithNoBorder(tableLayoutAllowance, "");
                    //AddCellToBodyWithRightBorder(tableLayoutAllowance, "");
                }
            }
            tableLayoutAllowance.AddCell(new PdfPCell(new Phrase("Total Earnings", new Font(Font.FontFamily.HELVETICA, 8, 1, iTextSharp.text.BaseColor.BLACK)))
            {
                HorizontalAlignment = Element.ALIGN_LEFT,
                Padding = 5,
                // BackgroundColor = new iTextSharp.text.BaseColor(212, 212, 212),
                UseVariableBorders = true,
                BorderColorRight = BaseColor.WHITE,
                VerticalAlignment = Element.ALIGN_MIDDLE

            });
            tableLayoutAllowance.AddCell(new PdfPCell(new Phrase(Convert.ToString(TotalEarning), new Font(Font.FontFamily.HELVETICA, 8, 1, iTextSharp.text.BaseColor.BLACK)))
            {
                HorizontalAlignment = Element.ALIGN_LEFT,
                Padding = 5,
                //  BackgroundColor = new iTextSharp.text.BaseColor(212, 212, 212),
                UseVariableBorders = true,
                BorderColorRight = BaseColor.WHITE,
                BorderColorLeft = BaseColor.WHITE,
                VerticalAlignment = Element.ALIGN_MIDDLE

            });
            tableLayoutAllowance.AddCell(new PdfPCell(new Phrase(Convert.ToString(ActualTotalEarning), new Font(Font.FontFamily.HELVETICA, 8, 1, iTextSharp.text.BaseColor.BLACK)))
            {
                HorizontalAlignment = Element.ALIGN_LEFT,
                Padding = 5,
                // BackgroundColor = new iTextSharp.text.BaseColor(212, 212, 212),
                UseVariableBorders = true,
                BorderColorLeft = BaseColor.WHITE,
                VerticalAlignment = Element.ALIGN_MIDDLE

            });

            tableLayoutDeduction.AddCell(new PdfPCell(new Phrase("Total Deduction", new Font(Font.FontFamily.HELVETICA, 8, 1, iTextSharp.text.BaseColor.BLACK)))
            {
                HorizontalAlignment = Element.ALIGN_LEFT,
                Padding = 5,
                // BackgroundColor = new iTextSharp.text.BaseColor(212, 212, 212),
                UseVariableBorders = true,
                BorderColorRight = BaseColor.WHITE,
                VerticalAlignment = Element.ALIGN_MIDDLE

            });
            tableLayoutDeduction.AddCell(new PdfPCell(new Phrase(Convert.ToString(ActualTotalDeduction), new Font(Font.FontFamily.HELVETICA, 8, 1, iTextSharp.text.BaseColor.BLACK)))
            {
                HorizontalAlignment = Element.ALIGN_LEFT,
                Padding = 5,
                // BackgroundColor = new iTextSharp.text.BaseColor(212, 212, 212),
                UseVariableBorders = true,
                BorderColorLeft = BaseColor.WHITE,
                VerticalAlignment = Element.ALIGN_MIDDLE

            });


            tableLayoutAllowance.WriteSelectedRows(0, -1, doc.Left, doc.Top - tableLayoutEmpDetails.CalculateHeights() - tableLayoutHeader.CalculateHeights(), writer.DirectContent);

            tableLayoutDeduction.WriteSelectedRows(0, -1, doc.Left + 340, doc.Top - tableLayoutEmpDetails.CalculateHeights() - tableLayoutHeader.CalculateHeights(), writer.DirectContent);


            var AmountInWords = ConvertToWords(Convert.ToString(ActualTotalEarning - ActualTotalDeduction));
            AddCellToBodyWithLeftBorder(tableLayoutTakeHomeSal, "NetPay");
            AddCellToBodyWithNoBorder(tableLayoutTakeHomeSal, Convert.ToString(ActualTotalEarning - ActualTotalDeduction));
            AddCellToBodyWithNoBorder(tableLayoutTakeHomeSal, "EMI Recovered");
            AddCellToBodyWithRightBorder(tableLayoutTakeHomeSal, "0");

            AddCellToBodyWithLeftBorder(tableLayoutTakeHomeSal, "Take Home");
            AddCellToBodyWithNoBorder(tableLayoutTakeHomeSal, Convert.ToString(ActualTotalEarning - ActualTotalDeduction));
            tableLayoutTakeHomeSal.AddCell(new PdfPCell(new Phrase("Rupees " + AmountInWords, new Font(Font.FontFamily.HELVETICA, 8, 1, iTextSharp.text.BaseColor.BLACK)))
            {
                HorizontalAlignment = Element.ALIGN_LEFT,
                Padding = 5,
                Colspan = 2,
                //  BackgroundColor = new iTextSharp.text.BaseColor(255, 255, 255),
                UseVariableBorders = true,
                BorderColorTop = BaseColor.WHITE,
                BorderColorLeft = BaseColor.WHITE,
                BorderColorBottom = BaseColor.WHITE,
                VerticalAlignment = Element.ALIGN_MIDDLE

            });
            tableLayoutTakeHomeSal.WriteSelectedRows(0, -1, doc.Left, doc.Top - tableLayoutEmpDetails.CalculateHeights() - tableLayoutHeader.CalculateHeights() - tableLayoutAllowance.CalculateHeights(), writer.DirectContent);


            tableLayoutSigniture.AddCell(new PdfPCell(new Phrase("This is system generated report & signature is not required.", new Font(Font.FontFamily.HELVETICA, 8, 1, iTextSharp.text.BaseColor.BLACK)))
            {
                HorizontalAlignment = Element.ALIGN_CENTER,
                Padding = 5,
                Colspan = 2,
                //  BackgroundColor = new iTextSharp.text.BaseColor(255, 255, 255),
                UseVariableBorders = true,
                VerticalAlignment = Element.ALIGN_MIDDLE

            });
            tableLayoutSigniture.WriteSelectedRows(0, -1, doc.Left, doc.Top - tableLayoutEmpDetails.CalculateHeights() - tableLayoutHeader.CalculateHeights() - tableLayoutAllowance.CalculateHeights() - tableLayoutTakeHomeSal.CalculateHeights(), writer.DirectContent);


            // Closing the document  
            doc.Close();
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;" + "filename=" + model.EmployeeSalaryTransactionList[0].EmployeeName + " " + model.EmployeeSalaryTransactionList[0].SaleContractBillingSpanName + ".pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Write(doc);
            Response.End();


        }

        // Method to add single cell to the Header  
        private static void AddCellToHeader(PdfPTable tableLayout, string cellText)
        {

            tableLayout.AddCell(new PdfPCell(new Phrase(cellText, new Font(Font.FontFamily.HELVETICA, 8, 1, iTextSharp.text.BaseColor.YELLOW)))
            {
                HorizontalAlignment = Element.ALIGN_LEFT,
                Padding = 5,
                BackgroundColor = new iTextSharp.text.BaseColor(128, 0, 0)
            });
        }

        // Method to add single cell to the body  
        private static void AddCellToBody(PdfPTable tableLayout, string cellText)
        {
            tableLayout.AddCell(new PdfPCell(new Phrase(cellText, new Font(Font.FontFamily.HELVETICA, 8, 1, iTextSharp.text.BaseColor.BLACK)))
            {
                HorizontalAlignment = Element.ALIGN_LEFT,
                Padding = 5,
                BackgroundColor = new iTextSharp.text.BaseColor(255, 255, 255)
            });
        }

        // Method to add single cell to the body with left Border  
        private static void AddCellToBodyWithLeftBorder(PdfPTable tableLayout, string cellText)
        {
            tableLayout.AddCell(new PdfPCell(new Phrase(cellText, new Font(Font.FontFamily.HELVETICA, 8, 1, iTextSharp.text.BaseColor.BLACK)))
            {
                HorizontalAlignment = Element.ALIGN_LEFT,
                Padding = 5,
                BackgroundColor = new iTextSharp.text.BaseColor(255, 255, 255),
                UseVariableBorders = true,
                BorderColorRight = BaseColor.WHITE,
                BorderColorTop = BaseColor.WHITE,
                BorderColorBottom = BaseColor.WHITE,
                VerticalAlignment = Element.ALIGN_MIDDLE

            });
        }
        // Method to add single cell to the body with Right Border
        private static void AddCellToBodyWithRightBorder(PdfPTable tableLayout, string cellText)
        {
            tableLayout.AddCell(new PdfPCell(new Phrase(cellText, new Font(Font.FontFamily.HELVETICA, 8, 1, iTextSharp.text.BaseColor.BLACK)))
            {
                HorizontalAlignment = Element.ALIGN_LEFT,
                Padding = 5,
                BackgroundColor = new iTextSharp.text.BaseColor(255, 255, 255),
                UseVariableBorders = true,
                BorderColorLeft = BaseColor.WHITE,
                BorderColorTop = BaseColor.WHITE,
                BorderColorBottom = BaseColor.WHITE,
                VerticalAlignment = Element.ALIGN_MIDDLE
            });
        }
        // Method to add single cell to the body with no Border
        private static void AddCellToBodyWithNoBorder(PdfPTable tableLayout, string cellText)
        {
            tableLayout.AddCell(new PdfPCell(new Phrase(cellText, new Font(Font.FontFamily.HELVETICA, 8, 1, iTextSharp.text.BaseColor.BLACK)))
            {
                HorizontalAlignment = Element.ALIGN_LEFT,
                Padding = 5,
                BackgroundColor = new iTextSharp.text.BaseColor(255, 255, 255),
                Border = 0,
                VerticalAlignment = Element.ALIGN_MIDDLE
            });
        }

        [HttpGet]
        public ActionResult DownloadSalarySheet(string CentreCode, string DepartmentID, string SpanID)
        {
            string FileName = "EmployeeSalaryExcelSheet_"+CentreCode+ ".xlsx";
            string filePath = Path.Combine(Server.MapPath("~") + "Content\\DownloadFiles\\", FileName);
            System.IO.File.Delete(filePath);
            CreateSaleContractEmployeeExcel(filePath);
         //   InsertSaleContractEmployeeExcel(filePath);
            int val = InsertEmployeeExcel(filePath, CentreCode, DepartmentID, SpanID);
            string contentType = "application/vnd.ms-excel";
            if(val == -1)
                return RedirectToAction("Index", "EmployeeSalaryTransaction");
            else
                 return File(filePath, contentType, FileName);
        }


        public static void InsertTextInExcel(string docName, string text, string Columns, uint rowID,bool isNumber)
        {
            // Open the document for editing.
            using (SpreadsheetDocument spreadSheet = SpreadsheetDocument.Open(docName, true))
            {
                // Get the SharedStringTablePart. If it does not exist, create a new one.
                SharedStringTablePart shareStringPart;
                if (spreadSheet.WorkbookPart.GetPartsOfType<SharedStringTablePart>().Count() > 0)
                {
                    shareStringPart = spreadSheet.WorkbookPart.GetPartsOfType<SharedStringTablePart>().First();
                }
                else
                {
                    shareStringPart = spreadSheet.WorkbookPart.AddNewPart<SharedStringTablePart>();
                }

                // Insert the text into the SharedStringTablePart.
                int index = InsertSharedStringItem(text, shareStringPart);

                // Insert a new worksheet.
                //WorksheetPart worksheetPart = InsertWorksheet(spreadSheet.WorkbookPart);

                DocumentFormat.OpenXml.Spreadsheet.Sheet sheet = spreadSheet.WorkbookPart.Workbook.Sheets.GetFirstChild<DocumentFormat.OpenXml.Spreadsheet.Sheet>();

                //Get the Worksheet instance.
                WorksheetPart worksheetPart = spreadSheet.WorkbookPart.GetPartById(sheet.Id.Value) as WorksheetPart;

                // Insert cell A1 into the new worksheet.
                DocumentFormat.OpenXml.Spreadsheet.Cell cell = InsertCellInWorksheet(Columns, rowID, worksheetPart);

                // Set the value of cell A1.
                cell.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue(index.ToString());

                if (isNumber)
                {
                    cell.StyleIndex = 7;
                    cell.DataType = new EnumValue<DocumentFormat.OpenXml.Spreadsheet.CellValues>(DocumentFormat.OpenXml.Spreadsheet.CellValues.Number);
                    cell.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue(text);
                }
                else
                {
                    cell.DataType = new EnumValue<DocumentFormat.OpenXml.Spreadsheet.CellValues>(DocumentFormat.OpenXml.Spreadsheet.CellValues.SharedString);
                }


                if (cell.CellReference.Value == "A1" || cell.CellReference.Value == "B1" || cell.CellReference.Value == "C1" || cell.CellReference.Value == "D1" || cell.CellReference.Value == "E1" || cell.CellReference.Value == "F1" || cell.CellReference.Value == "G1" || cell.CellReference.Value == "H1" || cell.CellReference.Value == "I1" || cell.CellReference.Value == "J1" || cell.CellReference.Value == "K1" || cell.CellReference.Value == "L1" || cell.CellReference.Value == "M1" || cell.CellReference.Value == "N1" || cell.CellReference.Value == "O1" || cell.CellReference.Value == "P1" || cell.CellReference.Value == "Q1" || cell.CellReference.Value == "R1" || cell.CellReference.Value == "S1" || cell.CellReference.Value == "T1" || cell.CellReference.Value == "U1" || cell.CellReference.Value == "V1" || cell.CellReference.Value == "W1" || cell.CellReference.Value == "X1" || cell.CellReference.Value == "Y1" || cell.CellReference.Value == "Z1"|| cell.CellReference.Value == "AA1"|| cell.CellReference.Value == "AB1"|| cell.CellReference.Value == "AC1"|| cell.CellReference.Value == "AD1"|| cell.CellReference.Value == "AE1"|| cell.CellReference.Value == "AF1"|| cell.CellReference.Value == "AG1"|| cell.CellReference.Value == "AH1"|| cell.CellReference.Value == "AI1")
                {
                    cell.StyleIndex = 5;
                }


                // Save the new worksheet.
                worksheetPart.Worksheet.Save();
            }
        }


        public static void InsertTextInExcel(string docName, string text, string Columns, uint rowID)
        {
            // Open the document for editing.
            using (SpreadsheetDocument spreadSheet = SpreadsheetDocument.Open(docName, true))
            {
                // Get the SharedStringTablePart. If it does not exist, create a new one.
                SharedStringTablePart shareStringPart;
                if (spreadSheet.WorkbookPart.GetPartsOfType<SharedStringTablePart>().Count() > 0)
                {
                    shareStringPart = spreadSheet.WorkbookPart.GetPartsOfType<SharedStringTablePart>().First();
                }
                else
                {
                    shareStringPart = spreadSheet.WorkbookPart.AddNewPart<SharedStringTablePart>();
                }

                // Insert the text into the SharedStringTablePart.
                int index = InsertSharedStringItem(text, shareStringPart);

                // Insert a new worksheet.
                //WorksheetPart worksheetPart = InsertWorksheet(spreadSheet.WorkbookPart);

                DocumentFormat.OpenXml.Spreadsheet.Sheet sheet = spreadSheet.WorkbookPart.Workbook.Sheets.GetFirstChild<DocumentFormat.OpenXml.Spreadsheet.Sheet>();

                //Get the Worksheet instance.
                WorksheetPart worksheetPart = spreadSheet.WorkbookPart.GetPartById(sheet.Id.Value) as WorksheetPart;

                // Insert cell A1 into the new worksheet.
                DocumentFormat.OpenXml.Spreadsheet.Cell cell = InsertCellInWorksheet(Columns, rowID, worksheetPart);

                // Set the value of cell A1.

                cell.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue(index.ToString());
                cell.DataType = new EnumValue<DocumentFormat.OpenXml.Spreadsheet.CellValues>(DocumentFormat.OpenXml.Spreadsheet.CellValues.SharedString);

                if (cell.CellReference.Value == "A1" || cell.CellReference.Value == "B1" || cell.CellReference.Value == "C1" || cell.CellReference.Value == "D1" || cell.CellReference.Value == "E1" || cell.CellReference.Value == "F1" || cell.CellReference.Value == "G1" || cell.CellReference.Value == "H1" || cell.CellReference.Value == "I1" || cell.CellReference.Value == "J1" || cell.CellReference.Value == "K1" || cell.CellReference.Value == "L1" || cell.CellReference.Value == "M1" || cell.CellReference.Value == "N1" || cell.CellReference.Value == "O1" || cell.CellReference.Value == "P1" || cell.CellReference.Value == "Q1" || cell.CellReference.Value == "R1" || cell.CellReference.Value == "S1" || cell.CellReference.Value == "T1" || cell.CellReference.Value == "U1" || cell.CellReference.Value == "V1" || cell.CellReference.Value == "W1" || cell.CellReference.Value == "X1" || cell.CellReference.Value == "Y1" || cell.CellReference.Value == "Z1" || cell.CellReference.Value == "AA1" || cell.CellReference.Value == "AB1" || cell.CellReference.Value == "AC1" || cell.CellReference.Value == "AD1" || cell.CellReference.Value == "AE1" || cell.CellReference.Value == "AF1" || cell.CellReference.Value == "AG1" || cell.CellReference.Value == "AH1" || cell.CellReference.Value == "AI1")
                {
                    cell.StyleIndex = 5;
                }
              

                // Save the new worksheet.
                worksheetPart.Worksheet.Save();
            }
        }

        public int InsertEmployeeExcel(string fileName, string CentreCode, string DepartmentID, string SpanID)
        {
            
            string[] ColumnsData = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q","R","S","T","U","V","W","X","Y","Z","AA", "AB", "AC", "AD", "AE", "AF", "AG", "AH", "AI", "AJ", "AK", "AL", "AM", "AN", "AO", "AP", "AQ", "AR", "AS", "AT", "AU", "AV", "AW", "AX", "AY", "AZ" };

            EmployeeSalaryTransactionViewModel model = new EmployeeSalaryTransactionViewModel();

            model.EmployeeSalaryTransactionDTO = new EmployeeSalaryTransaction();
            model.EmployeeSalaryTransactionDTO.CentreCode = CentreCode;
            model.EmployeeSalaryTransactionDTO.DepartmentMasterID = Convert.ToInt32(DepartmentID);
            model.EmployeeSalaryTransactionDTO.EmployeeSalarySpanID = Convert.ToInt16(SpanID);
            model.EmployeeSalaryTransactionDTO.ConnectionString = _connectioString;
            model.EmployeeSalaryTransactionList = GetSalaryTransactionDetails(CentreCode, DepartmentID, SpanID);
            if (model.EmployeeSalaryTransactionList.Count > 0)
            {
                string[] EmployeeIDList = model.EmployeeSalaryTransactionList[0].SaleContractEmployeeMasterIDList.Replace(", ", ",").Split(new char[] { ',' });
                int index = 0;
                string[] Headers = new string[50];

                Headers[index++] = "Sr.No";
                Headers[index++] = "Employee ID No.";
                Headers[index++] = "Particulars";
                Headers[index++] = "A/C Number";
                Headers[index++] = "PF Number";
                Headers[index++] = "ESIC Number";
                Headers[index++] = "UAN Number";
                Headers[index++] = "Designation";
                Headers[index++] = "Department";
                Headers[index++] = "Working Days";
                Headers[index++] = "Present Days";

                foreach (var item in model.EmployeeSalaryTransactionList)
                {
                    if (Convert.ToInt32(EmployeeIDList[0]) == item.EmployeeMasterID && item.HeadType == "OT")
                    {
                        Headers[index++] = "Over Time";
                    }
                }
                Headers[index++] = "Basic";

                foreach (var item in model.EmployeeSalaryTransactionList)
                {
                    if (Convert.ToInt32(EmployeeIDList[0]) == item.EmployeeMasterID && item.IsAllowance == true && item.HeadType == "DA")
                    {
                        Headers[index++] = "Dearness Allowance";
                        Headers[index++] = "Total Amount";
                    }
                }

                foreach (var item in model.EmployeeSalaryTransactionList)
                {
                    if (Convert.ToInt32(EmployeeIDList[0]) == item.EmployeeMasterID && item.IsAllowance == true && item.HeadType != "DA" && item.HeadType != "RIA" && item.HeadType != "OT" && ((item.HeadType == "AddA" && item.ComplianceType == 1) || (item.HeadType != "AddA")))
                    {
                        bool IsGrossAllowance = false;
                        foreach (var checkitem in model.EmployeeSalaryTransactionList)
                        {
                            if (Convert.ToInt32(EmployeeIDList[0]) == checkitem.EmployeeMasterID && checkitem.RuleType == "Deduction" && checkitem.ContributionType == 1 && checkitem.HeadType == "ESIC" && checkitem.ComplianceType == 1)
                            {
                                var CalculateOnValue = checkitem.CalculateOnString.Replace(", ", ",").Split(',');
                                foreach (var CalOn in CalculateOnValue)
                                {
                                    var ReferenceID = CalOn.Split('~');

                                    if (ReferenceID.Length > 1)
                                    {
                                        if (item.HeadID == Convert.ToByte(ReferenceID[0]))
                                        {
                                            IsGrossAllowance = true;
                                        }
                                    }
                                    else
                                    {
                                        IsGrossAllowance = true;
                                    }
                                }
                            }
                        }

                        if (IsGrossAllowance == true)
                        {
                            Headers[index++] = item.HeadName;
                        }
                    }
                }

               
                

                foreach (var item in model.EmployeeSalaryTransactionList)
                {
                    if (Convert.ToInt32(EmployeeIDList[0]) == item.EmployeeMasterID && item.IsAllowance == true && item.HeadType != "DA" && item.HeadType != "RIA" && item.HeadType != "OT" && ((item.HeadType == "AddA" && item.ComplianceType == 1) || (item.HeadType != "AddA")))
                    {
                        bool IsGrossAllowance = false;
                        foreach (var checkitem in model.EmployeeSalaryTransactionList)
                        {
                            if (Convert.ToInt32(EmployeeIDList[0]) == checkitem.EmployeeMasterID && checkitem.RuleType == "Deduction" && checkitem.ContributionType == 1 && checkitem.HeadType == "ESIC" && checkitem.ComplianceType == 1)
                            {
                                var CalculateOnValue = checkitem.CalculateOnString.Replace(", ", ",").Split(',');
                                foreach (var CalOn in CalculateOnValue)
                                {
                                    var ReferenceID = CalOn.Split('~');

                                    if (ReferenceID.Length > 1)
                                    {
                                        if (item.HeadID == Convert.ToByte(ReferenceID[0]))
                                        {
                                            IsGrossAllowance = true;
                                        }
                                    }
                                    else
                                    {
                                        IsGrossAllowance = true;
                                    }
                                }
                            }
                        }

                        if (IsGrossAllowance == false)
                        {
                            Headers[index++] = item.HeadName;
                        }
                    }
                }

                foreach (var item in model.EmployeeSalaryTransactionList)
                {
                    if (Convert.ToInt32(EmployeeIDList[0]) == item.EmployeeMasterID && item.IsAllowance == true && item.HeadType != "DA" && item.HeadType != "RIA" && item.HeadType != "OT" && ((item.HeadType == "AddA" && item.ComplianceType == 1) || (item.HeadType != "AddA")))
                    {
                        bool IsGrossAllowance = false;
                        foreach (var checkitem in model.EmployeeSalaryTransactionList)
                        {
                            if (Convert.ToInt32(EmployeeIDList[0]) == checkitem.EmployeeMasterID && checkitem.RuleType == "Deduction" && checkitem.ContributionType == 1 && checkitem.HeadType == "ESIC" && checkitem.ComplianceType == 1)
                            {
                                var CalculateOnValue = checkitem.CalculateOnString.Replace(", ", ",").Split(',');
                                foreach (var CalOn in CalculateOnValue)
                                {
                                    var ReferenceID = CalOn.Split('~');

                                    if (ReferenceID.Length > 1)
                                    {
                                        if (item.HeadID == Convert.ToByte(ReferenceID[0]))
                                        {
                                            IsGrossAllowance = true;
                                        }
                                    }
                                    else
                                    {
                                        IsGrossAllowance = true;
                                    }
                                }
                            }
                        }

                        if (IsGrossAllowance == true)
                        {
                            Headers[index++] = "Gross";
                            break;
                        }
                    }
                }
                foreach (var item in model.EmployeeSalaryTransactionList)
                {
                    if (Convert.ToInt32(EmployeeIDList[0]) == item.EmployeeMasterID && item.IsAllowance == true && (item.HeadType == "OT" || (item.HeadType == "AddA" && item.ComplianceType == 2)))
                    {
                        Headers[index++] = item.HeadName;
                    }
                }
                Headers[index++] = "Total Earnings";
                foreach (var item in model.EmployeeSalaryTransactionList)
                {
                    if (Convert.ToInt32(EmployeeIDList[0]) == item.EmployeeMasterID && item.IsAllowance == false)
                    {
                        Headers[index++] = item.HeadName;
                    }
                }
                Headers[index++] = "Total Deduction";
                Headers[index++] = "Net Amount";
                foreach (var item in model.EmployeeSalaryTransactionList)
                {
                    if (Convert.ToInt32(EmployeeIDList[0]) == item.EmployeeMasterID && item.IsAllowance == true && item.HeadType == "RIA")
                    {
                        Headers[index++] = item.HeadName;
                        Headers[index++] = "Total Incl. Amount";
                    }
                }
                string[] Columns = new string[50];// { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q" };

                for (uint i = 0; i < index; i++)
                {
                    Columns[i] = ColumnsData[i];
                }
                for (uint i = 0; i < index; i++)
                {
                    InsertTextInExcel(fileName, Headers[i], Columns[i], 1);
                }

                for (int j = 0; j < EmployeeIDList.Length; j++)
                {
                    string[] HeaderData = new string[50];
                    int IndexData = 0;
                   // HeaderData[IndexData++] = (j + 1).ToString();
                    InsertTextInExcel(fileName, (j + 1).ToString(), (IndexData++).ToString(), (uint)j + 3,true);

                    foreach (var item in model.EmployeeSalaryTransactionList)
                    {

                        if (Convert.ToInt32(EmployeeIDList[j]) == item.EmployeeMasterID)
                        {
                            //HeaderData[IndexData++] = item.EmployeeName;
                            InsertTextInExcel(fileName, item.EmployeeCode, (IndexData++).ToString(), (uint)j + 3, false);
                            InsertTextInExcel(fileName, item.EmployeeName, (IndexData++).ToString(), (uint)j + 3,false);
                            InsertTextInExcel(fileName, item.BankACNumber, (IndexData++).ToString(), (uint)j + 3, false);
                            InsertTextInExcel(fileName, item.ProvidentFundNumber, (IndexData++).ToString(), (uint)j + 3, false);
                            InsertTextInExcel(fileName, item.ESINumber, (IndexData++).ToString(), (uint)j + 3, false);
                            InsertTextInExcel(fileName, item.UANNumber, (IndexData++).ToString(), (uint)j + 3, false);
                            InsertTextInExcel(fileName, item.DesignationName, (IndexData++).ToString(), (uint)j + 3, false);
                            InsertTextInExcel(fileName, item.DepartmentName, (IndexData++).ToString(), (uint)j + 3, false);

                            //HeaderData[IndexData++] = Convert.ToString(item.TotalDays);
                            InsertTextInExcel(fileName, Convert.ToString(item.TotalDays), (IndexData++).ToString(), (uint)j + 3,true);

                            //HeaderData[IndexData++] = Convert.ToString(item.TotalAttendance);
                            InsertTextInExcel(fileName, Convert.ToString(item.TotalAttendance), (IndexData++).ToString(), (uint)j + 3,true);

                            decimal BasicAmount = Math.Round(item.BasicAmount);
                           // HeaderData[IndexData++] = Convert.ToString(BasicAmount);
                            InsertTextInExcel(fileName, Convert.ToString(BasicAmount), (IndexData++).ToString(), (uint)j + 3,true);

                            decimal TotalAttendance = item.TotalAttendance;
                            byte TotalDays = item.TotalDays;
                            break;
                        }
                    }
                    foreach (var item in model.EmployeeSalaryTransactionList)
                    {
                        if (Convert.ToInt32(EmployeeIDList[j]) == item.EmployeeMasterID && item.IsAllowance == true && item.HeadType == "DA")
                        {
                            //HeaderData[IndexData++] = Convert.ToString(item.Amount);
                            InsertTextInExcel(fileName, Convert.ToString(item.Amount), (IndexData++).ToString(), (uint)j + 3,true);

                            //HeaderData[IndexData++] = Convert.ToString(item.TotalAmount);
                            InsertTextInExcel(fileName, Convert.ToString(item.TotalAmount), (IndexData++).ToString(), (uint)j + 3,true);

                        }
                    }
                    decimal other = 0;
                    foreach (var item in model.EmployeeSalaryTransactionList)
                    {
                        if (Convert.ToInt32(EmployeeIDList[j]) == item.EmployeeMasterID && item.IsAllowance == true && item.HeadType != "DA" && item.HeadType != "RIA" && item.HeadType != "OT" && ((item.HeadType == "AddA" && item.ComplianceType == 1) || (item.HeadType != "AddA")))
                        {
                            bool IsGrossAllowance = false;
                            foreach (var checkitem in model.EmployeeSalaryTransactionList)
                            {
                                /* if (Convert.ToInt32(EmployeeIDList[j]) == checkitem.EmployeeMasterID && checkitem.RuleType == "Deduction" && checkitem.ContributionType == 1 && checkitem.HeadType == "ESIC" && checkitem.ComplianceType == 1)
                                 {

                                     var CalculateOnValue = checkitem.CalculateOnString.Replace(", ", ",").Split(',');
                                     foreach (var CalOn in CalculateOnValue)
                                     {
                                         var ReferenceID = CalOn.Split('~');

                                         if (ReferenceID.Length > 1)
                                         {
                                             if (item.HeadID == Convert.ToByte(ReferenceID[0]))
                                             {
                                                 IsGrossAllowance = true;
                                             }
                                         }
                                         else
                                         {
                                             IsGrossAllowance = true;
                                         }
                                     }/*
                                 }*/
                            }

                           // if (IsGrossAllowance == true)
                            {
                               // HeaderData[IndexData++] = Convert.ToString(item.Amount);
                                InsertTextInExcel(fileName, Convert.ToString(item.Amount), (IndexData++).ToString(), (uint)j + 3,true);

                                if (item.ComplianceType != 1 && item.HeadType == "Other")
                                {
                                    other = other + item.Amount;
                                }

                            }
                        }
                    }

                    foreach (var item in model.EmployeeSalaryTransactionList)
                    {
                        if (Convert.ToInt32(EmployeeIDList[j]) == item.EmployeeMasterID && item.IsAllowance == true && item.HeadType != "DA" && item.HeadType != "RIA" && item.HeadType != "OT" && ((item.HeadType == "AddA" && item.ComplianceType == 1) || (item.HeadType != "AddA")))
                        {
                            bool IsGrossAllowance = false;
                            foreach (var checkitem in model.EmployeeSalaryTransactionList)
                            {
                                if (Convert.ToInt32(EmployeeIDList[j]) == checkitem.EmployeeMasterID && checkitem.RuleType == "Deduction" && checkitem.ContributionType == 1 && checkitem.HeadType == "ESIC" && checkitem.ComplianceType == 1)
                                {
                                    InsertTextInExcel(fileName, Convert.ToString(item.TotalSalary), (IndexData++).ToString(), (uint)j + 3,true);

                                   // HeaderData[IndexData++] = Convert.ToString(item.TotalSalary);
                                    IsGrossAllowance = true;
                                    break;
                                }
                            }
                            if (IsGrossAllowance)
                                break;
                        }
                    }


                    foreach (var item in model.EmployeeSalaryTransactionList)
                    {
                        if (Convert.ToInt32(EmployeeIDList[j]) == item.EmployeeMasterID && item.IsAllowance == true && (item.HeadType == "OT" || (item.HeadType == "AddA" && item.ComplianceType == 2)))
                        {
                            //HeaderData[IndexData++] = Convert.ToString(item.Amount)
                            InsertTextInExcel(fileName, Convert.ToString(item.Amount), (IndexData++).ToString(), (uint)j + 3,true);

                        }
                    }
                    decimal TotalAmpount = 0;
                    foreach (var item in model.EmployeeSalaryTransactionList)
                    {
                        if (Convert.ToInt32(EmployeeIDList[j]) == item.EmployeeMasterID)
                        {
                          //  HeaderData[IndexData++] = Convert.ToString(item.TotalSalary);
                            InsertTextInExcel(fileName, Convert.ToString(item.TotalSalary), (IndexData++).ToString(), (uint)j + 3,true);

                            TotalAmpount = item.TotalSalary;
                            break;
                        }
                    }
                    decimal TotalDeduction = 0, NetPayable = 0;
                    foreach (var item in model.EmployeeSalaryTransactionList)
                    {
                        if (Convert.ToInt32(EmployeeIDList[j]) == item.EmployeeMasterID && item.IsAllowance == false)
                        {
                           // HeaderData[IndexData++] = Convert.ToString(item.Amount);
                            InsertTextInExcel(fileName, Convert.ToString(item.Amount), (IndexData++).ToString(), (uint)j + 3,true);

                            TotalDeduction = TotalDeduction + item.Amount;
                        }
                    }

                  //  HeaderData[IndexData++] = Convert.ToString(TotalDeduction);
                    InsertTextInExcel(fileName, Convert.ToString(TotalDeduction), (IndexData++).ToString(), (uint)j + 3,true);

                    NetPayable = TotalAmpount - TotalDeduction;
                  //  HeaderData[IndexData++] = Convert.ToString(NetPayable);
                    InsertTextInExcel(fileName, Convert.ToString(NetPayable), (IndexData++).ToString(), (uint)j + 3,true);

                    decimal totalInc = NetPayable;
                    bool isRIA = false;
                    foreach (var item in model.EmployeeSalaryTransactionList)
                    {
                        if (Convert.ToInt32(EmployeeIDList[j]) == item.EmployeeMasterID && item.IsAllowance == true && item.HeadType == "RIA")
                        {
                           // HeaderData[IndexData++] = Convert.ToString(item.Amount);
                            InsertTextInExcel(fileName, Convert.ToString(item.Amount), (IndexData++).ToString(), (uint)j + 3,true);
                            isRIA = true;
                            totalInc = totalInc + item.Amount;
                        }
                    }
                    if(isRIA)
                        InsertTextInExcel(fileName, Convert.ToString(totalInc), (IndexData++).ToString(), (uint)j + 3, true);
                   // HeaderData[IndexData++] = Convert.ToString(totalInc);

                    for (uint j1 = 0; j1 < IndexData; j1++)
                    {
                      //  InsertTextInExcel(fileName, HeaderData[j1], Columns[j1], (uint)j + 3);
                    }
                }
            }
            else
            {
                TempData["_errorMsg"] = "Record Not Found for Selected Salary.";
                return -1; 
            }
            return 1;
        }

        public void CreateSaleContractEmployeeExcel(string fileName)
        {
            using (SpreadsheetDocument document = SpreadsheetDocument.Create(fileName, SpreadsheetDocumentType.Workbook))
            {
                WorkbookPart workbookPart = document.AddWorkbookPart();
                workbookPart.Workbook = new DocumentFormat.OpenXml.Spreadsheet.Workbook();

                WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                worksheetPart.Worksheet = new DocumentFormat.OpenXml.Spreadsheet.Worksheet(new DocumentFormat.OpenXml.Spreadsheet.SheetData());

                DocumentFormat.OpenXml.Spreadsheet.Sheets sheets = workbookPart.Workbook.AppendChild(new DocumentFormat.OpenXml.Spreadsheet.Sheets());

                DocumentFormat.OpenXml.Spreadsheet.Sheet sheet = new DocumentFormat.OpenXml.Spreadsheet.Sheet() { Id = workbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = "Employee Salary Excel Sheet" };

                EmployeeSalaryTransactionViewModel model = new EmployeeSalaryTransactionViewModel();
                model.EmployeeSalaryTransactionDTO.ConnectionString = _connectioString;
                model.EmployeeSalaryTransactionDTO.ExcelSheetName = "EmployeeSalaryExcelSheet";

                /*
                 IBaseEntityResponse<SaleContractEmployeeMaster> response = _SaleContractEmployeeMasterBA.GetDataValidationListsForEmployeeMasterExcel(model.SaleContractEmployeeMasterDTO);
                 if (response != null && response.Entity != null)
                 {
                     model.SaleContractEmployeeMasterDTO.Title = response.Entity.Title;
                     model.SaleContractEmployeeMasterDTO.ESICZoneCode = response.Entity.ESICZoneCode;
                     model.SaleContractEmployeeMasterDTO.CentreCode = response.Entity.CentreCode;

                 }

                DataValidation dataValidation = new DataValidation();
                 {
                     Type = DataValidationValues.List,
                     AllowBlank = true,
                     SequenceOfReferences = new ListValue<StringValue>() { InnerText = "A3:A100" },
                     Formula1 = new Formula1(string.Concat("\"", model.SaleContractEmployeeMasterDTO.Title, "\"")),
                     ShowErrorMessage = true,
                     ErrorStyle = DataValidationErrorStyleValues.Stop,
                     ErrorTitle = new StringValue("Incorrect Value"),
                     Error = new StringValue("Please select value from list.")
                 };

                DataValidations dvs = worksheetPart.Worksheet.GetFirstChild<DataValidations>(); //worksheet type => Worksheet
                if (dvs != null)
                {
                    dvs.Count = dvs.Count + 1;
                    dvs.Append(dataValidation);
                }
                else
                {
                    DataValidations newDVs = new DataValidations();
                    newDVs.Append(dataValidation);
                    newDVs.Count = 1;
                    worksheetPart.Worksheet.Append(newDVs);
                }

                DataValidation dataValidation1 = new DataValidation();
                {
                    Type = DataValidationValues.List,
                    AllowBlank = true,
                    SequenceOfReferences = new ListValue<StringValue>() { InnerText = "M3:M100" },
                    Formula1 = new Formula1(string.Concat("\"", model.SaleContractEmployeeMasterDTO.ESICZoneCode, "\"")),
                    ShowErrorMessage = true,
                    ErrorStyle = DataValidationErrorStyleValues.Stop,
                    ErrorTitle = new StringValue("Incorrect Value"),
                    Error = new StringValue("Please select value from list.")
                };
                DataValidations dvs1 = worksheetPart.Worksheet.GetFirstChild<DataValidations>(); //worksheet type => Worksheet
                if (dvs1 != null)
                {
                    dvs1.Count = dvs1.Count + 1;
                    dvs1.Append(dataValidation1);
                }
                else
                {
                    DataValidations newDVs1 = new DataValidations();
                    newDVs1.Append(dataValidation1);
                    newDVs1.Count = 1;
                    worksheetPart.Worksheet.Append(newDVs1);
                }
                DataValidation dataValidation2 = new DataValidation();
               
                {
                    Type = DataValidationValues.List,
                    AllowBlank = true,
                    SequenceOfReferences = new ListValue<StringValue>() { InnerText = "P3:P500" },
                    Formula1 = new Formula1(string.Concat("\"", model.SaleContractEmployeeMasterDTO.CentreCode, "\"")),
                    ShowErrorMessage = true,
                    ErrorStyle = DataValidationErrorStyleValues.Stop,
                    ErrorTitle = new StringValue("Incorrect Value"),
                    Error = new StringValue("Please select value from list.")
                };
                DataValidations dvs2 = worksheetPart.Worksheet.GetFirstChild<DataValidations>(); //worksheet type => Worksheet
                if (dvs2 != null)
                {
                    dvs2.Count = dvs2.Count + 1;
                    dvs2.Append(dataValidation2);
                }
                else
                {
                    DataValidations newDVs2 = new DataValidations();
                    newDVs2.Append(dataValidation2);
                    newDVs2.Count = 1;
                    worksheetPart.Worksheet.Append(newDVs2);
                }
                DataValidation dataValidation3 = new DataValidation();
                
               {
                    Type = DataValidationValues.List,
                    AllowBlank = true,
                    SequenceOfReferences = new ListValue<StringValue>() { InnerText = "Q3:Q500" },
                    Formula1 = new Formula1(string.Concat("\"M,F\"")),
                    ShowErrorMessage = true,
                    ErrorStyle = DataValidationErrorStyleValues.Stop,
                    ErrorTitle = new StringValue("Incorrect Value"),
                    Error = new StringValue("Please select value from list.")
                };
                DataValidations dvs3 = worksheetPart.Worksheet.GetFirstChild<DataValidations>(); //worksheet type => Worksheet
                if (dvs3 != null)
                {
                    dvs3.Count = dvs3.Count + 1;
                    dvs3.Append(dataValidation3);
                }
                else
                {
                    DataValidations newDVs3 = new DataValidations();
                    newDVs3.Append(dataValidation3);
                    newDVs3.Count = 1;
                    worksheetPart.Worksheet.Append(newDVs3);
                }
                */
                sheets.Append(sheet);

                WorkbookStylesPart stylesPart = workbookPart.AddNewPart<WorkbookStylesPart>();
                stylesPart.Stylesheet = GenerateStyleSheet();
                stylesPart.Stylesheet.Save();

                workbookPart.Workbook.Save();
                document.Close();
            }
        }

        private DocumentFormat.OpenXml.Spreadsheet.Stylesheet GenerateStyleSheet()
        {
            DocumentFormat.OpenXml.Spreadsheet.NumberingFormat nf2decimal = new DocumentFormat.OpenXml.Spreadsheet.NumberingFormat();
            nf2decimal.NumberFormatId = UInt32Value.FromUInt32(3453);
            nf2decimal.FormatCode = StringValue.FromString("0.0%");

            return new DocumentFormat.OpenXml.Spreadsheet.Stylesheet(
                new DocumentFormat.OpenXml.Spreadsheet.Fonts(
                    new DocumentFormat.OpenXml.Spreadsheet.Font(                                                               // Index 0 – The default font.
                        new DocumentFormat.OpenXml.Spreadsheet.FontSize() { Val = 11 },
                        new DocumentFormat.OpenXml.Spreadsheet.Color() { Rgb = new HexBinaryValue() { Value = "000000" } },
                        new DocumentFormat.OpenXml.Spreadsheet.FontName() { Val = "Calibri" }),

                    new DocumentFormat.OpenXml.Spreadsheet.Font(                                                               // Index 1 – The bold font.
                        new DocumentFormat.OpenXml.Spreadsheet.Bold(),
                        new DocumentFormat.OpenXml.Spreadsheet.FontSize() { Val = 11 },
                        new DocumentFormat.OpenXml.Spreadsheet.Color() { Rgb = new HexBinaryValue() { Value = "ffffff" } },
                        new DocumentFormat.OpenXml.Spreadsheet.FontName() { Val = "Calibri" }),
                    new DocumentFormat.OpenXml.Spreadsheet.Font(                                                               // Index 2 – The Italic font.
                        new DocumentFormat.OpenXml.Spreadsheet.Italic(),
                        new DocumentFormat.OpenXml.Spreadsheet.FontSize() { Val = 11 },
                        new DocumentFormat.OpenXml.Spreadsheet.Color() { Rgb = new HexBinaryValue() { Value = "000000" } },
                        new DocumentFormat.OpenXml.Spreadsheet.FontName() { Val = "Calibri" }),
                    new DocumentFormat.OpenXml.Spreadsheet.Font(                                                               // Index 2 – The Times Roman font. with 16 size
                        new DocumentFormat.OpenXml.Spreadsheet.FontSize() { Val = 16 },
                        new DocumentFormat.OpenXml.Spreadsheet.Color() { Rgb = new HexBinaryValue() { Value = "000000" } },
                        new DocumentFormat.OpenXml.Spreadsheet.FontName() { Val = "Times New Roman" })
                ),
                new DocumentFormat.OpenXml.Spreadsheet.Fills(
                    new DocumentFormat.OpenXml.Spreadsheet.Fill(                                                           // Index 0 – The default fill.
                        new DocumentFormat.OpenXml.Spreadsheet.PatternFill() { PatternType = DocumentFormat.OpenXml.Spreadsheet.PatternValues.None }),
                    new DocumentFormat.OpenXml.Spreadsheet.Fill(                                                           // Index 1 – The default fill of gray 125 (required)
                        new DocumentFormat.OpenXml.Spreadsheet.PatternFill() { PatternType = DocumentFormat.OpenXml.Spreadsheet.PatternValues.Gray125 }),
                    new DocumentFormat.OpenXml.Spreadsheet.Fill(                                                           // Index 2 – The yellow fill.
                        new DocumentFormat.OpenXml.Spreadsheet.PatternFill(
                            new DocumentFormat.OpenXml.Spreadsheet.ForegroundColor() { Rgb = new HexBinaryValue() { Value = "00B050" } }
                        )
                        { PatternType = DocumentFormat.OpenXml.Spreadsheet.PatternValues.Solid })
                ),
                new DocumentFormat.OpenXml.Spreadsheet.Borders(
                    new DocumentFormat.OpenXml.Spreadsheet.Border(                                                         // Index 0 – The default border.
                        new DocumentFormat.OpenXml.Spreadsheet.LeftBorder(),
                        new DocumentFormat.OpenXml.Spreadsheet.RightBorder(),
                        new DocumentFormat.OpenXml.Spreadsheet.TopBorder(),
                        new DocumentFormat.OpenXml.Spreadsheet.BottomBorder(),
                        new DocumentFormat.OpenXml.Spreadsheet.DiagonalBorder()),
                    new DocumentFormat.OpenXml.Spreadsheet.Border(                                                         // Index 1 – Applies a Left, Right, Top, Bottom border to a cell
                        new DocumentFormat.OpenXml.Spreadsheet.LeftBorder(
                            new DocumentFormat.OpenXml.Spreadsheet.Color() { Auto = true }
                        )
                        { Style = DocumentFormat.OpenXml.Spreadsheet.BorderStyleValues.Thin },
                        new DocumentFormat.OpenXml.Spreadsheet.RightBorder(
                            new DocumentFormat.OpenXml.Spreadsheet.Color() { Auto = true }
                        )
                        { Style = DocumentFormat.OpenXml.Spreadsheet.BorderStyleValues.Thin },
                        new DocumentFormat.OpenXml.Spreadsheet.TopBorder(
                            new DocumentFormat.OpenXml.Spreadsheet.Color() { Auto = true }
                        )
                        { Style = DocumentFormat.OpenXml.Spreadsheet.BorderStyleValues.Thin },
                        new DocumentFormat.OpenXml.Spreadsheet.BottomBorder(
                            new DocumentFormat.OpenXml.Spreadsheet.Color() { Auto = true }
                        )
                        { Style = DocumentFormat.OpenXml.Spreadsheet.BorderStyleValues.Thin },
                        new DocumentFormat.OpenXml.Spreadsheet.DiagonalBorder())
                ),
                new DocumentFormat.OpenXml.Spreadsheet.CellFormats(
                    new DocumentFormat.OpenXml.Spreadsheet.CellFormat() { FontId = 0, FillId = 0, BorderId = 0 },                          // Index 0 – The default cell style.  If a cell does not have a style index applied it will use this style combination instead
                    new DocumentFormat.OpenXml.Spreadsheet.CellFormat() { FontId = 1, FillId = 0, BorderId = 0, ApplyFont = true },       // Index 1 – Bold 
                    new DocumentFormat.OpenXml.Spreadsheet.CellFormat() { FontId = 2, FillId = 0, BorderId = 0, ApplyFont = true },       // Index 2 – Italic
                    new DocumentFormat.OpenXml.Spreadsheet.CellFormat() { FontId = 3, FillId = 0, BorderId = 0, ApplyFont = true },       // Index 3 – Times Roman
                    new DocumentFormat.OpenXml.Spreadsheet.CellFormat() { FontId = 0, FillId = 2, BorderId = 0, ApplyFill = true },       // Index 4 – Yellow Fill
                    new DocumentFormat.OpenXml.Spreadsheet.CellFormat(                                                                   // Index 5 – Alignment
                        new DocumentFormat.OpenXml.Spreadsheet.Alignment() { Horizontal = DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Center, Vertical = DocumentFormat.OpenXml.Spreadsheet.VerticalAlignmentValues.Center, WrapText = true } 
                    )
                    { FontId = 0, FillId = 2, BorderId = 1, ApplyAlignment = true },
                    new DocumentFormat.OpenXml.Spreadsheet.CellFormat() { FontId = 0, FillId = 0, BorderId = 1, ApplyBorder = true },      // Index 6 – Border
                    new DocumentFormat.OpenXml.Spreadsheet.CellFormat(new DocumentFormat.OpenXml.Spreadsheet.NumberingFormat() { NumberFormatId = 4, FormatCode = "#,##0.00" }) { NumberFormatId = 3,ApplyNumberFormat = true } // Index 7 - For Validating to number //numFmt 
                )
            ); // return
        }

        public void InsertSaleContractEmployeeExcel(string fileName)
        {
            string[] HeaderData = new string[] { "Sr.No", "Particulars", "Working Days", "Present Days", "Basic", "Dearness Allowance", "Total", "House Rent Allowance", "Conveyance Allowance", "Gross", "Leave with wages", "Total Earnings", "Professional Tax", "Employee Provident Fund", "Emplyoee ESIC", "Total Deduction", "Net Amount" };

            string[] ColumnsData = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q" };
            for (uint i = 0; i < HeaderData.Length; i++)
            {
                InsertTextInExcel(fileName, HeaderData[i], ColumnsData[i], 1);
            }
        }


        [HttpGet]
        public ActionResult DownloadNRSheet(string SaleContractMasterID, string SaleContractBillingSpanID)
        {
            EmployeeSalaryTransactionViewModel model = new EmployeeSalaryTransactionViewModel();
            try
            {
                model.EmployeeSalaryTransactionDTO = new EmployeeSalaryTransaction();
                model.EmployeeSalaryTransactionDTO.SaleContractMasterID = Convert.ToInt64(SaleContractMasterID);
                model.EmployeeSalaryTransactionDTO.SaleContractBillingSpanID = Convert.ToInt64(SaleContractBillingSpanID);

                model.EmployeeSalaryTransactionDTO.ConnectionString = _connectioString;
                //Code For Generate PDF
                model.EmployeeSalaryTransactionList = GetSalaryTransactionDetailsForNRSheet(SaleContractMasterID, SaleContractBillingSpanID);

                if (model.EmployeeSalaryTransactionList.Count > 0)
                {

                    string SaleContractSalarySheetPDF = " ";

                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<table  width='100%' border='0'><tbody><tr><td style='font-size:5pt;text-align:left;'>M.W. From II</td><td style='font-size:8pt;text-align:center;'>Wage Sheet</td><td>" + model.EmployeeSalaryTransactionList[0].SaleContractBillingSpanName + "</td></tr><tr><td style='font-size:5pt;text-align:left;'>Factory F.No.17,29</td><td style='font-size:5pt;text-align:center;'>Factory Rules 122, 99 Rule 27 (1) </td><td style='font-size:8pt;text-align:right;'>Month - " + model.EmployeeSalaryTransactionList[0].SalaryMonth + "</td></tr><tr><td style='font-size:8pt;text-align:left;'>Name Of Establishment - " + model.EmployeeSalaryTransactionList[0].CentreName + "</td><td style='font-size:8pt;text-align:center;'>Name Of Employer - " + model.EmployeeSalaryTransactionList[0].CustomerBranchMasterName + "</td><td style='font-size:8pt;text-align:right;'>Year - " + model.EmployeeSalaryTransactionList[0].SalaryYear + "</td></tr></tbody></table>";

                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<br><table width='100%' border='1' style='repeat-header:yes;'><thead><tr>";

                    string[] SaleContractEmployeeMasterIDList = model.EmployeeSalaryTransactionList[0].SaleContractEmployeeMasterIDList.Replace(", ", ",").Split(new char[] { ',' });

                    string[] SaleContractManPowerItemIDList = model.EmployeeSalaryTransactionList[0].SaleContractManPowerItemIDList.Replace(", ", ",").Split(new char[] { ',' });

                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<th bgcolor='#D3D3D3' width='35%' style='border: 1px  black;border-collapse: collapse; font-size:5pt;text-align:center;'>Sr. No.</th><th bgcolor='#D3D3D3' width='250%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:5pt;text-align:left;'>Name Of Employee</th><th bgcolor='#D3D3D3' width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:5pt;text-align:center;'>Gross Salary</th>";

                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<th width='35%' bgcolor='#D3D3D3' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:5pt;text-align:center;'>Working Days</th>";
                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<th width='35%' bgcolor='#D3D3D3' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:5pt;text-align:center;'>Absent Days</th>";
                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<th width='70%' bgcolor='#D3D3D3' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:5pt;text-align:center;'>Extra Working Days (10)</th>";
                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<th width='70%' bgcolor='#D3D3D3' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:5pt;text-align:center;'>Extra Work Hrs (10)</th>";
                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<th width='70%' bgcolor='#D3D3D3' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:5pt;text-align:center;'>Extra Working Days (8)</th>";
                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<th width='70%' bgcolor='#D3D3D3' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:5pt;text-align:center;'>Extra Work Hrs (8)</th>";
                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<th width='70%' bgcolor='#D3D3D3' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:5pt;text-align:center;'>(+) Adjustments</th>";
                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<th width='70%' bgcolor='#D3D3D3' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:5pt;text-align:center;'>(-) Adjustments</th>";
                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<th width='70%' bgcolor='#D3D3D3' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:5pt;text-align:center;'>Extra Working Amt (10)</th>";
                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<th width='70%' bgcolor='#D3D3D3' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:5pt;text-align:center;'>Extra Working Amt (8)</th>";
                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<th width='70%' bgcolor='#D3D3D3' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:5pt;text-align:center;'>Salary Deduct</th>";
                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<th width='70%' bgcolor='#D3D3D3' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:5pt;text-align:center;'>Net Salary</th>";
                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<th width='150%' bgcolor='#D3D3D3' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:5pt;text-align:center;'>Signature</th>";

                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "</tr></thead><tbody>";

                    for (int manPowerID = 0, manPowerIDIndex = 1, manPowerListIndex = 0, j = 0; manPowerID < SaleContractManPowerItemIDList.Count(); manPowerID++, manPowerIDIndex++)
                    {
                        int v = j;
                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<tr><td width='35%' bgcolor='#D3D3D3' style='border: 1px  black;border-collapse: collapse; font-size:8pt;text-align:center;'>" + manPowerIDIndex + "</td><td bgcolor='#D3D3D3' width='250%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:left;'>" + model.EmployeeSalaryTransactionList[j].SaleContractManPowerItemName + "</td>";

                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'></td>";
                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='35%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'></td>";
                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='35%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'></td>";
                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'></td>";
                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'></td>";
                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'></td>";
                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'></td>";
                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'></td>";
                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'></td>";
                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'></td>";
                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'></td>";
                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'></td>";
                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'></td>";
                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='150%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'></td>";

                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "</tr>";

                        for (int i = 0, k = 1; i < SaleContractEmployeeMasterIDList.Count(); i++)
                        {
                            if (model.EmployeeSalaryTransactionList[j].SaleContractManPowerItemID == Convert.ToInt32(SaleContractManPowerItemIDList[manPowerID]) && model.EmployeeSalaryTransactionList[j].EmployeeMasterID == Convert.ToInt32(SaleContractEmployeeMasterIDList[i]))
                            {
                                SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<tr><td width='35%' style='border: 1px  black;border-collapse: collapse; font-size:8pt;text-align:center;'>" + k + "</td><td width='250%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:left;'>" + model.EmployeeSalaryTransactionList[j].EmployeeName + "</td><td width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center; '>" + Math.Round(model.EmployeeSalaryTransactionList[j].GrossAmount) + "</td><td width='35%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center; '>" + model.EmployeeSalaryTransactionList[j].TotalAttendance + "</td>";

                                SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='35%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'>0</td>";
                                SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'>0</td>";
                                SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'>0</td>";
                                SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'>0</td>";
                                SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'>0</td>";
                                SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'>0</td>";
                                SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'>0</td>";
                                SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'>0</td>";
                                SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'>0</td>";
                                SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'>0</td>";
                                SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'>" + Math.Round(model.EmployeeSalaryTransactionList[j].TotalSalary) + "</td>";
                                SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='150%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'></td>";
                                j++;
                                k++;
                                SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "</tr>";
                            }
                        }

                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<tr><td width='35%' bgcolor='#D3D3D3' style='border: 1px  black;border-collapse: collapse; font-size:8pt;text-align:center;'></td><td bgcolor='#D3D3D3' width='250%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:left;'>Sub Total</td>";

                        decimal TotalAttendanceManPowerSum = 0; decimal GrossSalarySum = 0; decimal TotalSalarySum = 0;
                        for (int bhu = 0; bhu < SaleContractEmployeeMasterIDList.Count(); bhu++)
                        {
                            bool DataAdded1 = false;
                            foreach (var item in model.EmployeeSalaryTransactionList)
                            {
                                if (item.SaleContractManPowerItemID == Convert.ToInt32(SaleContractManPowerItemIDList[manPowerID]) && item.EmployeeMasterID == Convert.ToInt32(SaleContractEmployeeMasterIDList[bhu]) && DataAdded1 == false)
                                {
                                    TotalAttendanceManPowerSum = TotalAttendanceManPowerSum + item.TotalAttendance;
                                    GrossSalarySum = GrossSalarySum + item.GrossAmount;
                                    TotalSalarySum = TotalSalarySum + item.TotalSalary;
                                    DataAdded1 = true;
                                }
                            }
                        }

                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'>" + Math.Round(GrossSalarySum) + "</td>";
                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='35%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'>" + TotalAttendanceManPowerSum + "</td>";
                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='35%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'></td>";
                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'></td>";
                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'></td>";
                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'></td>";
                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'></td>";
                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'></td>";
                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'></td>";
                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'></td>";
                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'></td>";
                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'></td>";
                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'>" + Math.Round(TotalSalarySum) + "</td>";
                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='150%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'></td>";

                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "</tr>";
                    }

                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "</tbody><tfoot>";

                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<tr><td width='35%' bgcolor='#D3D3D3' style='border: 1px  black;border-collapse: collapse; font-size:8pt;text-align:center;'></td><td bgcolor='#D3D3D3' width='250%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:left;'><b>Grand Total</b></td>";

                    decimal GrandAttendanceManPowerSum = 0; decimal GrandGrossSalarySum = 0; decimal GrandTotalSalarySum = 0;
                    for (int bhu = 0; bhu < SaleContractEmployeeMasterIDList.Count(); bhu++)
                    {
                        bool DataAdded1 = false;
                        foreach (var item in model.EmployeeSalaryTransactionList)
                        {
                            if (item.EmployeeMasterID == Convert.ToInt32(SaleContractEmployeeMasterIDList[bhu]) && DataAdded1 == false)
                            {
                                GrandAttendanceManPowerSum = GrandAttendanceManPowerSum + item.TotalAttendance;
                                GrandGrossSalarySum = GrandGrossSalarySum + item.GrossAmount;
                                GrandTotalSalarySum = GrandTotalSalarySum + item.TotalSalary;
                                DataAdded1 = true;
                            }
                        }
                    }

                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'><b>" + Math.Round(GrandGrossSalarySum) + "</b></td>";
                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='35%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'><b>" + GrandAttendanceManPowerSum + "</b></td>";
                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='35%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'><b></b></td>";
                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'><b></b></td>";
                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'><b></b></td>";
                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'><b></b></td>";
                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'><b></b></td>";
                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'><b></b></td>";
                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'><b></b></td>";
                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'><b></b></td>";
                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'><b></b></td>";
                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'><b></b></td>";
                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'><b>" + Math.Round(GrandTotalSalarySum) + "</b></td>";
                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='150%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'><b></b></td>";

                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "</tr>";

                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "</tfoot></table>";

                    DownloadNRPDF(SaleContractSalarySheetPDF, SaleContractMasterID, Convert.ToInt32(model.EmployeeSalaryTransactionList[0].SaleContractMasterID));

                    MemoryStream workStream = new MemoryStream();
                    return new FileStreamResult(workStream, "application/pdf");

                }
                else
                {
                    TempData["_errorMsg"] = "NR Record Not Found for Selected Salary.";
                    return RedirectToAction("Index", "EmployeeSalaryTransaction");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DownloadPDF(string SaleContractSalarySheetPDF, string CustomerInvoiceNumber, int SaleContractMasterID)
        {
            //string HTMLContent = "Hello <b>World</b>";

            Response.Clear();
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=" + "SalarySheet" + "_" + CustomerInvoiceNumber + ".pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.BinaryWrite(GetPDFDetails(SaleContractSalarySheetPDF));
            Response.End();
        }
        public void DownloadNRPDF(string SaleContractSalarySheetPDF, string CustomerInvoiceNumber, int SaleContractMasterID)
        {
            //string HTMLContent = "Hello <b>World</b>";

            Response.Clear();
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=" + "NRSheet" + "_" + CustomerInvoiceNumber + ".pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.BinaryWrite(GetPDFDetails(SaleContractSalarySheetPDF));
            Response.End();
        }
        public byte[] GetPDFDetails(string pHTML)
        {
            byte[] bPDF = null;

            MemoryStream ms = new MemoryStream();
            TextReader txtReader = new StringReader(pHTML);

            // 1: create object of a itextsharp document class
            Document doc = new Document(PageSize.A4.Rotate(), 5, 5, 5, 5);

            // 2: we create a itextsharp pdfwriter that listens to the document and directs a XML-stream to a file
            PdfWriter oPdfWriter = PdfWriter.GetInstance(doc, ms);

            // 3: we create a worker parse the document
            HTMLWorker htmlWorker = new HTMLWorker(doc);

            // 4: we open document and start the worker on the document
            doc.Open();
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

        #region Methods

        protected List<EmployeeSalaryTransaction> GetSalaryTransactionForGeneration(string EmployeeMasterID, string EmployeeSalarySpanID, string EmployeeSalaryRulesID)
        {

            EmployeeSalaryTransactionSearchRequest searchRequest = new EmployeeSalaryTransactionSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            searchRequest.EmployeeMasterID = Convert.ToInt32(EmployeeMasterID);
            searchRequest.EmployeeSalarySpanID = Convert.ToInt16(EmployeeSalarySpanID);
            searchRequest.EmployeeSalaryRulesID = Convert.ToInt64(EmployeeSalaryRulesID);

            List<EmployeeSalaryTransaction> listEmployeeSalaryTransaction = new List<EmployeeSalaryTransaction>();
            IBaseEntityCollectionResponse<EmployeeSalaryTransaction> baseEntityCollectionResponse = _EmployeeSalaryTransactionBA.GetSalaryTransactionForGeneration(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listEmployeeSalaryTransaction = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listEmployeeSalaryTransaction;
        }

        protected List<EmployeeSalaryTransaction> GetSalaryTransactionForBulkGeneration(string SelectedCentreCode, string DepartmentMasterID, string EmployeeSalarySpanID)
        {

            EmployeeSalaryTransactionSearchRequest searchRequest = new EmployeeSalaryTransactionSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            searchRequest.CenterCode = Convert.ToString(SelectedCentreCode);
            searchRequest.DepartmentMasterID = Convert.ToInt32(DepartmentMasterID);
            searchRequest.EmployeeSalarySpanID = Convert.ToInt16(EmployeeSalarySpanID);

            List<EmployeeSalaryTransaction> listEmployeeSalaryTransaction = new List<EmployeeSalaryTransaction>();
            IBaseEntityCollectionResponse<EmployeeSalaryTransaction> baseEntityCollectionResponse = _EmployeeSalaryTransactionBA.GetSalaryTransactionForBulkGeneration(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listEmployeeSalaryTransaction = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listEmployeeSalaryTransaction;
        }

        protected List<EmployeeSalaryTransaction> GetSalaryTransactionDetailsByID(string ID)
        {

            EmployeeSalaryTransactionSearchRequest searchRequest = new EmployeeSalaryTransactionSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            searchRequest.ID = Convert.ToInt64(ID);

            List<EmployeeSalaryTransaction> listEmployeeSalaryTransaction = new List<EmployeeSalaryTransaction>();
            IBaseEntityCollectionResponse<EmployeeSalaryTransaction> baseEntityCollectionResponse = _EmployeeSalaryTransactionBA.GetSalaryTransactionDetailsByID(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listEmployeeSalaryTransaction = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listEmployeeSalaryTransaction;
        }

        public ActionResult Delete(Int64 ID)
        {
            EmployeeSalaryTransactionViewModel model = new EmployeeSalaryTransactionViewModel();
            try
            {
                if (ID > 0)
                {
                    EmployeeSalaryTransaction EmployeeSalaryTransactionDTO = new EmployeeSalaryTransaction();
                    EmployeeSalaryTransactionDTO.ConnectionString = _connectioString;
                    EmployeeSalaryTransactionDTO.ID = ID;
                    EmployeeSalaryTransactionDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<EmployeeSalaryTransaction> response = _EmployeeSalaryTransactionBA.DeleteEmployeeSalary(EmployeeSalaryTransactionDTO);
                    model.EmployeeSalaryTransactionDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
                    return Json(model.EmployeeSalaryTransactionDTO.errorMessage, JsonRequestBehavior.AllowGet);
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

        protected List<EmployeeSalaryTransaction> GetSalaryTransactionDetails(string CentreCode, string DepartmentID, string SpanID)
        {

            EmployeeSalaryTransactionSearchRequest searchRequest = new EmployeeSalaryTransactionSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            searchRequest.CenterCode = CentreCode;
            searchRequest.DepartmentMasterID = Convert.ToInt32(DepartmentID);
            searchRequest.EmployeeSalarySpanID = Convert.ToInt16(SpanID);

            List<EmployeeSalaryTransaction> listEmployeeSalaryTransaction = new List<EmployeeSalaryTransaction>();
            IBaseEntityCollectionResponse<EmployeeSalaryTransaction> baseEntityCollectionResponse = _EmployeeSalaryTransactionBA.GetEmployeeSalaryDetailsForExcel(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listEmployeeSalaryTransaction = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listEmployeeSalaryTransaction;
        }


        protected List<EmployeeSalaryTransaction> GetListEmployeeSalaryTransactionDeduction()
        {

            EmployeeSalaryTransactionSearchRequest searchRequest = new EmployeeSalaryTransactionSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            List<EmployeeSalaryTransaction> listEmployeeSalaryTransaction = new List<EmployeeSalaryTransaction>();
            IBaseEntityCollectionResponse<EmployeeSalaryTransaction> baseEntityCollectionResponse = _EmployeeSalaryTransactionBA.GetListEmployeeSalaryTransactionDeduction(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listEmployeeSalaryTransaction = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listEmployeeSalaryTransaction;
        }

        [NonAction]
        protected List<EmployeeSalarySpan> GetEmployeeSalarySpanList()
        {
            EmployeeSalarySpanSearchRequest searchRequest = new EmployeeSalarySpanSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            List<EmployeeSalarySpan> listEmployeeSalaryRules = new List<EmployeeSalarySpan>();
            IBaseEntityCollectionResponse<EmployeeSalarySpan> baseEntityCollectionResponse = _EmployeeSalarySpanBA.GetSalarySpanList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listEmployeeSalaryRules = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listEmployeeSalaryRules;
        }

        [NonAction]
        public IEnumerable<EmployeeSalaryTransactionViewModel> GetEmployeeSalaryTransaction(out int TotalRecords, string SelectedCentreCode, string SelectedDepartmentID, string EmployeeSalarySpanID)
        {
            try
            {
                EmployeeSalaryTransactionSearchRequest searchRequest = new EmployeeSalaryTransactionSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
                _actionMode = Convert.ToString(TempData["ActionMode"]);

                searchRequest.CenterCode = SelectedCentreCode;
                searchRequest.DepartmentMasterID = Convert.ToInt32(SelectedDepartmentID);
                searchRequest.EmployeeSalarySpanID = Convert.ToInt16(EmployeeSalarySpanID);

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
                    searchRequest.SortBy = _sortBy;                     // parameters for SelectAll procedures under normal condition(Procedure Name : USP_AdminPostApplicableToRole_SelectAll)
                    searchRequest.StartRow = _startRow;
                    searchRequest.EndRow = _startRow + _rowLength;
                    searchRequest.SearchBy = _searchBy;
                    searchRequest.SortDirection = _sortDirection;
                }

                List<EmployeeSalaryTransactionViewModel> listSaleContractMasterViewModel = new List<EmployeeSalaryTransactionViewModel>();
                List<EmployeeSalaryTransaction> listSaleContractMaster = new List<EmployeeSalaryTransaction>();
                IBaseEntityCollectionResponse<EmployeeSalaryTransaction> baseEntityCollectionResponse = _EmployeeSalaryTransactionBA.GetEmployeeSalaryTransactionBySearch(searchRequest);
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        listSaleContractMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                        foreach (EmployeeSalaryTransaction item in listSaleContractMaster)
                        {
                            EmployeeSalaryTransactionViewModel SaleContractMasterViewModel = new EmployeeSalaryTransactionViewModel();
                            SaleContractMasterViewModel.EmployeeSalaryTransactionDTO = item;
                            listSaleContractMasterViewModel.Add(SaleContractMasterViewModel);
                        }
                    }
                }
                TotalRecords = baseEntityCollectionResponse.TotalRecords;

                return listSaleContractMasterViewModel;
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        protected List<EmployeeSalaryTransaction> GetSalaryTransactionDetailsForSalarySheet(string SaleContractMasterID, string SaleContractBillingSpanID)
        {

            EmployeeSalaryTransactionSearchRequest searchRequest = new EmployeeSalaryTransactionSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            searchRequest.SaleContractMasterID = Convert.ToInt64(SaleContractMasterID);
            searchRequest.SaleContractBillingSpanID = Convert.ToInt64(SaleContractBillingSpanID);

            List<EmployeeSalaryTransaction> listEmployeeSalaryTransaction = new List<EmployeeSalaryTransaction>();
            IBaseEntityCollectionResponse<EmployeeSalaryTransaction> baseEntityCollectionResponse = _EmployeeSalaryTransactionBA.GetSalaryTransactionDetailsForSalarySheet(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listEmployeeSalaryTransaction = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listEmployeeSalaryTransaction;
        }

        protected List<EmployeeSalaryTransaction> GetSalaryTransactionDetailsForNRSheet(string SaleContractMasterID, string SaleContractBillingSpanID)
        {

            EmployeeSalaryTransactionSearchRequest searchRequest = new EmployeeSalaryTransactionSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            searchRequest.SaleContractMasterID = Convert.ToInt64(SaleContractMasterID);
            searchRequest.SaleContractBillingSpanID = Convert.ToInt64(SaleContractBillingSpanID);

            List<EmployeeSalaryTransaction> listEmployeeSalaryTransaction = new List<EmployeeSalaryTransaction>();
            IBaseEntityCollectionResponse<EmployeeSalaryTransaction> baseEntityCollectionResponse = _EmployeeSalaryTransactionBA.GetSalaryTransactionDetailsForNRSheet(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listEmployeeSalaryTransaction = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listEmployeeSalaryTransaction;
        }
        #endregion

        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param, string SelectedCentreCode, string SelectedDepartmentID, string EmployeeSalarySpanID)
        {
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc
            int TotalRecords;
            IEnumerable<EmployeeSalaryTransactionViewModel> filteredEmployeeSalaryTransaction;

            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "EmployeeName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "EmployeeName Like '%" + param.sSearch + "%' or EmployeeCode Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "EmployeeCode";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "EmployeeName Like '%" + param.sSearch + "%' or EmployeeCode Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
            }

            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;

            string[] splitCentreCode = SelectedCentreCode.Split(':');
            var centreCode = splitCentreCode[0];

            filteredEmployeeSalaryTransaction = GetEmployeeSalaryTransaction(out TotalRecords, centreCode, SelectedDepartmentID, EmployeeSalarySpanID);

            var records = filteredEmployeeSalaryTransaction.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.EmployeeSalaryTransactionID), Convert.ToString(c.EmployeeMasterID), Convert.ToString(c.EmployeeName), Convert.ToString(c.TotalDays), Convert.ToString(c.TotalAttendance), Convert.ToString(c.NetPayable), Convert.ToString(c.TotalSalary), Convert.ToString(c.EmployeeSalaryRulesID) };
            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);

        }
        #endregion
    }
}


