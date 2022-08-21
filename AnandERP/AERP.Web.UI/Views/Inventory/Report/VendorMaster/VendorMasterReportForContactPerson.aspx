<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>Report For ContactPerson</title>
    <script runat="server">
   
        AERP.Web.UI.Controllers.VendorMasterReportController controller = new AERP.Web.UI.Controllers.VendorMasterReportController();

        protected void Page_PreInit(object sender, EventArgs e)
        {
            Context.Handler = this.Page;
        }
       
        void Page_Load(object sender, EventArgs e)
        {
            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            scriptManager.RegisterPostBackControl(this.rvVendorMasterReportForContactPerson);
            if (!IsPostBack)
            {
                rvVendorMasterReportForContactPerson.ProcessingMode = ProcessingMode.Local;
                List<AERP.DTO.VendorMasterReport> VendorMasterReport = null;
                //List<AERP.DTO.OrganisationStudyCentreMaster> OrganisationStudyCentreMasterDetails = null;



                VendorMasterReport = controller.GetVendorList("ContactPerson");

                
                if (VendorMasterReport == null)
                {
                    //MainDiv.Visible = false;
                    //NoRecordDiv.Visible = true;
                }
                else
                {
                    MainDiv.Visible = true;
                    NoRecordDiv.Visible = false;
                    rvVendorMasterReportForContactPerson.LocalReport.ReportPath = Server.MapPath("~/Report/Inventory/VendorMasterReportForContactPerson.rdlc");
                    rvVendorMasterReportForContactPerson.LocalReport.DataSources.Clear();//collection Of Reports

                    ReportDataSource rdc = new ReportDataSource();
                    rdc.Name = "VendorMasterReportForContactPersonDataSet1";//Data Set Name
                    rdc.Value = VendorMasterReport;                //DTO object
                    rvVendorMasterReportForContactPerson.LocalReport.DataSources.Add(rdc);

                    //ReportDataSource rdc2 = new ReportDataSource();
                    //rdc2.Name = "StudyCentrePrintingFormat";
                    //rdc2.Value = OrganisationStudyCentreMasterDetails;
                    //rvVendorMasterReportForContactPerson.LocalReport.DataSources.Add(rdc2);

                    rvVendorMasterReportForContactPerson.LocalReport.Refresh();
                    rvVendorMasterReportForContactPerson.Visible = true;
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
             <%--   Please Select Report :&nbsp&nbsp&nbsp;--%>
               
                 <rsweb:ReportViewer ID="rvVendorMasterReportForContactPerson" runat="server" AsyncRendering="False" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="" Width="" SizeToReportContent="True">
                    <LocalReport ReportEmbeddedResource="AERP.Web.UI.Report.Inventory.VendorMasterReportForContactPerson.rdlc">
                        <DataSources>
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="VendorMasterReportForContactPersonDataSet1" />

                          
                        </DataSources>
                    </LocalReport>
                </rsweb:ReportViewer>

              
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData" TypeName="VendorMasterReportForContactPersonDataSet1TableAdapters.VendorMasterReportForContactPersonTableAdapter"></asp:ObjectDataSource>

            </div>

        </div>
        <div id="NoRecordDiv" runat="server" style="text-align: center;">

            <b>No Record Found</b>

        </div>
       
    </form>
</body>
</html>


