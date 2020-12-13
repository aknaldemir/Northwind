var tBody = document.querySelector('#tableBody');
$(document).ready(function(){
    $("#getEmployeesBtn").click(function(){
        $.ajax({           
            type: "GET",
            url: "https://localhost:44357/api/employees",           
            dataType: "json",                     
            success: function (employees) {
                tBody.innerHTML = '';
                employees.forEach(function (employee) {
                    //console.log(employee);
                    tBody.innerHTML += `<tr><td>${employee.employeeId}</td><td>${employee.firstName}</td><td>${employee.lastName}</td><td>${employee.city}</td></tr>`;
                });
            },
            error: function(XMLHttpRequest, textStatus, errorThrown) { 
                alert("Status: " + textStatus); alert("Error: " + errorThrown); 
            } 
          });
    });
});
   

   
