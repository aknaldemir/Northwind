$(document).ready(function () {
    $('#getEmployeesBtn').click(function () {
        $.ajax({
            url: '/Home/GetAllEmployees',
            type: 'POST',
            dataType: 'json',
            success: function (data) {
                $('#allEmployeesDiv').load("/Employee/EmployeesList");


                console.log(data);



                //$.each(data, function (i, item) {
                   
                //});
            }
        });
    });
});

