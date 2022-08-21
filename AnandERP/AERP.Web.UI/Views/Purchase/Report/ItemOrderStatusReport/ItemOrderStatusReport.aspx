<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title></title>
    <script runat="server">
   
        AMS.Web.UI.Controllers.ItemOrderStatusReportController controller = new AMS.Web.UI.Controllers.ItemOrderStatusReportController();

        protected void Page_PreInit(object sender, EventArgs e)
        {
            Context.Handler = this.Page;
        }
        void Page_Load(object sender, EventArgs e)
        {
            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            scriptManager.RegisterPostBackControl(this.rvItemOrderStatusReport);
            if (!IsPostBack)
            {
                rvItemOrderStatusReport.ProcessingMode = ProcessingMode.Local;
                List<AMS.DTO.PurchaseReportMaster> PurchaseReportMaster = null;
                //List<AMS.DTO.OrganisationStudyCentreMaster> OrganisationStudyCentreMasterDetails = null;
                if (Request.RequestType == "POST")
                {
                    PurchaseReportMaster = controller.GetItemOrderList();
                }

                if (PurchaseReportMaster == null)
                {
                    MainDiv.Visible = false;
                    NoRecordDiv.Visible = true;
                }
                else
                {
                    MainDiv.Visible = true;
                    NoRecordDiv.Visible = false;
                    rvItemOrderStatusReport.LocalReport.ReportPath = Server.MapPath("~/Report/Purchase/ItemOrderStatusReport.rdlc");
                    rvItemOrderStatusReport.LocalReport.DataSources.Clear();//collection Of Reports

                    ReportDataSource rdc = new ReportDataSource();
                    rdc.Name = "ItemOrderStatusReports1";//Data Set Name
                    rdc.Value = PurchaseReportMaster;                //DTO object
                    rvItemOrderStatusReport.LocalReport.DataSources.Add(rdc);

                    ReportParameter[] param = new ReportParameter[2];
                    param[0] = new ReportParameter("CentreName", PurchaseReportMaster.Count > 0 ? PurchaseReportMaster[0].CentreName : string.Empty, false);
                    param[1] = new ReportParameter("GeneralUnitsName", PurchaseReportMaster.Count > 0 ? PurchaseReportMaster[0].GeneralUnitsName : string.Empty, false);
                    rvItemOrderStatusReport.LocalReport.SetParameters(param);
                    
                    rvItemOrderStatusReport.LocalReport.Refresh();
                    rvItemOrderStatusReport.Visible = true;
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

                <rsweb:ReportViewer ID="rvItemOrderStatusReport" runat="server" AsyncRendering="False" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="" Width="" SizeToReportContent="True">
                    <LocalReport ReportEmbeddedResource="AMS.Web.UI.Report.Purchase.ItemOrderStatusReport.rdlc">
                        <DataSources>
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="ItemOrderStatusReport1" />
                            <%--<rsweb:ReportDataSource DataSourceId="ObjectDataSource2" Name="StudyCentrePrintingFormat" />--%>
                        </DataSources>
                    </LocalReport>
                </rsweb:ReportViewer>

              
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData" TypeName="ItemOrderStatusReportListDataSet1TableAdapters.ItemOrderStatusReportListTableAdapter"></asp:ObjectDataSource>

            </div>

        </div>
        <div id="NoRecordDiv" runat="server" style="text-align: center;">

            <b>No Record Found</b>

        </div>
       
    </form>
</body>
</html>
