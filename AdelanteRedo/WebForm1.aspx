<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="AdelanteRedo.WebForm1" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager runat="server"></asp:ScriptManager>
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" Height="261px" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="823px">
            <LocalReport ReportPath="Report2.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet1" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DeleteMethod="Delete" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="AdelanteRedo.goyals420_troutDataSetTableAdapters.DonorTableAdapter" UpdateMethod="Update">
            <DeleteParameters>
                <asp:Parameter Name="Original_Donor_NUM" Type="String" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="Donor_NUM" Type="String" />
                <asp:Parameter Name="Donor_FirstName" Type="String" />
                <asp:Parameter Name="Donor_LastName" Type="String" />
                <asp:Parameter Name="Donor_Address" Type="String" />
                <asp:Parameter Name="Donor_City" Type="String" />
                <asp:Parameter Name="Donor_State" Type="String" />
                <asp:Parameter Name="Donor_Zip" Type="String" />
                <asp:Parameter Name="Donor_HomeTele" Type="String" />
                <asp:Parameter Name="Donor_CellPhone" Type="String" />
                <asp:Parameter Name="Donor_Email" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="Donor_FirstName" Type="String" />
                <asp:Parameter Name="Donor_LastName" Type="String" />
                <asp:Parameter Name="Donor_Address" Type="String" />
                <asp:Parameter Name="Donor_City" Type="String" />
                <asp:Parameter Name="Donor_State" Type="String" />
                <asp:Parameter Name="Donor_Zip" Type="String" />
                <asp:Parameter Name="Donor_HomeTele" Type="String" />
                <asp:Parameter Name="Donor_CellPhone" Type="String" />
                <asp:Parameter Name="Donor_Email" Type="String" />
                <asp:Parameter Name="Original_Donor_NUM" Type="String" />
            </UpdateParameters>
        </asp:ObjectDataSource>
    </div>
    </form>
</body>
</html>
