<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>


<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>Inventory Item Price Report</title>
    <script runat="server">

        AERP.Web.UI.Controllers.RegisterofDeductionsforDamageorLossController controller = new AERP.Web.UI.Controllers.RegisterofDeductionsforDamageorLossController();

        protected void Page_PreInit(object sender, EventArgs e)
        {
            Context.Handler = this.Page;
        }
        void Page_Load(object sender, EventArgs e)
        {
            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            scriptManager.RegisterPostBackControl(this.rvRegisterofDeductionsforDamageorLoss);
            if (!IsPostBack)
            {
                rvRegisterofDeductionsforDamageorLoss.ProcessingMode = ProcessingMode.Local;
                List<AERP.DTO.RegisterofDeductionsforDamageorLoss> RegisterofDeductionsforDamageorLoss = null;
                List<AERP.DTO.OrganisationStudyCentreMaster> OrganisationStudyCentreMasterDetails = null;



                RegisterofDeductionsforDamageorLoss = controller.GetRegisterofDeductionsforDamageorLossList();


                if (RegisterofDeductionsforDamageorLoss == null)
                {
                    MainDiv.Visible = false;
                    NoRecordDiv.Visible = true;
                }
                else
                {
                    MainDiv.Visible = true;
                    NoRecordDiv.Visible = false;
                    rvRegisterofDeductionsforDamageorLoss.LocalReport.ReportPath = Server.MapPath("~/Report/Contract/RegisterofDeductionsforDamageorLoss.rdlc");
                    rvRegisterofDeductionsforDamageorLoss.LocalReport.DataSources.Clear();//collection Of Reports

                    ReportDataSource rdc = new ReportDataSource();
                    rdc.Name = "RegisterofDeductionsforDamageorLossDataSet1";//Data Set Name
                    rdc.Value = RegisterofDeductionsforDamageorLoss;                //DTO object
                    rvRegisterofDeductionsforDamageorLoss.LocalReport.DataSources.Add(rdc);

                    //ReportParameter[] param = new ReportParameter[8];
                    //param[0] = new ReportParameter("EmployeeName", RegisterofDeductionsforDamageorLoss.Count > 0 ? RegisterofDeductionsforDamageorLoss[0].EmployeeName : string.Empty, false);
                    //param[1] = new ReportParameter("CentreAdress", RegisterofDeductionsforDamageorLoss.Count > 0 ? RegisterofDeductionsforDamageorLoss[0].CentreAdress : string.Empty, false);
                    //param[2] = new ReportParameter("CentreName", RegisterofDeductionsforDamageorLoss.Count > 0 ? RegisterofDeductionsforDamageorLoss[0].CentreName : string.Empty, false);
                    //param[3] = new ReportParameter("EmployeeFathersFullName", RegisterofDeductionsforDamageorLoss.Count > 0 ? RegisterofDeductionsforDamageorLoss[0].EmployeeFathersFullName : string.Empty, false);
                    //param[4] = new ReportParameter("PFAccountNmber", RegisterofDeductionsforDamageorLoss.Count > 0 ? RegisterofDeductionsforDamageorLoss[0].PFAccountNmber : string.Empty, false);
                    //param[5] = new ReportParameter("RateOfContribution", RegisterofDeductionsforDamageorLoss.Count > 0 ? Convert.ToString(RegisterofDeductionsforDamageorLoss[0].RateOfContribution):  string.Empty, false);
                    //param[6] = new ReportParameter("FromDate", RegisterofDeductionsforDamageorLoss.Count > 0 ? Convert.ToString(RegisterofDeductionsforDamageorLoss[0].FromDate):  string.Empty, false);
                    //param[7] = new ReportParameter("UptoDate", RegisterofDeductionsforDamageorLoss.Count > 0 ? Convert.ToString(RegisterofDeductionsforDamageorLoss[0].UptoDate):  string.Empty, false);
                    //rvRegisterofDeductionsforDamageorLoss.LocalReport.SetParameters(param);

                    rvRegisterofDeductionsforDamageorLoss.LocalReport.Refresh();
                    rvRegisterofDeductionsforDamageorLoss.Visible = true;
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

                <rsweb:ReportViewer ID="rvRegisterofDeductionsforDamageorLoss" runat="server" AsyncRendering="False" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="" Width="" SizeToReportContent="True">
                    <LocalReport ReportEmbeddedResource="AERP.Web.UI.Report.Contract.RegisterofDeductionsforDamageorLoss.rdlc">
                        <DataSources>
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="RegisterofDeductionsforDamageorLossDataSet1" />
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSource2" Name="StudyCentrePrintingFormat" />
                        </DataSources>
                    </LocalReport>
                </rsweb:ReportViewer>

              
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData" TypeName="RegisterofDeductionsforDamageorLossListDataSet1TableAdapters.InventoryRegisterofDeductionsforDamageorLossListTableAdapter"></asp:ObjectDataSource>

            </div>

        </div>
        <div id="NoRecordDiv" runat="server" style="text-align: center;">

            <b>No Record Found</b>

        </div>
       
    </form>
</body>
</html>


