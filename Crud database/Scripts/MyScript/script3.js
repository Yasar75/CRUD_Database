$(document).ready(function () {
  // load the employee data from the web service
  $.ajax({
    url: "Employee.asmx/GetEmployee",
    dataType: "json",
    method: "post",
    success: function (data) {
      var empTable = $("#myTable tbody");
      empTable.empty();
      $(data).each(function (index, emp) {
        empTable.append(
          "<tr><td>" +
            emp.Empid +
            "</td><td>" +
            emp.Firstname +" "+ emp.Middlename +" "+ emp.Lastname +
            "</td><td>" +
            emp.Gender +
            "</td><td>" +
            emp.DateOfBirth +
            "</td><td>" +
            emp.Age +
            "</td><td>" +
            '<a href="Form.aspx?Empid=' +
            emp.Empid +
            '" class="edit btn btn-outline-primary shadow">Edit</a>' +
            "</td><td>" +
            '<a href="javascript:void(0);" class="delete btn btn-outline-danger shadow">Delete</a>' +
            "</td></tr>"
        );
      });
    },
    error: function (err) {
      alert(err);
    },
  });

  // bind click event to delete button
  $("#myTable tbody").on("click", ".delete", function (event) {
    var self = this;
    var Empid = $(this).closest("tr").find("td:first-child").text();
    $.ajax({
      method: "POST",
      url: "Employee.asmx/DeleteData",
      data: JSON.stringify({ Empid: Empid }),
      contentType: "application/json; charset=utf-8",
      dataType: "json",
      success: function (data) {
        var returnedData = JSON.parse(data.d);
        if (returnedData.status === "success") {
            $(self).closest("tr").remove();
            alert("Data Deleted Successfully.");
            setTimeout(function(){
                location.reload();
            },300);
        } else {
            alert("Error deleting the row: " + returnedData.message);
        }
    },
    
      failure: function (jqXHR, textStatus, errorThrown) {
        alert(jqXHR.responseText);
      },
    });
  });
});
