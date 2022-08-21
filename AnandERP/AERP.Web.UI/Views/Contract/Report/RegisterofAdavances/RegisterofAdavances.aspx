<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>


<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>Inventory Item Price Report</title>
    <script runat="server">

        AERP.Web.UI.Controllers.RegisterofAdavancesController controller = new AERP.Web.UI.Controllers.RegisterofAdavancesController();

        protected void Page_PreInit(object sender, EventArgs e)
        {
            Context.Handler = this.Page;
        }
        void Page_Load(object sender, EventArgs e)
        {
            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            scriptManager.RegisterPostBackControl(this.rvRegisterofAdavances);
            if (!IsPostBack)
            {
                rvRegisterofAdavances.ProcessingMode = ProcessingMode.Local;
                List<AERP.DTO.RegisterofAdavances> RegisterofAdavances = null;
                List<AERP.DTO.OrganisationStudyCentreMaster> OrganisationStudyCentreMasterDetails = null;



                RegisterofAdavances = controller.GetRegisterofAdavancesList();


                if (RegisterofAdavances == null)
                {
                    MainDiv.Visible = false;
                    NoRecordDiv.Visible = true;
                }
                else
                {
                    MainDiv.Visible = true;
                    NoRecordDiv.Visible = false;
                    rvRegisterofAdavances.LocalReport.ReportPath = Server.MapPath("~/Report/Contract/RegisterofAdavances.rdlc");
                    rvRegisterofAdavances.LocalReport.DataSources.Clear();//collection Of Reports

                    ReportDataSource rdc = new ReportDataSource();
                    rdc.Name = "RegisterofAdavancesDataSet1";//Data Set Name
                    rdc.Value = RegisterofAdavances;                //DTO object
                    rvRegisterofAdavances.LocalReport.DataSources.Add(rdc);

                    //ReportParameter[] param = new ReportParameter[8];
                    //param[0] = new ReportParameter("EmployeeName", RegisterofAdavances.Count > 0 ? RegisterofAdavances[0].EmployeeName : string.Empty, false);
                    //param[1] = new ReportParameter("CentreAdress", RegisterofAdavances.Count > 0 ? RegisterofAdavances[0].CentreAdress : string.Empty, false);
                    //param[2] = new ReportParameter("CentreName", RegisterofAdavances.Count > 0 ? RegisterofAdavances[0].CentreName : string.Empty, false);
                    //param[3] = new ReportParameter("EmployeeFathersFullName", RegisterofAdavances.Count > 0 ? RegisterofAdavances[0].EmployeeFathersFullName : string.Empty, false);
                    //param[4] = new ReportParameter("PFAccountNmber", RegisterofAdavances.Count > 0 ? RegisterofAdavances[0].PFAccountNmber : string.Empty, false);
                    //param[5] = new ReportParameter("RateOfContribution", RegisterofAdavances.Count > 0 ? Convert.ToString(RegisterofAdavances[0].RateOfContribution):  string.Empty, false);
                    //param[6] = new ReportParameter("FromDate", RegisterofAdavances.Count > 0 ? Convert.ToString(RegisterofAdavances[0].FromDate):  string.Empty, false);
                    //param[7] = new ReportParameter("UptoDate", RegisterofAdavances.Count > 0 ? Convert.ToString(RegisterofAdavances[0].UptoDate):  string.Empty, false);
                    //rvRegisterofAdavances.LocalReport.SetParameters(param);

                    rvRegisterofAdavances.LocalReport.Refresh();
                    rvRegisterofAdavances.Visible = true;
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

                <rsweb:ReportViewer ID="rvRegisterofAdavances" runat="server" AsyncRendering="False" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="" Width="" SizeToReportContent="True">
                    <LocalReport ReportEmbeddedResource="AERP.Web.UI.Report.Contract.RegisterofAdavances.rdlc">
                        <DataSources>
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="RegisterofAdavancesDataSet1" />
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSource2" Name="StudyCentrePrintingFormat" />
                        </DataSources>
                    </LocalReport>
                </rsweb:ReportViewer>

              
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData" TypeName="RegisterofAdavancesListDataSet1TableAdapters.InventoryRegisterofAdavancesListTableAdapter"></asp:ObjectDataSource>

            </div>

        </div>
        <div id="NoRecordDiv" runat="server" style="text-align: center;">

            <b>No Record Found</b>

        </div>
       
    </form>
</body>
</html>


