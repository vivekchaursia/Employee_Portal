﻿<%@ Page Title="Log in" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="EmployeePortal.Account.Login" %>
<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %>.</h1>
    </hgroup>
    <section id="loginForm">
        
        
                <p class="validation-summary-errors">
                    <asp:Literal runat="server" ID="FailureText" />
                </p>
        <fieldset>
            <legend>Log in Form</legend>
            <ol>
                <li>
                    <asp:Label runat="server" AssociatedControlID="UserName">User name</asp:Label>
                    <asp:TextBox runat="server" ID="UserName" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="UserName" CssClass="field-validation-error" ErrorMessage="The user name field is required." />
                </li>
                <li>
                    <asp:Label runat="server" AssociatedControlID="Password">Password</asp:Label>
                    <asp:TextBox runat="server" ID="Password" TextMode="Password" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="field-validation-error" ErrorMessage="The password field is required." />
                </li>

            </ol>
            <asp:Button runat="server" CommandName="Login" Text="Log in" id="btnLogin" OnClick="btnLogin_Click" />
        </fieldset>
           
        <p>
            <asp:HyperLink runat="server" ID="RegisterHyperLink" ViewStateMode="Disabled">Register</asp:HyperLink>
            if you don't have an account.
        </p>
    </section>

    
</asp:Content>
