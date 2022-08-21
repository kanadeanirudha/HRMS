<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>


<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>Inventory Item Price Report</title>
    <script runat="server">

        AERP.Web.UI.Controllers.EmployeeFormIIWagesSheetReportController controller = new AERP.Web.UI.Controllers.EmployeeFormIIWagesSheetReportController();

        protected void Page_PreInit(object sender, EventArgs e)
        {
            Context.Handler = this.Page;
        }
        void Page_Load(object sender, EventArgs e)
        {
            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            scriptManager.RegisterPostBackControl(this.rvEmployeeFormIIWagesSheetReport);
            if (!IsPostBack)
            {
                rvEmployeeFormIIWagesSheetReport.ProcessingMode = ProcessingMode.Local;
                List<AERP.DTO.EmployeeFormIIWagesSheetReport> EmployeeFormIIWagesSheetReport = null;
                List<AERP.DTO.OrganisationStudyCentreMaster> OrganisationStudyCentreMasterDetails = null;



                EmployeeFormIIWagesSheetReport = controller.GetEmployeeFormIIWagesSheetReportList();


                if (EmployeeFormIIWagesSheetReport == null)
                {
                    MainDiv.Visible = false;
                    NoRecordDiv.Visible = true;
                }
                else
                {
                    MainDiv.Visible = true;
                    NoRecordDiv.Visible = false;
                    rvEmployeeFormIIWagesSheetReport.LocalReport.ReportPath = Server.MapPath("~/Report/Contract/EmployeeFormIIWagesSheetReport.rdlc");
                    rvEmployeeFormIIWagesSheetReport.LocalReport.DataSources.Clear();//collection Of Reports

                    ReportDataSource rdc = new ReportDataSource();
                    rdc.Name = "EmployeeFormIIWagesSheetReportDataSet1";//Data Set Name
                    rdc.Value = EmployeeFormIIWagesSheetReport;                //DTO object
                    rvEmployeeFormIIWagesSheetReport.LocalReport.DataSources.Add(rdc);

                    //ReportParameter[] param = new ReportParameter[8];
                    //param[0] = new ReportParameter("EmployeeName", EmployeeFormIIWagesSheetReport.Count > 0 ? EmployeeFormIIWagesSheetReport[0].EmployeeName : string.Empty, false);
                    //param[1] = new ReportParameter("CentreAdress", EmployeeFormIIWagesSheetReport.Count > 0 ? EmployeeFormIIWagesSheetReport[0].CentreAdress : string.Empty, false);
                    //param[2] = new ReportParameter("CentreName", EmployeeFormIIWagesSheetReport.Count > 0 ? EmployeeFormIIWagesSheetReport[0].CentreName : string.Empty, false);
                    //param[3] = new ReportParameter("EmployeeFathersFullName", EmployeeFormIIWagesSheetReport.Count > 0 ? EmployeeFormIIWagesSheetReport[0].EmployeeFathersFullName : string.Empty, false);
                    //param[4] = new ReportParameter("PFAccountNmber", EmployeeFormIIWagesSheetReport.Count > 0 ? EmployeeFormIIWagesSheetReport[0].PFAccountNmber : string.Empty, false);
                    //param[5] = new ReportParameter("RateOfContribution", EmployeeFormIIWagesSheetReport.Count > 0 ? Convert.ToString(EmployeeFormIIWagesSheetReport[0].RateOfContribution):  string.Empty, false);
                    //param[6] = new ReportParameter("FromDate", EmployeeFormIIWagesSheetReport.Count > 0 ? Convert.ToString(EmployeeFormIIWagesSheetReport[0].FromDate):  string.Empty, false);
                    //param[7] = new ReportParameter("UptoDate", EmployeeFormIIWagesSheetReport.Count > 0 ? Convert.ToString(EmployeeFormIIWagesSheetReport[0].UptoDate):  string.Empty, false);
                    //rvEmployeeFormIIWagesSheetReport.LocalReport.SetParameters(param);

                    rvEmployeeFormIIWagesSheetReport.LocalReport.Refresh();
                    rvEmployeeFormIIWagesSheetReport.Visible = true;
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

                <rsweb:ReportViewer ID="rvEmployeeFormIIWagesSheetReport" runat="server" AsyncRendering="False" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="" Width="" SizeToReportContent="True">
                    <LocalReport ReportEmbeddedResource="AERP.Web.UI.Report.Contract.EmployeeFormIIWagesSheetReport.rdlc">
                        <DataSources>
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="EmployeeFormIIWagesSheetReportDataSet1" />
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSource2" Name="StudyCentrePrintingFormat" />
                        </DataSources>
                    </LocalReport>
                </rsweb:ReportViewer>

              
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData" TypeName="EmployeeFormIIWagesSheetReportListDataSet1TableAdapters.InventoryEmployeeFormIIWagesSheetReportListTableAdapter"></asp:ObjectDataSource>

            </div>

        </div>
        <div id="NoRecordDiv" runat="server" style="text-align: center;">

            <b>No Record Found</b>

        </div>
       
    </form>
</body>
</html>


