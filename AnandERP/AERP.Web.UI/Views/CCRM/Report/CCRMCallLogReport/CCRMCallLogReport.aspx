<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>MIF Report</title>
    <script runat="server">

        AERP.Web.UI.Controllers.CCRMCallLogReportController controller = new AERP.Web.UI.Controllers.CCRMCallLogReportController();

        protected void Page_PreInit(object sender, EventArgs e)
        {
            Context.Handler = this.Page;
        }

        void Page_Load(object sender, EventArgs e)
        {
            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            scriptManager.RegisterPostBackControl(this.rvCCRMCallLogReport);
            if (!IsPostBack)
            {
                rvCCRMCallLogReport.ProcessingMode = ProcessingMode.Local;
                List<AERP.DTO.CCRMCallLogReport> CCRMCallLogReport = null;
                //List<AERP.DTO.OrganisationStudyCentreMaster> OrganisationStudyCentreMasterDetails = null;

                if (Request.RequestType == "POST")
                { 
                CCRMCallLogReport = controller.GetCallLogList();
                 }

                if (CCRMCallLogReport == null)
                {
                    MainDiv.Visible = false;
                    NoRecordDiv.Visible = true;
                }
                else
                {
                    MainDiv.Visible = true;
                    NoRecordDiv.Visible = false;
                    rvCCRMCallLogReport.LocalReport.ReportPath = Server.MapPath("~/Report/CCRM/CCRMCallLogReport.rdlc");
                    rvCCRMCallLogReport.LocalReport.DataSources.Clear();//collection Of Reports

                    ReportDataSource rdc = new ReportDataSource();
                    rdc.Name = "CCRMCallLogReportDataSet1";//Data Set Name
                    rdc.Value = CCRMCallLogReport;                //DTO object
                    rvCCRMCallLogReport.LocalReport.DataSources.Add(rdc);

                    ////ReportDataSource rdc2 = new ReportDataSource();
                    ////rdc2.Name = "StudyCentrePrintingFormat";
                    ////rdc2.Value = OrganisationStudyCentreMasterDetails;
                    ////rvCCRMCallLogReport.LocalReport.DataSources.Add(rdc2);



                    rvCCRMCallLogReport.LocalReport.Refresh();
                    rvCCRMCallLogReport.Visible = true;
                }
            }

        }

    </script>
    <style type="text/css">
        #categoryPrint {
            width: 2003px;
        }
    </style>
</head>
<body>
    <form runat="server">
        <div id="MainDiv" runat="server">
            <div id="categoryPrint">
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

                <rsweb:ReportViewer ID="rvCCRMCallLogReport" runat="server" AsyncRendering="False" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="" Width="" SizeToReportContent="True">
                    <LocalReport ReportEmbeddedResource="AERP.Web.UI.Report.CCRM.CCRMCallLogReport.rdlc">
                        <DataSources>
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="CCRMCallLogReportDataSet1" />
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSource2" Name="StudyCentrePrintingFormat" />
                        </DataSources>
                    </LocalReport>
                </rsweb:ReportViewer>

              
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData" TypeName="CCRMCallLogReportDataSet1TableAdapters.CCRMCallLogReportTableAdapter"></asp:ObjectDataSource>

            </div>

        </div>
        <div id="NoRecordDiv" runat="server" style="text-align: center;">

            <b>No Record Found</b>

        </div>
       
    </form>
</body>
</html>


