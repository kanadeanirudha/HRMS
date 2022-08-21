<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>


<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>Inventory Item Price Report</title>
    <script runat="server">

        AERP.Web.UI.Controllers.RegisterofWorkmenEmployedbyContractorController controller = new AERP.Web.UI.Controllers.RegisterofWorkmenEmployedbyContractorController();

        protected void Page_PreInit(object sender, EventArgs e)
        {
            Context.Handler = this.Page;
        }
        void Page_Load(object sender, EventArgs e)
        {
            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            scriptManager.RegisterPostBackControl(this.rvRegisterofWorkmenEmployedbyContractor);
            if (!IsPostBack)
            {
                rvRegisterofWorkmenEmployedbyContractor.ProcessingMode = ProcessingMode.Local;
                List<AERP.DTO.RegisterofWorkmenEmployedbyContractor> RegisterofWorkmenEmployedbyContractor = null;
                List<AERP.DTO.OrganisationStudyCentreMaster> OrganisationStudyCentreMasterDetails = null;



                RegisterofWorkmenEmployedbyContractor = controller.GetRegisterofWorkmenEmployedbyContractorList();


                if (RegisterofWorkmenEmployedbyContractor == null)
                {
                    MainDiv.Visible = false;
                    NoRecordDiv.Visible = true;
                }
                else
                {
                    MainDiv.Visible = true;
                    NoRecordDiv.Visible = false;
                    rvRegisterofWorkmenEmployedbyContractor.LocalReport.ReportPath = Server.MapPath("~/Report/Contract/RegisterofWorkmenEmployedbyContractor.rdlc");
                    rvRegisterofWorkmenEmployedbyContractor.LocalReport.DataSources.Clear();//collection Of Reports

                    ReportDataSource rdc = new ReportDataSource();
                    rdc.Name = "RegisterofWorkmenEmployedbyContractorDataSet1";//Data Set Name
                    rdc.Value = RegisterofWorkmenEmployedbyContractor;                //DTO object
                    rvRegisterofWorkmenEmployedbyContractor.LocalReport.DataSources.Add(rdc);

                    //ReportParameter[] param = new ReportParameter[8];
                    //param[0] = new ReportParameter("EmployeeName", RegisterofWorkmenEmployedbyContractor.Count > 0 ? RegisterofWorkmenEmployedbyContractor[0].EmployeeName : string.Empty, false);
                    //param[1] = new ReportParameter("CentreAdress", RegisterofWorkmenEmployedbyContractor.Count > 0 ? RegisterofWorkmenEmployedbyContractor[0].CentreAdress : string.Empty, false);
                    //param[2] = new ReportParameter("CentreName", RegisterofWorkmenEmployedbyContractor.Count > 0 ? RegisterofWorkmenEmployedbyContractor[0].CentreName : string.Empty, false);
                    //param[3] = new ReportParameter("EmployeeFathersFullName", RegisterofWorkmenEmployedbyContractor.Count > 0 ? RegisterofWorkmenEmployedbyContractor[0].EmployeeFathersFullName : string.Empty, false);
                    //param[4] = new ReportParameter("PFAccountNmber", RegisterofWorkmenEmployedbyContractor.Count > 0 ? RegisterofWorkmenEmployedbyContractor[0].PFAccountNmber : string.Empty, false);
                    //param[5] = new ReportParameter("RateOfContribution", RegisterofWorkmenEmployedbyContractor.Count > 0 ? Convert.ToString(RegisterofWorkmenEmployedbyContractor[0].RateOfContribution):  string.Empty, false);
                    //param[6] = new ReportParameter("FromDate", RegisterofWorkmenEmployedbyContractor.Count > 0 ? Convert.ToString(RegisterofWorkmenEmployedbyContractor[0].FromDate):  string.Empty, false);
                    //param[7] = new ReportParameter("UptoDate", RegisterofWorkmenEmployedbyContractor.Count > 0 ? Convert.ToString(RegisterofWorkmenEmployedbyContractor[0].UptoDate):  string.Empty, false);
                    //rvRegisterofWorkmenEmployedbyContractor.LocalReport.SetParameters(param);

                    rvRegisterofWorkmenEmployedbyContractor.LocalReport.Refresh();
                    rvRegisterofWorkmenEmployedbyContractor.Visible = true;
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

                <rsweb:ReportViewer ID="rvRegisterofWorkmenEmployedbyContractor" runat="server" AsyncRendering="False" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="" Width="" SizeToReportContent="True">
                    <LocalReport ReportEmbeddedResource="AERP.Web.UI.Report.Contract.RegisterofWorkmenEmployedbyContractor.rdlc">
                        <DataSources>
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="RegisterofWorkmenEmployedbyContractorDataSet1" />
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSource2" Name="StudyCentrePrintingFormat" />
                        </DataSources>
                    </LocalReport>
                </rsweb:ReportViewer>

              
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData" TypeName="RegisterofWorkmenEmployedbyContractorListDataSet1TableAdapters.InventoryRegisterofWorkmenEmployedbyContractorListTableAdapter"></asp:ObjectDataSource>

            </div>

        </div>
        <div id="NoRecordDiv" runat="server" style="text-align: center;">

            <b>No Record Found</b>

        </div>
       
    </form>
</body>
</html>


