<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="Crud_database.Report" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" />  
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <%: Styles.Render("~/bundles/Css/Report/desktop") %>
    <%= Scripts.Render("~/bundles/Scripts/Report/desktop") %>
    
</head>
<body>
    <h1 class="title text-center">Employee Details</h1> 
    <form id="form1"  runat="server">

    <div class="container">  
    <table id="myTable" class="wrapper table sl table-hover table-secondary table-bordered table-condensed table-striped">
    <thead>
      <tr>
        <th id="Empid"> Employee Code </th>
        <th id="Fullname">Employee Name</th>
        <th id="Gender"> Gender </th>
        <th id="DateOfBirth"> Dob </th>
        <th id="Age"> Age </th>
        <th><button type="button" class=" btn btn-warning text-dark shadow"
            onclick="window.open('Form','_self')">ADD</button></th>
            
      </tr>
    </thead>

    <tbody id="m"></tbody>
  </table>
        </div> 
    </form>
    </body>
</html>
                         