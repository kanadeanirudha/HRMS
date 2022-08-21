using AERP.Base.DTO;
using AERP.DTO;
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
using System.Text;
using AERP.Business.BusinessAction;
using System.Globalization;
namespace AERP.Web.UI.Controllers
{
    public class PFChallanRemittanceController : BaseController
    {
        #region ------------CONTROLLER CLASS VARIABLE------------
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        IPFChallanRemittanceBA _PFChallanRemittanceBA = null;
        private readonly ILogger _logException;
        protected static string _centreCode = string.Empty;
        protected static string _centreName = string.Empty;
        protected static string _Month = string.Empty;
        protected static string _Year = string.Empty;
        protected static int _SaleContractEmployeeMasterID = 0;
        protected static int _AccountSessionID = 0;

        #endregion

        #region ------------CONTROLLER CLASS CONSTRUCTOR------------
        public PFChallanRemittanceController()
        {
            _PFChallanRemittanceBA = new PFChallanRemittanceBA();
        }
        #endregion

        #region ------------CONTROLLER ACTION METHODS------------
        public ActionResult Index()
        {
            bool IsApplied = CheckMenuApplicableOrNot(ControllerContext.RouteData.Values["Controller"].ToString());
            if (IsApplied == true)
            {
                PFChallanRemittanceViewModel model = new PFChallanRemittanceViewModel();
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
                return View("/Views/Contract/Report/PFChallanRemittance/Index.cshtml", model);
            }
            else
            {
                return RedirectToAction("UnauthorizedAccess", "Home");
            }
        }

