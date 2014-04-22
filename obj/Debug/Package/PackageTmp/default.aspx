<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="WebApplication1.Styles._default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>FAB Localizador</title>
</head>
<body>



    <form id="form1" runat="server">
    <div>
        <table align="center" width="1100" border="2">
            <tr align="justify">
                <td>
                    <asp:Image ID="Image1" Height="50%" Width="15%" ImageUrl="~/Images/1.PNG" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="center">
                    <h1>FAB LOCALIZADOR</h1>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Menu ID="menu1" Orientation="Horizontal" runat="server" BackColor="#F9A649"
                        BorderStyle="Groove" BorderWidth="2px" DynamicHorizontalOffset="2" Font-Names="Verdana"
                        Font-Size="Medium" ForeColor="Black" RenderingMode="Table" StaticSubMenuIndent="20px">
                        <DynamicHoverStyle BackColor="#7C6F57" ForeColor="White" />
                        <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                        <DynamicMenuStyle BackColor="#F7F6F3" />
                        <DynamicSelectedStyle BackColor="#5D7B9D" />
                        <Items>
                            <asp:MenuItem Text="HOME" Value="HOME" NavigateUrl="~/default.aspx"></asp:MenuItem>
                            <asp:MenuItem Text="FUEL" Value="FUEL" NavigateUrl="~/Fuel.aspx"></asp:MenuItem>
                            <asp:MenuItem Text="ATM" Value="ATM" NavigateUrl="~/ATM.aspx"></asp:MenuItem>
                            <asp:MenuItem Text="BANK" Value="BANK" NavigateUrl="~/Bank.aspx"></asp:MenuItem>
                        </Items>
                        <StaticHoverStyle BackColor="#8FC5B9" BorderStyle="Solid" ForeColor="#000066" />
                        <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" BackColor="#F9A649"
                            ItemSpacing="10px" />
                        <StaticSelectedStyle BackColor="#5D7B9D" />
                    </asp:Menu>
                    <asp:LinkButton ID="lnbLogout" runat="server" Text="Logout" Visible="false" OnClick="lnbLogout_Click" />
                </td>
            </tr>
        </table>
        <table align="center" width="1100" border="2">
            <tr>
                <td>
                    <p style="height: 152px">
                        WELCOME<br />
                        *FAB.Localizador helps people in fetching location of Fuelpump ,ATM & Bank within
                        Gujarat in selected area.
                        <br />
                        *It will be helpful to its user during troublesome situations such as finding CNG,
                        petrol/diesel pumps in unknown areas also ATMs and Banks.
                        <br />
                        *People need not to worry about asking for location to the strangers while entering
                        any strange places.
                        <br />
                        *The system will notify user if he/she is out of the area that do not have Fuel
                        pump, ATM and Bank within his/her surrounding 40-50 km area.
                        <br />
                        *It will also display the current location of user using this application.
                        <br />
                        *The system will locate the distance(km) of Fuel pump, Bank and ATM from his current
                        location of user.
                        <br />
                        *The system will also notify if user leaves selected area.
                    </p>
                </td>
            </tr>
        </table>
        <table align="center" border="2">
            <tr>
                <td>
                    User Name :
                </td>
                <td>
                    <asp:TextBox ID="UsrID" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Password :
                </td>
                <td>
                    <asp:TextBox ID="Pass" TextMode="Password" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="sbmit" Text="LogIn" runat="server" OnClick="sbmit_Click" />
                </td>
                <td>
                    <asp:Label ID="LblMsg" Text="" ForeColor="Red" runat="server" />
                </td>
            </tr>
        </table>
    </div>
    </form>

    



           

</body>
</html>

