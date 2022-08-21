<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
  <script runat="server">
   
        AMS.Web.UI.Controllers.InventoryCurrentStockPriceDrillReportController controller = new AMS.Web.UI.Controllers.InventoryCurrentStockPriceDrillReportController();

        protected void Page_PreInit(object sender, EventArgs e)
        {
            Context.Handler = this.Page;
        }
        List<AMS.DTO.InventoryCurrentStockPriceDrillReport> InventoryCurrentStockPriceDrillReport = null;
        void Page_Load(object sender, EventArgs e)
        {
            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            scriptManager.RegisterPostBackControl(this.rvInventoryCurrentStockPriceDrillReport);

            if (!IsPostBack)
            {
                rvInventoryCurrentStockPriceDrillReport.ProcessingMode = ProcessingMode.Local;

               

                //if (Request.RequestType == "POST")
                //{
                InventoryCurrentStockPriceDrillReport = controller.GetOrganisationWiseList();
                //}

                if (InventoryCurrentStockPriceDrillReport == null)
                {
                    MainDiv.Visible = false;
                    NoRecordDiv.Visible = true;
                }
                else
                {
                    MainDiv.Visible = true;
                    NoRecordDiv.Visible = false;
                    rvInventoryCurrentStockPriceDrillReport.LocalReport.ReportPath = Server.MapPath("~/Report/Inventory_1/InventoryCurrentStockPriceDrillReportForOrganization.rdlc");
                    rvInventoryCurrentStockPriceDrillReport.LocalReport.DataSources.Clear();

                    ReportDataSource rdc = new ReportDataSource();
                    rdc.Name = "InventoryCurrentStockAmountReport";
                    rdc.Value = InventoryCurrentStockPriceDrillReport;
                    rvInventoryCurrentStockPriceDrillReport.LocalReport.DataSources.Add(rdc);
                    
                    rvInventoryCurrentStockPriceDrillReport.LocalReport.Refresh();
                    rvInventoryCurrentStockPriceDrillReport.Visible = true;
                }
            }
            rvInventoryCurrentStockPriceDrillReport.Drillthrough += new DrillthroughEventHandler(rvInventoryCurrentStockPriceDrillReport_Drillthrough);
        }
        public void rvInventoryCurrentStockPriceDrillReport_Drillthrough(object sender, DrillthroughEventArgs e)
        {
            /*Collect report parameter from drillthrough report*/
            ReportParameterInfoCollection DrillThroughValues = e.Report.GetParameters();
            if (DrillThroughValues[0].Name == "OrganisationMasterKey")
            {
                InventoryCurrentStockPriceDrillReport = controller.GetCentreWiseList(Convert.ToString(DrillThroughValues[0].Values[0].ToString()));

                /*Bind data source with report*/
                LocalReport localReport = (LocalReport)e.Report;
                localReport.DataSources.Clear();
                localReport.DataSources.Add(new ReportDataSource("DataSet1", InventoryCurrentStockPriceDrillReport));
                localReport.EnableHyperlinks = true;

                /*Add parameter to the report if report have paramerter*/
                List<ReportParameter> parameters = new List<ReportParameter>();
                parameters.Add(new ReportParameter("OrganisationMasterKey", DrillThroughValues[0].Values[0].ToString()));
                localReport.SetParameters(parameters);
                localReport.Refresh();
            }
            else if (DrillThroughValues[0].Name == "CentreCode")
            {
                InventoryCurrentStockPriceDrillReport = controller.GetStoreWiseList(Convert.ToString(DrillThroughValues[0].Values[0].ToString()));

                /*Bind data source with report*/
                LocalReport localReport = (LocalReport)e.Report;
                localReport.DataSources.Clear();
                localReport.DataSources.Add(new ReportDataSource("DataSet2", InventoryCurrentStockPriceDrillReport));
                localReport.EnableHyperlinks = true;

                /*Add parameter to the report if report have paramerter*/
                List<ReportParameter> parameters = new List<ReportParameter>();
                parameters.Add(new ReportParameter("CentreCode", DrillThroughValues[0].Values[0].ToString()));
                localReport.SetParameters(parameters);
                localReport.Refresh();
            }
            else if (DrillThroughValues[0].Name == "GeneralUnitsId")
            {
                InventoryCurrentStockPriceDrillReport = controller.GetArticleWiseList(Convert.ToString(DrillThroughValues[0].Values[0].ToString()));

                /*Bind data source with report*/
                LocalReport localReport = (LocalReport)e.Report;
                localReport.DataSources.Clear();
                localReport.DataSources.Add(new ReportDataSource("DataSet3", InventoryCurrentStockPriceDrillReport));
                localReport.EnableHyperlinks = true;

                /*Add parameter to the report if report have paramerter*/
                List<ReportParameter> parameters = new List<ReportParameter>();
                parameters.Add(new ReportParameter("GeneralUnitsId", DrillThroughValues[0].Values[0].ToString()));
                //  parameters.Add(new ReportParameter("Store", DrillThroughValues[1].Values[0].ToString()));
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
                <rsweb:ReportViewer ID="rvInventoryCurrentStockPriceDrillReport" runat="server" AsyncRendering="False" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="" Width="" SizeToReportContent="True">
                    <LocalReport ReportEmbeddedResource="AMS.Web.UI.Report.Inventory_1.InventoryCurrentStockPriceDrillReport_GroupDescriptionList.rdlc">
                        <DataSources>
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="InventoryCurrentStockAmountReport" />
                        </DataSources>
                    </LocalReport>
                </rsweb:ReportViewer>
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData" TypeName="DeveloperDBDataSet5TableAdapters.TBL_InventoryCurrentStockPriceDrillReportTableAdapter"></asp:ObjectDataSource>
            </div>
        </div>
        <div id="NoRecordDiv" runat="server" style="text-align: center;">
            <b>No Record Found</b>
        </div>
    </form>
</body>
</html>
