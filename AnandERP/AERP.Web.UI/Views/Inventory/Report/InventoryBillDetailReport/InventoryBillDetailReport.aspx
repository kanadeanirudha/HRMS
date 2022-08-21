<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
  <script runat="server">
   
        AMS.Web.UI.Controllers.InventoryBillDetailReportController controller = new AMS.Web.UI.Controllers.InventoryBillDetailReportController();

        protected void Page_PreInit(object sender, EventArgs e)
        {
            Context.Handler = this.Page;
        }
        void Page_Load(object sender, EventArgs e)
        {
            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            scriptManager.RegisterPostBackControl(this.rvInventoryBillDetailReport);

            if (!IsPostBack)
            {
                rvInventoryBillDetailReport.ProcessingMode = ProcessingMode.Local;

                List<AMS.DTO.RetailReports> InventoryBillDetailReport = null;

                if (Request.RequestType == "POST")
                {
                    InventoryBillDetailReport = controller.GetInventoryBillDetailReportList();
                }

                if (InventoryBillDetailReport == null)
                {
                    MainDiv.Visible = false;
                    NoRecordDiv.Visible = true;
                }
                else
                {
                    MainDiv.Visible = true;
                    NoRecordDiv.Visible = false;
                    rvInventoryBillDetailReport.LocalReport.ReportPath = Server.MapPath("~/Report/Inventory_1/InventoryBillDetailReport.rdlc");
                    rvInventoryBillDetailReport.LocalReport.DataSources.Clear();

                    ReportDataSource rdc = new ReportDataSource();
                    rdc.Name = "InventoryBillReportDataSet2";
                    rdc.Value = InventoryBillDetailReport;
                    rvInventoryBillDetailReport.LocalReport.DataSources.Add(rdc);
                    rvInventoryBillDetailReport.LocalReport.Refresh();
                    rvInventoryBillDetailReport.Visible = true;
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
                <rsweb:ReportViewer ID="rvInventoryBillDetailReport" runat="server" AsyncRendering="False" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="" Width="" SizeToReportContent="True">
                    <LocalReport ReportEmbeddedResource="AMS.Web.UI.Report.Inventory_1.InventoryBillDetailReport.rdlc">
                        <DataSources>
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="InventoryBillReportDataSet2" />
                        </DataSources>
                    </LocalReport>
                </rsweb:ReportViewer>
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData" TypeName="DeveloperDBDataSet5TableAdapters.TBL_InventoryBillDetailReportTableAdapter"></asp:ObjectDataSource>
            </div>
        </div>
        <div id="NoRecordDiv" runat="server" style="text-align: center;">
            <b>No Record Found</b>
        </div>
    </form>
</body>
</html>