        public ActionResult List(string MonthName, string MonthYear)
        {
            try
            {
                PFChallanRemittanceViewModel model = new PFChallanRemittanceViewModel();
                // get detail list of purchase requirement for purchase requisation

                decimal TotalPF = 0; decimal TotalAcc01 = 0;


                model.PFChallanRemittanceDetailListForparticulars = GetPFChallanRemittanceListForParticularsMonthWise(MonthName, MonthYear);
                model.MonthName = MonthName;
                model.MonthYear = MonthYear;
                if (model.PFChallanRemittanceDetailListForparticulars.Count > 0)
                {
                    model.ReferenceNumber = model.PFChallanRemittanceDetailListForparticulars[0].ReferenceNumber;
                    model.PaymentMode = model.PFChallanRemittanceDetailListForparticulars[0].PaymentMode;
                    model.ChallanRemmittanceDate = model.PFChallanRemittanceDetailListForparticulars[0].ChallanRemmittanceDate;
                    model.ID = model.PFChallanRemittanceDetailListForparticulars[0].ID;

                     TotalAcc01 = model.PFChallanRemittanceDetailListForparticulars[0].Acc01 + model.PFChallanRemittanceDetailListForparticulars[0].WorkersShare;
                    TotalPF = TotalAcc01 + model.PFChallanRemittanceDetailListForparticulars[0].Acc02 + model.PFChallanRemittanceDetailListForparticulars[0].Acc21 + model.PFChallanRemittanceDetailListForparticulars[0].Acc10 + model.PFChallanRemittanceDetailListForparticulars[0].Acc22;

                }

                string Amountt = Convert.ToString(Math.Round(TotalPF));
                model.PFAmountInWords = ConvertToWords(Amountt);
                
                List<SelectListItem> li = new List<SelectListItem>();
                li.Add(new SelectListItem { Text = "--Select--", Value = "0" });
                li.Add(new SelectListItem { Text = "Online Mode", Value = "1" });
                li.Add(new SelectListItem { Text = "Ofline Mode", Value = "2" });
                ViewData["PayementMode"] = li;
                return PartialView("/Views//Contract/Report/PFChallanRemittance/List.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }
        public ActionResult DownloadTxtFile(string MonthName, string MonthYear)
        {
            MemoryStream memoryStream = new MemoryStream();
            TextWriter tw = new StreamWriter(memoryStream);

            PFChallanRemittanceViewModel model = new PFChallanRemittanceViewModel();


            model.PFChallanRemittanceList = GetPFChallanRemittanceList(MonthName, MonthYear);
            int row = model.PFChallanRemittanceList.Count;

            for (int i = 0; i < model.PFChallanRemittanceList.Count; i++)
            {
                  if (i == row - 1)
                { 
                    tw.Write(model.PFChallanRemittanceList[i].UploadString.Trim());
                }
                else
                { 
                    tw.WriteLine(model.PFChallanRemittanceList[i].UploadString);
                }


            }
           
            tw.Flush();
            tw.Close();

            return File(memoryStream.GetBuffer(), "text/plain", "PF Uploading File.txt");
        }

        [HttpPost]
        [ValidateInput(false)]
        public FileResult DownloadExcelFile(string GridHtml)
        {
            return File(Encoding.ASCII.GetBytes(GridHtml), "application/vnd.ms-excel", "Grid.xls");
        }

        [HttpPost]
        public ActionResult Create(PFChallanRemittanceViewModel model)
        {
            try
            {
                if (model != null && model.PFChallanRemittanceDTO != null)
                {
                    model.PFChallanRemittanceDTO.ConnectionString = _connectioString;
                    model.PFChallanRemittanceDTO.MonthName = model.MonthName;
                    model.PFChallanRemittanceDTO.MonthYear = model.MonthYear;
                    model.PFChallanRemittanceDTO.ReferenceNumber = model.ReferenceNumber;
                    model.PFChallanRemittanceDTO.ChallanRemmittanceDate = model.ChallanRemmittanceDate;
                    model.PFChallanRemittanceDTO.Acc01 = model.Acc01;
                    model.PFChallanRemittanceDTO.Acc02 = model.Acc02;
                    model.PFChallanRemittanceDTO.Acc10 = model.Acc10;
                    model.PFChallanRemittanceDTO.Acc21 = model.Acc21;
                    model.PFChallanRemittanceDTO.Acc22 = model.Acc22;
                    model.PFChallanRemittanceDTO.TotalAmountRemited = model.TotalAmountRemited;
                    model.PFChallanRemittanceDTO.PaymentMode = model.PaymentMode;

                    model.PFChallanRemittanceDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    model.PFChallanRemittanceDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<PFChallanRemittance> response = _PFChallanRemittanceBA.InsertPFChallanRemittance(model.PFChallanRemittanceDTO);

                    model.PFChallanRemittanceDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);

                    return Json(model.PFChallanRemittanceDTO.errorMessage, JsonRequestBehavior.AllowGet);
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

        #endregion

        #region ------------CONTROLLER NON ACTION METHODS------------


        public List<PFChallanRemittance> GetPFChallanRemittanceList(string Month, string Year)
        {
            try
            {
                List<PFChallanRemittance> listPFChallanRemittance = new List<PFChallanRemittance>();
                PFChallanRemittanceSearchRequest searchRequest = new PFChallanRemittanceSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
                searchRequest.MonthName = Month;
                searchRequest.MonthYear = Year;
                IBaseEntityCollectionResponse<PFChallanRemittance> baseEntityCollectionResponse = _PFChallanRemittanceBA.GetPFChallanRemittanceDataList(searchRequest);
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        listPFChallanRemittance = baseEntityCollectionResponse.CollectionResponse.ToList();
                    }
                }
                return listPFChallanRemittance;
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }
        public List<PFChallanRemittance> GetPFChallanRemittanceListForParticularsMonthWise(string Month, string Year)
        {
            try
            {
                List<PFChallanRemittance> listPFChallanRemittance = new List<PFChallanRemittance>();
                PFChallanRemittanceSearchRequest searchRequest = new PFChallanRemittanceSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
                searchRequest.MonthName = Month;
                searchRequest.MonthYear = Year;
                IBaseEntityCollectionResponse<PFChallanRemittance> baseEntityCollectionResponse = _PFChallanRemittanceBA.GetPFChallanRemittanceDataListForParticularsMonthWise(searchRequest);
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        listPFChallanRemittance = baseEntityCollectionResponse.CollectionResponse.ToList();
                    }
                }
                return listPFChallanRemittance;
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }


        #endregion



    }
}
