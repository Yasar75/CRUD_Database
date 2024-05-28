<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="demo1.aspx.cs" Inherits="Crud_database.demo1" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml Jump ">
<head runat="server">
 <title></title>
 <style type="text/css">
 .auto-style1 {
 width: 50%;
 height: 13px;
 border: 2px solid #FFFFFF;
 margin-left: 0px;
 margin-right: 56px;
 background-color: #0000FF;
 }
 .auto-style7 {
 height: 52px;
 width: 121px;
 }
 .auto-style8 {
 height: 52px;
 width: 397px;
 }
 .auto-style10 {
 height: 71px;
 }
 .auto-style11 {
 height: 74px;
 width: 121px;
 }
 .auto-style12 {
 height: 74px;
 width: 397px;
 }
 </style>
</head>
<body>
 <form id="form1" runat="server">
 <div>
  
 <table align="center" class="auto-style1">
 <tr>
 <td class="auto-style10"><h1>   USER ACCOUNT</h1></td>
 </tr>
 </table>
 
 
 
  
 <table align="center" class="auto-style1">
 <tr>
 <td class="auto-style11" style="font-family: Verdana; font-size: medium; font-weight: bold; font-style: inherit; font-variant: inherit; text-transform: uppercase; color: #FFFFFF">  NAME</td>
 <td class="auto-style12">
  <asp:TextBox ID="TextBox1" runat="server" BackColor="#00CCFF" BorderColor="White" BorderStyle="Solid" Height="46px" Width="350px"></asp:TextBox>
 </td>
 </tr>
 <tr>
 <td class="auto-style11" style="font-family: Verdana; font-size: medium; font-weight: bold; font-style: inherit; font-variant: inherit; text-transform: uppercase; color: #FFFFFF">  ADDRESS</td>
 <td class="auto-style12">
  <asp:TextBox ID="TextBox2" runat="server" BackColor="#00CCFF" BorderColor="White" BorderStyle="Solid" Height="46px" Width="350px"></asp:TextBox>
 </td>
 </tr>
 <tr>
 <td class="auto-style7"></td>
 <td class="auto-style8">
   
  <asp:Button ID="Button1" OnClick="SaveBtn_Click1" runat ="server" BackColor="#00CCFF" BorderColor="White" BorderStyle="Solid" BorderWidth="3px" CssClass="auto-style1" ForeColor="White" Height="30px" Text="Send" Width="101px" />
  
  <br />
 </td>
 </tr>
 </table>
 </div>
 </form>
</body>
</html>