<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserLanding.aspx.cs" Inherits="EmployeePortal.Account.UserLanding" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        #floatMenu {
            position: absolute;
            top: 40%;
            left: 210px;
            width: 135px;
            background-color: #FFF;
            margin: 0;
            padding: 0;
            font-size: 11px;
            border-left: 1px solid #ddd;
            border-right: 1px solid #ddd;
        }

            #floatMenu h3 {
                color: white;
                font-weight: bold;
                padding: 3px;
                margin: 0;
                background-color: #006;
                border-bottom: 1px solid #ddd;
                border-top: 1px solid #ddd;
                font-size: 13px;
                text-align: center;
            }

            #floatMenu ul {
                margin: 0;
                padding: 0;
                list-style: none;
            }

                #floatMenu ul li {
                    padding-left: 10px;
                    background-color: #f5f5f5;
                    border-bottom: 1px solid #ddd;
                    border-top: 1px solid #ddd;
                }

                    #floatMenu ul li a {
                        text-decoration: none;
                    }
    </style>
    <script language="javascript" type="text/javascript">

        $(function () {
            function moveFloatMenu() {
                var menuOffset = menuYloc.top + $(this).scrollTop() + "px";
                $('#floatMenu').animate({ top: menuOffset }, { duration: 500, queue: false });
            }
            menuYloc = $('#floatMenu').offset();
            $(window).scroll(moveFloatMenu);
            moveFloatMenu();
        });

    </script>
    

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


    <div id="floatMenu">
        <h3>Menu Tab</h3>
        <ul>
            <li><a onclick="return true;" href="https://gmail.com" target="_blank">Go to Gmail</a></li>
            <li><a onclick="return true;" href="https://facebook.com" target="_blank">Go to FB</a></li>
            <li><a onclick="return true;" href="javascript:parent.func('/InternalPath/MorePath')" target="_blank">Go to WA</a></li>
            <li><a onclick="return true;" href="comingSoon.aspx">My Home</a></li>
            <li><a onclick="return true;" href="BannerUpload.aspx" >Image/Banner Upload</a></li>
            
        </ul>
    </div>
    <br />
    <br />
    <br />
</asp:Content>
