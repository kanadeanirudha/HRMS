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
using AERP.Business.BusinessAction;
using System.Globalization;
namespace AERP.Web.UI.Controllers
{
    public class SaleContractLifeSpanReportController : BaseController
    {
        #region ------------CONTROLLER CLASS VARIABLE------------
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        ISaleContractLifeSpanReportBA _SaleContractLifeSpanReportBA = null;
        private readonly ILogger _logException;
        protected static string _centreCode = string.Empty;
        protected static string _centreName = string.Empty;
        protected static string _MonthYear = string.Empty;
        protected static string _MonthName = string.Empty;
        protected static int _SaleContractEmployeeMasterID = 0;
        protected static int _AccountSessionID = 0;

        #endregion

        #region ------------CONTROLLER CLASS CONSTRUCTOR------------
        public SaleContractLifeSpanReportController()
        {
            _SaleContractLifeSpanReportBA = new SaleContractLifeSpanReportBA();
        }
        #endregion

        #region ------------CONTROLLER ACTION METHODS------------
        public ActionResult Index()
        {
            bool IsApplied = CheckMenuApplicableOrNot(ControllerContext.RouteData.Values["Controller"].ToString());
            if (IsApplied == true)
            {
                SaleContractLifeSpanReportViewModel model = new SaleContractLifeSpanReportViewModel();

                return View("/Views/Contract/Report/SaleContractLifeSpanReport/Index.cshtml", model);
            }
            else
            {
                return RedirectToAction("UnauthorizedAccess", "Home");
            }
        }

        [HttpPost]
        public ActionResult Index(SaleContractLifeSpanReportViewModel model)
        {
            return View("/Views/Contract/Report/SaleContractLifeSpanReport/Index.cshtml", model);
        }

        #endregion

        #region ------------CONTROLLER NON ACTION METHODS------------



        public List<SaleContractLifeSpanReport> GetSaleContractLifeSpanReportList()
        {
            try
            {
                List<SaleContractLifeSpanReport> listSaleContractLifeSpanReport = new List<SaleContractLifeSpanReport>();
                SaleContractLifeSpanReportSearchRequest searchRequest = new SaleContractLifeSpanReportSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
                {
                    IBaseEntityCollectionResponse<SaleContractLifeSpanReport> baseEntityCollectionResponse = _SaleContractLifeSpanReportBA.GetSaleContractLifeSpanReportDataList(searchRequest);
                    if (baseEntityCollectionResponse != null)
                    {
                        if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                        {
                            listSaleContractLifeSpanReport = baseEntityCollectionResponse.CollectionResponse.ToList();
                        }
                    }
                }
                return listSaleContractLifeSpanReport;
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
