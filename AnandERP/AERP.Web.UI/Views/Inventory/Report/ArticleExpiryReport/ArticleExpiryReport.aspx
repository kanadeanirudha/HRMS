<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title></title>
    <script runat="server">
   
        AMS.Web.UI.Controllers.ArticleExpiryReportController controller = new AMS.Web.UI.Controllers.ArticleExpiryReportController();

        protected void Page_PreInit(object sender, EventArgs e)
        {
            Context.Handler = this.Page;
        }
        void Page_Load(object sender, EventArgs e)
        {
            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            scriptManager.RegisterPostBackControl(this.rvArticleExpiryReport);
            if (!IsPostBack)
            {
                rvArticleExpiryReport.ProcessingMode = ProcessingMode.Local;
                List<AMS.DTO.InventoryReport> InventoryReport = null;
                //List<AMS.DTO.OrganisationStudyCentreMaster> OrganisationStudyCentreMasterDetails = null;

                if (Request.RequestType == "POST")
                {
                    InventoryReport = controller.GetArticleExpiryReportList();
                }

                if (InventoryReport != null && InventoryReport.Count != 0)
                {
                    MainDiv.Visible = true;
                    NoRecordDiv.Visible = false;
                    rvArticleExpiryReport.LocalReport.ReportPath = Server.MapPath("~/Report/Inventory_1/ArticleExpiryReport.rdlc");
                    rvArticleExpiryReport.LocalReport.DataSources.Clear();//collection Of Reports

                    ReportDataSource rdc = new ReportDataSource();
                    rdc.Name = "ArticleExpiryReportDataSet";//Data Set Name
                    rdc.Value = InventoryReport;                //DTO object
                    rvArticleExpiryReport.LocalReport.DataSources.Add(rdc);

                    //ReportDataSource rdc2 = new ReportDataSource();
                    //rdc2.Name = "StudyCentrePrintingFormat";
                    //rdc2.Value = OrganisationStudyCentreMasterDetails;
                    //rvArticleExpiryReport.LocalReport.DataSources.Add(rdc2);

                    ReportParameter[] param = new ReportParameter[2];
                    param[0] = new ReportParameter("GeneralUnitsName", InventoryReport.Count > 0 ? InventoryReport[0].GeneralUnitsName : string.Empty, false);
                    param[1] = new ReportParameter("CentreName", InventoryReport.Count > 0 ? InventoryReport[0].CentreName : string.Empty, false);
                    rvArticleExpiryReport.LocalReport.SetParameters(param);
                    
                    rvArticleExpiryReport.LocalReport.Refresh();
                    rvArticleExpiryReport.Visible = true;
                    
                }
                else
                {
                    MainDiv.Visible = false;
                    NoRecordDiv.Visible = true;
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

                <rsweb:ReportViewer ID="rvArticleExpiryReport" runat="server" AsyncRendering="False" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="" Width="" SizeToReportContent="True">
                    <LocalReport ReportEmbeddedResource="AMS.Web.UI.Report.Inventory_1.ArticleExpiryReport.rdlc">
                        <DataSources>
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="ArticleExpiryReportDataSet" />
                            <%--<rsweb:ReportDataSource DataSourceId="ObjectDataSource2" Name="StudyCentrePrintingFormat" />--%>
                        </DataSources>
                    </LocalReport>
                </rsweb:ReportViewer>

              
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData" TypeName="ArticleExpiryReportListDataSet1TableAdapters.ArticleExpiryReportListTableAdapter"></asp:ObjectDataSource>

            </div>

        </div>
        <div id="NoRecordDiv" runat="server" style="text-align: center;">

            <b>No Record Found</b>

        </div>
       
    </form>
</body>
</html>


