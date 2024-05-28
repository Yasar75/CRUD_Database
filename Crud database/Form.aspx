<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Form.aspx.cs" Inherits="Crud_database.WebForm1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
  <meta charset="UTF-8" />
  <meta http-equiv="X-UA-Compatible" content="IE=edge" />
  <meta name="viewport" content="width=device-width, initial-scale=1.0" />
  <script src="https://code.jquery.com/jquery-3.6.1.js" integrity="sha256-3zlB5s2uwoUzrXK3BT7AX3FyvojsraNFxCc2vC/7pNI="
    crossorigin="anonymous"></script>
  <link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.1.1/css/bootstrap.min.css" rel="stylesheet" />
  <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet"
    integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous" />
    <title>Form</title>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.min.js"></script>
    <link rel="stylesheet" href="https://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />

    <%: Styles.Render("~/bundles/Css/Form/desktop") %>
    <%= Scripts.Render("~/bundles/Scripts/Forms/desktop") %>
     

</head>

<body onload="autoGenerate()">
    <div class="wrapper">

      <center>
        <h1 class="title">Employee Details</h1>
      </center>

    <form id="form1" class="myform" runat="server">

        <div class="form-group">
          <label for="employeeid">Employee Id *</label>
          <input type="text" class="EMPLOYEEID" id="empid"  placeholder="" required readonly />
        </div>

        <div class="form-group">
          <label for="firstname">First Name: *</label>
          <input class="form-control-lg mb-2 FIRSTNAME" type="text" id="fname" placeholder="Enter First Name" />
        </div>

        <div class="form-group">
          <label for="middlename">Middle Name:</label>
          <input class="form-control-lg mb-2" type="text" id="mname" placeholder="Enter Middle Name" />
        </div>

        <div class="form-group">
          <label for="lastname">Last Name:</label>
          <input class="form-control-lg mb-2" type="text" id="lname" placeholder="Enter Last Name" />
        </div>

        <div class="form-group">
          <label for="gender">Gender: *</label>
          <select class="form-select form-select-lg-1" id="gender" name="Gender" required>

          </select>
        </div>

        <div class="form-group">
          <label for="dateofbirth">Date Of Birth: *</label>
          <input class="form-control-lg-1 mb-0" type="date" placeholder="Enter Date Of Birth" id="dob" max="2006-12-31" min="1970-01-01" onchange="return findage();" autofocus required />
        </div>

        <div class="form-group">
          <label for="Age">Age:</label>
          <input type="number" name="age" id="age" class="login-input" placeholder="Age" readonly />
        </div>

         <div class="btn">
          <button type="button" id="save" class="btn1 btn btn-outline-success shadow">Save</button>
          <button type="button" class="btn2 btn btn-outline-info shadow" onclick="viewData()">View</button>
        </div>
        </form>
  <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CRUD%>" SelectCommand="SELECT * FROM EmpDetails"></asp:SqlDataSource>

</div>
    <%--<asp:ScriptManager runat="server" EnablePageMethods="true"></asp:ScriptManager>--%>

</body> 
</html>
