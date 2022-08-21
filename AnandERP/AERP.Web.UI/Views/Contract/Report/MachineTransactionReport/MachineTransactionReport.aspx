<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>


<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>Inventory Item Price Report</title>
    <script runat="server">

        AERP.Web.UI.Controllers.MachineTransactionReportController controller = new AERP.Web.UI.Controllers.MachineTransactionReportController();

        protected void Page_PreInit(object sender, EventArgs e)
        {
            Context.Handler = this.Page;
        }
        void Page_Load(object sender, EventArgs e)
        {
            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            scriptManager.RegisterPostBackControl(this.rvMachineTransactionReport);
            if (!IsPostBack)
            {
                rvMachineTransactionReport.ProcessingMode = ProcessingMode.Local;
                List<AERP.DTO.MachineTransactionReport> MachineTransactionReport = null;
                List<AERP.DTO.OrganisationStudyCentreMaster> OrganisationStudyCentreMasterDetails = null;
                MachineTransactionReport = controller.GetMachineTransactionReportList();

                if (MachineTransactionReport.Count == 0)
                {
                    MainDiv.Visible = false;
                    NoRecordDiv.Visible = true;
                }
                else
                {
                    MainDiv.Visible = true;
                    NoRecordDiv.Visible = false;
                    rvMachineTransactionReport.LocalReport.ReportPath = Server.MapPath("~/Report/Contract/MachineTransactionReport.rdlc");
                    rvMachineTransactionReport.LocalReport.DataSources.Clear();//collection Of Reports

                    ReportDataSource rdc = new ReportDataSource();
                    rdc.Name = "MachineTransactionReportDataSet";//Data Set Name
                    rdc.Value = MachineTransactionReport;                //DTO object
                    rvMachineTransactionReport.LocalReport.DataSources.Add(rdc);

                    ReportParameter[] param = new ReportParameter[2];
                    param[0] = new ReportParameter("MachineMasterName", MachineTransactionReport.Count > 0 ? MachineTransactionReport[0].MachineMasterName : string.Empty, false);
                    param[1] = new ReportParameter("PurchaseDate", MachineTransactionReport.Count > 0 ? MachineTransactionReport[0].PurchaseDate: string.Empty, false);
                    rvMachineTransactionReport.LocalReport.SetParameters(param);

                    rvMachineTransactionReport.LocalReport.Refresh();
                    rvMachineTransactionReport.Visible = true;
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

                <rsweb:ReportViewer ID="rvMachineTransactionReport" runat="server" AsyncRendering="False" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="" Width="" SizeToReportContent="True">
                    <LocalReport ReportEmbeddedResource="AERP.Web.UI.Report.Contract.MachineTransactionReport.rdlc">
                        <DataSources>
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="MachineTransactionReportDataSet" />
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSource2" Name="StudyCentrePrintingFormat" />
                        </DataSources>
                    </LocalReport>
                </rsweb:ReportViewer>

              
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData" TypeName="MachineTransactionReportListDataSetTableAdapters.InventoryMachineTransactionReportListTableAdapter"></asp:ObjectDataSource>

            </div>

        </div>
        <div id="NoRecordDiv" runat="server" style="text-align: center;">

            <b>No Record Found</b>

        </div>
       
    </form>
</body>
</html>


