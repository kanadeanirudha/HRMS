<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>MIF Report</title>
    <script runat="server">

        AERP.Web.UI.Controllers.CCRMMIFReportController controller = new AERP.Web.UI.Controllers.CCRMMIFReportController();

        protected void Page_PreInit(object sender, EventArgs e)
        {
            Context.Handler = this.Page;
        }

        void Page_Load(object sender, EventArgs e)
        {
            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            scriptManager.RegisterPostBackControl(this.rvCCRMMIFReport);
            if (!IsPostBack)
            {
                rvCCRMMIFReport.ProcessingMode = ProcessingMode.Local;
                List<AERP.DTO.CCRMMIFReport> CCRMMIFReport = null;
                //List<AERP.DTO.OrganisationStudyCentreMaster> OrganisationStudyCentreMasterDetails = null;

                if (Request.RequestType == "POST")
                { 
                CCRMMIFReport = controller.GetContractExpiryList();
                 }

                if (CCRMMIFReport == null)
                {
                    MainDiv.Visible = false;
                    NoRecordDiv.Visible = true;
                }
                else
                {
                    MainDiv.Visible = true;
                    NoRecordDiv.Visible = false;
                    rvCCRMMIFReport.LocalReport.ReportPath = Server.MapPath("~/Report/CCRM/CCRMMIFReport.rdlc");
                    rvCCRMMIFReport.LocalReport.DataSources.Clear();//collection Of Reports

                    ReportDataSource rdc = new ReportDataSource();
                    rdc.Name = "CCRMMIFReportDataSet1";//Data Set Name
                    rdc.Value = CCRMMIFReport;                //DTO object
                    rvCCRMMIFReport.LocalReport.DataSources.Add(rdc);

                    ////ReportDataSource rdc2 = new ReportDataSource();
                    ////rdc2.Name = "StudyCentrePrintingFormat";
                    ////rdc2.Value = OrganisationStudyCentreMasterDetails;
                    ////rvCCRMMIFReport.LocalReport.DataSources.Add(rdc2);



                    rvCCRMMIFReport.LocalReport.Refresh();
                    rvCCRMMIFReport.Visible = true;
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

                <rsweb:ReportViewer ID="rvCCRMMIFReport" runat="server" AsyncRendering="False" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="" Width="" SizeToReportContent="True">
                    <LocalReport ReportEmbeddedResource="AERP.Web.UI.Report.CCRM.CCRMMIFReport.rdlc">
                        <DataSources>
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="CCRMMIFReportDataSet1" />
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSource2" Name="StudyCentrePrintingFormat" />
                        </DataSources>
                    </LocalReport>
                </rsweb:ReportViewer>

              
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData" TypeName="CCRMMIFReportDataSet1TableAdapters.CCRMMIFReportTableAdapter"></asp:ObjectDataSource>

            </div>

        </div>
        <div id="NoRecordDiv" runat="server" style="text-align: center;">

            <b>No Record Found</b>

        </div>
       
    </form>
</body>
</html>

