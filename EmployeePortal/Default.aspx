<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EmployeePortal._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <style type="text/css">
        .Slide {
            width:71%;
            height:50%;
            position:absolute;
        }
    </style>
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1 style="text-align:center"><%: Title %>.</h1>
                
            </hgroup>
            <p>
                Welcome to Employee management system, where one can login and manage their account details.
                Can change the Homepage banner and navigate to other important link as well.
            </p>
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
   
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Timer ID="Timer1" runat="server" OnTick="Timer1_Tick" Interval="2000">
            </asp:Timer>
            <asp:Image ID="Image1" runat="server" CssClass="Slide" />
        </ContentTemplate>
    </asp:UpdatePanel>
    </br></br></br></br></br></br></br></br></br></br></br></br></br></br></br></br>
    
</asp:Content>
