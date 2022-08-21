<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>


<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>ATTRITION Report</title>
    <script runat="server">

        AERP.Web.UI.Controllers.ATTRITIONReportController controller = new AERP.Web.UI.Controllers.ATTRITIONReportController();

        protected void Page_PreInit(object sender, EventArgs e)
        {
            Context.Handler = this.Page;
        }
        void Page_Load(object sender, EventArgs e)
        {
            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            scriptManager.RegisterPostBackControl(this.rvATTRITIONReport);
            if (!IsPostBack)
            {
                rvATTRITIONReport.ProcessingMode = ProcessingMode.Local;
                List<AERP.DTO.ATTRITIONReport> ATTRITIONReport = null;
                List<AERP.DTO.OrganisationStudyCentreMaster> OrganisationStudyCentreMasterDetails = null;



                ATTRITIONReport = controller.GetATTRITIONReportList();


                if (ATTRITIONReport == null)
                {
                    MainDiv.Visible = false;
                    NoRecordDiv.Visible = true;
                }
                else
                {
                    MainDiv.Visible = true;
                    NoRecordDiv.Visible = false;
                    rvATTRITIONReport.LocalReport.ReportPath = Server.MapPath("~/Report/Contract/ATTRITIONReport.rdlc");
                    rvATTRITIONReport.LocalReport.DataSources.Clear();//collection Of Reports

                    ReportDataSource rdc = new ReportDataSource();
                    rdc.Name = "ATTRITIONReportDataSet1";//Data Set Name
                    rdc.Value = ATTRITIONReport;                //DTO object
                    rvATTRITIONReport.LocalReport.DataSources.Add(rdc);

                    //ReportParameter[] param = new ReportParameter[8];
                    //param[0] = new ReportParameter("EmployeeName", ATTRITIONReport.Count > 0 ? ATTRITIONReport[0].EmployeeName : string.Empty, false);
                    //param[1] = new ReportParameter("CentreAdress", ATTRITIONReport.Count > 0 ? ATTRITIONReport[0].CentreAdress : string.Empty, false);
                    //param[2] = new ReportParameter("CentreName", ATTRITIONReport.Count > 0 ? ATTRITIONReport[0].CentreName : string.Empty, false);
                    //param[3] = new ReportParameter("EmployeeFathersFullName", ATTRITIONReport.Count > 0 ? ATTRITIONReport[0].EmployeeFathersFullName : string.Empty, false);
                    //param[4] = new ReportParameter("PFAccountNmber", ATTRITIONReport.Count > 0 ? ATTRITIONReport[0].PFAccountNmber : string.Empty, false);
                    //param[5] = new ReportParameter("RateOfContribution", ATTRITIONReport.Count > 0 ? Convert.ToString(ATTRITIONReport[0].RateOfContribution):  string.Empty, false);
                    //param[6] = new ReportParameter("FromDate", ATTRITIONReport.Count > 0 ? Convert.ToString(ATTRITIONReport[0].FromDate):  string.Empty, false);
                    //param[7] = new ReportParameter("UptoDate", ATTRITIONReport.Count > 0 ? Convert.ToString(ATTRITIONReport[0].UptoDate):  string.Empty, false);
                    //rvATTRITIONReport.LocalReport.SetParameters(param);

                    rvATTRITIONReport.LocalReport.Refresh();
                    rvATTRITIONReport.Visible = true;
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

                <rsweb:ReportViewer ID="rvATTRITIONReport" runat="server" AsyncRendering="False" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="" Width="" SizeToReportContent="True">
                    <LocalReport ReportEmbeddedResource="AERP.Web.UI.Report.Contract.ATTRITIONReport.rdlc">
                        <DataSources>
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="ATTRITIONReportDataSet1" />
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSource2" Name="StudyCentrePrintingFormat" />
                        </DataSources>
                    </LocalReport>
                </rsweb:ReportViewer>

              
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData" TypeName="ATTRITIONReportListDataSet1TableAdapters.InventoryATTRITIONReportListTableAdapter"></asp:ObjectDataSource>

            </div>

        </div>
        <div id="NoRecordDiv" runat="server" style="text-align: center;">

            <b>No Record Found</b>

        </div>
       
    </form>
</body>
</html>


