<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>Inventory Item Price Report</title>
    <script runat="server">
   
        AERP.Web.UI.Controllers.GeneralItemMissingExceptionReportController controller = new AERP.Web.UI.Controllers.GeneralItemMissingExceptionReportController();

        protected void Page_PreInit(object sender, EventArgs e)
        {
            Context.Handler = this.Page;
        }
        void Page_Load(object sender, EventArgs e)
        {
            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            scriptManager.RegisterPostBackControl(this.rvGeneralItemMissingExceptionReport);
            if (!IsPostBack)
            {
                rvGeneralItemMissingExceptionReport.ProcessingMode = ProcessingMode.Local;
                List<AERP.DTO.InventoryReport> InventoryReport = null;
                //List<AERP.DTO.OrganisationStudyCentreMaster> OrganisationStudyCentreMasterDetails = null;

                InventoryReport = controller.GetMissingExceptionReportList("All");

                if (InventoryReport == null)
                {
                    MainDiv.Visible = false;
                    NoRecordDiv.Visible = true;
                }
                else
                {
                    MainDiv.Visible = true;
                    NoRecordDiv.Visible = false;
                    rvGeneralItemMissingExceptionReport.LocalReport.ReportPath = Server.MapPath("~/Report/Inventory/GeneralItemMissingExceptionReport.rdlc");
                    rvGeneralItemMissingExceptionReport.LocalReport.DataSources.Clear();//collection Of Reports

                    ReportDataSource rdc = new ReportDataSource();
                    rdc.Name = "GeneralItemMissingExceptionReport1DataSet1";//Data Set Name
                    rdc.Value = InventoryReport;                //DTO object
                    rvGeneralItemMissingExceptionReport.LocalReport.DataSources.Add(rdc);

                    //ReportParameter[] param = new ReportParameter[1];
                    //param[0] = new ReportParameter("CentreName", InventoryReport.Count > 0 ? InventoryReport[0].CentreName : string.Empty, false);
                    //rvGeneralItemMissingExceptionReport.LocalReport.SetParameters(param);

                    rvGeneralItemMissingExceptionReport.LocalReport.Refresh();
                    rvGeneralItemMissingExceptionReport.Visible = true;
                }
            }

        }
        
    </script>
</head>
<body>
    <form runat="server">
        <div id="MainDiv" runat="server">
            <div id="categoryPrint">
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

                <rsweb:ReportViewer ID="rvGeneralItemMissingExceptionReport" runat="server" AsyncRendering="False" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="" Width="" SizeToReportContent="True">
                    <LocalReport ReportEmbeddedResource="AERP.Web.UI.Report.Inventory.GeneralItemMissingExceptionReport.rdlc">
                        <DataSources>
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="GeneralItemMissingExceptionReport1DataSet3" />
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSource2" Name="StudyCentrePrintingFormat" />
                        </DataSources>
                    </LocalReport>
                </rsweb:ReportViewer>


                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData" TypeName="GeneralItemMissingExceptionReport1DataSet1TableAdapters.GeneralItemMissingExceptionReport1DataSet1TableAdapters"></asp:ObjectDataSource>

            </div>

        </div>
        <div id="NoRecordDiv" runat="server" style="text-align: center;">

            <b>No Record Found</b>

        </div>

    </form>
</body>
</html>


