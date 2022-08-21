<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>


<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>Inventory Item Price Report</title>
    <script runat="server">

        AERP.Web.UI.Controllers.ContractSalaryBonusReportController controller = new AERP.Web.UI.Controllers.ContractSalaryBonusReportController();

        protected void Page_PreInit(object sender, EventArgs e)
        {
            Context.Handler = this.Page;
        }
        void Page_Load(object sender, EventArgs e)
        {
            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            scriptManager.RegisterPostBackControl(this.rvContractSalaryBonusReport);
            if (!IsPostBack)
            {
                rvContractSalaryBonusReport.ProcessingMode = ProcessingMode.Local;
                List<AERP.DTO.ContractSalaryBonusReport> ContractSalaryBonusReport = null;
                List<AERP.DTO.OrganisationStudyCentreMaster> OrganisationStudyCentreMasterDetails = null;
                ContractSalaryBonusReport = controller.GetContractSalaryBonusReportList();

                if (ContractSalaryBonusReport.Count == 0)
                {
                    MainDiv.Visible = false;
                    NoRecordDiv.Visible = true;
                }
                else
                {
                    MainDiv.Visible = true;
                    NoRecordDiv.Visible = false;
                    rvContractSalaryBonusReport.LocalReport.ReportPath = Server.MapPath("~/Report/Contract/ContractSalaryBonusReport.rdlc");

                    rvContractSalaryBonusReport.LocalReport.DataSources.Clear();//collection Of Reports

                    ReportDataSource rdc = new ReportDataSource();
                    rdc.Name = "ContractSalaryBonusReportDataSet";//Data Set Name
                    rdc.Value = ContractSalaryBonusReport;                //DTO object
                    rvContractSalaryBonusReport.LocalReport.DataSources.Add(rdc);

                    ReportParameter[] param = new ReportParameter[4];
                    param[0] = new ReportParameter("FromDate", ContractSalaryBonusReport.Count > 0 ? ContractSalaryBonusReport[0].FromDate : string.Empty, false);
                    param[1] = new ReportParameter("UptoDate", ContractSalaryBonusReport.Count > 0 ? ContractSalaryBonusReport[0].UptoDate : string.Empty, false);
                    param[2] = new ReportParameter("ContractNumber", ContractSalaryBonusReport.Count > 0 ? ContractSalaryBonusReport[0].ContractNumber : string.Empty, false);
                    param[3] = new ReportParameter("ReportTypeDisplay", ContractSalaryBonusReport.Count > 0 ? ContractSalaryBonusReport[0].ReportTypeDisplay : string.Empty, false);
                    rvContractSalaryBonusReport.LocalReport.SetParameters(param);

                    rvContractSalaryBonusReport.LocalReport.Refresh();
                    rvContractSalaryBonusReport.Visible = true;
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

                <rsweb:ReportViewer ID="rvContractSalaryBonusReport" runat="server" AsyncRendering="False" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="" Width="" SizeToReportContent="True">
                    <LocalReport ReportEmbeddedResource="AERP.Web.UI.Report.Contract.ContractSalaryBonusReport.rdlc">
                        <DataSources>
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="ContractSalaryBonusReportDataSet" />
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSource2" Name="StudyCentrePrintingFormat" />
                        </DataSources>
                    </LocalReport>
                </rsweb:ReportViewer>


                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData" TypeName="ContractSalaryBonusReportListDataSetTableAdapters.InventoryContractSalaryBonusReportListTableAdapter"></asp:ObjectDataSource>

            </div>

        </div>
        <div id="NoRecordDiv" runat="server" style="text-align: center;">

            <b>No Record Found</b>

        </div>

    </form>
</body>
</html>


