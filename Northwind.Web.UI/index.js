// console.log($('document'))

$(document).ready(function(){
    $("#getEmployeesBtn").click(function(){

        $.ajax({           
            type: "GET",
            url: "https://localhost:44357/api/employees",           
            dataType: "json",                     
            success: function(data){
                console.log(data);
            },
            error: function(XMLHttpRequest, textStatus, errorThrown) { 
                alert("Status: " + textStatus); alert("Error: " + errorThrown); 
            } 
          });

    });
});
   

   
