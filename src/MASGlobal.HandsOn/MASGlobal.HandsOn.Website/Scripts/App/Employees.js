$(document).ready(function () {
    var serverIsBusy = false;

    //DOM Elements
    var getEmployeesButton = $("#getEmployees");
    var table = $(".table");
    var employeeIdInput = $("#employeeId");
    var employeesResultsBody = $("#employeesResults");
    var alert = $(".alert");

    //Elements Events
    getEmployeesButton.click(getEmployees);
    employeeIdInput.keypress(function (event) {
        if (event.which == 13) {
            getEmployees();
        }
    });

    //Funtions
    function getEmployees() {

        // Let the server calls finish
        if (serverIsBusy)
            return;

        //Get the id
        var id = employeeIdInput.val();

        // Validate if id is a number
        if (isNaN(id)) {
            table.hide();
            alert.text("Use a valid id number, please don't use letters.");
            alert.show();

            return;
        }

        //Build Url
        var apiUrl = !id ? "/api/v1/employees" : "/api/v1/employees/" + id;

        // Clean table content
        employeesResultsBody.empty();

        // Disable Get Employee button to prevent multiple server calls
        getEmployeesButton.attr("disabled", "disabled");;

        // Hide Allert
        alert.hide();

        serverIsBusy = true;
        // Calling services
        $.getJSON(apiUrl)
            .done(function (data) {
                if (data && data.length > 0) {
                    $.each(data, function (index) {
                        employeesResultsBody.append(rowTemplate(data[index]));
                    });
                    table.show();
                    alert.hide();
                } else {
                    table.hide();
                    alert.text("Employee Doesn't Exist, Try with a different Id!");
                    alert.show();
                }
                getEmployeesButton.removeAttr("disabled");
            })
            .fail(function (jqXHR, textStatus, err) {
                table.hide();
                alert.text("Something went wront in the server, please try again.");
                alert.show();
            }).always(function () {
                getEmployeesButton.removeAttr("disabled");
                serverIsBusy = false;
            });
    }

    // Template to bulir the row
    function rowTemplate(employee) {
        var row = "<tr><th scope=\"row\">" + employee.id + "</th>";
        row = row + "<td>" + employee.name + "</td>";
        row = row + "<td>" + employee.roleName + "</td>";
        row = row + "<td>" + employee.contractTypeName + "</td>";
        row = row + "<td>" + employee.hourlySalary + "</td>";
        row = row + "<td>" + employee.monthlySalary + "</td>";
        return row + "<td>" + employee.annualSalary + "</td></tr>";
    }
});