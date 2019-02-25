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

                    //não vou mostrar o campo "developerMessage" para o usuário
                    $("#summary").html(response.message + " | " + response.kind);
                    $("#summary").show();
                }
                else {
                    $("#Address").show();
                    $("#CEP_SEARCH").html(cep);                    
                    $("#city").html(response.city);    
                    $("#state").html(response.state);    
                    $("#neighborhood").html(response.neighborhood);    
                    $("#street").html(response.street);    
                    $("#ibge").html(response.ibge);    
                    $("#additional_info").html(response.additional_info);    

                    //BAIRRO e NEIGHBORHOOD são a mesma coisa
                    //$("#bairro").html(response.bairro);
                }               
            },
            failure: function (response) {
                alert(response);
            }
        });
    }
}
//INDEX PAGE METHODS