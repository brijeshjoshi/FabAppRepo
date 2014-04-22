<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ATM.aspx.cs" Inherits="WebApplication1.ATM" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>ATM - FAB Localizador</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table align="center" width="1100" border="2">
            <tr align="justify">
                <td>
                    <asp:Image ID="img_fab" Height="50%" Width="15%" ImageUrl="~/Images/1.PNG" runat="server" />
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
                            <asp:MenuItem Text="HOME" Value="HOME" NavigateUrl="~/Home Page.aspx"></asp:MenuItem>
                            <asp:MenuItem Text="FUEL" Value="FUEL" NavigateUrl="~/Fuel.aspx"></asp:MenuItem>
                            <asp:MenuItem Text="ATM" Value="ATM" NavigateUrl="~/ATM.aspx"></asp:MenuItem>
                            <asp:MenuItem Text="BANK" Value="BANK" NavigateUrl="~/Bank.aspx"></asp:MenuItem>
                        </Items>
                        <StaticHoverStyle BackColor="#8FC5B9" BorderStyle="Solid" ForeColor="#000066" />
                        <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" BackColor="#F9A649"
                            ItemSpacing="10px" />
                        <StaticSelectedStyle BackColor="#5D7B9D" />
                    </asp:Menu>
                    <asp:LinkButton ID="lnbLogout" runat="server" Text="Logout"
                        onclick="lnbLogout_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                    <table align="left">
                        <tr>
                            <td>ATM ID : </td>
                            <td>
                                <asp:TextBox ID="txtID" runat="server" ReadOnly="true" />
                                <asp:RequiredFieldValidator ID="rfv" runat="server" ControlToValidate="txtID" Text="Please Click On Select" ValidationGroup="ID" />
                            </td>
                        </tr>
                        <tr>
                            <td>Bank Name : </td>
                            <td><asp:DropDownList ID="ddlATM" runat="server" AutoPostBack="True" /></td>
                        </tr>
                        <tr>
                            <td>ATM Address : </td>
                            <td>
                                <asp:TextBox ID="txtFaddress" runat="server" />
                                <asp:RequiredFieldValidator ID="rfv2" runat="server" ControlToValidate="txtFaddress" Text="*" ValidationGroup="Insert" />
                            </td>
                        </tr>
                        <tr>
                            <td>City : </td>
                            <td><asp:DropDownList ID="ddlCity" runat="server" AutoPostBack="True" 
                                    onselectedindexchanged="ddlCity_SelectedIndexChanged"></asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td>Area : </td>
                            <td><asp:DropDownList ID="ddlArea" runat="server"></asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2"><asp:Button ID="btnSubmit" Text="Submit" 
                                    runat="server" onclick="btnSubmit_Click" ValidationGroup="Insert" />
                            <asp:Button ID="btnUpdate" Text="Update" runat="server" onclick="btnUpdate_Click" 
                                    ValidationGroup="ID" />
                            <asp:Button ID="btnDelete" Text="Delete" runat="server" onclick="btnDelete_Click" 
                                    ValidationGroup="ID" />
                            <asp:Button ID="btnReset" Text="Reset" runat="server" onclick="btnReset_Click" 
                                    CausesValidation="False" /></td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:ListView ID="gvATM" runat="server" OnItemCommand="gvATM_ItemCommand" OnSelectedIndexChanging="gvATM_SelectedIndexChanging">
                            <LayoutTemplate>
                                <table border="1">
                                    <tr>
                                        <td align="center"><b>ATM ID</b></td>
                                        <td align="center"><b>Bank ID</b></td>
                                        <td align="center"><b>Address</b></td>
                                        <td align="center"><b>City ID</b></td>
                                        <td align="center"><b>Area ID</b></td>
                                        <td align="center"><b>Select</b></td>
                                    </tr>
                                    <tr id="ItemPlaceholder" runat="server"></tr>    
                                </table>
                            </LayoutTemplate>
                            <ItemTemplate>
                                    <tr id="Tr1" runat="server">
                                        <td align="center"><asp:Label ID="lblFID" runat="server" Text='<%#Eval("ATM_Id") %>' /></td>
                                        <td align="center"><asp:Label ID="lblTitle" runat="server" Text='<%#Eval("BankID") %>' /></td>
                                        <td><asp:Label ID="lblAddress" runat="server" Text='<%#Eval("Address") %>' /></td>
                                        <td align="center"><asp:Label ID="lblCity" runat="server" Text='<%#Eval("City_Id") %>' /></td>
                                        <td align="center"><asp:Label ID="lblArea" runat="server" Text='<%#Eval("Area_Id") %>' /></td>
                                        <td align="center"><asp:LinkButton ID="lnbSelect" runat="server" CommandName="Select" Text="Select" CommandArgument='<%#Eval("ATM_Id") %>' /></td>
                                    </tr>
                            </ItemTemplate>
                        </asp:ListView>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>

