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
    public class ArticlesAvailabilityReportController : BaseController
    {
        #region ------------CONTROLLER CLASS VARIABLE------------
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        IArticlesAvailabilityReportServiceAccess _ArticlesAvailabilityReportServiceAccess = null;
        
        private readonly ILogger _logException;
        protected static string _dateFrom = string.Empty;
        protected static string _dateTo = string.Empty;
        protected static string _ReportForPage;
        #endregion

        #region ------------CONTROLLER CLASS CONSTRUCTOR------------
        public ArticlesAvailabilityReportController()
        {
            _ArticlesAvailabilityReportServiceAccess = new ArticlesAvailabilityReportServiceAccess();
            
        }
        #endregion

        #region ------------CONTROLLER ACTION METHODS------------

        public ActionResult Index()
        {
            ArticlesAvailabilityReportViewModel model = new ArticlesAvailabilityReportViewModel();


            return View("/Views/Inventory_1/Report/ArticlesAvailabilityReport/Index.cshtml", model);
        }
        //[HttpPost]
        //public ActionResult Index(ArticlesAvailabilityReportViewModel model)
        //{
        //    //if (model.IsPosted == true)
        //    //{
        //    //    _dateFrom = model.DateFrom;
        //    //    _dateTo = model.DateTo;
        //    //    model.IsPosted = false;
        //    //}
        //    //else
        //    //{
        //    //    model.DateFrom = _dateFrom;
        //    //    model.DateTo = _dateTo;
        //    //}
        //    return View("/Views/Inventory_1/Report/ArticlesAvailabilityReport/Index.cshtml", model);
        //}
        #endregion

        #region ------------CONTROLLER NON ACTION METHODS------------

        public List<ArticlesAvailabilityReport> GetSocietyWiseReportList()
        {
            try
            {
                List<ArticlesAvailabilityReport> listArticlesAvailabilityReport = new List<ArticlesAvailabilityReport>();
                ArticlesAvailabilityReportSearchRequest searchRequest = new ArticlesAvailabilityReportSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["WareHouseDb.ConnectionString"]);

               // if (_dateFrom != string.Empty && _dateTo != string.Empty)
               // {

                    IBaseEntityCollectionResponse<ArticlesAvailabilityReport> baseEntityCollectionResponse = _ArticlesAvailabilityReportServiceAccess.GetArticlesAvailabilityReportBySociety(searchRequest);
                    if (baseEntityCollectionResponse != null)
                    {
                        if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                        {
                            listArticlesAvailabilityReport = baseEntityCollectionResponse.CollectionResponse.ToList();
                        }
                    }
               // }
                return listArticlesAvailabilityReport;
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }
        public List<ArticlesAvailabilityReport> GetCentreWiseReportList(string OrganisationMasterKey)
        {
            try
            {
                List<ArticlesAvailabilityReport> listArticlesAvailabilityReport = new List<ArticlesAvailabilityReport>();
                ArticlesAvailabilityReportSearchRequest searchRequest = new ArticlesAvailabilityReportSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["WareHouseDb.ConnectionString"]);

               // if (_dateFrom != string.Empty && _dateTo != string.Empty)
                //{
                searchRequest.OrganisationMasterKey = Convert.ToInt32(OrganisationMasterKey);
                    IBaseEntityCollectionResponse<ArticlesAvailabilityReport> baseEntityCollectionResponse = _ArticlesAvailabilityReportServiceAccess.GetArticlesAvailabilityReportByCentre(searchRequest);
                    if (baseEntityCollectionResponse != null)
                    {
                        if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                        {
                            listArticlesAvailabilityReport = baseEntityCollectionResponse.CollectionResponse.ToList();
                        }
                    }
                //}
                return listArticlesAvailabilityReport;
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }
        public List<ArticlesAvailabilityReport> GetStoreWiseReportList(string CentreCode)
        {
            try
            {
                List<ArticlesAvailabilityReport> listArticlesAvailabilityReport = new List<ArticlesAvailabilityReport>();
                ArticlesAvailabilityReportSearchRequest searchRequest = new ArticlesAvailabilityReportSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["WareHouseDb.ConnectionString"]);

               // if (_dateFrom != string.Empty && _dateTo != string.Empty)
               // {
                searchRequest.CentreCode = CentreCode;
                    IBaseEntityCollectionResponse<ArticlesAvailabilityReport> baseEntityCollectionResponse = _ArticlesAvailabilityReportServiceAccess.GetArticlesAvailabilityReportByStore(searchRequest);
                    if (baseEntityCollectionResponse != null)
                    {
                        if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                        {
                            listArticlesAvailabilityReport = baseEntityCollectionResponse.CollectionResponse.ToList();
                        }
                    }
                //}
                return listArticlesAvailabilityReport;
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }
        public List<ArticlesAvailabilityReport> GetVendorWiseReportList(string GeneralUnitsID)
        {
            try
            {
                List<ArticlesAvailabilityReport> listArticlesAvailabilityReport = new List<ArticlesAvailabilityReport>();
                ArticlesAvailabilityReportSearchRequest searchRequest = new ArticlesAvailabilityReportSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["WareHouseDb.ConnectionString"]);

                //if (_dateFrom != string.Empty && _dateTo != string.Empty)
                //{
                    searchRequest.GeneralUnitsID = Convert.ToInt32(GeneralUnitsID);
                    IBaseEntityCollectionResponse<ArticlesAvailabilityReport> baseEntityCollectionResponse = _ArticlesAvailabilityReportServiceAccess.GetArticlesAvailabilityReportByVendor(searchRequest);
                    if (baseEntityCollectionResponse != null)
                    {
                        if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                        {
                            listArticlesAvailabilityReport = baseEntityCollectionResponse.CollectionResponse.ToList();
                        }
                    }
                //}
                return listArticlesAvailabilityReport;
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
