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
    public class SaleContractWisePNLReportController : BaseController
    {
        #region ------------CONTROLLER CLASS VARIABLE------------
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        ISaleContractAttendanceBA _SaleContractAttendanceBA = null;
        ISaleContractWisePNLReportBA _SaleContractWisePNLReportBA = null;
        private readonly ILogger _logException;
        protected static string _centreCode = string.Empty;
        protected static string _centreName = string.Empty;
        protected static string _ContractNumber = string.Empty;
        protected static string _SaleContractBillingSpanName = string.Empty;
        protected static Int64 _SaleContractMasterID = 0;
        protected static Int64 _SaleContractBillingSpanID = 0;

        #endregion

        #region ------------CONTROLLER CLASS CONSTRUCTOR------------
        public SaleContractWisePNLReportController()
        {
            _SaleContractWisePNLReportBA = new SaleContractWisePNLReportBA();
            _SaleContractAttendanceBA = new SaleContractAttendanceBA();
        }
        #endregion

        #region ------------CONTROLLER ACTION METHODS------------
        public ActionResult Index()
        {
            bool IsApplied = CheckMenuApplicableOrNot(ControllerContext.RouteData.Values["Controller"].ToString());
            if (IsApplied == true)
            {
                SaleContractWisePNLReportViewModel model = new SaleContractWisePNLReportViewModel();

                return View("/Views/Contract/Report/SaleContractWisePNLReport/Index.cshtml", model);
            }
            else
            {
                return RedirectToAction("UnauthorizedAccess", "Home");
            }
        }

        [HttpPost]
        public ActionResult Index(SaleContractWisePNLReportViewModel model)
        {
            if (model.IsPosted == true)
            {
                _SaleContractMasterID = model.SaleContractMasterID;
                _ContractNumber = model.ContractNumber;
                _SaleContractBillingSpanID = model.SaleContractBillingSpanID;
                _SaleContractBillingSpanName = model.SaleContractBillingSpanName;
                model.IsPosted = false;
            }
            else
            {
                model.SaleContractMasterID = _SaleContractMasterID;
                model.ContractNumber = _ContractNumber;
                model.SaleContractBillingSpanID = _SaleContractBillingSpanID;
                model.SaleContractBillingSpanName = _SaleContractBillingSpanName;
            }

            model.SaleContractSpanList = GetSpanListBySaleContractMaster(model.SaleContractMasterID);

            return View("/Views/Contract/Report/SaleContractWisePNLReport/Index.cshtml", model);
        }

        #endregion

        #region ------------CONTROLLER NON ACTION METHODS------------

        protected List<SaleContractAttendance> GetSpanListBySaleContractMaster(Int64 SaleContractMasterID)
        {

            SaleContractAttendanceSearchRequest searchRequest = new SaleContractAttendanceSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.SaleContractMasterID = Convert.ToInt64(SaleContractMasterID);

            List<SaleContractAttendance> listSaleContractAttendance = new List<SaleContractAttendance>();
            IBaseEntityCollectionResponse<SaleContractAttendance> baseEntityCollectionResponse = _SaleContractAttendanceBA.GetSpanListBySaleContractMaster(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listSaleContractAttendance = baseEntityCollectionResponse.CollectionResponse.ToList();

                }
            }
            return listSaleContractAttendance;
        }

        public List<SaleContractWisePNLReport> GetSaleContractWisePNLReportList()
        {
            try
            {
                List<SaleContractWisePNLReport> listSaleContractWisePNLReport = new List<SaleContractWisePNLReport>();
                SaleContractWisePNLReportSearchRequest searchRequest = new SaleContractWisePNLReportSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
                
                if (_SaleContractMasterID > 0 && _SaleContractBillingSpanID > 0)
                {
                    searchRequest.SaleContractMasterID = _SaleContractMasterID;
                    searchRequest.ContractNumber = _ContractNumber;
                    searchRequest.SaleContractBillingSpanID = _SaleContractBillingSpanID;
                    searchRequest.SaleContractBillingSpanName = _SaleContractBillingSpanName;
                    IBaseEntityCollectionResponse<SaleContractWisePNLReport> baseEntityCollectionResponse = _SaleContractWisePNLReportBA.GetSaleContractWisePNLReportDataList(searchRequest);
                    if (baseEntityCollectionResponse != null)
                    {
                        if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                        {
                            listSaleContractWisePNLReport = baseEntityCollectionResponse.CollectionResponse.ToList();
                        }
                    }
                }
                return listSaleContractWisePNLReport;
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
