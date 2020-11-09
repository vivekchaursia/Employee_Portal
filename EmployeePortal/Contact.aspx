<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="EmployeePortal.Contact" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %>.</h1>
        <h2>Your contact page.</h2>
    </hgroup>

    <section class="contact">
        <header>
            <h3>Phone:</h3>
        </header>
        <p>
            <span class="label">Mob:</span>
            <span><a href="tel:+919665351240">+919665351240</a></span>
        </p>
        
    </section>

    <section class="contact">
        <header>
            <h3>Email:</h3>
        </header>
        <p>
            <span class="label">General:</span>
            <span><a href="mailto:chaursiavivek@gmail.com">chaursiavivek@gmail.com</a></span>
        </p>
    </section>

    
</asp:Content>