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

namespace AERP.Web.UI.Controllers
{
    public class SaleContractShiftEmployeeController : BaseController
    {
        ISaleContractMasterBA _SaleContractMasterBA = null;
        IGeneralItemMasterBA _GeneralItemMasterBA = null;

        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public SaleContractShiftEmployeeController()
        {
            _SaleContractMasterBA = new SaleContractMasterBA();
            _GeneralItemMasterBA = new GeneralItemMasterBA();
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
            if (Convert.ToString(Session["UserType"]) == "A" || ((Convert.ToInt32(Session["Sales Manager"]) > 0 || Convert.ToInt32(Session["HR Manager"]) > 0) && IsApplied == true))
            {
                SaleContractMasterViewModel _SaleContractMasterViewModel = new SaleContractMasterViewModel();

                return View("/Views/Contract/SaleContractShiftEmployee/Index.cshtml", _SaleContractMasterViewModel);
            }
            else
            {
                return RedirectToAction("UnauthorizedAccess", "Home");
            }
        }

        #endregion

        #region Methods

        #endregion

        #region AjaxHandler

        #endregion
    }
}


