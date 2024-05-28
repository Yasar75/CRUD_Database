// Get the Gender Dropdown from the Database
$.ajax({
    url: "Employee.asmx/GetGenderList",
    data: "{}",
    contentType: "application/json; charset=utf-8",
    dataType: "json",
    type: "post",
    success: function (data) {
        console.log(data); // Log the entire response

        var genderList = data.d;

        if (genderList && genderList.length > 0) {
            var select = $("#gender");
            select.empty();
            select.append($("<option disabled selected value>").text("Select Gender"));

            for (var i = 0; i < genderList.length; i++) {
                select.append($("<option>").val(genderList[i]).text(genderList[i]));
            }
        } else {
            console.log("Empty or invalid data received.");
        }
    },
    error: function (response) {
        console.log(response.responseText);
    }
});


function findage() {
  var PresentDay = new Date();
  var dateOfBirth = new Date(document.getElementById("dob").value);
  var months =
    PresentDay.getMonth() -
    dateOfBirth.getMonth() +
    12 * (PresentDay.getFullYear() - dateOfBirth.getFullYear());
  document.getElementById("age").value = Math.round(months / 12);
}

function IDGenerator() {
  this.length = 3;
  this.timestamp = +new Date();

  var _getRandomInt = function (min, max) {
    return Math.floor(Math.random() * (max - min + 1)) + min;
  };

  this.generate = function () {
    var ts = this.timestamp.toString();
    var parts = ts.split("").reverse();
    var id = "EMP";

    for (var i = 0; i < this.length; ++i) {
      var index = _getRandomInt(0, parts.length - 1);
      id += parts[index];
    }

    return id;
  };
}

function viewData() {
  window.open("Report.aspx", "_self");
}

function autoGenerate() {
  if (window.location.href === "http://localhost:64569/Form") {
    output = document.querySelector("#empid");
    var generator = new IDGenerator();
    output.value = generator.generate();
  } else {
    console.log(window.location.pathname);
  }
}

//Getting value from URL
$(document).ready(function () {
  let params = new URLSearchParams(document.location.search);
  let e = params.get("Empid");
  $("#empid").val(e);

  // Connect to the database and retrieve the employee information
  $.ajax({
    url: "Employee.asmx/GetEmployee",
    data: { Empid: e },
    contentType: "application/x-www-form-urlencoded; charset=UTF-8",
    dataType: "json",
    method: "post",
    success: function (data) {
      let isDataFilledByUrl = false;
      for (let i = 0; i < data.length; i++) {
        if (data[i].Empid == e) {
          $("#fname").val(data[i].Firstname);
          $("#mname").val(data[i].Middlename);
          $("#lname").val(data[i].Lastname);
          $("#gender").val(data[i].Gender);
          $("#dob").val(data[i].DateOfBirth);
          $("#age").val(data[i].Age);
          isDataFilledByUrl = true;
          break;
        }
      }
      $("#save").click(function () {
        if (!$("#fname").val() || !$("#gender").val() || !$("#dob").val()) {
          alert("Mandatory Fields can't be empty!");
        } 
        else if  (isDataFilledByUrl) {
          // Perform update operation here
        let updatedData = {
          Empid: $("#empid").val(),
          Firstname: $("#fname").val(),
          Middlename: $("#mname").val(),
          Lastname: $("#lname").val(),
          Gender: $("#gender").val(),
          DateOfBirth: $("#dob").val(),
          Age: $("#age").val(),
        };
        $.ajax({
          url: "Employee.asmx/UpdateEmployee",
          data: JSON.stringify(updatedData),
          contentType: "application/json; charset=utf-8",
          dataType: "json",
          method: "post",
          success: function (data) {
            if (data.d == true) {
              alert("Employee updated successfully!");
            } else {
              alert("Error updating employee!");
            }
          },
          error: function (err) {
            alert("Enter the Mendatory Fields!");
          },
        });
        } else {
          // Perform save operation here
          let newData = {
            Empid: $("#empid").val(),
            Firstname: $("#fname").val(),
            Middlename: $("#mname").val(),
            Lastname: $("#lname").val(),
            Gender: $("#gender").val(),
            DateOfBirth: $("#dob").val(),
            Age: $("#age").val(),
          };
          $.ajax({
            url: "Employee.asmx/SaveEmployee",
            data: JSON.stringify(newData),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            method: "post",
            success: function (data) {
              if (data.d == true) {
                alert("Employee saved successfully!");
                $("#fname").val("");
                $("#mname").val("");
                $("#lname").val("");
                $("#gender").val("");
                $("#dob").val("");
                $("#age").val("");
                location.reload();
              } else {
                alert("Error saving employee!");
              }
            },
            error: function (err) {
              alert("Enter mandatary fields!");
            },
          });
        }
      });
    },
    error: function (jqXHR, textStatus, errorThrown) {
      console.log(jqXHR);
      console.log(textStatus);
      console.log(errorThrown);
    },
  });



});
