<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BannerUpload.aspx.cs" Inherits="EmployeePortal.Account.BannerUpload" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <asp:Image ID="imProfilePc" runat="server" Height="7%" Width="7%" ImageAlign="Right" />
    </br>
    </br>
    </br>
    </br>
    </br>
    <p style="text-align: right">Welcome  <%: Session["UserName"] %>!</p>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h3 style="text-align:center">Use this page to upload a Banner/Image</h3>
    <div id="fuDiv" runat="server" style="text-align:center" >
    <asp:FileUpload ID="fuBanner" runat="server"  />
        </br>
        <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" />
    </div>
</asp:Content>
