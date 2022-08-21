using AMS.Base.DTO;
using AMS.DTO;
using AMS.ServiceAccess;
using AMS.ExceptionManager;
using AMS.ViewModel;
using System;
using System.IO;
using System.Web.UI;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using AMS.Common;
using AMS.DataProvider;
using AMS.Business.BusinessActions;
namespace AMS.Web.UI.Controllers
{
    public class InventoryCurrentStockPriceDrillReportController : BaseController
    {
        #region ------------CONTROLLER CLASS VARIABLE------------
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        IInventoryCurrentStockPriceDrillReportServiceAccess _InventoryCurrentStockPriceDrillReportServiceAccess = null;

        private readonly ILogger _logException;
        protected static string _dateFrom = string.Empty;
        protected static string _dateTo = string.Empty;
        protected static string _ReportForPage;
        #endregion

        #region ------------CONTROLLER CLASS CONSTRUCTOR------------
        public InventoryCurrentStockPriceDrillReportController()
        {
            _InventoryCurrentStockPriceDrillReportServiceAccess = new InventoryCurrentStockPriceDrillReportServiceAccess();

        }
        #endregion

        #region ------------CONTROLLER ACTION METHODS------------

        public ActionResult Index()
        {
            InventoryCurrentStockPriceDrillReportViewModel model = new InventoryCurrentStockPriceDrillReportViewModel();

            return View("/Views/Inventory_1/Report/InventoryCurrentStockPriceDrillReport/Index.cshtml", model);
        }
       
        #endregion

        #region ------------CONTROLLER NON ACTION METHODS------------

        public List<InventoryCurrentStockPriceDrillReport> GetOrganisationWiseList()
        {
            try
            {
                List<InventoryCurrentStockPriceDrillReport> listInventoryCurrentStockPriceDrillReport = new List<InventoryCurrentStockPriceDrillReport>();
                InventoryCurrentStockPriceDrillReportSearchRequest searchRequest = new InventoryCurrentStockPriceDrillReportSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["WareHouseDb.ConnectionString"]);

                // if (_dateFrom != string.Empty && _dateTo != string.Empty)
                // {

                IBaseEntityCollectionResponse<InventoryCurrentStockPriceDrillReport> baseEntityCollectionResponse = _InventoryCurrentStockPriceDrillReportServiceAccess.GetInventoryCurrentStockPriceDrillReportByOrganisation(searchRequest);
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        listInventoryCurrentStockPriceDrillReport = baseEntityCollectionResponse.CollectionResponse.ToList();
                    }
                }
                // }s
                return listInventoryCurrentStockPriceDrillReport;
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }
        public List<InventoryCurrentStockPriceDrillReport> GetCentreWiseList(string OrganisationMasterKey)
        {
            try
            {
                List<InventoryCurrentStockPriceDrillReport> listInventoryCurrentStockPriceDrillReport = new List<InventoryCurrentStockPriceDrillReport>();
                InventoryCurrentStockPriceDrillReportSearchRequest searchRequest = new InventoryCurrentStockPriceDrillReportSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["WareHouseDb.ConnectionString"]);
                searchRequest.OrganisationMasterKey = Convert.ToInt32(OrganisationMasterKey);
                // if (_dateFrom != string.Empty && _dateTo != string.Empty)
                //{

                IBaseEntityCollectionResponse<InventoryCurrentStockPriceDrillReport> baseEntityCollectionResponse = _InventoryCurrentStockPriceDrillReportServiceAccess.GetInventoryCurrentStockPriceDrillReportByCentre(searchRequest);
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        listInventoryCurrentStockPriceDrillReport = baseEntityCollectionResponse.CollectionResponse.ToList();
                    }
                }
                //}
                return listInventoryCurrentStockPriceDrillReport;
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }
        public List<InventoryCurrentStockPriceDrillReport> GetStoreWiseList(string CentreCode)
        {
            try
            {
                List<InventoryCurrentStockPriceDrillReport> listInventoryCurrentStockPriceDrillReport = new List<InventoryCurrentStockPriceDrillReport>();
                InventoryCurrentStockPriceDrillReportSearchRequest searchRequest = new InventoryCurrentStockPriceDrillReportSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["WareHouseDb.ConnectionString"]);
                searchRequest.CentreCode = CentreCode;
                // if (_dateFrom != string.Empty && _dateTo != string.Empty)
                // {
                IBaseEntityCollectionResponse<InventoryCurrentStockPriceDrillReport> baseEntityCollectionResponse = _InventoryCurrentStockPriceDrillReportServiceAccess.GetInventoryCurrentStockPriceDrillReportByStore(searchRequest);
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        listInventoryCurrentStockPriceDrillReport = baseEntityCollectionResponse.CollectionResponse.ToList();
                    }
                }
                //}
                return listInventoryCurrentStockPriceDrillReport;
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }
        public List<InventoryCurrentStockPriceDrillReport> GetArticleWiseList(string GeneralUnitsId)
        {
            try
            {
                List<InventoryCurrentStockPriceDrillReport> listInventoryCurrentStockPriceDrillReport = new List<InventoryCurrentStockPriceDrillReport>();
                InventoryCurrentStockPriceDrillReportSearchRequest searchRequest = new InventoryCurrentStockPriceDrillReportSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["WareHouseDb.ConnectionString"]);
                searchRequest.GeneralUnitsID = Convert.ToInt32(GeneralUnitsId);
                //if (_dateFrom != string.Empty && _dateTo != string.Empty)
                //{
                // searchRequest.GeneralUnitsID = Convert.ToInt32(GeneralUnitsID);
                IBaseEntityCollectionResponse<InventoryCurrentStockPriceDrillReport> baseEntityCollectionResponse = _InventoryCurrentStockPriceDrillReportServiceAccess.GetInventoryCurrentStockPriceDrillReportByArticle(searchRequest);
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        listInventoryCurrentStockPriceDrillReport = baseEntityCollectionResponse.CollectionResponse.ToList();
                    }
                }
                //}
                return listInventoryCurrentStockPriceDrillReport;
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
