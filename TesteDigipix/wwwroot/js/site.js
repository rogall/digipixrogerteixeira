// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.

//HELPERS
(function ($) {
    $.isBlank = function (obj) {
        return (!obj || $.trim(obj) === "");
    };
})(jQuery);
//HELPERS

//INDEX PAGE METHODS
function GetAddressByCEP() {

    var cep = $("#Input_CEP").val();

    if ($.isBlank(cep)) {
        $("#Address").hide();
        $("#summary").html("Por favor preencha o CEP");
        $("#summary").show();
    }
    else {
        $("#summary").html("");
        $("#summary").hide();

        $.ajax({
            type: "GET",
            url: "Handler?handler=AddressByCEP&cep=" + cep,
            contentType: "application/json; charset=utf-8",
            datatype: "json",
            success: function (response) {

                if (!$.isBlank(response.message)) {
                    $("#Address").hide();

                    $("#summary").html(response.message);
                    $("#summary").show();
                }
                else {
                    $("#Address").show();
                    $("#CEP_SEARCH").html(response.zipcode);                    
                    $("#city").html(response.city);    
                    $("#state").html(response.state_short);    
                    $("#neighborhood").html(response.neighborhood);    
                    $("#street").html(response.street);  
                }               
            },
            failure: function (response) {
                alert(response);
            }
        });
    }
}
//INDEX PAGE METHODS