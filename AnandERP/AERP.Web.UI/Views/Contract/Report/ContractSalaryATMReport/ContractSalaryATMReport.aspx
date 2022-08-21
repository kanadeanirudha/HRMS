<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>


<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>Inventory Item Price Report</title>
    <script runat="server">

        AERP.Web.UI.Controllers.ContractSalaryATMReportController controller = new AERP.Web.UI.Controllers.ContractSalaryATMReportController();

        protected void Page_PreInit(object sender, EventArgs e)
        {
            Context.Handler = this.Page;
        }
        void Page_Load(object sender, EventArgs e)
        {
            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            scriptManager.RegisterPostBackControl(this.rvContractSalaryATMReport);
            if (!IsPostBack)
            {
                rvContractSalaryATMReport.ProcessingMode = ProcessingMode.Local;
                List<AERP.DTO.ContractSalaryATMReport> ContractSalaryATMReport = null;
                List<AERP.DTO.OrganisationStudyCentreMaster> OrganisationStudyCentreMasterDetails = null;
                ContractSalaryATMReport = controller.GetContractSalaryATMReportList();

                if (ContractSalaryATMReport.Count == 0)
                {
                    MainDiv.Visible = false;
                    NoRecordDiv.Visible = true;
                }
                else
                {
                    MainDiv.Visible = true;
                    NoRecordDiv.Visible = false;

                    if (ContractSalaryATMReport.Count > 0 && ContractSalaryATMReport[0].ReportType == 2 && ContractSalaryATMReport[0].BankMasterID == 1)
                    {
                        rvContractSalaryATMReport.LocalReport.ReportPath = Server.MapPath("~/Report/Contract/ContractSalaryATMReportPNB.rdlc");
                    }
                    else if (ContractSalaryATMReport.Count > 0 && ContractSalaryATMReport[0].ReportType == 2 && ContractSalaryATMReport[0].BankMasterID == 2)
                    {
                        rvContractSalaryATMReport.LocalReport.ReportPath = Server.MapPath("~/Report/Contract/ContractSalaryATMReportCanara.rdlc");
                    }
                    else
                    {
                        rvContractSalaryATMReport.LocalReport.ReportPath = Server.MapPath("~/Report/Contract/ContractSalaryATMReportCash.rdlc");
                    }
                    rvContractSalaryATMReport.LocalReport.DataSources.Clear();//collection Of Reports

                    ReportDataSource rdc = new ReportDataSource();
                    rdc.Name = "ContractSalaryATMReportDataSet";//Data Set Name
                    rdc.Value = ContractSalaryATMReport;                //DTO object
                    rvContractSalaryATMReport.LocalReport.DataSources.Add(rdc);

                    ReportParameter[] param = new ReportParameter[3];
                    param[0] = new ReportParameter("CentreName", ContractSalaryATMReport.Count > 0 ? ContractSalaryATMReport[0].CentreName : string.Empty, false);
                    param[1] = new ReportParameter("BankName", ContractSalaryATMReport.Count > 0 ? (ContractSalaryATMReport[0].ReportType == 1 ? "Cash List" : ContractSalaryATMReport[0].BankName) : string.Empty, false);
                    param[2] = new ReportParameter("BranchName", ContractSalaryATMReport.Count > 0 ? ContractSalaryATMReport[0].SearchForDisplay : string.Empty, false);
                    rvContractSalaryATMReport.LocalReport.SetParameters(param);

                    rvContractSalaryATMReport.LocalReport.Refresh();
                    rvContractSalaryATMReport.Visible = true;
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

                <rsweb:ReportViewer ID="rvContractSalaryATMReport" runat="server" AsyncRendering="False" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="" Width="" SizeToReportContent="True">
                    <LocalReport ReportEmbeddedResource="AERP.Web.UI.Report.Contract.ContractSalaryATMReport.rdlc">
                        <DataSources>
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="ContractSalaryATMReportDataSet" />
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSource2" Name="StudyCentrePrintingFormat" />
                        </DataSources>
                    </LocalReport>
                </rsweb:ReportViewer>


                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData" TypeName="ContractSalaryATMReportListDataSetTableAdapters.InventoryContractSalaryATMReportListTableAdapter"></asp:ObjectDataSource>

            </div>

        </div>
        <div id="NoRecordDiv" runat="server" style="text-align: center;">

            <b>No Record Found</b>

        </div>

    </form>
</body>
</html>


