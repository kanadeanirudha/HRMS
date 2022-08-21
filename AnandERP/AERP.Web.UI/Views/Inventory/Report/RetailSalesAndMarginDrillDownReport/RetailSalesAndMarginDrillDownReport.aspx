<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
  <script runat="server">
   
        AMS.Web.UI.Controllers.RetailSalesAndMarginDrillDownReportController controller = new AMS.Web.UI.Controllers.RetailSalesAndMarginDrillDownReportController();

        protected void Page_PreInit(object sender, EventArgs e)
        {
            Context.Handler = this.Page;
        }
        List<AMS.DTO.RetailSalesAndMarginDrillDownReport> RetailSalesAndMarginDrillDownReport = null;
        void Page_Load(object sender, EventArgs e)
        {
            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            scriptManager.RegisterPostBackControl(this.rvRetailSalesAndMarginDrillDownReport);

            if (!IsPostBack)
            {
                rvRetailSalesAndMarginDrillDownReport.ProcessingMode = ProcessingMode.Local;

               

                if (Request.RequestType == "POST")
                {
                    RetailSalesAndMarginDrillDownReport = controller.GetStoresList();
                }

                if (RetailSalesAndMarginDrillDownReport == null)
                {
                    MainDiv.Visible = false;
                    NoRecordDiv.Visible = true;
                }
                else
                {
                    MainDiv.Visible = true;
                    NoRecordDiv.Visible = false;
                    rvRetailSalesAndMarginDrillDownReport.LocalReport.ReportPath = Server.MapPath("~/Report/Inventory_1/RetailSalesAndMarginDrillDownReportForUnitsList.rdlc");
                    rvRetailSalesAndMarginDrillDownReport.LocalReport.DataSources.Clear();

                    ReportDataSource rdc = new ReportDataSource();
                    rdc.Name = "DataSet1";
                    rdc.Value = RetailSalesAndMarginDrillDownReport;
                    rvRetailSalesAndMarginDrillDownReport.LocalReport.DataSources.Add(rdc);

                    ReportParameter[] param = new ReportParameter[4];
                    param[0] = new ReportParameter("DateFrom", RetailSalesAndMarginDrillDownReport.Count > 0 ? RetailSalesAndMarginDrillDownReport[0].DateFrom : string.Empty, false);
                    param[1] = new ReportParameter("DateTo", RetailSalesAndMarginDrillDownReport.Count > 0 ? RetailSalesAndMarginDrillDownReport[0].DateTo : string.Empty, false);
                    param[2] = new ReportParameter("CentreName", RetailSalesAndMarginDrillDownReport.Count > 0 ? RetailSalesAndMarginDrillDownReport[0].CentreName : string.Empty, false);
                    param[3] = new ReportParameter("GranularityName", RetailSalesAndMarginDrillDownReport.Count > 0 ? RetailSalesAndMarginDrillDownReport[0].GranularityName : string.Empty, false);
                    rvRetailSalesAndMarginDrillDownReport.LocalReport.SetParameters(param);
                    
                    rvRetailSalesAndMarginDrillDownReport.LocalReport.Refresh();
                    rvRetailSalesAndMarginDrillDownReport.Visible = true;
                }
            }
            rvRetailSalesAndMarginDrillDownReport.Drillthrough += new DrillthroughEventHandler(rvRetailSalesAndMarginDrillDownReport_Drillthrough);
        }
        public void rvRetailSalesAndMarginDrillDownReport_Drillthrough(object sender, DrillthroughEventArgs e)
        {
            /*Collect report parameter from drillthrough report*/
            ReportParameterInfoCollection DrillThroughValues = e.Report.GetParameters();
            // Type parameterName = Type.Parse(DrillThroughValues[1].Values[0].ToString());

            if (DrillThroughValues[0].Name == "GeneralUnitsId" && DrillThroughValues[1].Name == "GeneralUnitsName")
            {
                RetailSalesAndMarginDrillDownReport = controller.GetGroupDescriptionList(Convert.ToString(DrillThroughValues[0].Values[0].ToString()), Convert.ToString(DrillThroughValues[1].Values[0].ToString()));

                /*Bind data source with report*/
                LocalReport localReport = (LocalReport)e.Report;
                localReport.DataSources.Clear();
                localReport.DataSources.Add(new ReportDataSource("RetailDrillDownReportDataSet", RetailSalesAndMarginDrillDownReport));
                localReport.EnableHyperlinks = true;

                /*Add parameter to the report if report have paramerter*/
                List<ReportParameter> parameters = new List<ReportParameter>();
                parameters.Add(new ReportParameter("DateFrom", RetailSalesAndMarginDrillDownReport.Count > 0 ? RetailSalesAndMarginDrillDownReport[0].DateFrom : string.Empty, false));
                parameters.Add(new ReportParameter("CentreName", RetailSalesAndMarginDrillDownReport.Count > 0 ? RetailSalesAndMarginDrillDownReport[0].CentreName : string.Empty, false));
                parameters.Add(new ReportParameter("GeneralUnitsName", RetailSalesAndMarginDrillDownReport.Count > 0 ? RetailSalesAndMarginDrillDownReport[0].GeneralUnitsName : string.Empty, false));
                parameters.Add(new ReportParameter("GranularityName", RetailSalesAndMarginDrillDownReport.Count > 0 ? RetailSalesAndMarginDrillDownReport[0].GranularityName : string.Empty, false));
                parameters.Add(new ReportParameter("DateTo", RetailSalesAndMarginDrillDownReport.Count > 0 ? RetailSalesAndMarginDrillDownReport[0].DateTo : string.Empty, false));
                localReport.SetParameters(parameters);
                localReport.Refresh();
            }
            
            else if (DrillThroughValues[0].Name == "MarchandiseGroupCode")
            {
                RetailSalesAndMarginDrillDownReport = controller.GetMerchantiseDepartmentList(Convert.ToString(DrillThroughValues[0].Values[0].ToString()));

                /*Bind data source with report*/
                LocalReport localReport = (LocalReport)e.Report;
                localReport.DataSources.Clear();
                localReport.DataSources.Add(new ReportDataSource("SalesAndMarginDataSetNew1", RetailSalesAndMarginDrillDownReport));
                localReport.EnableHyperlinks = true;

                /*Add parameter to the report if report have paramerter*/
                List<ReportParameter> parameters = new List<ReportParameter>();
                parameters.Add(new ReportParameter("MarchandiseGroupCode", DrillThroughValues[0].Values[0].ToString()));
                parameters.Add(new ReportParameter("DateFrom", RetailSalesAndMarginDrillDownReport.Count > 0 ? RetailSalesAndMarginDrillDownReport[0].DateFrom : string.Empty, false));
               parameters.Add(new ReportParameter("CentreName", RetailSalesAndMarginDrillDownReport.Count > 0 ? RetailSalesAndMarginDrillDownReport[0].CentreName : string.Empty, false));
                parameters.Add(new ReportParameter("GeneralUnitsName", RetailSalesAndMarginDrillDownReport.Count > 0 ? RetailSalesAndMarginDrillDownReport[0].GeneralUnitsName : string.Empty, false));
                parameters.Add(new ReportParameter("GranularityName", RetailSalesAndMarginDrillDownReport.Count > 0 ? RetailSalesAndMarginDrillDownReport[0].GranularityName : string.Empty, false));
                parameters.Add(new ReportParameter("DateTo", RetailSalesAndMarginDrillDownReport.Count > 0 ? RetailSalesAndMarginDrillDownReport[0].DateTo : string.Empty, false));
                localReport.SetParameters(parameters);
                localReport.Refresh();
            }
            else if (DrillThroughValues[0].Name == "MerchantiseDepartmentCode")
            {
                RetailSalesAndMarginDrillDownReport = controller.GetMerchantiseCategoryList(Convert.ToString(DrillThroughValues[0].Values[0].ToString()));

                /*Bind data source with report*/
                LocalReport localReport = (LocalReport)e.Report;
                localReport.DataSources.Clear();
                localReport.DataSources.Add(new ReportDataSource("SalesAndMarginDataSetNew2", RetailSalesAndMarginDrillDownReport));
                localReport.EnableHyperlinks = true;

                /*Add parameter to the report if report have paramerter*/
                List<ReportParameter> parameters = new List<ReportParameter>();
                parameters.Add(new ReportParameter("MerchantiseDepartmentCode", DrillThroughValues[0].Values[0].ToString()));
                parameters.Add(new ReportParameter("DateFrom", RetailSalesAndMarginDrillDownReport.Count > 0 ? RetailSalesAndMarginDrillDownReport[0].DateFrom : string.Empty, false));
                parameters.Add(new ReportParameter("CentreName", RetailSalesAndMarginDrillDownReport.Count > 0 ? RetailSalesAndMarginDrillDownReport[0].CentreName : string.Empty, false));
                parameters.Add(new ReportParameter("GeneralUnitsName", RetailSalesAndMarginDrillDownReport.Count > 0 ? RetailSalesAndMarginDrillDownReport[0].GeneralUnitsName : string.Empty, false));
                parameters.Add(new ReportParameter("GranularityName", RetailSalesAndMarginDrillDownReport.Count > 0 ? RetailSalesAndMarginDrillDownReport[0].GranularityName : string.Empty, false));
                parameters.Add(new ReportParameter("DateTo", RetailSalesAndMarginDrillDownReport.Count > 0 ? RetailSalesAndMarginDrillDownReport[0].DateTo : string.Empty, false));
                localReport.SetParameters(parameters);
                localReport.Refresh();
            }
            else if (DrillThroughValues[0].Name == "MerchantiseCategoryCode")
            {
                RetailSalesAndMarginDrillDownReport = controller.GetMerchantiseSubCategoryList(Convert.ToString(DrillThroughValues[0].Values[0].ToString()));

                /*Bind data source with report*/
                LocalReport localReport = (LocalReport)e.Report;
                localReport.DataSources.Clear();
                localReport.DataSources.Add(new ReportDataSource("SalesAndMarginDataSetNew3", RetailSalesAndMarginDrillDownReport));
                localReport.EnableHyperlinks = true;

                /*Add parameter to the report if report have paramerter*/
                List<ReportParameter> parameters = new List<ReportParameter>();
                parameters.Add(new ReportParameter("MerchantiseCategoryCode", DrillThroughValues[0].Values[0].ToString()));
                parameters.Add(new ReportParameter("DateFrom", RetailSalesAndMarginDrillDownReport.Count > 0 ? RetailSalesAndMarginDrillDownReport[0].DateFrom : string.Empty, false));
                parameters.Add(new ReportParameter("CentreName", RetailSalesAndMarginDrillDownReport.Count > 0 ? RetailSalesAndMarginDrillDownReport[0].CentreName : string.Empty, false));
                parameters.Add(new ReportParameter("GeneralUnitsName", RetailSalesAndMarginDrillDownReport.Count > 0 ? RetailSalesAndMarginDrillDownReport[0].GeneralUnitsName : string.Empty, false));
                parameters.Add(new ReportParameter("GranularityName", RetailSalesAndMarginDrillDownReport.Count > 0 ? RetailSalesAndMarginDrillDownReport[0].GranularityName : string.Empty, false));
                parameters.Add(new ReportParameter("DateTo", RetailSalesAndMarginDrillDownReport.Count > 0 ? RetailSalesAndMarginDrillDownReport[0].DateTo : string.Empty, false));
                localReport.SetParameters(parameters);
                localReport.Refresh();
            }
            else if (DrillThroughValues[0].Name == "MarchandiseSubCatgoryCode")
            {
                RetailSalesAndMarginDrillDownReport = controller.GetMerchantiseBaseCategoryList(Convert.ToString(DrillThroughValues[0].Values[0].ToString()));

                /*Bind data source with report*/
                LocalReport localReport = (LocalReport)e.Report;
                localReport.DataSources.Clear();
                localReport.DataSources.Add(new ReportDataSource("SalesAndMarginDataSetNew4", RetailSalesAndMarginDrillDownReport));
                localReport.EnableHyperlinks = true;

                /*Add parameter to the report if report have paramerter*/
                List<ReportParameter> parameters = new List<ReportParameter>();
                parameters.Add(new ReportParameter("MarchandiseSubCatgoryCode", DrillThroughValues[0].Values[0].ToString()));
                parameters.Add(new ReportParameter("DateFrom", RetailSalesAndMarginDrillDownReport.Count > 0 ? RetailSalesAndMarginDrillDownReport[0].DateFrom : string.Empty, false));
                parameters.Add(new ReportParameter("CentreName", RetailSalesAndMarginDrillDownReport.Count > 0 ? RetailSalesAndMarginDrillDownReport[0].CentreName : string.Empty, false));
                parameters.Add(new ReportParameter("GeneralUnitsName", RetailSalesAndMarginDrillDownReport.Count > 0 ? RetailSalesAndMarginDrillDownReport[0].GeneralUnitsName : string.Empty, false));
                parameters.Add(new ReportParameter("GranularityName", RetailSalesAndMarginDrillDownReport.Count > 0 ? RetailSalesAndMarginDrillDownReport[0].GranularityName : string.Empty, false));
                parameters.Add(new ReportParameter("DateTo", RetailSalesAndMarginDrillDownReport.Count > 0 ? RetailSalesAndMarginDrillDownReport[0].DateTo : string.Empty, false));
                localReport.SetParameters(parameters);
                localReport.Refresh();
            }
            else if (DrillThroughValues[0].Name == "MarchandiseBaseCatgoryCode") 
            {
                RetailSalesAndMarginDrillDownReport = controller.GettemDescriptionList(Convert.ToString(DrillThroughValues[0].Values[0].ToString()));

                /*Bind data source with report*/
                LocalReport localReport = (LocalReport)e.Report;
                localReport.DataSources.Clear();
                localReport.DataSources.Add(new ReportDataSource("DataSet8", RetailSalesAndMarginDrillDownReport));
                localReport.EnableHyperlinks = true;               

                /*Add parameter to the report if report have paramerter*/
                List<ReportParameter> parameters = new List<ReportParameter>();
                parameters.Add(new ReportParameter("MarchandiseBaseCatgoryCode", DrillThroughValues[0].Values[0].ToString()));
                parameters.Add(new ReportParameter("DateFrom", RetailSalesAndMarginDrillDownReport.Count > 0 ? RetailSalesAndMarginDrillDownReport[0].DateFrom : string.Empty, false));
                parameters.Add(new ReportParameter("CentreName", RetailSalesAndMarginDrillDownReport.Count > 0 ? RetailSalesAndMarginDrillDownReport[0].CentreName : string.Empty, false));
                parameters.Add(new ReportParameter("GeneralUnitsName", RetailSalesAndMarginDrillDownReport.Count > 0 ? RetailSalesAndMarginDrillDownReport[0].GeneralUnitsName : string.Empty, false));
                parameters.Add(new ReportParameter("GranularityName", RetailSalesAndMarginDrillDownReport.Count > 0 ? RetailSalesAndMarginDrillDownReport[0].GranularityName : string.Empty, false));
                parameters.Add(new ReportParameter("DateTo", RetailSalesAndMarginDrillDownReport.Count > 0 ? RetailSalesAndMarginDrillDownReport[0].DateTo : string.Empty, false));
                localReport.SetParameters(parameters);
                localReport.Refresh();
            }
        }
    </script>
</head>
<body>
    <form runat="server">
        <div id="MainDiv" runat="server">
            <div id="categoryPrint">
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <rsweb:ReportViewer ID="rvRetailSalesAndMarginDrillDownReport" runat="server" AsyncRendering="False" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="" Width="" SizeToReportContent="True">
                    <LocalReport ReportEmbeddedResource="AMS.Web.UI.Report.Inventory_1.RetailSalesAndMarginDrillDownReport_GroupDescriptionList.rdlc">
                        <DataSources>
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet1" />
                        </DataSources>
                    </LocalReport>
                </rsweb:ReportViewer>
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData" TypeName="DeveloperDBDataSet5TableAdapters.TBL_RetailSalesAndMarginDrillDownReportTableAdapter"></asp:ObjectDataSource>
            </div>
        </div>
        <div id="NoRecordDiv" runat="server" style="text-align: center;">
            <b>No Record Found</b>
        </div>
    </form>
</body>
</html>
