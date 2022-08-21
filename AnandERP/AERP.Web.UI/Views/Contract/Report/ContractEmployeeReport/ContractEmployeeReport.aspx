<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>


<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>Inventory Item Price Report</title>
    <script runat="server">

        AERP.Web.UI.Controllers.ContractEmployeeReportController controller = new AERP.Web.UI.Controllers.ContractEmployeeReportController();

        protected void Page_PreInit(object sender, EventArgs e)
        {
            Context.Handler = this.Page;
        }
        void Page_Load(object sender, EventArgs e)
        {
            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            scriptManager.RegisterPostBackControl(this.rvContractEmployeeReport);
            if (!IsPostBack)
            {
                rvContractEmployeeReport.ProcessingMode = ProcessingMode.Local;
                List<AERP.DTO.ContractEmployeeReport> ContractEmployeeReport = null;
                List<AERP.DTO.OrganisationStudyCentreMaster> OrganisationStudyCentreMasterDetails = null;
                ContractEmployeeReport = controller.GetContractEmployeeReportList();

                if (ContractEmployeeReport.Count == 0)
                {
                    MainDiv.Visible = false;
                    NoRecordDiv.Visible = true;
                }
                else
                {
                    MainDiv.Visible = true;
                    NoRecordDiv.Visible = false;
                    rvContractEmployeeReport.LocalReport.ReportPath = Server.MapPath("~/Report/Contract/ContractEmployeeReport.rdlc");
                    rvContractEmployeeReport.LocalReport.DataSources.Clear();//collection Of Reports

                    ReportDataSource rdc = new ReportDataSource();
                    rdc.Name = "ContractEmployeeReportDataSet1";//Data Set Name
                    rdc.Value = ContractEmployeeReport;                //DTO object
                    rvContractEmployeeReport.LocalReport.DataSources.Add(rdc);

                    ReportParameter[] param = new ReportParameter[1];
                    param[0] = new ReportParameter("CentreName", ContractEmployeeReport.Count > 0 ? ContractEmployeeReport[0].CentreName : string.Empty, false);
                    rvContractEmployeeReport.LocalReport.SetParameters(param);

                    rvContractEmployeeReport.LocalReport.Refresh();
                    rvContractEmployeeReport.Visible = true;
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

                <rsweb:ReportViewer ID="rvContractEmployeeReport" runat="server" AsyncRendering="False" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="" Width="" SizeToReportContent="True">
                    <LocalReport ReportEmbeddedResource="AERP.Web.UI.Report.Contract.ContractEmployeeReport.rdlc">
                        <DataSources>
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="ContractEmployeeReportDataSet1" />
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSource2" Name="StudyCentrePrintingFormat" />
                        </DataSources>
                    </LocalReport>
                </rsweb:ReportViewer>

              
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData" TypeName="ContractEmployeeReportListDataSet1TableAdapters.InventoryContractEmployeeReportListTableAdapter"></asp:ObjectDataSource>

            </div>

        </div>
        <div id="NoRecordDiv" runat="server" style="text-align: center;">

            <b>No Record Found</b>

        </div>
       
    </form>
</body>
</html>


