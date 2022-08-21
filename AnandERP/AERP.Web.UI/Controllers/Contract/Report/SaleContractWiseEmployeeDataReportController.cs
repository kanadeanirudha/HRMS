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
    public class SaleContractWiseEmployeeDataReportController : BaseController
    {
        #region ------------CONTROLLER CLASS VARIABLE------------
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        ISaleContractAttendanceBA _SaleContractAttendanceBA = null;
        ISaleContractWiseEmployeeDataReportBA _SaleContractWiseEmployeeDataReportBA = null;
        private readonly ILogger _logException;
        protected static string _centreCode = string.Empty;
        protected static string _centreName = string.Empty;
        protected static string _ContractNumber = string.Empty;
        protected static string _SaleContractBillingSpanName = string.Empty;
        protected static Int64 _SaleContractMasterID = 0;
        protected static Int64 _SaleContractBillingSpanID = 0;

        #endregion

        #region ------------CONTROLLER CLASS CONSTRUCTOR------------
        public SaleContractWiseEmployeeDataReportController()
        {
            _SaleContractWiseEmployeeDataReportBA = new SaleContractWiseEmployeeDataReportBA();
            _SaleContractAttendanceBA = new SaleContractAttendanceBA();
        }
        #endregion

        #region ------------CONTROLLER ACTION METHODS------------
        public ActionResult Index()
        {
            bool IsApplied = CheckMenuApplicableOrNot(ControllerContext.RouteData.Values["Controller"].ToString());
            if (IsApplied == true)
            {
                _SaleContractMasterID = 0;
                _ContractNumber = string.Empty;

                SaleContractWiseEmployeeDataReportViewModel model = new SaleContractWiseEmployeeDataReportViewModel();

                return View("/Views/Contract/Report/SaleContractWiseEmployeeDataReport/Index.cshtml", model);
            }
            else
            {
                return RedirectToAction("UnauthorizedAccess", "Home");
            }
        }

        [HttpPost]
        public ActionResult Index(SaleContractWiseEmployeeDataReportViewModel model)
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

            return View("/Views/Contract/Report/SaleContractWiseEmployeeDataReport/Index.cshtml", model);
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

        public List<SaleContractWiseEmployeeDataReport> GetSaleContractWiseEmployeeDataReportList()
        {
            try
            {
                List<SaleContractWiseEmployeeDataReport> listSaleContractWiseEmployeeDataReport = new List<SaleContractWiseEmployeeDataReport>();
                SaleContractWiseEmployeeDataReportSearchRequest searchRequest = new SaleContractWiseEmployeeDataReportSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
                
                if (_SaleContractMasterID > 0)
                {
                    searchRequest.SaleContractMasterID = _SaleContractMasterID;
                    searchRequest.ContractNumber = _ContractNumber;
                    searchRequest.SaleContractBillingSpanID = _SaleContractBillingSpanID;
                    searchRequest.SaleContractBillingSpanName = _SaleContractBillingSpanName;
                    IBaseEntityCollectionResponse<SaleContractWiseEmployeeDataReport> baseEntityCollectionResponse = _SaleContractWiseEmployeeDataReportBA.GetSaleContractWiseEmployeeDataReportDataList(searchRequest);
                    if (baseEntityCollectionResponse != null)
                    {
                        if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                        {
                            listSaleContractWiseEmployeeDataReport = baseEntityCollectionResponse.CollectionResponse.ToList();
                        }
                    }
                }
                return listSaleContractWiseEmployeeDataReport;
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
