<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
  <script runat="server">
   
        AMS.Web.UI.Controllers.InventoryCounterDetailReportController controller = new AMS.Web.UI.Controllers.InventoryCounterDetailReportController();

        protected void Page_PreInit(object sender, EventArgs e)
        {
            Context.Handler = this.Page;
        }
        void Page_Load(object sender, EventArgs e)
        {
            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            scriptManager.RegisterPostBackControl(this.rvInventoryCounterDetailReport);
            if (!IsPostBack)
            {
                rvInventoryCounterDetailReport.ProcessingMode = ProcessingMode.Local;

                List<AMS.DTO.RetailReports> InventoryCounterDetailReport = null;

                if (Request.RequestType == "POST")
                {
                    InventoryCounterDetailReport = controller.GetInventoryCounterDetailReportList();
                }

                if (InventoryCounterDetailReport == null)
                {
                    MainDiv.Visible = false;
                    NoRecordDiv.Visible = true;
                }
                else
                {
                    MainDiv.Visible = true;
                    NoRecordDiv.Visible = false;
                    rvInventoryCounterDetailReport.LocalReport.ReportPath = Server.MapPath("~/Report/Inventory_1/InventoryCounterDetailReport.rdlc");
                    rvInventoryCounterDetailReport.LocalReport.DataSources.Clear();

                    ReportDataSource rdc = new ReportDataSource();
                    rdc.Name = "InventoryCounterReportDataSet1";
                    rdc.Value = InventoryCounterDetailReport;
                    rvInventoryCounterDetailReport.LocalReport.DataSources.Add(rdc);

                    ReportParameter[] param = new ReportParameter[1];
                    param[0] = new ReportParameter("CentreName", InventoryCounterDetailReport.Count > 0 ? InventoryCounterDetailReport[0].CentreName : string.Empty, false);
                    rvInventoryCounterDetailReport.LocalReport.SetParameters(param);
                    
                    rvInventoryCounterDetailReport.LocalReport.Refresh();
                    rvInventoryCounterDetailReport.Visible = true;
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
                <rsweb:ReportViewer ID="rvInventoryCounterDetailReport" runat="server" AsyncRendering="False" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="" Width="" SizeToReportContent="True">
                    <LocalReport ReportEmbeddedResource="AMS.Web.UI.Report.Inventory_1.InventoryCounterDetailReport.rdlc">
                        <DataSources>
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="InventoryCounterReportDataSet1" />
                        </DataSources>
                    </LocalReport>
                </rsweb:ReportViewer>
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData" TypeName="DeveloperDBDataSet5TableAdapters.TBL_InventoryCounterDetailReportTableAdapter"></asp:ObjectDataSource>
            </div>
        </div>
        <div id="NoRecordDiv" runat="server" style="text-align: center;">
            <b>No Record Found</b>
        </div>
    </form>
</body>
</html>
